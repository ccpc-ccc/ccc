namespace YF.MWS.Win.View.Master
{
    partial class FrmPlanCardList
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
            YF.MWS.Metadata.Query.QPage qPage1 = new YF.MWS.Metadata.Query.QPage();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanCardList));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRefreshCache = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bartemAddVirtualCard = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcPlanCard = new DevExpress.XtraGrid.GridControl();
            this.gvPlanCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCardId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehBizTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiverName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucPage = new YF.MWS.Win.Uc.UcPage();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gpSearchCondition = new DevExpress.XtraEditors.GroupControl();
            this.xscRight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.lblDept = new DevExpress.XtraEditors.LabelControl();
            this.weDept = new YF.MWS.Win.Uc.Weight.WLookupSearchEdit();
            this.wLookupSearchEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.weCarLookup = new YF.MWS.Win.Uc.Weight.WCarLookup();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            this.weDeliver = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lblDeliver = new DevExpress.XtraEditors.LabelControl();
            this.weReceiver = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lblReceiver = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).BeginInit();
            this.gpSearchCondition.SuspendLayout();
            this.xscRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weCarLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weDeliver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weReceiver.Properties)).BeginInit();
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
            this.btnItemCancel,
            this.btnItemAddSub,
            this.btnItemEdit,
            this.barItemDelete,
            this.barItemExport,
            this.barItemRefreshCache,
            this.barItemImport,
            this.barItemSearch,
            this.bartemAddVirtualCard});
            this.barManager.MaxItemId = 15;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemRefreshCache),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bartemAddVirtualCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete, true)});
            this.bar1.Text = "Tools";
            // 
            // barItemSearch
            // 
            this.barItemSearch.Caption = "搜索";
            this.barItemSearch.Id = 13;
            this.barItemSearch.ImageOptions.ImageIndex = 8;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemRefreshCache
            // 
            this.barItemRefreshCache.Caption = "刷新缓存";
            this.barItemRefreshCache.Id = 11;
            this.barItemRefreshCache.ImageOptions.ImageIndex = 5;
            this.barItemRefreshCache.Name = "barItemRefreshCache";
            this.barItemRefreshCache.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemRefreshCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemRefreshCache_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 10;
            this.barItemExport.ImageOptions.ImageIndex = 6;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入";
            this.barItemImport.Id = 12;
            this.barItemImport.ImageOptions.ImageIndex = 7;
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
            // bartemAddVirtualCard
            // 
            this.bartemAddVirtualCard.Caption = "新增虚拟卡";
            this.bartemAddVirtualCard.Id = 14;
            this.bartemAddVirtualCard.ImageOptions.ImageIndex = 1;
            this.bartemAddVirtualCard.Name = "bartemAddVirtualCard";
            this.bartemAddVirtualCard.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bartemAddVirtualCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bartemAddVirtualCard_ItemClick);
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
            // barItemDelete
            // 
            this.barItemDelete.Caption = "删除";
            this.barItemDelete.Id = 9;
            this.barItemDelete.ImageOptions.ImageIndex = 3;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1349, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 722);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1349, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 698);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1349, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 698);
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
            this.imgListSmall.Images.SetKeyName(6, "exportexcel_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "import_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "search_16x16.png");
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
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcPlanCard);
            this.gpSearchResult.Controls.Add(this.ucPage);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 24);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(1019, 698);
            this.gpSearchResult.TabIndex = 30;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcPlanCard
            // 
            this.gcPlanCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPlanCard.Location = new System.Drawing.Point(2, 23);
            this.gcPlanCard.MainView = this.gvPlanCard;
            this.gcPlanCard.Name = "gcPlanCard";
            this.gcPlanCard.Size = new System.Drawing.Size(1015, 647);
            this.gcPlanCard.TabIndex = 13;
            this.gcPlanCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlanCard});
            // 
            // gvPlanCard
            // 
            this.gvPlanCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCardId,
            this.colCardNo,
            this.colWarehBizTypeName,
            this.colCarNo,
            this.colMaterialName,
            this.colDeliveryName,
            this.colReceiverName});
            this.gvPlanCard.GridControl = this.gcPlanCard;
            this.gvPlanCard.Name = "gvPlanCard";
            this.gvPlanCard.OptionsBehavior.Editable = false;
            this.gvPlanCard.OptionsBehavior.ReadOnly = true;
            this.gvPlanCard.OptionsPrint.AutoWidth = false;
            this.gvPlanCard.OptionsView.ShowFooter = true;
            this.gvPlanCard.OptionsView.ShowGroupPanel = false;
            // 
            // colCardId
            // 
            this.colCardId.Caption = "序列号";
            this.colCardId.FieldName = "CardId";
            this.colCardId.Name = "colCardId";
            this.colCardId.Visible = true;
            this.colCardId.VisibleIndex = 0;
            this.colCardId.Width = 111;
            // 
            // colCardNo
            // 
            this.colCardNo.Caption = "卡号";
            this.colCardNo.FieldName = "CardNo";
            this.colCardNo.Name = "colCardNo";
            this.colCardNo.Visible = true;
            this.colCardNo.VisibleIndex = 1;
            this.colCardNo.Width = 120;
            // 
            // colWarehBizTypeName
            // 
            this.colWarehBizTypeName.Caption = "业务类型";
            this.colWarehBizTypeName.FieldName = "WarehBizTypeName";
            this.colWarehBizTypeName.Name = "colWarehBizTypeName";
            this.colWarehBizTypeName.Visible = true;
            this.colWarehBizTypeName.VisibleIndex = 2;
            this.colWarehBizTypeName.Width = 120;
            // 
            // colCarNo
            // 
            this.colCarNo.Caption = "车牌号";
            this.colCarNo.FieldName = "CarNo";
            this.colCarNo.Name = "colCarNo";
            this.colCarNo.Visible = true;
            this.colCarNo.VisibleIndex = 3;
            this.colCarNo.Width = 100;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "物资";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 4;
            this.colMaterialName.Width = 100;
            // 
            // colDeliveryName
            // 
            this.colDeliveryName.Caption = "发货单位";
            this.colDeliveryName.FieldName = "DeliveryName";
            this.colDeliveryName.Name = "colDeliveryName";
            this.colDeliveryName.Visible = true;
            this.colDeliveryName.VisibleIndex = 5;
            this.colDeliveryName.Width = 115;
            // 
            // colReceiverName
            // 
            this.colReceiverName.Caption = "收货单位";
            this.colReceiverName.FieldName = "ReceiverName";
            this.colReceiverName.Name = "colReceiverName";
            this.colReceiverName.Visible = true;
            this.colReceiverName.VisibleIndex = 6;
            this.colReceiverName.Width = 186;
            // 
            // ucPage
            // 
            this.ucPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPage.Location = new System.Drawing.Point(2, 670);
            this.ucPage.Name = "ucPage";
            qPage1.PageIndex = 0;
            qPage1.PageSize = 25;
            qPage1.TotalRows = 0;
            this.ucPage.Page = qPage1;
            this.ucPage.Size = new System.Drawing.Size(1015, 26);
            this.ucPage.TabIndex = 12;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(1019, 24);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(10, 698);
            this.splitterControl1.TabIndex = 29;
            this.splitterControl1.TabStop = false;
            // 
            // gpSearchCondition
            // 
            this.gpSearchCondition.Controls.Add(this.xscRight);
            this.gpSearchCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpSearchCondition.Location = new System.Drawing.Point(1029, 24);
            this.gpSearchCondition.Name = "gpSearchCondition";
            this.gpSearchCondition.Size = new System.Drawing.Size(320, 698);
            this.gpSearchCondition.TabIndex = 28;
            this.gpSearchCondition.Text = "查询条件";
            // 
            // xscRight
            // 
            this.xscRight.Controls.Add(this.lblDept);
            this.xscRight.Controls.Add(this.weDept);
            this.xscRight.Controls.Add(this.weCarLookup);
            this.xscRight.Controls.Add(this.lblCarNo);
            this.xscRight.Controls.Add(this.weDeliver);
            this.xscRight.Controls.Add(this.lblDeliver);
            this.xscRight.Controls.Add(this.weReceiver);
            this.xscRight.Controls.Add(this.lblReceiver);
            this.xscRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscRight.Location = new System.Drawing.Point(2, 23);
            this.xscRight.Name = "xscRight";
            this.xscRight.Size = new System.Drawing.Size(316, 673);
            this.xscRight.TabIndex = 89;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(31, 23);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(52, 14);
            this.lblDept.TabIndex = 143;
            this.lblDept.Text = "二级部门:";
            // 
            // weDept
            // 
            this.weDept.ActionName = null;
            this.weDept.AutoCalcNo = 0;
            this.weDept.Caption = null;
            this.weDept.ControlName = null;
            this.weDept.CurrentValue = "";
            this.weDept.DecimalDigits = 0;
            this.weDept.EditText = "";
            this.weDept.EditValue = "";
            this.weDept.ErrorTipText = null;
            this.weDept.Expression = null;
            this.weDept.FieldName = "DeptId";
            this.weDept.IsRequired = false;
            this.weDept.Location = new System.Drawing.Point(111, 20);
            this.weDept.Name = "weDept";
            this.weDept.ParentLocation = new System.Drawing.Point(0, 0);
            this.weDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weDept.Properties.NullText = "";
            this.weDept.Properties.PopupView = this.wLookupSearchEdit1View;
            this.weDept.Size = new System.Drawing.Size(167, 20);
            this.weDept.StartAutoSave = false;
            this.weDept.StartStay = false;
            this.weDept.TabIndex = 142;
            this.weDept.WeightVauleChanged = null;
            // 
            // wLookupSearchEdit1View
            // 
            this.wLookupSearchEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wLookupSearchEdit1View.Name = "wLookupSearchEdit1View";
            this.wLookupSearchEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wLookupSearchEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // weCarLookup
            // 
            this.weCarLookup.ActionName = null;
            this.weCarLookup.AutoCalcNo = 0;
            this.weCarLookup.Caption = null;
            this.weCarLookup.ControlName = null;
            this.weCarLookup.CurrentValue = "";
            this.weCarLookup.DecimalDigits = 0;
            this.weCarLookup.EditText = "";
            this.weCarLookup.EditValue = "";
            this.weCarLookup.ErrorTipText = null;
            this.weCarLookup.Expression = null;
            this.weCarLookup.FieldName = null;
            this.weCarLookup.IsRequired = false;
            this.weCarLookup.Location = new System.Drawing.Point(111, 59);
            this.weCarLookup.MenuManager = this.barManager;
            this.weCarLookup.Name = "weCarLookup";
            this.weCarLookup.ParentLocation = new System.Drawing.Point(0, 0);
            this.weCarLookup.Properties.AutoComplete = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.weCarLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "窗口选择车牌", null, null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "手动触发车牌识别", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.weCarLookup.Size = new System.Drawing.Size(167, 24);
            this.weCarLookup.StartAutoSave = false;
            this.weCarLookup.StartStay = false;
            this.weCarLookup.TabIndex = 141;
            this.weCarLookup.WeightVauleChanged = null;
            // 
            // lblCarNo
            // 
            this.lblCarNo.Location = new System.Drawing.Point(31, 64);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(40, 14);
            this.lblCarNo.TabIndex = 140;
            this.lblCarNo.Text = "车牌号:";
            // 
            // weDeliver
            // 
            this.weDeliver.ActionName = null;
            this.weDeliver.AutoCalcNo = 0;
            this.weDeliver.Caption = null;
            this.weDeliver.ControlName = null;
            this.weDeliver.CurrentValue = "";
            this.weDeliver.DecimalDigits = 0;
            this.weDeliver.EditText = "";
            this.weDeliver.EditValue = "";
            this.weDeliver.ErrorTipText = null;
            this.weDeliver.Expression = null;
            this.weDeliver.FieldName = null;
            this.weDeliver.IsRequired = false;
            this.weDeliver.Location = new System.Drawing.Point(111, 145);
            this.weDeliver.MenuManager = this.barManager;
            this.weDeliver.Name = "weDeliver";
            this.weDeliver.ParentLocation = new System.Drawing.Point(0, 0);
            this.weDeliver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weDeliver.Size = new System.Drawing.Size(167, 20);
            this.weDeliver.StartAutoSave = false;
            this.weDeliver.StartStay = false;
            this.weDeliver.TabIndex = 139;
            this.weDeliver.Type = YF.MWS.BaseMetadata.CustomerType.Delivery;
            this.weDeliver.WeightVauleChanged = null;
            // 
            // lblDeliver
            // 
            this.lblDeliver.Location = new System.Drawing.Point(31, 145);
            this.lblDeliver.Name = "lblDeliver";
            this.lblDeliver.Size = new System.Drawing.Size(52, 14);
            this.lblDeliver.TabIndex = 138;
            this.lblDeliver.Text = "发货单位:";
            // 
            // weReceiver
            // 
            this.weReceiver.ActionName = null;
            this.weReceiver.AutoCalcNo = 0;
            this.weReceiver.Caption = null;
            this.weReceiver.ControlName = null;
            this.weReceiver.CurrentValue = "";
            this.weReceiver.DecimalDigits = 0;
            this.weReceiver.EditText = "";
            this.weReceiver.EditValue = "";
            this.weReceiver.ErrorTipText = null;
            this.weReceiver.Expression = null;
            this.weReceiver.FieldName = null;
            this.weReceiver.IsRequired = false;
            this.weReceiver.Location = new System.Drawing.Point(111, 101);
            this.weReceiver.MenuManager = this.barManager;
            this.weReceiver.Name = "weReceiver";
            this.weReceiver.ParentLocation = new System.Drawing.Point(0, 0);
            this.weReceiver.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weReceiver.Size = new System.Drawing.Size(167, 20);
            this.weReceiver.StartAutoSave = false;
            this.weReceiver.StartStay = false;
            this.weReceiver.TabIndex = 137;
            this.weReceiver.Type = YF.MWS.BaseMetadata.CustomerType.Receiver;
            this.weReceiver.WeightVauleChanged = null;
            // 
            // lblReceiver
            // 
            this.lblReceiver.Location = new System.Drawing.Point(31, 101);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(52, 14);
            this.lblReceiver.TabIndex = 136;
            this.lblReceiver.Text = "收货单位:";
            // 
            // FrmPlanCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 722);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gpSearchCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmPlanCardList";
            this.Text = "IC卡管理";
            this.Load += new System.EventHandler(this.FrmCardList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).EndInit();
            this.gpSearchCondition.ResumeLayout(false);
            this.xscRight.ResumeLayout(false);
            this.xscRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weCarLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weDeliver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weReceiver.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit; 
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemRefreshCache;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
        private DevExpress.XtraBars.BarButtonItem barItemSearch;
        private DevExpress.XtraBars.BarButtonItem bartemAddVirtualCard;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private DevExpress.XtraGrid.GridControl gcPlanCard;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlanCard;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiverName;
        private Uc.UcPage ucPage;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gpSearchCondition;
        private DevExpress.XtraEditors.XtraScrollableControl xscRight;
        private Uc.Weight.WCarLookup weCarLookup;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private Uc.Weight.WCustomerEdit weDeliver;
        private DevExpress.XtraEditors.LabelControl lblDeliver;
        private Uc.Weight.WCustomerEdit weReceiver;
        private DevExpress.XtraEditors.LabelControl lblReceiver;
        private DevExpress.XtraEditors.LabelControl lblDept;
        private Uc.Weight.WLookupSearchEdit weDept;
        private DevExpress.XtraGrid.Views.Grid.GridView wLookupSearchEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehBizTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
    }
}