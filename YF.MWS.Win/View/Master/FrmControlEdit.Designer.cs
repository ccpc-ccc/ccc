namespace YF.MWS.Win.View.Master
{
    partial class FrmControlEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlEdit));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.teControlName = new DevExpress.XtraEditors.TextEdit();
            this.lblControlName = new DevExpress.XtraEditors.LabelControl();
            this.teFieldName = new DevExpress.XtraEditors.TextEdit();
            this.lblFieldName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.combWeightControl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teActionName = new DevExpress.XtraEditors.TextEdit();
            this.lblActionName = new DevExpress.XtraEditors.LabelControl();
            this.lblIsRequired = new DevExpress.XtraEditors.LabelControl();
            this.teErrorText = new DevExpress.XtraEditors.TextEdit();
            this.lblErrorText = new DevExpress.XtraEditors.LabelControl();
            this.teCaption = new DevExpress.XtraEditors.TextEdit();
            this.chkIsRequired = new DevExpress.XtraEditors.CheckEdit();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combWeightControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teErrorText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
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
            this.barManager.MaxItemId = 10;
            // 
            // barTop
            // 
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemClose)});
            this.barTop.Text = "Tools";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Caption = "保存";
            this.btnItemSave.Id = 1;
            this.btnItemSave.ImageOptions.ImageIndex = 0;
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemSave_ItemClick);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Caption = "关闭";
            this.btnItemClose.Id = 7;
            this.btnItemClose.ImageOptions.ImageIndex = 1;
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(562, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 287);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(562, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 263);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(562, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 263);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // teControlName
            // 
            this.teControlName.Location = new System.Drawing.Point(133, 18);
            this.teControlName.MenuManager = this.barManager;
            this.teControlName.Name = "teControlName";
            this.teControlName.Size = new System.Drawing.Size(387, 20);
            this.teControlName.TabIndex = 41;
            this.teControlName.Tag = "ControlName";
            // 
            // lblControlName
            // 
            this.lblControlName.Location = new System.Drawing.Point(31, 21);
            this.lblControlName.Name = "lblControlName";
            this.lblControlName.Size = new System.Drawing.Size(52, 14);
            this.lblControlName.TabIndex = 40;
            this.lblControlName.Text = "控件名称:";
            // 
            // teFieldName
            // 
            this.teFieldName.Location = new System.Drawing.Point(133, 51);
            this.teFieldName.MenuManager = this.barManager;
            this.teFieldName.Name = "teFieldName";
            this.teFieldName.Size = new System.Drawing.Size(387, 20);
            this.teFieldName.TabIndex = 36;
            this.teFieldName.Tag = "FieldName";
            // 
            // lblFieldName
            // 
            this.lblFieldName.Location = new System.Drawing.Point(31, 51);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(52, 14);
            this.lblFieldName.TabIndex = 38;
            this.lblFieldName.Text = "属性名称:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.combWeightControl);
            this.panelControl1.Controls.Add(this.teActionName);
            this.panelControl1.Controls.Add(this.lblActionName);
            this.panelControl1.Controls.Add(this.lblIsRequired);
            this.panelControl1.Controls.Add(this.teErrorText);
            this.panelControl1.Controls.Add(this.lblErrorText);
            this.panelControl1.Controls.Add(this.teCaption);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.chkIsRequired);
            this.panelControl1.Controls.Add(this.lblFullName);
            this.panelControl1.Controls.Add(this.teControlName);
            this.panelControl1.Controls.Add(this.lblControlName);
            this.panelControl1.Controls.Add(this.lblCaption);
            this.panelControl1.Controls.Add(this.teFieldName);
            this.panelControl1.Controls.Add(this.lblFieldName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(562, 263);
            this.panelControl1.TabIndex = 7;
            // 
            // combWeightControl
            // 
            this.dxErrorProvider.SetIconAlignment(this.combWeightControl, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combWeightControl.Location = new System.Drawing.Point(133, 115);
            this.combWeightControl.MenuManager = this.barManager;
            this.combWeightControl.Name = "combWeightControl";
            this.combWeightControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combWeightControl.Size = new System.Drawing.Size(387, 20);
            this.combWeightControl.TabIndex = 53;
            this.combWeightControl.Tag = "CarType";
            // 
            // teActionName
            // 
            this.teActionName.Location = new System.Drawing.Point(133, 81);
            this.teActionName.MenuManager = this.barManager;
            this.teActionName.Name = "teActionName";
            this.teActionName.Size = new System.Drawing.Size(129, 20);
            this.teActionName.TabIndex = 51;
            this.teActionName.Tag = "ActionName";
            // 
            // lblActionName
            // 
            this.lblActionName.Location = new System.Drawing.Point(31, 81);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(76, 14);
            this.lblActionName.TabIndex = 52;
            this.lblActionName.Text = "关联动作名称:";
            // 
            // lblIsRequired
            // 
            this.lblIsRequired.Location = new System.Drawing.Point(31, 224);
            this.lblIsRequired.Name = "lblIsRequired";
            this.lblIsRequired.Size = new System.Drawing.Size(64, 14);
            this.lblIsRequired.TabIndex = 50;
            this.lblIsRequired.Text = "是否必填项:";
            // 
            // teErrorText
            // 
            this.teErrorText.Location = new System.Drawing.Point(133, 186);
            this.teErrorText.MenuManager = this.barManager;
            this.teErrorText.Name = "teErrorText";
            this.teErrorText.Size = new System.Drawing.Size(387, 20);
            this.teErrorText.TabIndex = 49;
            this.teErrorText.Tag = "ErrorText";
            // 
            // lblErrorText
            // 
            this.lblErrorText.Location = new System.Drawing.Point(31, 189);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(52, 14);
            this.lblErrorText.TabIndex = 48;
            this.lblErrorText.Text = "验证提示:";
            // 
            // teCaption
            // 
            this.teCaption.Location = new System.Drawing.Point(133, 151);
            this.teCaption.MenuManager = this.barManager;
            this.teCaption.Name = "teCaption";
            this.teCaption.Size = new System.Drawing.Size(387, 20);
            this.teCaption.TabIndex = 47;
            this.teCaption.Tag = "Caption";
            // 
            // chkIsRequired
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkIsRequired, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkIsRequired.Location = new System.Drawing.Point(131, 221);
            this.chkIsRequired.MenuManager = this.barManager;
            this.chkIsRequired.Name = "chkIsRequired";
            this.chkIsRequired.Properties.Caption = "";
            this.chkIsRequired.Size = new System.Drawing.Size(27, 20);
            this.chkIsRequired.TabIndex = 46;
            this.chkIsRequired.Tag = "IsRequired";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(31, 117);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(28, 14);
            this.lblFullName.TabIndex = 44;
            this.lblFullName.Text = "控件:";
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(31, 154);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(28, 14);
            this.lblCaption.TabIndex = 39;
            this.lblCaption.Text = "标签:";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(397, 221);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "界面显示";
            this.checkEdit1.Size = new System.Drawing.Size(109, 20);
            this.checkEdit1.TabIndex = 46;
            this.checkEdit1.Tag = "IsViewShow";
            // 
            // FrmControlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 287);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(578, 326);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(564, 319);
            this.Name = "FrmControlEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控件编辑";
            this.Load += new System.EventHandler(this.FrmControlEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combWeightControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teErrorText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit teControlName;
        private DevExpress.XtraEditors.LabelControl lblControlName;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.TextEdit teFieldName;
        private DevExpress.XtraEditors.LabelControl lblFieldName;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.TextEdit teErrorText;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.TextEdit teCaption;
        private DevExpress.XtraEditors.CheckEdit chkIsRequired;
        private DevExpress.XtraEditors.LabelControl lblIsRequired;
        private DevExpress.XtraEditors.TextEdit teActionName;
        private DevExpress.XtraEditors.LabelControl lblActionName;
        private DevExpress.XtraEditors.ComboBoxEdit combWeightControl;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}