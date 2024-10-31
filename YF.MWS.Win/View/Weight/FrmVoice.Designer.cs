namespace YF.MWS.Win.View.Weight
{
    partial class FrmVoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoice));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.pcMain = new DevExpress.XtraEditors.PanelControl();
            this.btnUnloadWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnSecondWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirstWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnOverWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnInfraredCovered = new DevExpress.XtraEditors.SimpleButton();
            this.btnWeightUnStable = new DevExpress.XtraEditors.SimpleButton();
            this.btnCarStopFail = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimeOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnStartWeight = new DevExpress.XtraEditors.SimpleButton();
            this.btnCarRecognition = new DevExpress.XtraEditors.SimpleButton();
            this.btnReadCardFail = new DevExpress.XtraEditors.SimpleButton();
            this.btnReadCardSuccess = new DevExpress.XtraEditors.SimpleButton();
            this.btnStartReadCard = new DevExpress.XtraEditors.SimpleButton();
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
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
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
            this.btnItemClose,
            this.barButtonItem1});
            this.barManager.MaxItemId = 12;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "保存";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 0;
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
            this.barDockControlTop.Size = new System.Drawing.Size(576, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 511);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(576, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 487);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(576, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 487);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "voice_16x16.png");
            // 
            // pcMain
            // 
            this.pcMain.Controls.Add(this.btnUnloadWeight);
            this.pcMain.Controls.Add(this.btnSecondWeight);
            this.pcMain.Controls.Add(this.btnFirstWeight);
            this.pcMain.Controls.Add(this.btnOverWeight);
            this.pcMain.Controls.Add(this.btnInfraredCovered);
            this.pcMain.Controls.Add(this.btnWeightUnStable);
            this.pcMain.Controls.Add(this.btnCarStopFail);
            this.pcMain.Controls.Add(this.btnTimeOut);
            this.pcMain.Controls.Add(this.btnStartWeight);
            this.pcMain.Controls.Add(this.btnCarRecognition);
            this.pcMain.Controls.Add(this.btnReadCardFail);
            this.pcMain.Controls.Add(this.btnReadCardSuccess);
            this.pcMain.Controls.Add(this.btnStartReadCard);
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
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 24);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(576, 487);
            this.pcMain.TabIndex = 5;
            // 
            // btnUnloadWeight
            // 
            this.btnUnloadWeight.ImageOptions.ImageIndex = 1;
            this.btnUnloadWeight.ImageOptions.ImageList = this.imgListSmall;
            this.btnUnloadWeight.Location = new System.Drawing.Point(466, 438);
            this.btnUnloadWeight.Name = "btnUnloadWeight";
            this.btnUnloadWeight.Size = new System.Drawing.Size(75, 23);
            this.btnUnloadWeight.TabIndex = 37;
            this.btnUnloadWeight.Text = "播报";
            this.btnUnloadWeight.Click += new System.EventHandler(this.btnUnloadWeight_Click);
            // 
            // btnSecondWeight
            // 
            this.btnSecondWeight.ImageOptions.ImageIndex = 1;
            this.btnSecondWeight.ImageOptions.ImageList = this.imgListSmall;
            this.btnSecondWeight.Location = new System.Drawing.Point(466, 403);
            this.btnSecondWeight.Name = "btnSecondWeight";
            this.btnSecondWeight.Size = new System.Drawing.Size(75, 23);
            this.btnSecondWeight.TabIndex = 27;
            this.btnSecondWeight.Text = "播报";
            this.btnSecondWeight.Click += new System.EventHandler(this.btnSecondWeight_Click);
            // 
            // btnFirstWeight
            // 
            this.btnFirstWeight.ImageOptions.ImageIndex = 1;
            this.btnFirstWeight.ImageOptions.ImageList = this.imgListSmall;
            this.btnFirstWeight.Location = new System.Drawing.Point(466, 368);
            this.btnFirstWeight.Name = "btnFirstWeight";
            this.btnFirstWeight.Size = new System.Drawing.Size(75, 23);
            this.btnFirstWeight.TabIndex = 28;
            this.btnFirstWeight.Text = "播报";
            this.btnFirstWeight.Click += new System.EventHandler(this.btnFirstWeight_Click);
            // 
            // btnOverWeight
            // 
            this.btnOverWeight.ImageOptions.ImageIndex = 1;
            this.btnOverWeight.ImageOptions.ImageList = this.imgListSmall;
            this.btnOverWeight.Location = new System.Drawing.Point(466, 330);
            this.btnOverWeight.Name = "btnOverWeight";
            this.btnOverWeight.Size = new System.Drawing.Size(75, 23);
            this.btnOverWeight.TabIndex = 29;
            this.btnOverWeight.Text = "播报";
            this.btnOverWeight.Click += new System.EventHandler(this.btnOverWeight_Click);
            // 
            // btnInfraredCovered
            // 
            this.btnInfraredCovered.ImageOptions.ImageIndex = 1;
            this.btnInfraredCovered.ImageOptions.ImageList = this.imgListSmall;
            this.btnInfraredCovered.Location = new System.Drawing.Point(466, 296);
            this.btnInfraredCovered.Name = "btnInfraredCovered";
            this.btnInfraredCovered.Size = new System.Drawing.Size(75, 23);
            this.btnInfraredCovered.TabIndex = 30;
            this.btnInfraredCovered.Text = "播报";
            this.btnInfraredCovered.Click += new System.EventHandler(this.btnInfraredCovered_Click);
            // 
            // btnWeightUnStable
            // 
            this.btnWeightUnStable.ImageOptions.ImageIndex = 1;
            this.btnWeightUnStable.ImageOptions.ImageList = this.imgListSmall;
            this.btnWeightUnStable.Location = new System.Drawing.Point(466, 262);
            this.btnWeightUnStable.Name = "btnWeightUnStable";
            this.btnWeightUnStable.Size = new System.Drawing.Size(75, 23);
            this.btnWeightUnStable.TabIndex = 31;
            this.btnWeightUnStable.Text = "播报";
            this.btnWeightUnStable.Click += new System.EventHandler(this.btnWeightUnStable_Click);
            // 
            // btnCarStopFail
            // 
            this.btnCarStopFail.ImageOptions.ImageIndex = 1;
            this.btnCarStopFail.ImageOptions.ImageList = this.imgListSmall;
            this.btnCarStopFail.Location = new System.Drawing.Point(466, 223);
            this.btnCarStopFail.Name = "btnCarStopFail";
            this.btnCarStopFail.Size = new System.Drawing.Size(75, 23);
            this.btnCarStopFail.TabIndex = 32;
            this.btnCarStopFail.Text = "播报";
            this.btnCarStopFail.Click += new System.EventHandler(this.btnCarStopFail_Click);
            // 
            // btnTimeOut
            // 
            this.btnTimeOut.ImageOptions.ImageIndex = 1;
            this.btnTimeOut.ImageOptions.ImageList = this.imgListSmall;
            this.btnTimeOut.Location = new System.Drawing.Point(466, 185);
            this.btnTimeOut.Name = "btnTimeOut";
            this.btnTimeOut.Size = new System.Drawing.Size(75, 23);
            this.btnTimeOut.TabIndex = 33;
            this.btnTimeOut.Text = "播报";
            this.btnTimeOut.Click += new System.EventHandler(this.btnTimeOut_Click);
            // 
            // btnStartWeight
            // 
            this.btnStartWeight.ImageOptions.ImageIndex = 1;
            this.btnStartWeight.ImageOptions.ImageList = this.imgListSmall;
            this.btnStartWeight.Location = new System.Drawing.Point(466, 151);
            this.btnStartWeight.Name = "btnStartWeight";
            this.btnStartWeight.Size = new System.Drawing.Size(75, 23);
            this.btnStartWeight.TabIndex = 34;
            this.btnStartWeight.Text = "播报";
            this.btnStartWeight.Click += new System.EventHandler(this.btnStartWeight_Click);
            // 
            // btnCarRecognition
            // 
            this.btnCarRecognition.ImageOptions.ImageIndex = 1;
            this.btnCarRecognition.ImageOptions.ImageList = this.imgListSmall;
            this.btnCarRecognition.Location = new System.Drawing.Point(466, 116);
            this.btnCarRecognition.Name = "btnCarRecognition";
            this.btnCarRecognition.Size = new System.Drawing.Size(75, 23);
            this.btnCarRecognition.TabIndex = 35;
            this.btnCarRecognition.Text = "播报";
            this.btnCarRecognition.Click += new System.EventHandler(this.btnCarRecognition_Click);
            // 
            // btnReadCardFail
            // 
            this.btnReadCardFail.ImageOptions.ImageIndex = 1;
            this.btnReadCardFail.ImageOptions.ImageList = this.imgListSmall;
            this.btnReadCardFail.Location = new System.Drawing.Point(466, 82);
            this.btnReadCardFail.Name = "btnReadCardFail";
            this.btnReadCardFail.Size = new System.Drawing.Size(75, 23);
            this.btnReadCardFail.TabIndex = 36;
            this.btnReadCardFail.Text = "播报";
            this.btnReadCardFail.Click += new System.EventHandler(this.btnReadCardFail_Click);
            // 
            // btnReadCardSuccess
            // 
            this.btnReadCardSuccess.ImageOptions.ImageIndex = 1;
            this.btnReadCardSuccess.ImageOptions.ImageList = this.imgListSmall;
            this.btnReadCardSuccess.Location = new System.Drawing.Point(466, 48);
            this.btnReadCardSuccess.Name = "btnReadCardSuccess";
            this.btnReadCardSuccess.Size = new System.Drawing.Size(75, 23);
            this.btnReadCardSuccess.TabIndex = 27;
            this.btnReadCardSuccess.Text = "播报";
            this.btnReadCardSuccess.Click += new System.EventHandler(this.btnReadCardSuccess_Click);
            // 
            // btnStartReadCard
            // 
            this.btnStartReadCard.ImageOptions.ImageIndex = 1;
            this.btnStartReadCard.ImageOptions.ImageList = this.imgListSmall;
            this.btnStartReadCard.Location = new System.Drawing.Point(466, 18);
            this.btnStartReadCard.Name = "btnStartReadCard";
            this.btnStartReadCard.Size = new System.Drawing.Size(75, 23);
            this.btnStartReadCard.TabIndex = 26;
            this.btnStartReadCard.Text = "播报";
            this.btnStartReadCard.Click += new System.EventHandler(this.btnStartReadCard_Click);
            // 
            // lblUnloadWeight
            // 
            this.lblUnloadWeight.Location = new System.Drawing.Point(24, 442);
            this.lblUnloadWeight.Name = "lblUnloadWeight";
            this.lblUnloadWeight.Size = new System.Drawing.Size(64, 14);
            this.lblUnloadWeight.TabIndex = 25;
            this.lblUnloadWeight.Text = "下磅提示音:";
            // 
            // teUnloadWeight
            // 
            this.teUnloadWeight.Location = new System.Drawing.Point(143, 439);
            this.teUnloadWeight.MenuManager = this.barManager;
            this.teUnloadWeight.Name = "teUnloadWeight";
            this.teUnloadWeight.Size = new System.Drawing.Size(289, 20);
            this.teUnloadWeight.TabIndex = 24;
            // 
            // lblCarRecognition
            // 
            this.lblCarRecognition.Location = new System.Drawing.Point(26, 121);
            this.lblCarRecognition.Name = "lblCarRecognition";
            this.lblCarRecognition.Size = new System.Drawing.Size(88, 14);
            this.lblCarRecognition.TabIndex = 23;
            this.lblCarRecognition.Text = "车牌识别提示音:";
            // 
            // teCarRecognition
            // 
            this.teCarRecognition.Location = new System.Drawing.Point(143, 118);
            this.teCarRecognition.MenuManager = this.barManager;
            this.teCarRecognition.Name = "teCarRecognition";
            this.teCarRecognition.Size = new System.Drawing.Size(289, 20);
            this.teCarRecognition.TabIndex = 22;
            // 
            // lblStartWeight
            // 
            this.lblStartWeight.Location = new System.Drawing.Point(24, 155);
            this.lblStartWeight.Name = "lblStartWeight";
            this.lblStartWeight.Size = new System.Drawing.Size(64, 14);
            this.lblStartWeight.TabIndex = 21;
            this.lblStartWeight.Text = "上磅提示音:";
            // 
            // teStartWeight
            // 
            this.teStartWeight.Location = new System.Drawing.Point(143, 152);
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
            this.teStartReadCard.Location = new System.Drawing.Point(143, 19);
            this.teStartReadCard.MenuManager = this.barManager;
            this.teStartReadCard.Name = "teStartReadCard";
            this.teStartReadCard.Size = new System.Drawing.Size(289, 20);
            this.teStartReadCard.TabIndex = 18;
            // 
            // lblInfraredCovered
            // 
            this.lblInfraredCovered.Location = new System.Drawing.Point(24, 302);
            this.lblInfraredCovered.Name = "lblInfraredCovered";
            this.lblInfraredCovered.Size = new System.Drawing.Size(52, 14);
            this.lblInfraredCovered.TabIndex = 17;
            this.lblInfraredCovered.Text = "红外被挡:";
            // 
            // teInfraredCovered
            // 
            this.teInfraredCovered.Location = new System.Drawing.Point(143, 299);
            this.teInfraredCovered.MenuManager = this.barManager;
            this.teInfraredCovered.Name = "teInfraredCovered";
            this.teInfraredCovered.Size = new System.Drawing.Size(289, 20);
            this.teInfraredCovered.TabIndex = 16;
            // 
            // lblCarStop
            // 
            this.lblCarStop.Location = new System.Drawing.Point(24, 227);
            this.lblCarStop.Name = "lblCarStop";
            this.lblCarStop.Size = new System.Drawing.Size(52, 14);
            this.lblCarStop.TabIndex = 15;
            this.lblCarStop.Text = "车未停好:";
            // 
            // teCarStopFail
            // 
            this.teCarStopFail.Location = new System.Drawing.Point(143, 226);
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
            this.teReadCardFail.Location = new System.Drawing.Point(143, 84);
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
            this.teTimeOut.Location = new System.Drawing.Point(143, 187);
            this.teTimeOut.MenuManager = this.barManager;
            this.teTimeOut.Name = "teTimeOut";
            this.teTimeOut.Size = new System.Drawing.Size(289, 20);
            this.teTimeOut.TabIndex = 10;
            // 
            // lblSecondWeight
            // 
            this.lblSecondWeight.Location = new System.Drawing.Point(24, 406);
            this.lblSecondWeight.Name = "lblSecondWeight";
            this.lblSecondWeight.Size = new System.Drawing.Size(100, 14);
            this.lblSecondWeight.TabIndex = 9;
            this.lblSecondWeight.Text = "第二次完成称重时:";
            // 
            // teSecondWeight
            // 
            this.teSecondWeight.Location = new System.Drawing.Point(143, 403);
            this.teSecondWeight.MenuManager = this.barManager;
            this.teSecondWeight.Name = "teSecondWeight";
            this.teSecondWeight.Size = new System.Drawing.Size(289, 20);
            this.teSecondWeight.TabIndex = 8;
            // 
            // lblFirstWeight
            // 
            this.lblFirstWeight.Location = new System.Drawing.Point(24, 372);
            this.lblFirstWeight.Name = "lblFirstWeight";
            this.lblFirstWeight.Size = new System.Drawing.Size(100, 14);
            this.lblFirstWeight.TabIndex = 7;
            this.lblFirstWeight.Text = "第一次完成称重时:";
            // 
            // teFirstWeight
            // 
            this.teFirstWeight.Location = new System.Drawing.Point(143, 369);
            this.teFirstWeight.MenuManager = this.barManager;
            this.teFirstWeight.Name = "teFirstWeight";
            this.teFirstWeight.Size = new System.Drawing.Size(289, 20);
            this.teFirstWeight.TabIndex = 6;
            // 
            // lblWeightUnStable
            // 
            this.lblWeightUnStable.Location = new System.Drawing.Point(24, 268);
            this.lblWeightUnStable.Name = "lblWeightUnStable";
            this.lblWeightUnStable.Size = new System.Drawing.Size(76, 14);
            this.lblWeightUnStable.TabIndex = 5;
            this.lblWeightUnStable.Text = "称重未稳定时:";
            // 
            // teWeightUnStable
            // 
            this.teWeightUnStable.Location = new System.Drawing.Point(143, 265);
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
            this.teReadCardSuccess.Location = new System.Drawing.Point(143, 51);
            this.teReadCardSuccess.MenuManager = this.barManager;
            this.teReadCardSuccess.Name = "teReadCardSuccess";
            this.teReadCardSuccess.Size = new System.Drawing.Size(289, 20);
            this.teReadCardSuccess.TabIndex = 2;
            // 
            // lblOverWeight
            // 
            this.lblOverWeight.Location = new System.Drawing.Point(24, 336);
            this.lblOverWeight.Name = "lblOverWeight";
            this.lblOverWeight.Size = new System.Drawing.Size(64, 14);
            this.lblOverWeight.TabIndex = 1;
            this.lblOverWeight.Text = "超载提示音:";
            // 
            // teOverWeight
            // 
            this.teOverWeight.Location = new System.Drawing.Point(143, 333);
            this.teOverWeight.MenuManager = this.barManager;
            this.teOverWeight.Name = "teOverWeight";
            this.teOverWeight.Size = new System.Drawing.Size(289, 20);
            this.teOverWeight.TabIndex = 0;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(357, 4);
            this.checkEdit1.MenuManager = this.barManager;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "启用";
            this.checkEdit1.Size = new System.Drawing.Size(75, 20);
            this.checkEdit1.TabIndex = 38;
            // 
            // FrmVoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 511);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音播报";
            this.Load += new System.EventHandler(this.FrmVoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
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
        private DevExpress.XtraEditors.SimpleButton btnStartReadCard;
        private DevExpress.XtraEditors.SimpleButton btnUnloadWeight;
        private DevExpress.XtraEditors.SimpleButton btnSecondWeight;
        private DevExpress.XtraEditors.SimpleButton btnFirstWeight;
        private DevExpress.XtraEditors.SimpleButton btnOverWeight;
        private DevExpress.XtraEditors.SimpleButton btnInfraredCovered;
        private DevExpress.XtraEditors.SimpleButton btnWeightUnStable;
        private DevExpress.XtraEditors.SimpleButton btnCarStopFail;
        private DevExpress.XtraEditors.SimpleButton btnTimeOut;
        private DevExpress.XtraEditors.SimpleButton btnStartWeight;
        private DevExpress.XtraEditors.SimpleButton btnCarRecognition;
        private DevExpress.XtraEditors.SimpleButton btnReadCardFail;
        private DevExpress.XtraEditors.SimpleButton btnReadCardSuccess;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}