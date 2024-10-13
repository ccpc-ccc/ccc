using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using YF.Utility.Log;

namespace YF.MWS.Util
{
    public class FFmpegUtil
    {
        public static void AVIToMP4(string sourceFile, string targetFile)
        {
            try
            {
                string command = string.Format(@"ffmpeg -i {0} -y -vcodec h264 {1}", sourceFile, targetFile);
                Logger.Info("command:" + command);
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();
                //向cmd窗口发送输入信息
                //p.StandardInput.WriteLine(command + "&exit");
                p.StandardInput.WriteLine(command);
                p.StandardInput.AutoFlush = true;

                //获取输出信息
                //string strOuput = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                //p.WaitForExit();
                p.Close();
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 海康视频需要转换
        /// https://www.freesion.com/article/7067942548/
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        public static void HKToMP4(string sourceFile, string targetFile)
        {
            try
            {
                string command = string.Format(@"ffmpeg -i {0} -c copy -an {1}", sourceFile, targetFile);
                Logger.Info("command:" + command);
                Process process = new Process();
                //设置要启动的应用程序
                process.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                process.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                process.StartInfo.RedirectStandardInput = true;
                //输出信息
                process.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                process.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                process.StartInfo.CreateNoWindow = true;
                //启动程序
                process.Start();
                //向cmd窗口发送输入信息
                //p.StandardInput.WriteLine(command + "&exit");
                process.StandardInput.WriteLine(command);
                process.StandardInput.AutoFlush = true;

                //获取输出信息
                //string strOuput = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                //p.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
    }
}
