namespace YF.MWS.Win.Uc
{
    partial class FrmCustomerSelectorPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerSelectorPad));
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPYCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContracter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teCustomerName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCustomer
            // 
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(0, 78);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(935, 412);
            this.gcCustomer.TabIndex = 26;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCustomer.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvCustomer.Appearance.Row.Options.UseFont = true;
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPYCustomerName,
            this.colCustomerName,
            this.colContracter,
            this.colTel});
            this.gvCustomer.GridControl = this.gcCustomer;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.NewItemRowText = "点此添加数据";
            this.gvCustomer.OptionsFind.AlwaysVisible = true;
            this.gvCustomer.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCustomer.OptionsView.ShowAutoFilterRow = true;
            this.gvCustomer.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            this.gvCustomer.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCustomerName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvCustomer.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvCustomer_RowClick);
            this.gvCustomer.DoubleClick += new System.EventHandler(this.gvCustomer_DoubleClick);
            // 
            // colPYCustomerName
            // 
            this.colPYCustomerName.Caption = "客户简称";
            this.colPYCustomerName.FieldName = "PYCustomerName";
            this.colPYCustomerName.Name = "colPYCustomerName";
            this.colPYCustomerName.OptionsColumn.AllowEdit = false;
            this.colPYCustomerName.Visible = true;
            this.colPYCustomerName.VisibleIndex = 0;
            this.colPYCustomerName.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户名称";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCustomerName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            this.colCustomerName.Width = 160;
            // 
            // colContracter
            // 
            this.colContracter.Caption = "联络人";
            this.colContracter.FieldName = "Contracter";
            this.colContracter.Name = "colContracter";
            this.colContracter.OptionsColumn.AllowEdit = false;
            this.colContracter.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colContracter.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colContracter.Visible = true;
            this.colContracter.VisibleIndex = 2;
            this.colContracter.Width = 103;
            // 
            // colTel
            // 
            this.colTel.Caption = "联系电话";
            this.colTel.FieldName = "Tel";
            this.colTel.Name = "colTel";
            this.colTel.OptionsColumn.AllowEdit = false;
            this.colTel.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTel.Visible = true;
            this.colTel.VisibleIndex = 3;
            this.colTel.Width = 110;
            // 
            // pcCarNo
            // 
            this.pcCarNo.Controls.Add(this.btnCancel);
            this.pcCarNo.Controls.Add(this.btnOK);
            this.pcCarNo.Controls.Add(this.lblCustomerName);
            this.pcCarNo.Controls.Add(this.teCustomerName);
            this.pcCarNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcCarNo.Location = new System.Drawing.Point(0, 0);
            this.pcCarNo.Name = "pcCarNo";
            this.pcCarNo.Size = new System.Drawing.Size(935, 78);
            this.pcCarNo.TabIndex = 25;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(789, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 49);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(609, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 49);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lblCustomerName.Location = new System.Drawing.Point(22, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(93, 30);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "客户名称:";
            // 
            // teCustomerName
            // 
            this.teCustomerName.Enabled = false;
            this.teCustomerName.Location = new System.Drawing.Point(133, 22);
            this.teCustomerName.Name = "teCustomerName";
            this.teCustomerName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.teCustomerName.Properties.Appearance.Options.UseFont = true;
            this.teCustomerName.Properties.ReadOnly = true;
            this.teCustomerName.Size = new System.Drawing.Size(429, 34);
            this.teCustomerName.TabIndex = 0;
            // 
            // FrmCustomerSelectorPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 490);
            this.Controls.Add(this.gcCustomer);
            this.Controls.Add(this.pcCarNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomerSelectorPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客户选择";
            this.Load += new System.EventHandler(this.FrmCustomerSelectorPad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colPYCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colContracter;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teCustomerName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}