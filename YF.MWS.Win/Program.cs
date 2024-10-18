using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using YF.Utility.Log;
using System.Threading;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.MWS.Win.Util;
using DevExpress.XtraEditors.Controls;
using YF.Utility;
using YF.Utility.Security;
using YF.Utility.Configuration;
using YF.MWS.Metadata.Cfg;
using YF.MWS.CacheService;
using System.IO;
using System.Text.RegularExpressions;
using YF.MWS.Util;
using DevExpress.XtraSplashScreen;
using YF.MWS.Win.View.Weight;
using YF.MWS.Win.Core;
using System.Text;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Security;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Db.Server;

namespace YF.MWS.Win
{
    static class Program
    {
        public delegate void MyDelegate(int number);
        private static bool isExpired = false;
        private static DateTime expireDate = DateTime.Now;//加密狗过期时间
        //private static string PID = "ADDB5E67";
        private static string KeyPath;
        private static bool hasShowDialog = false;
        private static bool startBackupDb = false;
        private static bool expiredOnLine = false;
        private static bool hasRequested = false;
        private static string _readL = "BE56E057";
        private static string _readH = "F20F883E";
        public static SClient SClient { get; private set; }
        /// <summary>
        /// 加密狗PID
        /// </summary>
        //private static string et99PID = string.Empty;

        /// <summary>
        /// ET99加密狗工具类
        /// </summary>
        //private static ET99Util et99;
        private static SoftKeyPWD et99;

        /// <summary>
        /// 应用程序定时检测器
        /// </summary>
        private static System.Windows.Forms.Timer timerApp;
        private static IMasterService masterService = null;
        private static IWebClientService webClientService = new WebClientService();
        private static string backDir = string.Empty;
        public static SysCfg cfg = null;
        public static FrmMain frmMain { get; set; }
        public static FrmViewVideoDevice frmViewVideoDevice { get; set; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //应用程序退出事件
            Application.ApplicationExit += new EventHandler(Application_Exit);
            //处理未捕获的异常   
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            BonusSkins.Register();
            SkinManager.EnableFormSkinsIfNotVista();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            ApplicationUtil.InitApp();
            DevExpress.LookAndFeel.DefaultLookAndFeel feel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            string skinName = "Money Twins";
            LoginCfg loginCfg = CfgUtil.GetLoginCfg();
            if (loginCfg != null && !string.IsNullOrEmpty(loginCfg.SkinName))
            {
                skinName = loginCfg.SkinName;
            }
            feel.LookAndFeel.SetSkinStyle(skinName);
            //  Money Twins
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool runMoreApps = false;
            cfg = CfgUtil.GetCfg();
            if (cfg != null)
            {
                if (cfg.Launch != null)
                    runMoreApps = cfg.Launch.RunMoreApps;
            }
            if (args != null && args.Length > 0)
                runMoreApps = true;
            Process instance = ProcessUtil.RunningInstance(runMoreApps);
            if (instance == null)
            {
                //控件汉化
                Localizer.Active = new LocalizationCHS();
                CurrentClient.Instance.DataBase = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) 
                {
                    ServiceInitialization.Init();
                }
                masterService = new MasterService();
                SplashScreenManager.ShowForm(typeof(FrmSplashScreen), true, true);
                bool isConnected = false;
                //InitRegisterMode();
                isConnected = CheckDbConfig();
                if (!isConnected)
                {
                    return;
                }
                CfgUtil.Init();
                CacheUtil.Init();
                bool isOk= InitApplication();
                if (!isOk) {
                    using (FrmRegister frmRegister = new FrmRegister()) {
                        frmRegister.IsExpired = isExpired;
                        if (frmRegister.ShowDialog() == DialogResult.OK) {
                            isExpired = frmRegister.IsExpired;
                            InitApplication();
                        }
                    }
                } else {
                    using (FrmLogin loginForm = new FrmLogin()) {
                            if (args != null && args.Length > 0)
                                loginForm.ChangeUser = true;
                            if (loginForm.ShowDialog() == DialogResult.OK) {
                                FrmMain mainForm = new FrmMain();
                                mainForm.Icon = loginForm.Icon;
                                Application.Run(mainForm);
                            }
                    }
                }
            }
            else 
            {
                ProcessUtil.HandleRunningInstance(instance);
            }
        }

