namespace YF.MWS.Win.Uc
{
    partial class FrmCustomerSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerSelector));
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPYCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContracter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
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
            this.pcCarNo.Size = new System.Drawing.Size(594, 42);
            this.pcCarNo.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(436, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(333, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Location = new System.Drawing.Point(23, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(28, 14);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "名称:";
            // 
            // teCustomerName
            // 
            this.teCustomerName.Enabled = false;
            this.teCustomerName.Location = new System.Drawing.Point(66, 12);
            this.teCustomerName.Name = "teCustomerName";
            this.teCustomerName.Size = new System.Drawing.Size(242, 20);
            this.teCustomerName.TabIndex = 0;
            // 
            // gcCustomer
            // 
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(0, 42);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(594, 377);
            this.gcCustomer.TabIndex = 24;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPYCustomerName,
            this.colCustomerName,
            this.colCustomerType,
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
            // colCustomerType
            // 
            this.colCustomerType.Caption = "客户类型";
            this.colCustomerType.FieldName = "CustomerType";
            this.colCustomerType.Name = "colCustomerType";
            this.colCustomerType.OptionsColumn.AllowEdit = false;
            this.colCustomerType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCustomerType.Visible = true;
            this.colCustomerType.VisibleIndex = 2;
            this.colCustomerType.Width = 103;
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
            this.colContracter.VisibleIndex = 3;
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
            this.colTel.VisibleIndex = 4;
            this.colTel.Width = 110;
            // 
            // FrmCustomerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 419);
            this.Controls.Add(this.gcCustomer);
            this.Controls.Add(this.pcCarNo);
            this.Name = "FrmCustomerSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户单位选择";
            this.Load += new System.EventHandler(this.FrmCustomerSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teCustomerName;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colPYCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerType;
        private DevExpress.XtraGrid.Columns.GridColumn colContracter;
        private DevExpress.XtraGrid.Columns.GridColumn colTel;
    }
}