namespace YF.MWS.Win.Uc
{
    partial class UcPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPage));
            this.dnPager = new DevExpress.XtraEditors.DataNavigator();
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.lblPage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // dnPager
            // 
            this.dnPager.Appearance.BackColor = System.Drawing.Color.White;
            this.dnPager.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.dnPager.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.dnPager.Appearance.Options.UseBackColor = true;
            this.dnPager.Appearance.Options.UseBorderColor = true;
            this.dnPager.Buttons.Append.Visible = false;
            this.dnPager.Buttons.CancelEdit.Visible = false;
            this.dnPager.Buttons.EndEdit.Visible = false;
            this.dnPager.Buttons.First.ImageIndex = 0;
            this.dnPager.Buttons.First.Visible = false;
            this.dnPager.Buttons.ImageList = this.imgListSmall;
            this.dnPager.Buttons.Last.ImageIndex = 3;
            this.dnPager.Buttons.Last.Visible = false;
            this.dnPager.Buttons.Next.Visible = false;
            this.dnPager.Buttons.NextPage.ImageIndex = 2;
            this.dnPager.Buttons.NextPage.Visible = false;
            this.dnPager.Buttons.Prev.Visible = false;
            this.dnPager.Buttons.PrevPage.ImageIndex = 1;
            this.dnPager.Buttons.PrevPage.Visible = false;
            this.dnPager.Buttons.Remove.Visible = false;
            this.dnPager.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "第一页", "First"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 1, true, true, "上一页", "Prev"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 2, true, true, "下一页", "Next"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 3, true, true, "最后一页", "Last")});
            this.dnPager.Dock = System.Windows.Forms.DockStyle.Right;
            this.dnPager.Location = new System.Drawing.Point(360, 0);
            this.dnPager.Name = "dnPager";
            this.dnPager.ShowToolTips = true;
            this.dnPager.Size = new System.Drawing.Size(263, 26);
            this.dnPager.TabIndex = 0;
            this.dnPager.TextStringFormat = "Record 12 of 1";
            this.dnPager.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dnPager_ButtonClick);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "first_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "prev_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "next_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "last_16x16.png");
            // 
            // lblPage
            // 
            this.lblPage.Location = new System.Drawing.Point(4, 7);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(31, 14);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "第1页";
            // 
            // UcPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.dnPager);
            this.Name = "UcPage";
            this.Size = new System.Drawing.Size(623, 26);
            this.Load += new System.EventHandler(this.UcPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DataNavigator dnPager;
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.LabelControl lblPage;
    }
}
