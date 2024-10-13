namespace YF.MWS.Win.View.Manage
{
    partial class FrmDbPurge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbPurge));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemInitDb = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPurge = new DevExpress.XtraBars.BarButtonItem();
            this.barItemResetRegister = new DevExpress.XtraBars.BarButtonItem();
            this.barItemCompress = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teStoreYear = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblYear = new DevExpress.XtraEditors.LabelControl();
            this.tackBarYear = new DevExpress.XtraEditors.TrackBarControl();
            this.lblStoreYear = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStoreYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarYear.Properties)).BeginInit();
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
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barItemPurge,
            this.btnItemClose,
            this.barItemCompress,
            this.barItemInitDb,
            this.barItemResetRegister});
            this.barManager.MaxItemId = 13;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemInitDb),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPurge, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemResetRegister),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemCompress),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // barItemInitDb
            // 
            this.barItemInitDb.Caption = "初始化数据库";
            this.barItemInitDb.Id = 11;
            this.barItemInitDb.ImageOptions.ImageUri.Uri = "icon%20builder/actions_database;Size16x16";
            this.barItemInitDb.Name = "barItemInitDb";
            this.barItemInitDb.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemInitDb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemInitDb_ItemClick);
            // 
            // barItemPurge
            // 
            this.barItemPurge.Caption = "清除业务数据";
            this.barItemPurge.Id = 1;
            this.barItemPurge.ImageOptions.ImageIndex = 0;
            this.barItemPurge.ImageOptions.ImageUri.Uri = "dashboards/deletequery;Size16x16";
            this.barItemPurge.Name = "barItemPurge";
            this.barItemPurge.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPurge.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemPurge_ItemClick);
            // 
            // barItemResetRegister
            // 
            this.barItemResetRegister.Caption = "清空客户端注册信息";
            this.barItemResetRegister.Id = 12;
            this.barItemResetRegister.ImageOptions.ImageIndex = 2;
            this.barItemResetRegister.ImageOptions.ImageUri.Uri = "outlook%20inspired/productquictopsalesperson;Size16x16";
            this.barItemResetRegister.Name = "barItemResetRegister";
            this.barItemResetRegister.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemResetRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemResetRegister_ItemClick);
            // 
            // barItemCompress
            // 
            this.barItemCompress.Caption = "压缩数据库";
            this.barItemCompress.Id = 10;
            this.barItemCompress.ImageOptions.ImageIndex = 2;
            this.barItemCompress.ImageOptions.ImageUri.Uri = "outlook%20inspired/shipmentreceived;Size16x16";
            this.barItemCompress.Name = "barItemCompress";
            this.barItemCompress.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemCompress.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemCompress_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.ImageOptions.ImageUri.Uri = "Cancel;Size16x16";
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
            this.barDockControlTop.Size = new System.Drawing.Size(558, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 160);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(558, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 136);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(558, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 136);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teStoreYear
            // 
            this.teStoreYear.EditValue = "0";
            this.teStoreYear.Enabled = false;
            this.dxErrorProvider.SetIconAlignment(this.teStoreYear, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teStoreYear.Location = new System.Drawing.Point(122, 38);
            this.teStoreYear.MenuManager = this.barManager;
            this.teStoreYear.Name = "teStoreYear";
            this.teStoreYear.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teStoreYear.Properties.Appearance.Options.UseFont = true;
            this.teStoreYear.Size = new System.Drawing.Size(63, 18);
            this.teStoreYear.TabIndex = 39;
            this.teStoreYear.Tag = "";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.lblYear);
            this.plDetail.Controls.Add(this.tackBarYear);
            this.plDetail.Controls.Add(this.teStoreYear);
            this.plDetail.Controls.Add(this.lblStoreYear);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 24);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(558, 136);
            this.plDetail.TabIndex = 9;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(192, 39);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(12, 14);
            this.lblYear.TabIndex = 41;
            this.lblYear.Text = "年";
            // 
            // tackBarYear
            // 
            this.tackBarYear.EditValue = null;
            this.tackBarYear.Location = new System.Drawing.Point(119, 62);
            this.tackBarYear.MenuManager = this.barManager;
            this.tackBarYear.Name = "tackBarYear";
            this.tackBarYear.Size = new System.Drawing.Size(274, 45);
            this.tackBarYear.TabIndex = 40;
            this.tackBarYear.EditValueChanged += new System.EventHandler(this.tackBarYear_EditValueChanged);
            // 
            // lblStoreYear
            // 
            this.lblStoreYear.Location = new System.Drawing.Point(14, 38);
            this.lblStoreYear.Name = "lblStoreYear";
            this.lblStoreYear.Size = new System.Drawing.Size(100, 14);
            this.lblStoreYear.TabIndex = 38;
            this.lblStoreYear.Text = "业务数据保留年限:";
            // 
            // FrmDbPurge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 160);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDbPurge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库清理";
            this.Load += new System.EventHandler(this.FrmDbPurge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStoreYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemPurge;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.TrackBarControl tackBarYear;
        private DevExpress.XtraEditors.TextEdit teStoreYear;
        private DevExpress.XtraEditors.LabelControl lblStoreYear;
        private DevExpress.XtraEditors.LabelControl lblYear;
        private DevExpress.XtraBars.BarButtonItem barItemCompress;
        private DevExpress.XtraBars.BarButtonItem barItemInitDb;
        private DevExpress.XtraBars.BarButtonItem barItemResetRegister;
    }
}