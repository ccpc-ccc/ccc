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
            this.tabModbus = new DevExpress.XtraTab.XtraTabControl();
            this.pageNetworkCfg = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.txtModbusPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.txtModbusIP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.gpBoundGateCfg = new DevExpress.XtraEditors.GroupControl();
            this.chkBoundGate = new DevExpress.XtraEditors.CheckEdit();
            this.lblFunSixCloseTime = new DevExpress.XtraEditors.LabelControl();
            this.rgCloseGateMode = new DevExpress.XtraEditors.RadioGroup();
            this.teFunSixCloseTime = new DevExpress.XtraEditors.TextEdit();
            this.lblFunSixCloseTimeUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblCloseGateMode = new DevExpress.XtraEditors.LabelControl();
            this.gpPLCCfg = new DevExpress.XtraEditors.GroupControl();
            this.chkInfrared = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartTrafficLight = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtInfraredWeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkStartModBus = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabModbus)).BeginInit();
            this.tabModbus.SuspendLayout();
            this.pageNetworkCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBoundGateCfg)).BeginInit();
            this.gpBoundGateCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBoundGate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCloseGateMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFunSixCloseTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpPLCCfg)).BeginInit();
            this.gpPLCCfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInfrared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartTrafficLight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfraredWeight.Properties)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(742, 648);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnSend2);
            this.tabPage2.Controls.Add(this.simpleButton4);
            this.tabPage2.Controls.Add(this.txtSend2);
            this.tabPage2.Controls.Add(this.tabModbus);
            this.tabPage2.Controls.Add(this.gpBoundGateCfg);
            this.tabPage2.Controls.Add(this.gpPLCCfg);
            this.tabPage2.Controls.Add(this.chkStartModBus);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "控制箱设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 123);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 110);
            this.textBox1.TabIndex = 134;
            // 
            // btnSend2
            // 
            this.btnSend2.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSend2.Appearance.Options.UseFont = true;
            this.btnSend2.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.send_16x16;
            this.btnSend2.Location = new System.Drawing.Point(504, 94);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(70, 23);
            this.btnSend2.TabIndex = 7;
            this.btnSend2.Text = "发送";
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(246, 525);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 133;
            this.simpleButton4.Text = "保存";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // txtSend2
            // 
            this.txtSend2.Location = new System.Drawing.Point(230, 96);
            this.txtSend2.Name = "txtSend2";
            this.txtSend2.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.txtSend2.Properties.Appearance.Options.UseFont = true;
            this.txtSend2.Size = new System.Drawing.Size(268, 18);
            this.txtSend2.TabIndex = 5;
            // 
            // tabModbus
            // 
            this.tabModbus.Location = new System.Drawing.Point(8, 6);
            this.tabModbus.Name = "tabModbus";
            this.tabModbus.SelectedTabPage = this.pageNetworkCfg;
            this.tabModbus.Size = new System.Drawing.Size(197, 228);
            this.tabModbus.TabIndex = 130;
            this.tabModbus.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageNetworkCfg});
            // 
            // pageNetworkCfg
            // 
            this.pageNetworkCfg.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pageNetworkCfg.Appearance.PageClient.Options.UseBackColor = true;
            this.pageNetworkCfg.Controls.Add(this.simpleButton7);
            this.pageNetworkCfg.Controls.Add(this.txtModbusPort);
            this.pageNetworkCfg.Controls.Add(this.labelControl23);
            this.pageNetworkCfg.Controls.Add(this.txtModbusIP);
            this.pageNetworkCfg.Controls.Add(this.labelControl24);
            this.pageNetworkCfg.Name = "pageNetworkCfg";
            this.pageNetworkCfg.Padding = new System.Windows.Forms.Padding(3);
            this.pageNetworkCfg.Size = new System.Drawing.Size(195, 202);
            this.pageNetworkCfg.Text = "网口设置";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(54, 140);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(70, 23);
            this.simpleButton7.TabIndex = 13;
            this.simpleButton7.Text = "连接";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // txtModbusPort
            // 
            this.txtModbusPort.Location = new System.Drawing.Point(70, 82);
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
            this.labelControl23.Location = new System.Drawing.Point(20, 85);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(36, 12);
            this.labelControl23.TabIndex = 11;
            this.labelControl23.Text = "端口：";
            // 
            // txtModbusIP
            // 
            this.txtModbusIP.Location = new System.Drawing.Point(70, 36);
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
            this.labelControl24.Location = new System.Drawing.Point(20, 39);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(48, 12);
            this.labelControl24.TabIndex = 11;
            this.labelControl24.Text = "IP地址：";
            // 
            // gpBoundGateCfg
            // 
            this.gpBoundGateCfg.Controls.Add(this.chkBoundGate);
            this.gpBoundGateCfg.Controls.Add(this.lblFunSixCloseTime);
            this.gpBoundGateCfg.Controls.Add(this.rgCloseGateMode);
            this.gpBoundGateCfg.Controls.Add(this.teFunSixCloseTime);
            this.gpBoundGateCfg.Controls.Add(this.lblFunSixCloseTimeUnit);
            this.gpBoundGateCfg.Controls.Add(this.lblCloseGateMode);
            this.gpBoundGateCfg.Location = new System.Drawing.Point(306, 303);
            this.gpBoundGateCfg.Name = "gpBoundGateCfg";
            this.gpBoundGateCfg.Size = new System.Drawing.Size(419, 207);
            this.gpBoundGateCfg.TabIndex = 129;
            this.gpBoundGateCfg.Text = "道闸设置";
            // 
            // chkBoundGate
            // 
            this.chkBoundGate.Location = new System.Drawing.Point(136, 37);
            this.chkBoundGate.Name = "chkBoundGate";
            this.chkBoundGate.Properties.Caption = "启用道闸";
            this.chkBoundGate.Size = new System.Drawing.Size(75, 20);
            this.chkBoundGate.TabIndex = 5;
            // 
            // lblFunSixCloseTime
            // 
            this.lblFunSixCloseTime.Location = new System.Drawing.Point(238, 40);
            this.lblFunSixCloseTime.Name = "lblFunSixCloseTime";
            this.lblFunSixCloseTime.Size = new System.Drawing.Size(60, 14);
            this.lblFunSixCloseTime.TabIndex = 77;
            this.lblFunSixCloseTime.Text = "闭合时间：";
            // 
            // rgCloseGateMode
            // 
            this.rgCloseGateMode.EditValue = "Modbus";
            this.rgCloseGateMode.Location = new System.Drawing.Point(134, 163);
            this.rgCloseGateMode.Name = "rgCloseGateMode";
            this.rgCloseGateMode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgCloseGateMode.Properties.Appearance.Options.UseBackColor = true;
            this.rgCloseGateMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Modbus", "控制箱"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Car", "车牌识别")});
            this.rgCloseGateMode.Size = new System.Drawing.Size(224, 30);
            this.rgCloseGateMode.TabIndex = 21;
            // 
            // teFunSixCloseTime
            // 
            this.teFunSixCloseTime.EditValue = "5";
            this.teFunSixCloseTime.Location = new System.Drawing.Point(301, 37);
            this.teFunSixCloseTime.Name = "teFunSixCloseTime";
            this.teFunSixCloseTime.Size = new System.Drawing.Size(43, 20);
            this.teFunSixCloseTime.TabIndex = 78;
            this.teFunSixCloseTime.Tag = "FunSixCloseTime";
            // 
            // lblFunSixCloseTimeUnit
            // 
            this.lblFunSixCloseTimeUnit.Location = new System.Drawing.Point(347, 40);
            this.lblFunSixCloseTimeUnit.Name = "lblFunSixCloseTimeUnit";
            this.lblFunSixCloseTimeUnit.Size = new System.Drawing.Size(12, 14);
            this.lblFunSixCloseTimeUnit.TabIndex = 79;
            this.lblFunSixCloseTimeUnit.Text = "秒";
            // 
            // lblCloseGateMode
            // 
            this.lblCloseGateMode.Location = new System.Drawing.Point(68, 171);
            this.lblCloseGateMode.Name = "lblCloseGateMode";
            this.lblCloseGateMode.Size = new System.Drawing.Size(60, 14);
            this.lblCloseGateMode.TabIndex = 26;
            this.lblCloseGateMode.Text = "控制方式：";
            // 
            // gpPLCCfg
            // 
            this.gpPLCCfg.Controls.Add(this.chkInfrared);
            this.gpPLCCfg.Controls.Add(this.chkStartTrafficLight);
            this.gpPLCCfg.Controls.Add(this.labelControl2);
            this.gpPLCCfg.Controls.Add(this.txtInfraredWeight);
            this.gpPLCCfg.Controls.Add(this.labelControl1);
            this.gpPLCCfg.Location = new System.Drawing.Point(11, 303);
            this.gpPLCCfg.Name = "gpPLCCfg";
            this.gpPLCCfg.Size = new System.Drawing.Size(272, 207);
            this.gpPLCCfg.TabIndex = 128;
            this.gpPLCCfg.Text = "PLC设置";
            // 
            // chkInfrared
            // 
            this.chkInfrared.Location = new System.Drawing.Point(24, 129);
            this.chkInfrared.Name = "chkInfrared";
            this.chkInfrared.Properties.Caption = "启用红外对射";
            this.chkInfrared.Size = new System.Drawing.Size(102, 20);
            this.chkInfrared.TabIndex = 6;
            // 
            // chkStartTrafficLight
            // 
            this.chkStartTrafficLight.Location = new System.Drawing.Point(22, 47);
            this.chkStartTrafficLight.Name = "chkStartTrafficLight";
            this.chkStartTrafficLight.Properties.Caption = "启用红绿灯";
            this.chkStartTrafficLight.Size = new System.Drawing.Size(98, 20);
            this.chkStartTrafficLight.TabIndex = 23;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(137, 132);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "启动重量";
            // 
            // txtInfraredWeight
            // 
            this.txtInfraredWeight.EditValue = "5";
            this.txtInfraredWeight.Location = new System.Drawing.Point(189, 129);
            this.txtInfraredWeight.Name = "txtInfraredWeight";
            this.txtInfraredWeight.Size = new System.Drawing.Size(43, 20);
            this.txtInfraredWeight.TabIndex = 78;
            this.txtInfraredWeight.Tag = "FunSixCloseTime";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(235, 132);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "公斤";
            // 
            // chkStartModBus
            // 
            this.chkStartModBus.Location = new System.Drawing.Point(259, 28);
            this.chkStartModBus.Name = "chkStartModBus";
            this.chkStartModBus.Properties.Caption = "启用控制箱";
            this.chkStartModBus.Size = new System.Drawing.Size(103, 20);
            this.chkStartModBus.TabIndex = 127;
            this.chkStartModBus.CheckedChanged += new System.EventHandler(this.chkStartModBus_CheckedChanged);
            // 
            // FrmModbusSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 648);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModbusSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制箱设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDeviceSetting_FormClosed);
            this.Load += new System.EventHandler(this.FrmDeviceSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSend2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabModbus)).EndInit();
            this.tabModbus.ResumeLayout(false);
            this.pageNetworkCfg.ResumeLayout(false);
            this.pageNetworkCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModbusIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpBoundGateCfg)).EndInit();
            this.gpBoundGateCfg.ResumeLayout(false);
            this.gpBoundGateCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBoundGate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgCloseGateMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFunSixCloseTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpPLCCfg)).EndInit();
            this.gpPLCCfg.ResumeLayout(false);
            this.gpPLCCfg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInfrared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartTrafficLight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInfraredWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartModBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imgListSmall;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraTab.XtraTabControl tabModbus;
        private DevExpress.XtraTab.XtraTabPage pageNetworkCfg;
        private DevExpress.XtraEditors.TextEdit txtModbusPort;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.TextEdit txtModbusIP;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.GroupControl gpBoundGateCfg;
        private DevExpress.XtraEditors.CheckEdit chkBoundGate;
        private DevExpress.XtraEditors.RadioGroup rgCloseGateMode;
        private DevExpress.XtraEditors.LabelControl lblCloseGateMode;
        private DevExpress.XtraEditors.GroupControl gpPLCCfg;
        private DevExpress.XtraEditors.CheckEdit chkInfrared;
        private DevExpress.XtraEditors.CheckEdit chkStartTrafficLight;
        private DevExpress.XtraEditors.LabelControl lblFunSixCloseTime;
        private DevExpress.XtraEditors.TextEdit teFunSixCloseTime;
        private DevExpress.XtraEditors.LabelControl lblFunSixCloseTimeUnit;
        private DevExpress.XtraEditors.CheckEdit chkStartModBus;
        private DevExpress.XtraEditors.SimpleButton btnSend2;
        private DevExpress.XtraEditors.TextEdit txtSend2;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtInfraredWeight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox textBox1;
    }
}