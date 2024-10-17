using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util.Video.DHNew;
using YF.MWS.Win.Util.Video;
using YF.MWS.Metadata.UI;
using YF.Utility.Log;
using System.Threading;
using System.Runtime.CompilerServices;
using YF.Utility.Metadata;
using YF.MWS.Win.Util;
using System.Runtime.InteropServices;
using YF.Utility.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmViewVideoDevice : BaseForm {
        private AppContainer appBox = null;
        private List<VideoCameraUtil> videoCameraUtils=new List<VideoCameraUtil>();
        private List<BFile> lstFile = new List<BFile>();
        private List<IntPtr> videoHandles= new List<IntPtr>();
        private IFileService fileService = new FileService();
        private int currentIndex = 0;
        private string VideoCamera = "";
        private bool m_bInitSDK = false;
        private int controlNum = 0;
        /// <summary>
        /// 视频控件属性
        /// </summary>
        private Control currentControl = null;

        public FrmViewVideoDevice()
        {
            InitializeComponent();
            Cfg = CfgUtil.GetCfg();
            Init();
            LoadVideo();
        }

        private void FrmViewVideo_Load(object sender, EventArgs e) {
             CfgUtil.GetFormCfg();
            FormUtil.LoadFormCfg(this,CfgUtil.allFormCfg.videoFrm);
        }

        private void LoadVideo() {
            Action Func = () => {
                videoCameraUtils.Clear();
                for (int i = 0; i < 4; i++) {
                    VideoDeviceCfg deviceCfg = Cfg.VideoDevices[i];
                    if (deviceCfg == null || !deviceCfg.isUse) continue;
                    VideoCameraUtil cameraUtil = new VideoCameraUtil(deviceCfg,i);
                    videoCameraUtils.Add(cameraUtil);
                    bool isLogin = cameraUtil.LoginCamera2();
                    string power = "p2_"+(i+1);
                    if (isLogin) {
                        if(CurrentUser.Instance.IsAdministrator|| CurrentUser.Instance.Powers.Where(li => li == power).ToList().Count > 0) {
                        cameraUtil.PreviewCamera(videoHandles[i]);
                        if(deviceCfg.IsSuper) cameraUtil.SetWordWatermark(deviceCfg.Text, deviceCfg.X, deviceCfg.Y);
                        }
                        //cameraUtil.SetPicStruct(false, 0, 0, true, 0, 320, 520);
                    } else {
                        cameraUtil = null;
                    }
                }
            };
            ThreadPool.QueueUserWorkItem(new WaitCallback((object source) => {
                Func();
            }));
        }
        /// <summary>
        /// 重连回调函数
        /// </summary>
        private void DisConnectCallBack(int loginId, string dvrIP, int dvrPort, IntPtr hwdUser) {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private bool Init() {
            InitPict();
            setPictSize();
            switch (this.VideoCamera) {
                    case "DH":
                        if (VideoCameraUtil.CameraGroupCount == 0) {
                        try {
                        fSnapRevCallBack disConnect = new fSnapRevCallBack(SnapRevCallBack);
                            m_bInitSDK = DHNetSDK.Init(null, IntPtr.Zero, null);
                            DHNetSDK.SetSnapRevCallBack(disConnect, IntPtr.Zero);
                            if (m_bInitSDK == false) {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                return false;
                            }
                        }catch(Exception ex) {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                return false;

                        }
                            if (m_bInitSDK == false) {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                return false;
                            }
                        }
                        break;
                    case "DHNew":
                        if (VideoCameraUtil.CameraGroupCount == 0) {
                            DHVideoUtil dhVideoUtil = new DHVideoUtil();
                            dhVideoUtil.Init();
                        }
                        break;
                    case "Hikvision":
                        if (VideoCameraUtil.CameraGroupCount == 0) {
                            m_bInitSDK = VideoCameraSdk.NET_DVR_Init();
                            if (m_bInitSDK == false) {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                return false;
                            } else {
                                //保存SDK日志
                                VideoCameraSdk.NET_DVR_SetLogToFile(3, "Log\\", true);
                            }
                        }
                        break;
                    case "XM":
                        if (VideoCameraUtil.CameraGroupCount == 0) {
                        XMSDK.fDisConnect disCallBack = new XMSDK.fDisConnect(this.DisConnectCallBack);
                            int result = XMSDK.H264_DVR_Init(disCallBack, this.Handle);
                            if (result <= 0) {
                                MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                                return false;
                            }
                        }
                        break;
                    case "YS":
                        int iRet = NETDEVSDK.NETDEV_Init();
                        Logger.Write("init vedio:YS,result:" + iRet);
                        if (NETDEVSDK.TRUE != iRet) {
                            MessageDxUtil.ShowTips("初始化网络摄像机失败！");
                        }
                        break;
                }
            return true;
        }

        /// <summary>
        /// 关闭摄像头，释放摄像头资源
        /// </summary>
        public void Release() {
            for(int i=0;i<this.videoCameraUtils.Count;i++) {
                
                if (this.videoCameraUtils[i] != null) {
                    this.videoCameraUtils[i].LogoutCamera();
                }
            }
            switch (VideoCamera) {
                case "DH":
                    DHNetSDK.Cleanup();
                    break;
                case "DHNew":
                    DHVideoUtil.Release();
                    break;
                case "Hikvision":
                    VideoCameraSdk.NET_DVR_Cleanup();
                    break;
                case "XM":
                    XMSDK.H264_DVR_Cleanup();
                    break;
                case "YS":
                    NETDEVSDK.NETDEV_Cleanup();
                    break;
            }
        }

        /// <summary>
        /// 视频图片双击事件
        /// </summary>
        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                PictureBox pic = sender as PictureBox;
                if (this.currentControl == null ) {
                    for (int i = 0; i < this.pnlVideo.Controls.Count; i++) {
                        Control c = this.pnlVideo.Controls[i];
                        c.Visible = false;
                    }
                    currentControl = pic;
                    this.WindowState = FormWindowState.Maximized;
                    pic.Location = new Point(0, 0);
                    pic.Size = this.pnlVideo.Size;
                    pic.Visible = true;
                } else {
                    for (int i = 0; i < this.pnlVideo.Controls.Count; i++) {
                        Control c = this.pnlVideo.Controls[i];
                        c.Visible = true;
                    }
                    this.currentControl = null;
                    this.WindowState = FormWindowState.Normal;
                    //setPictSize();
                }
            }
        }

        private void FrmViewVideoDevice_FormClosed(object sender, FormClosedEventArgs e) {
            try {
            Release();
            }catch(Exception ex) {
                Logger.WriteException(ex);
            }
        }
        private void InitPict() {
            this.pnlVideo.Controls.Clear();
            for (int i = 0; i < 4; i++) {
                VideoDeviceCfg deviceCfg = Cfg.VideoDevices[i];
                //if (deviceCfg == null || !deviceCfg.isUse) continue;
                this.VideoCamera = deviceCfg.VideoCamera;
                PictureBox picOne = new PictureBox();
                picOne.BackColor = SystemColors.Desktop;
                picOne.BorderStyle = BorderStyle.FixedSingle;
                picOne.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
                this.pnlVideo.Controls.Add(picOne);
                videoHandles.Add(picOne.Handle);
            }
        }
        private void setPictSize() {
            if (Cfg.Video.HeightNum <= 0) Cfg.Video.HeightNum = 2;
            if (Cfg.Video.WidthNum <= 0) Cfg.Video.WidthNum = 2;
            controlNum = Cfg.Video.HeightNum * Cfg.Video.WidthNum;
            if (currentControl != null) {
                return;
            }
            for (int i = 0; i < 4; i++) {
                Control c = this.pnlVideo.Controls[i];
                c.Height = this.pnlVideo.Height / Cfg.Video.HeightNum;
                c.Width = this.pnlVideo.Width / Cfg.Video.WidthNum;
                int n = i % Cfg.Video.WidthNum;
                c.Location = new Point(n * c.Width, i / Cfg.Video.WidthNum * c.Height);
            }
        }
        private void FrmViewVideoDevice_SizeChanged(object sender, EventArgs e) {
            setPictSize();
        }

        private void 横向排列ToolStripMenuItem_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 1;
            Cfg.Video.WidthNum = 2;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void 纵向排列ToolStripMenuItem_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 1;
            Cfg.Video.WidthNum = 3;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 1;
            Cfg.Video.WidthNum = 1;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 1;
            Cfg.Video.WidthNum = 4;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 2;
            Cfg.Video.WidthNum = 1;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 2;
            Cfg.Video.WidthNum = 2;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 3;
            Cfg.Video.WidthNum = 1;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) {
            Cfg.Video.HeightNum = 4;
            Cfg.Video.WidthNum = 1;
            CfgUtil.SaveCfg(Cfg);
            setPictSize();
        }

        private void FrmViewVideoDevice_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
           this.Hide();
           CfgUtil.allFormCfg.videoFrm= FormUtil.CloseFormCfg(this);
           CfgUtil.SaveFormCfg(CfgUtil.allFormCfg);
        }

        /// <summary>
        /// 设置文字水印
        /// </summary>
        /// <param name="showStr">显示的文字</param>
        /// <param name="leftX">左上角X坐标</param>
        /// <param name="leftY">左上角Y坐标</param>
        public void SetWatermark(string showStr) {
            try {
                foreach(VideoCameraUtil camer in videoCameraUtils) {
                    if (camer != null) camer.ShowString = showStr;
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 开始录制视频
        /// </summary>
        /// <param name="weightId">磅单Id号</param>
        public void StartRecordVideo(string weightId) {
            lstFile.Clear();
            foreach (VideoCameraUtil camer in videoCameraUtils) {
                if (camer != null) camer.StartRecord(weightId);
            }
        }

        /// <summary>
        /// 停止录制视频
        /// </summary>
        public void StopRecordVideo() {
            foreach (VideoCameraUtil camer in videoCameraUtils) {
                if (camer != null) camer.StopRecord();
            }
        }

        /// <summary>
        /// 截取图片
        /// </summary>
        /// <param name="weightId">磅单Id号</param>
        public void CapturePicture(string weightId, string waterMarkText, FileType fileType = FileType.Enter) {
            lstFile.Clear();
            BFile temp = null;
            foreach (VideoCameraUtil camer in videoCameraUtils) {
                if (camer == null) continue;
                temp=camer.Capture(weightId, waterMarkText, fileType);
                if(temp!=null) lstFile.Add(temp);
            }
        }

        private void 抓拍ToolStripMenuItem_Click(object sender, EventArgs e) {
            int i = 0;
            string path = AppDomain.CurrentDomain.BaseDirectory + "File";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            foreach (VideoCameraUtil camer in videoCameraUtils) {
                if (camer == null) continue;
                i++;
                camer.Capture("125423655", "你好好好好好好好好");
            }
        }

        private void FrmViewVideoDevice_VisibleChanged(object sender, EventArgs e) {
            if (!this.Visible) return;
            //controlNum = Cfg.Video.HeightNum * Cfg.Video.WidthNum;
            //Init();
            //LoadVideo();
        }
        /// <summary>
        /// 大华远程抓拍
        /// </summary>
        private void SnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser) {
            string path = AppDomain.CurrentDomain.BaseDirectory + "image";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            if (EncodeType == 10) //.jpg
            {
                DateTime now = DateTime.Now;
                string fileName = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second) + ".jpg";
                string filePath = path + "\\" + fileName;
                byte[] data = new byte[RevLen];
                Marshal.Copy(pBuf, data, 0, (int)RevLen);
                try {
                    //when the file is operate by local capture will throw expection.
                    using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate)) {
                        stream.Write(data, 0, (int)RevLen);
                        stream.Flush();
                        stream.Dispose();
                    }
                } catch {
                    return;
                }
                this.BeginInvoke(new Action(() => {

                }));
            }
        }

        /// <summary>
        /// 截取图片
        /// </summary>
        /// <param name="weightId">磅单Id号</param>
        public List<BFile> CapturePicture(string weightId, string waterMarkText) {
            int i = 0;
            List<BFile> lstFile = new List<BFile>();
            BFile temp = null;
            foreach (VideoCameraUtil camer in videoCameraUtils) {
                if (camer == null) continue;
                i++;
                temp = camer.Capture(weightId, waterMarkText);
                if(temp==null) continue;
                temp.OrderNo = i;
                    lstFile.Add(temp);
            }
            return lstFile;
        }
    }
}