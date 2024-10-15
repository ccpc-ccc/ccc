namespace YF.MWS.Win.View.Log
{
    partial class FrmMLogList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMLogList));
            YF.MWS.Metadata.Query.QPage qPage1 = new YF.MWS.Metadata.Query.QPage();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcLog = new DevExpress.XtraGrid.GridControl();
            this.gvLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActionTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucPage = new YF.MWS.Win.Uc.UcPage();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gpSearchCondition = new DevExpress.XtraEditors.GroupControl();
            this.xscRight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gpSearchKey = new DevExpress.XtraEditors.GroupControl();
            this.teKey = new DevExpress.XtraEditors.TextEdit();
            this.lblLogDesc = new DevExpress.XtraEditors.LabelControl();
            this.combActionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblActionType = new DevExpress.XtraEditors.LabelControl();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.wLookupUser = new YF.MWS.Win.Uc.Weight.WLookupSearchEdit();
            this.wLookupSearchEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.deFilter = new YF.MWS.Win.Uc.DateFilter();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).BeginInit();
            this.gpSearchCondition.SuspendLayout();
            this.xscRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).BeginInit();
            this.gpSearchKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combActionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "search_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "exportexcel_16x16.png");
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
            this.barItemSearch,
            this.barItemExport});
            this.barManager.MaxItemId = 12;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSearch, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete)});
            this.bar1.Text = "Tools";
            // 
            // barItemSearch
            // 
            this.barItemSearch.Caption = "搜索";
            this.barItemSearch.Id = 10;
            this.barItemSearch.ImageIndex = 1;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "导出";
            this.barItemExport.Id = 11;
            this.barItemExport.ImageIndex = 2;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 2;
            this.btnItemDelete.ImageIndex = 0;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1289, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 715);
            this.barDockControlBottom.Size = new System.Drawing.Size(1289, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 684);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1289, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 684);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "新增";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 3;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 8;
            this.btnItemEdit.ImageIndex = 3;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemRefresh
            // 
            this.barItemRefresh.Caption = "刷新";
            this.barItemRefresh.Id = 9;
            this.barItemRefresh.ImageIndex = 1;
            this.barItemRefresh.Name = "barItemRefresh";
            this.barItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcLog);
            this.gpSearchResult.Controls.Add(this.ucPage);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 31);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(964, 684);
            this.gpSearchResult.TabIndex = 30;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcLog
            // 
            this.gcLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLog.Location = new System.Drawing.Point(2, 22);
            this.gcLog.MainView = this.gvLog;
            this.gcLog.Name = "gcLog";
            this.gcLog.Size = new System.Drawing.Size(960, 634);
            this.gcLog.TabIndex = 27;
            this.gcLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLog});
            // 
            // gvLog
            // 
            this.gvLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActionTypeName,
            this.colRecNo,
            this.colLogDesc,
            this.colFullName,
            this.colLogTime});
            this.gvLog.GridControl = this.gcLog;
            this.gvLog.Name = "gvLog";
            this.gvLog.NewItemRowText = "点此添加数据";
            this.gvLog.OptionsView.ShowGroupPanel = false;
            this.gvLog.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLogDesc, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvLog.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvLog_CustomDrawRowIndicator);
            // 
            // colActionTypeName
            // 
            this.colActionTypeName.Caption = "模块";
            this.colActionTypeName.FieldName = "ActionTypeName";
            this.colActionTypeName.Name = "colActionTypeName";
            this.colActionTypeName.Visible = true;
            this.colActionTypeName.VisibleIndex = 0;
            this.colActionTypeName.Width = 100;
            // 
            // colRecNo
            // 
            this.colRecNo.Caption = "单号";
            this.colRecNo.FieldName = "RecNo";
            this.colRecNo.Name = "colRecNo";
            this.colRecNo.Visible = true;
            this.colRecNo.VisibleIndex = 1;
            this.colRecNo.Width = 120;
            // 
            // colLogDesc
            // 
            this.colLogDesc.Caption = "描述";
            this.colLogDesc.FieldName = "LogDesc";
            this.colLogDesc.Name = "colLogDesc";
            this.colLogDesc.OptionsColumn.AllowEdit = false;
            this.colLogDesc.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colLogDesc.Visible = true;
            this.colLogDesc.VisibleIndex = 2;
            this.colLogDesc.Width = 534;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "用户";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 3;
            this.colFullName.Width = 94;
            // 
            // colLogTime
            // 
            this.colLogTime.Caption = "日志时间";
            this.colLogTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colLogTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.OptionsColumn.AllowEdit = false;
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 4;
            this.colLogTime.Width = 96;
            // 
            // ucPage
            // 
            this.ucPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPage.Location = new System.Drawing.Point(2, 656);
            this.ucPage.Name = "ucPage";
            qPage1.PageIndex = 0;
            qPage1.PageSize = 25;
            qPage1.TotalRows = 0;
            this.ucPage.Page = qPage1;
            this.ucPage.Size = new System.Drawing.Size(960, 26);
            this.ucPage.TabIndex = 12;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(964, 31);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 684);
            this.splitterControl1.TabIndex = 29;
            this.splitterControl1.TabStop = false;
            // 
            // gpSearchCondition
            // 
            this.gpSearchCondition.Controls.Add(this.xscRight);
            this.gpSearchCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpSearchCondition.Location = new System.Drawing.Point(969, 31);
            this.gpSearchCondition.Name = "gpSearchCondition";
            this.gpSearchCondition.Size = new System.Drawing.Size(320, 684);
            this.gpSearchCondition.TabIndex = 28;
            this.gpSearchCondition.Text = "查询条件";
            // 
            // xscRight
            // 
            this.xscRight.Controls.Add(this.gpSearchKey);
            this.xscRight.Controls.Add(this.deFilter);
            this.xscRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscRight.Location = new System.Drawing.Point(2, 22);
            this.xscRight.Name = "xscRight";
            this.xscRight.Size = new System.Drawing.Size(316, 660);
            this.xscRight.TabIndex = 89;
            // 
            // gpSearchKey
            // 
            this.gpSearchKey.Controls.Add(this.teKey);
            this.gpSearchKey.Controls.Add(this.lblLogDesc);
            this.gpSearchKey.Controls.Add(this.combActionType);
            this.gpSearchKey.Controls.Add(this.lblActionType);
            this.gpSearchKey.Controls.Add(this.lblUser);
            this.gpSearchKey.Controls.Add(this.wLookupUser);
            this.gpSearchKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpSearchKey.Location = new System.Drawing.Point(0, 254);
            this.gpSearchKey.Name = "gpSearchKey";
            this.gpSearchKey.Size = new System.Drawing.Size(316, 181);
            this.gpSearchKey.TabIndex = 54;
            this.gpSearchKey.Text = "查询关键词";
            // 
            // teKey
            // 
            this.teKey.Location = new System.Drawing.Point(82, 119);
            this.teKey.MenuManager = this.barManager;
            this.teKey.Name = "teKey";
            this.teKey.Size = new System.Drawing.Size(175, 20);
            this.teKey.TabIndex = 99;
            // 
            // lblLogDesc
            // 
            this.lblLogDesc.Location = new System.Drawing.Point(26, 120);
            this.lblLogDesc.Name = "lblLogDesc";
            this.lblLogDesc.Size = new System.Drawing.Size(40, 14);
            this.lblLogDesc.TabIndex = 98;
            this.lblLogDesc.Text = "关键词:";
            // 
            // combActionType
            // 
            this.combActionType.EditValue = "所有";
            this.combActionType.Location = new System.Drawing.Point(82, 41);
            this.combActionType.MenuManager = this.barManager;
            this.combActionType.Name = "combActionType";
            this.combActionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combActionType.Properties.Items.AddRange(new object[] {
            "所有",
            "磅单",
            "车辆",
            "物资",
            "客户"});
            this.combActionType.Size = new System.Drawing.Size(175, 20);
            this.combActionType.TabIndex = 97;
            // 
            // lblActionType
            // 
            this.lblActionType.Location = new System.Drawing.Point(26, 44);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(28, 14);
            this.lblActionType.TabIndex = 96;
            this.lblActionType.Text = "模块:";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(26, 82);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(28, 14);
            this.lblUser.TabIndex = 95;
            this.lblUser.Text = "用户:";
            // 
            // wLookupUser
            // 
            this.wLookupUser.ActionName = null;
            this.wLookupUser.AutoCalcNo = 0;
            this.wLookupUser.Caption = null;
            this.wLookupUser.ControlName = null;
            this.wLookupUser.CurrentValue = "";
            this.wLookupUser.DecimalDigits = 0;
            this.wLookupUser.EditText = "";
            this.wLookupUser.EditValue = "";
            this.wLookupUser.Expression = null;
            this.wLookupUser.FieldName = null;
            this.wLookupUser.IsRequired = false;
            this.wLookupUser.Location = new System.Drawing.Point(82, 80);
            this.wLookupUser.Name = "wLookupUser";
            this.wLookupUser.ParentLocation = new System.Drawing.Point(0, 0);
            this.wLookupUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.wLookupUser.Properties.NullText = "";
            this.wLookupUser.Properties.View = this.wLookupSearchEdit1View;
            this.wLookupUser.Size = new System.Drawing.Size(175, 20);
            this.wLookupUser.TabIndex = 94;
            this.wLookupUser.WeightVauleChanged = null;
            // 
            // wLookupSearchEdit1View
            // 
            this.wLookupSearchEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wLookupSearchEdit1View.Name = "wLookupSearchEdit1View";
            this.wLookupSearchEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wLookupSearchEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // deFilter
            // 
            this.deFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.deFilter.DtEnd = new System.DateTime(2017, 1, 1, 23, 28, 5, 135);
            this.deFilter.DtStart = new System.DateTime(2017, 1, 1, 23, 28, 5, 135);
            this.deFilter.EndDate = 0;
            this.deFilter.Location = new System.Drawing.Point(0, 0);
            this.deFilter.Name = "deFilter";
            this.deFilter.Size = new System.Drawing.Size(316, 254);
            this.deFilter.StartDate = 0;
            this.deFilter.TabIndex = 138;
            // 
            // FrmMLogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 715);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gpSearchCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmMLogList";
            this.Text = "日志管理";
            this.Load += new System.EventHandler(this.FrmMLogList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).EndInit();
            this.gpSearchCondition.ResumeLayout(false);
            this.xscRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).EndInit();
            this.gpSearchKey.ResumeLayout(false);
            this.gpSearchKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combActionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem barItemRefresh;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private Uc.UcPage ucPage;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gpSearchCondition;
        private DevExpress.XtraEditors.XtraScrollableControl xscRight;
        private DevExpress.XtraEditors.GroupControl gpSearchKey;
        private Uc.DateFilter deFilter;
        private DevExpress.XtraGrid.GridControl gcLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLog;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraEditors.TextEdit teKey;
        private DevExpress.XtraEditors.LabelControl lblLogDesc;
        private DevExpress.XtraEditors.ComboBoxEdit combActionType;
        private DevExpress.XtraEditors.LabelControl lblActionType;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private Uc.Weight.WLookupSearchEdit wLookupUser;
        private DevExpress.XtraGrid.Views.Grid.GridView wLookupSearchEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colActionTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecNo;
        private DevExpress.XtraBars.BarButtonItem barItemSearch;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
    }
}