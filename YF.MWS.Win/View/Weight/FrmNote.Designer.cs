namespace YF.MWS.Win.View.Weight
{
    partial class FrmNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNote));
            this.lblOverweightNote = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblOverweightNote
            // 
            this.lblOverweightNote.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblOverweightNote.Location = new System.Drawing.Point(99, 24);
            this.lblOverweightNote.Name = "lblOverweightNote";
            this.lblOverweightNote.Size = new System.Drawing.Size(84, 14);
            this.lblOverweightNote.TabIndex = 0;
            this.lblOverweightNote.Text = "该磅单已经超载";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(239, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(272, 71);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblOverweightNote);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(272, 71);
            this.MinimumSize = new System.Drawing.Size(272, 71);
            this.Name = "FrmNote";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOverweightNote;
        private DevExpress.XtraEditors.SimpleButton btnClose;

    }
}
