namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeightImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightImage));
            this.picWeight1 = new System.Windows.Forms.PictureBox();
            this.picWeight2 = new System.Windows.Forms.PictureBox();
            this.picWeight3 = new System.Windows.Forms.PictureBox();
            this.picWeight4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight4)).BeginInit();
            this.SuspendLayout();
            // 
            // picWeight1
            // 
            this.picWeight1.Location = new System.Drawing.Point(22, 12);
            this.picWeight1.Name = "picWeight1";
            this.picWeight1.Size = new System.Drawing.Size(300, 300);
            this.picWeight1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeight1.TabIndex = 0;
            this.picWeight1.TabStop = false;
            // 
            // picWeight2
            // 
            this.picWeight2.Location = new System.Drawing.Point(344, 12);
            this.picWeight2.Name = "picWeight2";
            this.picWeight2.Size = new System.Drawing.Size(300, 300);
            this.picWeight2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeight2.TabIndex = 1;
            this.picWeight2.TabStop = false;
            // 
            // picWeight3
            // 
            this.picWeight3.Location = new System.Drawing.Point(22, 318);
            this.picWeight3.Name = "picWeight3";
            this.picWeight3.Size = new System.Drawing.Size(300, 300);
            this.picWeight3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeight3.TabIndex = 2;
            this.picWeight3.TabStop = false;
            // 
            // picWeight4
            // 
            this.picWeight4.Location = new System.Drawing.Point(344, 318);
            this.picWeight4.Name = "picWeight4";
            this.picWeight4.Size = new System.Drawing.Size(300, 300);
            this.picWeight4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeight4.TabIndex = 3;
            this.picWeight4.TabStop = false;
            // 
            // FrmWeightImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 629);
            this.Controls.Add(this.picWeight4);
            this.Controls.Add(this.picWeight3);
            this.Controls.Add(this.picWeight2);
            this.Controls.Add(this.picWeight1);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeightImage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监控图片";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmWeightImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWeight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeight4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWeight1;
        private System.Windows.Forms.PictureBox picWeight2;
        private System.Windows.Forms.PictureBox picWeight3;
        private System.Windows.Forms.PictureBox picWeight4;
    }
}