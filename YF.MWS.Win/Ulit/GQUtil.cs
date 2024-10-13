using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using YF.Utility.Log;
using YF.MWS.Metadata.CarPlate;

namespace YF.MWS.Win
{
    /// <summary>
    /// 高清车牌识别仪
    /// 对应软件设置的名称：仓舒车牌识别仪_GQ
    /// </summary>
    public class GQUtil
    {
        public const int GQ_MESSAGE = 0x8000 + 1333; //默认接收消息ID

        //消息类型
        public enum GQ_MSG_TYPE
        {
            GQ_RESULT = 0,				//结果消息
            GQ_IMAGE = 1,				//图像
            GQ_NEW_DEVICE = 2,			//有设备连接上
            GQ_DEL_DEVICE = 3,			//有设备被删除
        }

        //车牌颜色定义
        public enum GQ_PLATE_COLOR
        {
            PLATE_COLOR_UNKNOWN = 0,	//未知
            PLATE_COLOR_BLUE = 1,		//蓝
            PLATE_COLOR_YELLOW = 2,		//黄
            PLATE_COLOR_WHITE = 3,		//白
            PLATE_COLOR_BLACK = 4,		//黑
        }

        //识别结果类型定义
        public enum GQ_TRIGGER_TYPE
        {
            TRIGGER_TYPE_AUTO = 0,		    //自动
            TRIGGER_TYPE_EXTERNAL = 1,		//外部
            TRIGGER_TYPE_SOFTWARE = 2,		//软件
        }

        //车辆行驶方向定义
        public enum GQ_MOVE_DIRECTION
        {
            MOVE_DIRECTION_UNKNOWN = 0,		        //未知方向
            MOVE_DIRECTION_ABOVETOBELOW = 1,		//摄像机抓拍区域的上方驶向下方
            MOVE_DIRECTION_BELOWTOABOVE = 2,		//摄像机抓拍区域的下方驶向上方
        }

        //继电器状态
        public enum GQ_WATCH_STATE
        {
            WATCH_CLOSE = 0,	//断开
            WATCH_OPEN = 1,		//闭合
        }

        //时间结构定义
        public struct GQ_TIME
        {
            public int tm_year;				//年
            public int tm_mon;				//月
            public int tm_mday;				//日
            public int tm_hour;				//时
            public int tm_min;				//分
            public int tm_sec;				//秒
            public int tm_millisecond;		//毫秒
        }

        //车牌区域定义
        public struct GQ_RECT
        {
            public int left;     //左边位置
            public int top;      //上边位置
            public int right;    //右边位置
            public int bottom;   //下边位置
        }

        //设备信息结构
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct GQ_DEVICE_INFO
        {
            public uint nID;						//设备标识，程序单次运行期间唯一
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIP;							//设备IP地址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string sNo;							//设备编号,用户可设定值
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sAddress;					//设备地点
            public uint nLimitUpSpeed;				//限定高速值
            public uint nDeviceType;				// 0,进口 1,出口
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
            byte[] Resverd;				//预留数据区,用于未来可能的扩展，无意义
        }

        //发送识别结果消息格式
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct GQ_RESULT_INFO
        {
            public uint DeviceID;		//设备标识，程序单次运行期间唯一
            //文本信息
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sPlateChar;				//车牌号码
            public GQ_PLATE_COLOR nPlateColor;			//车牌颜色
            public GQ_RECT PlateLocation;				//车牌在最终结果图片中的位置(图片可能经过缩放)
            public int nBright;					//亮度评价
            public GQ_TIME GrabTime;					//获得结果的设备时间
            public int nSpeed;						//车辆速度
            public GQ_TRIGGER_TYPE nTriggerType;		//抓拍方式
            public GQ_MOVE_DIRECTION nMoveDirection;	    //行驶方向
            public int nTriggerChannel;				//触发通道
            public int nRegionIndex;				//识别区域编号
            public int nPlateWidth;					//车牌原始大小(从摄像机采集的初始图像)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
            byte[] Resverd;			//预留数据区,用于未来可能的扩展，无意义

            //图片信息
            public uint nPlateImgLen;				//车牌图片长度
            public IntPtr pPlateImg;				//车牌图片数据
            public uint nImageLen;				//第一副图片数据长度
            public IntPtr pImage;				//第一副图片数据
            //第二副图和合成图只在两幅图模式下才会存在，目前只做保留
            public uint nImage2Len;				//第二副图片数据长度
            public IntPtr pImage2;					//第二副图片数据
            public uint nMergedImageLen;		//合成图长度
            public IntPtr pMergedImageData;			//合成图数据
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            byte[] Resverd2;			//预留数据区,用于未来可能的扩展，无意义
        }

