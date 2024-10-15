namespace YF.MWS.Win.Uc
{
    partial class FrmMaterialSelectorPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialSelectorPad));
            this.gcMaterial = new DevExpress.XtraGrid.GridControl();
            this.gvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPYMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teMaterialName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMaterial
            // 
            this.gcMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaterial.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gcMaterial.Location = new System.Drawing.Point(0, 78);
            this.gcMaterial.MainView = this.gvMaterial;
            this.gcMaterial.Name = "gcMaterial";
            this.gcMaterial.Size = new System.Drawing.Size(990, 428);
            this.gcMaterial.TabIndex = 27;
            this.gcMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterial});
            // 
            // gvMaterial
            // 
            this.gvMaterial.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvMaterial.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvMaterial.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvMaterial.Appearance.DetailTip.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.DetailTip.Options.UseFont = true;
            this.gvMaterial.Appearance.Empty.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.Empty.Options.UseFont = true;
            this.gvMaterial.Appearance.EvenRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.EvenRow.Options.UseFont = true;
            this.gvMaterial.Appearance.FilterCloseButton.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvMaterial.Appearance.FilterPanel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FilterPanel.Options.UseFont = true;
            this.gvMaterial.Appearance.FixedLine.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FixedLine.Options.UseFont = true;
            this.gvMaterial.Appearance.FocusedCell.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FocusedCell.Options.UseFont = true;
            this.gvMaterial.Appearance.FocusedRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FocusedRow.Options.UseFont = true;
            this.gvMaterial.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.FooterPanel.Options.UseFont = true;
            this.gvMaterial.Appearance.GroupButton.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.GroupButton.Options.UseFont = true;
            this.gvMaterial.Appearance.GroupFooter.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.GroupFooter.Options.UseFont = true;
            this.gvMaterial.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.GroupPanel.Options.UseFont = true;
            this.gvMaterial.Appearance.GroupRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.GroupRow.Options.UseFont = true;
            this.gvMaterial.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMaterial.Appearance.HideSelectionRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvMaterial.Appearance.HorzLine.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.HorzLine.Options.UseFont = true;
            this.gvMaterial.Appearance.OddRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.OddRow.Options.UseFont = true;
            this.gvMaterial.Appearance.Preview.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.Preview.Options.UseFont = true;
            this.gvMaterial.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.Row.Options.UseFont = true;
            this.gvMaterial.Appearance.RowSeparator.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.RowSeparator.Options.UseFont = true;
            this.gvMaterial.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMaterial.Appearance.TopNewRow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.TopNewRow.Options.UseFont = true;
            this.gvMaterial.Appearance.VertLine.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.VertLine.Options.UseFont = true;
            this.gvMaterial.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.gvMaterial.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaterialName,
            this.colPYMaterialName,
            this.colMaterialCode});
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
            this.colMaterialName.Width = 185;
            // 
            // colPYMaterialName
            // 
            this.colPYMaterialName.Caption = "物资简称";
            this.colPYMaterialName.FieldName = "PYMaterialName";
            this.colPYMaterialName.Name = "colPYMaterialName";
            this.colPYMaterialName.OptionsColumn.AllowEdit = false;
            this.colPYMaterialName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPYMaterialName.Visible = true;
            this.colPYMaterialName.VisibleIndex = 1;
            this.colPYMaterialName.Width = 119;
            // 
            // colMaterialCode
            // 
            this.colMaterialCode.Caption = "物资编码";
            this.colMaterialCode.FieldName = "MaterialCode";
            this.colMaterialCode.Name = "colMaterialCode";
            this.colMaterialCode.OptionsColumn.AllowEdit = false;
            this.colMaterialCode.Visible = true;
            this.colMaterialCode.VisibleIndex = 2;
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
            this.pcCarNo.Size = new System.Drawing.Size(990, 78);
            this.pcCarNo.TabIndex = 26;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(844, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 49);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(682, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 49);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lblCustomerName.Location = new System.Drawing.Point(22, 24);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(93, 30);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "物料名称:";
            // 
            // teMaterialName
            // 
            this.teMaterialName.Location = new System.Drawing.Point(138, 23);
            this.teMaterialName.Name = "teMaterialName";
            this.teMaterialName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.teMaterialName.Properties.Appearance.Options.UseFont = true;
            this.teMaterialName.Size = new System.Drawing.Size(492, 34);
            this.teMaterialName.TabIndex = 0;
            // 
            // FrmMaterialSelectorPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 506);
            this.Controls.Add(this.gcMaterial);
            this.Controls.Add(this.pcCarNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaterialSelectorPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择物料";
            this.Load += new System.EventHandler(this.FrmMaterialSelectorPad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colPYMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialCode;
        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teMaterialName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}