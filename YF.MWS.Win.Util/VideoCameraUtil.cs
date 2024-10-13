using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.Utility.IO;
using YF.MWS.Db;
using YF.MWS.Win.Util.Video;
using YF.MWS.Win.Util.Video.DHPlaySDK;
using System.Windows.Forms;
using YF.Utility.Metadata;
using YF.Utility.Gdi;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util.Video.DHNew;
using YF.MWS.BaseMetadata;
using System.Threading;
using YF.MWS.Util;

namespace YF.MWS.Win.Util
{
    public class VideoCameraUtil
    {
        private Int32 m_lUserID = -1;
        private string configFilePath = Path.Combine(Application.StartupPath, "SysSetting.xml");
        private fRealDataCallBack cbRealData = null;
        /// <summary>
        /// Set real-time data call or not
        /// </summary>
        private bool blnSetRealDataCallBack = false;
        /// <summary>
        /// 登录设备的句柄
        /// </summary>
        private IntPtr loginDeviceHandle = IntPtr.Zero;
        /// <summary>
        /// 设备Id
        /// </summary>
        public Int32 LoginUserID
        {
            get { return m_lUserID; }
            private set { m_lUserID = value; }
        }

        /// <summary>
        /// 播放视频窗体句柄
        /// </summary>
        private IntPtr m_hWnd = IntPtr.Zero;

        /// <summary>
        /// 播放视频窗体句柄
        /// </summary>
        public IntPtr PlayHandle
        {
            get { return m_hWnd; }
            private set { m_hWnd = value; }
        }

        /// <summary>
        /// 实时预览Id
        /// </summary>
        private Int32 m_lRealHandle = -1;

        private IntPtr m_lpRealHanel;

        /// <summary>
        /// 实时预览Id
        /// </summary>
        public Int32 DVRRealHandle
        {
            get { return m_lRealHandle; }
            private set { m_lRealHandle = value; }
        }

        private bool m_bRecord = false;

        /// <summary>
        /// 是否正在录制视频
        /// </summary>
        public bool IsRecord
        {
            get { return m_bRecord; }
            private set { m_bRecord = value; }
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        private uint iLastErr = 0;

        /// <summary>
        /// 摄像机品牌
        /// </summary>
        private string camera;
        /// <summary>
        /// 视屏通道
        /// </summary>
        private string channelName;

        private int channelNo=0;
        /// <summary>
        /// 输出错误消息
        /// </summary>
        private string errMsg;

        private int cameraCount;
        /// <summary>
        /// 摄像机组数量
        /// </summary>
        public static int CameraGroupCount = 0;
        private CaptureMode captureMode = CaptureMode.Orginal;
        private int cutPhotoWidth = 640;
        private int cutPhotoHeight = 320;
        private DHVideo dhVideo = null;
        private VideoFileType videoFileType = VideoFileType.Mp4;
        private string targetFilePath = string.Empty;
        private string sourceFilePath = string.Empty;

        public VideoCameraUtil(string videoCamera, int cameraNo, int channelNumber,int cameraCount)
        {
            cbRealData = new fRealDataCallBack(DHRealDataFun);
            this.camera = videoCamera;
            this.cameraCount = cameraCount;
            this.channelName = string.Format("VideoCamera{0}/VideoChannel{1}", cameraNo, channelNumber);
            SysCfg cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.Video != null) 
            {
                captureMode = cfg.Video.CaptureMode;
                cutPhotoHeight = cfg.Video.Height;
                cutPhotoWidth = cfg.Video.Width;
            }
        }