        private static bool CheckDbConfig()
        {
            bool isConnected = false;
            try
            {
                IClientService clientService = new ClientService();
                if (clientService == null)
                {
                    return isConnected;
                }
                isConnected = clientService.IsConnect();
            }
            catch (Exception e)
            {
                Logger.WriteException(e);
            }
            if (!isConnected)
            {
                MessageDxUtil.ShowWarning("数据库连接不成功\n请检查配置文件(MWS.exe.config)中的数据库连接信息配置是否正确或者联系软件供应商获取帮助.");
            }
            return isConnected;
        }

        private static void InitRegedit()
        {
            string adDomain = AppSetting.GetValue("AdDomain");
            if (string.IsNullOrEmpty(adDomain))
            {
                return;
            }
            if (Regex.Split(adDomain, "//").Length > 1)
            {
                string domain = Regex.Split(adDomain, "//")[1];
                string prefix = domain.Split('.')[0];
                RegeditUtil.InsertDomain(domain.Split(':')[0], prefix);
            }
        }

        private static void InitRegisterMode()
        {
            string filePath = Path.Combine(Application.StartupPath, "auth.yrg");
            if (File.Exists(filePath))
            {
                CurrentClient.Instance.RegType = RegisterMode.Softdog;
            }
            else
            {
                CurrentClient.Instance.RegType = RegisterMode.File;
            }
        }


