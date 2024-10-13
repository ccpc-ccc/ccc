using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility;
using System.IO;
using YF.MWS.Db;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmVideoSetting : DevExpress.XtraEditors.XtraForm
    {
        private string configFilePath = Path.Combine(Application.StartupPath, "SysSetting.xml");
        private SysCfg cfg;
        private int cameraNo = 1;
        /// <summary>
        /// 摄像机组编号
        /// </summary>
        public int CameraNo
        {
            get { return cameraNo; }
            set { cameraNo = value; }
        }

        /// <summary>
        /// 摄像机
        /// </summary>
        private string videoCamera;

        public FrmVideoSetting()
        {
            InitializeComponent();
        }

        private void FrmVideoSetting_Load(object sender, EventArgs e)
        {
            this.videoCamera = string.Format("VideoCamera{0}", this.cameraNo);
            cfg = CfgUtil.GetCfg();
            this.Init();
            if (cfg != null) 
            {
                chkStartVideo.Checked = cfg.StartVideo;
                rgCaptureMode.EditValue = cfg.Video.CaptureMode.ToString();
                teCaptureWidth.Text = cfg.Video.Width.ToString();
                teCaptureHeight.Text = cfg.Video.Height.ToString();
                teVideoAppName.Text = cfg.Video.VideoAppName;
            }
            #region 读取车牌识别配置
                string carNoRecognition = cfg.CarNoRecognition.Recognition;
                FormHelper.BindControl<CarNoRecognitionCfg>(gpCarNoRecognition, cfg.CarNoRecognition);
                DxHelper.BindComboBoxEdit(cmbRecognize, SysCode.CarNoRecognition, carNoRecognition);
                chkCarNoRecognition.Checked = cfg.StartCarNoRecognition;
                chkStartSameCarNoControl.Checked = cfg.CarNoRecognition.StartSameCarNoControl;
                teRecognitionTimeSpan.Text = cfg.CarNoRecognition.RecognitionTimeSpan.ToString();
                rgCarNoRecCondition.EditValue = cfg.CarNoRecognition.RecCondition.ToString();
                teIP1.Text = cfg.CarNoRecognition.IP1;
                tePort1.Text = cfg.CarNoRecognition.Port1.ToString();
                teIP2.Text = cfg.CarNoRecognition.IP2;
                tePort2.Text = cfg.CarNoRecognition.Port2.ToString();
                chkOutputVideo.Checked = cfg.CarNoRecognition.OutputVideo;
                chkOutputScreen.Checked = cfg.CarNoRecognition.OutputScreen;
                CarNoCfg carNo = cfg.CarNo;
                teAreaCode.Text = carNo.AreaCode;
                rgOutMode.EditValue = cfg.CarNo.OutMode.ToString();
                teLength.Text = cfg.CarNo.Length.ToString();
                rgCarLimitScopeType.EditValue = cfg.Weight.LimitScope.ToString();
                chkAutoLoadTareWeight.Checked = carNo.AutoLoadTareWeight;
                chkAutoSaveTareWeight.Checked = carNo.AutoSaveTareWeight;
                chkStartCarRecAdjust.Checked = cfg.CarNoRecognition.StartCarRecAdjust;
            #endregion
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            string settingValue;

            //摄像头品牌
            DxHelper.BindComboBoxEdit(cmbVideo, SysCode.VideoCamera, cfg.Video.VideoCamera);

            //视频尺寸
            if (XmlUtil.IsNodeExists(configFilePath, string.Format("{0}/VideoSize", this.videoCamera)))
            {
                this.txtVideoWidth.Text = XmlUtil.GetXmlNodeValue(configFilePath, string.Format("{0}/VideoSize/VideoWidth", this.videoCamera), "275");
                this.txtVideoHeight.Text = XmlUtil.GetXmlNodeValue(configFilePath, string.Format("{0}/VideoSize/VideoHeight", this.videoCamera), "195");
            }
            this.chkVideoOne.Checked = cfg.VideoDevices[0].isUse;
            this.txtIPOne.Text = cfg.VideoDevices[0].ip;
            this.txtPortOne.Text = cfg.VideoDevices[0].port.ToString();
            this.txtUserNameOne.Text = cfg.VideoDevices[0].userName;
            this.txtPasswordOne.Text = cfg.VideoDevices[0].password;
            this.teChannelOne.Text = cfg.VideoDevices[0].ChannelNo.ToString();
            this.chkSuper1.Checked = cfg.VideoDevices[0].IsSuper;
            this.txtText1.Text = cfg.VideoDevices[0].Text;
            this.txtLocation1X.Text = cfg.VideoDevices[0].X.ToString();
            this.txtLocation1Y.Text = cfg.VideoDevices[0].Y.ToString();
            this.chkVideoTwo.Checked = cfg.VideoDevices[1].isUse;
            this.txtIPTwo.Text = cfg.VideoDevices[1].ip;
            this.txtPortTwo.Text = cfg.VideoDevices[1].port.ToString();
            this.txtUserNameTwo.Text = cfg.VideoDevices[1].userName;
            this.txtPasswordTwo.Text = cfg.VideoDevices[1].password;
            this.teChannelTwo.Text = cfg.VideoDevices[1].ChannelNo.ToString();
            this.chkSuper2.Checked = cfg.VideoDevices[1].IsSuper;
            this.txtText2.Text = cfg.VideoDevices[1].Text;
            this.txtLocation2X.Text = cfg.VideoDevices[1].X.ToString();
            this.txtLocation2Y.Text = cfg.VideoDevices[1].Y.ToString();
            this.chkVideoThree.Checked = cfg.VideoDevices[2].isUse;
            this.txtIPThree.Text = cfg.VideoDevices[2].ip;
            this.txtPortThree.Text = cfg.VideoDevices[2].port.ToString();
            this.txtUserNameThree.Text = cfg.VideoDevices[2].userName;
            this.txtPasswordThree.Text = cfg.VideoDevices[2].password;
            this.teChannelThree.Text = cfg.VideoDevices[2].ChannelNo.ToString();
            this.chkSuper3.Checked = cfg.VideoDevices[2].IsSuper;
            this.txtText3.Text = cfg.VideoDevices[2].Text;
            this.txtLocation3X.Text = cfg.VideoDevices[2].X.ToString();
            this.txtLocation3Y.Text = cfg.VideoDevices[2].Y.ToString();
            this.chkVideoFour.Checked = cfg.VideoDevices[3].isUse;
            this.txtIPFour.Text = cfg.VideoDevices[3].ip;
            this.txtPortFour.Text = cfg.VideoDevices[3].port.ToString();
            this.txtUserNameFour.Text = cfg.VideoDevices[3].userName;
            this.txtPasswordFour.Text = cfg.VideoDevices[3].password;
            this.teChannelFour.Text = cfg.VideoDevices[3].ChannelNo.ToString();
            this.chkSuper4.Checked = cfg.VideoDevices[3].IsSuper;
            this.txtText4.Text = cfg.VideoDevices[3].Text;
            this.txtLocation4X.Text = cfg.VideoDevices[3].X.ToString();
            this.txtLocation4Y.Text = cfg.VideoDevices[3].Y.ToString();
        }

        /// <summary>
        /// 验证输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool isValidated = true;

            if (this.chkVideoOne.Checked || this.chkVideoTwo.Checked || this.chkVideoThree.Checked || this.chkVideoFour.Checked)
            {
                if (this.cmbVideo.EditValue == null || string.IsNullOrEmpty(this.cmbVideo.EditValue.ToString()))
                {
                    this.cmbVideo.ErrorText = "请选择摄像机类型";
                    isValidated = false;
                }
            }

            if (string.IsNullOrEmpty(this.txtVideoWidth.Text))
            {
                this.txtVideoWidth.ErrorText = "请输入视频宽度值";
                isValidated = false;
            }
            if (string.IsNullOrEmpty(this.txtVideoHeight.Text))
            {
                this.txtVideoHeight.ErrorText = "请输入视频高度值";
                isValidated = false;
            }

            if (this.chkVideoOne.Checked)
            {
                if (string.IsNullOrEmpty(this.txtIPOne.Text))
                {
                    this.txtIPOne.ErrorText = "请输入摄像机IP地址";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtPortOne.Text))
                {
                    this.txtPortOne.ErrorText = "请输入摄像机端口号";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtUserNameOne.Text))
                {
                    this.txtUserNameOne.ErrorText = "请输入摄像机登录用户名";
                    isValidated = false;
                }
                //if (string.IsNullOrEmpty(this.txtPasswordOne.Text))
                //{
                //    this.txtPasswordOne.ErrorText = "请输入摄像机登录密码";
                //    isValidated = false;
                //}
            }

            if (this.chkVideoTwo.Checked)
            {
                if (string.IsNullOrEmpty(this.txtIPTwo.Text))
                {
                    this.txtIPTwo.ErrorText = "请输入摄像机IP地址";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtPortTwo.Text))
                {
                    this.txtPortTwo.ErrorText = "请输入摄像机端口号";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtUserNameTwo.Text))
                {
                    this.txtUserNameTwo.ErrorText = "请输入摄像机登录用户名";
                    isValidated = false;
                }
                //if (string.IsNullOrEmpty(this.txtPasswordTwo.Text))
                //{
                //    this.txtPasswordTwo.ErrorText = "请输入摄像机登录密码";
                //    isValidated = false;
                //}
            }

            if (this.chkVideoThree.Checked)
            {
                if (string.IsNullOrEmpty(this.txtIPThree.Text))
                {
                    this.txtIPThree.ErrorText = "请输入摄像机IP地址";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtPortThree.Text))
                {
                    this.txtPortThree.ErrorText = "请输入摄像机端口号";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtUserNameThree.Text))
                {
                    this.txtUserNameThree.ErrorText = "请输入摄像机登录用户名";
                    isValidated = false;
                }
                //if (string.IsNullOrEmpty(this.txtPasswordThree.Text))
                //{
                //    this.txtPasswordThree.ErrorText = "请输入摄像机登录密码";
                //    isValidated = false;
                //}
            }

            if (this.chkVideoFour.Checked)
            {
                if (string.IsNullOrEmpty(this.txtIPFour.Text))
                {
                    this.txtIPFour.ErrorText = "请输入摄像机IP地址";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtPortFour.Text))
                {
                    this.txtPortFour.ErrorText = "请输入摄像机端口号";
                    isValidated = false;
                }
                if (string.IsNullOrEmpty(this.txtUserNameFour.Text))
                {
                    this.txtUserNameFour.ErrorText = "请输入摄像机登录用户名";
                    isValidated = false;
                }
                //if (string.IsNullOrEmpty(this.txtPasswordFour.Text))
                //{
                //    this.txtPasswordFour.ErrorText = "请输入摄像机登录密码";
                //    isValidated = false;
                //}
            }

            return isValidated;
        }

        private void Save() {
            if (cfg == null) {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            CarNoRecognitionCfg carNoRec = cfg.CarNoRecognition;
            CarNoCfg carNo = cfg.CarNo;
            FormHelper.ControlToEntity<CarNoRecognitionCfg>(gpCarNoRecognition, ref carNoRec);
            cfg.StartCarNoRecognition = chkCarNoRecognition.Checked;
            cfg.CarNoRecognition.RecCondition = rgCarNoRecCondition.EditValue.ToEnum<CarNoRecCondition>();
            cfg.Weight.LimitScope = rgCarLimitScopeType.EditValue.ToEnum<CarLimitScopeType>();
            cfg.CarNoRecognition.OutputVideo = chkOutputVideo.Checked;
            cfg.CarNoRecognition.OutputScreen = chkOutputScreen.Checked;
            carNoRec.Recognition = DxHelper.GetCode(cmbRecognize);
            carNoRec.IP1 = teIP1.Text.Trim();
            carNoRec.Port1 = tePort1.Text.Trim().ToInt();
            carNoRec.IP2 = teIP2.Text.Trim();
            carNoRec.Port2 = tePort2.Text.Trim().ToInt();
            carNoRec.StartSameCarNoControl = chkStartSameCarNoControl.Checked;
            carNoRec.RecognitionTimeSpan = teRecognitionTimeSpan.Text.ToInt();
            carNo.AreaCode = teAreaCode.Text;
            cfg.CarNo.OutMode = rgOutMode.EditValue.ToEnum<CarNoOutMode>();
            cfg.CarNo.Length = teLength.Text.ToInt();
            cfg.CarNo.AutoLoadTareWeight = chkAutoLoadTareWeight.Checked;
            cfg.CarNo.AutoSaveTareWeight = chkAutoSaveTareWeight.Checked;
            cfg.CarNoRecognition.StartCarRecAdjust = chkStartCarRecAdjust.Checked;
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存车牌识别设置信息");
        }

        private void chkStartVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartVideo.Checked && teVideoAppName.Text.Length == 0)
                teVideoAppName.Text = "磅房视频";
        }

        private void chkVideoOne_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVideoOne.Checked)
                chkStartVideo.Checked = true;
        }

        private void chkVideoTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVideoTwo.Checked)
                chkStartVideo.Checked = true;
        }

        private void chkVideoThree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVideoThree.Checked)
                chkStartVideo.Checked = true;
        }

        private void chkVideoFour_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVideoFour.Checked)
                chkStartVideo.Checked = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Save();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            string camera = "";
            SCode code= this.cmbVideo.EditValue as SCode;
            if (code!=null)
            {
                camera = code.ItemCode;
            }
            if (this.ValidateForm()) {
                if (cfg == null) {
                    cfg = CfgUtil.GetCfg();
                    if (cfg == null)
                        cfg = new SysCfg();
                }
                cfg.StartVideo = chkStartVideo.Checked;
                cfg.Video.CaptureMode = rgCaptureMode.EditValue.ToEnum<CaptureMode>();
                cfg.Video.Width = teCaptureWidth.Text.ToInt();
                cfg.Video.Height = teCaptureHeight.Text.ToInt();
                cfg.Video.VideoAppName = teVideoAppName.Text;
                cfg.Video.VideoCamera = camera;
               cfg.VideoDevices[0].isUse = this.chkVideoOne.Checked;
               cfg.VideoDevices[0].ip = this.txtIPOne.Text;
               cfg.VideoDevices[0].port = this.txtPortOne.Text.ToInt();
               cfg.VideoDevices[0].userName  = this.txtUserNameOne.Text;
                cfg.VideoDevices[0].password = this.txtPasswordOne.Text;
                cfg.VideoDevices[0].ChannelNo= this.teChannelOne.Text.ToInt();
                cfg.VideoDevices[0].VideoCamera = camera;
                cfg.VideoDevices[0].IsSuper = this.chkSuper1.Checked;
                cfg.VideoDevices[0].Text = this.txtText1.Text;
                cfg.VideoDevices[0].X = this.txtLocation1X.Text.ToInt();
                cfg.VideoDevices[0].Y = this.txtLocation1Y.Text.ToInt();
                cfg.VideoDevices[1].isUse = this.chkVideoTwo.Checked;
                cfg.VideoDevices[1].ip = this.txtIPTwo.Text;
                cfg.VideoDevices[1].port= this.txtPortTwo.Text.ToInt();
                cfg.VideoDevices[1].userName = this.txtUserNameTwo.Text;
                cfg.VideoDevices[1].password = this.txtPasswordTwo.Text;
                cfg.VideoDevices[1].ChannelNo= this.teChannelTwo.Text.ToInt();
                cfg.VideoDevices[1].VideoCamera = camera;
                cfg.VideoDevices[1].IsSuper = this.chkSuper2.Checked;
                cfg.VideoDevices[1].Text = this.txtText2.Text;
                cfg.VideoDevices[1].X = this.txtLocation2X.Text.ToInt();
                cfg.VideoDevices[1].Y = this.txtLocation2Y.Text.ToInt();
                cfg.VideoDevices[2].isUse = this.chkVideoThree.Checked;
                cfg.VideoDevices[2].ip = this.txtIPThree.Text;
                cfg.VideoDevices[2].port= this.txtPortThree.Text.ToInt();
                cfg.VideoDevices[2].userName = this.txtUserNameThree.Text;
                cfg.VideoDevices[2].password = this.txtPasswordThree.Text;
                cfg.VideoDevices[2].ChannelNo = this.teChannelThree.Text.ToInt();
                cfg.VideoDevices[2].VideoCamera = camera;
                cfg.VideoDevices[2].IsSuper = this.chkSuper3.Checked;
                cfg.VideoDevices[2].Text = this.txtText3.Text;
                cfg.VideoDevices[2].X = this.txtLocation3X.Text.ToInt();
                cfg.VideoDevices[2].Y = this.txtLocation3Y.Text.ToInt();
                cfg.VideoDevices[3].isUse = this.chkVideoFour.Checked;
                cfg.VideoDevices[3].ip = this.txtIPFour.Text;
                cfg.VideoDevices[3].port = this.txtPortFour.Text.ToInt();
                cfg.VideoDevices[3].userName = this.txtUserNameFour.Text;
                cfg.VideoDevices[3].password = this.txtPasswordFour.Text;
                cfg.VideoDevices[3].ChannelNo = this.teChannelFour.Text.ToInt();
                cfg.VideoDevices[3].VideoCamera = camera;
                cfg.VideoDevices[3].IsSuper = this.chkSuper4.Checked;
                cfg.VideoDevices[3].Text = this.txtText4.Text;
                cfg.VideoDevices[3].X = this.txtLocation4X.Text.ToInt();
                cfg.VideoDevices[3].Y = this.txtLocation4Y.Text.ToInt();

                CfgUtil.SaveCfg(cfg);
                MessageDxUtil.ShowTips("保存视频设置信息成功！");
                Program.frmViewVideoDevice.Close();
                Program.frmViewVideoDevice = null;
                Program.frmViewVideoDevice = new Weight.FrmViewVideoDevice();
                Program.frmViewVideoDevice.Visible = false;
            }
        }
    }
}