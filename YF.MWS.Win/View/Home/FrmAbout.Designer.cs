namespace YF.MWS.Win.View.Home
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.lblAppName = new DevExpress.XtraEditors.LabelControl();
            this.lblRegisterDate = new DevExpress.XtraEditors.LabelControl();
            this.lblExpireDate = new DevExpress.XtraEditors.LabelControl();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.lblRegisterCode = new DevExpress.XtraEditors.LabelControl();
            this.lblMachineCode = new DevExpress.XtraEditors.LabelControl();
            this.btnCopyMachineCode = new DevExpress.XtraEditors.SimpleButton();
            this.peWaitting = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.Location = new System.Drawing.Point(25, 205);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(47, 14);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "程序:{0}";
            // 
            // lblRegisterDate
            // 
            this.lblRegisterDate.Location = new System.Drawing.Point(25, 311);
            this.lblRegisterDate.Name = "lblRegisterDate";
            this.lblRegisterDate.Size = new System.Drawing.Size(71, 14);
            this.lblRegisterDate.TabIndex = 1;
            this.lblRegisterDate.Text = "注册日期:{0}";
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.Location = new System.Drawing.Point(25, 336);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(71, 14);
            this.lblExpireDate.TabIndex = 2;
            this.lblExpireDate.Text = "过期日期:{0}";
            this.lblExpireDate.Visible = false;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(25, 231);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(59, 14);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "版本号:{0}";
            // 
            // lblRegisterCode
            // 
            this.lblRegisterCode.Location = new System.Drawing.Point(25, 286);
            this.lblRegisterCode.Name = "lblRegisterCode";
            this.lblRegisterCode.Size = new System.Drawing.Size(59, 14);
            this.lblRegisterCode.TabIndex = 4;
            this.lblRegisterCode.Text = "序列号:{0}";
            // 
            // lblMachineCode
            // 
            this.lblMachineCode.Location = new System.Drawing.Point(25, 261);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new System.Drawing.Size(59, 14);
            this.lblMachineCode.TabIndex = 18;
            this.lblMachineCode.Text = "机器码:{0}";
            // 
            // btnCopyMachineCode
            // 
            this.btnCopyMachineCode.Location = new System.Drawing.Point(369, 261);
            this.btnCopyMachineCode.Name = "btnCopyMachineCode";
            this.btnCopyMachineCode.Size = new System.Drawing.Size(75, 23);
            this.btnCopyMachineCode.TabIndex = 20;
            this.btnCopyMachineCode.Text = "复制";
            this.btnCopyMachineCode.Click += new System.EventHandler(this.btnCopyMachineCode_Click);
            // 
            // peWaitting
            // 
            this.peWaitting.Location = new System.Drawing.Point(18, 22);
            this.peWaitting.Name = "peWaitting";
            this.peWaitting.Properties.AllowFocused = false;
            this.peWaitting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peWaitting.Properties.Appearance.Options.UseBackColor = true;
            this.peWaitting.Properties.ShowMenu = false;
            this.peWaitting.Size = new System.Drawing.Size(426, 166);
            this.peWaitting.TabIndex = 17;
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 375);
            this.Controls.Add(this.btnCopyMachineCode);
            this.Controls.Add(this.lblMachineCode);
            this.Controls.Add(this.peWaitting);
            this.Controls.Add(this.lblRegisterCode);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblExpireDate);
            this.Controls.Add(this.lblRegisterDate);
            this.Controls.Add(this.lblAppName);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 414);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 412);
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于我们";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbout_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblAppName;
        private DevExpress.XtraEditors.LabelControl lblRegisterDate;
        private DevExpress.XtraEditors.LabelControl lblExpireDate;
        private DevExpress.XtraEditors.LabelControl lblVersion;
        private DevExpress.XtraEditors.LabelControl lblRegisterCode;
        private DevExpress.XtraEditors.PictureEdit peWaitting;
        private DevExpress.XtraEditors.LabelControl lblMachineCode;
        private DevExpress.XtraEditors.SimpleButton btnCopyMachineCode;
    }
}