using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using System.Collections;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using System.Data;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using YF.Utility.Log;

namespace YF.MWS.Win
{
    public class PrintUtil
    {
        private static PrintDocument fPrintDocument = new PrintDocument();

        /// <summary>
        /// 获取本机默认打印机名称
        /// </summary>
        /// <returns></returns>
        public static String GetDefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }

        /// <summary>
        /// 获取本地的打印机
        /// </summary>
        /// <returns></returns>
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            try
            {
                fPrinters.Add(GetDefaultPrinter()); //默认打印机始终出现在列表的第一项
                foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
                {
                    if (!fPrinters.Contains(fPrinterName))
                    {
                        fPrinters.Add(fPrinterName);
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            return fPrinters;
        }

        public static void Print(IReportService reportService, DataSet dsReport, SReportTemplate template, Hashtable parameters, string printerName = null)
        {
            string reportFilePath = string.Empty;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                if (!string.IsNullOrEmpty(template.TemplateUrl))
                {
                    reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                }
            }
            else
            {
                SReportTemplate source = reportService.Get(template.Id);
                if (source != null)
                {
                    reportFilePath = Utility.GetReportTemplate(source);
                }
                
            }
            Print(reportFilePath, dsReport, parameters, printerName);
        }

        public static void PrintWeightReport(string viewId, string weightId, DocumentType type, IReportService reportService, Hashtable parameters, string printerName = null) 
        {
            DataSet dsReport = new DataSet();
            SReportTemplate template = reportService.GetDefaultTemplate(type);
            dsReport = reportService.GetWeight(viewId, weightId);
            string reportFilePath = string.Empty;
            if (type == DocumentType.ReWeight) 
            {
                if (template == null || template.Id == null || template.Id.Length == 0)
                {
                    template = reportService.GetDefaultTemplate(DocumentType.Weight);
                }
            }
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    if (!string.IsNullOrEmpty(template.TemplateUrl))
                    {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                }
                else
                {
                    SReportTemplate templateFind = reportService.Get(template.Id);
                    reportFilePath = Utility.GetReportTemplate(templateFind);
                }
            }
            else
            {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            Print(reportFilePath, dsReport, parameters,printerName);
        }
        public static void PrintWeightReportPdf(string viewId, BWeight weight, IReportService reportService, Hashtable parameters, string printerName = null) {
            DataSet dsReport = new DataSet();
            SReportTemplate template = reportService.GetDefaultTemplate(DocumentType.Weight);
            dsReport = reportService.GetWeight(viewId, weight.Id);
            string reportFilePath = string.Empty;
            if (template != null) {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                    if (!string.IsNullOrEmpty(template.TemplateUrl)) {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                } else {
                    SReportTemplate templateFind = reportService.Get(template.Id);
                    reportFilePath = Utility.GetReportTemplate(templateFind);
                }
            } else {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            PrintPdf(reportFilePath, dsReport, parameters, weight, printerName);
        }

        public static void PrintWeightReport(string viewId, string weightId, DocumentType type, IReportService reportService, Hashtable parameters,int printCount, string printerName = null)
        {
            DataSet dsReport = reportService.GetWeight(viewId, weightId);
            SReportTemplate template = reportService.GetDefaultTemplate(type);
            string reportFilePath = string.Empty;
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    if (!string.IsNullOrEmpty(template.TemplateUrl))
                    {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                }
                else
                {
                    SReportTemplate templateFind = reportService.Get(template.Id);
                    reportFilePath = Utility.GetReportTemplate(templateFind);
                }
            }
            else
            {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            Print(reportFilePath, dsReport, parameters, printerName);
        }

        public static void PrintWeightReportWithTemplate(string viewId, string weightId, string templateId, IReportService reportService, Hashtable parameters, string printerName = null)
        {
            DataSet dsReport = new DataSet();
            SReportTemplate template = reportService.Get(templateId);
            if (template == null || template.Id == null || template.Id.Length == 0)
            {
                return;
            }
            dsReport = reportService.GetWeight(viewId, weightId);
            string reportFilePath = string.Empty;
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    if (!string.IsNullOrEmpty(template.TemplateUrl))
                    {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                }
                else
                {
                    reportFilePath = Utility.GetReportTemplate(template);
                }
            }
            else
            {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            Print(reportFilePath, dsReport, parameters, printerName);
        }

        public static void PrintWeightReport(string viewId, string weightId, string qcNo, DocumentType type, IReportService reportService, Hashtable parameters, int printCount, string printerName = null)
        {
            DataSet dsReport = new DataSet();
            SReportTemplate template = null;
            if (printCount > 0)
            {
                template = reportService.GetDefaultTemplate(DocumentType.ReWeight);
            }
            if (template == null || template.Id == null || template.Id.Length == 0)
            {
                template = reportService.GetDefaultTemplate(DocumentType.Weight);
            }
            dsReport = reportService.GetWeight(viewId, weightId);
            string reportFilePath = string.Empty;
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    if (!string.IsNullOrEmpty(template.TemplateUrl))
                    {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                }
                else
                {
                    SReportTemplate templateFind = reportService.Get(template.Id);
                    reportFilePath = Utility.GetReportTemplate(templateFind);
                }
            }
            else
            {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            Print(reportFilePath, dsReport, parameters, printerName);
        }

        public static void Print(string reportFilePath, object dataSource, Hashtable parameters,string printerName=null) 
        {
            XtraReport report = new XtraReport();
            try
            {
                if (System.IO.File.Exists(reportFilePath))
                    report.LoadLayout(reportFilePath);
                report.DataSource = dataSource;
                report.Parameters.Clear();
                if (parameters != null)
                {
                    foreach (string k in parameters.Keys)
                    {
                        var par = new DevExpress.XtraReports.Parameters.Parameter();
                        par.Name = k;
                        par.Value = parameters[k];
                        par.Visible = true;
                        report.Parameters.Add(par);
                    }
                }
                report.ShowPrintMarginsWarning = false;
                report.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                if (printerName != null && !string.IsNullOrEmpty(printerName))
                {
                    report.PrinterName = printerName;
                }
                report.CreateDocument(true);
                report.Print();
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally 
            {
                if (report != null)
                {
                    report.Dispose();
                    report = null;
                }
            }
        }
        public static void PrintPdf(string reportFilePath, object dataSource, Hashtable parameters, BWeight weight,string printerName=null) 
        {
            XtraReport report = new XtraReport();
            try
            {
                if (System.IO.File.Exists(reportFilePath))
                    report.LoadLayout(reportFilePath);
                report.DataSource = dataSource;
                report.Parameters.Clear();
                if (parameters != null)
                {
                    foreach (string k in parameters.Keys)
                    {
                        var par = new DevExpress.XtraReports.Parameters.Parameter();
                        par.Name = k;
                        par.Value = parameters[k];
                        par.Visible = true;
                        report.Parameters.Add(par);
                    }
                }
                report.ShowPrintMarginsWarning = false;
                report.ReportUnit = ReportUnit.TenthsOfAMillimeter;
                if (printerName != null && !string.IsNullOrEmpty(printerName))
                {
                    report.PrinterName = printerName;
                }
                report.CreateDocument(true);
                string path = string.Format("File/Weight/{0}", DateTime.Now.ToString("yyyyMM"));
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                    report.ExportToPdf(string.Format("{0}/{1}.pdf",path,weight.WeightNo));
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
            finally 
            {
                if (report != null)
                {
                    report.Dispose();
                    report = null;
                }
            }
        }

        /// <summary>
        /// 调用win api将指定名称的打印机设置为默认打印机
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name);
    }
}
