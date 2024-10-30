namespace YF.MWS.Win.View.Master
{
    partial class FrmModbusSetting {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModbusSetting));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.txtSend2 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.txtModbusPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.txtModbusIP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.chkStartModBus = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartModBus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "refresh_16x16.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 297);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.simpleButton7);
            this.tabPage2.Controls.Add(this.txtModbusPort);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.labelControl23);
            this.tabPage2.Controls.Add(this.btnSend2);
            this.tabPage2.Controls.Add(this.txtModbusIP);
            this.tabPage2.Controls.Add(this.simpleButton4);
            this.tabPage2.Controls.Add(this.labelControl24);
            this.tabPage2.Controls.Add(this.txtSend2);
            this.tabPage2.Controls.Add(this.chkStartModBus);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设备";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(214, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 110);
            this.textBox1.TabIndex = 134;
            // 
            // btnSend2
            // 
            this.btnSend2.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSend2.Appearance.Options.UseFont = true;
            this.btnSend2.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.send_16x16;
            this.btnSend2.Location = new System.Drawing.Point(348, 47);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(70, 23);
            this.btnSend2.TabIndex = 7;
            this.btnSend2.Text = "发送";
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(270, 218);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 133;
            this.simpleButton4.Text = "保存";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // txtSend2
            // 
            this.txtSend2.Location = new System.Drawing.Point(214, 23);
            this.txtSend2.Name = "txtSend2";
            this.txtSend2.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtSend2.Properties.Appearance.Options.UseFont = true;
            this.txtSend2.Size = new System.Drawing.Size(204, 18);
            this.txtSend2.TabIndex = 5;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(66, 138);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(70, 23);
            this.simpleButton7.TabIndex = 13;
            this.simpleButton7.Text = "连接";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // txtModbusPort
            // 
            this.txtModbusPort.Location = new System.Drawing.Point(66, 82);
            this.txtModbusPort.Name = "txtModbusPort";
            this.txtModbusPort.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtModbusPort.Properties.Appearance.Options.UseFont = true;
            this.txtModbusPort.Size = new System.Drawing.Size(107, 18);
            this.txtModbusPort.TabIndex = 12;
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl23.Appearance.Options.UseFont = true;
            this.labelControl23.Location = new System.Drawing.Point(16, 85);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 12);
            this.labelControl23.TabIndex = 11;
            this.labelControl23.Text = "端口：";
            // 
            // txtModbusIP
            // 
            this.txtModbusIP.Location = new System.Drawing.Point(66, 36);
            this.txtModbusIP.Name = "txtModbusIP";
            this.txtModbusIP.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtModbusIP.Properties.Appearance.Options.UseFont = true;
            this.txtModbusIP.Size = new System.Drawing.Size(107, 18);
            this.txtModbusIP.TabIndex = 12;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.Location = new System.Drawing.Point(16, 39);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(48, 12);
            this.labelControl24.TabIndex = 11;
            this.labelControl24.Text = "IP地址：";
            // 
            // chkStartModBus
            // 
            this.chkStartModBus.Location = new System.Drawing.Point(52, 221);
            this.chkStartModBus.Name = "chkStartModBus";
            this.chkStartModBus.Properties.Caption = "启用设备";
            this.chkStartModBus.Size = new System.Drawing.Size(103, 20);
            this.chkStartModBus.TabIndex = 127;
            this.chkStartModBus.CheckedChanged += new System.EventHandler(this.chkStartModBus_CheckedChanged);
            // 
            // FrmModbusSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 297);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModbusSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDeviceSetting_FormClosed);
            this.Load += new System.EventHandler(this.FrmDeviceSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartModBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imgListSmall;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.TextEdit txtModbusPort;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.TextEdit txtModbusIP;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.CheckEdit chkStartModBus;
        private DevExpress.XtraEditors.SimpleButton btnSend2;
        private DevExpress.XtraEditors.TextEdit txtSend2;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.TextBox textBox1;
    }
}