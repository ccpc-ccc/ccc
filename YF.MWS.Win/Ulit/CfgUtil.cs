using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.SQliteService;
using YF.Utility;
using YF.Utility.Security;
using YF.MWS.Util;
using YF.Utility.IO;

namespace YF.MWS.Win
{
    /// <summary>
    /// 系统配置工具类
    /// Author:闫孝感
    /// Date:2023-12-20
    /// </summary>
    public class CfgUtil
    {
        private static SysCfg cfg;

        public static void SaveCfg(SysCfg cfg)
        {
            string xmlPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
            XmlUtil.Serialize<SysCfg>(cfg, xmlPath);
            ResetCfg();
        }

        public static SysCfg GetCfg()
        {
            if (cfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
                cfg = null;
                if (File.Exists(xmlPath))
                {
                    cfg = XmlUtil.Deserialize<SysCfg>(xmlPath);
                }
            }
            if (cfg == null) 
            {
                cfg = new SysCfg();
            }
            return cfg;
        }

        public static void SetAppRunVersion(AppRunVersion version) 
        {
            CurrentClient.Instance.RunVersion = version;
            string filePath;
            if (version == AppRunVersion.Corp)
            {
                CurrentClient.Instance.StartLogoUrl = Path.Combine(Application.StartupPath, "Config", "Launch", "start.png");
                CurrentClient.Instance.BannerUrl = Path.Combine(Application.StartupPath, "Config", "Launch", "banner.jpg");
                //filePath = Path.Combine(Application.StartupPath, "Config", "Launch", "infor.txt");
                //CurrentClient.Instance.Infor = TxtUtil.Read(filePath);
            }
            else 
            {
                CurrentClient.Instance.StartLogoUrl = Path.Combine(Application.StartupPath, "Config", "Launch", "dstart.png");
                CurrentClient.Instance.BannerUrl = Path.Combine(Application.StartupPath, "Config", "Launch", "dbanner.jpg");
                //filePath = Path.Combine(Application.StartupPath, "Config", "Launch", "dinfor.txt");
                //CurrentClient.Instance.Infor = TxtUtil.Read(filePath);
            }
        }

        public static void ResetCfg()
        {
            cfg = null;
        }
    }
}
