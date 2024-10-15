namespace YF.MWS.Win.View.Home
{
    partial class FrmConsult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsult));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemOK = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teCellPhone = new DevExpress.XtraEditors.TextEdit();
            this.teFullName = new DevExpress.XtraEditors.TextEdit();
            this.memConsultContent = new DevExpress.XtraEditors.MemoEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblConsultContent = new DevExpress.XtraEditors.LabelControl();
            this.lblCellPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCellPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memConsultContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imgListSmall;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnItemOK,
            this.btnItemClose});
            this.barManager.MaxItemId = 11;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemOK),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemOK
            // 
            this.btnItemOK.Caption = "提交";
            this.btnItemOK.Id = 1;
            this.btnItemOK.ImageOptions.ImageIndex = 0;
            this.btnItemOK.Name = "btnItemOK";
            this.btnItemOK.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemOK_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(564, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 364);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(564, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 340);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(564, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 340);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "apply_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teCellPhone
            // 
            this.dxErrorProvider.SetIconAlignment(this.teCellPhone, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teCellPhone.Location = new System.Drawing.Point(107, 68);
            this.teCellPhone.MenuManager = this.barManager;
            this.teCellPhone.Name = "teCellPhone";
            this.teCellPhone.Size = new System.Drawing.Size(230, 20);
            this.teCellPhone.TabIndex = 58;
            this.teCellPhone.Tag = "ClientName";
            // 
            // teFullName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teFullName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teFullName.Location = new System.Drawing.Point(107, 29);
            this.teFullName.MenuManager = this.barManager;
            this.teFullName.Name = "teFullName";
            this.teFullName.Size = new System.Drawing.Size(230, 20);
            this.teFullName.TabIndex = 60;
            this.teFullName.Tag = "ClientName";
            // 
            // memConsultContent
            // 
            this.dxErrorProvider.SetIconAlignment(this.memConsultContent, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.memConsultContent.Location = new System.Drawing.Point(107, 108);
            this.memConsultContent.MenuManager = this.barManager;
            this.memConsultContent.Name = "memConsultContent";
            this.memConsultContent.Size = new System.Drawing.Size(432, 203);
            this.memConsultContent.TabIndex = 65;
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.memConsultContent);
            this.plDetail.Controls.Add(this.lblConsultContent);
            this.plDetail.Controls.Add(this.teFullName);
            this.plDetail.Controls.Add(this.lblCellPhone);
            this.plDetail.Controls.Add(this.teCellPhone);
            this.plDetail.Controls.Add(this.lblFullName);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 24);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(564, 340);
            this.plDetail.TabIndex = 9;
            // 
            // lblConsultContent
            // 
            this.lblConsultContent.Location = new System.Drawing.Point(19, 108);
            this.lblConsultContent.Name = "lblConsultContent";
            this.lblConsultContent.Size = new System.Drawing.Size(52, 14);
            this.lblConsultContent.TabIndex = 64;
            this.lblConsultContent.Text = "问题描述:";
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.Location = new System.Drawing.Point(19, 68);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(40, 14);
            this.lblCellPhone.TabIndex = 59;
            this.lblCellPhone.Text = "手机号:";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(19, 32);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(28, 14);
            this.lblFullName.TabIndex = 38;
            this.lblFullName.Text = "姓名:";
            // 
            // FrmConsult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 364);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmConsult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "在线咨询";
            this.Load += new System.EventHandler(this.FrmConsult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCellPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memConsultContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemOK;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.MemoEdit memConsultContent;
        private DevExpress.XtraEditors.LabelControl lblConsultContent;
        private DevExpress.XtraEditors.TextEdit teFullName;
        private DevExpress.XtraEditors.LabelControl lblCellPhone;
        private DevExpress.XtraEditors.TextEdit teCellPhone;
        private DevExpress.XtraEditors.LabelControl lblFullName;
    }
}