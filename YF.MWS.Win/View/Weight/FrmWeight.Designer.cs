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
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState13 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState14 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState15 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState16 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState17 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState18 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.imgListLarger = new DevExpress.Utils.ImageCollection(this.components);
            this.plMainWeight = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gpWeight = new DevExpress.XtraEditors.GroupControl();
            this.lblWeight1 = new DevExpress.XtraEditors.LabelControl();
            this.plWeightDevice = new DevExpress.XtraEditors.PanelControl();
            this.lblDeviceNo = new DevExpress.XtraEditors.LabelControl();
            this.lbLeftUnit = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblWeightType = new DevExpress.XtraEditors.LabelControl();
            this.stateLight1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.gaugeDevice = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateWeightStable1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.stateIndicatorGauge2 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.gaugeWeightStatble = new DevExpress.XtraGauges.Win.GaugeControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.plLeft = new DevExpress.XtraEditors.PanelControl();
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListLarger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMainWeight)).BeginInit();
            this.plMainWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpWeight)).BeginInit();
            this.gpWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plWeightDevice)).BeginInit();
            this.plWeightDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateLight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateWeightStable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plLeft)).BeginInit();
            this.plLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListLarger
            // 
            this.imgListLarger.ImageSize = new System.Drawing.Size(32, 32);
            this.imgListLarger.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListLarger.ImageStream")));
            // 
            // plMainWeight
            // 
            this.plMainWeight.Controls.Add(this.plLeft);
            this.plMainWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMainWeight.Location = new System.Drawing.Point(0, 0);
            this.plMainWeight.Name = "plMainWeight";
            this.plMainWeight.Size = new System.Drawing.Size(706, 389);
            this.plMainWeight.TabIndex = 44;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.plMainWeight);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(710, 403);
            this.splitContainerControl1.SplitterPosition = 412;
            this.splitContainerControl1.TabIndex = 53;
            // 
            // gpWeight
            // 
            this.gpWeight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gpWeight.Controls.Add(this.simpleButton2);
            this.gpWeight.Controls.Add(this.plWeightDevice);
            this.gpWeight.Controls.Add(this.lblWeight1);
            this.gpWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpWeight.Location = new System.Drawing.Point(0, 0);
            this.gpWeight.Name = "gpWeight";
            this.gpWeight.ShowCaption = false;
            this.gpWeight.Size = new System.Drawing.Size(706, 158);
            this.gpWeight.TabIndex = 42;
            this.gpWeight.Text = "电子过磅区";
            // 
            // lblWeight1
            // 
            this.lblWeight1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(84)))), ((int)(((byte)(164)))));
            this.lblWeight1.Appearance.Font = new System.Drawing.Font("黑体", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight1.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblWeight1.Appearance.Options.UseBackColor = true;
            this.lblWeight1.Appearance.Options.UseFont = true;
            this.lblWeight1.Appearance.Options.UseForeColor = true;
            this.lblWeight1.Appearance.Options.UseTextOptions = true;
            this.lblWeight1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblWeight1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWeight1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblWeight1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblWeight1.LineColor = System.Drawing.Color.White;
            this.lblWeight1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblWeight1.Location = new System.Drawing.Point(5, 5);
            this.lblWeight1.Name = "lblWeight1";
            this.lblWeight1.Size = new System.Drawing.Size(472, 93);
            this.lblWeight1.TabIndex = 13;
            this.lblWeight1.Text = "0.00";
            // 
            // plWeightDevice
            // 
            this.plWeightDevice.Controls.Add(this.gaugeWeightStatble);
            this.plWeightDevice.Controls.Add(this.gaugeDevice);
            this.plWeightDevice.Controls.Add(this.labelControl1);
            this.plWeightDevice.Controls.Add(this.lbLeftUnit);
            this.plWeightDevice.Controls.Add(this.lblDeviceNo);
            this.plWeightDevice.Location = new System.Drawing.Point(5, 99);
            this.plWeightDevice.Name = "plWeightDevice";
            this.plWeightDevice.Size = new System.Drawing.Size(472, 28);
            this.plWeightDevice.TabIndex = 41;
            // 
            // lblDeviceNo
            // 
            this.lblDeviceNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDeviceNo.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDeviceNo.Appearance.Options.UseFont = true;
            this.lblDeviceNo.Appearance.Options.UseForeColor = true;
            this.lblDeviceNo.Location = new System.Drawing.Point(6, 5);
            this.lblDeviceNo.Name = "lblDeviceNo";
            this.lblDeviceNo.Size = new System.Drawing.Size(64, 22);
            this.lblDeviceNo.TabIndex = 26;
            this.lblDeviceNo.Text = "仪表传输";
            // 
            // lbLeftUnit
            // 
            this.lbLeftUnit.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbLeftUnit.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbLeftUnit.Appearance.Options.UseFont = true;
            this.lbLeftUnit.Appearance.Options.UseForeColor = true;
            this.lbLeftUnit.Location = new System.Drawing.Point(435, 5);
            this.lbLeftUnit.Name = "lbLeftUnit";
            this.lbLeftUnit.Size = new System.Drawing.Size(32, 22);
            this.lbLeftUnit.TabIndex = 13;
            this.lbLeftUnit.Text = "公斤";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(136, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 22);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "仪表稳定";
            // 
            // lblWeightType
            // 
            this.lblWeightType.Appearance.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblWeightType.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWeightType.Appearance.Options.UseFont = true;
            this.lblWeightType.Appearance.Options.UseForeColor = true;
            this.lblWeightType.Location = new System.Drawing.Point(44, 188);
            this.lblWeightType.Name = "lblWeightType";
            this.lblWeightType.Size = new System.Drawing.Size(64, 22);
            this.lblWeightType.TabIndex = 24;
            this.lblWeightType.Text = "当前重量";
            // 
            // stateLight1
            // 
            this.stateLight1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateLight1.Name = "stateIndicatorComponent1";
            this.stateLight1.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateLight1.StateIndex = 1;
            indicatorState13.Name = "State1";
            indicatorState13.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState14.Name = "State2";
            indicatorState14.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState15.Name = "State3";
            indicatorState15.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateLight1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState13,
            indicatorState14,
            indicatorState15});
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(2, 2, 24, 24);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateLight1});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // gaugeDevice
            // 
            this.gaugeDevice.AutoLayout = false;
            this.gaugeDevice.BackColor = System.Drawing.Color.Transparent;
            this.gaugeDevice.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeDevice.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeDevice.Location = new System.Drawing.Point(75, 1);
            this.gaugeDevice.Name = "gaugeDevice";
            this.gaugeDevice.Size = new System.Drawing.Size(28, 28);
            this.gaugeDevice.TabIndex = 32;
            // 
            // stateWeightStable1
            // 
            this.stateWeightStable1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateWeightStable1.Name = "stateIndicatorComponent1";
            this.stateWeightStable1.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateWeightStable1.StateIndex = 1;
            indicatorState16.Name = "State1";
            indicatorState16.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState17.Name = "State2";
            indicatorState17.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState18.Name = "State3";
            indicatorState18.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateWeightStable1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState16,
            indicatorState17,
            indicatorState18});
            // 
            // stateIndicatorGauge2
            // 
            this.stateIndicatorGauge2.Bounds = new System.Drawing.Rectangle(2, 2, 24, 24);
            this.stateIndicatorGauge2.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateWeightStable1});
            this.stateIndicatorGauge2.Name = "stateIndicatorGauge2";
            // 
            // gaugeWeightStatble
            // 
            this.gaugeWeightStatble.AutoLayout = false;
            this.gaugeWeightStatble.BackColor = System.Drawing.Color.Transparent;
            this.gaugeWeightStatble.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeWeightStatble.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge2});
            this.gaugeWeightStatble.Location = new System.Drawing.Point(210, 1);
            this.gaugeWeightStatble.Name = "gaugeWeightStatble";
            this.gaugeWeightStatble.Size = new System.Drawing.Size(28, 28);
            this.gaugeWeightStatble.TabIndex = 33;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.ImageIndex = 8;
            this.simpleButton2.Location = new System.Drawing.Point(499, 10);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 26);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Tag = "Weight";
            this.simpleButton2.Text = "清空";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // plLeft
            // 
            this.plLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plLeft.Controls.Add(this.txtWeight);
            this.plLeft.Controls.Add(this.lblWeightType);
            this.plLeft.Controls.Add(this.gpWeight);
            this.plLeft.Location = new System.Drawing.Point(2, 2);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(706, 386);
            this.plLeft.TabIndex = 51;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(114, 181);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Properties.Appearance.Options.UseFont = true;
            this.txtWeight.Size = new System.Drawing.Size(131, 32);
            this.txtWeight.TabIndex = 44;
            // 
            // FrmWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 403);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "FrmWeight";
            this.Text = "称重操作";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWeight_FormClosed);
            this.Load += new System.EventHandler(this.FrmWeight_Load);
            this.SizeChanged += new System.EventHandler(this.FrmWeight_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmWeight_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgListLarger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plMainWeight)).EndInit();
            this.plMainWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpWeight)).EndInit();
            this.gpWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plWeightDevice)).EndInit();
            this.plWeightDevice.ResumeLayout(false);
            this.plWeightDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateLight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateWeightStable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plLeft)).EndInit();
            this.plLeft.ResumeLayout(false);
            this.plLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            this.ResumeLayout(false);

        } 
        

        #endregion
        private DevExpress.Utils.ImageCollection imgListLarger;
        private DevExpress.XtraEditors.PanelControl plMainWeight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl plLeft;
        private DevExpress.XtraEditors.GroupControl gpWeight;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl plWeightDevice;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeWeightStatble;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge2;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateWeightStable1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeDevice;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateLight1;
        private DevExpress.XtraEditors.LabelControl lblWeightType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbLeftUnit;
        private DevExpress.XtraEditors.LabelControl lblDeviceNo;
        private DevExpress.XtraEditors.LabelControl lblWeight1;
        private DevExpress.XtraEditors.TextEdit txtWeight;
    }
}