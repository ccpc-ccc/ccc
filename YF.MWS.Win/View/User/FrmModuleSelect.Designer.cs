namespace YF.MWS.Win.View.User
{
    partial class FrmModuleSelect
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
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teParentName = new DevExpress.XtraEditors.TextEdit();
            this.treeModule = new DevExpress.XtraTreeList.TreeList();
            this.colModuleName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teParentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).BeginInit();
            this.SuspendLayout();
            // 
            // pcCarNo
            // 
            this.pcCarNo.Controls.Add(this.btnCancel);
            this.pcCarNo.Controls.Add(this.btnOK);
            this.pcCarNo.Controls.Add(this.lblCustomerName);
            this.pcCarNo.Controls.Add(this.teParentName);
            this.pcCarNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcCarNo.Location = new System.Drawing.Point(0, 0);
            this.pcCarNo.Name = "pcCarNo";
            this.pcCarNo.Size = new System.Drawing.Size(581, 42);
            this.pcCarNo.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(436, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.apply_16x16;
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
            // teParentName
            // 
            this.teParentName.Enabled = false;
            this.teParentName.Location = new System.Drawing.Point(66, 12);
            this.teParentName.Name = "teParentName";
            this.teParentName.Size = new System.Drawing.Size(242, 20);
            this.teParentName.TabIndex = 0;
            // 
            // treeModule
            // 
            this.treeModule.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colModuleName});
            this.treeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModule.KeyFieldName = "Id";
            this.treeModule.Location = new System.Drawing.Point(0, 42);
            this.treeModule.Name = "treeModule";
            this.treeModule.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeModule.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.treeModule.ParentFieldName = "ParentId";
            this.treeModule.Size = new System.Drawing.Size(581, 622);
            this.treeModule.TabIndex = 8;
            this.treeModule.Click += new System.EventHandler(this.treeModule_Click);
            this.treeModule.DoubleClick += new System.EventHandler(this.treeModule_DoubleClick);
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "模块名称";
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.MinWidth = 32;
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.OptionsColumn.AllowEdit = false;
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 0;
            this.colModuleName.Width = 91;
            // 
            // FrmModuleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 664);
            this.Controls.Add(this.treeModule);
            this.Controls.Add(this.pcCarNo);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmModuleSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块选择";
            this.Load += new System.EventHandler(this.FrmModuleSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teParentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teParentName;
        private DevExpress.XtraTreeList.TreeList treeModule;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleName;
    }
}