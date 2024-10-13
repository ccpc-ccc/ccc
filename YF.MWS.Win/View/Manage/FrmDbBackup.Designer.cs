namespace YF.MWS.Win.View.Manage
{
    partial class FrmDbBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbBackup));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtFileDb = new DevExpress.XtraEditors.TextEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.btnBrowser = new DevExpress.XtraEditors.SimpleButton();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
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
            this.btnItemBackup,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemBackup),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemBackup
            // 
            this.btnItemBackup.Caption = "备份";
            this.btnItemBackup.Id = 1;
            this.btnItemBackup.ImageIndex = 0;
            this.btnItemBackup.Name = "btnItemBackup";
            this.btnItemBackup.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemBackup_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(558, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 122);
            this.barDockControlBottom.Size = new System.Drawing.Size(558, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 91);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(558, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 91);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "extend_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "open_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // txtFileDb
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtFileDb, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtFileDb.Location = new System.Drawing.Point(122, 38);
            this.txtFileDb.MenuManager = this.barManager;
            this.txtFileDb.Name = "txtFileDb";
            this.txtFileDb.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtFileDb.Properties.Appearance.Options.UseFont = true;
            this.txtFileDb.Properties.ReadOnly = true;
            this.txtFileDb.Size = new System.Drawing.Size(284, 18);
            this.txtFileDb.TabIndex = 39;
            this.txtFileDb.Tag = "LogoUrl";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.btnBrowser);
            this.plDetail.Controls.Add(this.txtFileDb);
            this.plDetail.Controls.Add(this.lblCarNo);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(558, 91);
            this.plDetail.TabIndex = 8;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowser.Appearance.Options.UseFont = true;
            this.btnBrowser.ImageIndex = 2;
            this.btnBrowser.ImageList = this.imgListSmall;
            this.btnBrowser.Location = new System.Drawing.Point(433, 35);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(62, 23);
            this.btnBrowser.TabIndex = 40;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // lblCarNo
            // 
            this.lblCarNo.Location = new System.Drawing.Point(27, 38);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(76, 14);
            this.lblCarNo.TabIndex = 38;
            this.lblCarNo.Text = "备份文件路径:";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "SQLite数据库|*.db";
            // 
            // FrmDbBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 122);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(574, 161);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(574, 161);
            this.Name = "FrmDbBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库备份";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemBackup;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.SimpleButton btnBrowser;
        private DevExpress.XtraEditors.TextEdit txtFileDb;
        private System.Windows.Forms.SaveFileDialog sfdFile;
    }
}