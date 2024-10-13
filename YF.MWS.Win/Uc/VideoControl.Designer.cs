namespace YF.MWS.Win.Uc
{
    partial class VideoControl
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
            this.pnlVideo = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVideo
            // 
            this.pnlVideo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlVideo.Appearance.Options.UseBackColor = true;
            this.pnlVideo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlVideo.Location = new System.Drawing.Point(77, 58);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(200, 100);
            this.pnlVideo.TabIndex = 0;
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.pnlVideo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "VideoControl";
            this.Size = new System.Drawing.Size(376, 226);
            this.Load += new System.EventHandler(this.VideoControl_Load);
            this.SizeChanged += new System.EventHandler(this.VideoControl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlVideo;

    }
}
