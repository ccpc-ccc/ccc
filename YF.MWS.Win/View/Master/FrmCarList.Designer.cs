namespace YF.MWS.Win.View.Master
{
    partial class FrmCarList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSearch = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.gcCar = new DevExpress.XtraGrid.GridControl();
            this.gvCar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLimitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCar)).BeginInit();
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
            this.btnItemDelete,
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemEdit,
            this.barItemExport,
            this.barItemImport,
            this.barItemSearch,
            this.barItemSync});
            this.barManager.MaxItemId = 14;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSync, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete, true)});
            this.bar1.Text = "Tools";
            // 
            // barItemSearch
            // 
            this.barItemSearch.Caption = "搜索";
            this.barItemSearch.Id = 12;
            this.barItemSearch.ImageOptions.ImageIndex = 8;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemSync
            // 
            this.barItemSync.Caption = "同步";
            this.barItemSync.Enabled = false;
            this.barItemSync.Id = 13;
            this.barItemSync.ImageOptions.ImageIndex = 9;
            this.barItemSync.Name = "barItemSync";
            this.barItemSync.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSync.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSync_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 10;
            this.barItemExport.ImageOptions.ImageIndex = 7;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入";
            this.barItemImport.Id = 11;
            this.barItemImport.ImageOptions.ImageIndex = 6;
            this.barItemImport.Name = "barItemImport";
            this.barItemImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemImport_ItemClick);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "新增";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageOptions.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 8;
            this.btnItemEdit.ImageOptions.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 2;
            this.btnItemDelete.ImageOptions.ImageIndex = 3;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1068, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 648);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1068, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1068, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 624);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "cancel_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "import_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "exportexcel_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "search_16x16.png");
            this.imgListSmall.Images.SetKeyName(9, "upload_16x16.png");
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemAddSub
            // 
            this.btnItemAddSub.Caption = "添加子类";
            this.btnItemAddSub.Id = 5;
            this.btnItemAddSub.ImageOptions.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gcCar
            // 
            this.gcCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCar.Location = new System.Drawing.Point(0, 24);
            this.gcCar.MainView = this.gvCar;
            this.gcCar.MenuManager = this.barManager;
            this.gcCar.Name = "gcCar";
            this.gcCar.Size = new System.Drawing.Size(1068, 624);
            this.gcCar.TabIndex = 22;
            this.gcCar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCar});
            // 
            // gvCar
            // 
            this.gvCar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCarNo,
            this.colCarTypeName,
            this.colTare,
            this.colLimitWeight,
            this.colCreateTime});
            this.gvCar.GridControl = this.gcCar;
            this.gvCar.Name = "gvCar";
            this.gvCar.NewItemRowText = "点此添加数据";
            this.gvCar.OptionsFind.AlwaysVisible = true;
            this.gvCar.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCar.OptionsView.ShowGroupPanel = false;
            this.gvCar.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCarNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCarNo
            // 
            this.colCarNo.Caption = "车牌号";
            this.colCarNo.FieldName = "CarNo";
            this.colCarNo.Name = "colCarNo";
            this.colCarNo.OptionsColumn.AllowEdit = false;
            this.colCarNo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCarNo.Visible = true;
            this.colCarNo.VisibleIndex = 0;
            // 
            // colCarTypeName
            // 
            this.colCarTypeName.Caption = "车型";
            this.colCarTypeName.FieldName = "CarTypeName";
            this.colCarTypeName.Name = "colCarTypeName";
            this.colCarTypeName.OptionsColumn.AllowEdit = false;
            this.colCarTypeName.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCarTypeName.Visible = true;
            this.colCarTypeName.VisibleIndex = 3;
            // 
            // colTare
            // 
            this.colTare.Caption = "皮重";
            this.colTare.FieldName = "Tare";
            this.colTare.Name = "colTare";
            this.colTare.Visible = true;
            this.colTare.VisibleIndex = 2;
            // 
            // colLimitWeight
            // 
            this.colLimitWeight.Caption = "限重";
            this.colLimitWeight.FieldName = "LimitWeight";
            this.colLimitWeight.Name = "colLimitWeight";
            this.colLimitWeight.OptionsColumn.AllowEdit = false;
            this.colLimitWeight.Visible = true;
            this.colLimitWeight.VisibleIndex = 1;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.AllowEdit = false;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 4;
            // 
            // FrmCarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 648);
            this.Controls.Add(this.gcCar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmCarList";
            this.Text = "车辆管理";
            this.Load += new System.EventHandler(this.FrmCarList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub; 
        private DevExpress.XtraGrid.GridControl gcCar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCar;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLimitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colCarTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraGrid.Columns.GridColumn colTare;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
        private DevExpress.XtraBars.BarButtonItem barItemSearch;
        private DevExpress.XtraBars.BarButtonItem barItemSync;
    }
}