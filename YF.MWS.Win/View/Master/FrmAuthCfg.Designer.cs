namespace YF.MWS.Win.View.Master
{
    partial class FrmAuthCfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthCfg));
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(108, 40);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(210, 20);
            this.tePassword.TabIndex = 20;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(46, 43);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(28, 14);
            this.lblPassword.TabIndex = 19;
            this.lblPassword.Text = "密码:";
            // 
            // btnVerify
            // 
            this.btnVerify.Image = global::YF.MWS.Win.Properties.Resources.security_16x16;
            this.btnVerify.Location = new System.Drawing.Point(108, 76);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 21;
            this.btnVerify.Text = "验证";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // FrmAuthCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 134);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.tePassword);
            this.Controls.Add(this.lblPassword);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmAuthCfg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改确认";
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.LabelControl lblPassword;
    }
}