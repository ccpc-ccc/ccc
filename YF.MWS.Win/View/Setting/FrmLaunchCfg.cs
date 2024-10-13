using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.Utility;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmLaunchCfg : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;

        public FrmLaunchCfg()
        {
            InitializeComponent();
        }

        private void FrmLaunchCfg_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null) 
            {
                LaunchCfg launch = cfg.Launch;
                if (launch.DefaultPage == DefaultPageType.Corp)
                {
                    rgDefaultPage.SelectedIndex = 0;
                }
                else
                {
                    rgDefaultPage.SelectedIndex = 1;
                }
                rgAppRunVersion.EditValue = launch.RunVersion.ToString();
                chkRunMoreApps.Checked = launch.RunMoreApps;
                chkStartAutoMaintain.Checked = launch.StartAutoMaintain;
                rgReStartTimeSpan.EditValue = launch.ReStartTimeSpan.ToString();
                teHours.Text = launch.Hours.ToString();
                if (launch.FixedTimes != null && launch.FixedTimes.Count > 0)
                {
                    teFixedTimeFirst.Time = launch.FixedTimes[0];
                    if (launch.FixedTimes.Count > 1)
                        teFixedTimeSecond.Time = launch.FixedTimes[1];
                    if (launch.FixedTimes.Count > 2)
                        teFixedTimeThird.Time = launch.FixedTimes[2];
                }
            }
        }

        private void Save() 
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            LaunchCfg launch = cfg.Launch;
            launch.RunMoreApps = chkRunMoreApps.Checked;
            launch.DefaultPage = rgDefaultPage.EditValue.ToEnum<DefaultPageType>();
            launch.StartAutoMaintain = chkStartAutoMaintain.Checked;
            launch.ReStartTimeSpan = rgReStartTimeSpan.EditValue.ToEnum<ReStartTimeSpanType>();
            launch.Hours = teHours.Text.ToInt();
            if (launch.FixedTimes == null)
                launch.FixedTimes = new List<DateTime>();
            launch.FixedTimes.Add(teFixedTimeFirst.Time);
            launch.FixedTimes.Add(teFixedTimeSecond.Time);
            launch.FixedTimes.Add(teFixedTimeThird.Time);
            launch.RunVersion = rgAppRunVersion.EditValue.ToEnum<AppRunVersion>();
            CfgUtil.SetAppRunVersion(launch.RunVersion);
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存程序运行设置信息");
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barItemRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.ShowDialog();
        }
    }
}