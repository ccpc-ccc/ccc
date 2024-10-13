namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeightPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightPad));
            this.gpMainWeight = new DevExpress.XtraEditors.GroupControl();
            this.teCustomer = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.teMaterial = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectMaterial = new DevExpress.XtraEditors.SimpleButton();
            this.teCarNo = new DevExpress.XtraEditors.TextEdit();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectCarNo = new DevExpress.XtraEditors.SimpleButton();
            this.gpWeight = new DevExpress.XtraEditors.GroupControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnFinishInput = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblWeight = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).BeginInit();
            this.gpMainWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpWeight)).BeginInit();
            this.gpWeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpMainWeight
            // 
            this.gpMainWeight.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gpMainWeight.Appearance.Options.UseFont = true;
            this.gpMainWeight.Controls.Add(this.teCustomer);
            this.gpMainWeight.Controls.Add(this.lblCustomer);
            this.gpMainWeight.Controls.Add(this.btnSelectCustomer);
            this.gpMainWeight.Controls.Add(this.teMaterial);
            this.gpMainWeight.Controls.Add(this.lblMaterial);
            this.gpMainWeight.Controls.Add(this.btnSelectMaterial);
            this.gpMainWeight.Controls.Add(this.teCarNo);
            this.gpMainWeight.Controls.Add(this.lblCarNo);
            this.gpMainWeight.Controls.Add(this.btnSelectCarNo);
            this.gpMainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpMainWeight.Location = new System.Drawing.Point(0, 191);
            this.gpMainWeight.Name = "gpMainWeight";
            this.gpMainWeight.Size = new System.Drawing.Size(1366, 549);
            this.gpMainWeight.TabIndex = 41;
            this.gpMainWeight.Text = "磅单信息";
            // 
            // teCustomer
            // 
            this.teCustomer.Location = new System.Drawing.Point(108, 240);
            this.teCustomer.Name = "teCustomer";
            this.teCustomer.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.teCustomer.Properties.Appearance.Options.UseFont = true;
            this.teCustomer.Size = new System.Drawing.Size(462, 34);
            this.teCustomer.TabIndex = 12;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lblCustomer.Location = new System.Drawing.Point(39, 241);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(49, 30);
            this.lblCustomer.TabIndex = 11;
            this.lblCustomer.Text = "客户:";
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnSelectCustomer.Appearance.Options.UseFont = true;
            this.btnSelectCustomer.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectCustomer.Location = new System.Drawing.Point(624, 229);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(156, 60);
            this.btnSelectCustomer.TabIndex = 10;
            this.btnSelectCustomer.Text = "选择";
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // teMaterial
            // 
            this.teMaterial.Location = new System.Drawing.Point(108, 161);
            this.teMaterial.Name = "teMaterial";
            this.teMaterial.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.teMaterial.Properties.Appearance.Options.UseFont = true;
            this.teMaterial.Size = new System.Drawing.Size(462, 34);
            this.teMaterial.TabIndex = 9;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lblMaterial.Location = new System.Drawing.Point(39, 162);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(49, 30);
            this.lblMaterial.TabIndex = 8;
            this.lblMaterial.Text = "物料:";
            // 
            // btnSelectMaterial
            // 
            this.btnSelectMaterial.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnSelectMaterial.Appearance.Options.UseFont = true;
            this.btnSelectMaterial.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectMaterial.Location = new System.Drawing.Point(624, 146);
            this.btnSelectMaterial.Name = "btnSelectMaterial";
            this.btnSelectMaterial.Size = new System.Drawing.Size(156, 60);
            this.btnSelectMaterial.TabIndex = 7;
            this.btnSelectMaterial.Text = "选择";
            this.btnSelectMaterial.Click += new System.EventHandler(this.btnSelectMaterial_Click);
            // 
            // teCarNo
            // 
            this.teCarNo.Location = new System.Drawing.Point(108, 81);
            this.teCarNo.Name = "teCarNo";
            this.teCarNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.teCarNo.Properties.Appearance.Options.UseFont = true;
            this.teCarNo.Size = new System.Drawing.Size(462, 34);
            this.teCarNo.TabIndex = 6;
            // 
            // lblCarNo
            // 
            this.lblCarNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lblCarNo.Location = new System.Drawing.Point(39, 82);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(49, 30);
            this.lblCarNo.TabIndex = 5;
            this.lblCarNo.Text = "车牌:";
            // 
            // btnSelectCarNo
            // 
            this.btnSelectCarNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnSelectCarNo.Appearance.Options.UseFont = true;
            this.btnSelectCarNo.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectCarNo.Location = new System.Drawing.Point(624, 61);
            this.btnSelectCarNo.Name = "btnSelectCarNo";
            this.btnSelectCarNo.Size = new System.Drawing.Size(156, 60);
            this.btnSelectCarNo.TabIndex = 4;
            this.btnSelectCarNo.Text = "选择";
            this.btnSelectCarNo.Click += new System.EventHandler(this.btnSelectCarNo_Click);
            // 
            // gpWeight
            // 
            this.gpWeight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.gpWeight.Appearance.Options.UseBackColor = true;
            this.gpWeight.Controls.Add(this.lblStatus);
            this.gpWeight.Controls.Add(this.btnFinishInput);
            this.gpWeight.Controls.Add(this.btnClose);
            this.gpWeight.Controls.Add(this.lblWeight);
            this.gpWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpWeight.Location = new System.Drawing.Point(0, 0);
            this.gpWeight.Name = "gpWeight";
            this.gpWeight.Size = new System.Drawing.Size(1366, 191);
            this.gpWeight.TabIndex = 40;
            this.gpWeight.Text = "电子过磅区";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(45, 143);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 31);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "等待完成输入";
            // 
            // btnFinishInput
            // 
            this.btnFinishInput.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnFinishInput.Appearance.Options.UseFont = true;
            this.btnFinishInput.Image = global::YF.MWS.Win.Properties.Resources.apply_32x32;
            this.btnFinishInput.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnFinishInput.Location = new System.Drawing.Point(607, 47);
            this.btnFinishInput.Name = "btnFinishInput";
            this.btnFinishInput.Size = new System.Drawing.Size(179, 90);
            this.btnFinishInput.TabIndex = 29;
            this.btnFinishInput.Text = "完成输入(F)";
            this.btnFinishInput.Click += new System.EventHandler(this.btnFinishInput_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = global::YF.MWS.Win.Properties.Resources.close_32x32;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(837, 47);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 90);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "退出(E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.Appearance.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Appearance.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblWeight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblWeight.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWeight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWeight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblWeight.LineColor = System.Drawing.Color.White;
            this.lblWeight.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblWeight.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.lblWeight.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lblWeight.Location = new System.Drawing.Point(45, 56);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(404, 70);
            this.lblWeight.TabIndex = 13;
            this.lblWeight.Text = "0.00";
            // 
            // FrmWeightPad
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 740);
            this.Controls.Add(this.gpMainWeight);
            this.Controls.Add(this.gpWeight);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmWeightPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "触摸屏输入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWeightPad_FormClosed);
            this.Load += new System.EventHandler(this.FrmWeightPad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpMainWeight)).EndInit();
            this.gpMainWeight.ResumeLayout(false);
            this.gpMainWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpWeight)).EndInit();
            this.gpWeight.ResumeLayout(false);
            this.gpWeight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpMainWeight;
        private DevExpress.XtraEditors.GroupControl gpWeight;
        private DevExpress.XtraEditors.LabelControl lblWeight;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelectCarNo;
        private DevExpress.XtraEditors.TextEdit teCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.SimpleButton btnSelectCustomer;
        private DevExpress.XtraEditors.TextEdit teMaterial;
        private DevExpress.XtraEditors.LabelControl lblMaterial;
        private DevExpress.XtraEditors.SimpleButton btnSelectMaterial;
        private DevExpress.XtraEditors.TextEdit teCarNo;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.SimpleButton btnFinishInput;
        private DevExpress.XtraEditors.LabelControl lblStatus;


    }
}