namespace YF.MWS.Win.View.Customer
{
    partial class FrmPriceList
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
            YF.MWS.SQliteService.MasterService masterService1 = new YF.MWS.SQliteService.MasterService();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPriceList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barItemSearch = new DevExpress.XtraBars.BarButtonItem();
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
            this.gpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.gcPrice = new DevExpress.XtraGrid.GridControl();
            this.gvPrice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucPage = new YF.MWS.Win.Uc.UcPage();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gpSearchCondition = new DevExpress.XtraEditors.GroupControl();
            this.xscRight = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gpSearchKey = new DevExpress.XtraEditors.GroupControl();
            this.weCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.lookMaterial = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).BeginInit();
            this.gpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).BeginInit();
            this.gpSearchCondition.SuspendLayout();
            this.xscRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).BeginInit();
            this.gpSearchKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.barItemSearch});
            this.barManager.MaxItemId = 11;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete, true)});
            this.bar1.Text = "Tools";
            // 
            // barItemSearch
            // 
            this.barItemSearch.Caption = "搜索";
            this.barItemSearch.Id = 10;
            this.barItemSearch.ImageIndex = 6;
            this.barItemSearch.Name = "barItemSearch";
            this.barItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSearch_ItemClick);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "新增";
            this.btnItemAdd.Id = 4;
            this.btnItemAdd.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "编辑";
            this.btnItemEdit.Id = 8;
            this.btnItemEdit.ImageIndex = 4;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Caption = "删除";
            this.btnItemDelete.Id = 2;
            this.btnItemDelete.ImageIndex = 3;
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1001, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 493);
            this.barDockControlBottom.Size = new System.Drawing.Size(1001, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1001, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
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
            this.imgListSmall.Images.SetKeyName(6, "search_16x16.png");
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
            this.btnItemAddSub.ImageIndex = 1;
            this.btnItemAddSub.Name = "btnItemAddSub";
            this.btnItemAddSub.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // gpSearchResult
            // 
            this.gpSearchResult.Controls.Add(this.gcPrice);
            this.gpSearchResult.Controls.Add(this.ucPage);
            this.gpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSearchResult.Location = new System.Drawing.Point(0, 31);
            this.gpSearchResult.Name = "gpSearchResult";
            this.gpSearchResult.Size = new System.Drawing.Size(676, 462);
            this.gpSearchResult.TabIndex = 21;
            this.gpSearchResult.Text = "查询结果";
            // 
            // gcPrice
            // 
            this.gcPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPrice.Location = new System.Drawing.Point(2, 22);
            this.gcPrice.MainView = this.gvPrice;
            this.gcPrice.Name = "gcPrice";
            this.gcPrice.Size = new System.Drawing.Size(672, 412);
            this.gcPrice.TabIndex = 13;
            this.gcPrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrice});
            // 
            // gvPrice
            // 
            this.gvPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerName,
            this.colMaterialName,
            this.colPrice});
            this.gvPrice.GridControl = this.gcPrice;
            this.gvPrice.Name = "gvPrice";
            this.gvPrice.OptionsBehavior.Editable = false;
            this.gvPrice.OptionsBehavior.ReadOnly = true;
            this.gvPrice.OptionsPrint.AutoWidth = false;
            this.gvPrice.OptionsView.ShowFooter = true;
            this.gvPrice.OptionsView.ShowGroupPanel = false;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户名称";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            this.colCustomerName.Width = 125;
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "物资名称";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 1;
            this.colMaterialName.Width = 167;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "价格";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 108;
            // 
            // ucPage
            // 
            this.ucPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPage.Location = new System.Drawing.Point(2, 434);
            this.ucPage.Name = "ucPage";
            qPage1.PageIndex = 0;
            qPage1.PageSize = 25;
            qPage1.TotalRows = 0;
            this.ucPage.Page = qPage1;
            this.ucPage.Size = new System.Drawing.Size(672, 26);
            this.ucPage.TabIndex = 12;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(676, 31);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 462);
            this.splitterControl1.TabIndex = 20;
            this.splitterControl1.TabStop = false;
            // 
            // gpSearchCondition
            // 
            this.gpSearchCondition.Controls.Add(this.xscRight);
            this.gpSearchCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpSearchCondition.Location = new System.Drawing.Point(681, 31);
            this.gpSearchCondition.Name = "gpSearchCondition";
            this.gpSearchCondition.Size = new System.Drawing.Size(320, 462);
            this.gpSearchCondition.TabIndex = 19;
            this.gpSearchCondition.Text = "查询条件";
            // 
            // xscRight
            // 
            this.xscRight.Controls.Add(this.gpSearchKey);
            this.xscRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscRight.Location = new System.Drawing.Point(2, 22);
            this.xscRight.Name = "xscRight";
            this.xscRight.Size = new System.Drawing.Size(316, 438);
            this.xscRight.TabIndex = 89;
            // 
            // gpSearchKey
            // 
            this.gpSearchKey.Controls.Add(this.weCustomer);
            this.gpSearchKey.Controls.Add(this.lblCustomer);
            this.gpSearchKey.Controls.Add(this.lookMaterial);
            this.gpSearchKey.Controls.Add(this.lblMaterial);
            this.gpSearchKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpSearchKey.Location = new System.Drawing.Point(0, 0);
            this.gpSearchKey.Name = "gpSearchKey";
            this.gpSearchKey.Size = new System.Drawing.Size(316, 139);
            this.gpSearchKey.TabIndex = 52;
            this.gpSearchKey.Text = "查询关键词";
            // 
            // weCustomer
            // 
            this.weCustomer.ActionName = null;
            this.weCustomer.AutoCalcNo = 0;
            this.weCustomer.Caption = null;
            this.weCustomer.ControlName = null;
            this.weCustomer.CurrentValue = null;
            this.weCustomer.DecimalDigits = 0;
            this.weCustomer.EditText = "";
            this.weCustomer.EditValue = "";
            this.weCustomer.Expression = null;
            this.weCustomer.FieldName = null;
            this.weCustomer.IsRequired = false;
            this.weCustomer.Location = new System.Drawing.Point(86, 39);
            this.weCustomer.MenuManager = this.barManager;
            this.weCustomer.Name = "weCustomer";
            this.weCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.weCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.weCustomer.Size = new System.Drawing.Size(190, 20);
            this.weCustomer.TabIndex = 106;
            this.weCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.weCustomer.WeightVauleChanged = null;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.lblCustomer.Location = new System.Drawing.Point(26, 47);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(30, 12);
            this.lblCustomer.TabIndex = 105;
            this.lblCustomer.Text = "客户:";
            // 
            // lookMaterial
            // 
            this.lookMaterial.Location = new System.Drawing.Point(86, 82);
            this.lookMaterial.MenuManager = this.barManager;
            this.lookMaterial.Name = "lookMaterial";
            this.lookMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookMaterial.Properties.NullText = "";
            this.lookMaterial.Properties.View = this.gridView1;
            this.lookMaterial.Size = new System.Drawing.Size(190, 20);
            this.lookMaterial.TabIndex = 104;
            this.lookMaterial.Tag = "";
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Location = new System.Drawing.Point(26, 85);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(28, 14);
            this.lblMaterial.TabIndex = 103;
            this.lblMaterial.Text = "品种:";
            // 
            // FrmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 493);
            this.Controls.Add(this.gpSearchResult);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gpSearchCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmPriceList";
            this.Text = "客户物资价格管理";
            this.Load += new System.EventHandler(this.FrmPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchResult)).EndInit();
            this.gpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchCondition)).EndInit();
            this.gpSearchCondition.ResumeLayout(false);
            this.xscRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpSearchKey)).EndInit();
            this.gpSearchKey.ResumeLayout(false);
            this.gpSearchKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barItemSearch;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarButtonItem btnItemAddSub;
        private DevExpress.XtraEditors.GroupControl gpSearchResult;
        private DevExpress.XtraGrid.GridControl gcPrice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private Uc.UcPage ucPage;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gpSearchCondition;
        private DevExpress.XtraEditors.XtraScrollableControl xscRight;
        private DevExpress.XtraEditors.GroupControl gpSearchKey;
        private Uc.Weight.WCustomerEdit weCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.SearchLookUpEdit lookMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblMaterial;
    }
}