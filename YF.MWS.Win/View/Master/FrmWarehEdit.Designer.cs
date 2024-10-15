namespace YF.MWS.Win.View.Master
{
    partial class FrmWarehEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWarehEdit));
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblWarehCode = new DevExpress.XtraEditors.LabelControl();
            this.lblWarehName = new DevExpress.XtraEditors.LabelControl();
            this.teLocation = new DevExpress.XtraEditors.TextEdit();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.teWarehName = new DevExpress.XtraEditors.TextEdit();
            this.teWarehCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWarehName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWarehCode.Properties)).BeginInit();
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
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(444, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 210);
            this.barDockControlBottom.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 179);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(444, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 179);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.teWarehCode);
            this.panelControl1.Controls.Add(this.teWarehName);
            this.panelControl1.Controls.Add(this.lblWarehCode);
            this.panelControl1.Controls.Add(this.lblWarehName);
            this.panelControl1.Controls.Add(this.teLocation);
            this.panelControl1.Controls.Add(this.lblLocation);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(444, 179);
            this.panelControl1.TabIndex = 7;
            // 
            // lblWarehCode
            // 
            this.lblWarehCode.Location = new System.Drawing.Point(24, 30);
            this.lblWarehCode.Name = "lblWarehCode";
            this.lblWarehCode.Size = new System.Drawing.Size(28, 14);
            this.lblWarehCode.TabIndex = 57;
            this.lblWarehCode.Text = "编码:";
            // 
            // lblWarehName
            // 
            this.lblWarehName.Location = new System.Drawing.Point(24, 70);
            this.lblWarehName.Name = "lblWarehName";
            this.lblWarehName.Size = new System.Drawing.Size(28, 14);
            this.lblWarehName.TabIndex = 55;
            this.lblWarehName.Text = "名称:";
            // 
            // teLocation
            // 
            this.dxErrorProvider.SetIconAlignment(this.teLocation, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teLocation.Location = new System.Drawing.Point(72, 109);
            this.teLocation.MenuManager = this.barManager;
            this.teLocation.Name = "teLocation";
            this.teLocation.Size = new System.Drawing.Size(335, 20);
            this.teLocation.TabIndex = 41;
            this.teLocation.Tag = "Location";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(24, 112);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(28, 14);
            this.lblLocation.TabIndex = 40;
            this.lblLocation.Text = "位置:";
            // 
            // teWarehName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teWarehName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teWarehName.Location = new System.Drawing.Point(72, 67);
            this.teWarehName.MenuManager = this.barManager;
            this.teWarehName.Name = "teWarehName";
            this.teWarehName.Size = new System.Drawing.Size(225, 20);
            this.teWarehName.TabIndex = 58;
            this.teWarehName.Tag = "WarehName";
            // 
            // teWarehCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.teWarehCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teWarehCode.Location = new System.Drawing.Point(72, 27);
            this.teWarehCode.MenuManager = this.barManager;
            this.teWarehCode.Name = "teWarehCode";
            this.teWarehCode.Size = new System.Drawing.Size(225, 20);
            this.teWarehCode.TabIndex = 59;
            this.teWarehCode.Tag = "WarehCode";
            // 
            // FrmWarehEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 210);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWarehEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库编辑";
            this.Load += new System.EventHandler(this.FrmWarehEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWarehName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWarehCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit teWarehCode;
        private DevExpress.XtraEditors.TextEdit teWarehName;
        private DevExpress.XtraEditors.LabelControl lblWarehCode;
        private DevExpress.XtraEditors.LabelControl lblWarehName;
        private DevExpress.XtraEditors.TextEdit teLocation;
        private DevExpress.XtraEditors.LabelControl lblLocation;
    }
}