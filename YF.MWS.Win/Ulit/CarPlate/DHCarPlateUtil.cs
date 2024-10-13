using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Metadata.CarPlate;
using YF.MWS.Metadata.Event;
using YF.MWS.Win.Util.Video;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.CarPlate
{
    /// <summary>
    /// 大华车牌识别工具类
    /// </summary>
    public class DHCarPlateUtil
    {
        private fDisConnect disConnect;       //设备离线消息
        private fHaveReConnect onlineMsg;     //设备重新在线消息
        private fAnalyzerDataCallBack anaCallback; //设备过车事件及抓拍等消息 

        private NET_DEVICEINFO deviceInfo;
        private int[] m_nRealLoadPics;//订阅句柄数组
        private int m_nLoginID;     // 登陆返回的句柄
        private string mIP;
        private int mPort = 0;
        private string mUserName;
        private string mPassword;
        private int m_realPlayH;
        private int no;

        public int No
        {
            get { return no; }
            set { no = value; }
        }
        private bool hasLogined = false;

        public bool HasLogined
        {
            get { return hasLogined; }
            set { hasLogined = value; }
        }
        private PictureBox picVideo;

        public PictureBox PicVideo
        {
            get { return picVideo; }
            set { picVideo = value; }
        }
        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo plateInfo);

        public event DeviceReconnectedEventHandler DeviceReconnected;

        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;

        public DHCarPlateUtil(string ip, int port, string userName, string password) 
        {
            mIP = ip;
            mPort = port;
            mUserName = userName;
            mPassword = password;
            m_nLoginID = 0;
            disConnect = new fDisConnect(DisConnectEvent);
            bool blnInit = DHClient.DHInit(disConnect, IntPtr.Zero);
            onlineMsg = new fHaveReConnect(OnlineEvent);
            DHClient.DHSetAutoReconnect(onlineMsg, IntPtr.Zero);
            anaCallback = new fAnalyzerDataCallBack(AnalyzerDataCallBackEvent);

            Login();
        }

        public void Login() 
        {
            //设备用户信息获得
            deviceInfo = new NET_DEVICEINFO();
            int error = 0;
            m_nLoginID = DHClient.DHLogin(mIP, Convert.ToUInt16(mPort), mUserName, mPassword, out deviceInfo, out error);

            if (m_nLoginID != 0)
            {
                hasLogined = true;
                m_nRealLoadPics = new int[deviceInfo.byChanNum];
                for (int i = 0; i < m_nRealLoadPics.Length; i++)
                {
                    m_nRealLoadPics[i] = DHClient.DHRealLoadPicture(m_nLoginID, i, EventIvs.EVENT_IVS_ALL, anaCallback, 0);
                    if (m_nRealLoadPics[i] == 0)
                    {
                        DHClient.DHLogout(m_nLoginID);
                        return;
                    }
                }
            }
            else
            {
                Logger.Write("login dahua failed.");
            }
        }

        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            //设备离线消息；设备非正常关机，SDK可以检测到；需要取消订阅,当重新在线消息时，再发起订阅事件
            for (int i = 0; i < m_nRealLoadPics.Length; i++)
            {
                bool bret = DHClient.DHStopLoadPic(m_nRealLoadPics[i]);
            }
            hasLogined = false;
        }

        // 开始智能交通设备实时上传--回调
        private int AnalyzerDataCallBackEvent(Int32 lAnalyzerHandle, UInt32 dwAlarmType, IntPtr pAlarmInfo, IntPtr pBuffer, UInt32 dwBufSize, UInt32 dwUser, Int32 nSequence, IntPtr reserved)
        {
            try
            {
                if (dwBufSize == 0)
                {
                    return 1;
                }

                DH_MSG_OBJECT plateObj = new DH_MSG_OBJECT();
                DH_MSG_OBJECT VehicleObj = new DH_MSG_OBJECT();
                NET_TIME_EX utc = new NET_TIME_EX();
                int lane = 0;
                string strMsg;
                int nconfide = 0;//置信度


                bool bret = GetStuObject(dwAlarmType, pAlarmInfo, out plateObj, out VehicleObj, out utc, out lane, out strMsg, out nconfide);
                if (plateObj.szText.Length > 0)
                {
                    //显示车牌、车牌颜色、车身颜色、时间、车道号
                    string platenumber = Encoding.GetEncoding("gb2312").GetString(plateObj.szText);
                    PlateInfo plateInfo = new PlateInfo();
                    plateInfo.IP = mIP;
                    plateInfo.Num = platenumber.Trim().Replace(" ", "");
                    if (this.RecognizePlate != null)
                    {
                        RecognizePlate(plateInfo);
                        //this.RecognizePlate.BeginInvoke(plateInfo, null, null);
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.Write("DH-recoginize-error");
                Logger.WriteException(ex);
            }
            return 1;
        }

        public void OpenRealPlay() 
        {
            m_realPlayH = DHClient.DHRealPlay(m_nLoginID, 0, picVideo.Handle);
        }

        public void Realese() 
        {
            //停止消息订阅句柄
            if (m_nRealLoadPics != null)
            {
                for (int i = 0; i < m_nRealLoadPics.Length; i++)
                {
                    if (m_nRealLoadPics[i] != 0)
                    {
                        bool bret = DHClient.DHStopLoadPic(m_nRealLoadPics[i]);
                    }
                }
            }
            //停止监视
            if (m_realPlayH != 0)
            {
                DHClient.DHStopRealPlay(m_realPlayH);
                m_realPlayH = 0;
            }
            if (m_nLoginID != 0)
            {
                DHClient.DHLogout(m_nLoginID);
                m_nLoginID = 0;
            }
        }

        /// <summary>
        /// 获取识别对象 车身对象 事件发生时间 车道号等信息
        /// </summary>
        /// <param name="dwAlarmType"></param>
        /// <param name="pAlarmInfo"></param>
        /// <returns></returns>
        private bool GetStuObject(UInt32 dwAlarmType, IntPtr pAlarmInfo, out DH_MSG_OBJECT stuObj, out DH_MSG_OBJECT vehicleObj, out NET_TIME_EX outUTC, out int outlane, out string strMsg, out int nConfidence)
        {
            DH_MSG_OBJECT msg = new DH_MSG_OBJECT();
            DH_MSG_OBJECT veahcile = new DH_MSG_OBJECT();
            NET_TIME_EX utc = new NET_TIME_EX();
            int lane = 0;

            int nConfiden = 0; // 置信度只有特定设备才支持，一般设备默认都是0不填充

            DH_EVENT_FILE_INFO fileinfo = new DH_EVENT_FILE_INFO();

            string EventMsg = "未定义事件";


            if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFICGATE)
            {
                DEV_EVENT_TRAFFICGATE_INFO Info = new DEV_EVENT_TRAFFICGATE_INFO();
                Info = (DEV_EVENT_TRAFFICGATE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFICGATE_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;

                nConfiden = Info.stuObject.nConfidence;

                fileinfo = Info.stuFileInfo;
                EventMsg = "交通卡口事件 UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFICJUNCTION)
            {
                DEV_EVENT_TRAFFICJUNCTION_INFO Info = new DEV_EVENT_TRAFFICJUNCTION_INFO();
                Info = (DEV_EVENT_TRAFFICJUNCTION_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFICJUNCTION_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                nConfiden = Info.stuObject.nConfidence;

                EventMsg = "交通路口事件UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_RUNREDLIGHT)
            {
                DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO Info = new DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO();
                Info = (DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-闯红灯事件UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_TURNLEFT)
            {
                DEV_EVENT_TRAFFIC_TURNLEFT_INFO Info = new DEV_EVENT_TRAFFIC_TURNLEFT_INFO();
                Info = (DEV_EVENT_TRAFFIC_TURNLEFT_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_TURNLEFT_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-违章左转UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_TURNRIGHT)
            {
                DEV_EVENT_TRAFFIC_TURNRIGHT_INFO Info = new DEV_EVENT_TRAFFIC_TURNRIGHT_INFO();
                Info = (DEV_EVENT_TRAFFIC_TURNRIGHT_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_TURNRIGHT_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-违章右转UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_OVERSPEED)
            {
                DEV_EVENT_TRAFFIC_OVERSPEED_INFO Info = new DEV_EVENT_TRAFFIC_OVERSPEED_INFO();
                Info = (DEV_EVENT_TRAFFIC_OVERSPEED_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_OVERSPEED_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-超速UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_UNDERSPEED)
            {
                DEV_EVENT_TRAFFIC_UNDERSPEED_INFO Info = new DEV_EVENT_TRAFFIC_UNDERSPEED_INFO();
                Info = (DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_UNDERSPEED_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-低速UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_MANUALSNAP)
            {
                DEV_EVENT_TRAFFIC_MANUALSNAP_INFO Info = new DEV_EVENT_TRAFFIC_MANUALSNAP_INFO();
                Info = (DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_MANUALSNAP_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                nConfiden = Info.stuObject.nConfidence;

                EventMsg = "交通手动抓拍事件UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_PARKING)
            {
                DEV_EVENT_TRAFFIC_PARKING_INFO Info = new DEV_EVENT_TRAFFIC_PARKING_INFO();
                Info = (DEV_EVENT_TRAFFIC_PARKING_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_PARKING_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章停车UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_PARKINGSPACENOPARKING)
            {
                DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO Info = new DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO();
                Info = (DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "车位无车事件UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_PARKINGSPACEPARKING)
            {
                DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO Info = new DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO();
                Info = (DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO));
                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "车位有车事件UTC=" + UTCToString(Info.UTC);
            }

            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_WRONGROUTE)
            {
                DEV_EVENT_TRAFFIC_WRONGROUTE_INFO Info = new DEV_EVENT_TRAFFIC_WRONGROUTE_INFO();
                Info = (DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_WRONGROUTE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "不按车道行驶UTC=" + UTCToString(Info.UTC);

            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_RETROGRADE)
            {
                DEV_EVENT_TRAFFIC_RETROGRADE_INFO Info = new DEV_EVENT_TRAFFIC_RETROGRADE_INFO();
                Info = (DEV_EVENT_TRAFFIC_RETROGRADE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_RETROGRADE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "逆行UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_OVERYELLOWLINE)
            {
                DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO Info = new DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO();
                Info = (DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "压黄线UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_OVERLINE)
            {
                DEV_EVENT_TRAFFIC_OVERLINE_INFO Info = new DEV_EVENT_TRAFFIC_OVERLINE_INFO();
                Info = (DEV_EVENT_TRAFFIC_OVERLINE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_OVERLINE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "压车道线（压白线）UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_CROSSLANE)
            {
                DEV_EVENT_TRAFFIC_CROSSLANE_INFO Info = new DEV_EVENT_TRAFFIC_CROSSLANE_INFO();
                Info = (DEV_EVENT_TRAFFIC_CROSSLANE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_CROSSLANE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "违章变道UTC=" + UTCToString(Info.UTC);
            }
            else if (dwAlarmType == EventIvs.EVENT_IVS_TRAFFIC_YELLOWPLATEINLANE)
            {
                DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO Info = new DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO();
                Info = (DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO));

                stuObj = Info.stuObject;
                vehicleObj = Info.stuVehicle;
                outUTC = Info.UTC;
                outlane = Info.nLane;
                fileinfo = Info.stuFileInfo;

                EventMsg = "交通违章-黄牌车占道事件UTC=" + UTCToString(Info.UTC);
            }
            else
            {
                stuObj = msg;
                vehicleObj = veahcile;
                outUTC = utc;
                outlane = 0;

                EventMsg = "未处理事件dwAlarmType = " + dwAlarmType.ToString();
            }

            nConfidence = nConfiden;

            if (!EventMsg.Contains("未处理事件"))
            {
                EventMsg = EventMsg + ";组编号GroupID = " + fileinfo.nGroupId + ";图片组总数bount = " + fileinfo.bCount + ";当前图片序号bIndex=" + fileinfo.bIndex +
                    ";置信度 =  " + nConfiden;
                try
                {
                    //车牌
                    string platenumber = Encoding.GetEncoding("gb2312").GetString(stuObj.szText);
                    string[] plate = platenumber.Split('\0');
                    if (plate.Length > 0)
                    {
                        EventMsg += ";车牌号 = " + plate[0];
                    }

                    //车标
                    string strType = Encoding.GetEncoding("gb2312").GetString(vehicleObj.szText);
                    string[] vechitypes = strType.Split('\0');
                    if (vechitypes.Length > 0)
                    {
                         

                        if (!vechitypes[0].Equals(""))
                        {
                            EventMsg += ";车标 = " + vechitypes[0];
                        }
                    }
                }
                catch(Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
            strMsg = EventMsg;
            return true;

        }

        private void OnlineEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            try
            {
                if (m_nRealLoadPics != null && m_nRealLoadPics.Length > 0)
                {
                    //自动重连成功事件后，再发起订阅设备事件消息
                    for (int i = 0; i < m_nRealLoadPics.Length; i++)
                    {
                        m_nRealLoadPics[i] = DHClient.DHRealLoadPicture(m_nLoginID, i, EventIvs.EVENT_IVS_ALL, anaCallback, 0);
                    }
                }
                if (DeviceReconnected != null)
                {
                    DeviceReconnected(this, new DeviceReconnectedEventArgs(no));
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        //UTC时间字串；
        private string UTCToString(NET_TIME_EX ex)
        {
            return ex.dwYear.ToString() + "-" + ex.dwMonth.ToString() + "-" + ex.dwDay.ToString() + " " + ex.dwHour.ToString() + ":" +
                                                                                                          ex.dwMinute.ToString() + ":" +
                                                                                                          ex.dwSecond.ToString() + "::" + ex.dwMillisecond.ToString();
        }
    }
}