        public struct GQ_IMAGE_INFO //图片信息
        {
            public uint DeviceID;			//设备标识
            public GQ_TRIGGER_TYPE ImageType;		//抓拍方式
            public IntPtr pImageData;		//图片数据首地址指针
            public int Imagelen;					//图片长度
            public int Width;						//宽
            public int Height;						//高
            public int Bits;						//bit位数
            public int nSpeed;					//速度
            public GQ_TIME GrabTime;				//设备抓拍图片的时间
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            byte[] Reserved;	//保留字段
        }

        //--------------导入接口函数-----------------------------/
        //回调函数类型定义,通过GQ_SetRecvCB指定回调函数,用户在回调函数中接收结果和实时图像.
        //	WPARAM wParam 用于传输数据类型 值为GQ_MSG_TYPE

        //	LPARAM lParam 用于传输具体数据，作用根据wParam的值而定
        //	wParam == GQ_RESULT 时 lParam为GQ::GQ_RESULT_INFO*	类型指针，GQ::GQ_RESULT_INFO* pRes = (GQ_RESULT_INFO*)lParam;	代表识别结果。
        //	wParam == GQ_IMAGE 时  lParam为GQ::GQ_IMAGE_INFO*	类型指针，GQ::GQ_IMAGE_INFO* pRes = (GQ_IMAGE_INFO*)lParam;		代表实时图像
        //	wParam == GQ_NEW_DEVICE或GQ_DEL_DEVICE时,lParam为设备ID	代表打开或者关闭的设备ID

        //uint UserData 返回用户数据，值为GQ_SetRecvCB中指定的用户数据。

        //回调函数具体用法请参考示例。

        public delegate void GQ_CALLBACKFUN(IntPtr wParam, IntPtr lParam, uint UserData);

        /// <summary>
        /// 获取识别结果事件
        /// </summary>
        private GQ_CALLBACKFUN GQRecvCallback;

        /// <summary>
        /// 定义获取识别结果的委托
        /// </summary>
        public delegate void GQRecv_Invoke(IntPtr WParam, IntPtr LParam, uint UserData);

        /// <summary>
        /// 获取识别结果回调
        /// </summary>
        private GQRecv_Invoke m_GQRecvInvoke;

        /// <summary>
        /// 定义识别车牌的委托
        /// </summary>
        public delegate void RecognizePlateDelegate(PlateInfo ResInfo);

        /// <summary>
        /// 识别车牌事件
        /// </summary>
        public RecognizePlateDelegate RecognizePlate = null;

        /*
		GQ_Init
		功能
		初始化接口
		参数:
		IntPtr hWnd					响应DLL消息的窗口句柄
		int uMsg					指定获得识别结果的自定义消息ID
		返回值
			成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_Init(IntPtr hWnd, int uMsg);

        /*
        GQ_SetRecvCB
        功能:
        指定回调函数,用户在回调函数中接收结果和实时图像.
        参数:
        GQ_CALLBACKFUN RecvFun		回调函数指针
        uint UserData				用户自定义数据，将在回调函数中返回
        返回值:
        成功返回S_OK(0),失败返回S_FALSE(1)
        说明:
        通过GQ_SetRecvCB指定回调方式接收数据后，GQ_Init指定的hWnd和uMsg参数 将会被忽略。程序也将不能够通过消息方式接收到数据。
        例如如果想从回调函数接收数据，则如下调用方式
        GQ_Init(0,0);
        GQ_SetRecvCB(RecvFun);
        */
        [DllImport("GQ.dll")]
        public static extern int GQ_SetRecvCB(GQ_CALLBACKFUN RecvFun, uint UserData);

