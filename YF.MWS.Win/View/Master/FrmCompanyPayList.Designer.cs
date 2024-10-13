namespace YF.MWS.Win.View.Master
{
    partial class FrmCompanyPayList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyPayList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnItemEdit = new DevExpress.XtraBars.BarButtonItem();
            this.gcWareh = new DevExpress.XtraGrid.GridControl();
            this.gvWareh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.endDate = new DevExpress.XtraEditors.DateEdit();
            this.startDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).BeginInit();
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
            this.btnItemEdit,
            this.btnItemDelete,
            this.btnItemRefresh});
            this.barManager.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDelete)});
            this.bar1.Text = "Tools";
            // 
            // btnItemRefresh
            // 
            this.btnItemRefresh.Caption = "搜索";
            this.btnItemRefresh.Id = 3;
            this.btnItemRefresh.ImageOptions.ImageIndex = 3;
            this.btnItemRefresh.Name = "btnItemRefresh";
            this.btnItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemRefresh_ItemClick);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Caption = "添加";
            this.btnItemAdd.Id = 0;
            this.btnItemAdd.ImageOptions.ImageIndex = 0;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemAdd_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(844, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 488);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(844, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 464);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(844, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 464);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "add_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "edit_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "refresh_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "upload_16x16.png");
            // 
            // btnItemEdit
            // 
            this.btnItemEdit.Caption = "查看";
            this.btnItemEdit.Id = 1;
            this.btnItemEdit.ImageOptions.ImageIndex = 1;
            this.btnItemEdit.Name = "btnItemEdit";
            this.btnItemEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemEdit_ItemClick);
            // 
            // gcWareh
            // 
            this.gcWareh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcWareh.Location = new System.Drawing.Point(0, 103);
            this.gcWareh.MainView = this.gvWareh;
            this.gcWareh.MenuManager = this.barManager;
            this.gcWareh.Name = "gcWareh";
            this.gcWareh.Size = new System.Drawing.Size(844, 385);
            this.gcWareh.TabIndex = 5;
            this.gcWareh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWareh});
            // 
            // gvWareh
            // 
            this.gvWareh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerName,
            this.colQuantity,
            this.colPayAmount,
            this.colCreateDate});
            this.gvWareh.GridControl = this.gcWareh;
            this.gvWareh.Name = "gvWareh";
            this.gvWareh.OptionsBehavior.Editable = false;
            this.gvWareh.OptionsView.ShowGroupPanel = false;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "商户名称";
            this.colCustomerName.FieldName = "CompanyName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "延长次数";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            // 
            // colPayAmount
            // 
            this.colPayAmount.Caption = "支付金额";
            this.colPayAmount.FieldName = "Amount";
            this.colPayAmount.Name = "colPayAmount";
            this.colPayAmount.Visible = true;
            this.colPayAmount.VisibleIndex = 2;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "缴费时间";
            this.colCreateDate.DisplayFormat.FormatString = "d";
            this.colCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateDate.FieldName = "CreateTime";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.endDate);
            this.groupControl1.Controls.Add(this.startDate);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cmbCompany);
            this.groupControl1.Location = new System.Drawing.Point(0, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(844, 67);
            this.groupControl1.TabIndex = 10;
            // 
            // endDate
            // 
            this.endDate.EditValue = null;
            this.endDate.Location = new System.Drawing.Point(244, 35);
            this.endDate.Name = "endDate";
            this.endDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.endDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.endDate.Properties.DrawCellLines = true;
            this.endDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.endDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.endDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.endDate.Size = new System.Drawing.Size(142, 20);
            this.endDate.TabIndex = 1;
            // 
            // startDate
            // 
            this.startDate.EditValue = null;
            this.startDate.Location = new System.Drawing.Point(88, 35);
            this.startDate.MenuManager = this.barManager;
            this.startDate.Name = "startDate";
            this.startDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.startDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDate.Properties.DrawCellLines = true;
            this.startDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.startDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDate.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.startDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm:ss");
            this.startDate.Size = new System.Drawing.Size(142, 20);
            this.startDate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(236, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(4, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "-";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(412, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "商户";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "缴费日期";
            // 
            // cmbCompany
            // 
            this.cmbCompany.EditValue = "";
            this.cmbCompany.Location = new System.Drawing.Point(452, 35);
            this.cmbCompany.MenuManager = this.barManager;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCompany.Size = new System.Drawing.Size(131, 20);
            this.cmbCompany.TabIndex = 2;
            // 
            // FrmCompanyPayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 488);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcWareh);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmCompanyPayList";
            this.Text = "商户缴费";
            this.Load += new System.EventHandler(this.FrmWarehList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCompany.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnItemAdd;
        private DevExpress.XtraBars.BarButtonItem btnItemEdit;
        private DevExpress.XtraBars.BarButtonItem btnItemDelete;
        private DevExpress.XtraBars.BarButtonItem btnItemRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraGrid.GridControl gcWareh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWareh;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit endDate;
        private DevExpress.XtraEditors.DateEdit startDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colPayAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCompany;
    }
}