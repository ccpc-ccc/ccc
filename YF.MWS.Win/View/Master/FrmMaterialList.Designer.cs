namespace YF.MWS.Win.View.Master
{
    partial class FrmMaterialList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barItemSync = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.gcMaterial = new DevExpress.XtraGrid.GridControl();
            this.gvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).BeginInit();
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
            this.btnItemAdd,
            this.btnItemEdit,
            this.btnItemDelete,
            this.btnItemRefresh,
            this.barItemExport,
            this.barItemImport,
            this.barItemSync});
            this.barManager.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSync),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete)});
            this.bar1.Text = "Tools";
            // 
            // btnItemRefresh
            // 
            this.btnItemRefresh.Caption = "刷新";
            this.btnItemRefresh.Id = 3;
            this.btnItemRefresh.ImageOptions.ImageIndex = 3;
            this.btnItemRefresh.Name = "btnItemRefresh";
            this.btnItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRefresh_ItemClick);
            // 
            // barItemSync
            // 
            this.barItemSync.Caption = "同步";
            this.barItemSync.Id = 6;
            this.barItemSync.ImageOptions.ImageIndex = 3;
            this.barItemSync.Name = "barItemSync";
            this.barItemSync.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSync.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSync_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 4;
            this.barItemExport.ImageOptions.ImageIndex = 4;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入";
            this.barItemImport.Id = 5;
            this.barItemImport.ImageOptions.ImageIndex = 5;
            this.barItemImport.Name = "barItemImport";
            this.barItemImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemImport_ItemClick);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加";
            this.btnItemAdd.Id = 0;
            this.btnItemAdd.ImageOptions.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 1;
            this.btnItemEdit.ImageOptions.ImageIndex = 1;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 2;
            this.btnItemDelete.ImageOptions.ImageIndex = 2;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1077, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 655);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1077, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 631);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1077, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 631);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "exportexcel_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "import_16x16.png");
            // 
            // gcMaterial
            // 
            this.gcMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaterial.Location = new System.Drawing.Point(0, 24);
            this.gcMaterial.MainView = this.gvMaterial;
            this.gcMaterial.MenuManager = this.barManager;
            this.gcMaterial.Name = "gcMaterial";
            this.gcMaterial.Size = new System.Drawing.Size(1077, 631);
            this.gcMaterial.TabIndex = 4;
            this.gcMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterial});
            // 
            // gvMaterial
            // 
            this.gvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaterialCode,
            this.colMaterialName,
            this.colSpecName,
            this.colUnitPrice,
            this.colQuantity,
            this.colStateName,
            this.colCreateTime});
            this.gvMaterial.GridControl = this.gcMaterial;
            this.gvMaterial.IndicatorWidth = 40;
            this.gvMaterial.Name = "gvMaterial";
            this.gvMaterial.OptionsFind.AlwaysVisible = true;
            this.gvMaterial.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvMaterial.OptionsView.ShowAutoFilterRow = true;
            this.gvMaterial.OptionsView.ShowGroupPanel = false;
            this.gvMaterial.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMaterial_CustomDrawRowIndicator);
            // 
            // colMaterialCode
            // 
            this.colMaterialCode.Caption = "物资编码";
            this.colMaterialCode.FieldName = "MaterialCode";
            this.colMaterialCode.Name = "colMaterialCode";
            this.colMaterialCode.Visible = true;
            this.colMaterialCode.VisibleIndex = 2;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "物资名称";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.OptionsColumn.AllowEdit = false;
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 0;
            // 
            // colSpecName
            // 
            this.colSpecName.Caption = "规格";
            this.colSpecName.FieldName = "SpecName";
            this.colSpecName.Name = "colSpecName";
            this.colSpecName.OptionsColumn.AllowEdit = false;
            this.colSpecName.Visible = true;
            this.colSpecName.VisibleIndex = 1;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "单价";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 3;
            // 
            // colStateName
            // 
            this.colStateName.Caption = "状态";
            this.colStateName.FieldName = "StateName";
            this.colStateName.Name = "colStateName";
            this.colStateName.Visible = true;
            this.colStateName.VisibleIndex = 5;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.AllowEdit = false;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 6;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "库存数量";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 4;
            // 
            // FrmMaterialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 655);
            this.Controls.Add(this.gcMaterial);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmMaterialList";
            this.Text = "物资列表";
            this.Load += new System.EventHandler(this.FrmMaterialList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefresh;
        private DevExpress.XtraGrid.GridControl gcMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
        private DevExpress.XtraBars.BarButtonItem barItemSync;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStateName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
    }
}