namespace YF.MWS.Win.View.Master
{
    partial class FrmWeightColumFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeightColumFormat));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnItemOK = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.weDisplayFormatType = new YF.MWS.Win.Uc.Weight.WComboBoxEdit();
            this.weSummaryItemType = new YF.MWS.Win.Uc.Weight.WComboBoxEdit();
            this.weControl = new YF.MWS.Win.Uc.Weight.WLookupSearchEdit();
            this.wLookupSearchEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.weFormatType = new YF.MWS.Win.Uc.Weight.WComboBoxEdit();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.lblFormatType = new DevExpress.XtraEditors.LabelControl();
            this.lblControl = new DevExpress.XtraEditors.LabelControl();
            this.lblSummaryItemType = new DevExpress.XtraEditors.LabelControl();
            this.lblDisplayFormatType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weDisplayFormatType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weSummaryItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weFormatType.Properties)).BeginInit();
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
            this.btnItemCancel});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemCancel, true)});
            this.barTop.Text = "Tools";
            // 
            // btnItemOK
            // 
            this.btnItemOK.Caption = "确定";
            this.btnItemOK.Id = 1;
            this.btnItemOK.ImageIndex = 0;
            this.btnItemOK.Name = "btnItemOK";
            this.btnItemOK.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemOK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemOK_ItemClick);
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Caption = "取消";
            this.btnItemCancel.Id = 7;
            this.btnItemCancel.ImageIndex = 1;
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnItemCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemCancel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(374, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 239);
            this.barDockControlBottom.Size = new System.Drawing.Size(374, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 208);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(374, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 208);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "apply_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "delete_16x16.png");
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // weDisplayFormatType
            // 
            this.weDisplayFormatType.ActionName = null;
            this.weDisplayFormatType.AutoCalcNo = 0;
            this.weDisplayFormatType.Caption = null;
            this.weDisplayFormatType.ControlName = null;
            this.weDisplayFormatType.CurrentValue = "";
            this.weDisplayFormatType.DecimalDigits = 0;
            this.weDisplayFormatType.EditText = "";
            this.weDisplayFormatType.EditValue = "";
            this.weDisplayFormatType.Expression = null;
            this.weDisplayFormatType.FieldName = "DisplayFormatStringType";
            this.dxErrorProvider.SetIconAlignment(this.weDisplayFormatType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weDisplayFormatType.IsRequired = false;
            this.weDisplayFormatType.Location = new System.Drawing.Point(107, 108);
            this.weDisplayFormatType.MenuManager = this.barManager;
            this.weDisplayFormatType.Name = "weDisplayFormatType";
            this.weDisplayFormatType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weDisplayFormatType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weDisplayFormatType.Size = new System.Drawing.Size(222, 20);
            this.weDisplayFormatType.TabIndex = 63;
            this.weDisplayFormatType.WeightVauleChanged = null;
            // 
            // weSummaryItemType
            // 
            this.weSummaryItemType.ActionName = null;
            this.weSummaryItemType.AutoCalcNo = 0;
            this.weSummaryItemType.Caption = null;
            this.weSummaryItemType.ControlName = null;
            this.weSummaryItemType.CurrentValue = "";
            this.weSummaryItemType.DecimalDigits = 0;
            this.weSummaryItemType.EditText = "";
            this.weSummaryItemType.EditValue = "";
            this.weSummaryItemType.Expression = null;
            this.weSummaryItemType.FieldName = "WeightSummaryItemType";
            this.dxErrorProvider.SetIconAlignment(this.weSummaryItemType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weSummaryItemType.IsRequired = false;
            this.weSummaryItemType.Location = new System.Drawing.Point(107, 149);
            this.weSummaryItemType.MenuManager = this.barManager;
            this.weSummaryItemType.Name = "weSummaryItemType";
            this.weSummaryItemType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weSummaryItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weSummaryItemType.Size = new System.Drawing.Size(222, 20);
            this.weSummaryItemType.TabIndex = 62;
            this.weSummaryItemType.WeightVauleChanged = null;
            // 
            // weControl
            // 
            this.weControl.ActionName = null;
            this.weControl.AutoCalcNo = 0;
            this.weControl.Caption = null;
            this.weControl.ControlName = null;
            this.weControl.CurrentValue = "";
            this.weControl.DecimalDigits = 0;
            this.weControl.EditText = "";
            this.weControl.EditValue = "";
            this.weControl.Expression = null;
            this.weControl.FieldName = "WeightControlId";
            this.dxErrorProvider.SetIconAlignment(this.weControl, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weControl.IsRequired = false;
            this.weControl.Location = new System.Drawing.Point(107, 32);
            this.weControl.MenuManager = this.barManager;
            this.weControl.Name = "weControl";
            this.weControl.ParentLocation = new System.Drawing.Point(0, 0);
            this.weControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weControl.Properties.NullText = "";
            this.weControl.Properties.View = this.wLookupSearchEdit1View;
            this.weControl.Size = new System.Drawing.Size(222, 20);
            this.weControl.TabIndex = 61;
            this.weControl.WeightVauleChanged = null;
            // 
            // wLookupSearchEdit1View
            // 
            this.wLookupSearchEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wLookupSearchEdit1View.Name = "wLookupSearchEdit1View";
            this.wLookupSearchEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wLookupSearchEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // weFormatType
            // 
            this.weFormatType.ActionName = null;
            this.weFormatType.AutoCalcNo = 0;
            this.weFormatType.Caption = null;
            this.weFormatType.ControlName = null;
            this.weFormatType.CurrentValue = "";
            this.weFormatType.DecimalDigits = 0;
            this.weFormatType.EditText = "";
            this.weFormatType.EditValue = "";
            this.weFormatType.Expression = null;
            this.weFormatType.FieldName = "FormatType";
            this.dxErrorProvider.SetIconAlignment(this.weFormatType, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.weFormatType.IsRequired = false;
            this.weFormatType.Location = new System.Drawing.Point(107, 69);
            this.weFormatType.MenuManager = this.barManager;
            this.weFormatType.Name = "weFormatType";
            this.weFormatType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weFormatType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weFormatType.Size = new System.Drawing.Size(222, 20);
            this.weFormatType.TabIndex = 65;
            this.weFormatType.WeightVauleChanged = null;
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.weFormatType);
            this.plDetail.Controls.Add(this.lblFormatType);
            this.plDetail.Controls.Add(this.weDisplayFormatType);
            this.plDetail.Controls.Add(this.weSummaryItemType);
            this.plDetail.Controls.Add(this.weControl);
            this.plDetail.Controls.Add(this.lblControl);
            this.plDetail.Controls.Add(this.lblSummaryItemType);
            this.plDetail.Controls.Add(this.lblDisplayFormatType);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDetail.Location = new System.Drawing.Point(0, 31);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(374, 208);
            this.plDetail.TabIndex = 9;
            // 
            // lblFormatType
            // 
            this.lblFormatType.Location = new System.Drawing.Point(19, 69);
            this.lblFormatType.Name = "lblFormatType";
            this.lblFormatType.Size = new System.Drawing.Size(52, 14);
            this.lblFormatType.TabIndex = 64;
            this.lblFormatType.Text = "字段类型:";
            // 
            // lblControl
            // 
            this.lblControl.Location = new System.Drawing.Point(19, 35);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(28, 14);
            this.lblControl.TabIndex = 59;
            this.lblControl.Text = "字段:";
            // 
            // lblSummaryItemType
            // 
            this.lblSummaryItemType.Location = new System.Drawing.Point(19, 149);
            this.lblSummaryItemType.Name = "lblSummaryItemType";
            this.lblSummaryItemType.Size = new System.Drawing.Size(52, 14);
            this.lblSummaryItemType.TabIndex = 40;
            this.lblSummaryItemType.Text = "统计类型:";
            // 
            // lblDisplayFormatType
            // 
            this.lblDisplayFormatType.Location = new System.Drawing.Point(19, 108);
            this.lblDisplayFormatType.Name = "lblDisplayFormatType";
            this.lblDisplayFormatType.Size = new System.Drawing.Size(52, 14);
            this.lblDisplayFormatType.TabIndex = 38;
            this.lblDisplayFormatType.Text = "显示格式:";
            // 
            // FrmWeightColumFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 239);
            this.Controls.Add(this.plDetail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmWeightColumFormat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字段格式设置";
            this.Load += new System.EventHandler(this.FrmWeightColumFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weDisplayFormatType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weSummaryItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weFormatType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem btnItemOK;
        private DevExpress.XtraBars.BarButtonItem btnItemCancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private Uc.Weight.WComboBoxEdit weFormatType;
        private DevExpress.XtraEditors.LabelControl lblFormatType;
        private Uc.Weight.WComboBoxEdit weDisplayFormatType;
        private Uc.Weight.WComboBoxEdit weSummaryItemType;
        private Uc.Weight.WLookupSearchEdit weControl;
        private DevExpress.XtraGrid.Views.Grid.GridView wLookupSearchEdit1View;
        private DevExpress.XtraEditors.LabelControl lblControl;
        private DevExpress.XtraEditors.LabelControl lblSummaryItemType;
        private DevExpress.XtraEditors.LabelControl lblDisplayFormatType;
    }
}