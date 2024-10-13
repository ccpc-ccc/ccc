namespace YF.MWS.Win.View.Master
{
    partial class FrmPlanCardPadEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanCardPadEdit));
            this.plBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblStateNote = new DevExpress.XtraEditors.LabelControl();
            this.plBody = new DevExpress.XtraEditors.PanelControl();
            this.teReceiver = new DevExpress.XtraEditors.TextEdit();
            this.lblReceiver = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectReceiver = new DevExpress.XtraEditors.SimpleButton();
            this.teDeliver = new DevExpress.XtraEditors.TextEdit();
            this.lblDeliver = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectDeliver = new DevExpress.XtraEditors.SimpleButton();
            this.teCustomer = new DevExpress.XtraEditors.TextEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.teMaterial = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectMaterial = new DevExpress.XtraEditors.SimpleButton();
            this.teCarNo = new DevExpress.XtraEditors.TextEdit();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectCarNo = new DevExpress.XtraEditors.SimpleButton();
            this.plHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnFinishInput = new DevExpress.XtraEditors.SimpleButton();
            this.btnReconnect = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.timerReadCard = new System.Windows.Forms.Timer(this.components);
            this.btnStartInput = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).BeginInit();
            this.plBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teReceiver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDeliver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).BeginInit();
            this.plHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plBottom.Controls.Add(this.lblStateNote);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 659);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(1370, 90);
            this.plBottom.TabIndex = 5;
            // 
            // lblStateNote
            // 
            this.lblStateNote.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.lblStateNote.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStateNote.Location = new System.Drawing.Point(609, 20);
            this.lblStateNote.Name = "lblStateNote";
            this.lblStateNote.Size = new System.Drawing.Size(152, 50);
            this.lblStateNote.TabIndex = 96;
            this.lblStateNote.Text = "准备就绪";
            // 
            // plBody
            // 
            this.plBody.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.plBody.Appearance.Options.UseBackColor = true;
            this.plBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plBody.Controls.Add(this.teReceiver);
            this.plBody.Controls.Add(this.lblReceiver);
            this.plBody.Controls.Add(this.btnSelectReceiver);
            this.plBody.Controls.Add(this.teDeliver);
            this.plBody.Controls.Add(this.lblDeliver);
            this.plBody.Controls.Add(this.btnSelectDeliver);
            this.plBody.Controls.Add(this.teCustomer);
            this.plBody.Controls.Add(this.lblCustomer);
            this.plBody.Controls.Add(this.btnSelectCustomer);
            this.plBody.Controls.Add(this.teMaterial);
            this.plBody.Controls.Add(this.lblMaterial);
            this.plBody.Controls.Add(this.btnSelectMaterial);
            this.plBody.Controls.Add(this.teCarNo);
            this.plBody.Controls.Add(this.lblCarNo);
            this.plBody.Controls.Add(this.btnSelectCarNo);
            this.plBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBody.Location = new System.Drawing.Point(0, 119);
            this.plBody.Name = "plBody";
            this.plBody.Size = new System.Drawing.Size(1370, 630);
            this.plBody.TabIndex = 4;
            // 
            // teReceiver
            // 
            this.teReceiver.Location = new System.Drawing.Point(327, 457);
            this.teReceiver.Name = "teReceiver";
            this.teReceiver.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.teReceiver.Properties.Appearance.Options.UseFont = true;
            this.teReceiver.Size = new System.Drawing.Size(589, 64);
            this.teReceiver.TabIndex = 27;
            // 
            // lblReceiver
            // 
            this.lblReceiver.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblReceiver.Location = new System.Drawing.Point(105, 460);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(182, 57);
            this.lblReceiver.TabIndex = 26;
            this.lblReceiver.Text = "收货单位:";
            // 
            // btnSelectReceiver
            // 
            this.btnSelectReceiver.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.btnSelectReceiver.Appearance.Options.UseFont = true;
            this.btnSelectReceiver.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectReceiver.Location = new System.Drawing.Point(961, 461);
            this.btnSelectReceiver.Name = "btnSelectReceiver";
            this.btnSelectReceiver.Size = new System.Drawing.Size(267, 60);
            this.btnSelectReceiver.TabIndex = 25;
            this.btnSelectReceiver.Text = "选择";
            this.btnSelectReceiver.Click += new System.EventHandler(this.btnSelectReceiver_Click);
            // 
            // teDeliver
            // 
            this.teDeliver.Location = new System.Drawing.Point(327, 361);
            this.teDeliver.Name = "teDeliver";
            this.teDeliver.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.teDeliver.Properties.Appearance.Options.UseFont = true;
            this.teDeliver.Size = new System.Drawing.Size(589, 64);
            this.teDeliver.TabIndex = 24;
            // 
            // lblDeliver
            // 
            this.lblDeliver.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblDeliver.Location = new System.Drawing.Point(105, 358);
            this.lblDeliver.Name = "lblDeliver";
            this.lblDeliver.Size = new System.Drawing.Size(182, 57);
            this.lblDeliver.TabIndex = 23;
            this.lblDeliver.Text = "发货单位:";
            // 
            // btnSelectDeliver
            // 
            this.btnSelectDeliver.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.btnSelectDeliver.Appearance.Options.UseFont = true;
            this.btnSelectDeliver.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectDeliver.Location = new System.Drawing.Point(961, 355);
            this.btnSelectDeliver.Name = "btnSelectDeliver";
            this.btnSelectDeliver.Size = new System.Drawing.Size(267, 60);
            this.btnSelectDeliver.TabIndex = 22;
            this.btnSelectDeliver.Text = "选择";
            this.btnSelectDeliver.Click += new System.EventHandler(this.btnSelectDeliver_Click);
            // 
            // teCustomer
            // 
            this.teCustomer.Location = new System.Drawing.Point(327, 256);
            this.teCustomer.Name = "teCustomer";
            this.teCustomer.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.teCustomer.Properties.Appearance.Options.UseFont = true;
            this.teCustomer.Size = new System.Drawing.Size(589, 64);
            this.teCustomer.TabIndex = 21;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblCustomer.Location = new System.Drawing.Point(191, 253);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(96, 57);
            this.lblCustomer.TabIndex = 20;
            this.lblCustomer.Text = "客户:";
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.btnSelectCustomer.Appearance.Options.UseFont = true;
            this.btnSelectCustomer.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectCustomer.Location = new System.Drawing.Point(961, 250);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(267, 60);
            this.btnSelectCustomer.TabIndex = 19;
            this.btnSelectCustomer.Text = "选择";
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // teMaterial
            // 
            this.teMaterial.Location = new System.Drawing.Point(327, 147);
            this.teMaterial.Name = "teMaterial";
            this.teMaterial.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.teMaterial.Properties.Appearance.Options.UseFont = true;
            this.teMaterial.Size = new System.Drawing.Size(589, 64);
            this.teMaterial.TabIndex = 18;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblMaterial.Location = new System.Drawing.Point(191, 145);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(96, 57);
            this.lblMaterial.TabIndex = 17;
            this.lblMaterial.Text = "物料:";
            // 
            // btnSelectMaterial
            // 
            this.btnSelectMaterial.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.btnSelectMaterial.Appearance.Options.UseFont = true;
            this.btnSelectMaterial.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectMaterial.Location = new System.Drawing.Point(961, 142);
            this.btnSelectMaterial.Name = "btnSelectMaterial";
            this.btnSelectMaterial.Size = new System.Drawing.Size(267, 60);
            this.btnSelectMaterial.TabIndex = 16;
            this.btnSelectMaterial.Text = "选择";
            this.btnSelectMaterial.Click += new System.EventHandler(this.btnSelectMaterial_Click);
            // 
            // teCarNo
            // 
            this.teCarNo.Location = new System.Drawing.Point(327, 32);
            this.teCarNo.Name = "teCarNo";
            this.teCarNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.teCarNo.Properties.Appearance.Options.UseFont = true;
            this.teCarNo.Size = new System.Drawing.Size(589, 64);
            this.teCarNo.TabIndex = 15;
            // 
            // lblCarNo
            // 
            this.lblCarNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 32F);
            this.lblCarNo.Location = new System.Drawing.Point(191, 30);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(96, 57);
            this.lblCarNo.TabIndex = 14;
            this.lblCarNo.Text = "车牌:";
            // 
            // btnSelectCarNo
            // 
            this.btnSelectCarNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 28F);
            this.btnSelectCarNo.Appearance.Options.UseFont = true;
            this.btnSelectCarNo.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnSelectCarNo.Location = new System.Drawing.Point(961, 31);
            this.btnSelectCarNo.Name = "btnSelectCarNo";
            this.btnSelectCarNo.Size = new System.Drawing.Size(267, 64);
            this.btnSelectCarNo.TabIndex = 13;
            this.btnSelectCarNo.Text = "选择";
            this.btnSelectCarNo.Click += new System.EventHandler(this.btnSelectCarNo_Click);
            // 
            // plHeader
            // 
            this.plHeader.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.plHeader.Appearance.Options.UseBackColor = true;
            this.plHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plHeader.Controls.Add(this.btnStartInput);
            this.plHeader.Controls.Add(this.btnFinishInput);
            this.plHeader.Controls.Add(this.btnReconnect);
            this.plHeader.Controls.Add(this.lblTitle);
            this.plHeader.Controls.Add(this.btnClose);
            this.plHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHeader.Location = new System.Drawing.Point(0, 0);
            this.plHeader.Name = "plHeader";
            this.plHeader.Size = new System.Drawing.Size(1370, 119);
            this.plHeader.TabIndex = 3;
            // 
            // btnFinishInput
            // 
            this.btnFinishInput.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnFinishInput.Appearance.Options.UseFont = true;
            this.btnFinishInput.Image = global::YF.MWS.Win.Properties.Resources.apply_32x32;
            this.btnFinishInput.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnFinishInput.Location = new System.Drawing.Point(202, 17);
            this.btnFinishInput.Name = "btnFinishInput";
            this.btnFinishInput.Size = new System.Drawing.Size(168, 90);
            this.btnFinishInput.TabIndex = 98;
            this.btnFinishInput.Text = "信息确认";
            this.btnFinishInput.Click += new System.EventHandler(this.btnFinishInput_Click);
            // 
            // btnReconnect
            // 
            this.btnReconnect.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnReconnect.Appearance.Options.UseFont = true;
            this.btnReconnect.Image = global::YF.MWS.Win.Properties.Resources.add_32x32;
            this.btnReconnect.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnReconnect.Location = new System.Drawing.Point(1022, 17);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(154, 90);
            this.btnReconnect.TabIndex = 97;
            this.btnReconnect.Text = "重连IC卡";
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTitle.Location = new System.Drawing.Point(503, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "物资管理系统自助写卡";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = global::YF.MWS.Win.Properties.Resources.close_32x32;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(1199, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 90);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "退出写卡";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerReadCard
            // 
            this.timerReadCard.Interval = 1000;
            this.timerReadCard.Tick += new System.EventHandler(this.timerReadCard_Tick);
            // 
            // btnStartInput
            // 
            this.btnStartInput.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnStartInput.Appearance.Options.UseFont = true;
            this.btnStartInput.Image = global::YF.MWS.Win.Properties.Resources.apply_32x32;
            this.btnStartInput.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStartInput.Location = new System.Drawing.Point(12, 17);
            this.btnStartInput.Name = "btnStartInput";
            this.btnStartInput.Size = new System.Drawing.Size(167, 90);
            this.btnStartInput.TabIndex = 99;
            this.btnStartInput.Text = "准备写卡";
            this.btnStartInput.Click += new System.EventHandler(this.btnStartInput_Click);
            // 
            // FrmPlanCardPadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.plHeader);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmPlanCardPadEdit";
            this.Text = "自助写卡";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPlanCardPadEdit_FormClosed);
            this.Load += new System.EventHandler(this.FrmPlanCardPadEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            this.plBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).EndInit();
            this.plBody.ResumeLayout(false);
            this.plBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teReceiver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDeliver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plHeader)).EndInit();
            this.plHeader.ResumeLayout(false);
            this.plHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl plBottom;
        private DevExpress.XtraEditors.PanelControl plBody;
        private DevExpress.XtraEditors.PanelControl plHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit teCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.SimpleButton btnSelectCustomer;
        private DevExpress.XtraEditors.TextEdit teMaterial;
        private DevExpress.XtraEditors.LabelControl lblMaterial;
        private DevExpress.XtraEditors.SimpleButton btnSelectMaterial;
        private DevExpress.XtraEditors.TextEdit teCarNo;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.SimpleButton btnSelectCarNo;
        private DevExpress.XtraEditors.TextEdit teReceiver;
        private DevExpress.XtraEditors.LabelControl lblReceiver;
        private DevExpress.XtraEditors.SimpleButton btnSelectReceiver;
        private DevExpress.XtraEditors.TextEdit teDeliver;
        private DevExpress.XtraEditors.LabelControl lblDeliver;
        private DevExpress.XtraEditors.SimpleButton btnSelectDeliver;
        private DevExpress.XtraEditors.SimpleButton btnFinishInput;
        private DevExpress.XtraEditors.SimpleButton btnReconnect;
        private System.Windows.Forms.Timer timerReadCard;
        private DevExpress.XtraEditors.LabelControl lblStateNote;
        private DevExpress.XtraEditors.SimpleButton btnStartInput;

    }
}