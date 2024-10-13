namespace YF.MWS.Win.View.Weight
{
    partial class FrmSyncWeightList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSyncWeightList));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnUploadPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.combFinishState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblWeightDate = new DevExpress.XtraEditors.LabelControl();
            this.gcWeight = new DevExpress.XtraGrid.GridControl();
            this.gvWeight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSyncState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMGrossWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMTareWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMSuttleWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMNetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeighter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinishTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnUploadPhoto);
            this.panelControl1.Controls.Add(this.btnUpload);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.teEndDate);
            this.panelControl1.Controls.Add(this.lblRange);
            this.panelControl1.Controls.Add(this.combFinishState);
            this.panelControl1.Controls.Add(this.teStartDate);
            this.panelControl1.Controls.Add(this.lblWeightDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1012, 44);
            this.panelControl1.TabIndex = 7;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Image = global::YF.MWS.Win.Properties.Resources.upload_16x16;
            this.btnUploadPhoto.Location = new System.Drawing.Point(727, 14);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(89, 23);
            this.btnUploadPhoto.TabIndex = 91;
            this.btnUploadPhoto.Text = "上传图片";
            this.btnUploadPhoto.Visible = false;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::YF.MWS.Win.Properties.Resources.upload_16x16;
            this.btnUpload.Location = new System.Drawing.Point(629, 14);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 90;
            this.btnUpload.Text = "上传";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::YF.MWS.Win.Properties.Resources.search_16x16;
            this.btnSearch.Location = new System.Drawing.Point(529, 14);
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
            // combFinishState
            // 
            this.combFinishState.EditValue = "未同步磅单";
            this.combFinishState.Location = new System.Drawing.Point(351, 15);
            this.combFinishState.Name = "combFinishState";
            this.combFinishState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combFinishState.Properties.Items.AddRange(new object[] {
            "未同步磅单",
            "已同步磅单",
            "所有磅单"});
            this.combFinishState.Size = new System.Drawing.Size(157, 20);
            this.combFinishState.TabIndex = 86;
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
            this.gcWeight.Size = new System.Drawing.Size(1012, 425);
            this.gcWeight.TabIndex = 8;
            this.gcWeight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWeight});
            // 
            // gvWeight
            // 
            this.gvWeight.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSyncState,
            this.colWeightNo,
            this.colCarNo,
            this.colMGrossWeight,
            this.colMTareWeight,
            this.colMSuttleWeight,
            this.colMNetWeight,
            this.colWeighter,
            this.colFinishTime});
            this.gvWeight.GridControl = this.gcWeight;
            this.gvWeight.Name = "gvWeight";
            this.gvWeight.OptionsPrint.AutoWidth = false;
            this.gvWeight.OptionsView.ShowFooter = true;
            this.gvWeight.OptionsView.ShowGroupPanel = false;
            this.gvWeight.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvWeight_CustomColumnDisplayText);
            // 
            // colSyncState
            // 
            this.colSyncState.Caption = "同步状态";
            this.colSyncState.FieldName = "SyncStateCaption";
            this.colSyncState.Name = "colSyncState";
            this.colSyncState.OptionsColumn.ReadOnly = true;
            this.colSyncState.Visible = true;
            this.colSyncState.VisibleIndex = 0;
            this.colSyncState.Width = 70;
            // 
            // colWeightNo
            // 
            this.colWeightNo.Caption = "磅单号";
            this.colWeightNo.FieldName = "WeightNo";
            this.colWeightNo.Name = "colWeightNo";
            this.colWeightNo.OptionsColumn.ReadOnly = true;
            this.colWeightNo.Visible = true;
            this.colWeightNo.VisibleIndex = 1;
            this.colWeightNo.Width = 116;
            // 
            // colCarNo
            // 
            this.colCarNo.Caption = "车牌号";
            this.colCarNo.FieldName = "CarNo";
            this.colCarNo.Name = "colCarNo";
            this.colCarNo.OptionsColumn.ReadOnly = true;
            this.colCarNo.Visible = true;
            this.colCarNo.VisibleIndex = 2;
            this.colCarNo.Width = 101;
            // 
            // colMGrossWeight
            // 
            this.colMGrossWeight.Caption = "毛重";
            this.colMGrossWeight.FieldName = "GrossWeight";
            this.colMGrossWeight.Name = "colMGrossWeight";
            this.colMGrossWeight.OptionsColumn.ReadOnly = true;
            this.colMGrossWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrossWeight", "{0:f2}")});
            this.colMGrossWeight.Visible = true;
            this.colMGrossWeight.VisibleIndex = 4;
            this.colMGrossWeight.Width = 94;
            // 
            // colMTareWeight
            // 
            this.colMTareWeight.Caption = "皮重";
            this.colMTareWeight.FieldName = "TareWeight";
            this.colMTareWeight.Name = "colMTareWeight";
            this.colMTareWeight.OptionsColumn.ReadOnly = true;
            this.colMTareWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TareWeight", "{0:f2}")});
            this.colMTareWeight.Visible = true;
            this.colMTareWeight.VisibleIndex = 3;
            this.colMTareWeight.Width = 94;
            // 
            // colMSuttleWeight
            // 
            this.colMSuttleWeight.Caption = "净重";
            this.colMSuttleWeight.FieldName = "SuttleWeight";
            this.colMSuttleWeight.Name = "colMSuttleWeight";
            this.colMSuttleWeight.OptionsColumn.ReadOnly = true;
            this.colMSuttleWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SuttleWeight", "{0:f2}")});
            this.colMSuttleWeight.Visible = true;
            this.colMSuttleWeight.VisibleIndex = 5;
            this.colMSuttleWeight.Width = 94;
            // 
            // colMNetWeight
            // 
            this.colMNetWeight.Caption = "实重";
            this.colMNetWeight.FieldName = "NetWeight";
            this.colMNetWeight.Name = "colMNetWeight";
            this.colMNetWeight.OptionsColumn.ReadOnly = true;
            this.colMNetWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetWeight", "{0:f2}")});
            this.colMNetWeight.Visible = true;
            this.colMNetWeight.VisibleIndex = 6;
            this.colMNetWeight.Width = 94;
            // 
            // colWeighter
            // 
            this.colWeighter.Caption = "司磅员";
            this.colWeighter.FieldName = "Weighter";
            this.colWeighter.Name = "colWeighter";
            this.colWeighter.OptionsColumn.ReadOnly = true;
            this.colWeighter.Visible = true;
            this.colWeighter.VisibleIndex = 7;
            this.colWeighter.Width = 104;
            // 
            // colFinishTime
            // 
            this.colFinishTime.Caption = "过磅时间";
            this.colFinishTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colFinishTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFinishTime.FieldName = "FinishTime";
            this.colFinishTime.Name = "colFinishTime";
            this.colFinishTime.OptionsColumn.ReadOnly = true;
            this.colFinishTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colFinishTime.Visible = true;
            this.colFinishTime.VisibleIndex = 8;
            this.colFinishTime.Width = 227;
            // 
            // FrmSyncWeightList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 469);
            this.Controls.Add(this.gcWeight);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmSyncWeightList";
            this.Text = "磅单数据同步";
            this.Load += new System.EventHandler(this.FrmSyncWeightList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combFinishState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.ComboBoxEdit combFinishState;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.LabelControl lblWeightDate;
        private DevExpress.XtraGrid.GridControl gcWeight;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMGrossWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMTareWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMSuttleWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMNetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSyncState;
        private DevExpress.XtraGrid.Columns.GridColumn colWeighter;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishTime;
        private DevExpress.XtraEditors.SimpleButton btnUploadPhoto;

    }
}