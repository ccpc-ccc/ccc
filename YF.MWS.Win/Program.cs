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
using DevExpress.XtraEditors.Controls;
using YF.Utility;
using YF.Utility.Security;
using YF.Utility.Configuration;
using YF.MWS.Metadata.Cfg;
using System.IO;
using System.Text.RegularExpressions;
using YF.MWS.Util;
using DevExpress.XtraSplashScreen;
using YF.MWS.Win.View.Weight;
using System.Text;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Security;
using YF.MWS.Db.Server;

namespace YF.MWS.Win {
    static class Program {
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
        /// 应用程序定时检测器
        /// </summary>
        private static System.Windows.Forms.Timer timerApp;
        private static string backDir = string.Empty;
        public static SysCfg cfg = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
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
            //  Money Twins
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool runMoreApps = false;
            if (args != null && args.Length > 0)
                runMoreApps = true;
            Process instance = ProcessUtil.RunningInstance(runMoreApps);
            if (instance == null) {
                //控件汉化
                Localizer.Active = new LocalizationCHS();
                CurrentClient.Instance.DataBase = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) {
                    ServiceInitialization.Init();
                }
                SplashScreenManager.ShowForm(typeof(FrmSplashScreen), true, true);
                bool isConnected = false;
                //InitRegisterMode();
                isConnected = CheckDbConfig();
                if (!isConnected) {
                    return;
                }
                            FrmWeightSearch mainForm = new FrmWeightSearch();
                            Application.Run(mainForm);
            } else {
                ProcessUtil.HandleRunningInstance(instance);
            }
        }

        private static bool CheckDbConfig() {
            bool isConnected = false;
            try {
                IClientService clientService = new ClientService();
                if (clientService == null) {
                    return isConnected;
                }
                isConnected = clientService.IsConnect();
            } catch (Exception e) {
                Logger.WriteException(e);
            }
            if (!isConnected) {
                MessageBox.Show("数据库连接不成功\n请检查配置文件(MWS.exe.config)中的数据库连接信息配置是否正确或者联系软件供应商获取帮助.","错误");
            }
            return isConnected;
        }


        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
            Logger.WriteException(e.Exception);
            MessageBox.Show("发生未知错误:" + e.Exception.Message);
            //Util.Utility.ReStart();
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Logger.Write(string.Format("current domain unhandled exception,is terminating:{0}", e.IsTerminating));
            Exception ex = null;
            ex = e.ExceptionObject as Exception;
            Logger.WriteException(ex);
            MessageBox.Show("发生未知错误:" + ex != null ? ex.Message : "请重试");
            //Environment.Exit(System.Environment.ExitCode);//有此句则不弹异常对话框
            //Util.Utility.ReStart();
        }

        private static void Application_Exit(object sender, EventArgs e) {
            try {
                CurrentClient.Instance.DataBase = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                    string path = AppSetting.GetValue("dsnSqlite");
                    if (string.IsNullOrEmpty(cfg.Weight.BackupDir))
                        cfg.Weight.BackupDir = @"D:\MWS\DataBack";
                    if (!Directory.Exists(cfg.Weight.BackupDir)) {
                        Directory.CreateDirectory(cfg.Weight.BackupDir);
                    }
                    System.IO.File.Copy(path, cfg.Weight.BackupDir + "\\MWS.db", true);
                }

                //Environment.Exit(0);
            } catch (Exception ex) {
                Logger.Write("关闭加密狗设备异常：" + ex.ToString());
            }
        }
    }
}
