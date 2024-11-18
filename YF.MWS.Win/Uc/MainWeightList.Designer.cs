namespace YF.MWS.Win.Uc
{
    partial class MainWeightList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            SaveLayout();
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWeightList));
            this.pcHeader = new DevExpress.XtraEditors.PanelControl();
            this.txtCar = new DevExpress.XtraEditors.TextEdit();
            this.btnViewPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.combFinishState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cmbTimeType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.补录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.存为套表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pcHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pcHeader
            // 
            this.pcHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcHeader.Location = new System.Drawing.Point(0, 0);
            this.pcHeader.Name = "pcHeader";
            this.pcHeader.Size = new System.Drawing.Size(1414, 3);
            this.pcHeader.TabIndex = 6;
            // 
            // txtCar
            // 
            this.txtCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCar.Location = new System.Drawing.Point(556, 9);
            this.txtCar.Name = "txtCar";
            this.txtCar.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCar.Properties.Appearance.Options.UseFont = true;
            this.txtCar.Size = new System.Drawing.Size(71, 18);
            this.txtCar.TabIndex = 96;
            // 
            // btnViewPhoto
            // 
            this.btnViewPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPhoto.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnViewPhoto.Appearance.Options.UseFont = true;
            this.btnViewPhoto.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.photo_16x16;
            this.btnViewPhoto.Location = new System.Drawing.Point(1237, 2);
            this.btnViewPhoto.Name = "btnViewPhoto";
            this.btnViewPhoto.Size = new System.Drawing.Size(91, 25);
            this.btnViewPhoto.TabIndex = 95;
            this.btnViewPhoto.Text = "查看图片";
            this.btnViewPhoto.Click += new System.EventHandler(this.btnViewPhoto_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(514, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 12);
            this.labelControl1.TabIndex = 93;
            this.labelControl1.Text = "车牌号";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1336, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 25);
            this.simpleButton1.TabIndex = 90;
            this.simpleButton1.Text = "字段显示";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.exportexcel_16x16;
            this.btnExportExcel.Location = new System.Drawing.Point(729, 7);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 25);
            this.btnExportExcel.TabIndex = 90;
            this.btnExportExcel.Text = "导出";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.search_16x16;
            this.btnSearch.Location = new System.Drawing.Point(631, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // teEndDate
            // 
            this.teEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(331, 7);
            this.teEndDate.Name = "teEndDate";
            this.teEndDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teEndDate.Properties.Appearance.Options.UseFont = true;
            this.teEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teEndDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd");
            this.teEndDate.Size = new System.Drawing.Size(89, 20);
            this.teEndDate.TabIndex = 88;
            // 
            // lblRange
            // 
            this.lblRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRange.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRange.Appearance.Options.UseFont = true;
            this.lblRange.Location = new System.Drawing.Point(313, 11);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(12, 12);
            this.lblRange.TabIndex = 87;
            this.lblRange.Text = "至";
            // 
            // combFinishState
            // 
            this.combFinishState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combFinishState.EditValue = "所有磅单";
            this.combFinishState.Location = new System.Drawing.Point(428, 9);
            this.combFinishState.Name = "combFinishState";
            this.combFinishState.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combFinishState.Properties.Appearance.Options.UseFont = true;
            this.combFinishState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combFinishState.Properties.Items.AddRange(new object[] {
            "未完成磅单",
            "已完成磅单",
            "所有磅单"});
            this.combFinishState.Size = new System.Drawing.Size(80, 18);
            this.combFinishState.TabIndex = 86;
            // 
            // teStartDate
            // 
            this.teStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(216, 7);
            this.teStartDate.Name = "teStartDate";
            this.teStartDate.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.teStartDate.Properties.Appearance.Options.UseFont = true;
            this.teStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teStartDate.Properties.MaskSettings.Set("mask", "yyyy-MM-dd");
            this.teStartDate.Size = new System.Drawing.Size(91, 20);
            this.teStartDate.TabIndex = 63;
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.cmbTimeType);
            this.panelControl3.Controls.Add(this.cmbDate);
            this.panelControl3.Controls.Add(this.btnViewPhoto);
            this.panelControl3.Controls.Add(this.txtCar);
            this.panelControl3.Controls.Add(this.simpleButton1);
            this.panelControl3.Controls.Add(this.lblRange);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.teEndDate);
            this.panelControl3.Controls.Add(this.combFinishState);
            this.panelControl3.Controls.Add(this.btnSearch);
            this.panelControl3.Controls.Add(this.btnExportExcel);
            this.panelControl3.Controls.Add(this.teStartDate);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 284);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1414, 36);
            this.panelControl3.TabIndex = 97;
            // 
            // cmbTimeType
            // 
            this.cmbTimeType.Location = new System.Drawing.Point(3, 8);
            this.cmbTimeType.Name = "cmbTimeType";
            this.cmbTimeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTimeType.Size = new System.Drawing.Size(100, 20);
            this.cmbTimeType.TabIndex = 97;
            // 
            // cmbDate
            // 
            this.cmbDate.Location = new System.Drawing.Point(109, 7);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDate.Size = new System.Drawing.Size(100, 20);
            this.cmbDate.TabIndex = 97;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.EmbeddedNavigator.ContextMenuStrip = this.contextMenuStrip2;
            this.gcWeight.Location = new System.Drawing.Point(0, 3);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Margin = new System.Windows.Forms.Padding(0);
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Size = new System.Drawing.Size(1414, 281);
            this.gcWeight.TabIndex = 98;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.补录ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.作废ToolStripMenuItem,
            this.存为套表ToolStripMenuItem,
            this.打印ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(181, 136);
            // 
            // 补录ToolStripMenuItem
            // 
            this.补录ToolStripMenuItem.Name = "补录ToolStripMenuItem";
            this.补录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.补录ToolStripMenuItem.Text = "补录";
            this.补录ToolStripMenuItem.Click += new System.EventHandler(this.补录ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 作废ToolStripMenuItem
            // 
            this.作废ToolStripMenuItem.Name = "作废ToolStripMenuItem";
            this.作废ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.作废ToolStripMenuItem.Text = "作废";
            this.作废ToolStripMenuItem.Click += new System.EventHandler(this.作废ToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // gvWeight
            // 
            this.gvWeight.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvWeight.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvWeight.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvWeight.Appearance.DetailTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.DetailTip.Options.UseFont = true;
            this.gvWeight.Appearance.Empty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.Empty.Options.UseFont = true;
            this.gvWeight.Appearance.EvenRow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.EvenRow.Options.UseFont = true;
            this.gvWeight.Appearance.FilterCloseButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvWeight.Appearance.FilterPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.FilterPanel.Options.UseFont = true;
            this.gvWeight.Appearance.FixedLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.FixedLine.Options.UseFont = true;
            this.gvWeight.Appearance.FocusedCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.FocusedCell.Options.UseFont = true;
            this.gvWeight.Appearance.FocusedRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.FocusedRow.Options.UseFont = true;
            this.gvWeight.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.FooterPanel.Options.UseFont = true;
            this.gvWeight.Appearance.GroupButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.GroupButton.Options.UseFont = true;
            this.gvWeight.Appearance.GroupFooter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.GroupFooter.Options.UseFont = true;
            this.gvWeight.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.GroupPanel.Options.UseFont = true;
            this.gvWeight.Appearance.GroupRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.GroupRow.Options.UseFont = true;
            this.gvWeight.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvWeight.Appearance.HideSelectionRow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvWeight.Appearance.HorzLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.HorzLine.Options.UseFont = true;
            this.gvWeight.Appearance.OddRow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.OddRow.Options.UseFont = true;
            this.gvWeight.Appearance.Preview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.Preview.Options.UseFont = true;
            this.gvWeight.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.Row.Options.UseFont = true;
            this.gvWeight.Appearance.RowSeparator.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.RowSeparator.Options.UseFont = true;
            this.gvWeight.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.SelectedRow.Options.UseFont = true;
            this.gvWeight.Appearance.TopNewRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvWeight.Appearance.TopNewRow.Options.UseFont = true;
            this.gvWeight.Appearance.VertLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.VertLine.Options.UseFont = true;
            this.gvWeight.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.gvWeight.Appearance.ViewCaption.Options.UseFont = true;
            this.gvWeight.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvWeight.FooterPanelHeight = 0;
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsBehavior.Editable = false;
            this.gvWeight.OptionsBehavior.ReadOnly = true;
            this.gvWeight.OptionsView.ShowFooter = true;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            this.gvWeight.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvWeight_RowClick);
            this.gvWeight.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvWeight_CustomColumnDisplayText);
            this.gvWeight.DoubleClick += new System.EventHandler(this.gvWeight_DoubleClick);
            // 
            // 存为套表ToolStripMenuItem
            // 
            this.存为套表ToolStripMenuItem.Name = "存为套表ToolStripMenuItem";
            this.存为套表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.存为套表ToolStripMenuItem.Text = "存为套表";
            this.存为套表ToolStripMenuItem.Click += new System.EventHandler(this.存为套表ToolStripMenuItem_Click);
            // 
            // MainWeightList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.gcWeight);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.pcHeader);
            this.Name = "MainWeightList";
            this.Size = new System.Drawing.Size(1414, 320);
            this.Load += new System.EventHandler(this.MainWeightList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcHeader;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.ComboBoxEdit combFinishState;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
        private DevExpress.XtraEditors.SimpleButton btnViewPhoto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 补录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTimeType;
        private System.Windows.Forms.ToolStripMenuItem 存为套表ToolStripMenuItem;
    }
}