        /// <summary>
        /// 登录网络摄像头
        /// </summary>
        /// <returns></returns>
        public bool LoginCamera()
        {
            try
            {
                string value;
                if (!XmlUtil.IsNodeExists(configFilePath, this.channelName))
                {
                    return false;
                }
                else
                {
                    if (XmlUtil.GetXmlAttributeValue(configFilePath, this.channelName, "Enable", out value, out errMsg))
                    {
                        if (!Convert.ToBoolean(value))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    object obj = XmlUtil.GetXmlNodeEntity(configFilePath, this.channelName, SysConfig.VideoChannel);
                    if (obj == null)
                    {
                        return false;
                    }
                    VideoChannel channel = obj as VideoChannel;
                    if (channel != null)
                    {
                        switch (this.camera)
                        {
                            case "DH":
                                NET_DEVICEINFO deviceInfo = new NET_DEVICEINFO();
                                int error = 0;
                                m_lUserID = NETClient.NETLogin(channel.IpAddress, ushort.Parse(channel.PortNumber.ToString()), channel.UserName, channel.PassWord, out deviceInfo, out error);
                                if (m_lUserID <= 0)
                                {
                                    errMsg = this.channelName + " 大华摄像头登录失败,错误原因:" + NETClient.LastOperationInfo.ToString(NETClient.ErrInfoFormatStyle);
                                    Logger.Write(errMsg);
                                    return false;
                                }
                                break;
                            case "DHNew":
                                dhVideo = new DHVideo();
                                return dhVideo.Login(channel.IpAddress, channel.PortNumber, channel.UserName, channel.PassWord);
                            case "Hikvision":
                                VideoCameraSdk.NET_DVR_DEVICEINFO_V30 HKDeviceInfo = new VideoCameraSdk.NET_DVR_DEVICEINFO_V30();
                                channelNo = channel.ChannelNo;
                                //登录设备
                                m_lUserID = VideoCameraSdk.NET_DVR_Login_V30(channel.IpAddress, channel.PortNumber, channel.UserName, channel.PassWord, ref HKDeviceInfo);
                                if (m_lUserID < 0)
                                {
                                    iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                                    errMsg = this.channelName + " 登录海康摄像机失败,错误代码= " + iLastErr; //登录失败，输出错误号
                                    Logger.Write(errMsg);
                                    return false;
                                }
                                break;
                            case "XM":
                                XMSDK.H264_DVR_DEVICEINFO XMDeviceInfo = new XMSDK.H264_DVR_DEVICEINFO();
                                int nError = 0;
                                //登录设备
                                m_lUserID = XMSDK.H264_DVR_Login(channel.IpAddress, (ushort)channel.PortNumber, channel.UserName, channel.PassWord, out XMDeviceInfo, out nError, XMSDK.SocketStyle.TCPSOCKET);
                                if (m_lUserID < 0)
                                {
                                    nError = XMSDK.H264_DVR_GetLastError();
                                    errMsg = this.channelName + " H264_DVR_Login failed, error code= " + nError; //登录失败，输出错误号
                                    Logger.Write(errMsg);
                                    return false;
                                }
                                break;
                            case "YS":
                                if (IntPtr.Zero != m_lpRealHanel)
                                {
                                    NETDEVSDK.NETDEV_StopRealPlay(m_lpRealHanel);
                                }
                                NETDEVSDK.NETDEV_Logout(loginDeviceHandle);
                                m_lpRealHanel = IntPtr.Zero;
                                loginDeviceHandle = IntPtr.Zero;
                                IntPtr pstDevInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEVICE_INFO_S)));
                                loginDeviceHandle = NETDEVSDK.NETDEV_Login(channel.IpAddress, 0, channel.UserName, channel.PassWord, pstDevInfo);
                                Marshal.FreeHGlobal(pstDevInfo);
                                if (loginDeviceHandle == IntPtr.Zero)
                                {
                                    errMsg = this.channelName + "login failed,the error is [" + NETDEVSDK.NETDEV_GetLastError().ToString() + "]";
                                    Logger.Write(errMsg);
                                    return false;
                                }
                                else
                                {
                                    Logger.Write(string.Format("vedio YS login info,user:{0},password:{1},login successed", channel.UserName, channel.PassWord));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e) 
            {
                Logger.WriteException(e);
                return false;
            }
        }

        /// <summary>
        /// 设置视频图像结构
        /// </summary>
        /// <param name="showChanName">是否显示通道名称</param>
        /// <param name="chanLeftX">通道名称显示左上角</param>
        /// <param name="chanLeftY">通道名称显示右上角</param>
        /// <param name="showOSD">是否显示OSD</param>
        /// <param name="osdLeftX">OSD显示左上角</param>
        /// <param name="osdLeftY">OSD显示右上角</param>
        public void SetPicStruct(bool showChanName, int chanLeftX, int chanLeftY, bool showOSD, int osdType, int osdLeftX, int osdLeftY)
        {
            switch (this.camera)
            {
                case "Hikvision":
                    VideoCameraSdk.NET_DVR_PICCFG_V30 picStruct = new VideoCameraSdk.NET_DVR_PICCFG_V30();

                    uint len = 0;
                    IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(picStruct));
                    Marshal.StructureToPtr(picStruct, ptr, false);
                    bool isSuccess = VideoCameraSdk.NET_DVR_GetDVRConfig(m_lUserID, VideoCameraSdk.NET_DVR_GET_PICCFG_V30, 1, ptr, (uint)Marshal.SizeOf(picStruct), ref len);

                    picStruct = (VideoCameraSdk.NET_DVR_PICCFG_V30)Marshal.PtrToStructure(ptr, typeof(VideoCameraSdk.NET_DVR_PICCFG_V30));
                    picStruct.dwShowChanName = (uint)Convert.ToInt32(showChanName);
                    picStruct.wShowNameTopLeftX = (ushort)chanLeftX;
                    picStruct.wShowNameTopLeftY = (ushort)chanLeftY;
                    picStruct.dwShowOsd = (uint)Convert.ToInt32(showOSD);
                    picStruct.byOSDType = Convert.ToByte(osdType);
                    picStruct.wOSDTopLeftX = (ushort)osdLeftX;
                    picStruct.wOSDTopLeftY = (ushort)osdLeftY;
                    picStruct.byDispWeek = Convert.ToByte(showOSD);

                    ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(picStruct));
                    Marshal.StructureToPtr(picStruct, ptr, false);
                    isSuccess = VideoCameraSdk.NET_DVR_SetDVRConfig(m_lUserID, VideoCameraSdk.NET_DVR_SET_PICCFG_V30, 1, ptr, (uint)Marshal.SizeOf(picStruct));
                    break;
                case "XM":
                    break;
            }
        }

