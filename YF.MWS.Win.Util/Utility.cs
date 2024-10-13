using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Configuration;
using YF.MWS.Db;
using System.IO;
using YF.Utility.IO;
using YF.MWS.Metadata.UI;
using System.Diagnostics;
using YF.Utility.Log;
using System.Windows.Forms;

namespace YF.MWS.Win.Util
{
    public class Utility
    {
        public static string GetSearchTime(DateEdit de, TimeEdit te)
        {
            string searchTime = string.Empty;
            if (de.DateTime != DateTime.MinValue)
            {
                DateTime date = de.DateTime;
                DateTime time = te.Time;
                DateTime dt = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                searchTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return searchTime;
        }

        /// <summary>
        /// 根据配置信息生成磅单号
        /// </summary>
        /// <param name="weightService"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static string GenerateWeightNo(IWeightService weightService, WeightNoCfg cfg)
        {
            StringBuilder sbNo = new StringBuilder();
            int currentTotalCount = 0;
            if (weightService != null)
            {
                currentTotalCount = weightService.GetCurrentDateCount();
            }
            if (cfg != null)
            {
                if (cfg.PrefixFormat == WeightNoPrefixFormat.Date)
                {
                    sbNo.Append(DateTime.Now.ToString("yyyyMMdd"));
                }
                else
                {
                    sbNo.Append(cfg.Prefix);
                }
                currentTotalCount = currentTotalCount + cfg.CardinalNo + 1;
                sbNo.AppendFormat(currentTotalCount.ToString().PadLeft(cfg.SerialNoDigit, '0'));
            }
            else
            {
                currentTotalCount = currentTotalCount + 1;
                sbNo.AppendFormat(currentTotalCount.ToString().PadLeft(5, '0'));
            }
            return sbNo.ToString();
        }

        public static List<FileItem> GetFileList(string dirName)
        {
            List<FileItem> lstFile = new List<FileItem>();
            string fName = string.Empty;
            if (Directory.Exists(dirName))
            {
                foreach (string fileName in Directory.GetFiles(dirName))
                {
                    fName = Path.GetFileNameWithoutExtension(fileName);
                    if (!fName.StartsWith("~"))
                    {
                        lstFile.Add(new FileItem()
                        {
                            FullPath = fileName,
                            FileName = Path.GetFileNameWithoutExtension(fileName),
                            CreateTime = Directory.GetCreationTime(fileName),
                            UpdateTime = Directory.GetLastWriteTime(fileName),
                        });
                    }
                }
            }
            return lstFile;
        }

        public static WaitDialogForm GetWaitForm(string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new DevExpress.Utils.WaitDialogForm(AppSetting.GetValue("loadData"), AppSetting.GetValue("appName"));
            }
            else
            {
                return new DevExpress.Utils.WaitDialogForm(message, AppSetting.GetValue("appName"));
            }
        }

        public static WaitDialogForm GetWaitForm(XtraForm form)
        {
            string message = string.Empty;
            message = string.Format("正在加载{0},请稍后...", form.Text);
            if (string.IsNullOrEmpty(message))
            {
                return new DevExpress.Utils.WaitDialogForm(AppSetting.GetValue("loadData"), AppSetting.GetValue("appName"));
            }
            else
            {
                return new DevExpress.Utils.WaitDialogForm(message, AppSetting.GetValue("appName"));
            }
        }

        /// <summary>
        /// 执行查询时界面处理
        /// </summary>
        /// <param name="form">界面</param>
        /// <param name="title">要显示的值</param>
        /// <returns></returns>
        public static WaitDialogForm GetWaitForm(Form form, string title)
        {
            string message = string.Empty;
            message = string.Format("正在{0},请稍后...", title);
            if (string.IsNullOrEmpty(message))
            {
                return new DevExpress.Utils.WaitDialogForm(AppSetting.GetValue("appName"), AppSetting.GetValue("loadData"));
            }
            else
            {
                return new DevExpress.Utils.WaitDialogForm(form.Text, message);
            }
        }

        public static string GetReportTemplate(SReportTemplate template)
        {
            string path = template.TemplateUrl;
            if (template != null && template.TemplateContent != null)
            {
                if (!Directory.Exists(@"File\Temp"))
                {
                    Directory.CreateDirectory(@"File\Temp");
                }
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"File\Temp\{0}.repx", template.TemplateId));
                FileHelper.Delete(path);
                File.WriteAllBytes(path, template.TemplateContent);
            }
            return path;
        }

        public static string GetFilePath(string fileExtension, string fileId, byte[] fileContent)
        {
            string path = string.Empty;
            if (fileContent != null)
            {
                if (!Directory.Exists(@"File\Temp"))
                {
                    Directory.CreateDirectory(@"File\Temp");
                }
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"File\Temp\{0}.{1}", fileId, fileExtension));
                FileHelper.Delete(path);
                File.WriteAllBytes(path, fileContent);
            }
            return path;
        }

        /// <summary>
        /// 将byte[]转成指定的结构体
        /// </summary>
        /// <typeparam name="StructType">结构体类型</typeparam>
        /// <param name="bytesBuffer">byte数组</param>
        /// <returns></returns> 
        public static StructType ConverBytesToStructure<StructType>(byte[] bytesBuffer)
        {
            // 检查长度。
            if (bytesBuffer.Length != Marshal.SizeOf(typeof(StructType)))
            {
                throw new ArgumentException("字节数组与指定结构体字节长度不一致。");
            }

            IntPtr bufferHandler = Marshal.AllocHGlobal(bytesBuffer.Length);
            for (int index = 0; index < bytesBuffer.Length; index++)
            {
                Marshal.WriteByte(bufferHandler, index, bytesBuffer[index]);
            }
            StructType structObject = (StructType)Marshal.PtrToStructure(bufferHandler, typeof(StructType));
            Marshal.FreeHGlobal(bufferHandler);

            return structObject;
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        /// <param name="fileName"></param>
        public static bool Start(string fileName)
        {
            bool isStarted = false;
            try
            {
                Process proc = Process.Start(fileName);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
                isStarted = true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            return isStarted;
        }

        /// <summary>
        /// 程序重启
        /// </summary>
        public static void ReStart() 
        {
            System.Diagnostics.ProcessStartInfo cp = new System.Diagnostics.ProcessStartInfo();
            cp.FileName = Application.ExecutablePath;
            cp.UseShellExecute = true;
            System.Diagnostics.Process.Start(cp);
        }
    }
}
