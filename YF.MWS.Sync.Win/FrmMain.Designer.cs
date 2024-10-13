namespace YF.MWS.Sync.Win
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnManaual = new DevExpress.XtraEditors.SimpleButton();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSync
            // 
            this.timerSync.Interval = 60000;
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemClose});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(101, 26);
            this.ctxMenu.Text = "供应商订单同步服务";
            // 
            // toolItemClose
            // 
            this.toolItemClose.Name = "toolItemClose";
            this.toolItemClose.Size = new System.Drawing.Size(100, 22);
            this.toolItemClose.Text = "退出";
            this.toolItemClose.Click += new System.EventHandler(this.toolItemClose_Click);
            // 
            // notifyApp
            // 
            this.notifyApp.ContextMenuStrip = this.ctxMenu;
            this.notifyApp.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyApp.Icon")));
            this.notifyApp.Text = "磅单同步服务";
            this.notifyApp.Visible = true;
            this.notifyApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyApp_MouseDoubleClick);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(54, 49);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(72, 16);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "自动运行";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // btnManaual
            // 
            this.btnManaual.Location = new System.Drawing.Point(54, 96);
            this.btnManaual.Name = "btnManaual";
            this.btnManaual.Size = new System.Drawing.Size(75, 23);
            this.btnManaual.TabIndex = 3;
            this.btnManaual.Text = "手动执行";
            this.btnManaual.Click += new System.EventHandler(this.btnManaual_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 163);
            this.Controls.Add(this.btnManaual);
            this.Controls.Add(this.chkAutoStart);
            this.IconOptions.Image = global::YF.MWS.Win.Properties.Resources.app;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动同步服务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem toolItemClose;
        private System.Windows.Forms.NotifyIcon notifyApp;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private DevExpress.XtraEditors.SimpleButton btnManaual;
    }
}

