namespace YF.MWS.Win.View.Master
{
    partial class FrmSoundSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSoundSetting));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumWord = new DevExpress.XtraEditors.TextEdit();
            this.btnSound = new DevExpress.XtraEditors.SimpleButton();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumWord.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl1.Location = new System.Drawing.Point(48, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 12);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "输入数字：";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(114, 66);
            this.txtNum.Name = "txtNum";
            this.txtNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtNum.Properties.Appearance.Options.UseFont = true;
            this.txtNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNum.Size = new System.Drawing.Size(201, 18);
            this.txtNum.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl2.Location = new System.Drawing.Point(48, 116);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 12);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "转换结果：";
            // 
            // txtNumWord
            // 
            this.txtNumWord.Location = new System.Drawing.Point(114, 113);
            this.txtNumWord.Name = "txtNumWord";
            this.txtNumWord.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtNumWord.Properties.Appearance.Options.UseFont = true;
            this.txtNumWord.Properties.Mask.EditMask = "0.00";
            this.txtNumWord.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumWord.Properties.ReadOnly = true;
            this.txtNumWord.Size = new System.Drawing.Size(201, 18);
            this.txtNumWord.TabIndex = 3;
            // 
            // btnSound
            // 
            this.btnSound.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSound.Appearance.Options.UseFont = true;
            this.btnSound.Location = new System.Drawing.Point(415, 109);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(60, 23);
            this.btnSound.TabIndex = 5;
            this.btnSound.Text = "朗 读";
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnTransfer.Appearance.Options.UseFont = true;
            this.btnTransfer.Location = new System.Drawing.Point(333, 109);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(60, 23);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "转 换";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // FrmSoundSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 275);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtNumWord);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSoundSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "声音设置";
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumWord.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNumWord;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.SimpleButton btnSound;
    }
}