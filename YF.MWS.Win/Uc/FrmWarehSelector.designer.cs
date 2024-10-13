namespace YF.MWS.Win.Uc
{
    partial class FrmWarehSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWarehSelector));
            this.gcWareh = new DevExpress.XtraGrid.GridControl();
            this.gvWareh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWareName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teMaterialName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcWareh
            // 
            this.gcWareh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWareh.Location = new System.Drawing.Point(0, 42);
            this.gcWareh.MainView = this.gvWareh;
            this.gcWareh.Name = "gcWareh";
            this.gcWareh.Size = new System.Drawing.Size(526, 365);
            this.gcWareh.TabIndex = 27;
            this.gcWareh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWareh});
            // 
            // gvWareh
            // 
            this.gvWareh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWareName,
            this.colWarehCode});
            this.gvWareh.GridControl = this.gcWareh;
            this.gvWareh.Name = "gvWareh";
            this.gvWareh.NewItemRowText = "点此添加数据";
            this.gvWareh.OptionsFind.AlwaysVisible = true;
            this.gvWareh.OptionsView.ShowAutoFilterRow = true;
            this.gvWareh.OptionsView.ShowGroupPanel = false;
            this.gvWareh.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWareName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvWareh.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvWareh_RowClick);
            this.gvWareh.DoubleClick += new System.EventHandler(this.gvWareh_DoubleClick);
            // 
            // colWareName
            // 
            this.colWareName.Caption = "仓库名称";
            this.colWareName.FieldName = "WarehName";
            this.colWareName.Name = "colWareName";
            this.colWareName.OptionsColumn.AllowEdit = false;
            this.colWareName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colWareName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colWareName.Visible = true;
            this.colWareName.VisibleIndex = 0;
            this.colWareName.Width = 180;
            // 
            // colWarehCode
            // 
            this.colWarehCode.Caption = "仓库编码";
            this.colWarehCode.FieldName = "WarehCode";
            this.colWarehCode.Name = "colWarehCode";
            this.colWarehCode.Visible = true;
            this.colWarehCode.VisibleIndex = 1;
            this.colWarehCode.Width = 120;
            // 
            // pcCarNo
            // 
            this.pcCarNo.Controls.Add(this.btnCancel);
            this.pcCarNo.Controls.Add(this.btnOK);
            this.pcCarNo.Controls.Add(this.lblCustomerName);
            this.pcCarNo.Controls.Add(this.teMaterialName);
            this.pcCarNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcCarNo.Location = new System.Drawing.Point(0, 0);
            this.pcCarNo.Name = "pcCarNo";
            this.pcCarNo.Size = new System.Drawing.Size(526, 42);
            this.pcCarNo.TabIndex = 26;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::YF.MWS.Win.Properties.Resources.cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(436, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::YF.MWS.Win.Properties.Resources.apply_16x16;
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
            // teMaterialName
            // 
            this.teMaterialName.Location = new System.Drawing.Point(66, 12);
            this.teMaterialName.Name = "teMaterialName";
            this.teMaterialName.Size = new System.Drawing.Size(242, 20);
            this.teMaterialName.TabIndex = 0;
            // 
            // FrmWarehSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 407);
            this.Controls.Add(this.gcWareh);
            this.Controls.Add(this.pcCarNo);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWarehSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓库选择";
            this.Load += new System.EventHandler(this.FrmWarehSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWareh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcWareh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWareh;
        private DevExpress.XtraGrid.Columns.GridColumn colWareName;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehCode;
        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teMaterialName;
    }
}