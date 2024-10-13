using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.UI;
using YF.MWS.Db;
using YF.MWS.Win.Util.Video;
using YF.Utility.Log;
using System.IO;

namespace YF.MWS.Win.Uc
{
    public partial class VideoControl : UserControl
    {
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private string configFilePath = Path.Combine(Application.StartupPath, "SysSetting.xml");
        private string errMsg;

        private string videoCamera;
        /// <summary>
        /// 摄像头品牌
        /// </summary>
        public string VideoCamera
        {
            get { return videoCamera; }
            private set { videoCamera = value; }
        }
        //摄像头状态
        private CameraState cameraState;
        //显示视频控件
        private List<Control> listCtrl;
        public List<Control> ListCtrl
        {
            get { return listCtrl; }
            set { listCtrl = value; }
        }
        /// <summary>
        /// 1#摄像头
        /// </summary>
        private VideoCameraUtil cameraOne = null;
        /// <summary>
        /// 2#摄像头
        /// </summary>
        private VideoCameraUtil cameraTwo = null;
        /// <summary>
        /// 3#摄像头
        /// </summary>
        private VideoCameraUtil cameraThree = null;
        /// <summary>
        /// 4#摄像头
        /// </summary>
        private VideoCameraUtil cameraFour = null;

        /// <summary>
        /// 视频控件属性
        /// </summary>
        private ControlProperty ctrlVideo = null;

        /// <summary>
        /// 图片控件属性
        /// </summary>
        private ControlProperty ctrlPicture = null;

        private int cameraNo = 1;
        /// <summary>
        /// 摄像头组编号
        /// </summary>
        public int CameraNo
        {
            get { return cameraNo; }
            set { cameraNo = value; }
        }

        /// <summary>
        /// 重连回调函数
        /// </summary>
        private XMSDK.fDisConnect disCallBack;
        /// <summary>
        /// 是否从车牌识别仪加载视频
        /// </summary>
        private bool loadVideoFromCarRec = false;

