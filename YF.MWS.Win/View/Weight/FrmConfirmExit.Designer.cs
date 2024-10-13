namespace YF.MWS.Win.View.Weight
{
    partial class FrmConfirmExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfirmExit));
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(54, 81);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.tePassword.Properties.Appearance.Options.UseFont = true;
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(292, 34);
            this.tePassword.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Image = global::YF.MWS.Win.Properties.Resources.apply_32x32;
            this.btnOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnOK.Location = new System.Drawing.Point(39, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(143, 90);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(108, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 31);
            this.lblStatus.TabIndex = 31;
            this.lblStatus.Text = "输入密码确认";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = global::YF.MWS.Win.Properties.Resources.cancel_32x32;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(216, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 90);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmConfirmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 264);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tePassword);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfirmExit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "确认退出";
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}