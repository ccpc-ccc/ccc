namespace YF.MWS.Win.View.Master
{
    partial class FrmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barItemSync = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRefreshPayRecord = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRecovery = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRealDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowStateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinBalanceAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContracter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
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
            this.btnItemEdit,
            this.barItemRefresh,
            this.barItemImport,
            this.barItemExport,
            this.barItemSync,
            this.barItemRefreshPayRecord,
            this.barItemRealDelete,
            this.barItemRecovery});
            this.barManager.MaxItemId = 16;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRefreshPayRecord),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRecovery, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRealDelete)});
            this.bar1.Text = "Tools";
            // 
            // barItemRefresh
            // 
            this.barItemRefresh.Caption = "刷新";
            this.barItemRefresh.Id = 9;
            this.barItemRefresh.ImageOptions.ImageIndex = 1;
            this.barItemRefresh.Name = "barItemRefresh";
            this.barItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRefresh_ItemClick);
            // 
            // barItemSync
            // 
            this.barItemSync.Caption = "同步";
            this.barItemSync.Id = 12;
            this.barItemSync.ImageOptions.ImageIndex = 6;
            this.barItemSync.Name = "barItemSync";
            this.barItemSync.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSync.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSync_ItemClick);
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
            this.btnItemEdit.ImageOptions.ImageIndex = 3;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入";
            this.barItemImport.Id = 10;
            this.barItemImport.ImageOptions.ImageIndex = 4;
            this.barItemImport.Name = "barItemImport";
            this.barItemImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemImport.Tag = "Import";
            this.barItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemImport_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 11;
            this.barItemExport.ImageOptions.ImageIndex = 5;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.Tag = "Export";
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barItemRefreshPayRecord
            // 
            this.barItemRefreshPayRecord.Caption = "刷新客户账单";
            this.barItemRefreshPayRecord.Id = 13;
            this.barItemRefreshPayRecord.ImageOptions.ImageIndex = 1;
            this.barItemRefreshPayRecord.Name = "barItemRefreshPayRecord";
            this.barItemRefreshPayRecord.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRefreshPayRecord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRefreshPayRecord_ItemClick);
            // 
            // barItemRecovery
            // 
            this.barItemRecovery.Caption = "恢复";
            this.barItemRecovery.Id = 15;
            this.barItemRecovery.ImageOptions.ImageIndex = 8;
            this.barItemRecovery.Name = "barItemRecovery";
            this.barItemRecovery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRecovery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRecovery_ItemClick);
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
            // barItemRealDelete
            // 
            this.barItemRealDelete.Caption = "彻底删除";
            this.barItemRealDelete.Id = 14;
            this.barItemRealDelete.ImageOptions.ImageIndex = 7;
            this.barItemRealDelete.Name = "barItemRealDelete";
            this.barItemRealDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRealDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRealDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1418, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 719);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1418, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 695);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1418, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 695);
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
            // gcCustomer
            // 
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(0, 24);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.MenuManager = this.barManager;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(1418, 695);
            this.gcCustomer.TabIndex = 23;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerCode,
            this.colCustomerName,
            this.colCustomerType,
            this.colRowStateName,
            this.colBalanceAmount,
            this.colMinBalanceAmount,
            this.colContracter,
            this.colTel,
            this.colCreateTime});
            this.gvCustomer.GridControl = this.gcCustomer;
            this.gvCustomer.IndicatorWidth = 40;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.NewItemRowText = "点此添加数据";
            this.gvCustomer.OptionsFind.AlwaysVisible = true;
            this.gvCustomer.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCustomer.OptionsView.ShowAutoFilterRow = true;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            this.gvCustomer.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvCustomer_CustomDrawRowIndicator);
            this.gvCustomer.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvCustomer_RowStyle);
            this.gvCustomer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCustomer_FocusedRowChanged);
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Caption = "编号";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 0;
            this.colCustomerCode.Width = 161;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "名称";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            this.colCustomerName.Width = 174;
            // 
            // colCustomerType
            // 
            this.colCustomerType.Caption = "类型";
            this.colCustomerType.FieldName = "CustomerType";
            this.colCustomerType.Name = "colCustomerType";
            this.colCustomerType.OptionsColumn.AllowEdit = false;
            this.colCustomerType.Visible = true;
            this.colCustomerType.VisibleIndex = 2;
            this.colCustomerType.Width = 174;
            // 
            // colRowStateName
            // 
            this.colRowStateName.Caption = "状态";
            this.colRowStateName.FieldName = "RowStateName";
            this.colRowStateName.Name = "colRowStateName";
            this.colRowStateName.Visible = true;
            this.colRowStateName.VisibleIndex = 3;
            this.colRowStateName.Width = 133;
            // 
            // colBalanceAmount
            // 
            this.colBalanceAmount.Caption = "余额";
            this.colBalanceAmount.FieldName = "BalanceAmount";
            this.colBalanceAmount.Name = "colBalanceAmount";
            this.colBalanceAmount.Visible = true;
            this.colBalanceAmount.VisibleIndex = 4;
            this.colBalanceAmount.Width = 120;
            // 
            // colMinBalanceAmount
            // 
            this.colMinBalanceAmount.Caption = "最低余额";
            this.colMinBalanceAmount.FieldName = "MinBalanceAmount";
            this.colMinBalanceAmount.Name = "colMinBalanceAmount";
            this.colMinBalanceAmount.Visible = true;
            this.colMinBalanceAmount.VisibleIndex = 5;
            this.colMinBalanceAmount.Width = 120;
            // 
            // colContracter
            // 
            this.colContracter.Caption = "联络人";
            this.colContracter.FieldName = "Contracter";
            this.colContracter.Name = "colContracter";
            this.colContracter.OptionsColumn.AllowEdit = false;
            this.colContracter.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colContracter.Visible = true;
            this.colContracter.VisibleIndex = 6;
            this.colContracter.Width = 156;
            // 
            // colTel
            // 
            this.colTel.Caption = "联系电话";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 7;
            this.colTel.Width = 169;
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
            this.colCreateTime.VisibleIndex = 8;
            this.colCreateTime.Width = 169;
            // 
            // FrmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 719);
            this.Controls.Add(this.gcCustomer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmCustomerList";
            this.Text = "客户管理";
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
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
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel; 
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerType;
        private DevExpress.XtraGrid.Columns.GridColumn colContracter;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem barItemRefresh;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemSync;
        private DevExpress.XtraBars.BarButtonItem barItemRefreshPayRecord;
        private DevExpress.XtraBars.BarButtonItem barItemRealDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colRowStateName;
        private DevExpress.XtraBars.BarButtonItem barItemRecovery;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colMinBalanceAmount;
    }
}