        public VideoControl()
        {
            InitializeComponent();
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    SysCfg cfg = CfgUtil.GetCfg();
                    if (cfg != null && cfg.CarNoRecognition != null)
                        loadVideoFromCarRec = cfg.CarNoRecognition.OutputVideo;
                    if (cfg != null && cfg.StartVideo)
                    {
                        bool isInit = this.Init();
                        if (isInit && !loadVideoFromCarRec)
                        {
                            this.LoadVideo();
                        }
                    }
                }
                catch (Exception ex) 
                {
                    Logger.WriteException(ex);
                }
            }
        }

        /// <summary>
        ///  Device Disconnection Handling
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            //Device Disconnection Handling          
            //MessageBox.Show("Device User Disconnect", pMsgTitle);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private bool Init()
        {
            if (!loadVideoFromCarRec)
            {
                if (!XmlUtil.IsNodeExists(configFilePath, string.Format("VideoCamera{0}", this.cameraNo)))
                {
                    MessageDxUtil.ShowTips("读取视频设置信息失败！");
                    return false;
                }
                else
                {
                    this.videoCamera = XmlUtil.GetXmlNodeValue(configFilePath, string.Format("VideoCamera{0}/CameraBland", this.cameraNo), "");
                    switch (this.videoCamera)
                    {
                        case "DH":
                            if (VideoCameraUtil.CameraGroupCount == 0)
                            {
                                fDisConnect disConnect = new fDisConnect(DisConnectEvent);
                                m_bInitSDK = NETClient.NETInit(disConnect, IntPtr.Zero);
                                NETClient.NETSetConnectTime(50000, 10);
                                NETClient.NETSetEncoding(LANGUAGE_ENCODING.gb2312);
                                if (m_bInitSDK == false)
                                {
                                    MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                    return false;
                                }
                            }
                            break;
                        case "Hikvision":
                            if (VideoCameraUtil.CameraGroupCount == 0)
                            {
                                m_bInitSDK = VideoCameraSdk.NET_DVR_Init();
                                if (m_bInitSDK == false)
                                {
                                    MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                    return false;
                                }
                                else
                                {
                                    //保存SDK日志
                                    VideoCameraSdk.NET_DVR_SetLogToFile(3, "Log\\", true);
                                }
                            }
                            break;
                        case "XM":
                            if (VideoCameraUtil.CameraGroupCount == 0)
                            {
                                this.disCallBack = new XMSDK.fDisConnect(this.DisConnectCallBack);
                                int result = XMSDK.H264_DVR_Init(this.disCallBack, this.Handle);
                                if (result <= 0)
                                {
                                    MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                    return false;
                                }
                            }
                            break;
                        case "YS":
                            int iRet = NETDEVSDK.NETDEV_Init();
                            Logger.Write("init vedio:YS,result:" + iRet);
                            if (NETDEVSDK.TRUE != iRet)
                            {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                            }
                            break;
                    }
                }
            }
            this.cameraState = this.GetCameraState();
            this.InitControl(this.videoCamera, this.cameraState);
            return true;
        }

        private int GetCameraCount() 
        {
            int count = 0;
            if (cameraState != null) 
            {
                if (cameraState.CameraOneEnable) 
                {
                    count++;
                }
                if (cameraState.CameraTwoEnable)
                {
                    count++;
                }
                if (cameraState.CameraThreeEnable)
                {
                    count++;
                }
                if (cameraState.CameraFourEnable)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 初始化页面控件
        /// </summary>
        /// <param name="videoCamera">摄像头品牌</param>
        /// <param name="camState">摄像头状态</param>
        private void InitControl(string videoCamera, CameraState camState)
        {
            int width = Convert.ToInt32(XmlUtil.GetXmlNodeValue(configFilePath, string.Format("VideoCamera{0}/VideoSize/VideoWidth", this.cameraNo), "275"));
            int height = Convert.ToInt32(XmlUtil.GetXmlNodeValue(configFilePath, string.Format("VideoCamera{0}/VideoSize/VideoHeight", this.cameraNo), "195"));

            this.pnlVideo.SuspendLayout();
            this.listCtrl = new List<Control>();
            if ((camState.CameraOneEnable && camState.CameraTwoEnable && !camState.CameraThreeEnable && !camState.CameraFourEnable) || (!camState.CameraOneEnable && !camState.CameraTwoEnable && camState.CameraThreeEnable && camState.CameraFourEnable))
            {
                if (camState.CameraOneEnable)
                {
                    PictureBox picOne = new PictureBox();
                    picOne.Location = new Point(0, 0);
                    picOne.Size = new Size(width, height);
                    picOne.BackColor = SystemColors.Desktop;
                    picOne.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picOne);

                    PictureBox picTwo = new PictureBox();
                    picTwo.Location = new Point(width + 5, 0);
                    picTwo.Size = new Size(width, height);
                    picTwo.BackColor = SystemColors.Desktop;
                    picTwo.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picTwo);
                }
                else
                {
                    PictureBox picThree = new PictureBox();
                    picThree.Location = new Point(0, 0);
                    picThree.Size = new Size(width, height);
                    picThree.BackColor = SystemColors.Desktop;
                    picThree.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picThree);

                    PictureBox picFour = new PictureBox();
                    picFour.Location = new Point(width + 5, 0);
                    picFour.Size = new Size(width, height);
                    picFour.BackColor = SystemColors.Desktop;
                    picFour.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picFour);
                }
                this.pnlVideo.Width = width * 2 + 5;
                this.pnlVideo.Height = height;
            }
            else if ((camState.CameraOneEnable && !camState.CameraTwoEnable && camState.CameraThreeEnable && !camState.CameraFourEnable) || (!camState.CameraOneEnable && camState.CameraTwoEnable && !camState.CameraThreeEnable && camState.CameraFourEnable))
            {
                if (camState.CameraOneEnable)
                {
                    PictureBox picOne = new PictureBox();
                    picOne.Location = new Point(0, 0);
                    picOne.Size = new Size(width, height);
                    picOne.BackColor = SystemColors.Desktop;
                    picOne.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picOne);

                    PictureBox picThree = new PictureBox();
                    picThree.Location = new Point(0, height + 5);
                    picThree.Size = new Size(width, height);
                    picThree.BackColor = SystemColors.Desktop;
                    picThree.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picThree);
                }
                else
                {
                    PictureBox picTwo = new PictureBox();
                    picTwo.Location = new Point(0, 0);
                    picTwo.Size = new Size(width, height);
                    picTwo.BackColor = SystemColors.Desktop;
                    picTwo.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picTwo);

                    PictureBox picFour = new PictureBox();
                    picFour.Location = new Point(0, height + 5);
                    picFour.Size = new Size(width, height);
                    picFour.BackColor = SystemColors.Desktop;
                    picFour.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picFour);
                }
                this.pnlVideo.Width = width;
                this.pnlVideo.Height = height * 2 + 5;
            }
            else
            {
                if (camState.CameraOneEnable)
                {
                    PictureBox picOne = new PictureBox();
                    picOne.Location = new Point(0, 0);
                    picOne.Size = new Size(width, height);
                    picOne.BackColor = SystemColors.Desktop;
                    picOne.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picOne);
                }

                if (camState.CameraTwoEnable)
                {
                    PictureBox picTwo = new PictureBox();
                    if (this.listCtrl.Count == 0)
                        picTwo.Location = new Point(0, 0);
                    else
                        picTwo.Location = new Point(width + 5, 0);
                    picTwo.Size = new Size(width, height);
                    picTwo.BackColor = SystemColors.Desktop;
                    picTwo.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picTwo);
                }

                if (camState.CameraThreeEnable)
                {
                    PictureBox picThree = new PictureBox();
                    if (this.listCtrl.Count == 0)
                        picThree.Location = new Point(0, 0);
                    else if (this.listCtrl.Count == 1)
                        picThree.Location = new Point(width + 5, 0);
                    else
                        picThree.Location = new Point(0, height + 5);
                    picThree.Size = new Size(width, height);
                    picThree.BackColor = SystemColors.Desktop;
                    picThree.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picThree);
                }

                if (camState.CameraFourEnable)
                {
                    PictureBox picFour = new PictureBox();
                    if (this.listCtrl.Count == 0)
                        picFour.Location = new Point(0, 0);
                    else if (this.listCtrl.Count == 1)
                        picFour.Location = new Point(width + 5, 0);
                    else if (this.listCtrl.Count == 2)
                        picFour.Location = new Point(0, height + 5);
                    else
                        picFour.Location = new Point(width + 5, height + 5);
                    picFour.Size = new Size(width, height);
                    picFour.BackColor = SystemColors.Desktop;
                    picFour.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                    this.listCtrl.Add(picFour);
                }

                if (this.listCtrl.Count == 1)
                {
                    this.pnlVideo.Dock = DockStyle.Fill;
                    PictureBox pic = this.listCtrl[0] as PictureBox;
                    pic.Dock = DockStyle.Fill;
                    pic.MouseDoubleClick -= new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                }
                else if (this.listCtrl.Count == 2)
                {
                    this.pnlVideo.Width = width * 2 + 5;
                    this.pnlVideo.Height = height;
                }
                else
                {
                    this.pnlVideo.Width = width * 2 + 5;
                    this.pnlVideo.Height = height * 2 + 5;
                }
            }
            foreach (Control c in listCtrl)
            {
                PictureBox pic = c as PictureBox;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            this.pnlVideo.Controls.AddRange(this.listCtrl.ToArray());
            this.pnlVideo.ResumeLayout();
        }

        /// <summary>
        /// 视频图片双击事件
        /// </summary>
        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pic = sender as PictureBox;

                if (this.ctrlVideo == null && this.ctrlPicture == null)
                {
                    //保存视频控件原始位置和尺寸信息
                    this.ctrlVideo = new ControlProperty()
                    {
                        Location = this.pnlVideo.Location,
                        Width = this.pnlVideo.Width,
                        Height = this.pnlVideo.Height
                    };

                    //保存图片控件原始位置和尺寸信息
                    this.ctrlPicture = new ControlProperty()
                    {
                        Location = pic.Location,
                        Width = pic.Width,
                        Height = pic.Height
                    };

                    this.pnlVideo.Dock = DockStyle.Fill;
                    pic.Dock = DockStyle.Fill;
                    pic.BringToFront();
                }
                else
                {
                    //恢复视频控件的位置和尺寸
                    this.pnlVideo.Location = this.ctrlVideo.Location;
                    this.pnlVideo.Width = this.ctrlVideo.Width;
                    this.pnlVideo.Height = this.ctrlVideo.Height;
                    this.pnlVideo.Dock = DockStyle.None;

                    //恢复图片控件的位置和尺寸
                    pic.Location = this.ctrlPicture.Location;
                    pic.Width = this.ctrlPicture.Width;
                    pic.Height = this.ctrlPicture.Height;
                    pic.Dock = DockStyle.None;

                    this.ctrlVideo = null;
                    this.ctrlPicture = null;
                }
            }
        }

        /// <summary>
        /// 获取摄像头状态
        /// </summary>
        /// <returns></returns>
        private CameraState GetCameraState()
        {
            string channelName;
            string value;
            CameraState cameraState = new CameraState();
            for (int i = 1; i <= 4; i++)
            {
                channelName = string.Format("VideoCamera{0}/VideoChannel{1}", this.cameraNo, i);
                if (!XmlUtil.IsNodeExists(configFilePath, channelName))
                {
                    switch (i)
                    {
                        case 1:
                            cameraState.CameraOneEnable = false;
                            break;
                        case 2:
                            cameraState.CameraTwoEnable = false;
                            break;
                        case 3:
                            cameraState.CameraThreeEnable = false;
                            break;
                        case 4:
                            cameraState.CameraFourEnable = false;
                            break;
                    }
                }
                else
                {
                    if (XmlUtil.GetXmlAttributeValue(configFilePath, channelName, "Enable", out value, out errMsg))
                    {
                        if (!Convert.ToBoolean(value))
                        {
                            switch (i)
                            {
                                case 1:
                                    cameraState.CameraOneEnable = false;
                                    break;
                                case 2:
                                    cameraState.CameraTwoEnable = false;
                                    break;
                                case 3:
                                    cameraState.CameraThreeEnable = false;
                                    break;
                                case 4:
                                    cameraState.CameraFourEnable = false;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 1:
                                    cameraState.CameraOneEnable = true;
                                    break;
                                case 2:
                                    cameraState.CameraTwoEnable = true;
                                    break;
                                case 3:
                                    cameraState.CameraThreeEnable = true;
                                    break;
                                case 4:
                                    cameraState.CameraFourEnable = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 1:
                                cameraState.CameraOneEnable = false;
                                break;
                            case 2:
                                cameraState.CameraTwoEnable = false;
                                break;
                            case 3:
                                cameraState.CameraThreeEnable = false;
                                break;
                            case 4:
                                cameraState.CameraFourEnable = false;
                                break;
                        }
                    }
                }
            }

            return cameraState;
        }

        /// <summary>
        /// 设置文字水印
        /// </summary>
        /// <param name="showStr">显示的文字</param>
        /// <param name="leftX">左上角X坐标</param>
        /// <param name="leftY">左上角Y坐标</param>
        public void SetWatermark(string showStr, int leftX, int leftY)
        {
            try
            {
                if (this.cameraOne != null)
                    this.cameraOne.SetWordWatermark(showStr, leftX, leftY);

                if (this.cameraTwo != null)
                    this.cameraTwo.SetWordWatermark(showStr, leftX, leftY);

                if (this.cameraThree != null)
                    this.cameraThree.SetWordWatermark(showStr, leftX, leftY);

                if (this.cameraFour != null)
                    this.cameraFour.SetWordWatermark(showStr, leftX, leftY);
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 开始录制视频
        /// </summary>
        /// <param name="weightId">磅单Id号</param>
        public List<BFile> StartRecordVideo(string weightId)
        {
            List<BFile> lstFile = new List<BFile>();
            BFile temp = null;
            if (!this.m_bRecord)
            {
                if (this.cameraOne != null)
                {
                    temp=cameraOne.StartRecord(weightId);
                    if (temp != null) 
                    {
                        lstFile.Add(temp);
                    }
                }
                if (this.cameraTwo != null)
                {
                    temp=cameraTwo.StartRecord(weightId);
                    if (temp != null)
                    {
                        lstFile.Add(temp);
                    }
                }
                if (this.cameraThree != null)
                {
                    temp=cameraThree.StartRecord(weightId);
                    if (temp != null)
                    {
                        lstFile.Add(temp);
                    }
                }
                if (this.cameraFour != null)
                {
                    temp=cameraFour.StartRecord(weightId);
                    if (temp != null)
                    {
                        lstFile.Add(temp);
                    }
                }
                this.m_bRecord = true;
            }
            return lstFile;
        }

        /// <summary>
        /// 停止录制视频
        /// </summary>
        public void StopRecordVideo()
        {
            if (this.m_bRecord)
            {
                if (this.cameraOne != null)
                    this.cameraOne.StopRecord();

                if (this.cameraTwo != null)
                    this.cameraTwo.StopRecord();

                if (this.cameraThree != null)
                    this.cameraThree.StopRecord();

                if (this.cameraFour != null)
                    this.cameraFour.StopRecord();

                this.m_bRecord = false;
            }
        }

        /// <summary>
        /// 截取图片
        /// </summary>
        /// <param name="weightId">磅单Id号</param>
        public List<BFile> CapturePicture(string weightId, string waterMarkText)
        {
            bool hasCaptured = false;
            List<BFile> lstFile = new List<BFile>();
            BFile temp = null;
            if (this.cameraOne != null)
            {
                temp = cameraOne.Capture(weightId, waterMarkText);
                if (temp != null) 
                {
                    lstFile.Add(temp);
                    hasCaptured = true;
                }
            }
            if (this.cameraTwo != null)
            {
                temp = cameraTwo.Capture(weightId, waterMarkText);
                if (temp != null)
                {
                    hasCaptured = true;
                    lstFile.Add(temp);
                }
            }
            if (this.cameraThree != null)
            {
                temp = cameraThree.Capture(weightId, waterMarkText);
                if (temp != null)
                {
                    hasCaptured = true;
                    lstFile.Add(temp);
                }
            }
            if (this.cameraFour != null)
            {
                temp = cameraFour.Capture(weightId, waterMarkText);
                if (temp != null)
                {
                    hasCaptured = true;
                    lstFile.Add(temp);
                }
            }
            return lstFile;
        }

        private void VideoControl_SizeChanged(object sender, EventArgs e)
        {
            this.pnlVideo.Location = new Point((this.Width - this.pnlVideo.Width) / 2, (this.Height - this.pnlVideo.Height) / 2);
        }

        /// <summary>
        /// 重连回调函数
        /// </summary>
        private void DisConnectCallBack(int loginId, string dvrIP, int dvrPort, IntPtr hwdUser)
        {

        }

        /// <summary>
        /// 关闭摄像头，释放摄像头资源
        /// </summary>
        public void Close()
        {
            if (this.cameraOne != null)
                this.cameraOne.LogoutCamera();

            if (this.cameraTwo != null)
                this.cameraTwo.LogoutCamera();

            if (this.cameraThree != null)
                this.cameraThree.LogoutCamera();

            if (this.cameraFour != null)
                this.cameraFour.LogoutCamera();
        }

        /// <summary>
        /// 加载视频
        /// </summary>
        private void LoadVideo()
        {
            IntPtr ptrCtrl1 = IntPtr.Zero;
            IntPtr ptrCtrl2 = IntPtr.Zero;
            IntPtr ptrCtrl3 = IntPtr.Zero;
            IntPtr ptrCtrl4 = IntPtr.Zero;
            int cameraCount = GetCameraCount();
            if (this.listCtrl != null && this.listCtrl.Count > 0)
            {
                ptrCtrl1 = this.listCtrl[0].Handle;
            }
            if (this.listCtrl != null && this.listCtrl.Count > 1)
            {
                ptrCtrl2 = this.listCtrl[1].Handle;
            }
            if (this.listCtrl != null && this.listCtrl.Count > 2)
            {
                ptrCtrl3 = this.listCtrl[2].Handle;
            }
            if (this.listCtrl != null && this.listCtrl.Count > 3)
            {
                ptrCtrl4 = this.listCtrl[3].Handle;
            }

            Action Func = () =>
            {
                bool isLogin = false;

                if ((this.cameraState.CameraOneEnable && this.cameraState.CameraTwoEnable && !this.cameraState.CameraThreeEnable && !this.cameraState.CameraFourEnable) || (!this.cameraState.CameraOneEnable && !this.cameraState.CameraTwoEnable && this.cameraState.CameraThreeEnable && this.cameraState.CameraFourEnable))
                {
                    if (this.cameraState.CameraOneEnable)
                    {
                        //初始化1#摄像头
                        this.cameraOne = new VideoCameraUtil(this.videoCamera, this.cameraNo, 1, cameraCount);
                        isLogin = this.cameraOne.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraOne.PreviewCamera(ptrCtrl1);
                            this.cameraOne.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraOne = null;
                        }

                        //初始化2#摄像头
                        this.cameraTwo = new VideoCameraUtil(this.videoCamera, this.cameraNo, 2, cameraCount);
                        isLogin = this.cameraTwo.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraTwo.PreviewCamera(ptrCtrl2);
                            this.cameraTwo.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraTwo = null;
                        }
                    }
                    else
                    {
                        //初始化3#摄像头
                        this.cameraThree = new VideoCameraUtil(this.videoCamera, this.cameraNo, 3, cameraCount);
                        isLogin = this.cameraThree.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraThree.PreviewCamera(ptrCtrl1);
                            this.cameraThree.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraThree = null;
                        }

                        //初始化4#摄像头
                        this.cameraFour = new VideoCameraUtil(this.videoCamera, this.cameraNo, 4, cameraCount);
                        isLogin = this.cameraFour.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraFour.PreviewCamera(ptrCtrl2);
                            this.cameraFour.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraFour = null;
                        }
                    }
                }
                else if ((this.cameraState.CameraOneEnable && !this.cameraState.CameraTwoEnable && this.cameraState.CameraThreeEnable && !this.cameraState.CameraFourEnable) || (!this.cameraState.CameraOneEnable && this.cameraState.CameraTwoEnable && !this.cameraState.CameraThreeEnable && this.cameraState.CameraFourEnable))
                {
                    if (this.cameraState.CameraOneEnable)
                    {
                        //初始化1#摄像头
                        this.cameraOne = new VideoCameraUtil(this.videoCamera, this.cameraNo, 1, cameraCount);
                        isLogin = this.cameraOne.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraOne.PreviewCamera(ptrCtrl1);
                            this.cameraOne.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraOne = null;
                        }

                        //初始化3#摄像头
                        this.cameraThree = new VideoCameraUtil(this.videoCamera, this.cameraNo, 3, cameraCount);
                        isLogin = this.cameraThree.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraThree.PreviewCamera(ptrCtrl2);
                            this.cameraThree.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraThree = null;
                        }
                    }
                    else
                    {
                        //初始化2#摄像头
                        this.cameraTwo = new VideoCameraUtil(this.videoCamera, this.cameraNo, 2, cameraCount);
                        isLogin = this.cameraTwo.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraTwo.PreviewCamera(ptrCtrl1);
                            this.cameraTwo.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraTwo = null;
                        }

                        //初始化4#摄像头
                        this.cameraFour = new VideoCameraUtil(this.videoCamera, this.cameraNo, 4, cameraCount);
                        isLogin = this.cameraFour.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraFour.PreviewCamera(ptrCtrl2);
                            this.cameraFour.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraFour = null;
                        }
                    }
                }
                else
                {
                    if (this.cameraState.CameraOneEnable)
                    {
                        //初始化1#摄像头
                        this.cameraOne = new VideoCameraUtil(this.videoCamera, this.cameraNo, 1, cameraCount);
                        isLogin = this.cameraOne.LoginCamera();
                        if (isLogin)
                        {
                            this.cameraOne.PreviewCamera(ptrCtrl1);
                            this.cameraOne.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraOne = null;
                        }
                    }

                    if (this.cameraState.CameraTwoEnable)
                    {
                        //初始化2#摄像头
                        this.cameraTwo = new VideoCameraUtil(this.videoCamera, this.cameraNo, 2, cameraCount);
                        isLogin = this.cameraTwo.LoginCamera();
                        if (isLogin)
                        {
                            if (this.listCtrl.Count == 1)
                                this.cameraTwo.PreviewCamera(ptrCtrl1);
                            else
                                this.cameraTwo.PreviewCamera(ptrCtrl2);
                            this.cameraTwo.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraTwo = null;
                        }
                    }

                    if (this.cameraState.CameraThreeEnable)
                    {
                        //初始化3#摄像头
                        this.cameraThree = new VideoCameraUtil(this.videoCamera, this.cameraNo, 3, cameraCount);
                        isLogin = this.cameraThree.LoginCamera();
                        if (isLogin)
                        {
                            if (this.listCtrl.Count == 1)
                                this.cameraThree.PreviewCamera(ptrCtrl1);
                            else if (this.listCtrl.Count == 2)
                                this.cameraThree.PreviewCamera(ptrCtrl2);
                            else
                                this.cameraThree.PreviewCamera(ptrCtrl3);
                            this.cameraThree.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraThree = null;
                        }
                    }

                    if (this.cameraState.CameraFourEnable)
                    {
                        //初始化4#摄像头
                        this.cameraFour = new VideoCameraUtil(this.videoCamera, this.cameraNo, 4, cameraCount);
                        isLogin = this.cameraFour.LoginCamera();
                        if (isLogin)
                        {
                            if (this.listCtrl.Count == 1)
                                this.cameraFour.PreviewCamera(ptrCtrl1);
                            else if (this.listCtrl.Count == 2)
                                this.cameraFour.PreviewCamera(ptrCtrl2);
                            else if (this.listCtrl.Count == 3)
                                this.cameraFour.PreviewCamera(ptrCtrl3);
                            else
                                this.cameraFour.PreviewCamera(ptrCtrl4);
                            this.cameraFour.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                        }
                        else
                        {
                            this.cameraFour = null;
                        }
                    }
                }
            };
            ThreadPool.QueueUserWorkItem(new WaitCallback((object source) =>
            {
                Func();
            }));
        }
    }
}