        /*
		GQ_Release
		功能:
		释放接口库资源
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_Release();

        /*
		GQ_GetDeviceInfo
		功能:
		获得指定ID的设备信息
		参数:
		uint DeviceID					设备ID
		ref GQ_DEVICE_INFO DeviceInfo				设备信息结构，函数执行完后，如果返回S_OK，DeviceInfo将包含设备的所有信息
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_GetDeviceInfo(uint DeviceID, ref GQ_DEVICE_INFO DeviceInfo);

        /*
		GQ_QueryAllDevices
		功能:
		查询已连接的所有设备ID列表
		参数:
		uint[] pDevices 	指向设备列表的数据缓冲区，函数执行前必须已分配好空间
		ref int nDevicesCount		函数执行完后，如果返回S_OK，将返回当前的设备总数
		int nBufferCount					pDevices指向的数据缓冲区大小
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_QueryAllDevices(uint[] pDevices, ref int nDevicesCount, int nBufferCount);

        /*
		GQ_SoftTriggerDevice
		功能:
		软件触发指定ID的设备,执行成功后，将触发设备进行一次抓拍
		参数:
		uint DeviceID					设备ID 
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_SoftTriggerDevice(uint DeviceID);

        /*
		GQ_DeviceSetting
		功能:
		打开设备参数面板
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_DeviceSetting();

        /*
        GQ_SetWatch
        功能:
        设置指定设备编号和继电器编号的继电器状态
        参数:
        uint DeviceID		设备ID
        int nWatchID				继电器编号，目前只能为1或者2，代表1号或者2号继电器 
        GQ_WATCH_STATE nWatchState 指定继电器状态
        返回值:
        成功返回S_OK(0),失败返回S_FALSE(1)
        */
        [DllImport("GQ.dll")]
        public static extern int GQ_SetWatch(uint DeviceID, int nWatchID, GQ_WATCH_STATE nWatchState);

        /*
		GQ_GetWatch
		功能:
		获得指定设备编号和继电器编号的继电器状态
		参数:
		uint DeviceID		                设备ID
		int nWatchID				        继电器编号，目前只能为1或者2，代表1号或者2号继电器 
		ref GQ_WATCH_STATE nWatchState      返回参数,如果函数返回S_OK，nWatchState为指定的继电器状态
		返回值:
		成功返回S_OK(0),失败返回S_FALSE(1)
		*/
        [DllImport("GQ.dll")]
        public static extern int GQ_GetWatch(uint DeviceID, int nWatchID, ref GQ_WATCH_STATE nWatchState);

        /*
           GQ_Recognize
           功能:
           识别指定JPG图片
           参数:
            * IntPtr pJpgBuffer    指向JPG图像首地址
            * int nJpgLen          JPG图像长度
            * int nLeftSpan        左边距
            * int nRightSpan       右边距
            * int nTopSpan         上边距
            * int nBotSpan         下边距
            * ref GQ_RESULT_INFO GQ_Res  返回识别结果
           返回值:
           成功返回S_OK(0),失败返回S_FALSE(1)
           */
        [DllImport("GQ.dll")]
        public static extern int GQ_Recognize(IntPtr pJpgBuffer, int nJpgLen, int nLeftSpan, int nRightSpan, int nTopSpan, int nBotSpan,
                                       ref GQ_RESULT_INFO GQ_Res);

