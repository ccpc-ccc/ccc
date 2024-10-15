namespace YF.MWS.Win.View.UI
{
    partial class FrmExtendViewDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtendViewDetail));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.teErrorText = new DevExpress.XtraEditors.TextEdit();
            this.teControlName = new DevExpress.XtraEditors.TextEdit();
            this.chkReadonly = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsRequired = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.teDecimalDigits = new DevExpress.XtraEditors.TextEdit();
            this.lblDecimalDigits = new DevExpress.XtraEditors.LabelControl();
            this.teAutoCalcNo = new DevExpress.XtraEditors.TextEdit();
            this.lblAutoCalcNo = new DevExpress.XtraEditors.LabelControl();
            this.teExpression = new DevExpress.XtraEditors.TextEdit();
            this.lblExpression = new DevExpress.XtraEditors.LabelControl();
            this.teActionName = new DevExpress.XtraEditors.TextEdit();
            this.lblActionName = new DevExpress.XtraEditors.LabelControl();
            this.teFullName = new DevExpress.XtraEditors.TextEdit();
            this.lookupControl = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.lblErrorText = new DevExpress.XtraEditors.LabelControl();
            this.teCaption = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblControlName = new DevExpress.XtraEditors.LabelControl();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.teFieldName = new DevExpress.XtraEditors.TextEdit();
            this.lblFieldName = new DevExpress.XtraEditors.LabelControl();
            this.chkStartAutoSave = new DevExpress.XtraEditors.CheckEdit();
            this.chkStartStay = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teErrorText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadonly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDecimalDigits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAutoCalcNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teExpression.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartAutoSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartStay.Properties)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(562, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 486);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(562, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 455);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(562, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 455);
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
            // teErrorText
            // 
            this.dxErrorProvider.SetIconAlignment(this.teErrorText, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teErrorText.Location = new System.Drawing.Point(126, 277);
            this.teErrorText.MenuManager = this.barManager;
            this.teErrorText.Name = "teErrorText";
            this.teErrorText.Size = new System.Drawing.Size(387, 20);
            this.teErrorText.TabIndex = 49;
            this.teErrorText.Tag = "ErrorText";
            // 
            // teControlName
            // 
            this.dxErrorProvider.SetIconAlignment(this.teControlName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.teControlName.Location = new System.Drawing.Point(126, 56);
            this.teControlName.MenuManager = this.barManager;
            this.teControlName.Name = "teControlName";
            this.teControlName.Size = new System.Drawing.Size(387, 20);
            this.teControlName.TabIndex = 41;
            this.teControlName.Tag = "ControlName";
            // 
            // chkReadonly
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkReadonly, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkReadonly.Location = new System.Drawing.Point(124, 339);
            this.chkReadonly.MenuManager = this.barManager;
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Properties.Caption = "是否只读";
            this.chkReadonly.Size = new System.Drawing.Size(90, 19);
            this.chkReadonly.TabIndex = 69;
            this.chkReadonly.Tag = "";
            // 
            // chkIsRequired
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkIsRequired, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkIsRequired.Location = new System.Drawing.Point(124, 310);
            this.chkIsRequired.MenuManager = this.barManager;
            this.chkIsRequired.Name = "chkIsRequired";
            this.chkIsRequired.Properties.Caption = "是否必填项";
            this.chkIsRequired.Size = new System.Drawing.Size(90, 19);
            this.chkIsRequired.TabIndex = 68;
            this.chkIsRequired.Tag = "IsRequired";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkStartAutoSave);
            this.panelControl1.Controls.Add(this.chkStartStay);
            this.panelControl1.Controls.Add(this.chkReadonly);
            this.panelControl1.Controls.Add(this.chkIsRequired);
            this.panelControl1.Controls.Add(this.teDecimalDigits);
            this.panelControl1.Controls.Add(this.lblDecimalDigits);
            this.panelControl1.Controls.Add(this.teAutoCalcNo);
            this.panelControl1.Controls.Add(this.lblAutoCalcNo);
            this.panelControl1.Controls.Add(this.teExpression);
            this.panelControl1.Controls.Add(this.lblExpression);
            this.panelControl1.Controls.Add(this.teActionName);
            this.panelControl1.Controls.Add(this.lblActionName);
            this.panelControl1.Controls.Add(this.teFullName);
            this.panelControl1.Controls.Add(this.lookupControl);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.teOrderNo);
            this.panelControl1.Controls.Add(this.lblOrderNo);
            this.panelControl1.Controls.Add(this.teErrorText);
            this.panelControl1.Controls.Add(this.lblErrorText);
            this.panelControl1.Controls.Add(this.teCaption);
            this.panelControl1.Controls.Add(this.lblFullName);
            this.panelControl1.Controls.Add(this.teControlName);
            this.panelControl1.Controls.Add(this.lblControlName);
            this.panelControl1.Controls.Add(this.lblCaption);
            this.panelControl1.Controls.Add(this.teFieldName);
            this.panelControl1.Controls.Add(this.lblFieldName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(562, 455);
            this.panelControl1.TabIndex = 9;
            // 
            // teDecimalDigits
            // 
            this.teDecimalDigits.EditValue = "0";
            this.teDecimalDigits.Location = new System.Drawing.Point(126, 406);
            this.teDecimalDigits.MenuManager = this.barManager;
            this.teDecimalDigits.Name = "teDecimalDigits";
            this.teDecimalDigits.Properties.Mask.EditMask = "N0";
            this.teDecimalDigits.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teDecimalDigits.Size = new System.Drawing.Size(76, 20);
            this.teDecimalDigits.TabIndex = 67;
            this.teDecimalDigits.Tag = "DecimalDigits";
            // 
            // lblDecimalDigits
            // 
            this.lblDecimalDigits.Location = new System.Drawing.Point(30, 409);
            this.lblDecimalDigits.Name = "lblDecimalDigits";
            this.lblDecimalDigits.Size = new System.Drawing.Size(52, 14);
            this.lblDecimalDigits.TabIndex = 66;
            this.lblDecimalDigits.Text = "小数位数:";
            // 
            // teAutoCalcNo
            // 
            this.teAutoCalcNo.Location = new System.Drawing.Point(126, 149);
            this.teAutoCalcNo.MenuManager = this.barManager;
            this.teAutoCalcNo.Name = "teAutoCalcNo";
            this.teAutoCalcNo.Properties.Mask.EditMask = "N0";
            this.teAutoCalcNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teAutoCalcNo.Size = new System.Drawing.Size(76, 20);
            this.teAutoCalcNo.TabIndex = 65;
            this.teAutoCalcNo.Tag = "AutoCalcNo";
            // 
            // lblAutoCalcNo
            // 
            this.lblAutoCalcNo.Location = new System.Drawing.Point(30, 151);
            this.lblAutoCalcNo.Name = "lblAutoCalcNo";
            this.lblAutoCalcNo.Size = new System.Drawing.Size(64, 14);
            this.lblAutoCalcNo.TabIndex = 64;
            this.lblAutoCalcNo.Text = "计算顺序号:";
            // 
            // teExpression
            // 
            this.teExpression.Location = new System.Drawing.Point(126, 118);
            this.teExpression.MenuManager = this.barManager;
            this.teExpression.Name = "teExpression";
            this.teExpression.Size = new System.Drawing.Size(387, 20);
            this.teExpression.TabIndex = 63;
            this.teExpression.Tag = "Expression";
            // 
            // lblExpression
            // 
            this.lblExpression.Location = new System.Drawing.Point(30, 121);
            this.lblExpression.Name = "lblExpression";
            this.lblExpression.Size = new System.Drawing.Size(52, 14);
            this.lblExpression.TabIndex = 62;
            this.lblExpression.Text = "计算公式:";
            // 
            // teActionName
            // 
            this.teActionName.Location = new System.Drawing.Point(126, 180);
            this.teActionName.MenuManager = this.barManager;
            this.teActionName.Name = "teActionName";
            this.teActionName.Size = new System.Drawing.Size(129, 20);
            this.teActionName.TabIndex = 56;
            this.teActionName.Tag = "ActionName";
            // 
            // lblActionName
            // 
            this.lblActionName.Location = new System.Drawing.Point(30, 180);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(76, 14);
            this.lblActionName.TabIndex = 57;
            this.lblActionName.Text = "关联控件名称:";
            // 
            // teFullName
            // 
            this.teFullName.Location = new System.Drawing.Point(126, 213);
            this.teFullName.MenuManager = this.barManager;
            this.teFullName.Name = "teFullName";
            this.teFullName.Size = new System.Drawing.Size(387, 20);
            this.teFullName.TabIndex = 55;
            this.teFullName.Tag = "FullName";
            // 
            // lookupControl
            // 
            this.lookupControl.EditValue = "";
            this.lookupControl.Location = new System.Drawing.Point(126, 27);
            this.lookupControl.MenuManager = this.barManager;
            this.lookupControl.Name = "lookupControl";
            this.lookupControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupControl.Properties.NullText = "";
            this.lookupControl.Properties.PopupView = this.gridView1;
            this.lookupControl.Size = new System.Drawing.Size(387, 20);
            this.lookupControl.TabIndex = 54;
            this.lookupControl.Tag = "ControlId";
            this.lookupControl.EditValueChanged += new System.EventHandler(this.lookupControl_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "控件:";
            // 
            // teOrderNo
            // 
            this.teOrderNo.Location = new System.Drawing.Point(126, 374);
            this.teOrderNo.MenuManager = this.barManager;
            this.teOrderNo.Name = "teOrderNo";
            this.teOrderNo.Properties.Mask.EditMask = "N0";
            this.teOrderNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teOrderNo.Size = new System.Drawing.Size(76, 20);
            this.teOrderNo.TabIndex = 52;
            this.teOrderNo.Tag = "OrderNo";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(30, 377);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(40, 14);
            this.lblOrderNo.TabIndex = 51;
            this.lblOrderNo.Text = "排序号:";
            // 
            // lblErrorText
            // 
            this.lblErrorText.Location = new System.Drawing.Point(30, 280);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(52, 14);
            this.lblErrorText.TabIndex = 48;
            this.lblErrorText.Text = "验证提示:";
            // 
            // teCaption
            // 
            this.teCaption.Location = new System.Drawing.Point(126, 246);
            this.teCaption.MenuManager = this.barManager;
            this.teCaption.Name = "teCaption";
            this.teCaption.Size = new System.Drawing.Size(387, 20);
            this.teCaption.TabIndex = 47;
            this.teCaption.Tag = "Caption";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(30, 213);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(52, 14);
            this.lblFullName.TabIndex = 44;
            this.lblFullName.Text = "控件类型:";
            // 
            // lblControlName
            // 
            this.lblControlName.Location = new System.Drawing.Point(30, 59);
            this.lblControlName.Name = "lblControlName";
            this.lblControlName.Size = new System.Drawing.Size(52, 14);
            this.lblControlName.TabIndex = 40;
            this.lblControlName.Text = "控件名称:";
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(30, 246);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(28, 14);
            this.lblCaption.TabIndex = 39;
            this.lblCaption.Text = "标签:";
            // 
            // teFieldName
            // 
            this.teFieldName.Enabled = false;
            this.teFieldName.Location = new System.Drawing.Point(126, 87);
            this.teFieldName.MenuManager = this.barManager;
            this.teFieldName.Name = "teFieldName";
            this.teFieldName.Size = new System.Drawing.Size(129, 20);
            this.teFieldName.TabIndex = 36;
            this.teFieldName.Tag = "FieldName";
            // 
            // lblFieldName
            // 
            this.lblFieldName.Location = new System.Drawing.Point(30, 87);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(52, 14);
            this.lblFieldName.TabIndex = 38;
            this.lblFieldName.Text = "字段名称:";
            // 
            // chkStartAutoSave
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkStartAutoSave, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkStartAutoSave.Location = new System.Drawing.Point(289, 339);
            this.chkStartAutoSave.MenuManager = this.barManager;
            this.chkStartAutoSave.Name = "chkStartAutoSave";
            this.chkStartAutoSave.Properties.Caption = "启用输入项自动保存";
            this.chkStartAutoSave.Size = new System.Drawing.Size(135, 19);
            this.chkStartAutoSave.TabIndex = 71;
            this.chkStartAutoSave.Tag = "";
            // 
            // chkStartStay
            // 
            this.dxErrorProvider.SetIconAlignment(this.chkStartStay, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.chkStartStay.Location = new System.Drawing.Point(289, 310);
            this.chkStartStay.MenuManager = this.barManager;
            this.chkStartStay.Name = "chkStartStay";
            this.chkStartStay.Properties.Caption = "启用磅单驻留";
            this.chkStartStay.Size = new System.Drawing.Size(107, 19);
            this.chkStartStay.TabIndex = 70;
            this.chkStartStay.Tag = "IsRequired";
            // 
            // FrmExtendViewDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 486);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmExtendViewDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扩展控件编辑";
            this.Load += new System.EventHandler(this.FrmExtendViewDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teErrorText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teControlName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadonly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDecimalDigits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAutoCalcNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teExpression.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teActionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartAutoSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStartStay.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit teActionName;
        private DevExpress.XtraEditors.LabelControl lblActionName;
        private DevExpress.XtraEditors.TextEdit teFullName;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teOrderNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraEditors.TextEdit teErrorText;
        private DevExpress.XtraEditors.LabelControl lblErrorText;
        private DevExpress.XtraEditors.TextEdit teCaption;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit teControlName;
        private DevExpress.XtraEditors.LabelControl lblControlName;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.TextEdit teFieldName;
        private DevExpress.XtraEditors.LabelControl lblFieldName;
        private DevExpress.XtraEditors.TextEdit teAutoCalcNo;
        private DevExpress.XtraEditors.LabelControl lblAutoCalcNo;
        private DevExpress.XtraEditors.TextEdit teExpression;
        private DevExpress.XtraEditors.LabelControl lblExpression;
        private DevExpress.XtraEditors.TextEdit teDecimalDigits;
        private DevExpress.XtraEditors.LabelControl lblDecimalDigits;
        private DevExpress.XtraEditors.CheckEdit chkReadonly;
        private DevExpress.XtraEditors.CheckEdit chkIsRequired;
        private DevExpress.XtraEditors.CheckEdit chkStartAutoSave;
        private DevExpress.XtraEditors.CheckEdit chkStartStay;
    }
}