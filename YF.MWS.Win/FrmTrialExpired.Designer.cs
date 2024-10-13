namespace YF.MWS.Win
{
    partial class FrmTrialExpired
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrialExpired));
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.btnExtendProbation = new DevExpress.XtraEditors.SimpleButton();
            this.btnConvertOfficial = new DevExpress.XtraEditors.SimpleButton();
            this.peWaitting = new DevExpress.XtraEditors.PictureEdit();
            this.btnAddConsult = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblNote.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblNote.Location = new System.Drawing.Point(145, 238);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(180, 14);
            this.lblNote.TabIndex = 25;
            this.lblNote.Text = "试用期过期,请与经销商联系,谢谢!";
            // 
            // btnExtendProbation
            // 
            this.btnExtendProbation.Location = new System.Drawing.Point(241, 200);
            this.btnExtendProbation.Name = "btnExtendProbation";
            this.btnExtendProbation.Size = new System.Drawing.Size(89, 23);
            this.btnExtendProbation.TabIndex = 26;
            this.btnExtendProbation.Text = "延长试用期";
            this.btnExtendProbation.Click += new System.EventHandler(this.btnExtendProbation_Click);
            // 
            // btnConvertOfficial
            // 
            this.btnConvertOfficial.Location = new System.Drawing.Point(112, 200);
            this.btnConvertOfficial.Name = "btnConvertOfficial";
            this.btnConvertOfficial.Size = new System.Drawing.Size(89, 23);
            this.btnConvertOfficial.TabIndex = 27;
            this.btnConvertOfficial.Text = "转为正式版";
            this.btnConvertOfficial.Click += new System.EventHandler(this.btnConvertOfficial_Click);
            // 
            // peWaitting
            // 
            this.peWaitting.EditValue = global::YF.MWS.Win.Properties.Resources.start;
            this.peWaitting.Location = new System.Drawing.Point(16, 22);
            this.peWaitting.Name = "peWaitting";
            this.peWaitting.Properties.AllowFocused = false;
            this.peWaitting.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peWaitting.Properties.Appearance.Options.UseBackColor = true;
            this.peWaitting.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peWaitting.Properties.ShowMenu = false;
            this.peWaitting.Size = new System.Drawing.Size(426, 166);
            this.peWaitting.TabIndex = 10;
            // 
            // btnAddConsult
            // 
            this.btnAddConsult.Image = global::YF.MWS.Win.Properties.Resources.help_16x16;
            this.btnAddConsult.Location = new System.Drawing.Point(350, 200);
            this.btnAddConsult.Name = "btnAddConsult";
            this.btnAddConsult.Size = new System.Drawing.Size(92, 23);
            this.btnAddConsult.TabIndex = 37;
            this.btnAddConsult.Text = "在线咨询";
            this.btnAddConsult.Click += new System.EventHandler(this.btnAddConsult_Click);
            // 
            // FrmTrialExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 266);
            this.Controls.Add(this.btnAddConsult);
            this.Controls.Add(this.btnConvertOfficial);
            this.Controls.Add(this.btnExtendProbation);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.peWaitting);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 305);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(476, 303);
            this.Name = "FrmTrialExpired";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件故障提示";
            this.Load += new System.EventHandler(this.FrmTrialExpired_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peWaitting.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peWaitting;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.SimpleButton btnExtendProbation;
        private DevExpress.XtraEditors.SimpleButton btnConvertOfficial;
        private DevExpress.XtraEditors.SimpleButton btnAddConsult;
    }
}