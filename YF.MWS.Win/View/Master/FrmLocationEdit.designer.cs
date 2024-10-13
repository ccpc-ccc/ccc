namespace YF.MWS.Win.View.Master
{
    partial class FrmLocationEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocationEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.teLocationName = new DevExpress.XtraEditors.TextEdit();
            this.teLocationCode = new DevExpress.XtraEditors.TextEdit();
            this.combLocationType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblLocationName = new DevExpress.XtraEditors.LabelControl();
            this.lblLocationType = new DevExpress.XtraEditors.LabelControl();
            this.lblLocationCode = new DevExpress.XtraEditors.LabelControl();
            this.rgValidateInput = new DevExpress.XtraEditors.RadioGroup();
            this.lblValidateInput = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLocationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLocationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combLocationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgValidateInput.Properties)).BeginInit();
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
            this.btnItemSave,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(383, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 277);
            this.barDockControlBottom.Size = new System.Drawing.Size(383, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 246);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(383, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 246);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // teLocationName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teLocationName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teLocationName.Location = new System.Drawing.Point(122, 175);
            this.teLocationName.MenuManager = this.barManager;
            this.teLocationName.Name = "teLocationName";
            this.teLocationName.Size = new System.Drawing.Size(212, 20);
            this.teLocationName.TabIndex = 58;
            this.teLocationName.Tag = "DriverName";
            // 
            // teLocationCode
            // 
            this.dxErrorProvider.SetIconAlignment(this.teLocationCode, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teLocationCode.Location = new System.Drawing.Point(122, 140);
            this.teLocationCode.MenuManager = this.barManager;
            this.teLocationCode.Name = "teLocationCode";
            this.teLocationCode.Size = new System.Drawing.Size(212, 20);
            this.teLocationCode.TabIndex = 36;
            this.teLocationCode.Tag = "CarNo";
            // 
            // combLocationType
            // 
            this.dxErrorProvider.SetIconAlignment(this.combLocationType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combLocationType.Location = new System.Drawing.Point(122, 22);
            this.combLocationType.MenuManager = this.barManager;
            this.combLocationType.Name = "combLocationType";
            this.combLocationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combLocationType.Size = new System.Drawing.Size(212, 20);
            this.combLocationType.TabIndex = 74;
            this.combLocationType.Tag = "Gender";
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.lblValidateInput);
            this.plDetail.Controls.Add(this.rgValidateInput);
            this.plDetail.Controls.Add(this.combLocationType);
            this.plDetail.Controls.Add(this.lblLocationName);
            this.plDetail.Controls.Add(this.teLocationName);
            this.plDetail.Controls.Add(this.lblLocationType);
            this.plDetail.Controls.Add(this.teLocationCode);
            this.plDetail.Controls.Add(this.lblLocationCode);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(383, 246);
            this.plDetail.TabIndex = 8;
            // 
            // lblLocationName
            // 
            this.lblLocationName.Location = new System.Drawing.Point(19, 175);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(52, 14);
            this.lblLocationName.TabIndex = 59;
            this.lblLocationName.Text = "位置名称:";
            // 
            // lblLocationType
            // 
            this.lblLocationType.Location = new System.Drawing.Point(19, 25);
            this.lblLocationType.Name = "lblLocationType";
            this.lblLocationType.Size = new System.Drawing.Size(52, 14);
            this.lblLocationType.TabIndex = 40;
            this.lblLocationType.Text = "位置类别:";
            // 
            // lblLocationCode
            // 
            this.lblLocationCode.Location = new System.Drawing.Point(19, 140);
            this.lblLocationCode.Name = "lblLocationCode";
            this.lblLocationCode.Size = new System.Drawing.Size(52, 14);
            this.lblLocationCode.TabIndex = 38;
            this.lblLocationCode.Text = "位置编码:";
            // 
            // rgValidateInput
            // 
            this.rgValidateInput.EditValue = "UnValidate";
            this.rgValidateInput.Location = new System.Drawing.Point(122, 60);
            this.rgValidateInput.MenuManager = this.barManager;
            this.rgValidateInput.Name = "rgValidateInput";
            this.rgValidateInput.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgValidateInput.Properties.Appearance.Options.UseBackColor = true;
            this.rgValidateInput.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.rgValidateInput.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("UnValidate", "不验证"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ValidateNew", "验证新磅单"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ValidateFinish", "完成时验证"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ValidateAny", "每次都验证")});
            this.rgValidateInput.Size = new System.Drawing.Size(212, 57);
            this.rgValidateInput.TabIndex = 75;
            // 
            // lblValidateInput
            // 
            this.lblValidateInput.Location = new System.Drawing.Point(19, 60);
            this.lblValidateInput.Name = "lblValidateInput";
            this.lblValidateInput.Size = new System.Drawing.Size(64, 14);
            this.lblValidateInput.TabIndex = 76;
            this.lblValidateInput.Text = "验证输入项:";
            // 
            // FrmLocationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 277);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmLocationEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "位置编辑";
            this.Load += new System.EventHandler(this.FrmLocationEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLocationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLocationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combLocationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgValidateInput.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemSave;
        private DevExpress.XtraBars.BarButtonItem btnItemClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private DevExpress.XtraEditors.LabelControl lblLocationName;
        private DevExpress.XtraEditors.TextEdit teLocationName;
        private DevExpress.XtraEditors.LabelControl lblLocationType;
        private DevExpress.XtraEditors.TextEdit teLocationCode;
        private DevExpress.XtraEditors.LabelControl lblLocationCode;
        private DevExpress.XtraEditors.ComboBoxEdit combLocationType;
        private DevExpress.XtraEditors.RadioGroup rgValidateInput;
        private DevExpress.XtraEditors.LabelControl lblValidateInput;
    }
}