namespace YF.MWS.Win.View.Extend
{
    partial class FrmFinanceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinanceList));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.barItemSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemAuth = new DevExpress.XtraBars.BarButtonItem();
            this.barItemFreightSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPaymentSettle = new DevExpress.XtraBars.BarButtonItem();
            this.barItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnItemPaymentSettle = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barItemBatchAudit = new DevExpress.XtraBars.BarButtonItem();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExortWithGV = new DevExpress.XtraEditors.SimpleButton();
            this.combDateType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.combFinaSettlement = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblWeightDate = new DevExpress.XtraEditors.LabelControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combDateType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinaSettlement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "currency_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "summary_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "textbox_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "print_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "weight_16x16.png");
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
            this.btnItemPaymentSettle,
            this.btnItemPrint,
            this.barItemSettle,
            this.barItemAuth,
            this.barItemFreightSettle,
            this.barItemPaymentSettle,
            this.barItemPrint,
            this.barItemBatchAudit});
            this.barManager.MaxItemId = 17;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemAuth, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemFreightSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPaymentSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barItemPrint, true)});
            this.barTop.Text = "Tools";
            // 
            // barItemSettle
            // 
            this.barItemSettle.Caption = "财务结算详情";
            this.barItemSettle.Id = 11;
            this.barItemSettle.ImageIndex = 0;
            this.barItemSettle.Name = "barItemSettle";
            this.barItemSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemSettle.Tag = "Detail";
            this.barItemSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemSettle_ItemClick);
            // 
            // barItemAuth
            // 
            this.barItemAuth.Caption = "财务审核";
            this.barItemAuth.Id = 12;
            this.barItemAuth.ImageIndex = 4;
            this.barItemAuth.Name = "barItemAuth";
            this.barItemAuth.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemAuth.Tag = "Auth";
            this.barItemAuth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemAuth_ItemClick);
            // 
            // barItemFreightSettle
            // 
            this.barItemFreightSettle.Caption = "运费结算";
            this.barItemFreightSettle.Id = 13;
            this.barItemFreightSettle.ImageIndex = 1;
            this.barItemFreightSettle.Name = "barItemFreightSettle";
            this.barItemFreightSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemFreightSettle.Tag = "Freight";
            this.barItemFreightSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemFreightSettle_ItemClick_1);
            // 
            // barItemPaymentSettle
            // 
            this.barItemPaymentSettle.Caption = "货款结算";
            this.barItemPaymentSettle.Id = 14;
            this.barItemPaymentSettle.ImageIndex = 1;
            this.barItemPaymentSettle.Name = "barItemPaymentSettle";
            this.barItemPaymentSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPaymentSettle.Tag = "Payment";
            this.barItemPaymentSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPaymentSettle_ItemClick);
            // 
            // barItemPrint
            // 
            this.barItemPrint.AllowAllUp = true;
            this.barItemPrint.Caption = "打印";
            this.barItemPrint.Id = 15;
            this.barItemPrint.ImageIndex = 3;
            this.barItemPrint.Name = "barItemPrint";
            this.barItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemPrint_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1110, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 486);
            this.barDockControlBottom.Size = new System.Drawing.Size(1110, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 455);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1110, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 455);
            // 
            // btnItemPaymentSettle
            // 
            this.btnItemPaymentSettle.Caption = "货款结算";
            this.btnItemPaymentSettle.Id = 1;
            this.btnItemPaymentSettle.ImageIndex = 0;
            this.btnItemPaymentSettle.Name = "btnItemPaymentSettle";
            this.btnItemPaymentSettle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemPaymentSettle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemPaymentSettle_ItemClick);
            // 
            // btnItemPrint
            // 
            this.btnItemPrint.Caption = "打印";
            this.btnItemPrint.Id = 7;
            this.btnItemPrint.ImageIndex = 1;
            this.btnItemPrint.Name = "btnItemPrint";
            this.btnItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemBatchAudit
            // 
            this.barItemBatchAudit.Caption = "批量审核";
            this.barItemBatchAudit.Id = 16;
            this.barItemBatchAudit.ImageIndex = 4;
            this.barItemBatchAudit.Name = "barItemBatchAudit";
            this.barItemBatchAudit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barItemBatchAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barItemBatchAudit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemBatchAudit_ItemClick);
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExortWithGV);
            this.panelControl1.Controls.Add(this.combDateType);
            this.panelControl1.Controls.Add(this.btnExportExcel);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.teEndDate);
            this.panelControl1.Controls.Add(this.lblRange);
            this.panelControl1.Controls.Add(this.combFinaSettlement);
            this.panelControl1.Controls.Add(this.teStartDate);
            this.panelControl1.Controls.Add(this.lblWeightDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1110, 44);
            this.panelControl1.TabIndex = 8;
            // 
            // btnExortWithGV
            // 
            this.btnExortWithGV.Location = new System.Drawing.Point(709, 14);
            this.btnExortWithGV.Name = "btnExortWithGV";
            this.btnExortWithGV.Size = new System.Drawing.Size(113, 23);
            this.btnExortWithGV.TabIndex = 92;
            this.btnExortWithGV.Text = "按格式导出";
            this.btnExortWithGV.Click += new System.EventHandler(this.btnExortWithGV_Click);
            // 
            // combDateType
            // 
            this.combDateType.EditValue = "过磅日期";
            this.combDateType.Location = new System.Drawing.Point(12, 14);
            this.combDateType.Name = "combDateType";
            this.combDateType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combDateType.Properties.Items.AddRange(new object[] {
            "过磅日期",
            "结算日期"});
            this.combDateType.Size = new System.Drawing.Size(87, 20);
            this.combDateType.TabIndex = 91;
            this.combDateType.SelectedIndexChanged += new System.EventHandler(this.combDateType_SelectedIndexChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(843, 14);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(113, 23);
            this.btnExportExcel.TabIndex = 90;
            this.btnExportExcel.Text = "标准Excel导出";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(613, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // teEndDate
            // 
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(320, 15);
            this.teEndDate.Name = "teEndDate";
            this.teEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.teEndDate.Size = new System.Drawing.Size(100, 20);
            this.teEndDate.TabIndex = 88;
            // 
            // lblRange
            // 
            this.lblRange.Location = new System.Drawing.Point(292, 18);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(12, 14);
            this.lblRange.TabIndex = 87;
            this.lblRange.Text = "至";
            // 
            // combFinaSettlement
            // 
            this.combFinaSettlement.EditValue = "所有磅单";
            this.combFinaSettlement.Location = new System.Drawing.Point(435, 15);
            this.combFinaSettlement.Name = "combFinaSettlement";
            this.combFinaSettlement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combFinaSettlement.Size = new System.Drawing.Size(157, 20);
            this.combFinaSettlement.TabIndex = 86;
            // 
            // teStartDate
            // 
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(179, 15);
            this.teStartDate.Name = "teStartDate";
            this.teStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.teStartDate.Size = new System.Drawing.Size(100, 20);
            this.teStartDate.TabIndex = 63;
            // 
            // lblWeightDate
            // 
            this.lblWeightDate.Location = new System.Drawing.Point(116, 17);
            this.lblWeightDate.Name = "lblWeightDate";
            this.lblWeightDate.Size = new System.Drawing.Size(52, 14);
            this.lblWeightDate.TabIndex = 40;
            this.lblWeightDate.Text = "过磅日期:";
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(0, 75);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Size = new System.Drawing.Size(1110, 411);
            this.gcWeight.TabIndex = 9;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsBehavior.Editable = false;
            this.gvWeight.OptionsBehavior.ReadOnly = true;
            this.gvWeight.OptionsPrint.AutoWidth = false;
            this.gvWeight.OptionsView.ShowFooter = true;
            this.gvWeight.DoubleClick += new System.EventHandler(this.gvWeight_DoubleClick);
            // 
            // FrmFinanceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 486);
            this.Controls.Add(this.gcWeight);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmFinanceList";
            this.Text = "财务结算";
            this.Load += new System.EventHandler(this.FrmFinanceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combDateType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinaSettlement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemPaymentSettle;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnItemPrint;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.ComboBoxEdit combFinaSettlement;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.LabelControl lblWeightDate;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private DevExpress.XtraBars.BarButtonItem barItemSettle;
        private DevExpress.XtraBars.BarButtonItem barItemAuth;
        private DevExpress.XtraBars.BarButtonItem barItemFreightSettle;
        private DevExpress.XtraBars.BarButtonItem barItemPaymentSettle;
        private DevExpress.XtraBars.BarButtonItem barItemPrint;
        private DevExpress.XtraBars.BarButtonItem barItemBatchAudit;
        private DevExpress.XtraEditors.ComboBoxEdit combDateType;
        private DevExpress.XtraEditors.SimpleButton btnExortWithGV;
    }
}