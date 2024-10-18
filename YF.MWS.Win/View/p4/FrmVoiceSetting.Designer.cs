namespace YF.MWS.Win.View.Master
{
    partial class FrmVoiceSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoiceSetting));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.gpTest = new DevExpress.XtraEditors.GroupControl();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teTest = new DevExpress.XtraEditors.TextEdit();
            this.gpBasic = new DevExpress.XtraEditors.GroupControl();
            this.chkStartVoicePrompt = new DevExpress.XtraEditors.CheckEdit();
            this.rgBroadcastWeightType = new DevExpress.XtraEditors.RadioGroup();
            this.pcMain = new DevExpress.XtraEditors.PanelControl();
            this.lblUnloadWeight = new DevExpress.XtraEditors.LabelControl();
            this.teUnloadWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblCarRecognition = new DevExpress.XtraEditors.LabelControl();
            this.teCarRecognition = new DevExpress.XtraEditors.TextEdit();
            this.lblStartWeight = new DevExpress.XtraEditors.LabelControl();
            this.teStartWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblStartReadCard = new DevExpress.XtraEditors.LabelControl();
            this.teStartReadCard = new DevExpress.XtraEditors.TextEdit();
            this.lblInfraredCovered = new DevExpress.XtraEditors.LabelControl();
            this.teInfraredCovered = new DevExpress.XtraEditors.TextEdit();
            this.lblCarStop = new DevExpress.XtraEditors.LabelControl();
            this.teCarStopFail = new DevExpress.XtraEditors.TextEdit();
            this.lblReadCardFail = new DevExpress.XtraEditors.LabelControl();
            this.teReadCardFail = new DevExpress.XtraEditors.TextEdit();
            this.lblTimeOut = new DevExpress.XtraEditors.LabelControl();
            this.teTimeOut = new DevExpress.XtraEditors.TextEdit();
            this.lblSecondWeight = new DevExpress.XtraEditors.LabelControl();
            this.teSecondWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblFirstWeight = new DevExpress.XtraEditors.LabelControl();
            this.teFirstWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblWeightUnStable = new DevExpress.XtraEditors.LabelControl();
            this.teWeightUnStable = new DevExpress.XtraEditors.TextEdit();
            this.lblReadCardSuccess = new DevExpress.XtraEditors.LabelControl();
            this.teReadCardSuccess = new DevExpress.XtraEditors.TextEdit();
            this.lblOverWeight = new DevExpress.XtraEditors.LabelControl();
            this.teOverWeight = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpTest)).BeginInit();
            this.gpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBasic)).BeginInit();
            this.gpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartVoicePrompt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBroadcastWeightType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            this.pcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUnloadWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarRecognition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartReadCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInfraredCovered.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarStopFail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teReadCardFail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSecondWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFirstWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWeightUnStable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teReadCardSuccess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOverWeight.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(941, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 499);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(941, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 475);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(941, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 475);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // gpTest
            // 
            this.gpTest.Controls.Add(this.btnTest);
            this.gpTest.Controls.Add(this.labelControl1);
            this.gpTest.Controls.Add(this.teTest);
            this.gpTest.Location = new System.Drawing.Point(0, 388);
            this.gpTest.Name = "gpTest";
            this.gpTest.Size = new System.Drawing.Size(941, 111);
            this.gpTest.TabIndex = 9;
            this.gpTest.Text = "语音测试";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(605, 40);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 26;
            this.btnTest.Text = "测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "测试文字:";
            // 
            // teTest
            // 
            this.teTest.Location = new System.Drawing.Point(145, 41);
            this.teTest.MenuManager = this.barManager;
            this.teTest.Name = "teTest";
            this.teTest.Size = new System.Drawing.Size(454, 20);
            this.teTest.TabIndex = 24;
            // 
            // gpBasic
            // 
            this.gpBasic.Controls.Add(this.chkStartVoicePrompt);
            this.gpBasic.Controls.Add(this.rgBroadcastWeightType);
            this.gpBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpBasic.Location = new System.Drawing.Point(0, 24);
            this.gpBasic.Name = "gpBasic";
            this.gpBasic.Size = new System.Drawing.Size(941, 82);
            this.gpBasic.TabIndex = 27;
            this.gpBasic.Text = "语音设置";
            // 
            // chkStartVoicePrompt
            // 
            this.chkStartVoicePrompt.Location = new System.Drawing.Point(135, 40);
            this.chkStartVoicePrompt.MenuManager = this.barManager;
            this.chkStartVoicePrompt.Name = "chkStartVoicePrompt";
            this.chkStartVoicePrompt.Properties.Caption = "启用语音提示";
            this.chkStartVoicePrompt.Size = new System.Drawing.Size(103, 20);
            this.chkStartVoicePrompt.TabIndex = 92;
            // 
            // rgBroadcastWeightType
            // 
            this.rgBroadcastWeightType.EditValue = "SourceWeight";
            this.rgBroadcastWeightType.Location = new System.Drawing.Point(250, 37);
            this.rgBroadcastWeightType.MenuManager = this.barManager;
            this.rgBroadcastWeightType.Name = "rgBroadcastWeightType";
            this.rgBroadcastWeightType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgBroadcastWeightType.Properties.Appearance.Options.UseBackColor = true;
            this.rgBroadcastWeightType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.rgBroadcastWeightType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SourceWeight", "播报原始重量"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SuttleWeight", "播报净重")});
            this.rgBroadcastWeightType.Size = new System.Drawing.Size(260, 25);
            this.rgBroadcastWeightType.TabIndex = 26;
            // 
            // pcMain
            // 
            this.pcMain.Controls.Add(this.lblUnloadWeight);
            this.pcMain.Controls.Add(this.teUnloadWeight);
            this.pcMain.Controls.Add(this.lblCarRecognition);
            this.pcMain.Controls.Add(this.teCarRecognition);
            this.pcMain.Controls.Add(this.lblStartWeight);
            this.pcMain.Controls.Add(this.teStartWeight);
            this.pcMain.Controls.Add(this.lblStartReadCard);
            this.pcMain.Controls.Add(this.teStartReadCard);
            this.pcMain.Controls.Add(this.lblInfraredCovered);
            this.pcMain.Controls.Add(this.teInfraredCovered);
            this.pcMain.Controls.Add(this.lblCarStop);
            this.pcMain.Controls.Add(this.teCarStopFail);
            this.pcMain.Controls.Add(this.lblReadCardFail);
            this.pcMain.Controls.Add(this.teReadCardFail);
            this.pcMain.Controls.Add(this.lblTimeOut);
            this.pcMain.Controls.Add(this.teTimeOut);
            this.pcMain.Controls.Add(this.lblSecondWeight);
            this.pcMain.Controls.Add(this.teSecondWeight);
            this.pcMain.Controls.Add(this.lblFirstWeight);
            this.pcMain.Controls.Add(this.teFirstWeight);
            this.pcMain.Controls.Add(this.lblWeightUnStable);
            this.pcMain.Controls.Add(this.teWeightUnStable);
            this.pcMain.Controls.Add(this.lblReadCardSuccess);
            this.pcMain.Controls.Add(this.teReadCardSuccess);
            this.pcMain.Controls.Add(this.lblOverWeight);
            this.pcMain.Controls.Add(this.teOverWeight);
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcMain.Location = new System.Drawing.Point(0, 106);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(941, 275);
            this.pcMain.TabIndex = 28;
            // 
            // lblUnloadWeight
            // 
            this.lblUnloadWeight.Location = new System.Drawing.Point(483, 238);
            this.lblUnloadWeight.Name = "lblUnloadWeight";
            this.lblUnloadWeight.Size = new System.Drawing.Size(64, 14);
            this.lblUnloadWeight.TabIndex = 25;
            this.lblUnloadWeight.Text = "下磅提示音:";
            // 
            // teUnloadWeight
            // 
            this.teUnloadWeight.Location = new System.Drawing.Point(602, 235);
            this.teUnloadWeight.MenuManager = this.barManager;
            this.teUnloadWeight.Name = "teUnloadWeight";
            this.teUnloadWeight.Size = new System.Drawing.Size(289, 20);
            this.teUnloadWeight.TabIndex = 24;
            // 
            // lblCarRecognition
            // 
            this.lblCarRecognition.Location = new System.Drawing.Point(26, 124);
            this.lblCarRecognition.Name = "lblCarRecognition";
            this.lblCarRecognition.Size = new System.Drawing.Size(88, 14);
            this.lblCarRecognition.TabIndex = 23;
            this.lblCarRecognition.Text = "车牌识别提示音:";
            // 
            // teCarRecognition
            // 
            this.teCarRecognition.Location = new System.Drawing.Point(145, 121);
            this.teCarRecognition.MenuManager = this.barManager;
            this.teCarRecognition.Name = "teCarRecognition";
            this.teCarRecognition.Size = new System.Drawing.Size(289, 20);
            this.teCarRecognition.TabIndex = 22;
            // 
            // lblStartWeight
            // 
            this.lblStartWeight.Location = new System.Drawing.Point(26, 154);
            this.lblStartWeight.Name = "lblStartWeight";
            this.lblStartWeight.Size = new System.Drawing.Size(64, 14);
            this.lblStartWeight.TabIndex = 21;
            this.lblStartWeight.Text = "上磅提示音:";
            // 
            // teStartWeight
            // 
            this.teStartWeight.Location = new System.Drawing.Point(145, 155);
            this.teStartWeight.MenuManager = this.barManager;
            this.teStartWeight.Name = "teStartWeight";
            this.teStartWeight.Size = new System.Drawing.Size(289, 20);
            this.teStartWeight.TabIndex = 20;
            // 
            // lblStartReadCard
            // 
            this.lblStartReadCard.Location = new System.Drawing.Point(26, 22);
            this.lblStartReadCard.Name = "lblStartReadCard";
            this.lblStartReadCard.Size = new System.Drawing.Size(52, 14);
            this.lblStartReadCard.TabIndex = 19;
            this.lblStartReadCard.Text = "开始刷卡:";
            // 
            // teStartReadCard
            // 
            this.teStartReadCard.Location = new System.Drawing.Point(145, 22);
            this.teStartReadCard.MenuManager = this.barManager;
            this.teStartReadCard.Name = "teStartReadCard";
            this.teStartReadCard.Size = new System.Drawing.Size(289, 20);
            this.teStartReadCard.TabIndex = 18;
            // 
            // lblInfraredCovered
            // 
            this.lblInfraredCovered.Location = new System.Drawing.Point(483, 98);
            this.lblInfraredCovered.Name = "lblInfraredCovered";
            this.lblInfraredCovered.Size = new System.Drawing.Size(52, 14);
            this.lblInfraredCovered.TabIndex = 17;
            this.lblInfraredCovered.Text = "红外被挡:";
            // 
            // teInfraredCovered
            // 
            this.teInfraredCovered.Location = new System.Drawing.Point(602, 95);
            this.teInfraredCovered.MenuManager = this.barManager;
            this.teInfraredCovered.Name = "teInfraredCovered";
            this.teInfraredCovered.Size = new System.Drawing.Size(289, 20);
            this.teInfraredCovered.TabIndex = 16;
            // 
            // lblCarStop
            // 
            this.lblCarStop.Location = new System.Drawing.Point(483, 23);
            this.lblCarStop.Name = "lblCarStop";
            this.lblCarStop.Size = new System.Drawing.Size(52, 14);
            this.lblCarStop.TabIndex = 15;
            this.lblCarStop.Text = "车未停好:";
            // 
            // teCarStopFail
            // 
            this.teCarStopFail.Location = new System.Drawing.Point(602, 22);
            this.teCarStopFail.MenuManager = this.barManager;
            this.teCarStopFail.Name = "teCarStopFail";
            this.teCarStopFail.Size = new System.Drawing.Size(289, 20);
            this.teCarStopFail.TabIndex = 14;
            // 
            // lblReadCardFail
            // 
            this.lblReadCardFail.Location = new System.Drawing.Point(26, 90);
            this.lblReadCardFail.Name = "lblReadCardFail";
            this.lblReadCardFail.Size = new System.Drawing.Size(52, 14);
            this.lblReadCardFail.TabIndex = 13;
            this.lblReadCardFail.Text = "刷卡失败:";
            // 
            // teReadCardFail
            // 
            this.teReadCardFail.Location = new System.Drawing.Point(145, 87);
            this.teReadCardFail.MenuManager = this.barManager;
            this.teReadCardFail.Name = "teReadCardFail";
            this.teReadCardFail.Size = new System.Drawing.Size(289, 20);
            this.teReadCardFail.TabIndex = 12;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Location = new System.Drawing.Point(26, 189);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(28, 14);
            this.lblTimeOut.TabIndex = 11;
            this.lblTimeOut.Text = "超时:";
            // 
            // teTimeOut
            // 
            this.teTimeOut.Location = new System.Drawing.Point(145, 190);
            this.teTimeOut.MenuManager = this.barManager;
            this.teTimeOut.Name = "teTimeOut";
            this.teTimeOut.Size = new System.Drawing.Size(289, 20);
            this.teTimeOut.TabIndex = 10;
            // 
            // lblSecondWeight
            // 
            this.lblSecondWeight.Location = new System.Drawing.Point(483, 202);
            this.lblSecondWeight.Name = "lblSecondWeight";
            this.lblSecondWeight.Size = new System.Drawing.Size(100, 14);
            this.lblSecondWeight.TabIndex = 9;
            this.lblSecondWeight.Text = "第二次完成称重时:";
            // 
            // teSecondWeight
            // 
            this.teSecondWeight.Location = new System.Drawing.Point(602, 199);
            this.teSecondWeight.MenuManager = this.barManager;
            this.teSecondWeight.Name = "teSecondWeight";
            this.teSecondWeight.Size = new System.Drawing.Size(289, 20);
            this.teSecondWeight.TabIndex = 8;
            // 
            // lblFirstWeight
            // 
            this.lblFirstWeight.Location = new System.Drawing.Point(483, 168);
            this.lblFirstWeight.Name = "lblFirstWeight";
            this.lblFirstWeight.Size = new System.Drawing.Size(100, 14);
            this.lblFirstWeight.TabIndex = 7;
            this.lblFirstWeight.Text = "第一次完成称重时:";
            // 
            // teFirstWeight
            // 
            this.teFirstWeight.Location = new System.Drawing.Point(602, 165);
            this.teFirstWeight.MenuManager = this.barManager;
            this.teFirstWeight.Name = "teFirstWeight";
            this.teFirstWeight.Size = new System.Drawing.Size(289, 20);
            this.teFirstWeight.TabIndex = 6;
            // 
            // lblWeightUnStable
            // 
            this.lblWeightUnStable.Location = new System.Drawing.Point(483, 64);
            this.lblWeightUnStable.Name = "lblWeightUnStable";
            this.lblWeightUnStable.Size = new System.Drawing.Size(76, 14);
            this.lblWeightUnStable.TabIndex = 5;
            this.lblWeightUnStable.Text = "称重未稳定时:";
            // 
            // teWeightUnStable
            // 
            this.teWeightUnStable.Location = new System.Drawing.Point(602, 61);
            this.teWeightUnStable.MenuManager = this.barManager;
            this.teWeightUnStable.Name = "teWeightUnStable";
            this.teWeightUnStable.Size = new System.Drawing.Size(289, 20);
            this.teWeightUnStable.TabIndex = 4;
            // 
            // lblReadCardSuccess
            // 
            this.lblReadCardSuccess.Location = new System.Drawing.Point(26, 57);
            this.lblReadCardSuccess.Name = "lblReadCardSuccess";
            this.lblReadCardSuccess.Size = new System.Drawing.Size(52, 14);
            this.lblReadCardSuccess.TabIndex = 3;
            this.lblReadCardSuccess.Text = "刷卡成功:";
            // 
            // teReadCardSuccess
            // 
            this.teReadCardSuccess.Location = new System.Drawing.Point(145, 54);
            this.teReadCardSuccess.MenuManager = this.barManager;
            this.teReadCardSuccess.Name = "teReadCardSuccess";
            this.teReadCardSuccess.Size = new System.Drawing.Size(289, 20);
            this.teReadCardSuccess.TabIndex = 2;
            // 
            // lblOverWeight
            // 
            this.lblOverWeight.Location = new System.Drawing.Point(483, 132);
            this.lblOverWeight.Name = "lblOverWeight";
            this.lblOverWeight.Size = new System.Drawing.Size(64, 14);
            this.lblOverWeight.TabIndex = 1;
            this.lblOverWeight.Text = "超载提示音:";
            // 
            // teOverWeight
            // 
            this.teOverWeight.Location = new System.Drawing.Point(602, 129);
            this.teOverWeight.MenuManager = this.barManager;
            this.teOverWeight.Name = "teOverWeight";
            this.teOverWeight.Size = new System.Drawing.Size(289, 20);
            this.teOverWeight.TabIndex = 0;
            // 
            // FrmVoiceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 499);
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.gpBasic);
            this.Controls.Add(this.gpTest);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmVoiceSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音文字设置";
            this.Load += new System.EventHandler(this.FrmVoiceSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpTest)).EndInit();
            this.gpTest.ResumeLayout(false);
            this.gpTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBasic)).EndInit();
            this.gpBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkStartVoicePrompt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgBroadcastWeightType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            this.pcMain.ResumeLayout(false);
            this.pcMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUnloadWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarRecognition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartReadCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInfraredCovered.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarStopFail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teReadCardFail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSecondWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFirstWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWeightUnStable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teReadCardSuccess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOverWeight.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.GroupControl gpTest;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teTest;
        private DevExpress.XtraEditors.PanelControl pcMain;
        private DevExpress.XtraEditors.LabelControl lblUnloadWeight;
        private DevExpress.XtraEditors.TextEdit teUnloadWeight;
        private DevExpress.XtraEditors.LabelControl lblCarRecognition;
        private DevExpress.XtraEditors.TextEdit teCarRecognition;
        private DevExpress.XtraEditors.LabelControl lblStartWeight;
        private DevExpress.XtraEditors.TextEdit teStartWeight;
        private DevExpress.XtraEditors.LabelControl lblStartReadCard;
        private DevExpress.XtraEditors.TextEdit teStartReadCard;
        private DevExpress.XtraEditors.LabelControl lblInfraredCovered;
        private DevExpress.XtraEditors.TextEdit teInfraredCovered;
        private DevExpress.XtraEditors.LabelControl lblCarStop;
        private DevExpress.XtraEditors.TextEdit teCarStopFail;
        private DevExpress.XtraEditors.LabelControl lblReadCardFail;
        private DevExpress.XtraEditors.TextEdit teReadCardFail;
        private DevExpress.XtraEditors.LabelControl lblTimeOut;
        private DevExpress.XtraEditors.TextEdit teTimeOut;
        private DevExpress.XtraEditors.LabelControl lblSecondWeight;
        private DevExpress.XtraEditors.TextEdit teSecondWeight;
        private DevExpress.XtraEditors.LabelControl lblFirstWeight;
        private DevExpress.XtraEditors.TextEdit teFirstWeight;
        private DevExpress.XtraEditors.LabelControl lblWeightUnStable;
        private DevExpress.XtraEditors.TextEdit teWeightUnStable;
        private DevExpress.XtraEditors.LabelControl lblReadCardSuccess;
        private DevExpress.XtraEditors.TextEdit teReadCardSuccess;
        private DevExpress.XtraEditors.LabelControl lblOverWeight;
        private DevExpress.XtraEditors.TextEdit teOverWeight;
        private DevExpress.XtraEditors.GroupControl gpBasic;
        private DevExpress.XtraEditors.RadioGroup rgBroadcastWeightType;
        private DevExpress.XtraEditors.CheckEdit chkStartVoicePrompt;
    }
}