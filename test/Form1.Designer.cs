namespace test {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtNum = new DevExpress.XtraEditors.TextEdit();
            this.button2 = new System.Windows.Forms.Button();
            this.txtChinese = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbParity1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbStopBits1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDataBits1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBaudRate1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCom1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.chkCRC = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChinese.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParity1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStopBits1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBits1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaudRate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCom1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCRC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 294);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "解  析";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 328);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(401, 22);
            this.textBox2.TabIndex = 1;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(521, 11);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(651, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "转中文数字";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtChinese
            // 
            this.txtChinese.Location = new System.Drawing.Point(424, 37);
            this.txtChinese.Name = "txtChinese";
            this.txtChinese.Size = new System.Drawing.Size(373, 20);
            this.txtChinese.TabIndex = 3;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.textBox1);
            this.xtraTabPage1.Controls.Add(this.txtChinese);
            this.xtraTabPage1.Controls.Add(this.textBox2);
            this.xtraTabPage1.Controls.Add(this.txtNum);
            this.xtraTabPage1.Controls.Add(this.button1);
            this.xtraTabPage1.Controls.Add(this.button2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(798, 424);
            this.xtraTabPage1.Text = "数据解析";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.chkCRC);
            this.xtraTabPage2.Controls.Add(this.textBox4);
            this.xtraTabPage2.Controls.Add(this.textBox3);
            this.xtraTabPage2.Controls.Add(this.simpleButton1);
            this.xtraTabPage2.Controls.Add(this.simpleButton2);
            this.xtraTabPage2.Controls.Add(this.cmbParity1);
            this.xtraTabPage2.Controls.Add(this.cmbAddress);
            this.xtraTabPage2.Controls.Add(this.cmbStopBits1);
            this.xtraTabPage2.Controls.Add(this.cmbDataBits1);
            this.xtraTabPage2.Controls.Add(this.labelControl6);
            this.xtraTabPage2.Controls.Add(this.labelControl5);
            this.xtraTabPage2.Controls.Add(this.labelControl4);
            this.xtraTabPage2.Controls.Add(this.labelControl3);
            this.xtraTabPage2.Controls.Add(this.cmbBaudRate1);
            this.xtraTabPage2.Controls.Add(this.labelControl1);
            this.xtraTabPage2.Controls.Add(this.labelControl2);
            this.xtraTabPage2.Controls.Add(this.cmbCom1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(798, 424);
            this.xtraTabPage2.Text = "变送器";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(53, 138);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(70, 23);
            this.simpleButton2.TabIndex = 18;
            this.simpleButton2.Text = "连接";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cmbParity1
            // 
            this.cmbParity1.EditValue = "无";
            this.cmbParity1.Location = new System.Drawing.Point(75, 109);
            this.cmbParity1.Name = "cmbParity1";
            this.cmbParity1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbParity1.Properties.Appearance.Options.UseFont = true;
            this.cmbParity1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbParity1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbParity1.Size = new System.Drawing.Size(92, 18);
            this.cmbParity1.TabIndex = 22;
            this.cmbParity1.Tag = "ParityVerifyBit";
            // 
            // cmbStopBits1
            // 
            this.cmbStopBits1.EditValue = "1";
            this.cmbStopBits1.Location = new System.Drawing.Point(75, 85);
            this.cmbStopBits1.Name = "cmbStopBits1";
            this.cmbStopBits1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbStopBits1.Properties.Appearance.Options.UseFont = true;
            this.cmbStopBits1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStopBits1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbStopBits1.Size = new System.Drawing.Size(92, 18);
            this.cmbStopBits1.TabIndex = 21;
            this.cmbStopBits1.Tag = "StopBit";
            // 
            // cmbDataBits1
            // 
            this.cmbDataBits1.EditValue = "8";
            this.cmbDataBits1.Location = new System.Drawing.Point(75, 61);
            this.cmbDataBits1.Name = "cmbDataBits1";
            this.cmbDataBits1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbDataBits1.Properties.Appearance.Options.UseFont = true;
            this.cmbDataBits1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataBits1.Properties.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDataBits1.Size = new System.Drawing.Size(92, 18);
            this.cmbDataBits1.TabIndex = 20;
            this.cmbDataBits1.Tag = "DataBit";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(10, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 12);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "奇偶校验：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 12);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "停 止 位：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(10, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 12);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "数 据 位：";
            // 
            // cmbBaudRate1
            // 
            this.cmbBaudRate1.EditValue = "9600";
            this.cmbBaudRate1.Location = new System.Drawing.Point(75, 36);
            this.cmbBaudRate1.Name = "cmbBaudRate1";
            this.cmbBaudRate1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudRate1.Properties.Appearance.Options.UseFont = true;
            this.cmbBaudRate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBaudRate1.Properties.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.cmbBaudRate1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBaudRate1.Size = new System.Drawing.Size(92, 18);
            this.cmbBaudRate1.TabIndex = 15;
            this.cmbBaudRate1.Tag = "BaundRate";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 12);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "端    口：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 12);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "波 特 率：";
            // 
            // cmbCom1
            // 
            this.cmbCom1.Location = new System.Drawing.Point(75, 12);
            this.cmbCom1.Name = "cmbCom1";
            this.cmbCom1.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCom1.Properties.Appearance.Options.UseFont = true;
            this.cmbCom1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCom1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCom1.Size = new System.Drawing.Size(92, 18);
            this.cmbCom1.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(173, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(564, 158);
            this.textBox3.TabIndex = 23;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(173, 167);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 23);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "发送";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(249, 168);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(416, 22);
            this.textBox4.TabIndex = 23;
            // 
            // chkCRC
            // 
            this.chkCRC.Location = new System.Drawing.Point(671, 168);
            this.chkCRC.Name = "chkCRC";
            this.chkCRC.Properties.Caption = "CRC校验";
            this.chkCRC.Size = new System.Drawing.Size(66, 20);
            this.chkCRC.TabIndex = 24;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(10, 173);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 12);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "地址编号：";
            // 
            // cmbAddress
            // 
            this.cmbAddress.EditValue = "1";
            this.cmbAddress.Location = new System.Drawing.Point(75, 170);
            this.cmbAddress.Name = "cmbAddress";
            this.cmbAddress.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.cmbAddress.Properties.Appearance.Options.UseFont = true;
            this.cmbAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAddress.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbAddress.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAddress.Size = new System.Drawing.Size(92, 18);
            this.cmbAddress.TabIndex = 21;
            this.cmbAddress.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Form1";
            this.Text = "调试工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChinese.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParity1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStopBits1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBits1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBaudRate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCom1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCRC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAddress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.TextEdit txtChinese;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBaudRate1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCom1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbParity1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStopBits1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDataBits1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit chkCRC;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAddress;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}

