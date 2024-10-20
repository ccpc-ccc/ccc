namespace YF.MWS.Win.View
{
    partial class FrmViewList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewList));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemModify = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDeleteView = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAddControl = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAddExtendControl = new DevExpress.XtraBars.BarButtonItem();
            this.barItemEditControl = new DevExpress.XtraBars.BarButtonItem();
            this.barItemShow = new DevExpress.XtraBars.BarButtonItem();
            this.barItemHiden = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDeleteControl = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barItemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.barItemCarViewSetting = new DevExpress.XtraBars.BarButtonItem();
            this.gpViewDetail = new DevExpress.XtraEditors.GroupControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.pageStandardControl = new DevExpress.XtraTab.XtraTabPage();
            this.gcViewDetail = new DevExpress.XtraGrid.GridControl();
            this.gvViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShow1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colShow2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColRowIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColColIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoSaveState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpList = new DevExpress.XtraEditors.GroupControl();
            this.gcViewList = new DevExpress.XtraGrid.GridControl();
            this.gvViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colViewName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViewTypeCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStayState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpViewDetail)).BeginInit();
            this.gpViewDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pageStandardControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).BeginInit();
            this.gpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "setup_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "design_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "module_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "upload_16x16.png");
            this.imgListSmall.Images.SetKeyName(9, "show_16x16.png");
            this.imgListSmall.Images.SetKeyName(10, "remove_16x16.png");
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
            this.btnItemModify,
            this.btnItemSetting,
            this.barItemNew,
            this.barItemEditControl,
            this.barItemAddControl,
            this.barItemSetting,
            this.barItemDeleteControl,
            this.barItemDeleteView,
            this.barItemAddExtendControl,
            this.barItemCarViewSetting,
            this.barItemShow,
            this.barItemHiden});
            this.barManager.MaxItemId = 21;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSetting),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemModify),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDeleteView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAddControl, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAddExtendControl),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemEditControl, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemHiden, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDeleteControl, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemNew
            // 
            this.barItemNew.Caption = "新建界面";
            this.barItemNew.Id = 10;
            this.barItemNew.ImageOptions.ImageIndex = 3;
            this.barItemNew.Name = "barItemNew";
            this.barItemNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemNew_ItemClick);
            // 
            // btnItemSetting
            // 
            this.btnItemSetting.Caption = "设为默认界面";
            this.btnItemSetting.Id = 7;
            this.btnItemSetting.ImageOptions.ImageIndex = 1;
            this.btnItemSetting.Name = "btnItemSetting";
            this.btnItemSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSetting_ItemClick);
            // 
            // btnItemModify
            // 
            this.btnItemModify.Caption = "编辑界面";
            this.btnItemModify.Id = 1;
            this.btnItemModify.ImageOptions.ImageIndex = 4;
            this.btnItemModify.Name = "btnItemModify";
            this.btnItemModify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemModify_ItemClick);
            // 
            // barItemDeleteView
            // 
            this.barItemDeleteView.Caption = "删除界面";
            this.barItemDeleteView.Id = 15;
            this.barItemDeleteView.ImageOptions.ImageIndex = 6;
            this.barItemDeleteView.Name = "barItemDeleteView";
            this.barItemDeleteView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDeleteView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDeleteView_ItemClick);
            // 
            // barItemAddControl
            // 
            this.barItemAddControl.Caption = "添加标准控件";
            this.barItemAddControl.Id = 12;
            this.barItemAddControl.ImageOptions.ImageIndex = 5;
            this.barItemAddControl.Name = "barItemAddControl";
            this.barItemAddControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAddControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAddControl_ItemClick);
            // 
            // barItemAddExtendControl
            // 
            this.barItemAddExtendControl.Caption = "数据同步";
            this.barItemAddExtendControl.Id = 16;
            this.barItemAddExtendControl.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemAddExtendControl.ImageOptions.Image")));
            this.barItemAddExtendControl.ImageOptions.ImageIndex = 5;
            this.barItemAddExtendControl.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemAddExtendControl.ImageOptions.LargeImage")));
            this.barItemAddExtendControl.Name = "barItemAddExtendControl";
            this.barItemAddExtendControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAddExtendControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAddExtendControl_ItemClick);
            // 
            // barItemEditControl
            // 
            this.barItemEditControl.Caption = "编辑控件";
            this.barItemEditControl.Id = 11;
            this.barItemEditControl.ImageOptions.ImageIndex = 4;
            this.barItemEditControl.Name = "barItemEditControl";
            this.barItemEditControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemEditControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSetControl_ItemClick);
            // 
            // barItemShow
            // 
            this.barItemShow.Caption = "显示控件";
            this.barItemShow.Id = 19;
            this.barItemShow.ImageOptions.ImageIndex = 3;
            this.barItemShow.Name = "barItemShow";
            this.barItemShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemShow_ItemClick);
            // 
            // barItemHiden
            // 
            this.barItemHiden.Caption = "隐藏控件";
            this.barItemHiden.Id = 20;
            this.barItemHiden.ImageOptions.ImageIndex = 10;
            this.barItemHiden.Name = "barItemHiden";
            this.barItemHiden.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemHiden.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemHiden_ItemClick);
            // 
            // barItemDeleteControl
            // 
            this.barItemDeleteControl.Caption = "删除控件";
            this.barItemDeleteControl.Id = 14;
            this.barItemDeleteControl.ImageOptions.ImageIndex = 6;
            this.barItemDeleteControl.Name = "barItemDeleteControl";
            this.barItemDeleteControl.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDeleteControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDeleteControl_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1334, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 734);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1334, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 710);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1334, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 710);
            // 
            // barItemSetting
            // 
            this.barItemSetting.Caption = "设计基础控件";
            this.barItemSetting.Id = 13;
            this.barItemSetting.ImageOptions.ImageIndex = 2;
            this.barItemSetting.Name = "barItemSetting";
            this.barItemSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSetting_ItemClick);
            // 
            // barItemCarViewSetting
            // 
            this.barItemCarViewSetting.Caption = "IC卡界面设置";
            this.barItemCarViewSetting.Id = 17;
            this.barItemCarViewSetting.ImageOptions.ImageIndex = 7;
            this.barItemCarViewSetting.Name = "barItemCarViewSetting";
            this.barItemCarViewSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemCarViewSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemCarViewSetting_ItemClick);
            // 
            // gpViewDetail
            // 
            this.gpViewDetail.Controls.Add(this.tabControl);
            this.gpViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpViewDetail.Location = new System.Drawing.Point(287, 24);
            this.gpViewDetail.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gpViewDetail.Name = "gpViewDetail";
            this.gpViewDetail.Size = new System.Drawing.Size(1047, 710);
            this.gpViewDetail.TabIndex = 7;
            this.gpViewDetail.Text = "界面控件列表";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(2, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.pageStandardControl;
            this.tabControl.Size = new System.Drawing.Size(1043, 685);
            this.tabControl.TabIndex = 26;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageStandardControl});
            // 
            // pageStandardControl
            // 
            this.pageStandardControl.Controls.Add(this.gcViewDetail);
            this.pageStandardControl.Name = "pageStandardControl";
            this.pageStandardControl.Size = new System.Drawing.Size(1041, 659);
            this.pageStandardControl.Text = "标准控件";
            // 
            // gcViewDetail
            // 
            this.gcViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewDetail.Location = new System.Drawing.Point(0, 0);
            this.gcViewDetail.MainView = this.gvViewDetail;
            this.gcViewDetail.MenuManager = this.barManager;
            this.gcViewDetail.Name = "gcViewDetail";
            this.gcViewDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.gcViewDetail.Size = new System.Drawing.Size(1041, 659);
            this.gcViewDetail.TabIndex = 25;
            this.gcViewDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewDetail});
            // 
            // gvViewDetail
            // 
            this.gvViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControlName,
            this.colFieldName,
            this.colCaption,
            this.colShow1,
            this.colShow2,
            this.ColRowIndex,
            this.ColColIndex,
            this.colStayState,
            this.colAutoSaveState,
            this.colCreateTime});
            this.gvViewDetail.GridControl = this.gcViewDetail;
            this.gvViewDetail.Name = "gvViewDetail";
            this.gvViewDetail.NewItemRowText = "点此添加数据";
            this.gvViewDetail.OptionsView.ShowGroupPanel = false;
            this.gvViewDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvViewDetail_CellValueChanged);
            this.gvViewDetail.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvViewDetail_CustomColumnDisplayText);
            // 
            // colControlName
            // 
            this.colControlName.Caption = "控件名称";
            this.colControlName.FieldName = "ControlName";
            this.colControlName.Name = "colControlName";
            this.colControlName.OptionsColumn.AllowEdit = false;
            this.colControlName.OptionsFilter.AllowAutoFilter = false;
            this.colControlName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colControlName.Visible = true;
            this.colControlName.VisibleIndex = 0;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "属性";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.OptionsFilter.AllowAutoFilter = false;
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 1;
            // 
            // colCaption
            // 
            this.colCaption.Caption = "标签";
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.OptionsFilter.AllowAutoFilter = false;
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 2;
            // 
            // colShow1
            // 
            this.colShow1.Caption = "界面显示";
            this.colShow1.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colShow1.FieldName = "RowState";
            this.colShow1.Name = "colShow1";
            this.colShow1.Visible = true;
            this.colShow1.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.ValueUnchecked = ((short)(3));
            // 
            // colShow2
            // 
            this.colShow2.Caption = "列表显示";
            this.colShow2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colShow2.FieldName = "Show2";
            this.colShow2.Name = "colShow2";
            this.colShow2.Visible = true;
            this.colShow2.VisibleIndex = 5;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "";
            this.repositoryItemCheckEdit1.HotTrackWhenReadOnly = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            this.repositoryItemCheckEdit1.ValueChecked = ((short)(1));
            this.repositoryItemCheckEdit1.ValueUnchecked = ((short)(0));
            // 
            // ColRowIndex
            // 
            this.ColRowIndex.Caption = "行序号";
            this.ColRowIndex.FieldName = "RowIndex";
            this.ColRowIndex.Name = "ColRowIndex";
            this.ColRowIndex.Visible = true;
            this.ColRowIndex.VisibleIndex = 3;
            // 
            // ColColIndex
            // 
            this.ColColIndex.Caption = "列序号";
            this.ColColIndex.FieldName = "ColIndex";
            this.ColColIndex.Name = "ColColIndex";
            this.ColColIndex.Visible = true;
            this.ColColIndex.VisibleIndex = 4;
            // 
            // colAutoSaveState
            // 
            this.colAutoSaveState.Caption = "自动保存";
            this.colAutoSaveState.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colAutoSaveState.FieldName = "AutoSaveState";
            this.colAutoSaveState.Name = "colAutoSaveState";
            this.colAutoSaveState.Visible = true;
            this.colAutoSaveState.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsFilter.AllowAutoFilter = false;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 9;
            // 
            // gpList
            // 
            this.gpList.Controls.Add(this.gcViewList);
            this.gpList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpList.Location = new System.Drawing.Point(0, 24);
            this.gpList.Name = "gpList";
            this.gpList.Size = new System.Drawing.Size(287, 710);
            this.gpList.TabIndex = 6;
            this.gpList.Text = "称重界面列表";
            // 
            // gcViewList
            // 
            this.gcViewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewList.Location = new System.Drawing.Point(2, 23);
            this.gcViewList.MainView = this.gvViewList;
            this.gcViewList.MenuManager = this.barManager;
            this.gcViewList.Name = "gcViewList";
            this.gcViewList.Size = new System.Drawing.Size(283, 685);
            this.gcViewList.TabIndex = 24;
            this.gcViewList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewList});
            // 
            // gvViewList
            // 
            this.gvViewList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colViewName,
            this.colViewTypeCaption});
            this.gvViewList.GridControl = this.gcViewList;
            this.gvViewList.Name = "gvViewList";
            this.gvViewList.NewItemRowText = "点此添加数据";
            this.gvViewList.OptionsView.ShowGroupPanel = false;
            this.gvViewList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvViewList_FocusedRowChanged);
            // 
            // colViewName
            // 
            this.colViewName.Caption = "名称";
            this.colViewName.FieldName = "ExtViewName";
            this.colViewName.Name = "colViewName";
            this.colViewName.OptionsColumn.AllowEdit = false;
            this.colViewName.OptionsFilter.AllowFilter = false;
            this.colViewName.Visible = true;
            this.colViewName.VisibleIndex = 0;
            this.colViewName.Width = 133;
            // 
            // colViewTypeCaption
            // 
            this.colViewTypeCaption.Caption = "类别";
            this.colViewTypeCaption.FieldName = "ViewTypeCaption";
            this.colViewTypeCaption.Name = "colViewTypeCaption";
            this.colViewTypeCaption.OptionsFilter.AllowFilter = false;
            this.colViewTypeCaption.Visible = true;
            this.colViewTypeCaption.VisibleIndex = 1;
            this.colViewTypeCaption.Width = 45;
            // 
            // colStayState
            // 
            this.colStayState.Caption = "信息驻留";
            this.colStayState.ColumnEdit = this.repositoryItemCheckEdit4;
            this.colStayState.FieldName = "StayState";
            this.colStayState.Name = "colStayState";
            this.colStayState.Visible = true;
            this.colStayState.VisibleIndex = 7;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // FrmViewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 734);
            this.Controls.Add(this.gpViewDetail);
            this.Controls.Add(this.gpList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmViewList";
            this.Text = "称重界面管理";
            this.Load += new System.EventHandler(this.FrmViewList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpViewDetail)).EndInit();
            this.gpViewDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pageStandardControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).EndInit();
            this.gpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemModify;
        private DevExpress.XtraBars.BarButtonItem btnItemSetting;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barItemNew;
        private DevExpress.XtraBars.BarButtonItem barItemEditControl;
        private DevExpress.XtraEditors.GroupControl gpViewDetail;
        private DevExpress.XtraEditors.GroupControl gpList;
        private DevExpress.XtraGrid.GridControl gcViewList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewList;
        private DevExpress.XtraGrid.Columns.GridColumn colViewName;
        private DevExpress.XtraBars.BarButtonItem barItemAddControl;
        private DevExpress.XtraBars.BarButtonItem barItemSetting;
        private DevExpress.XtraBars.BarButtonItem barItemDeleteView;
        private DevExpress.XtraBars.BarButtonItem barItemDeleteControl;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage pageStandardControl;
        private DevExpress.XtraGrid.GridControl gcViewDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colControlName;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraBars.BarButtonItem barItemAddExtendControl;
        private DevExpress.XtraBars.BarButtonItem barItemCarViewSetting;
        private DevExpress.XtraGrid.Columns.GridColumn colViewTypeCaption;
        private DevExpress.XtraBars.BarButtonItem barItemShow;
        private DevExpress.XtraBars.BarButtonItem barItemHiden;
        private DevExpress.XtraGrid.Columns.GridColumn colShow1;
        private DevExpress.XtraGrid.Columns.GridColumn colShow2;
        private DevExpress.XtraGrid.Columns.GridColumn ColRowIndex;
        private DevExpress.XtraGrid.Columns.GridColumn ColColIndex;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoSaveState;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colStayState;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
    }
}