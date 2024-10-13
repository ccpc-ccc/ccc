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
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWeightList));
            this.pcHeader = new DevExpress.XtraEditors.PanelControl();
            this.txtCar = new DevExpress.XtraEditors.TextEdit();
            this.btnViewPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.combFinishState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbTotalSuttleWeight = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbTotalMoney = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pcHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
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
            this.txtCar.Location = new System.Drawing.Point(694, 13);
            this.txtCar.Name = "txtCar";
            this.txtCar.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCar.Properties.Appearance.Options.UseFont = true;
            this.txtCar.Size = new System.Drawing.Size(133, 18);
            this.txtCar.TabIndex = 96;
            // 
            // btnViewPhoto
            // 
            this.btnViewPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPhoto.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnViewPhoto.Appearance.Options.UseFont = true;
            this.btnViewPhoto.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.photo_16x16;
            this.btnViewPhoto.Location = new System.Drawing.Point(1237, 8);
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
            this.labelControl1.Location = new System.Drawing.Point(652, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 12);
            this.labelControl1.TabIndex = 93;
            this.labelControl1.Text = "车牌号";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(302, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(48, 12);
            this.lblTitle.TabIndex = 93;
            this.lblTitle.Text = "最新磅单";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1336, 8);
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
            this.btnExportExcel.Location = new System.Drawing.Point(931, 10);
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
            this.btnSearch.Location = new System.Drawing.Point(833, 10);
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
            this.teEndDate.Location = new System.Drawing.Point(471, 12);
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
            this.lblRange.Location = new System.Drawing.Point(453, 16);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(12, 12);
            this.lblRange.TabIndex = 87;
            this.lblRange.Text = "至";
            // 
            // combFinishState
            // 
            this.combFinishState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combFinishState.EditValue = "所有磅单";
            this.combFinishState.Location = new System.Drawing.Point(566, 13);
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
            this.teStartDate.Location = new System.Drawing.Point(356, 12);
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
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.lbTotalSuttleWeight);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(3, 8);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(136, 29);
            this.panelControl1.TabIndex = 14;
            // 
            // lbTotalSuttleWeight
            // 
            this.lbTotalSuttleWeight.Location = new System.Drawing.Point(52, 8);
            this.lbTotalSuttleWeight.Name = "lbTotalSuttleWeight";
            this.lbTotalSuttleWeight.Size = new System.Drawing.Size(12, 14);
            this.lbTotalSuttleWeight.TabIndex = 0;
            this.lbTotalSuttleWeight.Text = "   ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "总重量：";
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl2.Controls.Add(this.lbTotalMoney);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Location = new System.Drawing.Point(145, 8);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(136, 29);
            this.panelControl2.TabIndex = 14;
            // 
            // lbTotalMoney
            // 
            this.lbTotalMoney.Location = new System.Drawing.Point(52, 8);
            this.lbTotalMoney.Name = "lbTotalMoney";
            this.lbTotalMoney.Size = new System.Drawing.Size(12, 14);
            this.lbTotalMoney.TabIndex = 0;
            this.lbTotalMoney.Text = "   ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "总金额：";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Controls.Add(this.btnViewPhoto);
            this.panelControl3.Controls.Add(this.txtCar);
            this.panelControl3.Controls.Add(this.simpleButton1);
            this.panelControl3.Controls.Add(this.panelControl2);
            this.panelControl3.Controls.Add(this.lblRange);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.teEndDate);
            this.panelControl3.Controls.Add(this.lblTitle);
            this.panelControl3.Controls.Add(this.combFinishState);
            this.panelControl3.Controls.Add(this.btnSearch);
            this.panelControl3.Controls.Add(this.btnExportExcel);
            this.panelControl3.Controls.Add(this.teStartDate);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 278);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1414, 42);
            this.panelControl3.TabIndex = 97;
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(0, 3);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Margin = new System.Windows.Forms.Padding(0);
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Size = new System.Drawing.Size(1414, 275);
            this.gcWeight.TabIndex = 98;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
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
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            this.gvWeight.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvWeight_RowClick);
            this.gvWeight.DoubleClick += new System.EventHandler(this.gvWeight_DoubleClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnViewPhoto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbTotalSuttleWeight;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbTotalMoney;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
    }
}
