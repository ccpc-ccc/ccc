namespace YF.MWS.Win.View.Setting
{
    partial class FrmLaunchCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLaunchCfg));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.plMain = new DevExpress.XtraEditors.PanelControl();
            this.gpLaunchCfg = new DevExpress.XtraEditors.GroupControl();
            this.lblAppRunVersion = new DevExpress.XtraEditors.LabelControl();
            this.rgAppRunVersion = new DevExpress.XtraEditors.RadioGroup();
            this.chkRunMoreApps = new DevExpress.XtraEditors.CheckEdit();
            this.lblFixedTimes = new DevExpress.XtraEditors.LabelControl();
            this.teFixedTimeThird = new DevExpress.XtraEditors.TimeEdit();
            this.teFixedTimeSecond = new DevExpress.XtraEditors.TimeEdit();
            this.teFixedTimeFirst = new DevExpress.XtraEditors.TimeEdit();
            this.lblHours = new DevExpress.XtraEditors.LabelControl();
            this.teHours = new DevExpress.XtraEditors.TextEdit();
            this.lblReStartTimeSpan = new DevExpress.XtraEditors.LabelControl();
            this.rgReStartTimeSpan = new DevExpress.XtraEditors.RadioGroup();
            this.chkStartAutoMaintain = new DevExpress.XtraEditors.CheckEdit();
            this.lblDefaultPage = new DevExpress.XtraEditors.LabelControl();
            this.rgDefaultPage = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpLaunchCfg)).BeginInit();
            this.gpLaunchCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgAppRunVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRunMoreApps.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeThird.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeSecond.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeFirst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgReStartTimeSpan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartAutoMaintain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDefaultPage.Properties)).BeginInit();
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
            this.btnItemClose,
            this.barItemRegister});
            this.barManager.MaxItemId = 12;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRegister, true),
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
            // barItemRegister
            // 
            this.barItemRegister.Caption = "注册";
            this.barItemRegister.Id = 11;
            this.barItemRegister.ImageOptions.ImageIndex = 3;
            this.barItemRegister.Name = "barItemRegister";
            this.barItemRegister.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRegister_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(613, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 392);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(613, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 368);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(613, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 368);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "edit_16x16.png");
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.gpLaunchCfg);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 24);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(613, 368);
            this.plMain.TabIndex = 5;
            // 
            // gpLaunchCfg
            // 
            this.gpLaunchCfg.Controls.Add(this.lblAppRunVersion);
            this.gpLaunchCfg.Controls.Add(this.rgAppRunVersion);
            this.gpLaunchCfg.Controls.Add(this.chkRunMoreApps);
            this.gpLaunchCfg.Controls.Add(this.lblFixedTimes);
            this.gpLaunchCfg.Controls.Add(this.teFixedTimeThird);
            this.gpLaunchCfg.Controls.Add(this.teFixedTimeSecond);
            this.gpLaunchCfg.Controls.Add(this.teFixedTimeFirst);
            this.gpLaunchCfg.Controls.Add(this.lblHours);
            this.gpLaunchCfg.Controls.Add(this.teHours);
            this.gpLaunchCfg.Controls.Add(this.lblReStartTimeSpan);
            this.gpLaunchCfg.Controls.Add(this.rgReStartTimeSpan);
            this.gpLaunchCfg.Controls.Add(this.chkStartAutoMaintain);
            this.gpLaunchCfg.Controls.Add(this.lblDefaultPage);
            this.gpLaunchCfg.Controls.Add(this.rgDefaultPage);
            this.gpLaunchCfg.Location = new System.Drawing.Point(12, 19);
            this.gpLaunchCfg.Name = "gpLaunchCfg";
            this.gpLaunchCfg.Size = new System.Drawing.Size(580, 316);
            this.gpLaunchCfg.TabIndex = 61;
            this.gpLaunchCfg.Text = "程序运行设置";
            // 
            // lblAppRunVersion
            // 
            this.lblAppRunVersion.Location = new System.Drawing.Point(26, 40);
            this.lblAppRunVersion.Name = "lblAppRunVersion";
            this.lblAppRunVersion.Size = new System.Drawing.Size(100, 14);
            this.lblAppRunVersion.TabIndex = 96;
            this.lblAppRunVersion.Text = "程序运行版本设置:";
            // 
            // rgAppRunVersion
            // 
            this.rgAppRunVersion.EditValue = "Corp";
            this.rgAppRunVersion.Location = new System.Drawing.Point(163, 38);
            this.rgAppRunVersion.Name = "rgAppRunVersion";
            this.rgAppRunVersion.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgAppRunVersion.Properties.Appearance.Options.UseBackColor = true;
            this.rgAppRunVersion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgAppRunVersion.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Corp", "公司专版"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Distributor", "经销商版本")});
            this.rgAppRunVersion.Size = new System.Drawing.Size(187, 27);
            this.rgAppRunVersion.TabIndex = 95;
            // 
            // chkRunMoreApps
            // 
            this.chkRunMoreApps.Location = new System.Drawing.Point(161, 117);
            this.chkRunMoreApps.Name = "chkRunMoreApps";
            this.chkRunMoreApps.Properties.Caption = "是否运行多个程序";
            this.chkRunMoreApps.Size = new System.Drawing.Size(126, 20);
            this.chkRunMoreApps.TabIndex = 94;
            this.chkRunMoreApps.Tag = "Active";
            // 
            // lblFixedTimes
            // 
            this.lblFixedTimes.Location = new System.Drawing.Point(22, 275);
            this.lblFixedTimes.Name = "lblFixedTimes";
            this.lblFixedTimes.Size = new System.Drawing.Size(124, 14);
            this.lblFixedTimes.TabIndex = 93;
            this.lblFixedTimes.Text = "每天固定时间自动启动:";
            // 
            // teFixedTimeThird
            // 
            this.teFixedTimeThird.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teFixedTimeThird.Location = new System.Drawing.Point(346, 272);
            this.teFixedTimeThird.Name = "teFixedTimeThird";
            this.teFixedTimeThird.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teFixedTimeThird.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.teFixedTimeThird.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeThird.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teFixedTimeThird.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeThird.Properties.Mask.EditMask = "HH:mm:ss";
            this.teFixedTimeThird.Size = new System.Drawing.Size(81, 20);
            this.teFixedTimeThird.TabIndex = 92;
            // 
            // teFixedTimeSecond
            // 
            this.teFixedTimeSecond.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teFixedTimeSecond.Location = new System.Drawing.Point(256, 272);
            this.teFixedTimeSecond.Name = "teFixedTimeSecond";
            this.teFixedTimeSecond.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teFixedTimeSecond.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.teFixedTimeSecond.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeSecond.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.teFixedTimeSecond.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeSecond.Properties.Mask.EditMask = "HH:mm:ss";
            this.teFixedTimeSecond.Size = new System.Drawing.Size(77, 20);
            this.teFixedTimeSecond.TabIndex = 91;
            // 
            // teFixedTimeFirst
            // 
            this.teFixedTimeFirst.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teFixedTimeFirst.Location = new System.Drawing.Point(161, 272);
            this.teFixedTimeFirst.Name = "teFixedTimeFirst";
            this.teFixedTimeFirst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teFixedTimeFirst.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.teFixedTimeFirst.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeFirst.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.teFixedTimeFirst.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teFixedTimeFirst.Properties.Mask.EditMask = "HH:mm:ss";
            this.teFixedTimeFirst.Size = new System.Drawing.Size(81, 20);
            this.teFixedTimeFirst.TabIndex = 90;
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(22, 236);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(124, 14);
            this.lblHours.TabIndex = 44;
            this.lblHours.Text = "每隔多少小时自动启动:";
            // 
            // teHours
            // 
            this.teHours.Location = new System.Drawing.Point(161, 233);
            this.teHours.Name = "teHours";
            this.teHours.Size = new System.Drawing.Size(50, 20);
            this.teHours.TabIndex = 45;
            this.teHours.Tag = "ServerUrl";
            // 
            // lblReStartTimeSpan
            // 
            this.lblReStartTimeSpan.Location = new System.Drawing.Point(22, 197);
            this.lblReStartTimeSpan.Name = "lblReStartTimeSpan";
            this.lblReStartTimeSpan.Size = new System.Drawing.Size(100, 14);
            this.lblReStartTimeSpan.TabIndex = 43;
            this.lblReStartTimeSpan.Text = "启动时间间隔类型:";
            // 
            // rgReStartTimeSpan
            // 
            this.rgReStartTimeSpan.EditValue = "Fixed";
            this.rgReStartTimeSpan.Location = new System.Drawing.Point(161, 193);
            this.rgReStartTimeSpan.Name = "rgReStartTimeSpan";
            this.rgReStartTimeSpan.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgReStartTimeSpan.Properties.Appearance.Options.UseBackColor = true;
            this.rgReStartTimeSpan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.rgReStartTimeSpan.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Periodicity", "周期性"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Fixed", "固定时间")});
            this.rgReStartTimeSpan.Size = new System.Drawing.Size(187, 27);
            this.rgReStartTimeSpan.TabIndex = 42;
            // 
            // chkStartAutoMaintain
            // 
            this.chkStartAutoMaintain.Location = new System.Drawing.Point(161, 153);
            this.chkStartAutoMaintain.Name = "chkStartAutoMaintain";
            this.chkStartAutoMaintain.Properties.Caption = "是否自动维护";
            this.chkStartAutoMaintain.Size = new System.Drawing.Size(126, 20);
            this.chkStartAutoMaintain.TabIndex = 41;
            this.chkStartAutoMaintain.Tag = "Active";
            // 
            // lblDefaultPage
            // 
            this.lblDefaultPage.Location = new System.Drawing.Point(25, 79);
            this.lblDefaultPage.Name = "lblDefaultPage";
            this.lblDefaultPage.Size = new System.Drawing.Size(100, 14);
            this.lblDefaultPage.TabIndex = 26;
            this.lblDefaultPage.Text = "程序默认加载界面:";
            // 
            // rgDefaultPage
            // 
            this.rgDefaultPage.EditValue = "Corp";
            this.rgDefaultPage.Location = new System.Drawing.Point(162, 77);
            this.rgDefaultPage.Name = "rgDefaultPage";
            this.rgDefaultPage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgDefaultPage.Properties.Appearance.Options.UseBackColor = true;
            this.rgDefaultPage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgDefaultPage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Corp", "公司简介"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Weight", "新建磅单")});
            this.rgDefaultPage.Size = new System.Drawing.Size(187, 27);
            this.rgDefaultPage.TabIndex = 25;
            // 
            // FrmLaunchCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 392);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmLaunchCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统运行设置";
            this.Load += new System.EventHandler(this.FrmLaunchCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpLaunchCfg)).EndInit();
            this.gpLaunchCfg.ResumeLayout(false);
            this.gpLaunchCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgAppRunVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRunMoreApps.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeThird.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeSecond.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFixedTimeFirst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgReStartTimeSpan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartAutoMaintain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDefaultPage.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl gpLaunchCfg;
        private DevExpress.XtraEditors.LabelControl lblFixedTimes;
        private DevExpress.XtraEditors.TimeEdit teFixedTimeThird;
        private DevExpress.XtraEditors.TimeEdit teFixedTimeSecond;
        private DevExpress.XtraEditors.TimeEdit teFixedTimeFirst;
        private DevExpress.XtraEditors.LabelControl lblHours;
        private DevExpress.XtraEditors.TextEdit teHours;
        private DevExpress.XtraEditors.LabelControl lblReStartTimeSpan;
        private DevExpress.XtraEditors.RadioGroup rgReStartTimeSpan;
        private DevExpress.XtraEditors.CheckEdit chkStartAutoMaintain;
        private DevExpress.XtraEditors.LabelControl lblDefaultPage;
        private DevExpress.XtraEditors.RadioGroup rgDefaultPage;
        private DevExpress.XtraEditors.CheckEdit chkRunMoreApps;
        private DevExpress.XtraEditors.LabelControl lblAppRunVersion;
        private DevExpress.XtraEditors.RadioGroup rgAppRunVersion;
        private DevExpress.XtraBars.BarButtonItem barItemRegister;
    }
}