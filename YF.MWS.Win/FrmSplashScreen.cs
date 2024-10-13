using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using YF.Utility.Configuration;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.CacheService;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata;

namespace YF.MWS.Win
{
    public partial class FrmSplashScreen : SplashScreen
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
            LoadStartLogo();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {

        }

        private void LoadStartLogo() 
        {
            SysCfg cfg = CfgUtil.GetCfg();
            AppRunVersion runVersion = AppRunVersion.Corp;
            if (cfg != null)
            {
                if (cfg.Launch != null)
                    runVersion = cfg.Launch.RunVersion;
            }
            CfgUtil.SetAppRunVersion(runVersion);
            string fileName = AppSetting.GetValue("StartLogoUrl");
            if (File.Exists(fileName))
            {
                peWaitting.Image = Image.FromFile(fileName);
            }
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            string companyName = AppSetting.GetValue("corpName");
            lblCopyright.Text = string.Format("{0} © {1}-{2}", companyName, AppSetting.GetValue("startYear"), DateTime.Now.Year);
        }
    }
}