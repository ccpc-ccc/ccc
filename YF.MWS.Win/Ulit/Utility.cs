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
using System.Diagnostics;
using YF.Utility.Log;
using System.Windows.Forms;
using DevExpress.Export.Xl;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;

namespace YF.MWS.Win {
    public class Utility {
        public static string GetSearchTime(DateEdit de, TimeEdit te) {
            string searchTime = string.Empty;
            if (de.DateTime != DateTime.MinValue) {
                DateTime date = de.DateTime;
                DateTime time = te.Time;
                DateTime dt = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                searchTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return searchTime;
        }

        public static WaitDialogForm GetWaitForm(string message = null) {
            if (string.IsNullOrEmpty(message)) {
                return new DevExpress.Utils.WaitDialogForm(AppSetting.GetValue("loadData"), AppSetting.GetValue("appName"));
            } else {
                return new DevExpress.Utils.WaitDialogForm(message, AppSetting.GetValue("appName"));
            }
        }

        public static WaitDialogForm GetWaitForm(XtraForm form) {
            string message = string.Empty;
            message = string.Format("正在加载{0},请稍后...", form.Text);
            if (string.IsNullOrEmpty(message)) {
                return new DevExpress.Utils.WaitDialogForm(AppSetting.GetValue("loadData"), AppSetting.GetValue("appName"));
            } else {
                return new DevExpress.Utils.WaitDialogForm(message, AppSetting.GetValue("appName"));
            }
        }


        public static string GetReportTemplate(SReportTemplate template) {
            string path = template.TemplateUrl;
            if (template != null && template.TemplateContent != null) {
                if (!Directory.Exists(@"File\Temp")) {
                    Directory.CreateDirectory(@"File\Temp");
                }
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"File\Temp\{0}.repx", template.Id));
                FileHelper.Delete(path);
                File.WriteAllBytes(path, template.TemplateContent);
            }
            return path;
        }

        /// <summary>
        /// 将byte[]转成指定的结构体
        /// </summary>
        /// <typeparam name="StructType">结构体类型</typeparam>
        /// <param name="bytesBuffer">byte数组</param>
        /// <returns></returns> 
        public static StructType ConverBytesToStructure<StructType>(byte[] bytesBuffer) {
            // 检查长度。
            if (bytesBuffer.Length != Marshal.SizeOf(typeof(StructType))) {
                throw new ArgumentException("字节数组与指定结构体字节长度不一致。");
            }

            IntPtr bufferHandler = Marshal.AllocHGlobal(bytesBuffer.Length);
            for (int index = 0; index < bytesBuffer.Length; index++) {
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
        public static bool Start(string fileName) {
            bool isStarted = false;
            try {
                Process proc = Process.Start(fileName);
                if (proc != null) {
                    proc.WaitForExit();
                }
                isStarted = true;
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
            return isStarted;
        }

        /// <summary>
        /// 程序重启
        /// </summary>
        public static void ReStart() {
            System.Diagnostics.ProcessStartInfo cp = new System.Diagnostics.ProcessStartInfo();
            cp.FileName = Application.ExecutablePath;
            cp.UseShellExecute = true;
            System.Diagnostics.Process.Start(cp);
        }
        public static bool tableExport(GridView gvWeight, DataTable dtExport) {
            if (dtExport == null) return false;
            foreach (DataColumn column in dtExport.Columns) {
                column.Caption = "";
            }
            foreach (GridColumn col in gvWeight.Columns) {
                if (dtExport.Columns.Contains(col.FieldName) && col.Visible) dtExport.Columns[col.FieldName].Caption = col.Caption;
            }
            for (int i = dtExport.Columns.Count - 1; i >= 0; i--) {
                if (string.IsNullOrEmpty(dtExport.Columns[i].Caption)) dtExport.Columns.RemoveAt(i);
            }
            SaveFileDialog sfdFileSave = new SaveFileDialog();
            sfdFileSave.Filter = "Excel 文件|*.xls";
            if (sfdFileSave.ShowDialog() == DialogResult.OK) {
                string filePath = sfdFileSave.FileName;
                return NPOIHelper.DataTableToExcel(dtExport, filePath, null);
            }
            return false;
        }
    }
}
