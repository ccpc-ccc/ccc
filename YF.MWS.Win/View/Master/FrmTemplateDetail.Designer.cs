namespace YF.MWS.Win.View.Master
{
    partial class FrmTemplateDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplateDetail));
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
            this.teTempateName = new DevExpress.XtraEditors.TextEdit();
            this.beTemplateUrl = new DevExpress.XtraEditors.ButtonEdit();
            this.teOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.combReportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.memoDataSourceSql = new DevExpress.XtraEditors.MemoEdit();
            this.lblDataSourceSql = new DevExpress.XtraEditors.LabelControl();
            this.lblReportType = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.lblTempateUrl = new DevExpress.XtraEditors.LabelControl();
            this.lblTempateName = new DevExpress.XtraEditors.LabelControl();
            this.ofdReportTemplate = new System.Windows.Forms.OpenFileDialog();
            this.combSubReportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSubReportType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTempateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beTemplateUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDataSourceSql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combSubReportType.Properties)).BeginInit();
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
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(564, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 423);
            this.barDockControlBottom.Size = new System.Drawing.Size(564, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(564, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
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
            // teTempateName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teTempateName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teTempateName.Location = new System.Drawing.Point(115, 106);
            this.teTempateName.MenuManager = this.barManager;
            this.teTempateName.Name = "teTempateName";
            this.teTempateName.Size = new System.Drawing.Size(410, 20);
            this.teTempateName.TabIndex = 36;
            this.teTempateName.Tag = "TempateName";
            // 
            // beTemplateUrl
            // 
            this.dxErrorProvider.SetIconAlignment(this.beTemplateUrl, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.beTemplateUrl.Location = new System.Drawing.Point(115, 179);
            this.beTemplateUrl.MenuManager = this.barManager;
            this.beTemplateUrl.Name = "beTemplateUrl";
            this.beTemplateUrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beTemplateUrl.Size = new System.Drawing.Size(410, 20);
            this.beTemplateUrl.TabIndex = 42;
            this.beTemplateUrl.ToolTipTitle = "选择文件";
            this.beTemplateUrl.Click += new System.EventHandler(this.beTemplateUrl_Click);
            // 
            // teOrderNo
            // 
            this.dxErrorProvider.SetIconAlignment(this.teOrderNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teOrderNo.Location = new System.Drawing.Point(115, 141);
            this.teOrderNo.MenuManager = this.barManager;
            this.teOrderNo.Name = "teOrderNo";
            this.teOrderNo.Properties.Mask.EditMask = "N0";
            this.teOrderNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teOrderNo.Size = new System.Drawing.Size(89, 20);
            this.teOrderNo.TabIndex = 43;
            this.teOrderNo.Tag = "OrderNo";
            // 
            // combReportType
            // 
            this.dxErrorProvider.SetIconAlignment(this.combReportType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combReportType.Location = new System.Drawing.Point(115, 28);
            this.combReportType.MenuManager = this.barManager;
            this.combReportType.Name = "combReportType";
            this.combReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combReportType.Properties.Items.AddRange(new object[] {
            "正式磅单",
            "临时磅单",
            "财务结算",
            "计量方",
            "重印正式磅单"});
            this.combReportType.Size = new System.Drawing.Size(157, 20);
            this.combReportType.TabIndex = 62;
            this.combReportType.SelectedIndexChanged += new System.EventHandler(this.combReportType_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.combSubReportType);
            this.panelControl1.Controls.Add(this.lblSubReportType);
            this.panelControl1.Controls.Add(this.memoDataSourceSql);
            this.panelControl1.Controls.Add(this.lblDataSourceSql);
            this.panelControl1.Controls.Add(this.combReportType);
            this.panelControl1.Controls.Add(this.lblReportType);
            this.panelControl1.Controls.Add(this.teOrderNo);
            this.panelControl1.Controls.Add(this.lblOrderNo);
            this.panelControl1.Controls.Add(this.beTemplateUrl);
            this.panelControl1.Controls.Add(this.lblTempateUrl);
            this.panelControl1.Controls.Add(this.teTempateName);
            this.panelControl1.Controls.Add(this.lblTempateName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(564, 392);
            this.panelControl1.TabIndex = 6;
            // 
            // memoDataSourceSql
            // 
            this.memoDataSourceSql.Location = new System.Drawing.Point(115, 220);
            this.memoDataSourceSql.MenuManager = this.barManager;
            this.memoDataSourceSql.Name = "memoDataSourceSql";
            this.memoDataSourceSql.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.memoDataSourceSql.Properties.Appearance.Options.UseFont = true;
            this.memoDataSourceSql.Size = new System.Drawing.Size(410, 152);
            this.memoDataSourceSql.TabIndex = 65;
            // 
            // lblDataSourceSql
            // 
            this.lblDataSourceSql.Location = new System.Drawing.Point(31, 222);
            this.lblDataSourceSql.Name = "lblDataSourceSql";
            this.lblDataSourceSql.Size = new System.Drawing.Size(72, 14);
            this.lblDataSourceSql.TabIndex = 64;
            this.lblDataSourceSql.Text = "数据源(SQL):";
            // 
            // lblReportType
            // 
            this.lblReportType.Location = new System.Drawing.Point(31, 29);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(52, 14);
            this.lblReportType.TabIndex = 61;
            this.lblReportType.Text = "报表类别:";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(31, 141);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(40, 14);
            this.lblOrderNo.TabIndex = 44;
            this.lblOrderNo.Text = "排序号:";
            // 
            // lblTempateUrl
            // 
            this.lblTempateUrl.Location = new System.Drawing.Point(31, 179);
            this.lblTempateUrl.Name = "lblTempateUrl";
            this.lblTempateUrl.Size = new System.Drawing.Size(52, 14);
            this.lblTempateUrl.TabIndex = 39;
            this.lblTempateUrl.Text = "模板文件:";
            // 
            // lblTempateName
            // 
            this.lblTempateName.Location = new System.Drawing.Point(31, 106);
            this.lblTempateName.Name = "lblTempateName";
            this.lblTempateName.Size = new System.Drawing.Size(52, 14);
            this.lblTempateName.TabIndex = 38;
            this.lblTempateName.Text = "模板名称:";
            // 
            // ofdReportTemplate
            // 
            this.ofdReportTemplate.Filter = "报表模板文件|*.repx";
            // 
            // combSubReportType
            // 
            this.dxErrorProvider.SetIconAlignment(this.combSubReportType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combSubReportType.Location = new System.Drawing.Point(115, 68);
            this.combSubReportType.MenuManager = this.barManager;
            this.combSubReportType.Name = "combSubReportType";
            this.combSubReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combSubReportType.Properties.Items.AddRange(new object[] {
            "正式磅单",
            "临时磅单",
            "财务结算",
            "计量方",
            "重印正式磅单"});
            this.combSubReportType.Size = new System.Drawing.Size(157, 20);
            this.combSubReportType.TabIndex = 67;
            // 
            // lblSubReportType
            // 
            this.lblSubReportType.Location = new System.Drawing.Point(31, 69);
            this.lblSubReportType.Name = "lblSubReportType";
            this.lblSubReportType.Size = new System.Drawing.Size(52, 14);
            this.lblSubReportType.TabIndex = 66;
            this.lblSubReportType.Text = "二级分类:";
            // 
            // FrmTemplateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 423);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTemplateDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板详情";
            this.Load += new System.EventHandler(this.FrmTemplateDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTempateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beTemplateUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDataSourceSql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combSubReportType.Properties)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.LabelControl lblTempateUrl;
        private DevExpress.XtraEditors.TextEdit teTempateName;
        private DevExpress.XtraEditors.LabelControl lblTempateName;
        private DevExpress.XtraEditors.ButtonEdit beTemplateUrl;
        private System.Windows.Forms.OpenFileDialog ofdReportTemplate;
        private DevExpress.XtraEditors.TextEdit teOrderNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraEditors.ComboBoxEdit combReportType;
        private DevExpress.XtraEditors.LabelControl lblReportType;
        private DevExpress.XtraEditors.LabelControl lblDataSourceSql;
        private DevExpress.XtraEditors.MemoEdit memoDataSourceSql;
        private DevExpress.XtraEditors.ComboBoxEdit combSubReportType;
        private DevExpress.XtraEditors.LabelControl lblSubReportType;
    }
}