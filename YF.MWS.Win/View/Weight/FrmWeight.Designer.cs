namespace YF.MWS.Win.View.Weight
{
    partial class FrmWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeight));
            this.imgListLarger = new DevExpress.Utils.ImageCollection(this.components);
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            this.lblWeightType = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lbLeftUnit = new DevExpress.XtraEditors.LabelControl();
            this.cmbSymbol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.txtResult = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgListLarger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSymbol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResult.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListLarger
            // 
            this.imgListLarger.ImageSize = new System.Drawing.Size(32, 32);
            this.imgListLarger.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListLarger.ImageStream")));
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(15, 51);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Properties.Appearance.Options.UseFont = true;
            this.txtWeight.Size = new System.Drawing.Size(131, 32);
            this.txtWeight.TabIndex = 44;
            this.txtWeight.EditValueChanged += new System.EventHandler(this.txtWeight_EditValueChanged);
            this.txtWeight.TextChanged += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // lblWeightType
            // 
            this.lblWeightType.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblWeightType.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWeightType.Appearance.Options.UseFont = true;
            this.lblWeightType.Appearance.Options.UseForeColor = true;
            this.lblWeightType.Location = new System.Drawing.Point(33, 23);
            this.lblWeightType.Name = "lblWeightType";
            this.lblWeightType.Size = new System.Drawing.Size(64, 22);
            this.lblWeightType.TabIndex = 24;
            this.lblWeightType.Text = "当前重量";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.ImageIndex = 8;
            this.simpleButton2.Location = new System.Drawing.Point(383, 101);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 26);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Tag = "Weight";
            this.simpleButton2.Text = "计算";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // lbLeftUnit
            // 
            this.lbLeftUnit.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbLeftUnit.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbLeftUnit.Appearance.Options.UseFont = true;
            this.lbLeftUnit.Appearance.Options.UseForeColor = true;
            this.lbLeftUnit.Location = new System.Drawing.Point(337, 58);
            this.lbLeftUnit.Name = "lbLeftUnit";
            this.lbLeftUnit.Size = new System.Drawing.Size(12, 22);
            this.lbLeftUnit.TabIndex = 13;
            this.lbLeftUnit.Text = "=";
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.EditValue = "/";
            this.cmbSymbol.Location = new System.Drawing.Point(152, 51);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSymbol.Properties.Appearance.Options.UseFont = true;
            this.cmbSymbol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSymbol.Properties.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cmbSymbol.Size = new System.Drawing.Size(42, 32);
            this.cmbSymbol.TabIndex = 44;
            this.cmbSymbol.SelectedIndexChanged += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "150";
            this.textEdit2.Location = new System.Drawing.Point(200, 51);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new System.Drawing.Size(131, 32);
            this.textEdit2.TabIndex = 44;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(355, 51);
            this.txtResult.Name = "txtResult";
            this.txtResult.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Properties.Appearance.Options.UseFont = true;
            this.txtResult.Size = new System.Drawing.Size(131, 32);
            this.txtResult.TabIndex = 44;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.ImageIndex = 8;
            this.simpleButton1.Location = new System.Drawing.Point(383, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 26);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Tag = "Weight";
            this.simpleButton1.Text = "注册";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.ImageIndex = 8;
            this.simpleButton3.Location = new System.Drawing.Point(274, 12);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(103, 26);
            this.simpleButton3.TabIndex = 20;
            this.simpleButton3.Tag = "Weight";
            this.simpleButton3.Text = "设置";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FrmWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 159);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeightType);
            this.Controls.Add(this.lbLeftUnit);
            this.Controls.Add(this.cmbSymbol);
            this.KeyPreview = true;
            this.Name = "FrmWeight";
            this.Text = "称重操作";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWeight_FormClosed);
            this.Load += new System.EventHandler(this.FrmWeight_Load);
            this.SizeChanged += new System.EventHandler(this.FrmWeight_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmWeight_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgListLarger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSymbol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResult.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 
        

        #endregion
        private DevExpress.Utils.ImageCollection imgListLarger;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl lblWeightType;
        private DevExpress.XtraEditors.LabelControl lbLeftUnit;
        private DevExpress.XtraEditors.TextEdit txtWeight;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSymbol;
        private DevExpress.XtraEditors.TextEdit txtResult;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}