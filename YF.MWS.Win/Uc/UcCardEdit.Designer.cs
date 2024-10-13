namespace YF.MWS.Win.Uc
{
    partial class UcCardEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupOther = new DevExpress.XtraEditors.GroupControl();
            this.scOther = new DevExpress.XtraEditors.XtraScrollableControl();
            this.cardView = new YF.MWS.Win.Uc.CardView();
            this.plDetail = new DevExpress.XtraEditors.PanelControl();
            this.weWarehBizType = new YF.MWS.Win.Uc.Weight.WComboBoxEdit();
            this.weWareh = new YF.MWS.Win.Uc.Weight.WLookupSearchEdit();
            this.wLookupSearchEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.teCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblCardNo = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.teRemark = new DevExpress.XtraEditors.TextEdit();
            this.teCardId = new DevExpress.XtraEditors.TextEdit();
            this.lblCardId = new DevExpress.XtraEditors.LabelControl();
            this.lookupCustomer = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lookupMaterialId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.lookupReceiverId = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lookupDeliveryId = new YF.MWS.Win.Uc.Weight.WCustomerEdit();
            this.lookupCar = new YF.MWS.Win.Uc.Weight.WCarLookup();
            this.lblWareh = new DevExpress.XtraEditors.LabelControl();
            this.lblReceiver = new DevExpress.XtraEditors.LabelControl();
            this.lblDelivery = new DevExpress.XtraEditors.LabelControl();
            this.lblDriverName = new DevExpress.XtraEditors.LabelControl();
            this.teDriverName = new DevExpress.XtraEditors.TextEdit();
            this.lblWarehBizType = new DevExpress.XtraEditors.LabelControl();
            this.lblCarNo = new DevExpress.XtraEditors.LabelControl();
            this.timerReadCard = new System.Windows.Forms.Timer(this.components);
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.lblTareWeight = new DevExpress.XtraEditors.LabelControl();
            this.teTareWeight = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOther)).BeginInit();
            this.groupOther.SuspendLayout();
            this.scOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).BeginInit();
            this.plDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWareh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCardId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupMaterialId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupReceiverId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDeliveryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDriverName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTareWeight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOther
            // 
            this.groupOther.Controls.Add(this.scOther);
            this.groupOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOther.Location = new System.Drawing.Point(0, 182);
            this.groupOther.Name = "groupOther";
            this.groupOther.Size = new System.Drawing.Size(943, 373);
            this.groupOther.TabIndex = 15;
            this.groupOther.Text = "其他相关值";
            // 
            // scOther
            // 
            this.scOther.Controls.Add(this.cardView);
            this.scOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOther.Location = new System.Drawing.Point(2, 21);
            this.scOther.Name = "scOther";
            this.scOther.Size = new System.Drawing.Size(939, 350);
            this.scOther.TabIndex = 0;
            // 
            // cardView
            // 
            this.cardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardView.Location = new System.Drawing.Point(0, 0);
            this.cardView.Name = "cardView";
            this.cardView.Size = new System.Drawing.Size(939, 350);
            this.cardView.TabIndex = 0;
            // 
            // plDetail
            // 
            this.plDetail.Controls.Add(this.lblTareWeight);
            this.plDetail.Controls.Add(this.teTareWeight);
            this.plDetail.Controls.Add(this.weWarehBizType);
            this.plDetail.Controls.Add(this.weWareh);
            this.plDetail.Controls.Add(this.teCardNo);
            this.plDetail.Controls.Add(this.lblCardNo);
            this.plDetail.Controls.Add(this.lblRemark);
            this.plDetail.Controls.Add(this.teRemark);
            this.plDetail.Controls.Add(this.teCardId);
            this.plDetail.Controls.Add(this.lblCardId);
            this.plDetail.Controls.Add(this.lookupCustomer);
            this.plDetail.Controls.Add(this.lookupMaterialId);
            this.plDetail.Controls.Add(this.lblMaterialName);
            this.plDetail.Controls.Add(this.lblCustomer);
            this.plDetail.Controls.Add(this.lookupReceiverId);
            this.plDetail.Controls.Add(this.lookupDeliveryId);
            this.plDetail.Controls.Add(this.lookupCar);
            this.plDetail.Controls.Add(this.lblWareh);
            this.plDetail.Controls.Add(this.lblReceiver);
            this.plDetail.Controls.Add(this.lblDelivery);
            this.plDetail.Controls.Add(this.lblDriverName);
            this.plDetail.Controls.Add(this.teDriverName);
            this.plDetail.Controls.Add(this.lblWarehBizType);
            this.plDetail.Controls.Add(this.lblCarNo);
            this.plDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.plDetail.Location = new System.Drawing.Point(0, 0);
            this.plDetail.Name = "plDetail";
            this.plDetail.Size = new System.Drawing.Size(943, 182);
            this.plDetail.TabIndex = 14;
            // 
            // weWarehBizType
            // 
            this.weWarehBizType.ActionName = null;
            this.weWarehBizType.AutoCalcNo = 0;
            this.weWarehBizType.Caption = null;
            this.weWarehBizType.ControlName = null;
            this.weWarehBizType.CurrentValue = "";
            this.weWarehBizType.DecimalDigits = 0;
            this.weWarehBizType.EditText = "";
            this.weWarehBizType.EditValue = "";
            this.weWarehBizType.ErrorTipText = null;
            this.weWarehBizType.Expression = "";
            this.weWarehBizType.FieldName = "WarehBizType";
            this.weWarehBizType.IsRequired = false;
            this.weWarehBizType.Location = new System.Drawing.Point(734, 46);
            this.weWarehBizType.Name = "weWarehBizType";
            this.weWarehBizType.ParentLocation = new System.Drawing.Point(0, 0);
            this.weWarehBizType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weWarehBizType.Size = new System.Drawing.Size(191, 20);
            this.weWarehBizType.StartAutoSave = false;
            this.weWarehBizType.StartStay = false;
            this.weWarehBizType.TabIndex = 86;
            this.weWarehBizType.WeightVauleChanged = null;
            // 
            // weWareh
            // 
            this.weWareh.ActionName = null;
            this.weWareh.AutoCalcNo = 0;
            this.weWareh.Caption = null;
            this.weWareh.ControlName = null;
            this.weWareh.CurrentValue = "";
            this.weWareh.DecimalDigits = 0;
            this.weWareh.EditText = "";
            this.weWareh.EditValue = "";
            this.weWareh.ErrorTipText = null;
            this.weWareh.Expression = null;
            this.weWareh.FieldName = "WarehId";
            this.weWareh.IsRequired = false;
            this.weWareh.Location = new System.Drawing.Point(734, 13);
            this.weWareh.Name = "weWareh";
            this.weWareh.ParentLocation = new System.Drawing.Point(0, 0);
            this.weWareh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.weWareh.Properties.NullText = "";
            this.weWareh.Properties.PopupView = this.wLookupSearchEdit1View;
            this.weWareh.Size = new System.Drawing.Size(191, 20);
            this.weWareh.StartAutoSave = false;
            this.weWareh.StartStay = false;
            this.weWareh.TabIndex = 85;
            this.weWareh.WeightVauleChanged = null;
            // 
            // wLookupSearchEdit1View
            // 
            this.wLookupSearchEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.wLookupSearchEdit1View.Name = "wLookupSearchEdit1View";
            this.wLookupSearchEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.wLookupSearchEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // teCardNo
            // 
            this.teCardNo.Location = new System.Drawing.Point(87, 47);
            this.teCardNo.Name = "teCardNo";
            this.teCardNo.Properties.ReadOnly = true;
            this.teCardNo.Size = new System.Drawing.Size(193, 20);
            this.teCardNo.TabIndex = 83;
            this.teCardNo.Tag = "CardNo";
            // 
            // lblCardNo
            // 
            this.lblCardNo.Location = new System.Drawing.Point(19, 48);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(28, 14);
            this.lblCardNo.TabIndex = 84;
            this.lblCardNo.Text = "卡号:";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(19, 148);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(28, 14);
            this.lblRemark.TabIndex = 82;
            this.lblRemark.Text = "备注:";
            // 
            // teRemark
            // 
            this.teRemark.Location = new System.Drawing.Point(87, 145);
            this.teRemark.Name = "teRemark";
            this.teRemark.Size = new System.Drawing.Size(532, 20);
            this.teRemark.TabIndex = 81;
            this.teRemark.Tag = "Remark";
            // 
            // teCardId
            // 
            this.teCardId.Location = new System.Drawing.Point(87, 14);
            this.teCardId.Name = "teCardId";
            this.teCardId.Properties.ReadOnly = true;
            this.teCardId.Size = new System.Drawing.Size(193, 20);
            this.teCardId.TabIndex = 79;
            this.teCardId.Tag = "CardId";
            // 
            // lblCardId
            // 
            this.lblCardId.Location = new System.Drawing.Point(19, 15);
            this.lblCardId.Name = "lblCardId";
            this.lblCardId.Size = new System.Drawing.Size(28, 14);
            this.lblCardId.TabIndex = 80;
            this.lblCardId.Text = "编号:";
            // 
            // lookupCustomer
            // 
            this.lookupCustomer.ActionName = null;
            this.lookupCustomer.AutoCalcNo = 0;
            this.lookupCustomer.Caption = null;
            this.lookupCustomer.ControlName = null;
            this.lookupCustomer.CurrentValue = null;
            this.lookupCustomer.DecimalDigits = 0;
            this.lookupCustomer.EditText = "";
            this.lookupCustomer.EditValue = "";
            this.lookupCustomer.ErrorTipText = null;
            this.lookupCustomer.Expression = null;
            this.lookupCustomer.FieldName = null;
            this.lookupCustomer.IsRequired = false;
            this.lookupCustomer.Location = new System.Drawing.Point(87, 112);
            this.lookupCustomer.Name = "lookupCustomer";
            this.lookupCustomer.ParentLocation = new System.Drawing.Point(0, 0);
            this.lookupCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lookupCustomer.Size = new System.Drawing.Size(193, 20);
            this.lookupCustomer.StartAutoSave = false;
            this.lookupCustomer.StartStay = false;
            this.lookupCustomer.TabIndex = 78;
            this.lookupCustomer.Type = YF.MWS.BaseMetadata.CustomerType.Customer;
            this.lookupCustomer.WeightVauleChanged = null;
            // 
            // lookupMaterialId
            // 
            this.lookupMaterialId.Location = new System.Drawing.Point(87, 81);
            this.lookupMaterialId.Name = "lookupMaterialId";
            this.lookupMaterialId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupMaterialId.Properties.NullText = "";
            this.lookupMaterialId.Properties.PopupView = this.gridView2;
            this.lookupMaterialId.Size = new System.Drawing.Size(193, 20);
            this.lookupMaterialId.TabIndex = 77;
            this.lookupMaterialId.Tag = "MaterialId";
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Location = new System.Drawing.Point(19, 84);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialName.TabIndex = 76;
            this.lblMaterialName.Text = "货物名称:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(19, 115);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(52, 14);
            this.lblCustomer.TabIndex = 75;
            this.lblCustomer.Text = "客户单位:";
            // 
            // lookupReceiverId
            // 
            this.lookupReceiverId.ActionName = null;
            this.lookupReceiverId.AutoCalcNo = 0;
            this.lookupReceiverId.Caption = null;
            this.lookupReceiverId.ControlName = null;
            this.lookupReceiverId.CurrentValue = null;
            this.lookupReceiverId.DecimalDigits = 0;
            this.lookupReceiverId.EditText = "";
            this.lookupReceiverId.EditValue = "";
            this.lookupReceiverId.ErrorTipText = null;
            this.lookupReceiverId.Expression = null;
            this.lookupReceiverId.FieldName = null;
            this.lookupReceiverId.IsRequired = false;
            this.lookupReceiverId.Location = new System.Drawing.Point(389, 78);
            this.lookupReceiverId.Name = "lookupReceiverId";
            this.lookupReceiverId.ParentLocation = new System.Drawing.Point(0, 0);
            this.lookupReceiverId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lookupReceiverId.Size = new System.Drawing.Size(230, 20);
            this.lookupReceiverId.StartAutoSave = false;
            this.lookupReceiverId.StartStay = false;
            this.lookupReceiverId.TabIndex = 74;
            this.lookupReceiverId.Type = YF.MWS.BaseMetadata.CustomerType.Receiver;
            this.lookupReceiverId.WeightVauleChanged = null;
            // 
            // lookupDeliveryId
            // 
            this.lookupDeliveryId.ActionName = null;
            this.lookupDeliveryId.AutoCalcNo = 0;
            this.lookupDeliveryId.Caption = null;
            this.lookupDeliveryId.ControlName = null;
            this.lookupDeliveryId.CurrentValue = null;
            this.lookupDeliveryId.DecimalDigits = 0;
            this.lookupDeliveryId.EditText = "";
            this.lookupDeliveryId.EditValue = "";
            this.lookupDeliveryId.ErrorTipText = null;
            this.lookupDeliveryId.Expression = null;
            this.lookupDeliveryId.FieldName = null;
            this.lookupDeliveryId.IsRequired = false;
            this.lookupDeliveryId.Location = new System.Drawing.Point(389, 109);
            this.lookupDeliveryId.Name = "lookupDeliveryId";
            this.lookupDeliveryId.ParentLocation = new System.Drawing.Point(0, 0);
            this.lookupDeliveryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lookupDeliveryId.Size = new System.Drawing.Size(230, 20);
            this.lookupDeliveryId.StartAutoSave = false;
            this.lookupDeliveryId.StartStay = false;
            this.lookupDeliveryId.TabIndex = 73;
            this.lookupDeliveryId.Type = YF.MWS.BaseMetadata.CustomerType.Delivery;
            this.lookupDeliveryId.WeightVauleChanged = null;
            // 
            // lookupCar
            // 
            this.lookupCar.ActionName = null;
            this.lookupCar.AutoCalcNo = 0;
            this.lookupCar.Caption = null;
            this.lookupCar.ControlName = null;
            this.lookupCar.CurrentValue = "372d6e053dcb47c0847c8534181d78c0";
            this.lookupCar.DecimalDigits = 0;
            this.lookupCar.EditText = "";
            this.lookupCar.EditValue = "";
            this.lookupCar.ErrorTipText = null;
            this.lookupCar.Expression = null;
            this.lookupCar.FieldName = null;
            this.dxErrorProvider.SetIconAlignment(this.lookupCar, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.lookupCar.IsRequired = false;
            this.lookupCar.Location = new System.Drawing.Point(389, 14);
            this.lookupCar.Name = "lookupCar";
            this.lookupCar.ParentLocation = new System.Drawing.Point(0, 0);
            this.lookupCar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lookupCar.Size = new System.Drawing.Size(230, 20);
            this.lookupCar.StartAutoSave = false;
            this.lookupCar.StartStay = false;
            this.lookupCar.TabIndex = 71;
            this.lookupCar.WeightVauleChanged = null;
            // 
            // lblWareh
            // 
            this.lblWareh.Location = new System.Drawing.Point(656, 15);
            this.lblWareh.Name = "lblWareh";
            this.lblWareh.Size = new System.Drawing.Size(28, 14);
            this.lblWareh.TabIndex = 60;
            this.lblWareh.Text = "仓库:";
            // 
            // lblReceiver
            // 
            this.lblReceiver.Location = new System.Drawing.Point(316, 81);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(52, 14);
            this.lblReceiver.TabIndex = 59;
            this.lblReceiver.Text = "收货单位:";
            // 
            // lblDelivery
            // 
            this.lblDelivery.Location = new System.Drawing.Point(316, 112);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(52, 14);
            this.lblDelivery.TabIndex = 58;
            this.lblDelivery.Text = "发货单位:";
            // 
            // lblDriverName
            // 
            this.lblDriverName.Location = new System.Drawing.Point(316, 47);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(28, 14);
            this.lblDriverName.TabIndex = 57;
            this.lblDriverName.Text = "司机:";
            // 
            // teDriverName
            // 
            this.teDriverName.Location = new System.Drawing.Point(389, 47);
            this.teDriverName.Name = "teDriverName";
            this.teDriverName.Size = new System.Drawing.Size(230, 20);
            this.teDriverName.TabIndex = 56;
            this.teDriverName.Tag = "DriverName";
            // 
            // lblWarehBizType
            // 
            this.lblWarehBizType.Location = new System.Drawing.Point(656, 49);
            this.lblWarehBizType.Name = "lblWarehBizType";
            this.lblWarehBizType.Size = new System.Drawing.Size(64, 14);
            this.lblWarehBizType.TabIndex = 47;
            this.lblWarehBizType.Text = "出入库业务:";
            // 
            // lblCarNo
            // 
            this.lblCarNo.Location = new System.Drawing.Point(316, 16);
            this.lblCarNo.Name = "lblCarNo";
            this.lblCarNo.Size = new System.Drawing.Size(40, 14);
            this.lblCarNo.TabIndex = 38;
            this.lblCarNo.Text = "车牌号:";
            // 
            // timerReadCard
            // 
            this.timerReadCard.Interval = 1000;
            this.timerReadCard.Tick += new System.EventHandler(this.timerReadCard_Tick);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // lblTareWeight
            // 
            this.lblTareWeight.Location = new System.Drawing.Point(656, 81);
            this.lblTareWeight.Name = "lblTareWeight";
            this.lblTareWeight.Size = new System.Drawing.Size(50, 14);
            this.lblTareWeight.TabIndex = 88;
            this.lblTareWeight.Text = "皮重(吨):";
            // 
            // teTareWeight
            // 
            this.teTareWeight.Location = new System.Drawing.Point(734, 81);
            this.teTareWeight.Name = "teTareWeight";
            this.teTareWeight.Size = new System.Drawing.Size(191, 20);
            this.teTareWeight.TabIndex = 87;
            this.teTareWeight.Tag = "TareWeight";
            // 
            // UcCardEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupOther);
            this.Controls.Add(this.plDetail);
            this.Name = "UcCardEdit";
            this.Size = new System.Drawing.Size(943, 555);
            this.Load += new System.EventHandler(this.UcCardEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupOther)).EndInit();
            this.groupOther.ResumeLayout(false);
            this.scOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plDetail)).EndInit();
            this.plDetail.ResumeLayout(false);
            this.plDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weWarehBizType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weWareh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wLookupSearchEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCardId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupMaterialId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupReceiverId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDeliveryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDriverName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTareWeight.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupOther;
        private DevExpress.XtraEditors.XtraScrollableControl scOther;
        private CardView cardView;
        private DevExpress.XtraEditors.PanelControl plDetail;
        private Weight.WCustomerEdit lookupCustomer;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupMaterialId;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private Weight.WCustomerEdit lookupReceiverId;
        private Weight.WCustomerEdit lookupDeliveryId;
        private Weight.WCarLookup lookupCar;
        private DevExpress.XtraEditors.LabelControl lblWareh;
        private DevExpress.XtraEditors.LabelControl lblReceiver;
        private DevExpress.XtraEditors.LabelControl lblDelivery;
        private DevExpress.XtraEditors.LabelControl lblDriverName;
        private DevExpress.XtraEditors.TextEdit teDriverName;
        private DevExpress.XtraEditors.LabelControl lblWarehBizType;
        private DevExpress.XtraEditors.LabelControl lblCarNo;
        private DevExpress.XtraEditors.TextEdit teCardId;
        private DevExpress.XtraEditors.LabelControl lblCardId;
        private System.Windows.Forms.Timer timerReadCard;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private DevExpress.XtraEditors.TextEdit teRemark;
        private DevExpress.XtraEditors.TextEdit teCardNo;
        private DevExpress.XtraEditors.LabelControl lblCardNo;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private Weight.WComboBoxEdit weWarehBizType;
        private Weight.WLookupSearchEdit weWareh;
        private DevExpress.XtraGrid.Views.Grid.GridView wLookupSearchEdit1View;
        private DevExpress.XtraEditors.LabelControl lblTareWeight;
        private DevExpress.XtraEditors.TextEdit teTareWeight;
    }
}