        /*
        GQ_SendChargeInfoToLed
        功能:
        发送收费信息到LED屏显示
        参数:
        uint DeviceID		设备ID
        string pPlate				车牌号码
        double dMoney				收费金额，单位元
        GQ_TIME gParkTime			停车时长
        GQ_TIME CardValidTime		卡有效期
        string pOther				其他未考虑到的信息以字符串发送
        返回值:
        成功返回S_OK(0),失败返回S_FALSE(1)
        */
        [DllImport("GQ.dll")]
        public static extern int GQ_SendChargeInfoToLed(uint DeviceID,
                                                 string pPlate,
                                                 double dMoney,
                                                 GQ_TIME gParkTime, GQ_TIME gCardValidTime, string pOther);

        /*
        GQ_SendToNetCom
        功能:
        向指定ID设备网络串口发送数据
        参数:
        uint DeviceID		        设备ID
        IntPtr pData				数据缓冲区地址
        int nLen					数据长度
        返回值:
        成功返回S_OK(0),失败返回S_FALSE(1)
        说明:目前一次发送的长度有限制，不能超过20字节，也即nLen<=20,否则将可能导致发送数据丢失
        */
        [DllImport("GQ.dll")]
        public static extern int GQ_SendToNetCom(uint DeviceID, IntPtr pData, int nLen);

        /*
        GQ_RosePole
        功能:
            抬杆命令
        参数:
        uint DeviceID		        设备ID
        返回值:
            成功返回S_OK(0),失败返回S_FALSE(1)
        */
        [DllImport("GQ.dll")]
        public static extern int GQ_RosePole(uint DeviceID);

        private bool isRecoRan = false;
        /// <summary>
        /// 车牌识别仪是否正在运行
        /// </summary>
        public bool IsRecoRan
        {
            get { return isRecoRan; }
            set { isRecoRan = value; }
        }

        /// <summary>
        /// 初始化车牌识别一体机
        /// </summary>
        /// <returns></returns>
        public GQUtil()
        {
            try
            {
                //回调方式接收结果初始化
                this.GQRecvCallback = new GQ_CALLBACKFUN(this.GQRecvCB);
                this.m_GQRecvInvoke = new GQRecv_Invoke(this.GQRecv);
                int nRet = GQ_Init(new IntPtr(0), 0);
                nRet = GQ_SetRecvCB(this.GQRecvCallback, 0);
                if (nRet == 0)
                {
                    this.isRecoRan = true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 车牌识别一体机结果处理事件
        /// </summary>
        /// <param name="WParam"></param>
        /// <param name="LParam"></param>
        /// <param name="UserData"></param>
        private void GQRecv(IntPtr WParam, IntPtr LParam, uint UserData)
        {
            switch ((GQ_MSG_TYPE)WParam)
            {
                case GQ_MSG_TYPE.GQ_RESULT:
                    this.ProcessRes(LParam);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 车牌识别一体机异步结果处理
        /// </summary>
        /// <param name="WParam"></param>
        /// <param name="LParam"></param>
        /// <param name="UserData"></param>
        private void GQRecvCB(IntPtr WParam, IntPtr LParam, uint UserData)
        {
            IAsyncResult asyncResult = this.m_GQRecvInvoke.BeginInvoke(WParam, LParam, UserData, null, null);

            GQ_MSG_TYPE msg = (GQ_MSG_TYPE)WParam;
            if (GQ_MSG_TYPE.GQ_RESULT == msg || GQ_MSG_TYPE.GQ_IMAGE == msg)
            {
                while (!asyncResult.AsyncWaitHandle.WaitOne(100, false))
                {
                    if (!this.isRecoRan)
                    {
                        //如果程序退出，不再等待。
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 车牌识别一体机返回数据处理
        /// </summary>
        /// <param name="LParam">返回的数据</param>
        public void ProcessRes(IntPtr LParam)
        {
            GQ_RESULT_INFO ResInfo = (GQ_RESULT_INFO)Marshal.PtrToStructure(LParam, typeof(GQ_RESULT_INFO));
            PlateInfo plateInfo = new PlateInfo();
            plateInfo.Num = ResInfo.sPlateChar;
            plateInfo.DeviceID = ResInfo.DeviceID;
            if(this.RecognizePlate!=null)
            {
                this.RecognizePlate.BeginInvoke(plateInfo, null, null);
            }
        }
    }
}
