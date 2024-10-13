namespace YF.MWS.Win.View.Weight
{
    partial class FrmPay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPay));
            this.peQrCode = new DevExpress.XtraEditors.PictureEdit();
            this.timerPay = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.peQrCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // peQrCode
            // 
            this.peQrCode.Location = new System.Drawing.Point(12, 12);
            this.peQrCode.Name = "peQrCode";
            this.peQrCode.Size = new System.Drawing.Size(300, 300);
            this.peQrCode.TabIndex = 0;
            // 
            // timerPay
            // 
            this.timerPay.Interval = 1000;
            this.timerPay.Tick += new System.EventHandler(this.timerPay_Tick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(82, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消支付允许车辆离开";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 365);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.peQrCode);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫码支付";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPay_FormClosing);
            this.Load += new System.EventHandler(this.FrmPay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peQrCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit peQrCode;
        private System.Windows.Forms.Timer timerPay;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}