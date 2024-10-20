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
using YF.MWS.Metadata.Screen;
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
        private static SmsCfg smsCfg = null;
        private static FontCfg fontCfg;
        private static LoginCfg loginCfg = null;
        private static VoiceCfg voiceCfg = null;
        public static AllFormCfg allFormCfg = null;

        public static void Init() 
        {
            SysCfg cfg = GetCfg();
            if (cfg != null) 
            {
                if (cfg.Transfer != null) 
                {
                    CurrentClient.Instance.ServerUrl = cfg.Transfer.ServerUrl;
                }
            }
        }

        public static string GetAuthCode(AuthCfg cfg) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(cfg.StartVideo ? "1" : "0");
            sb.Append(cfg.ReadCard ? "1" : "0");
            sb.Append(cfg.CarNoRecognition ? "1" : "0");
            sb.Append(cfg.StartOnline ? "1" : "0");
            sb.Append(cfg.AutoWeight ? "1" : "0");
            sb.Append(cfg.StartScreen ? "1" : "0");
            sb.Append(cfg.StartFinance ? "1" : "0");
            sb.Append(cfg.StartPad ? "1" : "0");
            string authCode = Encrypt.EncryptDES(sb.ToString(), CurrentClient.Instance.EncryptKey);
            return authCode;
        }

        public static AuthCfg GetAuthFromAuthCode(string authCode)
        {
            AuthCfg cfg = new AuthCfg();
            if (string.IsNullOrEmpty(authCode))
            {
                return cfg;
            }
            //authCode = Encrypt.DecryptDES(authCode, CurrentClient.Instance.EncryptKey);
                if (authCode[0] == '1')
                {
                    cfg.StartVideo = true;
                }
                if (authCode[1] == '1')
                {
                    cfg.ReadCard = true;
                }
                if (authCode[2] == '1')
                {
                    cfg.CarNoRecognition = true;
                }
                if (authCode[3] == '1')
                {
                    cfg.StartOnline = true;
                }
                if (authCode[4] == '1')
                {
                    cfg.AutoWeight = true;
                }
                if (authCode[5] == '1')
                {
                    cfg.StartScreen = true;
                }
                if (authCode[6] == '1')
                {
                    cfg.StartFinance = true;
                }
                if (authCode[7] == '1')
                {
                    cfg.StartPad = true;
                }
            return cfg;
        }


        public static LoginCfg GetLoginCfg()
        {
            if (loginCfg == null)
            {
                string loginCfgXml = Path.Combine(Application.StartupPath, "LoginCfg.xml");
                if (File.Exists(loginCfgXml))
                {
                    loginCfg = YF.Utility.Serialization.XmlUtil.Deserialize<LoginCfg>(loginCfgXml);
                }
            }
            return loginCfg;
        }

        /// <summary>
        /// 获取授权配置信息
        /// </summary>
        /// <returns></returns>
        public static AuthCfg GetAuth()
        {
            AuthCfg cfg = new AuthCfg();
                cfg.AutoWeight = true;
                cfg.CarNoRecognition = true;
                cfg.ReadCard = true;
                cfg.StartOnline = true;
                cfg.StartVideo = true;
                cfg.StartPad = true;
                cfg.StartFinance = true;
                cfg.StartScreen = true;
            return cfg;
        }

        public static FontCfg GetFontCfg()
        {
            if (fontCfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "FontCfg.xml");
                if (File.Exists(xmlPath))
                {
                    fontCfg = XmlUtil.Deserialize<FontCfg>(xmlPath);
                }
            }
            return fontCfg;
        }

        public static LXCfg GetLXCfg(int ledNo=1)
        {
            LXCfg lxCfg = null;
            string xmlPath = Path.Combine(Application.StartupPath, "LXCfg.xml");
            if (ledNo > 1)
            {
                xmlPath = Path.Combine(Application.StartupPath, string.Format("LXCfg_{0}.xml", ledNo));
            }
            if (File.Exists(xmlPath))
            {
                lxCfg = XmlUtil.Deserialize<LXCfg>(xmlPath);
            }
            if (lxCfg == null)
                lxCfg = new LXCfg();
            return lxCfg;
        }

        public static SmsCfg GetSmsCfg()
        {
            if (smsCfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "SmsCfg.xml");
                if (File.Exists(xmlPath))
                {
                    smsCfg = XmlUtil.Deserialize<SmsCfg>(xmlPath);
                }
            }
            return smsCfg;
        }

        public static VoiceCfg GetVoiceCfg()
        {
            if (voiceCfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "VoiceCfg.xml");
                if (File.Exists(xmlPath))
                {
                    voiceCfg = XmlUtil.Deserialize<VoiceCfg>(xmlPath);
                }
            }
            return voiceCfg;
        }

        public static void SaveFormData(FormData data)
        {
            string xmlPath = Path.Combine(Application.StartupPath, "FormData.xml");
            XmlUtil.Serialize<FormData>(data, xmlPath);
        }

        public static ExportCfg GetExportCfg()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "Config", "ExportCfg.xml");
            if (File.Exists(xmlPath))
            {
                return XmlUtil.Deserialize<ExportCfg>(xmlPath);
            }
            else
            {
                return null;
            }
        }

        public static FormData GetFormData()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "FormData.xml");
            if (File.Exists(xmlPath))
            {
                return XmlUtil.Deserialize<FormData>(xmlPath);
            }
            else
            {
                return null;
            }
        }

        public static Font GetFont()
        {
            FontCfg fontCfg = GetFontCfg();
            if (fontCfg == null)
            {
                fontCfg = new FontCfg();
            }
            Font f = new Font(fontCfg.FamilyName, fontCfg.FontSize, fontCfg.Style, GraphicsUnit.Point);
            return f;
        }

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
        public static AllFormCfg GetFormCfg()
        {
            if(allFormCfg!=null) return allFormCfg;
                string xmlPath = Path.Combine(Application.StartupPath, "Layerout/FormCfg.xml");
                if (File.Exists(xmlPath))
                {
                allFormCfg = XmlUtil.Deserialize<AllFormCfg>(xmlPath);
            } else {
                allFormCfg = new AllFormCfg();
            }
            return allFormCfg;
        }
        public static void SaveFormCfg(AllFormCfg cfg)
        {
            string xmlPath = Path.Combine(Application.StartupPath, "Layerout/FormCfg.xml");
            XmlUtil.Serialize<AllFormCfg>(cfg, xmlPath);
            allFormCfg = cfg;
        }
        public static void LoadFormCfg(Form frm,FormCfg cfg) {
            if (cfg.isMax < 0) return;
            frm.WindowState= cfg.isMax==1? FormWindowState.Maximized : FormWindowState.Normal;
            frm.Location =new Point(cfg.x,cfg.y);
        }

        public static void SaveSmsCfg(SmsCfg cfg)
        {
            string xmlPath = Path.Combine(Application.StartupPath, "SmsCfg.xml");
            XmlUtil.Serialize<SmsCfg>(cfg, xmlPath);
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

        public static void ResetFontCfg()
        {
            fontCfg = null;
        }

        public static void ResetLoginCfg()
        {
            loginCfg = null;
        }

        public static void ResetVoiceCfg()
        {
            voiceCfg = null;
        }
    }
}
