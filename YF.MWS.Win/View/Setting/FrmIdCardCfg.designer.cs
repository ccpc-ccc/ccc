namespace YF.MWS.Win.View.Setting
{
    partial class FrmIdCardCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIdCardCfg));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.gpIdCardConfig = new DevExpress.XtraEditors.GroupControl();
            this.chkStartGenerateCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartSecondRead = new DevExpress.XtraEditors.CheckEdit();
            this.chkStart = new DevExpress.XtraEditors.CheckEdit();
            this.lblExtendParaTip = new DevExpress.XtraEditors.LabelControl();
            this.teExtendPara = new DevExpress.XtraEditors.TextEdit();
            this.lblExtendPara = new DevExpress.XtraEditors.LabelControl();
            this.lblPortParaTip = new DevExpress.XtraEditors.LabelControl();
            this.tePortPara = new DevExpress.XtraEditors.TextEdit();
            this.lblPortPara = new DevExpress.XtraEditors.LabelControl();
            this.lblPortTypeTip = new DevExpress.XtraEditors.LabelControl();
            this.comboUsbDeviceInfo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rgCommType = new DevExpress.XtraEditors.RadioGroup();
            this.tePortType = new DevExpress.XtraEditors.TextEdit();
            this.lblIPortType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpIdCardConfig)).BeginInit();
            this.gpIdCardConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartGenerateCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartSecondRead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teExtendPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePortPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboUsbDeviceInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCommType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePortType.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(551, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 375);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(551, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 351);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(551, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 351);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // gpIdCardConfig
            // 
            this.gpIdCardConfig.Controls.Add(this.chkStartGenerateCustomer);
            this.gpIdCardConfig.Controls.Add(this.chkStartSecondRead);
            this.gpIdCardConfig.Controls.Add(this.chkStart);
            this.gpIdCardConfig.Controls.Add(this.lblExtendParaTip);
            this.gpIdCardConfig.Controls.Add(this.teExtendPara);
            this.gpIdCardConfig.Controls.Add(this.lblExtendPara);
            this.gpIdCardConfig.Controls.Add(this.lblPortParaTip);
            this.gpIdCardConfig.Controls.Add(this.tePortPara);
            this.gpIdCardConfig.Controls.Add(this.lblPortPara);
            this.gpIdCardConfig.Controls.Add(this.lblPortTypeTip);
            this.gpIdCardConfig.Controls.Add(this.comboUsbDeviceInfo);
            this.gpIdCardConfig.Controls.Add(this.labelControl1);
            this.gpIdCardConfig.Controls.Add(this.rgCommType);
            this.gpIdCardConfig.Controls.Add(this.tePortType);
            this.gpIdCardConfig.Controls.Add(this.lblIPortType);
            this.gpIdCardConfig.Location = new System.Drawing.Point(22, 50);
            this.gpIdCardConfig.Name = "gpIdCardConfig";
            this.gpIdCardConfig.Size = new System.Drawing.Size(502, 298);
            this.gpIdCardConfig.TabIndex = 61;
            this.gpIdCardConfig.Text = "身份证识别器设置";
            // 
            // chkStartGenerateCustomer
            // 
            this.chkStartGenerateCustomer.Location = new System.Drawing.Point(305, 47);
            this.chkStartGenerateCustomer.Name = "chkStartGenerateCustomer";
            this.chkStartGenerateCustomer.Properties.Caption = "启用身份证信息生成客户单位";
            this.chkStartGenerateCustomer.Size = new System.Drawing.Size(180, 20);
            this.chkStartGenerateCustomer.TabIndex = 141;
            // 
            // chkStartSecondRead
            // 
            this.chkStartSecondRead.Location = new System.Drawing.Point(142, 80);
            this.chkStartSecondRead.Name = "chkStartSecondRead";
            this.chkStartSecondRead.Properties.Caption = "开启二次过磅读取身份证";
            this.chkStartSecondRead.Size = new System.Drawing.Size(172, 20);
            this.chkStartSecondRead.TabIndex = 140;
            // 
            // chkStart
            // 
            this.chkStart.Location = new System.Drawing.Point(142, 47);
            this.chkStart.Name = "chkStart";
            this.chkStart.Properties.Caption = "启用身份证识别器";
            this.chkStart.Size = new System.Drawing.Size(135, 20);
            this.chkStart.TabIndex = 139;
            // 
            // lblExtendParaTip
            // 
            this.lblExtendParaTip.Location = new System.Drawing.Point(363, 252);
            this.lblExtendParaTip.Name = "lblExtendParaTip";
            this.lblExtendParaTip.Size = new System.Drawing.Size(46, 14);
            this.lblExtendParaTip.TabIndex = 138;
            this.lblExtendParaTip.Text = "(扩展盒)";
            // 
            // teExtendPara
            // 
            this.teExtendPara.Location = new System.Drawing.Point(137, 250);
            this.teExtendPara.MenuManager = this.barManager;
            this.teExtendPara.Name = "teExtendPara";
            this.teExtendPara.Size = new System.Drawing.Size(209, 20);
            this.teExtendPara.TabIndex = 137;
            // 
            // lblExtendPara
            // 
            this.lblExtendPara.Location = new System.Drawing.Point(31, 252);
            this.lblExtendPara.Name = "lblExtendPara";
            this.lblExtendPara.Size = new System.Drawing.Size(52, 14);
            this.lblExtendPara.TabIndex = 136;
            this.lblExtendPara.Text = "扩展参数:";
            // 
            // lblPortParaTip
            // 
            this.lblPortParaTip.Location = new System.Drawing.Point(363, 217);
            this.lblPortParaTip.Name = "lblPortParaTip";
            this.lblPortParaTip.Size = new System.Drawing.Size(46, 14);
            this.lblPortParaTip.TabIndex = 135;
            this.lblPortParaTip.Text = "(波特率)";
            // 
            // tePortPara
            // 
            this.tePortPara.Location = new System.Drawing.Point(137, 215);
            this.tePortPara.MenuManager = this.barManager;
            this.tePortPara.Name = "tePortPara";
            this.tePortPara.Size = new System.Drawing.Size(209, 20);
            this.tePortPara.TabIndex = 134;
            // 
            // lblPortPara
            // 
            this.lblPortPara.Location = new System.Drawing.Point(31, 217);
            this.lblPortPara.Name = "lblPortPara";
            this.lblPortPara.Size = new System.Drawing.Size(52, 14);
            this.lblPortPara.TabIndex = 133;
            this.lblPortPara.Text = "端口参数:";
            // 
            // lblPortTypeTip
            // 
            this.lblPortTypeTip.Location = new System.Drawing.Point(363, 156);
            this.lblPortTypeTip.Name = "lblPortTypeTip";
            this.lblPortTypeTip.Size = new System.Drawing.Size(46, 14);
            this.lblPortTypeTip.TabIndex = 132;
            this.lblPortTypeTip.Text = "(串口号)";
            // 
            // comboUsbDeviceInfo
            // 
            this.comboUsbDeviceInfo.Location = new System.Drawing.Point(137, 184);
            this.comboUsbDeviceInfo.MenuManager = this.barManager;
            this.comboUsbDeviceInfo.Name = "comboUsbDeviceInfo";
            this.comboUsbDeviceInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboUsbDeviceInfo.Properties.Items.AddRange(new object[] {
            "0400C35A <==> SS628100U",
            "261A0007 <==> SS628100H",
            "261A000C <==> SS728M05",
            "261A0011 <==> SS628100X1",
            "261A0012 <==> SS728M801",
            "261A001C <==> SS628100Wm"});
            this.comboUsbDeviceInfo.Size = new System.Drawing.Size(209, 20);
            this.comboUsbDeviceInfo.TabIndex = 131;
            this.comboUsbDeviceInfo.SelectedIndexChanged += new System.EventHandler(this.comboUsbDeviceInfo_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 124);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 130;
            this.labelControl1.Text = "通讯方式:";
            // 
            // rgCommType
            // 
            this.rgCommType.EditValue = "Com";
            this.rgCommType.Location = new System.Drawing.Point(137, 118);
            this.rgCommType.MenuManager = this.barManager;
            this.rgCommType.Name = "rgCommType";
            this.rgCommType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Com", "串口"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Usb", "USB")});
            this.rgCommType.Size = new System.Drawing.Size(209, 26);
            this.rgCommType.TabIndex = 129;
            this.rgCommType.SelectedIndexChanged += new System.EventHandler(this.rgWriteCardType_SelectedIndexChanged);
            // 
            // tePortType
            // 
            this.tePortType.Location = new System.Drawing.Point(137, 154);
            this.tePortType.MenuManager = this.barManager;
            this.tePortType.Name = "tePortType";
            this.tePortType.Size = new System.Drawing.Size(209, 20);
            this.tePortType.TabIndex = 128;
            // 
            // lblIPortType
            // 
            this.lblIPortType.Location = new System.Drawing.Point(35, 156);
            this.lblIPortType.Name = "lblIPortType";
            this.lblIPortType.Size = new System.Drawing.Size(52, 14);
            this.lblIPortType.TabIndex = 126;
            this.lblIPortType.Text = "端口类型:";
            // 
            // FrmIdCardCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 375);
            this.Controls.Add(this.gpIdCardConfig);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmIdCardCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "身份证识别器设置";
            this.Load += new System.EventHandler(this.FrmIdCardCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpIdCardConfig)).EndInit();
            this.gpIdCardConfig.ResumeLayout(false);
            this.gpIdCardConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartGenerateCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartSecondRead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teExtendPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePortPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboUsbDeviceInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCommType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePortType.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl gpIdCardConfig;
        private DevExpress.XtraEditors.TextEdit tePortType;
        private DevExpress.XtraEditors.LabelControl lblIPortType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rgCommType;
        private DevExpress.XtraEditors.ComboBoxEdit comboUsbDeviceInfo;
        private DevExpress.XtraEditors.LabelControl lblExtendParaTip;
        private DevExpress.XtraEditors.TextEdit teExtendPara;
        private DevExpress.XtraEditors.LabelControl lblExtendPara;
        private DevExpress.XtraEditors.LabelControl lblPortParaTip;
        private DevExpress.XtraEditors.TextEdit tePortPara;
        private DevExpress.XtraEditors.LabelControl lblPortPara;
        private DevExpress.XtraEditors.LabelControl lblPortTypeTip;
        private DevExpress.XtraEditors.CheckEdit chkStartSecondRead;
        private DevExpress.XtraEditors.CheckEdit chkStart;
        private DevExpress.XtraEditors.CheckEdit chkStartGenerateCustomer;
    }
}