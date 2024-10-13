namespace YF.MWS.Win.Test
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.endDate = new DevExpress.XtraEditors.TimeEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.teRandCode = new DevExpress.XtraEditors.TextEdit();
            this.lblRandCode = new DevExpress.XtraEditors.LabelControl();
            this.btnVerify = new DevExpress.XtraEditors.SimpleButton();
            this.teAuthCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAuthCode = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDongle = new DevExpress.XtraEditors.TimeEdit();
            this.txtPID2 = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPID = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtPackPath = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFilePath = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.raType = new DevExpress.XtraEditors.RadioGroup();
            this.label10 = new System.Windows.Forms.Label();
            this.raFileType = new DevExpress.XtraEditors.RadioGroup();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDongle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPID.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raFileType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(64, 38);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(381, 20);
            this.txtCode.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(64, 180);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(86, 36);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "生成注册文件";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // endDate
            // 
            this.endDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.endDate.Location = new System.Drawing.Point(64, 82);
            this.endDate.Name = "endDate";
            this.endDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.endDate.Properties.Appearance.Options.UseFont = true;
            this.endDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.endDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.endDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.endDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.endDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.endDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.endDate.Size = new System.Drawing.Size(129, 28);
            this.endDate.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "注册码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "到期时间";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(491, 319);
            this.xtraTabControl1.TabIndex = 64;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.raFileType);
            this.xtraTabPage1.Controls.Add(this.label11);
            this.xtraTabPage1.Controls.Add(this.btnTest);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Controls.Add(this.endDate);
            this.xtraTabPage1.Controls.Add(this.txtCode);
            this.xtraTabPage1.Controls.Add(this.label1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(489, 293);
            this.xtraTabPage1.Text = "软件注册";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.teRandCode);
            this.xtraTabPage2.Controls.Add(this.lblRandCode);
            this.xtraTabPage2.Controls.Add(this.btnVerify);
            this.xtraTabPage2.Controls.Add(this.teAuthCode);
            this.xtraTabPage2.Controls.Add(this.lblAuthCode);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(489, 293);
            this.xtraTabPage2.Text = "生成验证码";
            // 
            // teRandCode
            // 
            this.teRandCode.Location = new System.Drawing.Point(151, 84);
            this.teRandCode.Name = "teRandCode";
            this.teRandCode.Size = new System.Drawing.Size(134, 20);
            this.teRandCode.TabIndex = 34;
            // 
            // lblRandCode
            // 
            this.lblRandCode.Location = new System.Drawing.Point(87, 87);
            this.lblRandCode.Name = "lblRandCode";
            this.lblRandCode.Size = new System.Drawing.Size(40, 14);
            this.lblRandCode.TabIndex = 33;
            this.lblRandCode.Text = "随机码:";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(151, 169);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 32;
            this.btnVerify.Text = "获取";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // teAuthCode
            // 
            this.teAuthCode.Location = new System.Drawing.Point(151, 123);
            this.teAuthCode.Name = "teAuthCode";
            this.teAuthCode.Size = new System.Drawing.Size(134, 20);
            this.teAuthCode.TabIndex = 31;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.Location = new System.Drawing.Point(87, 126);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(40, 14);
            this.lblAuthCode.TabIndex = 30;
            this.lblAuthCode.Text = "授权码:";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.raType);
            this.xtraTabPage3.Controls.Add(this.simpleButton1);
            this.xtraTabPage3.Controls.Add(this.label4);
            this.xtraTabPage3.Controls.Add(this.dateDongle);
            this.xtraTabPage3.Controls.Add(this.label10);
            this.xtraTabPage3.Controls.Add(this.txtPID2);
            this.xtraTabPage3.Controls.Add(this.label7);
            this.xtraTabPage3.Controls.Add(this.txtPID);
            this.xtraTabPage3.Controls.Add(this.label6);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(489, 293);
            this.xtraTabPage3.Text = "加密狗注册";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(64, 189);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 36);
            this.simpleButton1.TabIndex = 66;
            this.simpleButton1.Text = "注册加密狗";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 67;
            this.label4.Text = "到期时间";
            // 
            // dateDongle
            // 
            this.dateDongle.EditValue = new System.DateTime(2026, 11, 4, 23, 59, 0, 0);
            this.dateDongle.Location = new System.Drawing.Point(64, 65);
            this.dateDongle.Name = "dateDongle";
            this.dateDongle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.dateDongle.Properties.Appearance.Options.UseFont = true;
            this.dateDongle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateDongle.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateDongle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDongle.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateDongle.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateDongle.Properties.MaskSettings.Set("mask", "yyyy-MM-dd");
            this.dateDongle.Size = new System.Drawing.Size(129, 28);
            this.dateDongle.TabIndex = 70;
            // 
            // txtPID2
            // 
            this.txtPID2.Location = new System.Drawing.Point(64, 39);
            this.txtPID2.Name = "txtPID2";
            this.txtPID2.Size = new System.Drawing.Size(147, 20);
            this.txtPID2.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 69;
            this.label7.Text = "新PID:";
            // 
            // txtPID
            // 
            this.txtPID.EditValue = "ADDB5E67";
            this.txtPID.Location = new System.Drawing.Point(64, 13);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(147, 20);
            this.txtPID.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 69;
            this.label6.Text = "旧PID:";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.simpleButton2);
            this.xtraTabPage4.Controls.Add(this.txtPackPath);
            this.xtraTabPage4.Controls.Add(this.label9);
            this.xtraTabPage4.Controls.Add(this.txtFilePath);
            this.xtraTabPage4.Controls.Add(this.label8);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.PageVisible = false;
            this.xtraTabPage4.Size = new System.Drawing.Size(489, 293);
            this.xtraTabPage4.Text = "软件打包";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(186, 144);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(86, 36);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "开始打包";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtPackPath
            // 
            this.txtPackPath.EditValue = "E:/C#\\称重软件1.1\\单机版";
            this.txtPackPath.Location = new System.Drawing.Point(81, 99);
            this.txtPackPath.Name = "txtPackPath";
            this.txtPackPath.Size = new System.Drawing.Size(367, 20);
            this.txtPackPath.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "打包路径";
            // 
            // txtFilePath
            // 
            this.txtFilePath.EditValue = "E:\\project\\C#\\weight\\1.1\\YF.MWS.Win\\bin\\Debug";
            this.txtFilePath.Location = new System.Drawing.Point(81, 61);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(367, 20);
            this.txtFilePath.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "文件路径";
            // 
            // raType
            // 
            this.raType.EditValue = "manual";
            this.raType.Location = new System.Drawing.Point(64, 125);
            this.raType.Name = "raType";
            this.raType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("manual", "普通版"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("all", "无人值守")});
            this.raType.Size = new System.Drawing.Size(269, 27);
            this.raType.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 68;
            this.label10.Text = "系统版本";
            // 
            // raFileType
            // 
            this.raFileType.EditValue = "manual";
            this.raFileType.Location = new System.Drawing.Point(64, 133);
            this.raFileType.Name = "raFileType";
            this.raFileType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("manual", "普通版"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("all", "无人值守")});
            this.raFileType.Size = new System.Drawing.Size(269, 27);
            this.raFileType.TabIndex = 73;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 72;
            this.label11.Text = "系统版本";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 319);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmMain";
            this.Text = "生成注册文件";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAuthCode.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDongle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPID.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raFileType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TimeEdit endDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.TextEdit teRandCode;
        private DevExpress.XtraEditors.LabelControl lblRandCode;
        private DevExpress.XtraEditors.SimpleButton btnVerify;
        private DevExpress.XtraEditors.TextEdit teAuthCode;
        private DevExpress.XtraEditors.LabelControl lblAuthCode;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TimeEdit dateDongle;
        private DevExpress.XtraEditors.TextEdit txtPID;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPID2;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtPackPath;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtFilePath;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.RadioGroup raType;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.RadioGroup raFileType;
        private System.Windows.Forms.Label label11;
    }
}

