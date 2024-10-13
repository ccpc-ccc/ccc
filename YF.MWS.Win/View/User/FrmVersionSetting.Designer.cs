namespace YF.MWS.Win.View.User
{
    partial class FrmVersionSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVersionSetting));
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
            this.chkReadCard = new DevExpress.XtraEditors.CheckEdit();
            this.chkCarNoRecognition = new DevExpress.XtraEditors.CheckEdit();
            this.chkAutoWeight = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartVideo = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartOnline = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkStartPad = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartFinance = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartScreen = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCarNoRecognition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartVideo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartOnline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartPad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartFinance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartScreen.Properties)).BeginInit();
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
            this.barManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(378, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 351);
            this.barDockControlBottom.Size = new System.Drawing.Size(378, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 320);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(378, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 320);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // chkReadCard
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkReadCard, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkReadCard.Location = new System.Drawing.Point(68, 86);
            this.chkReadCard.MenuManager = this.barManager;
            this.chkReadCard.Name = "chkReadCard";
            this.chkReadCard.Properties.Caption = "启用读卡器";
            this.chkReadCard.Size = new System.Drawing.Size(93, 19);
            this.chkReadCard.TabIndex = 13;
            // 
            // chkCarNoRecognition
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkCarNoRecognition, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkCarNoRecognition.Location = new System.Drawing.Point(68, 129);
            this.chkCarNoRecognition.MenuManager = this.barManager;
            this.chkCarNoRecognition.Name = "chkCarNoRecognition";
            this.chkCarNoRecognition.Properties.Caption = "启用车牌设别";
            this.chkCarNoRecognition.Size = new System.Drawing.Size(93, 19);
            this.chkCarNoRecognition.TabIndex = 14;
            // 
            // chkAutoWeight
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkAutoWeight, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkAutoWeight.Location = new System.Drawing.Point(68, 212);
            this.chkAutoWeight.MenuManager = this.barManager;
            this.chkAutoWeight.Name = "chkAutoWeight";
            this.chkAutoWeight.Properties.Caption = "启用无人值守";
            this.chkAutoWeight.Size = new System.Drawing.Size(93, 19);
            this.chkAutoWeight.TabIndex = 16;
            // 
            // chkStartVideo
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkStartVideo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkStartVideo.Location = new System.Drawing.Point(68, 46);
            this.chkStartVideo.MenuManager = this.barManager;
            this.chkStartVideo.Name = "chkStartVideo";
            this.chkStartVideo.Properties.Caption = "启用视频";
            this.chkStartVideo.Size = new System.Drawing.Size(87, 19);
            this.chkStartVideo.TabIndex = 17;
            // 
            // chkStartOnline
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkStartOnline, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkStartOnline.Location = new System.Drawing.Point(68, 169);
            this.chkStartOnline.MenuManager = this.barManager;
            this.chkStartOnline.Name = "chkStartOnline";
            this.chkStartOnline.Properties.Caption = "启用网络版";
            this.chkStartOnline.Size = new System.Drawing.Size(122, 19);
            this.chkStartOnline.TabIndex = 18;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkStartScreen);
            this.panelControl1.Controls.Add(this.chkStartPad);
            this.panelControl1.Controls.Add(this.chkStartFinance);
            this.panelControl1.Controls.Add(this.chkStartOnline);
            this.panelControl1.Controls.Add(this.chkStartVideo);
            this.panelControl1.Controls.Add(this.chkAutoWeight);
            this.panelControl1.Controls.Add(this.chkCarNoRecognition);
            this.panelControl1.Controls.Add(this.chkReadCard);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(378, 320);
            this.panelControl1.TabIndex = 7;
            // 
            // chkStartPad
            // 
            this.chkStartPad.Location = new System.Drawing.Point(204, 85);
            this.chkStartPad.Name = "chkStartPad";
            this.chkStartPad.Properties.Caption = "启用触摸屏";
            this.chkStartPad.Size = new System.Drawing.Size(87, 19);
            this.chkStartPad.TabIndex = 30;
            // 
            // chkStartFinance
            // 
            this.chkStartFinance.Location = new System.Drawing.Point(204, 46);
            this.chkStartFinance.Name = "chkStartFinance";
            this.chkStartFinance.Properties.Caption = "启用财务模块";
            this.chkStartFinance.Size = new System.Drawing.Size(107, 19);
            this.chkStartFinance.TabIndex = 29;
            // 
            // chkStartScreen
            // 
            this.chkStartScreen.Location = new System.Drawing.Point(68, 257);
            this.chkStartScreen.Name = "chkStartScreen";
            this.chkStartScreen.Properties.Caption = "启用大屏幕";
            this.chkStartScreen.Size = new System.Drawing.Size(122, 19);
            this.chkStartScreen.TabIndex = 31;
            // 
            // FrmVersionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 351);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmVersionSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本功能设置";
            this.Load += new System.EventHandler(this.FrmVersionSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCarNoRecognition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartVideo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartOnline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkStartPad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartFinance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartScreen.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkReadCard;
        private DevExpress.XtraEditors.CheckEdit chkCarNoRecognition;
        private DevExpress.XtraEditors.CheckEdit chkAutoWeight;
        private DevExpress.XtraEditors.CheckEdit chkStartVideo;
        private DevExpress.XtraEditors.CheckEdit chkStartOnline;
        private DevExpress.XtraEditors.CheckEdit chkStartScreen;
        private DevExpress.XtraEditors.CheckEdit chkStartPad;
        private DevExpress.XtraEditors.CheckEdit chkStartFinance;
    }
}