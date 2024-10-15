namespace YF.MWS.Win.View.User
{
    partial class FrmAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuth));
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.teAuthCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAuthCode = new DevExpress.XtraEditors.LabelControl();
            this.lblRandCode = new DevExpress.XtraEditors.LabelControl();
            this.teRandCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(125, 121);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 18;
            this.btnVerify.Text = "验证";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // teAuthCode
            // 
            this.teAuthCode.Location = new System.Drawing.Point(125, 75);
            this.teAuthCode.Name = "teAuthCode";
            this.teAuthCode.Size = new System.Drawing.Size(134, 20);
            this.teAuthCode.TabIndex = 17;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.Location = new System.Drawing.Point(61, 78);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(40, 14);
            this.lblAuthCode.TabIndex = 16;
            this.lblAuthCode.Text = "授权码:";
            // 
            // lblRandCode
            // 
            this.lblRandCode.Location = new System.Drawing.Point(61, 39);
            this.lblRandCode.Name = "lblRandCode";
            this.lblRandCode.Size = new System.Drawing.Size(40, 14);
            this.lblRandCode.TabIndex = 19;
            this.lblRandCode.Text = "随机码:";
            // 
            // teRandCode
            // 
            this.teRandCode.Location = new System.Drawing.Point(125, 36);
            this.teRandCode.Name = "teRandCode";
            this.teRandCode.Properties.ReadOnly = true;
            this.teRandCode.Size = new System.Drawing.Size(134, 20);
            this.teRandCode.TabIndex = 29;
            // 
            // FrmAuth
            // 
            this.AcceptButton = this.btnVerify;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 165);
            this.Controls.Add(this.teRandCode);
            this.Controls.Add(this.lblRandCode);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.teAuthCode);
            this.Controls.Add(this.lblAuthCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAuth";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权验证";
            this.Load += new System.EventHandler(this.FrmAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.TextEdit teAuthCode;
        private DevExpress.XtraEditors.LabelControl lblAuthCode;
        private DevExpress.XtraEditors.LabelControl lblRandCode;
        private DevExpress.XtraEditors.TextEdit teRandCode;
    }
}