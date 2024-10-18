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
using YF.MWS.Metadata.Cfg;
using YF.Utility.Gdi;
using YF.Utility.IO;
using YF.Utility.Log;
using YF.Utility.Metadata;

namespace YF.MWS.Win.Util.CarPlate
{
    /// <summary>
    /// 华夏车牌识别仪
    /// </summary>
    public class HXPlateRecognizer
    {
        private IntPtr ptrSDK = IntPtr.Zero;
        private string whiteCarNo = "无车牌";
        private HXSDK.ICE_IPCSDK_OnPlate onPlate;
        private bool m_bExit = false;
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);
        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;
        private string ip = string.Empty;
        private bool openVideo = false;
        private PictureBox picVideo;
        private CaptureMode captureMode = CaptureMode.Orginal;
        private int cutPhotoWidth = 640;
        private int cutPhotoHeight = 320;
        private bool loginSuccess = false;

        public bool LoginSuccess
        {
            get { return loginSuccess; }
            set { loginSuccess = value; }
        }


        public HXPlateRecognizer(string ip, bool openVideo, PictureBox picVideo) 
        {
            SysCfg cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.Video != null) 
            {
                captureMode = cfg.Video.CaptureMode;
                cutPhotoHeight = cfg.Video.Height;
                cutPhotoWidth = cfg.Video.Width;
            }
            HXSDK.ICE_IPCSDK_Init(); //调用全局初始化
            onPlate = new HXSDK.ICE_IPCSDK_OnPlate(SDK_OnPlate);
            this.openVideo = openVideo;
            this.ip = ip;
            this.picVideo = picVideo;
            Login();
        }

        public void Login()
        {
            IntPtr videoHandle = IntPtr.Zero;
            if (picVideo != null)
            {
                videoHandle = picVideo.Handle;
            }
            if (openVideo && videoHandle != IntPtr.Zero)
            {
                ptrSDK = HXSDK.ICE_IPCSDK_OpenPreview(ip, 1, 1, (uint)videoHandle, onPlate, new IntPtr(0));
            }
            else
            {
                //ptrSDK = HXSDK.ICE_IPCSDK_Open(ip, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                ptrSDK = HXSDK.ICE_IPCSDK_OpenDevice(ip);
                HXSDK.ICE_IPCSDK_SetPlateCallback(ptrSDK, onPlate, new IntPtr(0));//设置获取车牌识别数据的回调函数
            }
            if (ptrSDK == IntPtr.Zero)
            {
                Logger.Write("connect hx car plate failed.");
            }
            else
                loginSuccess = true;
        }

        /// <summary>
        /// 手动触发车牌识别
        /// </summary>
        /// <returns></returns>
        public bool ManualTrigger() 
        {
            bool isSuccess = false;
            if (ptrSDK != IntPtr.Zero) 
            {
                StringBuilder strNum = new StringBuilder(32);
                StringBuilder strColor = new StringBuilder(64);
                uint len = 0;
                //IntPtr pLen = Marshal.AllocHGlobal(32);
                byte[] pdata = new byte[1048576];
                uint result = HXSDK.ICE_IPCSDK_Trigger(ptrSDK, strNum, strColor, pdata, 1048576, ref len);//软触发
                if (result == 1)
                    isSuccess = true;
                pdata = null;
                strNum = null;
                strColor = null;
            }
            return isSuccess;
        }

        public BFile Capture(string weightId, string waterMarkText) 
        {
            BFile file = null;
            if (!openVideo)
                return file;
            byte[] pdata = new byte[1048576];
            uint pLen = 0;
            UInt32 success = HXSDK.ICE_IPCSDK_Capture(ptrSDK, pdata, 1048576, ref pLen);//获取一张抓拍图
            if (1 == success && pLen > 0)
            {
                if (pLen > 0)
                {
                    byte[] dataImg = new byte[pLen];
                    Array.Copy(pdata, 0, dataImg, 0, dataImg.Length);//拷贝数据
                    file = CapturePhoto(dataImg, weightId,waterMarkText);//保存图片
                    dataImg = null;
                }
            }
            return file;
        }

        private BFile CapturePhoto(byte[] bytes, string weightId,string waterMarkText) 
        {
            BFile file = null;
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
                FileStream fs = new FileStream(sourceFileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                bw.Close();
                fs.Close();
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
                    file.Id = YF.MWS.Util.Utility.GetGuid();
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

        public void SDK_OnPlate(System.IntPtr pvParam,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcNumber,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcColor,
                    System.IntPtr pcPicData, uint u32PicLen, System.IntPtr pcCloseUpPicData, uint u32CloseUpPicLen,
                    short nSpeed, short nVehicleType, short nReserved1, short nReserved2,
                    float fPlateConfidence, uint u32VehicleColor, uint u32PlateType, uint u32VehicleDir, uint u32AlarmType,
                    uint u32SerialNum, uint uCapTime, uint u32ResultHigh, uint u32ResultLow)
        {
            try
            {
                int index = (int)pvParam;
                if (m_bExit)
                    return;
                if (pcNumber == whiteCarNo)
                {
                    return;
                }
                PlateInfo plateInfo = new PlateInfo();
                plateInfo.IP = pcIP;
                plateInfo.Num = pcNumber;
                Logger.Info(string.Format("Hx-CarNo:{0}", pcNumber));
                if (this.RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }
        public bool CloseGate() {
            if(ptrSDK == IntPtr.Zero) return false;
            return HXSDK.ICE_IPCSDK_ControlAlarmOut(ptrSDK,1)>0;
        }
        public bool OpenGate() {
            if(ptrSDK == IntPtr.Zero) return false;
            return HXSDK.ICE_IPCSDK_ControlAlarmOut(ptrSDK,2)>0;
        }
        public void Release() 
        {
            try
            {
                m_bExit = true;
                HXSDK.ICE_IPCSDK_Close(ptrSDK);
                HXSDK.ICE_IPCSDK_Fini(); //调用全局释放
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }
         
    }
}