        /// <summary>
        /// 设置文字水印
        /// </summary>
        /// <param name="showString">显示的文字</param>
        /// <param name="strLeftX">左上角X坐标</param>
        /// <param name="strLeftY">左上角Y坐标</param>
        public void SetWordWatermark(string showString, int strLeftX, int strLeftY)
        {
            //if (!string.IsNullOrEmpty(showString))
            //{
            //    switch (this.camera)
            //    {
            //        case "Hikvision":
            //            VideoCameraSdk.NET_DVR_SHOWSTRING_V30 showStruct = new VideoCameraSdk.NET_DVR_SHOWSTRING_V30();

            //            uint len = 0;
            //            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(showStruct));
            //            Marshal.StructureToPtr(showStruct, ptr, false);
            //            bool isSuccess = VideoCameraSdk.NET_DVR_GetDVRConfig(m_lUserID, VideoCameraSdk.NET_DVR_GET_SHOWSTRING_V30, 1, ptr, (uint)Marshal.SizeOf(showStruct), ref len);

            //            showStruct = (VideoCameraSdk.NET_DVR_SHOWSTRING_V30)Marshal.PtrToStructure(ptr, typeof(VideoCameraSdk.NET_DVR_SHOWSTRING_V30));
            //            showStruct.struStringInfo[0].sString = showString;
            //            showStruct.struStringInfo[0].wShowString = 1;
            //            showStruct.struStringInfo[0].wShowStringTopLeftX = (ushort)strLeftX;
            //            showStruct.struStringInfo[0].wShowStringTopLeftY = (ushort)strLeftY;
            //            showStruct.struStringInfo[0].wStringSize = (ushort)Encoding.Default.GetBytes(showString).Length;

            //            ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(showStruct));
            //            Marshal.StructureToPtr(showStruct, ptr, false);
            //            isSuccess = VideoCameraSdk.NET_DVR_SetDVRConfig(m_lUserID, VideoCameraSdk.NET_DVR_SET_SHOWSTRING_V30, 1, ptr, (uint)Marshal.SizeOf(showStruct));
            //            break;
            //        case "XM":
            //            break;
            //    }
            //}
        }

