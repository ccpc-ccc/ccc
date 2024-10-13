namespace YF.MWS.Win.View.Customer
{
    partial class FrmCustomerSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerSimple));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barItemSync = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.tabCustomer = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageCustomer = new DevExpress.XtraTab.XtraTabPage();
            this.ucCustomer = new YF.MWS.Win.Uc.UcCustomer();
            this.tabPageDelivery = new DevExpress.XtraTab.XtraTabPage();
            this.ucDeliver = new YF.MWS.Win.Uc.UcCustomer();
            this.tabPageReceiver = new DevExpress.XtraTab.XtraTabPage();
            this.ucReceiver = new YF.MWS.Win.Uc.UcCustomer();
            this.tabPageSupplier = new DevExpress.XtraTab.XtraTabPage();
            this.ucSupplier = new YF.MWS.Win.Uc.UcCustomer();
            this.tabPageTransfer = new DevExpress.XtraTab.XtraTabPage();
            this.ucTransfer = new YF.MWS.Win.Uc.UcCustomer();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomer)).BeginInit();
            this.tabCustomer.SuspendLayout();
            this.tabPageCustomer.SuspendLayout();
            this.tabPageDelivery.SuspendLayout();
            this.tabPageReceiver.SuspendLayout();
            this.tabPageSupplier.SuspendLayout();
            this.tabPageTransfer.SuspendLayout();
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
            this.btnItemCancel,
            this.btnItemEdit,
            this.barItemRefresh,
            this.barItemSync,
            this.barItemDelete});
            this.barManager.MaxItemId = 17;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSync),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete, true)});
            this.bar1.Text = "Tools";
            // 
            // barItemRefresh
            // 
            this.barItemRefresh.Caption = "刷新";
            this.barItemRefresh.Id = 9;
            this.barItemRefresh.ImageIndex = 1;
            this.barItemRefresh.Name = "barItemRefresh";
            this.barItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemSync
            // 
            this.barItemSync.Caption = "同步";
            this.barItemSync.Id = 12;
            this.barItemSync.ImageIndex = 6;
            this.barItemSync.Name = "barItemSync";
            this.barItemSync.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 4;
            this.btnItemSave.ImageIndex = 4;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 8;
            this.btnItemEdit.ImageIndex = 3;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1057, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 695);
            this.barDockControlBottom.Size = new System.Drawing.Size(1057, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 664);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1057, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 664);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "import_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "exportexcel_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "upload_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "clear_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "redo_16x16.png");
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomer.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabCustomer.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabCustomer.Location = new System.Drawing.Point(0, 31);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.SelectedTabPage = this.tabPageCustomer;
            this.tabCustomer.Size = new System.Drawing.Size(1057, 664);
            this.tabCustomer.TabIndex = 4;
            this.tabCustomer.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageCustomer,
            this.tabPageDelivery,
            this.tabPageReceiver,
            this.tabPageSupplier,
            this.tabPageTransfer});
            // 
            // tabPageCustomer
            // 
            this.tabPageCustomer.Controls.Add(this.ucCustomer);
            this.tabPageCustomer.Name = "tabPageCustomer";
            this.tabPageCustomer.Size = new System.Drawing.Size(989, 658);
            this.tabPageCustomer.Text = "客户单位";
            // 
            // ucCustomer
            // 
            this.ucCustomer.CustomerType = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.ucCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCustomer.Location = new System.Drawing.Point(0, 0);
            this.ucCustomer.Name = "ucCustomer";
            this.ucCustomer.Size = new System.Drawing.Size(989, 658);
            this.ucCustomer.TabIndex = 0;
            // 
            // tabPageDelivery
            // 
            this.tabPageDelivery.Controls.Add(this.ucDeliver);
            this.tabPageDelivery.Name = "tabPageDelivery";
            this.tabPageDelivery.Size = new System.Drawing.Size(989, 658);
            this.tabPageDelivery.Text = "发货单位";
            // 
            // ucDeliver
            // 
            this.ucDeliver.CustomerType = YF.MWS.BaseMetadata.CustomerType.Delivery;
            this.ucDeliver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDeliver.Location = new System.Drawing.Point(0, 0);
            this.ucDeliver.Name = "ucDeliver";
            this.ucDeliver.Size = new System.Drawing.Size(989, 658);
            this.ucDeliver.TabIndex = 1;
            // 
            // tabPageReceiver
            // 
            this.tabPageReceiver.Controls.Add(this.ucReceiver);
            this.tabPageReceiver.Name = "tabPageReceiver";
            this.tabPageReceiver.Size = new System.Drawing.Size(989, 658);
            this.tabPageReceiver.Text = "收货单位";
            // 
            // ucReceiver
            // 
            this.ucReceiver.CustomerType = YF.MWS.BaseMetadata.CustomerType.Receiver;
            this.ucReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReceiver.Location = new System.Drawing.Point(0, 0);
            this.ucReceiver.Name = "ucReceiver";
            this.ucReceiver.Size = new System.Drawing.Size(989, 658);
            this.ucReceiver.TabIndex = 1;
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.Controls.Add(this.ucSupplier);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Size = new System.Drawing.Size(989, 658);
            this.tabPageSupplier.Text = "供货单位";
            // 
            // ucSupplier
            // 
            this.ucSupplier.CustomerType = YF.MWS.BaseMetadata.CustomerType.Supplier;
            this.ucSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSupplier.Location = new System.Drawing.Point(0, 0);
            this.ucSupplier.Name = "ucSupplier";
            this.ucSupplier.Size = new System.Drawing.Size(989, 658);
            this.ucSupplier.TabIndex = 1;
            // 
            // tabPageTransfer
            // 
            this.tabPageTransfer.Controls.Add(this.ucTransfer);
            this.tabPageTransfer.Name = "tabPageTransfer";
            this.tabPageTransfer.Size = new System.Drawing.Size(989, 658);
            this.tabPageTransfer.Text = "承运单位";
            // 
            // ucTransfer
            // 
            this.ucTransfer.CustomerType = YF.MWS.BaseMetadata.CustomerType.Transfer;
            this.ucTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTransfer.Location = new System.Drawing.Point(0, 0);
            this.ucTransfer.Name = "ucTransfer";
            this.ucTransfer.Size = new System.Drawing.Size(989, 658);
            this.ucTransfer.TabIndex = 1;
            // 
            // barItemDelete
            // 
            this.barItemDelete.Caption = "删除";
            this.barItemDelete.Id = 16;
            this.barItemDelete.ImageIndex = 2;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
            // 
            // FrmCustomerSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 695);
            this.Controls.Add(this.tabCustomer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmCustomerSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位信息快速设置";
            this.Load += new System.EventHandler(this.FrmCustomerSimple_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomer)).EndInit();
            this.tabCustomer.ResumeLayout(false);
            this.tabPageCustomer.ResumeLayout(false);
            this.tabPageDelivery.ResumeLayout(false);
            this.tabPageReceiver.ResumeLayout(false);
            this.tabPageSupplier.ResumeLayout(false);
            this.tabPageTransfer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barItemRefresh;
        private DevExpress.XtraBars.BarButtonItem barItemSync;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraTab.XtraTabControl tabCustomer;
        private DevExpress.XtraTab.XtraTabPage tabPageCustomer;
        private Uc.UcCustomer ucCustomer;
        private DevExpress.XtraTab.XtraTabPage tabPageDelivery;
        private Uc.UcCustomer ucDeliver;
        private DevExpress.XtraTab.XtraTabPage tabPageReceiver;
        private Uc.UcCustomer ucReceiver;
        private DevExpress.XtraTab.XtraTabPage tabPageSupplier;
        private Uc.UcCustomer ucSupplier;
        private DevExpress.XtraTab.XtraTabPage tabPageTransfer;
        private Uc.UcCustomer ucTransfer;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
    }
}