using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.MWS.Metadata.CarPlate;

namespace YF.MWS.Win.Util
{
    /// <summary>
    /// 快号通车牌识别仪
    /// 对应软件设置的名称：仓舒车牌识别仪_KHT
    /// </summary>
    public class KHTUtil
    {
        private bool isRecoRan = false;
        private string mIP = string.Empty;
        /// <summary>
        /// 连接状态事件
        /// </summary>
        private KHTSdk.WTYConnectCallback ConnectCallback = null;
        /// <summary>
        /// 获取识别结果事件
        /// </summary>
        private KHTSdk.WTYDataExCallback DataExCallback = null;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);

        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;

        /// <summary>
        /// 车牌识别仪是否正在运行
        /// </summary>
        public bool IsRecoRan
        {
            get { return isRecoRan; }
            set { isRecoRan = value; }
        }

        public KHTUtil(string ip, UInt16 port)
        {
            try
            {
                mIP = ip;
                UInt32 nMsg = 0;
                IntPtr[] ptrIP = new IntPtr[2];

                ptrIP[0] = Marshal.StringToHGlobalAnsi(ip);
                ptrIP[1] = IntPtr.Zero;

                ConnectCallback = new KHTSdk.WTYConnectCallback(this.ConnectState);
                DataExCallback = new KHTSdk.WTYDataExCallback(this.RecognizeCallback);
                // 注册链接状态函数
                KHTSdk.WTY_RegWTYConnEvent(this.ConnectCallback);
                // 注册获取识别结果回调函数
                KHTSdk.WTY_RegDataExEvent(this.DataExCallback);

                if (!Directory.Exists("CarNoRecognition\\"))
                {
                    Directory.CreateDirectory("CarNoRecognition\\");
                }
                // 设置回调函数中，图片的保存路径
                KHTSdk.WTY_SetSavePath("CarNoRecognition\\");
                //车牌识别一体机初始化
                int nRet = KHTSdk.WTY_InitSDK(port, ptrIP[1], nMsg, ptrIP[0]);
                if (nRet == 0)
                {
                    Logger.Write("初始化KHT车牌识别仪成功");
                    this.isRecoRan = true;
                }
                else 
                {
                    Logger.Write("初始化KHT车牌识别仪失败");
                }
            }
            catch (Exception ex)
            {
                Logger.Write("初始化KHT车牌识别仪失败,发生异常");
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 连接状态检测
        /// </summary>
        /// <param name="chWTYIP"></param>
        /// <param name="Status"></param>
        private void ConnectState(StringBuilder chWTYIP, UInt32 Status)
        {
            UInt32 nState = Status;
            if (nState == 0)
            {
                Logger.Write("快号通连接失败！");
            }
        }

        /// <summary>
        /// 获取识别结果回调函数
        /// </summary>
        /// <param name="recResult">识别结果</param>  
        private unsafe void RecognizeCallback(IntPtr recResult)
        {
            try
            {
                KHTSdk.plate_result recResult_ss = new KHTSdk.plate_result();
                int size = Marshal.SizeOf(recResult_ss);
                byte[] bytes = new byte[size];
                Marshal.Copy(recResult, bytes, 0, size);
                KHTSdk.plate_result recResult_s = Utility.ConverBytesToStructure<KHTSdk.plate_result>(bytes);
                string strPlate = new string(recResult_s.chLicense).TrimEnd('\0');
                PlateInfo plateInfo = new PlateInfo();
                plateInfo.IP = new string(recResult_s.chWTYIP).TrimEnd('\0');
                plateInfo.Num = strPlate;
                if (this.RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                    //this.RecognizePlate.BeginInvoke(recResult_s, null, null);
                }

                //// 显示识别时间
                //Int32 nYear = recResult_s.shootTime.Year;
                //Int32 nMonth = recResult_s.shootTime.Month;
                //Int32 nDay = recResult_s.shootTime.Day;
                //Int32 nHour = recResult_s.shootTime.Hour;
                //Int32 nMinute = recResult_s.shootTime.Minute;
                //Int32 nSecond = recResult_s.shootTime.Second;
                //Int32 nMillisecond = recResult_s.shootTime.Millisecond;
                //object[] D2 = { nYear, nMonth, nDay, nHour, nMinute, nSecond, nMillisecond };//传递的参数
                //BeginInvoke(new delShowRecogniseTime(ShowRecogniseTime), D2);

                //// 显示识别坐标
                //Int32 nLeft = recResult_s.pcLocation.Left;
                //Int32 nTop = recResult_s.pcLocation.Top;
                //Int32 nRight = recResult_s.pcLocation.Right;
                //Int32 nBottom = recResult_s.pcLocation.Bottom;
                //object[] D3 = { nLeft, nTop, nRight, nBottom };//传递的参数
                //BeginInvoke(new delShowPlateC(ShowPlateC), D3);                
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public static void Release() 
        {
            KHTSdk.WTY_QuitSDK();
        }
    }
}
