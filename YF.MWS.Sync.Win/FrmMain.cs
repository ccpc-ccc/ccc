using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Sync.Win.Core;
using YF.Utility.Configuration;
using YF.Utility;
using YF.Utility.Log;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using System.IO;
using YF.Utility.IO;
using System.Net;

namespace YF.MWS.Sync.Win
{
    public partial class FrmMain : Form
    {
        private TaskCfg task = TaskCfgUtil.GetTaskCfg();
        private bool isRuning = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitForm(false);
            int syncInterval = AppSetting.GetValue("SyncInterval").ToInt();
            if (syncInterval <= 0)
            {
                syncInterval = 2;
            }
            timerSync.Interval = 1000 * syncInterval * 60;
            timerSync.Start();
            if (task != null)
                chkAutoStart.Checked = task.AutoStart;
            SysCfg cfg = CfgUtil.GetCfg();
        }

        private void InitForm(bool isShow)
        {
            this.Hide();
            notifyApp.Visible = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = isShow;
            this.WindowState = FormWindowState.Minimized;
        }

        private void AutoStart(bool isAutoStart)
        {
            RegistryKey reg = null;
            string file = Application.StartupPath + "\\" + AppSetting.GetValue("AppName");
            try
            {
                RegistryKey localKey;
                if (Environment.Is64BitOperatingSystem)
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                else
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                reg = localKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (reg != null)
                {
                    if (isAutoStart)
                    {
                        reg.SetValue("MwsSync", file);
                    }
                    else
                    {
                        reg.SetValue("MwsSync", "false");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally
            {
                if (reg != null)
                {
                    reg.Close();
                }
            }
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            AutoStart(chkAutoStart.Checked);
            if (task == null)
                task = new TaskCfg();
            task.AutoStart = chkAutoStart.Checked;
            TaskCfgUtil.SaveTaskCfg(task);
        }

        private void notifyApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.ShowInTaskbar = true;
        }

        private void toolItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            if (!isRuning)
            {
                isRuning = true;
                Sync();
                isRuning = false;
            }
        }

        private void Sync()
        {
           
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnManaual_Click(object sender, EventArgs e)
        {
            Sync();
        }
    }
}
