namespace YF.MWS.Win.Uc
{
    partial class DateFilter
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
            this.gpSummaryType = new DevExpress.XtraEditors.GroupControl();
            this.combQuanter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combWeek = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teEndDate = new DevExpress.XtraEditors.TimeEdit();
            this.lblRange = new DevExpress.XtraEditors.LabelControl();
            this.teStartDate = new DevExpress.XtraEditors.TimeEdit();
            this.teYear = new DevExpress.XtraEditors.TimeEdit();
            this.teQuanter = new DevExpress.XtraEditors.TimeEdit();
            this.teMonth = new DevExpress.XtraEditors.TimeEdit();
            this.teWeek = new DevExpress.XtraEditors.TimeEdit();
            this.teDay = new DevExpress.XtraEditors.TimeEdit();
            this.rgSummaryType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gpSummaryType)).BeginInit();
            this.gpSummaryType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combQuanter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teQuanter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSummaryType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gpSummaryType
            // 
            this.gpSummaryType.Controls.Add(this.combQuanter);
            this.gpSummaryType.Controls.Add(this.combWeek);
            this.gpSummaryType.Controls.Add(this.teEndDate);
            this.gpSummaryType.Controls.Add(this.lblRange);
            this.gpSummaryType.Controls.Add(this.teStartDate);
            this.gpSummaryType.Controls.Add(this.teYear);
            this.gpSummaryType.Controls.Add(this.teQuanter);
            this.gpSummaryType.Controls.Add(this.teMonth);
            this.gpSummaryType.Controls.Add(this.teWeek);
            this.gpSummaryType.Controls.Add(this.teDay);
            this.gpSummaryType.Controls.Add(this.rgSummaryType);
            this.gpSummaryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpSummaryType.Location = new System.Drawing.Point(0, 0);
            this.gpSummaryType.Name = "gpSummaryType";
            this.gpSummaryType.Size = new System.Drawing.Size(283, 250);
            this.gpSummaryType.TabIndex = 55;
            this.gpSummaryType.Text = "日期选择";
            // 
            // combQuanter
            // 
            this.combQuanter.EditValue = "第1季度";
            this.combQuanter.Location = new System.Drawing.Point(178, 115);
            this.combQuanter.Name = "combQuanter";
            this.combQuanter.Properties.AllowMouseWheel = false;
            this.combQuanter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combQuanter.Properties.Items.AddRange(new object[] {
            "第1季度",
            "第2季度",
            "第3季度",
            "第4季度"});
            this.combQuanter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combQuanter.Size = new System.Drawing.Size(90, 20);
            this.combQuanter.TabIndex = 93;
            // 
            // combWeek
            // 
            this.combWeek.EditValue = "";
            this.combWeek.Location = new System.Drawing.Point(178, 63);
            this.combWeek.Name = "combWeek";
            this.combWeek.Properties.AllowMouseWheel = false;
            this.combWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combWeek.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combWeek.Size = new System.Drawing.Size(90, 20);
            this.combWeek.TabIndex = 92;
            // 
            // teEndDate
            // 
            this.teEndDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teEndDate.Location = new System.Drawing.Point(65, 207);
            this.teEndDate.Name = "teEndDate";
            this.teEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teEndDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teEndDate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.teEndDate.Size = new System.Drawing.Size(147, 20);
            this.teEndDate.TabIndex = 91;
            // 
            // lblRange
            // 
            this.lblRange.Location = new System.Drawing.Point(218, 174);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(9, 14);
            this.lblRange.TabIndex = 90;
            this.lblRange.Text = "~";
            // 
            // teStartDate
            // 
            this.teStartDate.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teStartDate.Location = new System.Drawing.Point(65, 171);
            this.teStartDate.Name = "teStartDate";
            this.teStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teStartDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartDate.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.teStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teStartDate.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.teStartDate.Size = new System.Drawing.Size(147, 20);
            this.teStartDate.TabIndex = 89;
            // 
            // teYear
            // 
            this.teYear.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teYear.Location = new System.Drawing.Point(65, 141);
            this.teYear.Name = "teYear";
            this.teYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teYear.Properties.DisplayFormat.FormatString = "yyyy";
            this.teYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teYear.Properties.EditFormat.FormatString = "yyyy";
            this.teYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teYear.Properties.Mask.EditMask = "yyyy";
            this.teYear.Size = new System.Drawing.Size(100, 20);
            this.teYear.TabIndex = 68;
            // 
            // teQuanter
            // 
            this.teQuanter.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teQuanter.Location = new System.Drawing.Point(65, 115);
            this.teQuanter.Name = "teQuanter";
            this.teQuanter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teQuanter.Properties.DisplayFormat.FormatString = "yyyy";
            this.teQuanter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teQuanter.Properties.EditFormat.FormatString = "yyyy";
            this.teQuanter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teQuanter.Properties.Mask.EditMask = "yyyy";
            this.teQuanter.Size = new System.Drawing.Size(100, 20);
            this.teQuanter.TabIndex = 67;
            // 
            // teMonth
            // 
            this.teMonth.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teMonth.Location = new System.Drawing.Point(65, 89);
            this.teMonth.Name = "teMonth";
            this.teMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teMonth.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.teMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teMonth.Properties.EditFormat.FormatString = "yyyy-MM";
            this.teMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teMonth.Properties.Mask.EditMask = "yyyy-MM";
            this.teMonth.Size = new System.Drawing.Size(100, 20);
            this.teMonth.TabIndex = 66;
            // 
            // teWeek
            // 
            this.teWeek.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teWeek.Location = new System.Drawing.Point(65, 63);
            this.teWeek.Name = "teWeek";
            this.teWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teWeek.Properties.DisplayFormat.FormatString = "yyyy";
            this.teWeek.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teWeek.Properties.EditFormat.FormatString = "yyyy";
            this.teWeek.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teWeek.Properties.Mask.EditMask = "yyyy";
            this.teWeek.Size = new System.Drawing.Size(100, 20);
            this.teWeek.TabIndex = 65;
            // 
            // teDay
            // 
            this.teDay.EditValue = new System.DateTime(2014, 11, 4, 23, 59, 59, 0);
            this.teDay.Location = new System.Drawing.Point(65, 37);
            this.teDay.Name = "teDay";
            this.teDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teDay.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.teDay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teDay.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.teDay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.teDay.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.teDay.Size = new System.Drawing.Size(100, 20);
            this.teDay.TabIndex = 64;
            // 
            // rgSummaryType
            // 
            this.rgSummaryType.EditValue = "Customer";
            this.rgSummaryType.Location = new System.Drawing.Point(9, 27);
            this.rgSummaryType.Name = "rgSummaryType";
            this.rgSummaryType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSummaryType.Properties.Appearance.Options.UseBackColor = true;
            this.rgSummaryType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSummaryType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Day", "日"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Week", "周"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Month", "月"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Quarter", "季"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Year", "年"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Customer", "其他")});
            this.rgSummaryType.Size = new System.Drawing.Size(55, 170);
            this.rgSummaryType.TabIndex = 44;
            // 
            // DateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpSummaryType);
            this.Name = "DateFilter";
            this.Size = new System.Drawing.Size(283, 250);
            ((System.ComponentModel.ISupportInitialize)(this.gpSummaryType)).EndInit();
            this.gpSummaryType.ResumeLayout(false);
            this.gpSummaryType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combQuanter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teQuanter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSummaryType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpSummaryType;
        private DevExpress.XtraEditors.ComboBoxEdit combQuanter;
        private DevExpress.XtraEditors.ComboBoxEdit combWeek;
        private DevExpress.XtraEditors.TimeEdit teEndDate;
        private DevExpress.XtraEditors.LabelControl lblRange;
        private DevExpress.XtraEditors.TimeEdit teStartDate;
        private DevExpress.XtraEditors.TimeEdit teYear;
        private DevExpress.XtraEditors.TimeEdit teQuanter;
        private DevExpress.XtraEditors.TimeEdit teMonth;
        private DevExpress.XtraEditors.TimeEdit teWeek;
        private DevExpress.XtraEditors.TimeEdit teDay;
        private DevExpress.XtraEditors.RadioGroup rgSummaryType;
    }
}
