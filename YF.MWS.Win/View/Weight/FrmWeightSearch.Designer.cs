namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeightSearch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightSearch));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barItemExportWithGv = new DevExpress.XtraBars.BarButtonItem();
            this.gpSearchCondition = new DevExpress.XtraEditors.GroupControl();
            this.xscRight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.cmbDevice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            this.ofdFileImport = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).BeginInit();
            this.gpSearchCondition.SuspendLayout();
            this.xscRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.barItemExport,
            this.barItemQuery,
            this.barItemAdd,
            this.barItemExportWithGv});
            this.barManager.MaxItemId = 31;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemQuery, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemExport, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemQuery
            // 
            this.barItemQuery.Caption = "搜索";
            this.barItemQuery.Id = 20;
            this.barItemQuery.ImageOptions.ImageIndex = 18;
            this.barItemQuery.Name = "barItemQuery";
            this.barItemQuery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemQuery_ItemClick);
            // 
            // barItemExport
            // 
            this.barItemExport.Caption = "标准Excel导出";
            this.barItemExport.Id = 12;
            this.barItemExport.ImageOptions.ImageIndex = 7;
            this.barItemExport.Name = "barItemExport";
            this.barItemExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemExport.Tag = "Export";
            this.barItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExport_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1642, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 791);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1642, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 767);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1642, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 767);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "preview_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "print_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "invalid.png");
            this.imgListSmall.Images.SetKeyName(5, "video_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "image_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "exportexcel_16x16.png");
            this.imgListSmall.Images.SetKeyName(8, "find_16x16.png");
            this.imgListSmall.Images.SetKeyName(9, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(10, "extend_16x16.png");
            this.imgListSmall.Images.SetKeyName(11, "redo_16x16.png");
            this.imgListSmall.Images.SetKeyName(12, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(13, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(14, "weight_16x16.png");
            this.imgListSmall.Images.SetKeyName(15, "import_16x16.png");
            this.imgListSmall.Images.SetKeyName(16, "export_16x16.png");
            this.imgListSmall.Images.SetKeyName(17, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(18, "search_16x16.png");
            // 
            // barItemAdd
            // 
            this.barItemAdd.Caption = "补录";
            this.barItemAdd.Id = 26;
            this.barItemAdd.ImageOptions.ImageIndex = 17;
            this.barItemAdd.Name = "barItemAdd";
            this.barItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAdd.Tag = "Add";
            this.barItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAdd_ItemClick);
            // 
            // barItemExportWithGv
            // 
            this.barItemExportWithGv.Caption = "磅单格式导出";
            this.barItemExportWithGv.Id = 30;
            this.barItemExportWithGv.ImageOptions.ImageIndex = 7;
            this.barItemExportWithGv.Name = "barItemExportWithGv";
            this.barItemExportWithGv.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            toolTipTitleItem1.Text = "磅单格式导出";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "完全按照当前磅单的格式导出Excel，导出的数据不支持再次导入，如果要导入请用标准Excel导出功能。";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barItemExportWithGv.SuperTip = superToolTip1;
            this.barItemExportWithGv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemExportWithGv_ItemClick);
            // 
            // gpSearchCondition
            // 
            this.gpSearchCondition.Controls.Add(this.xscRight);
            this.gpSearchCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpSearchCondition.Location = new System.Drawing.Point(1293, 24);
            this.gpSearchCondition.Name = "gpSearchCondition";
            this.gpSearchCondition.Size = new System.Drawing.Size(349, 767);
            this.gpSearchCondition.TabIndex = 4;
            this.gpSearchCondition.Text = "查询条件";
            // 
            // xscRight
            // 
            this.xscRight.Controls.Add(this.cmbDevice);
            this.xscRight.Controls.Add(this.labelControl3);
            this.xscRight.Controls.Add(this.txtCar);
            this.xscRight.Controls.Add(this.labelControl2);
            this.xscRight.Controls.Add(this.labelControl1);
            this.xscRight.Controls.Add(this.teEndDate);
            this.xscRight.Controls.Add(this.lblRange);
            this.xscRight.Controls.Add(this.teStartDate);
            this.xscRight.Controls.Add(this.btnSearch);
            this.xscRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscRight.Location = new System.Drawing.Point(2, 23);
            this.xscRight.Name = "xscRight";
            this.xscRight.Size = new System.Drawing.Size(345, 742);
            this.xscRight.TabIndex = 89;
            // 
            // cmbDevice
            // 
            this.cmbDevice.Location = new System.Drawing.Point(76, 162);
            this.cmbDevice.MenuManager = this.barManager;
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDevice.Size = new System.Drawing.Size(147, 20);
            this.cmbDevice.TabIndex = 97;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 162);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 95;
            this.labelControl3.Text = "称重线：";
            // 
            // txtCar
            // 
            this.txtCar.Location = new System.Drawing.Point(76, 104);
            this.txtCar.MenuManager = this.barManager;
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(147, 20);
            this.txtCar.TabIndex = 96;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 95;
            this.labelControl2.Text = "货物名称：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 95;
            this.labelControl1.Text = "完成时间：";
            // 
            // teEndDate
            // 
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(76, 61);
            this.teEndDate.Name = "teEndDate";
            this.teEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.teEndDate.Size = new System.Drawing.Size(147, 20);
            this.teEndDate.TabIndex = 94;
            // 
            // lblRange
            // 
            this.lblRange.Location = new System.Drawing.Point(229, 38);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(9, 14);
            this.lblRange.TabIndex = 93;
            this.lblRange.Text = "~";
            // 
            // teStartDate
            // 
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(76, 35);
            this.teStartDate.Name = "teStartDate";
            this.teStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.teStartDate.Size = new System.Drawing.Size(147, 20);
            this.teStartDate.TabIndex = 92;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.ImageIndex = 18;
            this.btnSearch.ImageOptions.ImageList = this.imgListSmall;
            this.btnSearch.Location = new System.Drawing.Point(33, 371);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 56;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(1283, 24);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(10, 767);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcWeight);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 24);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(1283, 767);
            this.gpSearchResult.TabIndex = 6;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(2, 23);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.gcWeight.Size = new System.Drawing.Size(1279, 742);
            this.gcWeight.TabIndex = 14;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColMaterial,
            this.ColDevice,
            this.ColWeight,
            this.ColCreateTime});
            this.gvWeight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.IndicatorWidth = 45;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsSelection.MultiSelect = true;
            this.gvWeight.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            this.gvWeight.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvWeight_CustomDrawRowIndicator);
            this.gvWeight.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvWeight_CustomColumnDisplayText_1);
            // 
            // ColMaterial
            // 
            this.ColMaterial.Caption = "产品名称";
            this.ColMaterial.FieldName = "MaterialName";
            this.ColMaterial.Name = "ColMaterial";
            this.ColMaterial.Visible = true;
            this.ColMaterial.VisibleIndex = 0;
            this.ColMaterial.Width = 308;
            // 
            // ColDevice
            // 
            this.ColDevice.Caption = "拉线";
            this.ColDevice.FieldName = "CompanyId";
            this.ColDevice.Name = "ColDevice";
            this.ColDevice.Visible = true;
            this.ColDevice.VisibleIndex = 1;
            this.ColDevice.Width = 308;
            // 
            // ColWeight
            // 
            this.ColWeight.Caption = "重量";
            this.ColWeight.FieldName = "SuttleWeight";
            this.ColWeight.Name = "ColWeight";
            this.ColWeight.Visible = true;
            this.ColWeight.VisibleIndex = 2;
            this.ColWeight.Width = 308;
            // 
            // ColCreateTime
            // 
            this.ColCreateTime.Caption = "称重时间";
            this.ColCreateTime.FieldName = "CreateTime";
            this.ColCreateTime.Name = "ColCreateTime";
            this.ColCreateTime.Visible = true;
            this.ColCreateTime.VisibleIndex = 3;
            this.ColCreateTime.Width = 300;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // FrmWeightSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 791);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gpSearchCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmWeightSearch";
            this.Text = "历史磅单搜索";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmWeightSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).EndInit();
            this.gpSearchCondition.ResumeLayout(false);
            this.xscRight.ResumeLayout(false);
            this.xscRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem barItemExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gpSearchCondition;
        private DevExpress.XtraEditors.XtraScrollableControl xscRight;
        private DevExpress.XtraBars.BarButtonItem barItemQuery;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
        private System.Windows.Forms.OpenFileDialog ofdFileImport;
        private DevExpress.XtraBars.BarButtonItem barItemAdd;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraBars.BarButtonItem barItemExportWithGv;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDevice;
        private DevExpress.XtraGrid.Columns.GridColumn ColMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn ColDevice;
        private DevExpress.XtraGrid.Columns.GridColumn ColWeight;
        private DevExpress.XtraGrid.Columns.GridColumn ColCreateTime;
    }
}