        private static bool ValidateSoftWithSoftdogOnly() 
        {
            //初始化我们的操作加密锁的类
            et99 = new SoftKeyPWD();
            string outstring = "";
            //这个用于判断系统中是否存在着加密锁。不需要是指定的加密锁,
            if (et99.FindPort(0, ref KeyPath) != 0)
            {
                return false;
            }
            int ret = et99.YReadString(ref outstring, 0, 56, _readH, _readL, KeyPath);
            if (ret != 0) return false;
            if (outstring.Length != 56)  return false;
            string auth = outstring.Substring(0, 8);
            string date = outstring.Substring(32, 24);
            date = Encrypt.DecryptDES(date, CurrentClient.Instance.EncryptKey);
            DateTime now = DateTime.Now.ToString("yyyyMMdd").ToDate("yyyyMMdd");
            expireDate = date.ToDate("yyyyMMdd");
            if ((expireDate - now).Days < 0) {
                MessageBox.Show("加密狗无效，请联系供货商");
                return false;
            }
            CurrentClient.Instance.AutoCfg = Encrypt.EncryptDES(auth, CurrentClient.Instance.EncryptKey);
            return true;
        }
        /// <summary>
        /// 软件验证
        /// </summary>
        private static bool InitApplication()
        {
            try
            {
                //SysCfg cfg = CfgUtil.GetCfg();
                //CurrentClient.Instance.IsConnectedServer = NetworkUtil.IsConnectedServer(cfg);
                if (cfg != null) 
                {
                    if (cfg.Weight != null)
                    {
                        backDir = cfg.Weight.BackupDir;
                    }
                }
                isExpired = false;
                IClientService clientService = new ClientService();
                IWeightViewService viewService = new WeightViewService();
                IMasterService masterService = new MasterService();
                SWeightView view = viewService.GetDefaultView(ViewType.Weight);
                string machineCode = SoftValidator.GetMachineCode();
                CurrentClient.Instance.MachineCode = machineCode;
                string use = AppSetting.GetValue("use");
                string autoCode = "10011111";
                if (use == "all") {
                    autoCode = "11111111";
                }
                SClient = clientService.RegisterProbation(machineCode,"CS智能称重客户端", autoCode);
                if (SClient != null)
                {
                //string autoCfg = Encrypt.DecryptDES(SClient.AuthCode, CurrentClient.Instance.EncryptKey);
                    CurrentUser.Instance.ClientId = SClient.Id;
                    CurrentUser.Instance.ClientName = SClient.ClientName;
                    CurrentClient.Instance.VerifyCode = SClient.VerifyCode;
                    CurrentClient.Instance.AutoCfg = SClient.AuthCode;
                }
                bool isValidated = false;
                //优先验证无文件类型的加密狗
                isValidated = ValidateSoftWithSoftdogOnly();
                if (isValidated) {
                    CurrentClient.Instance.CurrentVersion = VersionType.Official;
                    CurrentClient.Instance.RegType = RegisterMode.Softdog;
                    SClient.RegisterType = "softdog";
                    timerApp = new System.Windows.Forms.Timer();
                    timerApp.Interval = 10000;
                    timerApp.Tick += timerApp_Tick;
                    timerApp.Start();
                } else {
                    int days= ResidueDays();
                    isExpired = true;
                    CurrentClient.Instance.ResidualDays = days;
                    if (days < 0) return false;
                if (SClient.RegisterType == "none") {
                        CurrentClient.Instance.CurrentVersion = VersionType.Probation;
                    MessageBox.Show($"当前使用的为试用版，剩余{days}天后到期，请尽快联系代理商家注册");
                    } else {
                        CurrentClient.Instance.CurrentVersion = VersionType.Official;
                        if (SClient.RegisterType == "file") {
                            CurrentClient.Instance.RegType = RegisterMode.File;
                        } else {
                            CurrentClient.Instance.RegType = RegisterMode.Softdog;
                        }
                    }
                    WebWeightService.ServerUrl = AppSetting.GetValue("EcsServer");
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
                return false;
        }
        private static int ResidueDays() {
            DateTime date = DateTime.Now.ToString("yyyyMMdd").ToDate("yyyyMMdd");
            DateTime expire = Encrypt.DecryptDES(SClient.ExpireCode, CurrentClient.Instance.EncryptKey).ToDate("yyyyMMdd");
            return (expire - date).Days;
        }

        private static void timerApp_Tick(object sender, EventArgs e) {
            if (CurrentClient.Instance.CurrentVersion == VersionType.Official && CurrentClient.Instance.RegType != RegisterMode.File) {
                if (et99.FindPort(0, ref KeyPath) != 0) {
                    timerApp.Stop();
                    MessageDxUtil.ShowTips("没有检测到加密狗设备，请检查！");
                    Application.Exit();
                } else {
                    if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 20) {
                        DateTime now = DateTime.Now.ToString("yyyyMMdd").ToDate("yyyyMMdd");
                        if ((expireDate - now).Days < 0) {
                            timerApp.Stop();
                            MessageBox.Show("加密狗无效，请联系供货商");
                            Application.Exit();
                        }
                    }
                }
            }
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.WriteException(e.Exception);
            MessageDxUtil.ShowError("发生未知错误:"+e.Exception.Message);
            //Util.Utility.ReStart();
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Write(string.Format("current domain unhandled exception,is terminating:{0}",e.IsTerminating));
            Exception ex = null;
            ex = e.ExceptionObject as Exception;
            Logger.WriteException(ex);
            MessageDxUtil.ShowError("发生未知错误:" + ex!=null ? ex.Message:"请重试");
            //Environment.Exit(System.Environment.ExitCode);//有此句则不弹异常对话框
            //Util.Utility.ReStart();
        }

        private static void Application_Exit(object sender, EventArgs e)
        {
            try
            {
                if (masterService != null && startBackupDb)
                    masterService.DataBackup(backDir);
                if (et99 != null)
                {
                    //关闭加密狗设备
                    //et99.CloseDevice();
                    //关闭加密狗检测定时器
                    if (timerApp != null && timerApp.Enabled)
                    {
                        timerApp.Stop();
                        timerApp = null;
                    }
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                CurrentClient.Instance.DataBase = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                    string path = AppSetting.GetValue("dsnSqlite");
                if (string.IsNullOrEmpty(cfg.Weight.BackupDir))
                    cfg.Weight.BackupDir = @"D:\MWS\DataBack";
                    if (!Directory.Exists(cfg.Weight.BackupDir)) {
                        Directory.CreateDirectory(cfg.Weight.BackupDir);
                    }
                    System.IO.File.Copy(path, cfg.Weight.BackupDir+"\\MWS.db", true);
                }

                //Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Logger.Write("关闭加密狗设备异常：" + ex.ToString());
            }
        }
    }
}
