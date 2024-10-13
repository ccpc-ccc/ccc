namespace YF.MWS.Win.Uc
{
    partial class WeightTempList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.combRecordCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblWeightDate = new DevExpress.XtraEditors.LabelControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWeightNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeighterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sfdFileSave = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combRecordCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.combRecordCount);
            this.panelControl1.Controls.Add(this.btnExportExcel);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.teEndDate);
            this.panelControl1.Controls.Add(this.lblRange);
            this.panelControl1.Controls.Add(this.teStartDate);
            this.panelControl1.Controls.Add(this.lblWeightDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(935, 44);
            this.panelControl1.TabIndex = 7;
            // 
            // combRecordCount
            // 
            this.combRecordCount.EditValue = "前10条";
            this.combRecordCount.Location = new System.Drawing.Point(348, 15);
            this.combRecordCount.Name = "combRecordCount";
            this.combRecordCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combRecordCount.Properties.Items.AddRange(new object[] {
            "前10条",
            "前20条",
            "前30条",
            "前50条"});
            this.combRecordCount.Size = new System.Drawing.Size(119, 20);
            this.combRecordCount.TabIndex = 91;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::YF.MWS.Win.Properties.Resources.exportexcel_16x16;
            this.btnExportExcel.Location = new System.Drawing.Point(573, 13);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 90;
            this.btnExportExcel.Text = "导出";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::YF.MWS.Win.Properties.Resources.search_16x16;
            this.btnSearch.Location = new System.Drawing.Point(487, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 89;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // teEndDate
            // 
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(217, 15);
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
            this.lblRange.Location = new System.Drawing.Point(189, 18);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(12, 14);
            this.lblRange.TabIndex = 87;
            this.lblRange.Text = "至";
            // 
            // teStartDate
            // 
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(76, 15);
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
            this.lblWeightDate.Location = new System.Drawing.Point(14, 18);
            this.lblWeightDate.Name = "lblWeightDate";
            this.lblWeightDate.Size = new System.Drawing.Size(52, 14);
            this.lblWeightDate.TabIndex = 40;
            this.lblWeightDate.Text = "过磅日期:";
            // 
            // gcWeight
            // 
            this.gcWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWeight.Location = new System.Drawing.Point(0, 44);
            this.gcWeight.MainView = this.gvWeight;
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Size = new System.Drawing.Size(935, 319);
            this.gcWeight.TabIndex = 8;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWeightNo,
            this.colWeight,
            this.colWeightTime,
            this.colUnit,
            this.colWeighterName});
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsBehavior.Editable = false;
            this.gvWeight.OptionsBehavior.ReadOnly = true;
            this.gvWeight.OptionsPrint.AutoWidth = false;
            this.gvWeight.OptionsView.ShowFooter = true;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            // 
            // colWeightNo
            // 
            this.colWeightNo.Caption = "编号";
            this.colWeightNo.FieldName = "WeightNo";
            this.colWeightNo.Name = "colWeightNo";
            this.colWeightNo.Visible = true;
            this.colWeightNo.VisibleIndex = 0;
            this.colWeightNo.Width = 210;
            // 
            // colWeight
            // 
            this.colWeight.Caption = "重量";
            this.colWeight.FieldName = "Weight";
            this.colWeight.Name = "colWeight";
            this.colWeight.Visible = true;
            this.colWeight.VisibleIndex = 1;
            this.colWeight.Width = 150;
            // 
            // colWeightTime
            // 
            this.colWeightTime.Caption = "称重时间";
            this.colWeightTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colWeightTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colWeightTime.FieldName = "WeightTime";
            this.colWeightTime.Name = "colWeightTime";
            this.colWeightTime.Visible = true;
            this.colWeightTime.VisibleIndex = 2;
            this.colWeightTime.Width = 120;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "计量单位";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 3;
            this.colUnit.Width = 193;
            // 
            // colWeighterName
            // 
            this.colWeighterName.Caption = "司磅员";
            this.colWeighterName.FieldName = "WeighterName";
            this.colWeighterName.Name = "colWeighterName";
            this.colWeighterName.Visible = true;
            this.colWeighterName.VisibleIndex = 4;
            this.colWeighterName.Width = 244;
            // 
            // sfdFileSave
            // 
            this.sfdFileSave.Filter = "Excel 文件|*.xls";
            // 
            // WeightTempList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcWeight);
            this.Controls.Add(this.panelControl1);
            this.Name = "WeightTempList";
            this.Size = new System.Drawing.Size(935, 363);
            this.Load += new System.EventHandler(this.WeightTempList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combRecordCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combRecordCount;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.LabelControl lblWeightDate;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colWeighterName;
        private System.Windows.Forms.SaveFileDialog sfdFileSave;
    }
}
