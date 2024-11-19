namespace YF.MWS.Win.View.Setting
{
    partial class FrmTransferCfg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransferCfg));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.plMain = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoSend = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.gpRuiJieYun = new DevExpress.XtraEditors.GroupControl();
            this.lblRemoteAppSecret = new DevExpress.XtraEditors.LabelControl();
            this.txtRegisterCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAppKey = new DevExpress.XtraEditors.LabelControl();
            this.txtMachineCode = new DevExpress.XtraEditors.TextEdit();
            this.lblRemoteServerUrl = new DevExpress.XtraEditors.LabelControl();
            this.txtCompanyCode = new DevExpress.XtraEditors.TextEdit();
            this.txtServerUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRuiJieYun)).BeginInit();
            this.gpRuiJieYun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerUrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemSave,
            this.btnItemClose});
            this.barManager.MaxItemId = 11;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(437, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 249);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(437, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 225);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(437, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 225);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.simpleButton2);
            this.plMain.Controls.Add(this.simpleButton1);
            this.plMain.Controls.Add(this.chkAutoSend);
            this.plMain.Controls.Add(this.checkEdit1);
            this.plMain.Controls.Add(this.gpRuiJieYun);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 24);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(437, 225);
            this.plMain.TabIndex = 5;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(246, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 61;
            this.simpleButton2.Text = "测试连接";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(336, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 61;
            this.simpleButton1.Text = "生成二维码";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // chkAutoSend
            // 
            this.chkAutoSend.Location = new System.Drawing.Point(131, 13);
            this.chkAutoSend.Name = "chkAutoSend";
            this.chkAutoSend.Properties.Caption = "自动上传";
            this.chkAutoSend.Size = new System.Drawing.Size(75, 20);
            this.chkAutoSend.TabIndex = 19;
            this.chkAutoSend.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(25, 13);
            this.checkEdit1.MenuManager = this.barManager;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "开启服务";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 19;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // gpRuiJieYun
            // 
            this.gpRuiJieYun.Controls.Add(this.lblRemoteAppSecret);
            this.gpRuiJieYun.Controls.Add(this.txtRegisterCode);
            this.gpRuiJieYun.Controls.Add(this.lblAppKey);
            this.gpRuiJieYun.Controls.Add(this.txtMachineCode);
            this.gpRuiJieYun.Controls.Add(this.labelControl1);
            this.gpRuiJieYun.Controls.Add(this.lblRemoteServerUrl);
            this.gpRuiJieYun.Controls.Add(this.txtServerUrl);
            this.gpRuiJieYun.Controls.Add(this.txtCompanyCode);
            this.gpRuiJieYun.Enabled = false;
            this.gpRuiJieYun.Location = new System.Drawing.Point(12, 39);
            this.gpRuiJieYun.Name = "gpRuiJieYun";
            this.gpRuiJieYun.Size = new System.Drawing.Size(415, 174);
            this.gpRuiJieYun.TabIndex = 60;
            this.gpRuiJieYun.Text = "云磅服务器设置";
            // 
            // lblRemoteAppSecret
            // 
            this.lblRemoteAppSecret.Location = new System.Drawing.Point(36, 137);
            this.lblRemoteAppSecret.Name = "lblRemoteAppSecret";
            this.lblRemoteAppSecret.Size = new System.Drawing.Size(40, 14);
            this.lblRemoteAppSecret.TabIndex = 17;
            this.lblRemoteAppSecret.Text = "连接码:";
            // 
            // txtRegisterCode
            // 
            this.txtRegisterCode.Location = new System.Drawing.Point(119, 135);
            this.txtRegisterCode.Name = "txtRegisterCode";
            this.txtRegisterCode.Size = new System.Drawing.Size(263, 20);
            this.txtRegisterCode.TabIndex = 18;
            this.txtRegisterCode.Tag = "AppSecret";
            // 
            // lblAppKey
            // 
            this.lblAppKey.Location = new System.Drawing.Point(36, 106);
            this.lblAppKey.Name = "lblAppKey";
            this.lblAppKey.Size = new System.Drawing.Size(52, 14);
            this.lblAppKey.TabIndex = 15;
            this.lblAppKey.Text = "终端编码:";
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Location = new System.Drawing.Point(119, 104);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(263, 20);
            this.txtMachineCode.TabIndex = 16;
            this.txtMachineCode.Tag = "AppKey";
            // 
            // lblRemoteServerUrl
            // 
            this.lblRemoteServerUrl.Location = new System.Drawing.Point(36, 73);
            this.lblRemoteServerUrl.Name = "lblRemoteServerUrl";
            this.lblRemoteServerUrl.Size = new System.Drawing.Size(52, 14);
            this.lblRemoteServerUrl.TabIndex = 11;
            this.lblRemoteServerUrl.Text = "商户编码:";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(119, 71);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(263, 20);
            this.txtCompanyCode.TabIndex = 12;
            this.txtCompanyCode.Tag = "ServerUrl";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(119, 35);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(263, 20);
            this.txtServerUrl.TabIndex = 12;
            this.txtServerUrl.Tag = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "平台地址:";
            // 
            // FrmTransferCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 249);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTransferCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "联网设置";
            this.Load += new System.EventHandler(this.FrmTransferCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpRuiJieYun)).EndInit();
            this.gpRuiJieYun.ResumeLayout(false);
            this.gpRuiJieYun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerUrl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.PanelControl plMain;
        private DevExpress.XtraEditors.GroupControl gpRuiJieYun;
        private DevExpress.XtraEditors.LabelControl lblRemoteAppSecret;
        private DevExpress.XtraEditors.TextEdit txtRegisterCode;
        private DevExpress.XtraEditors.LabelControl lblAppKey;
        private DevExpress.XtraEditors.TextEdit txtMachineCode;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.LabelControl lblRemoteServerUrl;
        private DevExpress.XtraEditors.TextEdit txtCompanyCode;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit chkAutoSend;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtServerUrl;
    }
}