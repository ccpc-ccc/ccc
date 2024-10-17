namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeight2
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbPlan = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Location = new System.Drawing.Point(24, 620);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "数据查询";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tbPlan
            // 
            this.tbPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPlan.ColumnCount = 6;
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPlan.Location = new System.Drawing.Point(2, 5);
            this.tbPlan.Name = "tbPlan";
            this.tbPlan.RowCount = 1;
            this.tbPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPlan.Size = new System.Drawing.Size(1490, 609);
            this.tbPlan.TabIndex = 2;
            // 
            // FrmWeight2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 648);
            this.Controls.Add(this.tbPlan);
            this.Controls.Add(this.simpleButton1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeight2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "称重操作";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmWeight2_Load);
            this.ResumeLayout(false);

        }


        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TableLayoutPanel tbPlan;
    }
}