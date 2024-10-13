namespace YF.MWS.Win
{
    partial class FrmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.lblRegisterFile = new DevExpress.XtraEditors.LabelControl();
            this.txtMachineCode = new DevExpress.XtraEditors.TextEdit();
            this.lblMachineCode = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teClientName = new DevExpress.XtraEditors.TextEdit();
            this.beRegisterFile = new DevExpress.XtraEditors.ButtonEdit();
            this.lblClientName = new DevExpress.XtraEditors.LabelControl();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.lblCopyright = new DevExpress.XtraEditors.LabelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.ofdRegisterFile = new System.Windows.Forms.OpenFileDialog();
            this.btnTrial = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddConsult = new DevExpress.XtraEditors.SimpleButton();
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teClientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beRegisterFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegisterFile
            // 
            this.lblRegisterFile.Location = new System.Drawing.Point(54, 108);
            this.lblRegisterFile.Name = "lblRegisterFile";
            this.lblRegisterFile.Size = new System.Drawing.Size(52, 14);
            this.lblRegisterFile.TabIndex = 18;
            this.lblRegisterFile.Text = "注册文件:";
            // 
            // txtMachineCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtMachineCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtMachineCode.Location = new System.Drawing.Point(142, 68);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(287, 20);
            this.txtMachineCode.TabIndex = 17;
            // 
            // lblMachineCode
            // 
            this.lblMachineCode.Location = new System.Drawing.Point(54, 68);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new System.Drawing.Size(40, 14);
            this.lblMachineCode.TabIndex = 16;
            this.lblMachineCode.Text = "机器码:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teClientName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teClientName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teClientName.Location = new System.Drawing.Point(142, 27);
            this.teClientName.Name = "teClientName";
            this.teClientName.Size = new System.Drawing.Size(287, 20);
            this.teClientName.TabIndex = 22;
            this.teClientName.Tag = "ClientName";
            // 
            // beRegisterFile
            // 
            this.dxErrorProvider.SetIconAlignment(this.beRegisterFile, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.beRegisterFile.Location = new System.Drawing.Point(142, 105);
            this.beRegisterFile.Name = "beRegisterFile";
            // 
            // 
            // 
            this.beRegisterFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beRegisterFile.Size = new System.Drawing.Size(287, 20);
            this.beRegisterFile.TabIndex = 25;
            this.beRegisterFile.Click += new System.EventHandler(this.beRegisterFile_Click);
            // 
            // lblClientName
            // 
            this.lblClientName.Location = new System.Drawing.Point(54, 27);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(64, 14);
            this.lblClientName.TabIndex = 21;
            this.lblClientName.Text = "客户端名称:";
            // 
            // btnRegister
            // 
            this.btnRegister.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.apply_16x16;
            this.btnRegister.Location = new System.Drawing.Point(142, 147);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(116, 23);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "软件授权注册";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCopyright.Location = new System.Drawing.Point(142, 190);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(0, 14);
            this.lblCopyright.TabIndex = 23;
            // 
            // lblNote
            // 
            this.lblNote.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Appearance.Options.UseForeColor = true;
            this.lblNote.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblNote.Location = new System.Drawing.Point(142, 190);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(24, 14);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "提示";
            // 
            // ofdRegisterFile
            // 
            this.ofdRegisterFile.Filter = "注册文件|*.yrg";
            // 
            // btnTrial
            // 
            this.btnTrial.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.info_16x16;
            this.btnTrial.Location = new System.Drawing.Point(275, 147);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(94, 23);
            this.btnTrial.TabIndex = 26;
            this.btnTrial.Text = "应急处理";
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // btnAddConsult
            // 
            this.btnAddConsult.ImageOptions.Image = global::YF.MWS.Win.Properties.Resources.help_16x16;
            this.btnAddConsult.Location = new System.Drawing.Point(385, 147);
            this.btnAddConsult.Name = "btnAddConsult";
            this.btnAddConsult.Size = new System.Drawing.Size(92, 23);
            this.btnAddConsult.TabIndex = 37;
            this.btnAddConsult.Text = "在线咨询";
            this.btnAddConsult.Click += new System.EventHandler(this.btnAddConsult_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 227);
            this.Controls.Add(this.btnAddConsult);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.beRegisterFile);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.teClientName);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblRegisterFile);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.lblMachineCode);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(532, 266);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(532, 265);
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teClientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beRegisterFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.LabelControl lblRegisterFile;
        private DevExpress.XtraEditors.TextEdit txtMachineCode;
        private DevExpress.XtraEditors.LabelControl lblMachineCode;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit teClientName;
        private DevExpress.XtraEditors.LabelControl lblClientName;
        private DevExpress.XtraEditors.LabelControl lblCopyright;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.ButtonEdit beRegisterFile;
        private System.Windows.Forms.OpenFileDialog ofdRegisterFile;
        private DevExpress.XtraEditors.SimpleButton btnTrial;
        private DevExpress.XtraEditors.SimpleButton btnAddConsult;
        private System.Diagnostics.EventLog eventLog1;
    }
}