namespace YF.MWS.Win
{
    partial class FrmRepair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepair));
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.beRepairFile = new DevExpress.XtraEditors.ButtonEdit();
            this.txtMachineCode = new DevExpress.XtraEditors.TextEdit();
            this.ofdRegisterFile = new System.Windows.Forms.OpenFileDialog();
            this.plMain = new DevExpress.XtraEditors.PanelControl();
            this.lblMachineCode = new DevExpress.XtraEditors.LabelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblRepairFile = new DevExpress.XtraEditors.LabelControl();
            this.btnRepair = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddConsult = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beRepairFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // beRepairFile
            // 
            this.dxErrorProvider.SetIconAlignment(this.beRepairFile, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.beRepairFile.Location = new System.Drawing.Point(180, 159);
            this.beRepairFile.Name = "beRepairFile";
            this.beRepairFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beRepairFile.Size = new System.Drawing.Size(261, 20);
            this.beRepairFile.TabIndex = 28;
            this.beRepairFile.Click += new System.EventHandler(this.beRepairFile_Click);
            // 
            // txtMachineCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.txtMachineCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.txtMachineCode.Location = new System.Drawing.Point(180, 121);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(261, 20);
            this.txtMachineCode.TabIndex = 31;
            // 
            // ofdRegisterFile
            // 
            this.ofdRegisterFile.Filter = "注册文件|*.yrg";
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.btnAddConsult);
            this.plMain.Controls.Add(this.txtMachineCode);
            this.plMain.Controls.Add(this.lblMachineCode);
            this.plMain.Controls.Add(this.lblNote);
            this.plMain.Controls.Add(this.beRepairFile);
            this.plMain.Controls.Add(this.btnRepair);
            this.plMain.Controls.Add(this.lblRepairFile);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(537, 254);
            this.plMain.TabIndex = 0;
            // 
            // lblMachineCode
            // 
            this.lblMachineCode.Location = new System.Drawing.Point(92, 121);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new System.Drawing.Size(64, 14);
            this.lblMachineCode.TabIndex = 30;
            this.lblMachineCode.Text = "修复唯一码:";
            // 
            // lblNote
            // 
            this.lblNote.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblNote.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblNote.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblNote.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblNote.Location = new System.Drawing.Point(61, 50);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(428, 50);
            this.lblNote.TabIndex = 29;
            this.lblNote.Text = "The intelligent weighing software cannot \r\nbe used and needs to be repaired";
            // 
            // lblRepairFile
            // 
            this.lblRepairFile.Location = new System.Drawing.Point(92, 162);
            this.lblRepairFile.Name = "lblRepairFile";
            this.lblRepairFile.Size = new System.Drawing.Size(52, 14);
            this.lblRepairFile.TabIndex = 26;
            this.lblRepairFile.Text = "修复文件:";
            // 
            // btnRepair
            // 
            this.btnRepair.Image = global::YF.MWS.Win.Properties.Resources.apply_16x16;
            this.btnRepair.Location = new System.Drawing.Point(180, 201);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(115, 23);
            this.btnRepair.TabIndex = 27;
            this.btnRepair.Text = "软件修复";
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnAddConsult
            // 
            this.btnAddConsult.Image = global::YF.MWS.Win.Properties.Resources.help_16x16;
            this.btnAddConsult.Location = new System.Drawing.Point(324, 201);
            this.btnAddConsult.Name = "btnAddConsult";
            this.btnAddConsult.Size = new System.Drawing.Size(92, 23);
            this.btnAddConsult.TabIndex = 37;
            this.btnAddConsult.Text = "在线咨询";
            this.btnAddConsult.Click += new System.EventHandler(this.btnAddConsult_Click);
            // 
            // FrmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 254);
            this.Controls.Add(this.plMain);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmRepair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "软件修复";
            this.Load += new System.EventHandler(this.FrmRepair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beRepairFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private System.Windows.Forms.OpenFileDialog ofdRegisterFile;
        private DevExpress.XtraEditors.PanelControl plMain;
        private DevExpress.XtraEditors.ButtonEdit beRepairFile;
        private DevExpress.XtraEditors.SimpleButton btnRepair;
        private DevExpress.XtraEditors.LabelControl lblRepairFile;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.TextEdit txtMachineCode;
        private DevExpress.XtraEditors.LabelControl lblMachineCode;
        private DevExpress.XtraEditors.SimpleButton btnAddConsult;
    }
}