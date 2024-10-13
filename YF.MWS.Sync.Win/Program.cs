using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility.Configuration;
using YF.Utility.Log;
using YF.Utility;

namespace YF.MWS.Sync.Win
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string exePath = AppSetting.GetValue("ExePath");
            string currentPath = Process.GetCurrentProcess().MainModule.FileName;
            if (string.IsNullOrEmpty(exePath) || (!string.IsNullOrEmpty(exePath) && exePath != currentPath))
            {
                AppConfigUtil.SetConfigValue("ExePath", currentPath);
            }
            Process instance = ProcessUtil.RunningInstanceByPath(false);
            if (instance == null)
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                CurrentClient.Instance.DataBase = AppSetting.GetValue("databaseType").ToEnum<DataBaseType>();
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
                {
                    ServiceInitialization.Init();
                }
                CfgUtil.Init();
                Application.Run(new FrmMain());
            }
            else
            {
                ProcessUtil.HandleRunningInstance(instance);
            }
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.WriteException(e.Exception);
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Write(string.Format("current domain unhandled exception,is terminating:{0}", e.IsTerminating));
            Logger.WriteException(e.ExceptionObject as Exception);
            Environment.Exit(System.Environment.ExitCode);//有此句则不弹异常对话框
        }
    }
}
