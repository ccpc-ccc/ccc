namespace YF.MWS.Win.Uc
{
    partial class FrmMaterialSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialSelector));
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teMaterialName = new DevExpress.XtraEditors.TextEdit();
            this.gcMaterial = new DevExpress.XtraGrid.GridControl();
            this.gvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).BeginInit();
            this.SuspendLayout();
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
            this.pcCarNo.Size = new System.Drawing.Size(653, 42);
            this.pcCarNo.TabIndex = 7;
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
            // teMaterialName
            // 
            this.teMaterialName.Location = new System.Drawing.Point(66, 12);
            this.teMaterialName.Name = "teMaterialName";
            this.teMaterialName.Size = new System.Drawing.Size(242, 20);
            this.teMaterialName.TabIndex = 0;
            // 
            // gcMaterial
            // 
            this.gcMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaterial.Location = new System.Drawing.Point(0, 42);
            this.gcMaterial.MainView = this.gvMaterial;
            this.gcMaterial.Name = "gcMaterial";
            this.gcMaterial.Size = new System.Drawing.Size(653, 361);
            this.gcMaterial.TabIndex = 25;
            this.gcMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterial});
            // 
            // gvMaterial
            // 
            this.gvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaterialName,
            this.colSpecName});
            this.gvMaterial.GridControl = this.gcMaterial;
            this.gvMaterial.Name = "gvMaterial";
            this.gvMaterial.NewItemRowText = "点此添加数据";
            this.gvMaterial.OptionsFind.AlwaysVisible = true;
            this.gvMaterial.OptionsView.ShowAutoFilterRow = true;
            this.gvMaterial.OptionsView.ShowGroupPanel = false;
            this.gvMaterial.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMaterialName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMaterial.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvMaterial_RowClick);
            this.gvMaterial.DoubleClick += new System.EventHandler(this.gvMaterial_DoubleClick);
            // 
            // colMaterialName
            // 
            this.colMaterialName.Caption = "物资名称";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.OptionsColumn.AllowEdit = false;
            this.colMaterialName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaterialName.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 0;
            this.colMaterialName.Width = 180;
            // 
            // colSpecName
            // 
            this.colSpecName.Caption = "物资规格";
            this.colSpecName.FieldName = "SpecName";
            this.colSpecName.Name = "colSpecName";
            this.colSpecName.Visible = true;
            this.colSpecName.VisibleIndex = 1;
            this.colSpecName.Width = 120;
            // 
            // FrmMaterialSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 403);
            this.Controls.Add(this.gcMaterial);
            this.Controls.Add(this.pcCarNo);
            this.Name = "FrmMaterialSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物资选择";
            this.Load += new System.EventHandler(this.FrmMaterialSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teMaterialName;
        private DevExpress.XtraGrid.GridControl gcMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecName;
    }
}