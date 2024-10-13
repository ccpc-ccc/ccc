namespace YF.MWS.Win.View.Order
{
    partial class FrmPlanList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRefreshCache = new DevExpress.XtraBars.BarButtonItem();
            this.barItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.bartemAddVirtualCard = new DevExpress.XtraBars.BarButtonItem();
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcCarPlan = new DevExpress.XtraGrid.GridControl();
            this.gvCarPlan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPlanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehBizName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLimitTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanCarCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinishedCarCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurplusCarCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinishedWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurplusWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucPage = new YF.MWS.Win.Uc.UcPage();
            this.gpSearchCondition = new DevExpress.XtraEditors.GroupControl();
            this.xscRight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gpSearchKey = new DevExpress.XtraEditors.GroupControl();
            this.weMaterial = new YF.MWS.Win.Uc.Weight.WMaterialEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.weWarehBizType = new YF.MWS.Win.Uc.Weight.WComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.wCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.deFilter = new YF.MWS.Win.Uc.DateFilter();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCarPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).BeginInit();
            this.gpSearchCondition.SuspendLayout();
            this.xscRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).BeginInit();
            this.gpSearchKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd, true),
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
            this.barDockControlTop.Size = new System.Drawing.Size(1450, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 766);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1450, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 735);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1450, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 735);
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
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 10;
            this.barItemExport.ImageOptions.ImageIndex = 6;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemRefreshCache
            // 
            this.barItemRefreshCache.Caption = "刷新缓存";
            this.barItemRefreshCache.Id = 11;
            this.barItemRefreshCache.ImageOptions.ImageIndex = 5;
            this.barItemRefreshCache.Name = "barItemRefreshCache";
            this.barItemRefreshCache.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemImport
            // 
            this.barItemImport.Caption = "导入";
            this.barItemImport.Id = 12;
            this.barItemImport.ImageOptions.ImageIndex = 7;
            this.barItemImport.Name = "barItemImport";
            this.barItemImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bartemAddVirtualCard
            // 
            this.bartemAddVirtualCard.Caption = "新增虚拟卡";
            this.bartemAddVirtualCard.Id = 14;
            this.bartemAddVirtualCard.ImageOptions.ImageIndex = 1;
            this.bartemAddVirtualCard.Name = "bartemAddVirtualCard";
            this.bartemAddVirtualCard.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcCarPlan);
            this.gpSearchResult.Controls.Add(this.ucPage);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 31);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(1130, 735);
            this.gpSearchResult.TabIndex = 35;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcCarPlan
            // 
            this.gcCarPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCarPlan.Location = new System.Drawing.Point(2, 21);
            this.gcCarPlan.MainView = this.gvCarPlan;
            this.gcCarPlan.Name = "gcCarPlan";
            this.gcCarPlan.Size = new System.Drawing.Size(1126, 677);
            this.gcCarPlan.TabIndex = 31;
            this.gcCarPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCarPlan});
            // 
            // gvCarPlan
            // 
            this.gvCarPlan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlanNo,
            this.colCustomerName,
            this.colCarNo,
            this.colMaterialName,
            this.colWarehBizName,
            this.colLimitTypeName,
            this.colPlanCarCount,
            this.colFinishedCarCount,
            this.colSurplusCarCount,
            this.colPlanWeight,
            this.colFinishedWeight,
            this.colSurplusWeight,
            this.colStartTime,
            this.colEndTime,
            this.colCreateTime});
            this.gvCarPlan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvCarPlan.GridControl = this.gcCarPlan;
            this.gvCarPlan.IndicatorWidth = 40;
            this.gvCarPlan.Name = "gvCarPlan";
            this.gvCarPlan.NewItemRowText = "点此添加数据";
            this.gvCarPlan.OptionsBehavior.Editable = false;
            this.gvCarPlan.OptionsBehavior.ReadOnly = true;
            this.gvCarPlan.OptionsFind.AlwaysVisible = true;
            this.gvCarPlan.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCarPlan.OptionsSelection.MultiSelect = true;
            this.gvCarPlan.OptionsView.ShowGroupPanel = false;
            // 
            // colPlanNo
            // 
            this.colPlanNo.Caption = "编号";
            this.colPlanNo.FieldName = "PlanNo";
            this.colPlanNo.Name = "colPlanNo";
            this.colPlanNo.Visible = true;
            this.colPlanNo.VisibleIndex = 0;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户单位";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colCarNo
            // 
            this.colCarNo.Caption = "车牌号";
            this.colCarNo.FieldName = "CarNo";
            this.colCarNo.Name = "colCarNo";
            this.colCarNo.Visible = true;
            this.colCarNo.VisibleIndex = 2;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "物资名称";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 3;
            // 
            // colWarehBizName
            // 
            this.colWarehBizName.Caption = "业务类型";
            this.colWarehBizName.FieldName = "WarehBizName";
            this.colWarehBizName.Name = "colWarehBizName";
            this.colWarehBizName.Visible = true;
            this.colWarehBizName.VisibleIndex = 4;
            // 
            // colLimitTypeName
            // 
            this.colLimitTypeName.Caption = "限制类型";
            this.colLimitTypeName.FieldName = "LimitTypeName";
            this.colLimitTypeName.Name = "colLimitTypeName";
            this.colLimitTypeName.Visible = true;
            this.colLimitTypeName.VisibleIndex = 5;
            // 
            // colPlanCarCount
            // 
            this.colPlanCarCount.Caption = "计划车数";
            this.colPlanCarCount.FieldName = "PlanCarCount";
            this.colPlanCarCount.Name = "colPlanCarCount";
            this.colPlanCarCount.Visible = true;
            this.colPlanCarCount.VisibleIndex = 6;
            // 
            // colFinishedCarCount
            // 
            this.colFinishedCarCount.Caption = "完成车次";
            this.colFinishedCarCount.FieldName = "FinishedCarCount";
            this.colFinishedCarCount.Name = "colFinishedCarCount";
            this.colFinishedCarCount.Visible = true;
            this.colFinishedCarCount.VisibleIndex = 7;
            // 
            // colSurplusCarCount
            // 
            this.colSurplusCarCount.Caption = "剩余车次";
            this.colSurplusCarCount.FieldName = "SurplusCarCount";
            this.colSurplusCarCount.Name = "colSurplusCarCount";
            this.colSurplusCarCount.Visible = true;
            this.colSurplusCarCount.VisibleIndex = 8;
            // 
            // colPlanWeight
            // 
            this.colPlanWeight.Caption = "计划吨位";
            this.colPlanWeight.FieldName = "PlanWeight";
            this.colPlanWeight.Name = "colPlanWeight";
            this.colPlanWeight.Visible = true;
            this.colPlanWeight.VisibleIndex = 9;
            // 
            // colFinishedWeight
            // 
            this.colFinishedWeight.Caption = "完成吨位";
            this.colFinishedWeight.FieldName = "FinishedWeight";
            this.colFinishedWeight.Name = "colFinishedWeight";
            this.colFinishedWeight.Visible = true;
            this.colFinishedWeight.VisibleIndex = 10;
            // 
            // colSurplusWeight
            // 
            this.colSurplusWeight.Caption = "剩余吨位";
            this.colSurplusWeight.FieldName = "SurplusWeight";
            this.colSurplusWeight.Name = "colSurplusWeight";
            this.colSurplusWeight.Visible = true;
            this.colSurplusWeight.VisibleIndex = 11;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "开始时间";
            this.colStartTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 12;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "截止时间";
            this.colEndTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 13;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 14;
            // 
            // ucPage
            // 
            this.ucPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPage.Location = new System.Drawing.Point(2, 698);
            this.ucPage.Name = "ucPage";
            qPage1.PageIndex = 0;
            qPage1.PageSize = 25;
            qPage1.TotalRows = 0;
            this.ucPage.Page = qPage1;
            this.ucPage.Size = new System.Drawing.Size(1126, 35);
            this.ucPage.TabIndex = 30;
            // 
            // gpSearchCondition
            // 
            this.gpSearchCondition.Controls.Add(this.xscRight);
            this.gpSearchCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpSearchCondition.Location = new System.Drawing.Point(1130, 31);
            this.gpSearchCondition.Name = "gpSearchCondition";
            this.gpSearchCondition.Size = new System.Drawing.Size(320, 735);
            this.gpSearchCondition.TabIndex = 34;
            this.gpSearchCondition.Text = "查询条件";
            // 
            // xscRight
            // 
            this.xscRight.Controls.Add(this.gpSearchKey);
            this.xscRight.Controls.Add(this.deFilter);
            this.xscRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscRight.Location = new System.Drawing.Point(2, 21);
            this.xscRight.Name = "xscRight";
            this.xscRight.Size = new System.Drawing.Size(316, 712);
            this.xscRight.TabIndex = 89;
            // 
            // gpSearchKey
            // 
            this.gpSearchKey.Controls.Add(this.weMaterial);
            this.gpSearchKey.Controls.Add(this.labelControl6);
            this.gpSearchKey.Controls.Add(this.weWarehBizType);
            this.gpSearchKey.Controls.Add(this.labelControl9);
            this.gpSearchKey.Controls.Add(this.wCustomer);
            this.gpSearchKey.Controls.Add(this.lblCustomer);
            this.gpSearchKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpSearchKey.Location = new System.Drawing.Point(0, 241);
            this.gpSearchKey.Name = "gpSearchKey";
            this.gpSearchKey.Size = new System.Drawing.Size(316, 187);
            this.gpSearchKey.TabIndex = 54;
            this.gpSearchKey.Text = "查询关键词";
            // 
            // weMaterial
            // 
            this.weMaterial.ActionName = null;
            this.weMaterial.AutoCalcNo = 0;
            this.weMaterial.Caption = null;
            this.weMaterial.ControlName = null;
            this.weMaterial.CurrentValue = "";
            this.weMaterial.DecimalDigits = 0;
            this.weMaterial.EditText = "";
            this.weMaterial.EditValue = "";
            this.weMaterial.ErrorTipText = null;
            this.weMaterial.Expression = null;
            this.weMaterial.FieldName = null;
            this.weMaterial.IsRequired = false;
            this.weMaterial.Location = new System.Drawing.Point(88, 79);
            this.weMaterial.MenuManager = this.barManager;
            this.weMaterial.Name = "weMaterial";
            this.weMaterial.ParentLocation = new System.Drawing.Point(0, 0);
            this.weMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weMaterial.Size = new System.Drawing.Size(168, 20);
            this.weMaterial.TabIndex = 141;
            this.weMaterial.WeightVauleChanged = null;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(20, 82);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 140;
            this.labelControl6.Text = "物资名称:";
            // 
            // weWarehBizType
            // 
            this.weWarehBizType.ActionName = null;
            this.weWarehBizType.AutoCalcNo = 0;
            this.weWarehBizType.Caption = null;
            this.weWarehBizType.ControlName = null;
            this.weWarehBizType.CurrentValue = "";
            this.weWarehBizType.DecimalDigits = 0;
            this.weWarehBizType.EditText = "";
            this.weWarehBizType.EditValue = "";
            this.weWarehBizType.ErrorTipText = null;
            this.weWarehBizType.Expression = "";
            this.weWarehBizType.FieldName = "WarehBizType";
            this.weWarehBizType.IsRequired = false;
            this.weWarehBizType.Location = new System.Drawing.Point(88, 42);
            this.weWarehBizType.Name = "weWarehBizType";
            this.weWarehBizType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weWarehBizType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weWarehBizType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.weWarehBizType.Size = new System.Drawing.Size(168, 20);
            this.weWarehBizType.TabIndex = 139;
            this.weWarehBizType.WeightVauleChanged = null;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(20, 46);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 14);
            this.labelControl9.TabIndex = 138;
            this.labelControl9.Text = "业务类型:";
            // 
            // wCustomer
            // 
            this.wCustomer.ActionName = null;
            this.wCustomer.AutoCalcNo = 0;
            this.wCustomer.Caption = null;
            this.wCustomer.ControlName = null;
            this.wCustomer.CurrentValue = "";
            this.wCustomer.DecimalDigits = 0;
            this.wCustomer.EditText = "";
            this.wCustomer.EditValue = "";
            this.wCustomer.ErrorTipText = null;
            this.wCustomer.Expression = null;
            this.wCustomer.FieldName = null;
            this.wCustomer.IsRequired = false;
            this.wCustomer.Location = new System.Drawing.Point(88, 120);
            this.wCustomer.Name = "wCustomer";
            this.wCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.wCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCustomer.Size = new System.Drawing.Size(167, 20);
            this.wCustomer.TabIndex = 137;
            this.wCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.wCustomer.WeightVauleChanged = null;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(20, 123);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(52, 14);
            this.lblCustomer.TabIndex = 136;
            this.lblCustomer.Text = "客户单位:";
            // 
            // deFilter
            // 
            this.deFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.deFilter.DtEnd = new System.DateTime(2017, 1, 1, 23, 28, 5, 135);
            this.deFilter.DtStart = new System.DateTime(2017, 1, 1, 23, 28, 5, 135);
            this.deFilter.EndDate = 0;
            this.deFilter.Location = new System.Drawing.Point(0, 0);
            this.deFilter.Name = "deFilter";
            this.deFilter.Size = new System.Drawing.Size(316, 241);
            this.deFilter.StartDate = 0;
            this.deFilter.TabIndex = 138;
            // 
            // FrmPlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 766);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.gpSearchCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmPlanList";
            this.Text = "计划单";
            this.Load += new System.EventHandler(this.FrmCarPlanList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCarPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).EndInit();
            this.gpSearchCondition.ResumeLayout(false);
            this.xscRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).EndInit();
            this.gpSearchKey.ResumeLayout(false);
            this.gpSearchKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barItemSearch;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarButtonItem barItemRefreshCache;
        private DevExpress.XtraBars.BarButtonItem barItemImport;
        private DevExpress.XtraBars.BarButtonItem bartemAddVirtualCard;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private DevExpress.XtraGrid.GridControl gcCarPlan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCarPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishedWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehBizName;
        private DevExpress.XtraGrid.Columns.GridColumn colLimitTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanCarCount;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private Uc.UcPage ucPage;
        private DevExpress.XtraEditors.GroupControl gpSearchCondition;
        private DevExpress.XtraEditors.XtraScrollableControl xscRight;
        private DevExpress.XtraEditors.GroupControl gpSearchKey;
        private Uc.Weight.WCustomerEdit wCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private Uc.DateFilter deFilter;
        private Uc.Weight.WComboBoxEdit weWarehBizType;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private Uc.Weight.WMaterialEdit weMaterial;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishedCarCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSurplusCarCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSurplusWeight;
    }
}