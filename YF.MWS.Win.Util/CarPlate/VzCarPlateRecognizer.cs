using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.CarPlate;
using YF.Utility.Gdi;
using YF.Utility.IO;
using YF.Utility.Log;
using YF.Utility.Metadata;

namespace YF.MWS.Win.Util.CarPlate
{
    /// <summary>
    /// 臻识车牌识别仪
    /// </summary>
    public class VzCarPlateRecognizer
    {
        private string ip;
        private UInt16 port = 0;
        private string userName;
        private string password;
        private int handle = 0;
        private int flag = 0;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);
        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;
        private VzClientSDK.VZLPRC_PLATE_GROUP_INFO_CALLBACK[] m_PlateGroupResult = new VzClientSDK.VZLPRC_PLATE_GROUP_INFO_CALLBACK[10];
        private bool isSuccess = false;
        private PictureBox picVideo;
        private CaptureMode captureMode = CaptureMode.Orginal;
        private int cutPhotoWidth = 640;
        private int cutPhotoHeight = 320;
        private bool openVideo = false;
        private int mPlayHandle = 0;

        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }

        public VzCarPlateRecognizer(string mIP, UInt16 mport, string mUserName, string mPassword, bool openVideo, PictureBox picVideo) 
        {
            ip = mIP;
            port = mport;
            userName = mUserName;
            password = mPassword;
            this.openVideo = openVideo;
            this.picVideo = picVideo;
            VzClientSDK.VzLPRClient_Setup();
            Login();
        }

        public void Login() 
        {
            handle = VzClientSDK.VzLPRClient_Open(ip, port, userName, password);
            Logger.Write(string.Format("IP:{0},port:{1},userName:{2},password:{3}",ip,port,userName,password));
            Logger.Write("连接臻识车牌识别仪-Handle:" + handle);
            if (handle == 0)
            {
                Logger.Write("连接臻识车牌识别仪失败");
            }
            else
            {
                int retSetDG = VzClientSDK.VzLPRClient_SetDGResultEnable(handle, true);
                if (retSetDG != 0)
                {
                    Logger.Write("开启臻识车牌识别仪接收组网结果失败");
                    return;
                }
                isSuccess = true;
                m_PlateGroupResult[flag] = new VzClientSDK.VZLPRC_PLATE_GROUP_INFO_CALLBACK(OnPlateGroupInfo);
                VzClientSDK.VzLPRClient_SetPlateGroupInfoCallBack(handle, m_PlateGroupResult[flag], IntPtr.Zero);
                if(openVideo && picVideo!=null)
                    mPlayHandle = VzClientSDK.VzLPRClient_StartRealPlay(handle, picVideo.Handle);//播放实时视频
            }
        }

        public void Logoff() 
        {
            if (mPlayHandle > 0)
            {
                VzClientSDK.VzLPRClient_StopRealPlay(mPlayHandle);
                mPlayHandle = 0;
            }
            if (handle != 0)
            {
                VzClientSDK.VzLPRClient_SetDGResultEnable(handle, false);//关闭“接收组网识别结果"
                VzClientSDK.VzLPRClient_Close(handle);
            }
        }

        /// <summary>
        /// 手动触发
        /// </summary>
        public bool ManualTrigger()
        {
            bool isSuccess = false;
            if (handle > 0)
            {
                int result=VzClientSDK.VzLPRClient_ForceTrigger(handle);
                if (result == 0)
                    isSuccess = true;
            }
            return isSuccess;
        }

        public BFile Capture(string weightId, string waterMarkText)
        {
            BFile file = null;
            if (mPlayHandle == 0)
                return file;
            bool isCapture = false;
            string filePath = string.Format("File\\Graphic\\{0}\\", DateTime.Now.ToString("yyyyMMdd"));
            string sourceFileName;
            string imgFileName;
            string fileExten = "jpg";
            imgFileName = filePath + FileHelper.GenerateFileName(fileExten);
            sourceFileName = filePath + FileHelper.GenerateFileName(fileExten);
            string waterMarkImageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "logo.png");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            try
            {
                int res = VzClientSDK.VzLPRClient_GetSnapShootToJpeg2(mPlayHandle, sourceFileName, 80);
                if(res==0)
                    isCapture = true;
            }
            catch (System.Exception ex)
            {
                Logger.WriteException(ex);
            }
            if (File.Exists(sourceFileName) && isCapture)
            {
                if (captureMode == CaptureMode.Cut)
                {
                    imgFileName = filePath + FileHelper.GenerateFileName("jpg");
                    GraphicsUtil.GenerateThumbnail(AppDomain.CurrentDomain.BaseDirectory + sourceFileName,
                                                   AppDomain.CurrentDomain.BaseDirectory + imgFileName,
                                                   cutPhotoWidth, cutPhotoHeight, ThumbnailGenerateMode.FixedWidth);
                    FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + sourceFileName);
                }
                fileExten = Path.GetExtension(imgFileName);
                string newImgFileName = filePath + FileHelper.GenerateFileName(fileExten);
                List<WaterMarkText> markTexts = new List<WaterMarkText>();
                markTexts.Add(new WaterMarkText() { MarkText = waterMarkText, WatermarkPosition = WatermarkPositionType.TopLeft });
                List<WaterMarkImage> markImages = new List<WaterMarkImage>();
                markImages.Add(new WaterMarkImage() { MarkImagePath = waterMarkImageFilePath, WatermarkPosition = WatermarkPositionType.BottomRight });
                bool isAddMark = false;
                if (captureMode == CaptureMode.Cut)
                {
                    isAddMark = GraphicsUtil.AddWaterMark(AppDomain.CurrentDomain.BaseDirectory + imgFileName,
                                                           AppDomain.CurrentDomain.BaseDirectory + newImgFileName, markTexts, markImages);
                }
                else
                {
                    isAddMark = GraphicsUtil.AddWaterMark(AppDomain.CurrentDomain.BaseDirectory + sourceFileName,
                                                           AppDomain.CurrentDomain.BaseDirectory + newImgFileName, markTexts, markImages);
                }
                FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + imgFileName);
                if (isAddMark)
                {
                    file = new BFile();
                    file.FileId = YF.MWS.Util.Utility.GetGuid();
                    file.TableName = "B_Weight";
                    file.RecId = weightId;
                    file.BusinessType = FileBusinessType.Graphic.ToString();
                    file.FileExtension = fileExten;
                    file.FileUrl = newImgFileName;
                    file.SyncState = 0;
                }
            }
            return file;
        }

        private int OnPlateGroupInfo(int handle, IntPtr pUserData,
                                     int exitEntryInfo,
                                     IntPtr exitIvsInfo,
                                     IntPtr entryIvsInfo,
                                     IntPtr exitDGInfo,
                                     IntPtr entryDGInfo)
        {
            VzClientSDK.TH_PlateResult entryInfo = new VzClientSDK.TH_PlateResult();
            VzClientSDK.TH_PlateResult exitInfo = new VzClientSDK.TH_PlateResult();
            if (entryIvsInfo != null)
            {
                entryInfo = (VzClientSDK.TH_PlateResult)Marshal.PtrToStructure(entryIvsInfo, typeof(VzClientSDK.TH_PlateResult));
            }
            if (exitIvsInfo != null)
            {
                exitInfo = (VzClientSDK.TH_PlateResult)Marshal.PtrToStructure(exitIvsInfo, typeof(VzClientSDK.TH_PlateResult));
            }
            string carNo = string.Empty;
            //获取入口设备组网车牌识别结果
            if (exitEntryInfo == 0)
            {
                //车牌号码
                carNo = new string(entryInfo.license);
            }
            //获取出口设备组网车牌结果
            else if (exitEntryInfo == 1)
            {
                //车牌号码
                carNo = new string(entryInfo.license);
                if (string.IsNullOrEmpty(carNo))
                    carNo = new string(exitInfo.license);
            }
            Logger.Write("CarNo:" + carNo);
            if (!string.IsNullOrEmpty(carNo))
            {
                PlateInfo plateInfo = new PlateInfo();
                plateInfo.IP = ip;
                plateInfo.Num = carNo;
                if (this.RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                }
            }
            return 0;
        }

        public void Relase() 
        {
            VzClientSDK.VzLPRClient_Cleanup();
        }
    }
}
