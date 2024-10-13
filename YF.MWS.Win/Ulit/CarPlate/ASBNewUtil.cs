using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.CarPlate;
using YF.Utility.IO;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.CarPlate
{
    public class ASBNewUtil
    {
        private string mIP;
        public ASBSdk.IPCSDK_CALLBACK call;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(ASBPlateInfo plateInfo);
        // 16KB 用于存储车牌信息足够了 */
        public char[] plate_result = new char[16 * 1024];
        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;

        public ASBNewUtil(string ip) 
        {
            mIP = ip;
            Init();
            //Open();
        }

        private void Init() 
        {
            int ret;
            ret = ASBSdk.IPCSDK_Init(8190);
            if (ret != 0)
            {
                Logger.Write(string.Format("Init ASB New failed,error code:{0}!",ret));
            }
            if (ret == 0)
            {
                //注册回调函数
                call = new ASBSdk.IPCSDK_CALLBACK(callback);
                ASBSdk.IPCSDK_Register_Callback(call);
                Logger.Write("Init ASB NEW successed!");
            }
        }

        private void Open() 
        {
            int ret = ASBSdk.IPCSDK_Manual_Open_Door(mIP);
            if (ret != 0) 
            {
                Logger.Write(string.Format("Open asb new failed,error code:{0}!",ret));
            }
        }

        unsafe public int callback(string ip, IntPtr buff, UInt32 len)
        {
            //数据长度  断点
            uint pllen = 0;
            //用于保存函数返回值
            int ret = 0;
            IntPtr ptPlate = Marshal.AllocHGlobal(plate_result.Length);
            ret = ASBSdk.IPCSDK_Get_Plate_Info(buff, ptPlate, ref pllen);
            StringBuilder license = new StringBuilder("", 16);
            ASBSdk.IPCSDK_Get_Plate_License(ptPlate, license);
            ASBPlateInfo plateInfo = new ASBPlateInfo();
            plateInfo.Num = license.ToString();
            plateInfo.IP = mIP;

            #region 生成全图jpeg文件名
            //图片保存路径和文件名
            string filePath =  string.Format("File\\Graphic\\{0}\\", DateTime.Now.ToString("yyyyMMdd"));
            string imgFileName;
            string fileExten = "jpg";
            imgFileName = filePath + FileHelper.GenerateFileName(fileExten);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            byte[] bytes = new byte[len];
            Marshal.Copy(buff, bytes, 0, (Int32)len);
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + imgFileName;
            FileStream fsWrite = new FileStream(fullPath, FileMode.OpenOrCreate);
            bool isGenerateImage = false;
            try
            {
                fsWrite.Write(bytes, 0, bytes.Length);
                fsWrite.Flush();
                isGenerateImage = true;
            }
            catch (Exception e)
            {
                Logger.WriteException(e);
            }
            finally
            {
                fsWrite.Close();
            }
            if (isGenerateImage) 
            {
                BFile file = new BFile();
                file.Id = YF.MWS.Util.Utility.GetGuid();
                file.TableName = "B_Weight";
                file.BusinessType = FileBusinessType.CarRecognition.ToString();
                file.FileExtension = fileExten;
                file.FileUrl = imgFileName;
                file.SyncState = 0;
                plateInfo.File = file;
            }
            #endregion

            if (this.RecognizePlate != null)
            {
                this.RecognizePlate.BeginInvoke(plateInfo, null, null);
            }
            return 0;
        } 

        private void Close() 
        {
            int ret = ASBSdk.IPCSDK_Manual_Close_Door(mIP);
            if (ret != 0)
            {
                Logger.Write("close asb failed!");
            }
        }

        public void Release()
        {
            try
            {
                ASBSdk.IPCSDK_Stop_Stream(mIP);
                Close();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
    }
}
