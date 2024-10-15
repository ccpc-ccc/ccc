namespace YF.MWS.Win.View.Master
{
    partial class FrmMaterialDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialDetail));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.teMaterialName = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.txtMaxWeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMinWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblUnitPrice = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemSave,
            this.btnItemClose});
            this.barManager.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.bar1.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 0;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 1;
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
            this.barDockControlTop.Size = new System.Drawing.Size(397, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 262);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(397, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 238);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(397, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 238);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.teMaterialName);
            this.panelControl1.Controls.Add(this.lblMaterialName);
            this.panelControl1.Controls.Add(this.txtMaxWeight);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMinWeight);
            this.panelControl1.Controls.Add(this.lblUnitPrice);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(397, 238);
            this.panelControl1.TabIndex = 4;
            // 
            // teMaterialName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teMaterialName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teMaterialName.Location = new System.Drawing.Point(106, 24);
            this.teMaterialName.MenuManager = this.barManager;
            this.teMaterialName.Name = "teMaterialName";
            this.teMaterialName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.teMaterialName.Properties.Appearance.Options.UseFont = true;
            this.teMaterialName.Size = new System.Drawing.Size(247, 18);
            this.teMaterialName.TabIndex = 17;
            this.teMaterialName.Tag = "MaterialName";
            this.teMaterialName.EditValueChanged += new System.EventHandler(this.teMaterialName_EditValueChanged);
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblMaterialName.Appearance.Options.UseFont = true;
            this.lblMaterialName.Location = new System.Drawing.Point(40, 27);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(54, 12);
            this.lblMaterialName.TabIndex = 16;
            this.lblMaterialName.Text = "物资名称:";
            // 
            // txtMaxWeight
            // 
            this.txtMaxWeight.Location = new System.Drawing.Point(106, 122);
            this.txtMaxWeight.Name = "txtMaxWeight";
            this.txtMaxWeight.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtMaxWeight.Properties.Appearance.Options.UseFont = true;
            this.txtMaxWeight.Size = new System.Drawing.Size(247, 18);
            this.txtMaxWeight.TabIndex = 15;
            this.txtMaxWeight.Tag = "Quantity";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(40, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 12);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "最高重量:";
            // 
            // txtMinWeight
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtMinWeight, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtMinWeight.Location = new System.Drawing.Point(106, 72);
            this.txtMinWeight.MenuManager = this.barManager;
            this.txtMinWeight.Name = "txtMinWeight";
            this.txtMinWeight.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtMinWeight.Properties.Appearance.Options.UseFont = true;
            this.txtMinWeight.Size = new System.Drawing.Size(247, 18);
            this.txtMinWeight.TabIndex = 15;
            this.txtMinWeight.Tag = "UnitPrice";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblUnitPrice.Appearance.Options.UseFont = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(40, 75);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(54, 12);
            this.lblUnitPrice.TabIndex = 14;
            this.lblUnitPrice.Text = "最低重量:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmMaterialDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmMaterialDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物资详情";
            this.Load += new System.EventHandler(this.FrmMaterialDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit txtMinWeight;
        private DevExpress.XtraEditors.LabelControl lblUnitPrice;
        private DevExpress.XtraEditors.TextEdit teMaterialName;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.TextEdit txtMaxWeight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}