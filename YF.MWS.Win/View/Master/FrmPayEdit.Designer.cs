namespace YF.MWS.Win.View.Master
{
    partial class FrmPayEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtPayNo = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcWareh = new DevExpress.XtraGrid.GridControl();
            this.gvWareh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWeightNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuttleWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPayAmount = new DevExpress.XtraEditors.TextEdit();
            this.wCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lblWarehCode = new DevExpress.XtraEditors.LabelControl();
            this.lblWarehName = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).BeginInit();
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
            this.btnItemSave,
            this.btnItemClose});
            this.barManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1033, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 534);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1033, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 510);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1033, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 510);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // txtPayNo
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtPayNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtPayNo.Location = new System.Drawing.Point(72, 27);
            this.txtPayNo.MenuManager = this.barManager;
            this.txtPayNo.Name = "txtPayNo";
            this.txtPayNo.Size = new System.Drawing.Size(225, 20);
            this.txtPayNo.TabIndex = 59;
            this.txtPayNo.Tag = "PayNo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcWareh);
            this.panelControl1.Controls.Add(this.txtPayAmount);
            this.panelControl1.Controls.Add(this.wCustomer);
            this.panelControl1.Controls.Add(this.txtPayNo);
            this.panelControl1.Controls.Add(this.lblWarehCode);
            this.panelControl1.Controls.Add(this.lblWarehName);
            this.panelControl1.Controls.Add(this.lblLocation);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1033, 510);
            this.panelControl1.TabIndex = 7;
            // 
            // gcWareh
            // 
            this.gcWareh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcWareh.Location = new System.Drawing.Point(0, 53);
            this.gcWareh.MainView = this.gvWareh;
            this.gcWareh.MenuManager = this.barManager;
            this.gcWareh.Name = "gcWareh";
            this.gcWareh.Size = new System.Drawing.Size(1033, 457);
            this.gcWareh.TabIndex = 62;
            this.gcWareh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWareh});
            // 
            // gvWareh
            // 
            this.gvWareh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWeightNo,
            this.colCustomerName,
            this.colUnitPrice,
            this.colSuttleWeight,
            this.colUnitMoney,
            this.colCreateDate});
            this.gvWareh.GridControl = this.gcWareh;
            this.gvWareh.Name = "gvWareh";
            this.gvWareh.OptionsBehavior.Editable = false;
            this.gvWareh.OptionsSelection.MultiSelect = true;
            this.gvWareh.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvWareh.OptionsView.ShowGroupPanel = false;
            // 
            // colWeightNo
            // 
            this.colWeightNo.Caption = "磅单号";
            this.colWeightNo.FieldName = "WeightNo";
            this.colWeightNo.Name = "colWeightNo";
            this.colWeightNo.Visible = true;
            this.colWeightNo.VisibleIndex = 2;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "物资名称";
            this.colCustomerName.FieldName = "MaterialName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "物资价格";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 5;
            // 
            // colSuttleWeight
            // 
            this.colSuttleWeight.Caption = "净重";
            this.colSuttleWeight.FieldName = "SuttleWeight";
            this.colSuttleWeight.Name = "colSuttleWeight";
            this.colSuttleWeight.Visible = true;
            this.colSuttleWeight.VisibleIndex = 3;
            // 
            // colUnitMoney
            // 
            this.colUnitMoney.Caption = "金额";
            this.colUnitMoney.FieldName = "UnitMoney";
            this.colUnitMoney.Name = "colUnitMoney";
            this.colUnitMoney.Visible = true;
            this.colUnitMoney.VisibleIndex = 4;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "完成时间";
            this.colCreateDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateDate.FieldName = "FinishTime";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 6;
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(646, 27);
            this.txtPayAmount.MenuManager = this.barManager;
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Properties.EditFormat.FormatString = "0.00";
            this.txtPayAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPayAmount.Size = new System.Drawing.Size(225, 20);
            this.txtPayAmount.TabIndex = 61;
            this.txtPayAmount.Tag = "PayAmount";
            // 
            // wCustomer
            // 
            this.wCustomer.ActionName = null;
            this.wCustomer.AutoCalcNo = 0;
            this.wCustomer.Caption = null;
            this.wCustomer.ControlName = null;
            this.wCustomer.CurrentValue = null;
            this.wCustomer.DecimalDigits = 0;
            this.wCustomer.EditText = "";
            this.wCustomer.EditValue = "";
            this.wCustomer.ErrorTipText = null;
            this.wCustomer.Expression = null;
            this.wCustomer.FieldName = null;
            this.wCustomer.IsRequired = false;
            this.wCustomer.Location = new System.Drawing.Point(360, 27);
            this.wCustomer.MenuManager = this.barManager;
            this.wCustomer.Name = "wCustomer";
            this.wCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.wCustomer.Properties.AutoComplete = false;
            this.wCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.wCustomer.Size = new System.Drawing.Size(225, 20);
            this.wCustomer.StartAutoSave = false;
            this.wCustomer.StartStay = false;
            this.wCustomer.TabIndex = 60;
            this.wCustomer.Tag = "CustomerId";
            this.wCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.wCustomer.WeightVauleChanged = null;
            this.wCustomer.SelectedValueChanged += new System.EventHandler(this.wCustomer_SelectedValueChanged);
            this.wCustomer.TextChanged += new System.EventHandler(this.wCustomer_TextChanged);
            // 
            // lblWarehCode
            // 
            this.lblWarehCode.Location = new System.Drawing.Point(24, 30);
            this.lblWarehCode.Name = "lblWarehCode";
            this.lblWarehCode.Size = new System.Drawing.Size(28, 14);
            this.lblWarehCode.TabIndex = 57;
            this.lblWarehCode.Text = "编码:";
            // 
            // lblWarehName
            // 
            this.lblWarehName.Location = new System.Drawing.Point(326, 30);
            this.lblWarehName.Name = "lblWarehName";
            this.lblWarehName.Size = new System.Drawing.Size(28, 14);
            this.lblWarehName.TabIndex = 55;
            this.lblWarehName.Text = "客户:";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(612, 30);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(28, 14);
            this.lblLocation.TabIndex = 40;
            this.lblLocation.Text = "金额:";
            // 
            // FrmPayEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 534);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPayEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加往来";
            this.Load += new System.EventHandler(this.FrmWarehEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPayAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wCustomer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtPayNo;
        private DevExpress.XtraEditors.LabelControl lblWarehCode;
        private DevExpress.XtraEditors.LabelControl lblWarehName;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private Uc.Weight.WCustomerEdit wCustomer;
        private DevExpress.XtraEditors.TextEdit txtPayAmount;
        private DevExpress.XtraGrid.GridControl gcWareh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWareh;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSuttleWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitMoney;
    }
}