namespace YF.MWS.Win.View.Master
{
    partial class FrmWeightRepTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightRepTemplate));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barItemModify = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDesign = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barItemTempReportSetting = new DevExpress.XtraBars.BarButtonItem();
            this.gpList = new DevExpress.XtraEditors.GroupControl();
            this.gcReportList = new DevExpress.XtraGrid.GridControl();
            this.gvReportList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTemplateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportTypeCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcView = new DevExpress.XtraEditors.GroupControl();
            this.pcReport = new DevExpress.XtraPrinting.Control.PrintControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).BeginInit();
            this.gpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            this.gcView.SuspendLayout();
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
            this.btnItemDesign,
            this.btnItemSetting,
            this.barItemTempReportSetting,
            this.barItemModify,
            this.barItemAdd,
            this.barItemDelete});
            this.barManager.MaxItemId = 14;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemModify),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDesign),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSetting, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemAdd
            // 
            this.barItemAdd.Caption = "新建单据";
            this.barItemAdd.Id = 12;
            this.barItemAdd.ImageIndex = 4;
            this.barItemAdd.Name = "barItemAdd";
            this.barItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAdd_ItemClick);
            // 
            // barItemModify
            // 
            this.barItemModify.Caption = "单据设置";
            this.barItemModify.Id = 11;
            this.barItemModify.ImageIndex = 3;
            this.barItemModify.Name = "barItemModify";
            this.barItemModify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemModify_ItemClick);
            // 
            // btnItemDesign
            // 
            this.btnItemDesign.Caption = "设计单据";
            this.btnItemDesign.Id = 1;
            this.btnItemDesign.ImageIndex = 2;
            this.btnItemDesign.Name = "btnItemDesign";
            this.btnItemDesign.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDesign_ItemClick);
            // 
            // btnItemSetting
            // 
            this.btnItemSetting.Caption = "设为默认单据";
            this.btnItemSetting.Id = 7;
            this.btnItemSetting.ImageIndex = 1;
            this.btnItemSetting.Name = "btnItemSetting";
            this.btnItemSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSetting_ItemClick);
            // 
            // barItemDelete
            // 
            this.barItemDelete.Caption = "删除";
            this.barItemDelete.Id = 13;
            this.barItemDelete.ImageIndex = 5;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1202, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 721);
            this.barDockControlBottom.Size = new System.Drawing.Size(1202, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 690);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1202, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 690);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "setup_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "design_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "delete_16x16.png");
            // 
            // barItemTempReportSetting
            // 
            this.barItemTempReportSetting.Caption = "设为默认临时磅单";
            this.barItemTempReportSetting.Id = 10;
            this.barItemTempReportSetting.ImageIndex = 1;
            this.barItemTempReportSetting.Name = "barItemTempReportSetting";
            this.barItemTempReportSetting.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemTempReportSetting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemTempReportSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemTempReportSetting_ItemClick);
            // 
            // gpList
            // 
            this.gpList.Controls.Add(this.gcReportList);
            this.gpList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpList.Location = new System.Drawing.Point(0, 31);
            this.gpList.Name = "gpList";
            this.gpList.Size = new System.Drawing.Size(287, 690);
            this.gpList.TabIndex = 4;
            this.gpList.Text = "磅单报表模板";
            // 
            // gcReportList
            // 
            this.gcReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReportList.Location = new System.Drawing.Point(2, 22);
            this.gcReportList.MainView = this.gvReportList;
            this.gcReportList.MenuManager = this.barManager;
            this.gcReportList.Name = "gcReportList";
            this.gcReportList.Size = new System.Drawing.Size(283, 666);
            this.gcReportList.TabIndex = 24;
            this.gcReportList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReportList});
            // 
            // gvReportList
            // 
            this.gvReportList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTemplateName,
            this.colReportTypeCaption});
            this.gvReportList.GridControl = this.gcReportList;
            this.gvReportList.Name = "gvReportList";
            this.gvReportList.NewItemRowText = "点此添加数据";
            this.gvReportList.OptionsView.ShowGroupPanel = false;
            this.gvReportList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTemplateName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvReportList.DoubleClick += new System.EventHandler(this.gvReportList_DoubleClick);
            // 
            // colTemplateName
            // 
            this.colTemplateName.Caption = "名称";
            this.colTemplateName.FieldName = "TemplateAliasName";
            this.colTemplateName.Name = "colTemplateName";
            this.colTemplateName.OptionsColumn.AllowEdit = false;
            this.colTemplateName.OptionsColumn.ReadOnly = true;
            this.colTemplateName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colTemplateName.Visible = true;
            this.colTemplateName.VisibleIndex = 0;
            this.colTemplateName.Width = 150;
            // 
            // colReportTypeCaption
            // 
            this.colReportTypeCaption.Caption = "类型";
            this.colReportTypeCaption.FieldName = "ReportTypeCaption";
            this.colReportTypeCaption.Name = "colReportTypeCaption";
            this.colReportTypeCaption.OptionsColumn.AllowEdit = false;
            this.colReportTypeCaption.OptionsColumn.ReadOnly = true;
            this.colReportTypeCaption.Visible = true;
            this.colReportTypeCaption.VisibleIndex = 1;
            this.colReportTypeCaption.Width = 50;
            // 
            // gcView
            // 
            this.gcView.Controls.Add(this.pcReport);
            this.gcView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcView.Location = new System.Drawing.Point(287, 31);
            this.gcView.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gcView.Name = "gcView";
            this.gcView.Size = new System.Drawing.Size(915, 690);
            this.gcView.TabIndex = 5;
            this.gcView.Text = "报表预览";
            // 
            // pcReport
            // 
            this.pcReport.BackColor = System.Drawing.Color.Empty;
            this.pcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcReport.ForeColor = System.Drawing.Color.Empty;
            this.pcReport.IsMetric = true;
            this.pcReport.Location = new System.Drawing.Point(2, 22);
            this.pcReport.Name = "pcReport";
            this.pcReport.Size = new System.Drawing.Size(911, 666);
            this.pcReport.TabIndex = 6;
            this.pcReport.TooltipFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // FrmWeightRepTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 721);
            this.Controls.Add(this.gcView);
            this.Controls.Add(this.gpList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmWeightRepTemplate";
            this.Text = "单据模板管理";
            this.Load += new System.EventHandler(this.FrmWeightReportList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpList)).EndInit();
            this.gpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            this.gcView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemDesign;
        private DevExpress.XtraBars.BarButtonItem btnItemSetting;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.GroupControl gpList;
        private DevExpress.XtraEditors.GroupControl gcView;
        private DevExpress.XtraPrinting.Control.PrintControl pcReport;
        private DevExpress.XtraGrid.GridControl gcReportList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReportList;
        private DevExpress.XtraGrid.Columns.GridColumn colTemplateName;
        private DevExpress.XtraBars.BarButtonItem barItemTempReportSetting;
        private DevExpress.XtraGrid.Columns.GridColumn colReportTypeCaption;
        private DevExpress.XtraBars.BarButtonItem barItemModify;
        private DevExpress.XtraBars.BarButtonItem barItemAdd;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
    }
}