using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
    public class HKCarPlateRecognizer
    {
        private string mIP;
        private int mNo=0;
        private int mPort = 0;
        private string mUserName;
        private string mPassword;

        private Int32 m_lUserID = -1;
        private Int32 m_lAlarmHandle = -1;
        private Int32 iListenHandle = -1;
        private int iDeviceNumber = 0; //添加设备个数
        private uint iLastErr = 0;
        private string strErr;
        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        public delegate void UpdateListBoxCallback(string strAlarmTime, string strDevIP, string strAlarmMsg);

        CHCNetSDK.NET_VCA_TRAVERSE_PLANE m_struTraversePlane = new CHCNetSDK.NET_VCA_TRAVERSE_PLANE();
        CHCNetSDK.NET_VCA_AREA m_struVcaArea = new CHCNetSDK.NET_VCA_AREA();
        CHCNetSDK.NET_VCA_INTRUSION m_struIntrusion = new CHCNetSDK.NET_VCA_INTRUSION();
        CHCNetSDK.UNION_STATFRAME m_struStatFrame = new CHCNetSDK.UNION_STATFRAME();
        CHCNetSDK.UNION_STATTIME m_struStatTime = new CHCNetSDK.UNION_STATTIME();

        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);
        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;
        private int mRealHandle = 0;
        private CaptureMode captureMode = CaptureMode.Orginal;
        private int cutPhotoWidth = 640;
        private int cutPhotoHeight = 320;
        private bool openVideo = false;
        private PictureBox picVideo;

        public HKCarPlateRecognizer(string ip, int no, int port, string userName, string password, bool openVideo, PictureBox picVideo) 
        {
            mIP = ip;
            mNo = no;
            mPort = port;
            mUserName = userName;
            mPassword = password;
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                Logger.Write("NET_DVR_Init error!");
                return;
            }
            else
            {
                byte[] strIP = new byte[16 * 16];
                uint dwValidNum = 0;
                Boolean bEnableBind = false;

                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, Path.Combine(Application.StartupPath,"Log","HkSdk",DateTime.Now.ToString("yyyyMMdd")), false);
                //设置报警回调函数
                if (m_falarmData_V31 == null)
                {
                    m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MsgCallback_V31);
                }
                CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);
            }
            this.openVideo = openVideo;
            this.picVideo = picVideo;
            Login();
            StartAlarm();
            if (openVideo && picVideo != null) 
            {
                InitVideo();
            }
        }

        /// <summary>
        /// 抓取JPEG格式图片
        /// </summary>
        /// <param name="weightId">磅单ID</param>
        /// <returns></returns>
        public BFile Capture(string weightId, string waterMarkText, FileType fileType = FileType.Enter)
        {
            BFile file = null;

            bool isCaptured = false;
            //图片保存路径和文件名
            string filePath = string.Format("File\\Graphic\\{0}\\", weightId);
            filePath = string.Format("File\\Graphic\\{0}\\", DateTime.Now.ToString("yyyyMMdd"));
            string sourceFileName;
            string imgFileName;
            string fileExten = "jpg";
            imgFileName = filePath + FileHelper.GenerateFileName(fileExten);
            sourceFileName = filePath + FileHelper.GenerateFileName(fileExten);
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + sourceFileName;
            string waterMarkImageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "logo.png");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            VideoCameraSdk.NET_DVR_JPEGPARA lpJpegPara = new VideoCameraSdk.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //图像质量
            //lpJpegPara.wPicSize = 0xff; //抓图分辨率: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档
            lpJpegPara.wPicSize = 2;
            //JPEG抓图
            isCaptured = VideoCameraSdk.NET_DVR_CapturePicture(mRealHandle, fullPath);  //抓拍当前预览的视频比下面那个方法抓拍的图片要清晰完整
            if (!File.Exists(fullPath))
                isCaptured = VideoCameraSdk.NET_DVR_CaptureJPEGPicture(m_lUserID, 1, ref lpJpegPara, sourceFileName);
            if (!isCaptured)
            {
                try
                {
                    isCaptured = VideoCameraSdk.NET_DVR_CapturePicture(mRealHandle, fullPath);
                    //VideoCameraSdk.CAPTURE_MODE.JPEG_MODE
                }
                catch (Exception e)
                {
                    Logger.WriteException(e);
                }
            }

            if (!File.Exists(fullPath)) //因为抓拍有延迟,所以需要在此暂停1秒
                Thread.Sleep(300);
            if (isCaptured || File.Exists(fullPath))
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
                //Logger.Write(string.Format("Capture-IsAddMark-{0}-WeightId-{1}-SourceFile-{2}", isAddMark, weightId, sourceFileName));
                file = new BFile();
                file.FileId = YF.MWS.Util.Utility.GetGuid();
                file.TableName = "B_Weight";
                file.RecId = weightId;
                file.BusinessType = FileBusinessType.Graphic.ToString();
                file.FileExtension = fileExten;
                file.FileUrl = newImgFileName;
                file.SyncState = (int)SyncState.UnSynced;
                file.FileType = (int)fileType;
                if (isAddMark)
                {
                    file.FileUrl = newImgFileName;
                }
                else
                {
                    file.FileUrl = sourceFileName;
                }
                FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + imgFileName);
            }
            return file;
        }

        public void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            switch (lCommand)
            {
                case CHCNetSDK.COMM_UPLOAD_PLATE_RESULT://交通抓拍结果上传(老报警信息类型)
                    ProcessCommAlarm_Plate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ITS_PLATE_RESULT://交通抓拍结果上传(新报警信息类型)
                    ProcessCommAlarm_ITSPlate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
            }
        }

        public bool MsgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            AlarmMessageHandle(lCommand, ref pAlarmer, pAlarmInfo, dwBufLen, pUser);

            return true; //回调函数需要有返回，表示正常接收到数据
        }

        public void AlarmMessageHandle(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            switch (lCommand)
            {
                case CHCNetSDK.COMM_UPLOAD_PLATE_RESULT://交通抓拍结果上传(老报警信息类型)
                    ProcessCommAlarm_Plate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                case CHCNetSDK.COMM_ITS_PLATE_RESULT://交通抓拍结果上传(新报警信息类型)
                    ProcessCommAlarm_ITSPlate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
            }
        }

        private void ProcessCommAlarm_Plate(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_DVR_PLATE_RESULT struPlateResultInfo = new CHCNetSDK.NET_DVR_PLATE_RESULT();
            uint dwSize = (uint)Marshal.SizeOf(struPlateResultInfo);
            struPlateResultInfo = (CHCNetSDK.NET_DVR_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_PLATE_RESULT));

            //报警设备IP地址
            string strIP = pAlarmer.sDeviceIP;

            //抓拍时间：年月日时分秒
            string strTimeYear = System.Text.Encoding.UTF8.GetString(struPlateResultInfo.byAbsTime);

            //上传结果
            string stringAlarm = "抓拍上传，" + "车牌：" + struPlateResultInfo.struPlateInfo.sLicense + "，车辆序号：" + struPlateResultInfo.struVehicleInfo.dwIndex;

            PlateInfo plateInfo = new PlateInfo();
            plateInfo.DeviceID = (uint)mNo;
            plateInfo.IP = strIP;
            plateInfo.Num = struPlateResultInfo.struPlateInfo.sLicense;
            if (!string.IsNullOrEmpty(plateInfo.Num) && plateInfo.Num != "无车牌")
            {
                if (!string.IsNullOrEmpty(plateInfo.Num) && plateInfo.Num.Length > 1)
                {
                    plateInfo.Num = plateInfo.Num.Substring(1);
                }
                if (RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                    //RecognizePlate.BeginInvoke(plateInfo, null, null);
                }
            }
        }

        private void ProcessCommAlarm_ITSPlate(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult = new CHCNetSDK.NET_ITS_PLATE_RESULT();
            uint dwSize = (uint)Marshal.SizeOf(struITSPlateResult);
            struITSPlateResult = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));
            //报警设备IP地址
            string strIP = pAlarmer.sDeviceIP;
            //上传结果
            string stringAlarm = "抓拍上传，" + "车牌：" + struITSPlateResult.struPlateInfo.sLicense + "，车辆序号：" + struITSPlateResult.struVehicleInfo.dwIndex;

            PlateInfo plateInfo = new PlateInfo();
            plateInfo.DeviceID = (uint)mNo;
            plateInfo.IP = strIP;
            plateInfo.Num = struITSPlateResult.struPlateInfo.sLicense;
            if (!string.IsNullOrEmpty(plateInfo.Num) && plateInfo.Num != "无车牌")
            {
                if (!string.IsNullOrEmpty(plateInfo.Num) && plateInfo.Num.Length > 1)
                {
                    plateInfo.Num = plateInfo.Num.Substring(1);
                }
                if (RecognizePlate != null)
                {
                    RecognizePlate(plateInfo);
                    //RecognizePlate.BeginInvoke(plateInfo, null, null);
                }
            }
        }
        

        private void Login() 
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(mIP, mPort, mUserName, mPassword, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                strErr = "登录" + mNo + "号海康车牌识别仪失败,错误内容:" + iLastErr; //登录失败
                Logger.Write(strErr);
            }
            else
            {
                CHCNetSDK.NET_DVR_SetConnectTime(30000, 3);
                Logger.Write("登录" + mNo + "号海康车牌识别仪成功,IP:"+mIP);
            }
        }

        private void InitVideo() 
        {
            VideoCameraSdk.NET_DVR_PREVIEWINFO lpPreviewInfo = new VideoCameraSdk.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = picVideo.Handle;//预览窗口
            lpPreviewInfo.lChannel = 1;//预览的设备通道
            lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

            IntPtr pUser = new IntPtr();//用户数据

            //打开预览
            mRealHandle = VideoCameraSdk.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null, pUser);
            if (mRealHandle < 0)
            {
                iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                string errMsg = mNo + " NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                Logger.Write(errMsg);
            }
        }

        private void StartAlarm() 
        {
            CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
            struAlarmParam.dwSize = (uint)Marshal.SizeOf(struAlarmParam);
            struAlarmParam.byLevel = 1; //0- 一级布防,1- 二级布防
            struAlarmParam.byAlarmInfoType = 1;//智能交通设备有效，新报警信息类型
            struAlarmParam.byFaceAlarmDetection = 1;//1-人脸侦测
            m_lAlarmHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref struAlarmParam);
            if (m_lAlarmHandle < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                strErr = "海康车牌识别仪布防失败，错误号：" + iLastErr; //布防失败，输出错误号
                Logger.Write(strErr);
            }
            else 
            {
                Logger.Write("海康车牌识别仪布防成功");
            }
        }

        public void Logout() 
        {
            if (m_lAlarmHandle > 0) 
            {
                CHCNetSDK.NET_DVR_CloseAlarmChan_V30(m_lAlarmHandle);
            }
            if (mRealHandle >= 0)
            {
                VideoCameraSdk.NET_DVR_StopRealPlay(mRealHandle);
                mRealHandle = -1;
            }
            CHCNetSDK.NET_DVR_Logout(m_lUserID);
        }

        public void Realse() 
        {
            //释放SDK资源，在程序结束之前调用
            CHCNetSDK.NET_DVR_Cleanup();
        }

    }
}
