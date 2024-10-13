using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Metadata;
using YF.Utility.Configuration;
using YF.Utility.Log;

namespace YF.MWS.Win
{
    public class ProcessUtil
    {
        //2.在进程中查找是否已经有实例在运行
        #region  确保程序只运行一个实例
        public static Process RunningInstance(bool runMoreApps)
        {
            if (runMoreApps)
                return null;
            Process current = Process.GetCurrentProcess();
            string appName = AppSetting.GetValue("appName");
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (process.MainWindowTitle.ToLower() == appName.ToLower())
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }
        //3.已经有了就把它激活，并将其窗口放置最前端
        public static void HandleRunningInstance(Process instance)
        {
            MessageDxUtil.ShowWarning("本程序已经在运行，请不要同时运行多个相同程序。");  
            ShowWindowAsync(instance.MainWindowHandle,3);  //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }

        /// <summary>
        /// 关闭指定名称的进程
        /// </summary>
        /// <param name="processname"></param>
        public static void KillProcess(string processname,string mainWidowTitle)
        {
            try
            {
                Process[] allProcess = Process.GetProcesses();
                foreach (Process p in allProcess)
                {
                    if (p.ProcessName.ToLower() == processname.ToLower() && p.MainWindowTitle.ToLower()==mainWidowTitle.ToLower())
                    {
                        for (int i = 0; i < p.Threads.Count; i++)
                            p.Threads[i].Dispose();

                        p.Kill();
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion

        public static Process RunningInstanceByPath(bool runMoreApps)
        {
            if (runMoreApps)
                return null;
            Process current = Process.GetCurrentProcess();
            string exePath = AppSetting.GetValue("ExePath");
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (process.MainModule.FileName.ToLower() == exePath.ToLower())
                    {
                        return process;
                    }
                }
            }
            return null;
        }
    }
}
