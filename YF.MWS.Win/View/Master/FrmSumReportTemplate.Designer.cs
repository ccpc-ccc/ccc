namespace YF.MWS.Win.View.Master
{
    partial class FrmSumReportTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSumReportTemplate));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemDesign = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAddSub = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemModify = new DevExpress.XtraBars.BarButtonItem();
            this.barItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcView = new DevExpress.XtraEditors.GroupControl();
            this.pcReport = new DevExpress.XtraPrinting.Control.PrintControl();
            this.gcList = new DevExpress.XtraEditors.GroupControl();
            this.gcReportList = new DevExpress.XtraGrid.GridControl();
            this.gvReportList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportTypeCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTemplateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barItemViewData = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).BeginInit();
            this.gcView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            this.gcList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportList)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "setup_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "design_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "additem_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(5, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(6, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(7, "preview_16x16.png");
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
            this.barItemAddSub,
            this.barItemDelete,
            this.barItemAdd,
            this.barItemDesign,
            this.barItemViewData});
            this.barManager.MaxItemId = 14;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDesign),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemViewData),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAddSub),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemModify),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemDelete, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemDesign
            // 
            this.barItemDesign.Caption = "设计报表模板";
            this.barItemDesign.Id = 12;
            this.barItemDesign.ImageIndex = 2;
            this.barItemDesign.Name = "barItemDesign";
            this.barItemDesign.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDesign_ItemClick);
            // 
            // barItemAdd
            // 
            this.barItemAdd.Caption = "新建分类";
            this.barItemAdd.Id = 11;
            this.barItemAdd.ImageIndex = 6;
            this.barItemAdd.Name = "barItemAdd";
            this.barItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAdd_ItemClick);
            // 
            // barItemAddSub
            // 
            this.barItemAddSub.Caption = "新建";
            this.barItemAddSub.Id = 7;
            this.barItemAddSub.ImageIndex = 3;
            this.barItemAddSub.Name = "barItemAddSub";
            this.barItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAddSub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAddSub_ItemClick);
            // 
            // btnItemModify
            // 
            this.btnItemModify.Caption = "编辑";
            this.btnItemModify.Id = 1;
            this.btnItemModify.ImageIndex = 5;
            this.btnItemModify.Name = "btnItemModify";
            this.btnItemModify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemModify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemModify_ItemClick);
            // 
            // barItemDelete
            // 
            this.barItemDelete.Caption = "删除";
            this.barItemDelete.Id = 10;
            this.barItemDelete.ImageIndex = 4;
            this.barItemDelete.Name = "barItemDelete";
            this.barItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemDelete_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 499);
            this.barDockControlBottom.Size = new System.Drawing.Size(1057, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 468);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1057, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 468);
            // 
            // gcView
            // 
            this.gcView.Controls.Add(this.pcReport);
            this.gcView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcView.Location = new System.Drawing.Point(407, 31);
            this.gcView.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gcView.Name = "gcView";
            this.gcView.Size = new System.Drawing.Size(650, 468);
            this.gcView.TabIndex = 7;
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
            this.pcReport.Size = new System.Drawing.Size(646, 444);
            this.pcReport.TabIndex = 6;
            this.pcReport.TooltipFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // gcList
            // 
            this.gcList.Controls.Add(this.gcReportList);
            this.gcList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcList.Location = new System.Drawing.Point(0, 31);
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(407, 468);
            this.gcList.TabIndex = 6;
            this.gcList.Text = "统计报表模板";
            // 
            // gcReportList
            // 
            this.gcReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReportList.Location = new System.Drawing.Point(2, 22);
            this.gcReportList.MainView = this.gvReportList;
            this.gcReportList.MenuManager = this.barManager;
            this.gcReportList.Name = "gcReportList";
            this.gcReportList.Size = new System.Drawing.Size(403, 444);
            this.gcReportList.TabIndex = 25;
            this.gcReportList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReportList});
            // 
            // gvReportList
            // 
            this.gvReportList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNo,
            this.colReportTypeCaption,
            this.colTemplateName});
            this.gvReportList.GridControl = this.gcReportList;
            this.gvReportList.Name = "gvReportList";
            this.gvReportList.NewItemRowText = "点此添加数据";
            this.gvReportList.OptionsView.ShowGroupPanel = false;
            this.gvReportList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvReportList_FocusedRowChanged);
            this.gvReportList.DoubleClick += new System.EventHandler(this.gvReportList_DoubleClick);
            // 
            // colOrderNo
            // 
            this.colOrderNo.Caption = "序号";
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 0;
            this.colOrderNo.Width = 62;
            // 
            // colReportTypeCaption
            // 
            this.colReportTypeCaption.Caption = "分类";
            this.colReportTypeCaption.FieldName = "ReportTypeCaption";
            this.colReportTypeCaption.Name = "colReportTypeCaption";
            this.colReportTypeCaption.Visible = true;
            this.colReportTypeCaption.VisibleIndex = 1;
            this.colReportTypeCaption.Width = 80;
            // 
            // colTemplateName
            // 
            this.colTemplateName.Caption = "名称";
            this.colTemplateName.FieldName = "TemplateName";
            this.colTemplateName.Name = "colTemplateName";
            this.colTemplateName.OptionsColumn.AllowEdit = false;
            this.colTemplateName.OptionsColumn.ReadOnly = true;
            this.colTemplateName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colTemplateName.Visible = true;
            this.colTemplateName.VisibleIndex = 2;
            this.colTemplateName.Width = 245;
            // 
            // barItemViewData
            // 
            this.barItemViewData.Caption = "预览数据";
            this.barItemViewData.Id = 13;
            this.barItemViewData.ImageIndex = 7;
            this.barItemViewData.Name = "barItemViewData";
            this.barItemViewData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemViewData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemViewData_ItemClick);
            // 
            // FrmSumReportTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 499);
            this.Controls.Add(this.gcView);
            this.Controls.Add(this.gcList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmSumReportTemplate";
            this.Text = "统计报表模板";
            this.Load += new System.EventHandler(this.FrmSumReportTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcView)).EndInit();
            this.gcView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            this.gcList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReportList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemModify;
        private DevExpress.XtraBars.BarButtonItem barItemAddSub;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl gcView;
        private DevExpress.XtraPrinting.Control.PrintControl pcReport;
        private DevExpress.XtraEditors.GroupControl gcList;
        private DevExpress.XtraBars.BarButtonItem barItemDelete;
        private DevExpress.XtraBars.BarButtonItem barItemAdd;
        private DevExpress.XtraGrid.GridControl gcReportList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReportList;
        private DevExpress.XtraGrid.Columns.GridColumn colTemplateName;
        private DevExpress.XtraBars.BarButtonItem barItemDesign;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReportTypeCaption;
        private DevExpress.XtraBars.BarButtonItem barItemViewData;
    }
}