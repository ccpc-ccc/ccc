namespace YF.MWS.Win.View.Home
{
    partial class FrmWelcome
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
            this.groupLogo = new DevExpress.XtraEditors.GroupControl();
            this.peLogo = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLogo)).BeginInit();
            this.groupLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peLogo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupLogo
            // 
            this.groupLogo.Controls.Add(this.peLogo);
            this.groupLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLogo.Location = new System.Drawing.Point(0, 0);
            this.groupLogo.Name = "groupLogo";
            this.groupLogo.ShowCaption = false;
            this.groupLogo.Size = new System.Drawing.Size(1483, 832);
            this.groupLogo.TabIndex = 4;
            this.groupLogo.Text = "公司LOGO";
            // 
            // peLogo
            // 
            this.peLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.peLogo.EditValue = global::YF.MWS.Win.Properties.Resources.banner1;
            this.peLogo.Location = new System.Drawing.Point(2, 2);
            this.peLogo.Name = "peLogo";
            this.peLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peLogo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.Window;
            this.peLogo.Properties.Appearance.Options.UseBackColor = true;
            this.peLogo.Properties.Appearance.Options.UseForeColor = true;
            this.peLogo.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.peLogo.Properties.ReadOnly = true;
            this.peLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peLogo.Size = new System.Drawing.Size(1479, 828);
            this.peLogo.TabIndex = 3;
            // 
            // FrmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 832);
            this.ControlBox = false;
            this.Controls.Add(this.groupLogo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWelcome";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmWelcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupLogo)).EndInit();
            this.groupLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peLogo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peLogo;
        private DevExpress.XtraEditors.GroupControl groupLogo;

    }
}