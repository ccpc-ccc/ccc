namespace YF.MWS.Win.Uc
{
    partial class WeightScreen
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState1 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState2 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.plWeight = new DevExpress.XtraEditors.PanelControl();
            this.plWeightState = new DevExpress.XtraEditors.PanelControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.stateIndicatorComponent2 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.lblState = new DevExpress.XtraEditors.LabelControl();
            this.lblLeftUnitCaption = new DevExpress.XtraEditors.LabelControl();
            this.lbLeftUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblWeight = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.plWeight)).BeginInit();
            this.plWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plWeightState)).BeginInit();
            this.plWeightState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent2)).BeginInit();
            this.SuspendLayout();
            // 
            // plWeight
            // 
            this.plWeight.Appearance.BackColor = System.Drawing.Color.Black;
            this.plWeight.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.plWeight.Appearance.Options.UseBackColor = true;
            this.plWeight.Controls.Add(this.plWeightState);
            this.plWeight.Controls.Add(this.lblWeight);
            this.plWeight.Location = new System.Drawing.Point(5, 4);
            this.plWeight.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.plWeight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.plWeight.Name = "plWeight";
            this.plWeight.Size = new System.Drawing.Size(355, 110);
            this.plWeight.TabIndex = 22;
            // 
            // plWeightState
            // 
            this.plWeightState.Appearance.BackColor = System.Drawing.Color.Black;
            this.plWeightState.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.plWeightState.Appearance.BorderColor = System.Drawing.Color.White;
            this.plWeightState.Appearance.Options.UseBackColor = true;
            this.plWeightState.Appearance.Options.UseBorderColor = true;
            this.plWeightState.Controls.Add(this.gaugeControl1);
            this.plWeightState.Controls.Add(this.lblState);
            this.plWeightState.Controls.Add(this.lblLeftUnitCaption);
            this.plWeightState.Controls.Add(this.lbLeftUnit);
            this.plWeightState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plWeightState.Location = new System.Drawing.Point(3, 76);
            this.plWeightState.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.plWeightState.LookAndFeel.UseDefaultLookAndFeel = false;
            this.plWeightState.Margin = new System.Windows.Forms.Padding(0);
            this.plWeightState.Name = "plWeightState";
            this.plWeightState.Size = new System.Drawing.Size(349, 31);
            this.plWeightState.TabIndex = 22;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(286, 2);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(28, 28);
            this.gaugeControl1.TabIndex = 22;
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(2, 2, 24, 24);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateIndicatorComponent2});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // stateIndicatorComponent2
            // 
            this.stateIndicatorComponent2.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateIndicatorComponent2.Name = "stateIndicatorComponent1";
            this.stateIndicatorComponent2.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateIndicatorComponent2.StateIndex = 0;
            indicatorState1.Name = "State1";
            indicatorState1.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState2.Name = "State2";
            indicatorState2.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            this.stateIndicatorComponent2.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState1,
            indicatorState2});
            // 
            // lblState
            // 
            this.lblState.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblState.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblState.Location = new System.Drawing.Point(320, 11);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(24, 12);
            this.lblState.TabIndex = 23;
            this.lblState.Text = "状态";
            // 
            // lblLeftUnitCaption
            // 
            this.lblLeftUnitCaption.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLeftUnitCaption.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblLeftUnitCaption.Location = new System.Drawing.Point(13, 11);
            this.lblLeftUnitCaption.Name = "lblLeftUnitCaption";
            this.lblLeftUnitCaption.Size = new System.Drawing.Size(30, 12);
            this.lblLeftUnitCaption.TabIndex = 14;
            this.lblLeftUnitCaption.Text = "单位:";
            // 
            // lbLeftUnit
            // 
            this.lbLeftUnit.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbLeftUnit.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbLeftUnit.Location = new System.Drawing.Point(43, 11);
            this.lbLeftUnit.Name = "lbLeftUnit";
            this.lbLeftUnit.Size = new System.Drawing.Size(24, 12);
            this.lbLeftUnit.TabIndex = 13;
            this.lbLeftUnit.Text = "公斤";
            // 
            // lblWeight
            // 
            this.lblWeight.AllowHtmlString = true;
            this.lblWeight.Appearance.Font = new System.Drawing.Font("Arial", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Appearance.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblWeight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblWeight.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWeight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblWeight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblWeight.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWeight.LineColor = System.Drawing.Color.White;
            this.lblWeight.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblWeight.Location = new System.Drawing.Point(3, 3);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(349, 70);
            this.lblWeight.TabIndex = 13;
            this.lblWeight.Text = "111.21";
            // 
            // WeightScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plWeight);
            this.Name = "WeightScreen";
            this.Size = new System.Drawing.Size(366, 123);
            ((System.ComponentModel.ISupportInitialize)(this.plWeight)).EndInit();
            this.plWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plWeightState)).EndInit();
            this.plWeightState.ResumeLayout(false);
            this.plWeightState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl plWeight;
        private DevExpress.XtraEditors.PanelControl plWeightState;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateIndicatorComponent2;
        private DevExpress.XtraEditors.LabelControl lblState;
        private DevExpress.XtraEditors.LabelControl lblLeftUnitCaption;
        private DevExpress.XtraEditors.LabelControl lbLeftUnit;
        private DevExpress.XtraEditors.LabelControl lblWeight;
    }
}
