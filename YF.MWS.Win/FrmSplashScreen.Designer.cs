namespace YF.MWS.Win
{
    partial class FrmSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplashScreen));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lblCopyright = new DevExpress.XtraEditors.LabelControl();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.peWaitting = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(23, 213);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 11);
            this.marqueeProgressBarControl1.TabIndex = 5;
            // 
            // lblCopyright
            // 
            this.lblCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCopyright.Location = new System.Drawing.Point(109, 258);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 14);
            this.lblCopyright.TabIndex = 6;
            this.lblCopyright.Text = "武汉客到科技有限公司 © 2017-2023";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(23, 190);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(72, 14);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "系统启动中...";
            // 
            // peWaitting
            // 
            this.peWaitting.EditValue = ((object)(resources.GetObject("peWaitting.EditValue")));
            this.peWaitting.Location = new System.Drawing.Point(12, 11);
            this.peWaitting.Name = "peWaitting";
            this.peWaitting.Properties.AllowFocused = false;
            this.peWaitting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peWaitting.Properties.Appearance.Options.UseBackColor = true;
            this.peWaitting.Properties.ShowMenu = false;
            this.peWaitting.Size = new System.Drawing.Size(426, 166);
            this.peWaitting.TabIndex = 9;
            // 
            // FrmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 295);
            this.Controls.Add(this.peWaitting);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Name = "FrmSplashScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmSplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl lblCopyright;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.PictureEdit peWaitting;
    }
}
