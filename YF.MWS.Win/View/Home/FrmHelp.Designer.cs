namespace YF.MWS.Win.View.Home
{
    partial class FrmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHelp));
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.gvReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpenFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkOpenFile = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkOpenFile)).BeginInit();
            this.SuspendLayout();
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(0, 0);
            this.gcReport.MainView = this.gvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkOpenFile});
            this.gcReport.Size = new System.Drawing.Size(893, 460);
            this.gcReport.TabIndex = 23;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReport});
            // 
            // gvReport
            // 
            this.gvReport.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gvReport.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileName,
            this.colCreateTime,
            this.colUpdateTime,
            this.colOpenFile});
            this.gvReport.GridControl = this.gcReport;
            this.gvReport.Name = "gvReport";
            this.gvReport.NewItemRowText = "点此添加数据";
            this.gvReport.OptionsView.ShowGroupPanel = false;
            this.gvReport.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCreateTime, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUpdateTime, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colFileName
            // 
            this.colFileName.Caption = "报告名称";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.ReadOnly = true;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.OptionsColumn.ReadOnly = true;
            this.colCreateTime.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 1;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Caption = "修改时间";
            this.colUpdateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colUpdateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUpdateTime.FieldName = "UpdateTime";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.OptionsColumn.ReadOnly = true;
            this.colUpdateTime.Visible = true;
            this.colUpdateTime.VisibleIndex = 2;
            // 
            // colOpenFile
            // 
            this.colOpenFile.Caption = "浏览报告";
            this.colOpenFile.ColumnEdit = this.linkOpenFile;
            this.colOpenFile.FieldName = "OpenReport";
            this.colOpenFile.Name = "colOpenFile";
            this.colOpenFile.Visible = true;
            this.colOpenFile.VisibleIndex = 3;
            // 
            // linkOpenFile
            // 
            this.linkOpenFile.AutoHeight = false;
            this.linkOpenFile.Name = "linkOpenFile";
            this.linkOpenFile.Click += new System.EventHandler(this.linkOpenFile_Click);
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 460);
            this.Controls.Add(this.gcReport);
            this.Name = "FrmHelp";
            this.Text = "帮助文档浏览";
            this.Load += new System.EventHandler(this.FrmHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkOpenFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReport;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOpenFile;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkOpenFile;
    }
}