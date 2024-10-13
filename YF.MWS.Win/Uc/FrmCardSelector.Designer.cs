namespace YF.MWS.Win.Uc
{
    partial class FrmCardSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardSelector));
            this.pcCarNo = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.teCardNo = new DevExpress.XtraEditors.TextEdit();
            this.gcPlanCard = new DevExpress.XtraGrid.GridControl();
            this.gvPlanCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCarNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDriverName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).BeginInit();
            this.pcCarNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanCard)).BeginInit();
            this.SuspendLayout();
            // 
            // pcCarNo
            // 
            this.pcCarNo.Controls.Add(this.btnCancel);
            this.pcCarNo.Controls.Add(this.btnOK);
            this.pcCarNo.Controls.Add(this.lblCustomerName);
            this.pcCarNo.Controls.Add(this.teCardNo);
            this.pcCarNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcCarNo.Location = new System.Drawing.Point(0, 0);
            this.pcCarNo.Name = "pcCarNo";
            this.pcCarNo.Size = new System.Drawing.Size(526, 42);
            this.pcCarNo.TabIndex = 8;
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
            // teCardNo
            // 
            this.teCardNo.Location = new System.Drawing.Point(66, 12);
            this.teCardNo.Name = "teCardNo";
            this.teCardNo.Size = new System.Drawing.Size(242, 20);
            this.teCardNo.TabIndex = 0;
            // 
            // gcPlanCard
            // 
            this.gcPlanCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPlanCard.Location = new System.Drawing.Point(0, 42);
            this.gcPlanCard.MainView = this.gvPlanCard;
            this.gcPlanCard.Name = "gcPlanCard";
            this.gcPlanCard.Size = new System.Drawing.Size(526, 305);
            this.gcPlanCard.TabIndex = 26;
            this.gcPlanCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlanCard});
            // 
            // gvPlanCard
            // 
            this.gvPlanCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCardNo,
            this.colCarNo,
            this.colDriverName});
            this.gvPlanCard.GridControl = this.gcPlanCard;
            this.gvPlanCard.Name = "gvPlanCard";
            this.gvPlanCard.NewItemRowText = "点此添加数据";
            this.gvPlanCard.OptionsFind.AlwaysVisible = true;
            this.gvPlanCard.OptionsView.ShowGroupPanel = false;
            this.gvPlanCard.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCardNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPlanCard.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPlanCard_RowClick);
            this.gvPlanCard.DoubleClick += new System.EventHandler(this.gvPlanCard_DoubleClick);
            // 
            // colCardNo
            // 
            this.colCardNo.Caption = "卡号";
            this.colCardNo.FieldName = "CardNo";
            this.colCardNo.Name = "colCardNo";
            this.colCardNo.OptionsColumn.AllowEdit = false;
            this.colCardNo.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCardNo.Visible = true;
            this.colCardNo.VisibleIndex = 0;
            this.colCardNo.Width = 220;
            // 
            // colCarNo
            // 
            this.colCarNo.Caption = "车牌号";
            this.colCarNo.FieldName = "CarNo";
            this.colCarNo.Name = "colCarNo";
            this.colCarNo.OptionsColumn.AllowEdit = false;
            this.colCarNo.Visible = true;
            this.colCarNo.VisibleIndex = 1;
            this.colCarNo.Width = 150;
            // 
            // colDriverName
            // 
            this.colDriverName.Caption = "司机";
            this.colDriverName.FieldName = "DriverName";
            this.colDriverName.Name = "colDriverName";
            this.colDriverName.Visible = true;
            this.colDriverName.VisibleIndex = 2;
            this.colDriverName.Width = 138;
            // 
            // FrmCardSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 347);
            this.Controls.Add(this.gcPlanCard);
            this.Controls.Add(this.pcCarNo);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmCardSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IC卡选择";
            this.Load += new System.EventHandler(this.FrmCardSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcCarNo)).EndInit();
            this.pcCarNo.ResumeLayout(false);
            this.pcCarNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlanCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlanCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcCarNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.TextEdit teCardNo;
        private DevExpress.XtraGrid.GridControl gcPlanCard;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlanCard;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCarNo;
        private DevExpress.XtraGrid.Columns.GridColumn colDriverName;
    }
}