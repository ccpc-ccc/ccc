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
            if (cfg.StartVideo)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.ReadCard)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.CarNoRecognition)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.StartOnline)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.AutoWeight)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.StartScreen)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.StartFinance)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            if (cfg.StartPad)
            {
                sb.Append("1");
            }
            else
            {
                sb.Append("0");
            }
            string authCode = Encrypt.EncryptDES(sb.ToString(), CurrentClient.Instance.EncryptKey);
            return authCode;
        }

        private static AuthCfg GetAuthFromAuthCode(string authCode)
        {
            AuthCfg cfg = new AuthCfg();
            if (string.IsNullOrEmpty(authCode))
            {
                return cfg;
            }
            authCode = Encrypt.DecryptDES(authCode, CurrentClient.Instance.EncryptKey);
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

        public static AuthCfg GetAuthFromVersion(string version, AuthCfg baseCfg)
        {
            AuthCfg cfg = new AuthCfg();
            if (string.IsNullOrEmpty(version))
            {
                return cfg;
            }
                if (version[0] == '1' || baseCfg.StartVideo)
                {
                    cfg.StartVideo = true;
                }
                if (version[1] == '1' || baseCfg.ReadCard)
                {
                    cfg.ReadCard = true;
                }
                if ( version[2] == '1' || baseCfg.CarNoRecognition)
                {
                    cfg.CarNoRecognition = true;
                }
                if ( version[3] == '1' || baseCfg.StartOnline)
                {
                    cfg.StartOnline = true;
                }
                if ( version[4] == '1' || baseCfg.AutoWeight)
                {
                    cfg.AutoWeight = true;
                }
                if ( version[5] == '1' || baseCfg.StartScreen)
                {
                    cfg.StartScreen = true;
                }
                if ( version[6] == '1'|| baseCfg.StartFinance)
                {
                    cfg.StartFinance = true;
                }
                if ( version[7] == '1' || baseCfg.StartPad)
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
            /*if (CurrentClient.Instance.CurrentVersion == VersionType.Probation)
            {
            }
            else
            {
                IClientService clientService = new ClientService();
                SClient client = clientService.Get(CurrentClient.Instance.MachineCode);
                bool hasLoadAuthCode = false;
                if (client != null)
                {
                    AuthCfg baseCfg = new AuthCfg();
                    if (!string.IsNullOrEmpty(client.AuthCode))
                    {
                        baseCfg = GetAuthFromAuthCode(client.AuthCode);
                    }
                    if (CurrentClient.Instance.RegType == RegisterMode.SoftdogOnly)
                    {
                        cfg = CfgUtil.GetAuthFromVersion(CurrentClient.Instance.VersionFunc, baseCfg);
                    }
                    if (CurrentClient.Instance.RegType == RegisterMode.File)
                    {
                        cfg = baseCfg;
                    }
                    hasLoadAuthCode = true;
                }
                if (!hasLoadAuthCode)
                {
                    string path = Path.Combine(Application.StartupPath, "auth.cfg");
                    if (File.Exists(path))
                    {
                        string[] lines = File.ReadAllLines(path);
                        if (lines != null && lines.Length > 0)
                        {
                            cfg = Encrypt.DecryptDES(lines[0], CurrentClient.Instance.EncryptKey).JsonDeserialize<AuthCfg>();
                            hasLoadAuthCode = true;
                        }
                    }
                    if (!hasLoadAuthCode)
                    {
                        path = Path.Combine(Application.StartupPath, "auth.yrg");
                        if (File.Exists(path))
                        {
                            string[] lines = File.ReadAllLines(path);
                            if (lines != null && lines.Length > 0)
                            {
                                cfg = Encrypt.DecryptDES(lines[3], CurrentClient.Instance.EncryptKey).JsonDeserialize<AuthCfg>();
                                hasLoadAuthCode = true;
                            }
                        }
                    }
                }
            }
            */
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
            FontCfg fontCfg = null;
            fontCfg = GetFontCfg();
            if (fontCfg == null)
            {
                fontCfg = new FontCfg();
            }
            Font f = new Font(fontCfg.FamilyName, fontCfg.FontSize, fontCfg.Style, GraphicsUnit.Pixel);
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
