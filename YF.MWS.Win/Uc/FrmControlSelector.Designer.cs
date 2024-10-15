namespace YF.MWS.Win.Uc
{
    partial class FrmControlSelector {
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
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.gcControl = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControlId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcControl)).BeginInit();
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
            // gcControl
            // 
            this.gcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcControl.Location = new System.Drawing.Point(0, 42);
            this.gcControl.MainView = this.gvCustomer;
            this.gcControl.Name = "gcControl";
            this.gcControl.Size = new System.Drawing.Size(594, 377);
            this.gcControl.TabIndex = 24;
            this.gcControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colControlId,
            this.colControlName,
            this.colFieldName,
            this.colCaption});
            this.gvCustomer.GridControl = this.gcControl;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.NewItemRowText = "点此添加数据";
            this.gvCustomer.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvCustomer.OptionsView.ShowAutoFilterRow = true;
            this.gvCustomer.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvCustomer.OptionsView.ShowGroupPanel = false;
            this.gvCustomer.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFieldName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvCustomer.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvCustomer_RowClick);
            this.gvCustomer.DoubleClick += new System.EventHandler(this.gvCustomer_DoubleClick);
            // 
            // colControlName
            // 
            this.colControlName.Caption = "控件名称";
            this.colControlName.FieldName = "ControlName";
            this.colControlName.Name = "colControlName";
            this.colControlName.OptionsColumn.AllowEdit = false;
            this.colControlName.Visible = true;
            this.colControlName.VisibleIndex = 0;
            this.colControlName.Width = 100;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "控件字段";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.OptionsColumn.AllowEdit = false;
            this.colFieldName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFieldName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 1;
            this.colFieldName.Width = 160;
            // 
            // colCaption
            // 
            this.colCaption.Caption = "控件标题";
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.OptionsColumn.AllowEdit = false;
            this.colCaption.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 2;
            this.colCaption.Width = 103;
            // 
            // colControlId
            // 
            this.colControlId.Caption = "gridColumn1";
            this.colControlId.FieldName = "ControlId";
            this.colControlId.Name = "colControlId";
            // 
            // FrmControlSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 419);
            this.Controls.Add(this.gcControl);
            this.Controls.Add(this.pcCarNo);
            this.Name = "FrmControlSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控件选择";
            this.Load += new System.EventHandler(this.FrmCustomerSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teCustomerName;
        private DevExpress.XtraGrid.GridControl gcControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colControlName;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colControlId;
    }
}