        /// <summary>
        /// 预览监控视频
        /// </summary>
        /// <param name="hWnd">视频播放窗体</param>
        /// <returns></returns>
        public bool PreviewCamera(IntPtr hWnd)
        {
            this.m_hWnd = hWnd;
            switch (this.camera)
            {
                case "DH":
                    m_lRealHandle = NETClient.NETRealPlay(m_lUserID, 0, m_hWnd);
                    if (NETPlay.NETPlayControl(PLAY_COMMAND.OpenStream, 0, IntPtr.Zero, 0, (UInt32)(900 * 1024)))
                    {
                        errMsg = "DH_DVR:successesed to open stream play!";
                        Logger.Write(errMsg);
                    }
                    else
                    {
                        errMsg = "DH_DVR:failed to open stream play!";
                        Logger.Write(errMsg);
                        return false;
                    }

                    if (NETPlay.NETSetStreamOpenMode(0, PLAY_MODE.STREAME_REALTIME))//Set stream play mode
                    {
                        errMsg = "DH_DVR:set stream mode successfully!";
                        Logger.Write(errMsg);
                    }
                    else
                    {
                        errMsg = "DH_DVR:Failed to set stream mode!";
                        Logger.Write(errMsg);
                        return false;
                    }
                    if (NETPlay.NETPlayControl(PLAY_COMMAND.Start, 0, hWnd))
                    {
                        errMsg = "DH_DVR:stream play successfully!";
                        Logger.Write(errMsg);
                    }
                    else
                    {
                        errMsg = "DH_DVR:failed to stream play!";
                        Logger.Write(errMsg);
                        return false;
                    }
                    if (NETClient.NETSetRealDataCallBack(m_lRealHandle, cbRealData, IntPtr.Zero))//Set data call process function
                    {
                        blnSetRealDataCallBack = true;
                    }
                    return true;
                case "DHNew":
                    if (dhVideo != null) 
                    {
                        return dhVideo.PreviewCamera(hWnd, channelNo);
                    }
                    return true;
                case "Hikvision":
                    VideoCameraSdk.NET_DVR_PREVIEWINFO lpPreviewInfo = new VideoCameraSdk.NET_DVR_PREVIEWINFO();
                    lpPreviewInfo.hPlayWnd = hWnd;//预览窗口
                    if (channelNo != 0)
                    {
                        lpPreviewInfo.lChannel = channelNo;//预览的设备通道
                    }
                    else
                    {
                        lpPreviewInfo.lChannel = 1;//预览的设备通道
                    }
                    if (cameraCount > 2)
                    {
                        lpPreviewInfo.dwStreamType = 1;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    }
                    else
                    {
                        lpPreviewInfo.dwStreamType = 0;
                    }
                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

                    VideoCameraSdk.REALDATACALLBACK RealData = new VideoCameraSdk.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                    IntPtr pUser = new IntPtr();//用户数据

                    //打开预览
                    m_lRealHandle = VideoCameraSdk.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                    if (m_lRealHandle < 0)
                    {
                        iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                        errMsg = this.channelName + " NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                        Logger.Write(errMsg);
                        return false;
                    }
                    return true;
                case "XM":
                    XMSDK.H264_DVR_CLIENTINFO lpClientInfo = new XMSDK.H264_DVR_CLIENTINFO();
                    lpClientInfo.hWnd = hWnd;
                    lpClientInfo.nChannel = 0;
                    lpClientInfo.nStream = 0;
                    lpClientInfo.nMode = 0;

                    //打开预览
                    m_lRealHandle = XMSDK.H264_DVR_RealPlay(m_lUserID, ref lpClientInfo);
                    if (m_lRealHandle < 0)
                    {
                        int nError = XMSDK.H264_DVR_GetLastError();
                        errMsg = this.channelName + " H264_DVR_RealPlay failed, error code= " + nError; //预览失败，输出错误号
                        Logger.Write(errMsg);
                        return false;
                    }
                    else
                    {
                        XMSDK.H264_DVR_MakeKeyFrame(m_lUserID, 1, 0);
                    }
                    return true;
                case "YS":
                    if (IntPtr.Zero == loginDeviceHandle)
                    {
                        return false;
                    }
                    int bRet;
                    if (IntPtr.Zero != m_lpRealHanel)
                    {
                        bRet = NETDEVSDK.NETDEV_StopRealPlay(m_lpRealHanel);
                        if (NETDEVSDK.TRUE == bRet)
                        {
                            m_lpRealHanel = IntPtr.Zero;
                        }
                    }
                    NETDEV_PREVIEWINFO_S stNetInfo = new NETDEV_PREVIEWINFO_S();
                    if (channelNo != 0)
                    {
                        stNetInfo.dwChannelID =channelNo;//预览的设备通道
                    }
                    else
                    {
                        stNetInfo.dwChannelID =1;//预览的设备通道
                    }
                    stNetInfo.hPlayWnd = m_hWnd;
                    stNetInfo.dwStreamType = (Int32)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN;
                    stNetInfo.dwLinkMode = (Int32)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;

                    m_lpRealHanel = NETDEVSDK.NETDEV_RealPlay(loginDeviceHandle, ref stNetInfo, IntPtr.Zero, IntPtr.Zero);
                    if (IntPtr.Zero == m_lpRealHanel)
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Real-time monitor data call process
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwDataType"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="dwUser"></param>
        private void DHRealDataFun(int lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr dwUser)
        {
            NETPlay.NETPlayControl(PLAY_COMMAND.InputData, 0, pBuffer, dwBufSize);
        }

        private void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {

        }

        /// <summary>
        /// 开始录制视频
        /// </summary>
        /// <param name="weightId">磅单ID</param>
        /// <returns></returns>
        public BFile StartRecord(string weightId)
        {
            BFile file = null;
            bool isRecorded = false;
            //录像保存路径和文件名
            string filePath = string.Format("File\\Video\\{0}\\", weightId);
            filePath = string.Format("File\\Video\\{0}\\", DateTime.Now.ToString("yyyyMMdd"));
            string videoFileName;
            string fileExten = "mp4";

            switch (this.camera)
            {
                case "DH":
                    fileExten = "avi";
                    break;
                case "Hikvision":
                    break;
                case "XM":
                    fileExten = "h264";
                    break;
            }
            videoFileName = filePath + FileHelper.GenerateFileName(fileExten);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            /***
            string[] files = Directory.GetFiles(filePath);
            if (files == null || files.Length == 0)
            {
                videoFileName = filePath + string.Format("Weight_01{0}", fileExten);
            }
            else
            {
                if (files.Length < 9)
                {
                    videoFileName = filePath + string.Format("Weight_0{0}{1}", files.Length + 1, fileExten);
                }
                else
                {
                    videoFileName = filePath + string.Format("Weight_{0}{1}", files.Length + 1, fileExten);
                }
            }****/

            if (m_bRecord == false)
            {
                switch (this.camera)
                {
                    case "DH":
                        isRecorded = NETPlay.NETStartDataRecord(0, videoFileName, 1);
                        if (!isRecorded) 
                        {
                            errMsg = this.channelName + " DH_DVR_SaveRealData failed." ;
                            Logger.Write(errMsg);
                        }
                        else
                        {
                            m_bRecord = true;
                        }
                        break;
                    case "Hikvision":
                        //强制I帧
                        VideoCameraSdk.NET_DVR_MakeKeyFrame(m_lUserID, 1);
                        isRecorded=VideoCameraSdk.NET_DVR_SaveRealData(m_lRealHandle, videoFileName);
                        //开始录像
                        if (!isRecorded)
                        {
                            iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                            errMsg = this.channelName + " NET_DVR_SaveRealData failed, error code= " + iLastErr;
                            Logger.Write(errMsg);
                        }
                        else
                        {
                            m_bRecord = true;
                        }
                        break;
                    case "XM":
                        isRecorded=XMSDK.H264_DVR_StartLocalRecord(m_lRealHandle, videoFileName, (int)XMSDK.MEDIA_FILE_TYPE.MEDIA_FILE_NONE);
                        if (!isRecorded)
                        {
                            int nError = XMSDK.H264_DVR_GetLastError();
                            errMsg = this.channelName + " H264_DVR_StartLocalRecord failed, error code= " + nError;
                            Logger.Write(errMsg); 
                        }
                        else
                        {
                            m_bRecord = true;
                        }
                        break;
                }
            }
            if (isRecorded) 
            {
                FileInfo fileInfo = new FileInfo(videoFileName);
                file = new BFile();
                videoFileType = VideoFileType.Mp4;
                if (fileExten == "avi" || camera == "Hikvision")
                {
                    file.FileExtension = "mp4";
                    string path = filePath + FileHelper.GenerateFileName("mp4");
                    sourceFilePath = Path.Combine(Application.StartupPath, videoFileName);
                    targetFilePath = Path.Combine(Application.StartupPath, path);
                    if (fileExten == "avi")
                    {
                        videoFileType = VideoFileType.Avi;
                    }
                    if (camera == "Hikvision")
                    {
                        videoFileType = VideoFileType.Hk;
                    }
                    file.FileUrl = path;
                }
                else
                {
                    file.FileExtension = fileExten;
                    file.FileUrl = videoFileName;
                }
                file.FileId = YF.MWS.Util.Utility.GetGuid();
                file.TableName = "B_Weight";
                file.RecId = weightId;
                file.BusinessType = FileBusinessType.Video.ToString();

                file.FileSize = fileInfo.Length;
                file.SyncState = 0;
            }
            return file;
        }

        /// <summary>
        /// 停止视频录制
        /// </summary>
        /// <returns></returns>
        public bool StopRecord()
        {
            if (m_bRecord == true)
            {
                switch (this.camera)
                {
                    case "DH":
                        if (!NETPlay.NETStopDataRecord(0)) 
                        {
                            errMsg = this.channelName + " DH_DVR_StopSaveRealData failed.";
                            Logger.Write(errMsg);
                            return false;
                        }
                        else
                        {
                            m_bRecord = false;
                        }
                        break;
                    case "Hikvision":
                        //停止录像
                        if (!VideoCameraSdk.NET_DVR_StopSaveRealData(m_lRealHandle))
                        {
                            iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                            errMsg = this.channelName + " NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                            Logger.Write(errMsg);
                            return false;
                        }
                        else
                        {
                            m_bRecord = false;
                        }
                        break;
                    case "XM":
                        //停止录像
                        if (!XMSDK.H264_DVR_StopLocalRecord(m_lRealHandle))
                        {
                            int nError = XMSDK.H264_DVR_GetLastError();
                            errMsg = this.channelName + " H264_DVR_StopLocalRecord failed, error code= " + nError;
                            Logger.Write(errMsg);
                            return false;
                        }
                        else
                        {
                            m_bRecord = false;
                        }
                        break;
                }
                if (videoFileType == VideoFileType.Avi)
                {
                    Logger.Info(string.Format("AviToMp4-SourcePath:{0}-TargetFilePath:{1}", sourceFilePath, targetFilePath));
                    FFmpegUtil.AVIToMP4(sourceFilePath, targetFilePath);
                }
                if (videoFileType == VideoFileType.Hk)
                {
                    Logger.Info(string.Format("HkToMp4-SourcePath:{0}-TargetFilePath:{1}", sourceFilePath, targetFilePath));
                    FFmpegUtil.HKToMP4(sourceFilePath, targetFilePath);
                }
            }
            return true;
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

            switch (this.camera)
            {
                case "Hikvision":
                    break;
                case "DH":
                case "XM":
                    fileExten = "bmp";
                    break;
            }
            imgFileName = filePath+FileHelper.GenerateFileName(fileExten);
            sourceFileName = filePath + FileHelper.GenerateFileName(fileExten);
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + sourceFileName;
            string waterMarkImageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "logo.png");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            switch (this.camera)
            {
                case "DH":
                    isCaptured = NETClient.NETCapturePicture(m_lRealHandle, AppDomain.CurrentDomain.BaseDirectory + sourceFileName);
                    if (!isCaptured)
                    {
                        errMsg = this.channelName + " DH_DVR Capture Picture failed.";
                        Logger.Write(errMsg);
                    }
                    break;
                case "DHNew":
                    if (dhVideo != null)
                    {
                        isCaptured = dhVideo.Capture(AppDomain.CurrentDomain.BaseDirectory + sourceFileName);
                    }
                    break;
                case "Hikvision":
                    VideoCameraSdk.NET_DVR_JPEGPARA lpJpegPara = new VideoCameraSdk.NET_DVR_JPEGPARA();
                    lpJpegPara.wPicQuality = 0; //图像质量
                    //lpJpegPara.wPicSize = 0xff; //抓图分辨率: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档
                    lpJpegPara.wPicSize = 2;
                    //JPEG抓图
                    isCaptured = VideoCameraSdk.NET_DVR_CapturePicture(m_lRealHandle, fullPath);  //抓拍当前预览的视频比下面那个方法抓拍的图片要清晰完整
                    if(!File.Exists(fullPath))
                       isCaptured = VideoCameraSdk.NET_DVR_CaptureJPEGPicture(m_lUserID, 1, ref lpJpegPara, sourceFileName);
                    if (!isCaptured)
                    {
                        iLastErr = VideoCameraSdk.NET_DVR_GetLastError();
                        errMsg = this.channelName + " NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                        Logger.Write(errMsg);
                        //if (iLastErr == 23)
                        {
                            //不支持上面的抓图方法，则调用下面这个方法实现
                            try
                            {
                                
                                isCaptured = VideoCameraSdk.NET_DVR_CapturePicture(m_lRealHandle, fullPath);
                                //VideoCameraSdk.CAPTURE_MODE.JPEG_MODE
                            }
                            catch (Exception e) 
                            {
                                Logger.WriteException(e);
                            }
                        }
                    }
                    break;
                case "XM":
                    //bmp抓图
                    isCaptured = XMSDK.H264_DVR_LocalCatchPic(m_lRealHandle, sourceFileName);
                    if (!isCaptured)
                    {
                        int nError = XMSDK.H264_DVR_GetLastError();
                        errMsg = this.channelName + " H264_DVR_LocalCatchPic failed, error code= " + nError;
                        Logger.Write(errMsg); 
                    }
                    break;
                case "YS":
                    if (IntPtr.Zero != m_lpRealHanel)
                    {
                        int bRet = NETDEVSDK.NETDEV_CapturePicture(m_lpRealHanel, sourceFileName, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_JPG);
                        if (NETDEVSDK.TRUE != bRet)
                        {
                            errMsg = "Get capture failed.";
                        }
                        Logger.Write(errMsg); 
                    }
                    break;
            }
            if (!File.Exists(fullPath)) //因为抓拍有延迟,所以需要在此暂停1秒
                Thread.Sleep(300);
            bool isGenerateThumbnail = false;
            if (isCaptured || File.Exists(fullPath)) 
            {
                if (captureMode == CaptureMode.Cut)
                {
                    imgFileName = filePath + FileHelper.GenerateFileName("jpg");
                    isGenerateThumbnail = GraphicsUtil.GenerateThumbnail(AppDomain.CurrentDomain.BaseDirectory + sourceFileName,
                                                   AppDomain.CurrentDomain.BaseDirectory + imgFileName,
                                                   cutPhotoWidth, cutPhotoHeight, ThumbnailGenerateMode.FixedWidth);
                }
                fileExten = Path.GetExtension(imgFileName);
                string newImgFileName = filePath + FileHelper.GenerateFileName(fileExten);
                List<WaterMarkText> markTexts = new List<WaterMarkText>();
                markTexts.Add(new WaterMarkText() { MarkText=waterMarkText, WatermarkPosition= WatermarkPositionType.TopLeft });
                List<WaterMarkImage> markImages = new List<WaterMarkImage>();
                markImages.Add(new WaterMarkImage() { MarkImagePath = waterMarkImageFilePath, WatermarkPosition= WatermarkPositionType.BottomRight });
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
                Logger.Write(string.Format("Capture-IsAddMark-{0}-WeightId-{1}-SourceFile-{2}",isAddMark,weightId,sourceFileName));
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
                    if (captureMode == CaptureMode.Cut)
                    {
                        if (isGenerateThumbnail)
                        {
                            file.FileUrl = imgFileName;
                        }
                        else
                        {
                            file.FileUrl = sourceFileName;
                        }
                    }
                    else
                    {
                        file.FileUrl = sourceFileName;
                    }
                }
                if(isAddMark)
                   FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + imgFileName);
                if (isGenerateThumbnail)
                {
                    FileHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + sourceFileName);
                }
            }
            return file;
        }

        /// <summary>
        /// 退出网络摄像头
        /// </summary>
        /// <returns></returns>
        public bool LogoutCamera()
        {
            switch (this.camera)
            {
                case "DH":
                    NETPlay.NETPlayControl(PLAY_COMMAND.Stop, 0);
                    NETPlay.NETPlayControl(PLAY_COMMAND.CloseStream, 0);
                    if (m_lUserID != 0) 
                    {
                        NETClient.NETLogout(m_lUserID);
                        m_lUserID = 0;
                    }
                    break;
                case "DHNew":
                    if (dhVideo != null)
                    {
                        dhVideo.Logout();
                    }
                    break;
                case "Hikvision":
                    //停止预览
                    if (m_lRealHandle >= 0)
                    {
                        VideoCameraSdk.NET_DVR_StopRealPlay(m_lRealHandle);
                        m_lRealHandle = -1;
                    }

                    //注销登录
                    if (m_lUserID >= 0)
                    {
                        VideoCameraSdk.NET_DVR_Logout(m_lUserID);
                        m_lUserID = -1;
                    }
                    break;
                case "XM":
                    //停止预览
                    if (m_hWnd != IntPtr.Zero && m_lRealHandle >= 0)
                    {
                        XMSDK.H264_DVR_StopRealPlay(m_lRealHandle, (uint)m_hWnd);
                        m_hWnd = IntPtr.Zero;
                        m_lRealHandle = -1;
                    }

                    //注销登录
                    if (m_lUserID >= 0)
                    {
                        XMSDK.H264_DVR_Logout(m_lUserID);
                        m_lUserID = -1;
                    }
                    break;
                case "YS":
                    if (IntPtr.Zero == loginDeviceHandle)
                    {
                        return true;
                    }
                    if (IntPtr.Zero != m_lpRealHanel)
                    {
                        NETDEVSDK.NETDEV_StopRealPlay(m_lpRealHanel);
                    }
                    NETDEVSDK.NETDEV_Logout(loginDeviceHandle);
                    break;
            }

            return true;
        }
    }
}
