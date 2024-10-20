using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.Utility.Log;
using System.Configuration;
using YF.Utility;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using DevExpress.XtraSplashScreen;
using YF.Utility.Configuration;
using System.IO;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Security;
using YF.MWS.CacheService;
using YF.MWS.Win.View.User;
using YF.MWS.Util;
using YF.MWS.Metadata;
using System.Runtime.InteropServices;
using YF.Utility.Net;
using YF.MWS.Win.View.Home;

namespace YF.MWS.Win
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private IUserService userService = new UserService();
        private ILogService logSerivce = new LogService();
        private ICompanyService companyService = new CompanyService();
        private LoginCfg loginCfg = null;
        private bool autoLogin = false;
        private bool changeUser = false;

        public bool ChangeUser
        {
            get { return changeUser; }
            set { changeUser = value; }
        }
        private string loginCfgXml = Path.Combine(Application.StartupPath, "LoginCfg.xml");
        private IMasterService masterService = new MasterService();
        private Dictionary<string, string> dicDsn = new Dictionary<string, string>();
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmLogin));
        public FrmLogin()
        {
            InitializeComponent();
            SplashScreenManager.CloseForm();
            this.Icon= global::YF.MWS.Win.Properties.Resources.favicon;
        }
      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(combUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageDxUtil.ShowWarning("用户名密码不能为空");
                return;
            }
            else
            {
                string userName = combUserName.Text;
                string userPwd = txtPassword.Text.ToMd5();
                 SUser user = null;
                user = userService.Login(userName, userPwd);
                if (user != null)
                {
                    if (user.Active == 0)
                    {
                        if (!autoLogin)
                        {
                            MessageDxUtil.ShowWarning("用户未激活！");
                        }
                    }
                    else
                    {
                        CurrentUser.Instance.UserName = user.UserName;
                        CurrentUser.Instance.Id = user.Id;
                        CurrentUser.Instance.FullName = user.FullName;
                        CurrentUser.Instance.CustomerId = user.CustomerId;
                        CurrentUser.Instance.IsAdministrator = user.IsAdmin == 1 ? true : false;
                        CurrentUser.Instance.CompanyId= user.CompanyId;
                        CurrentUser.Instance.Powers = user.Powers?.Split(',');
                        CurrentUser.Instance.UserType = user.UserType.ToEnum<UserType>();
                        if (user.CompanyId != null && user.CompanyId != "") {
                            CurrentUser.Instance.CompanyIds = companyService.GetCompanys(user.CompanyId).ToArray();
                        }
                        try
                        {
                            if (loginCfg == null)
                            {
                                loginCfg = new LoginCfg();
                            }
                            loginCfg.UserName = combUserName.Text;
                            loginCfg.RememberPwd = chkRememberPwd.Checked;
                            if(!loginCfg.UserNames.Contains(loginCfg.UserName)) loginCfg.UserNames.Add(loginCfg.UserName);
                            if (chkRememberPwd.Checked)
                            {
                                loginCfg.UserPwd = Encrypt.EncryptDES(txtPassword.Text, CurrentClient.Instance.EncryptKey);
                            }
                            XmlUtil.Serialize<LoginCfg>(loginCfg, loginCfgXml);
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteException(ex);
                        }
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                {
                    if (!autoLogin)
                    {
                        MessageDxUtil.ShowWarning("用户名密码错误");
                    }
                }
            } 
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string fileName = AppSetting.GetValue("LoginLogoUrl");
            if (File.Exists(fileName))
            {
                peWaitting.Image = Image.FromFile(fileName);
            }
            BindData();
            DataBaseType dbType = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
            BindDbCfg(dbType);
            if (autoLogin) 
            {
                btnLogin.PerformClick();
            }
        }

        private void BindDbCfg(DataBaseType dbType) 
        {
            if (dbType == DataBaseType.Sqlserver) 
            {
                string dsn = AppSetting.GetValue("dsn");
                if (string.IsNullOrEmpty(dsn)) return;
                List<string> lstDsn = dsn.Split(';').ToList();
            }
        }

        private void BindData()
        {
            loginCfg = YF.Utility.Serialization.XmlUtil.Deserialize<LoginCfg>(loginCfgXml);
            if (loginCfg != null)
            {
                if (loginCfg.RememberPwd && !string.IsNullOrEmpty(loginCfg.UserPwd))
                {
                    txtPassword.Text = Encrypt.DecryptDES(loginCfg.UserPwd, CurrentClient.Instance.EncryptKey);
                }
                chkRememberPwd.Checked = loginCfg.RememberPwd;
                combUserName.Properties.Items.AddRange(loginCfg.UserNames.ToArray());
                combUserName.Text = loginCfg.UserName;
            }
            SysCfg cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.Weight != null) 
            {
                autoLogin = false; // cfg.Weight.AutoLogin;
            }
            if (changeUser)
                autoLogin = false;
        }

    }
}