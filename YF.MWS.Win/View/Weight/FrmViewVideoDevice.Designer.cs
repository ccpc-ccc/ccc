using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.Utility.IO;
namespace YF.MWS.Win.View.Weight
{
    partial class FrmViewVideoDevice {
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
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) 
            {
                //FileHelper.Delete(player.URL);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewVideoDevice));
            this.imgListSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.pnlVideo = new DevExpress.XtraEditors.PanelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.横向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.纵向排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.抓拍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.Images.SetKeyName(0, "close_16x16.png");
            this.imgListSmall.Images.SetKeyName(1, "first_16x16.png");
            this.imgListSmall.Images.SetKeyName(2, "next_16x16.png");
            this.imgListSmall.Images.SetKeyName(3, "last_16x16.png");
            this.imgListSmall.Images.SetKeyName(4, "prev_16x16.png");
            // 
            // pnlVideo
            // 
            this.pnlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideo.Location = new System.Drawing.Point(0, 0);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(812, 572);
            this.pnlVideo.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.横向排列ToolStripMenuItem,
            this.纵向排列ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.抓拍ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 202);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem7.Text = "1*1";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // 横向排列ToolStripMenuItem
            // 
            this.横向排列ToolStripMenuItem.Name = "横向排列ToolStripMenuItem";
            this.横向排列ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.横向排列ToolStripMenuItem.Text = "1*2";
            this.横向排列ToolStripMenuItem.Click += new System.EventHandler(this.横向排列ToolStripMenuItem_Click);
            // 
            // 纵向排列ToolStripMenuItem
            // 
            this.纵向排列ToolStripMenuItem.Name = "纵向排列ToolStripMenuItem";
            this.纵向排列ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.纵向排列ToolStripMenuItem.Text = "1*3";
            this.纵向排列ToolStripMenuItem.Click += new System.EventHandler(this.纵向排列ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "1*4";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "2*1";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = "2*2";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem5.Text = "3*1";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem6.Text = "4*1";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // 抓拍ToolStripMenuItem
            // 
            this.抓拍ToolStripMenuItem.Name = "抓拍ToolStripMenuItem";
            this.抓拍ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.抓拍ToolStripMenuItem.Text = "抓拍";
            this.抓拍ToolStripMenuItem.Click += new System.EventHandler(this.抓拍ToolStripMenuItem_Click);
            // 
            // FrmViewVideoDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 572);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pnlVideo);
            this.MinimizeBox = false;
            this.Name = "FrmViewVideoDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浏览视频";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewVideoDevice_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmViewVideoDevice_FormClosed);
            this.Load += new System.EventHandler(this.FrmViewVideo_Load);
            this.SizeChanged += new System.EventHandler(this.FrmViewVideoDevice_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.FrmViewVideoDevice_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.imgListSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imgListSmall;
        private DevExpress.XtraEditors.PanelControl pnlVideo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 横向排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 纵向排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem 抓拍ToolStripMenuItem;
    }
}