namespace YF.MWS.Win.View.UI
{
    partial class FrmExtendControlDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtendControlDetail));
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
            this.combWeightExtendControl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teControlName = new DevExpress.XtraEditors.TextEdit();
            this.teFieldName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblFieldName = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblAttributeName = new DevExpress.XtraEditors.LabelControl();
            this.lblFieldNameNote = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combWeightExtendControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(429, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 223);
            this.barDockControlBottom.Size = new System.Drawing.Size(429, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 192);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(429, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 192);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "save_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "close_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // combWeightExtendControl
            // 
            this.dxErrorProvider.SetIconAlignment(this.combWeightExtendControl, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.combWeightExtendControl.Location = new System.Drawing.Point(112, 119);
            this.combWeightExtendControl.MenuManager = this.barManager;
            this.combWeightExtendControl.Name = "combWeightExtendControl";
            this.combWeightExtendControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combWeightExtendControl.Size = new System.Drawing.Size(244, 20);
            this.combWeightExtendControl.TabIndex = 53;
            this.combWeightExtendControl.Tag = "CarType";
            // 
            // teControlName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teControlName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teControlName.Location = new System.Drawing.Point(112, 34);
            this.teControlName.MenuManager = this.barManager;
            this.teControlName.Name = "teControlName";
            this.teControlName.Size = new System.Drawing.Size(244, 20);
            this.teControlName.TabIndex = 41;
            this.teControlName.Tag = "AttributeName";
            // 
            // teFieldName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teFieldName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teFieldName.Location = new System.Drawing.Point(112, 74);
            this.teFieldName.MenuManager = this.barManager;
            this.teFieldName.Name = "teFieldName";
            this.teFieldName.Size = new System.Drawing.Size(143, 20);
            this.teFieldName.TabIndex = 55;
            this.teFieldName.Tag = "FieldName";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblFieldNameNote);
            this.panelControl1.Controls.Add(this.teFieldName);
            this.panelControl1.Controls.Add(this.lblFieldName);
            this.panelControl1.Controls.Add(this.combWeightExtendControl);
            this.panelControl1.Controls.Add(this.lblFullName);
            this.panelControl1.Controls.Add(this.teControlName);
            this.panelControl1.Controls.Add(this.lblAttributeName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(429, 192);
            this.panelControl1.TabIndex = 8;
            // 
            // lblFieldName
            // 
            this.lblFieldName.Location = new System.Drawing.Point(28, 77);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(52, 14);
            this.lblFieldName.TabIndex = 54;
            this.lblFieldName.Text = "字段名称:";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(28, 121);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(28, 14);
            this.lblFullName.TabIndex = 44;
            this.lblFullName.Text = "控件:";
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.Location = new System.Drawing.Point(28, 37);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(52, 14);
            this.lblAttributeName.TabIndex = 40;
            this.lblAttributeName.Text = "属性名称:";
            // 
            // lblFieldNameNote
            // 
            this.lblFieldNameNote.Location = new System.Drawing.Point(264, 77);
            this.lblFieldNameNote.Name = "lblFieldNameNote";
            this.lblFieldNameNote.Size = new System.Drawing.Size(132, 14);
            this.lblFieldNameNote.TabIndex = 66;
            this.lblFieldNameNote.Text = "字段名称必须为英文字母";
            // 
            // FrmExtendControlDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 223);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(445, 262);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(445, 261);
            this.Name = "FrmExtendControlDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控件属性编辑";
            this.Load += new System.EventHandler(this.FrmExtendControlDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combWeightExtendControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combWeightExtendControl;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit teControlName;
        private DevExpress.XtraEditors.LabelControl lblAttributeName;
        private DevExpress.XtraEditors.TextEdit teFieldName;
        private DevExpress.XtraEditors.LabelControl lblFieldName;
        private DevExpress.XtraEditors.LabelControl lblFieldNameNote;
    }
}