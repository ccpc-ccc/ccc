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
using System.Drawing;
using YF.Utility;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.Win
{
    public class PrintUtil
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        private static Hashtable parameters = new Hashtable {
                        { "当前时间", DateTime.Now
    }
};
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

        public static void PrintWeightReport(string viewId, string weightId, IReportService reportService, string printerName = null) {
            DataSet dsReport = new DataSet();
            SReportTemplate template = reportService.GetDefaultTemplate(DocumentType.Weight);
            dsReport = reportService.GetWeight(viewId, weightId);
            string reportFilePath = string.Empty;
            if (template != null) {
                    if (!string.IsNullOrEmpty(template.TemplateUrl)) {
                        reportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
            } else {
                reportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            Print(reportFilePath, dsReport, parameters, printerName);
        }

        public static void PrintWeightReportWithTemplate(string viewId, string weightId, string templateId, IReportService reportService, string printerName = null)
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
        public static void Print(List<VWeight> bWeights,int num) {
            PrintDocument printDocument = new PrintDocument();
            BWeights = bWeights;
            printDocument.PrintPage += new PrintPageEventHandler((object sender, PrintPageEventArgs e) => {
            int y = 10;
            int w = e.PageSettings.PaperSize.Height / 3;
            page1(e.Graphics, y);
            page2(e.Graphics,y+w);
            if(num==3) page3(e.Graphics,y+w*2);
            });
            printDocument.Print();
        }
        private static List<VWeight> BWeights { get; set; }
        private static void page1(Graphics e,int y) {
            int x = 10;
            int y1 = y;
            Font printFont = new Font("Arial", 18);
            centerMiddle(e, x, y, 500, 20, printFont, "計量伝票");
            y += 30;
            printFont = new Font("Arial", 12, FontStyle.Underline);
            e.DrawString("       山本     样", printFont, Brushes.Black, x, y);
            y += 20;
            printFont = new Font("Arial", 12, FontStyle.Regular);
            drawTable(e, x, y, printFont, new testRow[]{
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=100,text="日付"},
                        new testCell(){w=100, text="伝票No" },
                        new testCell(){ w=100, text="車両No" },
                        new testCell(){ w=90, text="時刻" },
                        new testCell(){ w=100, text="入力者" }
                }
                },
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=100,text=DateTime.Now.ToString("yyyy-MM-dd")},
                        new testCell(){w=100, text=BWeights[0].WaybillNo },
                        new testCell(){ w=100, text=BWeights[0].CarId },
                        new testCell(){ w=90, text=DateTime.Now.ToString("HH:mm") },
                        new testCell(){ w=100, text=BWeights[0].WeighterName }
                }
                }
            });
            y += 80;
            List<testRow> tRows = new List<testRow>();
            tRows.Add(new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=130,text="商品名"},
                        new testCell(){w=90, text="総重量" },
                        new testCell(){ w=90, text="空車重量" },
                        new testCell(){ w=90, text="ダスト引" },
                        new testCell(){ w=90, text="重量引" },
                        new testCell(){ w=90, text="正味重量" },
                        new testCell(){ w=90, text="単価(内税)" },
                        new testCell(){ w=90, text="金額" }
                }
                });
            decimal totalMoney = 0;
            decimal totalWeight = 0;
            for(int i = 0; i < 5; i++) {
                if (BWeights.Count > i) {
            tRows.Add(new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=130,text=BWeights[i].MaterialName},
                        new testCell(){w=90, text=BWeights[i].GrossWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].TareWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].d1.ToString() },
                        new testCell(){ w=90, text=BWeights[i].ImpurityWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].NetWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].UnitPrice.ToString() },
                        new testCell(){ w=90, text=BWeights[i].UnitMoney.ToString() }
                }
                });
                    totalMoney += BWeights[i].UnitMoney;
                    totalWeight += BWeights[i].NetWeight;
                } else {
            tRows.Add(new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=130,text=""},
                        new testCell(){w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" }
                }
                });

                }
            }
            drawTable(e, x, y, printFont, tRows.ToArray());
            y += 180;
            drawRow(e, x, y,60, printFont, new testCell[] {
                new testCell(){w=400,text="" },
                new testCell(){w=180,text="" },
                new testCell(){w=180,text="" }
            });
            e.DrawString("【備考】", printFont, Brushes.Black, x + 10, y + 5);
            e.DrawString("重量計", printFont, Brushes.Black, x +400+ 10, y + 5);
            e.DrawString("金額計", printFont, Brushes.Black, x +400+180+ 10, y + 5);
            rightMiddle(e, x +400+180- 10, y + 5,180,20, printFont, $"￥{totalMoney.ToString("0.##")}");
            rightMiddle(e, x +400- 10, y + 35,180,20, printFont, $"{totalWeight.ToString("0.##")}");
            x = 500;
            e.DrawString(CfgUtil.GetCfg().Print.rightTitle, printFont, Brushes.Black, x, y1 + 5);

        }
        private static void page2(Graphics e,int y) {
            int x = 10;
            int y1 = y;
            Font printFont = new Font("Arial", 18);
            centerMiddle(e, x, y, 500, 20, printFont, "仕入伝票");
            y += 30;
            printFont = new Font("Arial", 12, FontStyle.Underline);
            e.DrawString("       山本     样", printFont, Brushes.Black, x, y);
            y += 20;
            printFont = new Font("Arial", 12, FontStyle.Regular);
            drawTable(e, x, y, printFont, new testRow[]{
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=100,text="日付"},
                        new testCell(){w=100, text="伝票No" },
                        new testCell(){ w=100, text="車両No" },
                        new testCell(){ w=90, text="時刻" },
                        new testCell(){ w=100, text="入力者" }
                }
                },
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=100,text=DateTime.Now.ToString("yyyy-MM-dd")},
                        new testCell(){w=100, text=BWeights[0].WaybillNo },
                        new testCell(){ w=100, text=BWeights[0].CarId },
                        new testCell(){ w=90, text=DateTime.Now.ToString("HH:mm") },
                        new testCell(){ w=100, text=BWeights[0].WeighterName }
                }
                }
            });
            y += 80;
            List<testRow> tRows = new List<testRow>();
            tRows.Add(new testRow() {
                h = 30,
                cells = new testCell[] {
                        new testCell(){w=130,text="商品名"},
                        new testCell(){w=90, text="総重量" },
                        new testCell(){ w=90, text="空車重量" },
                        new testCell(){ w=90, text="ダスト引" },
                        new testCell(){ w=90, text="重量引" },
                        new testCell(){ w=90, text="正味重量" },
                        new testCell(){ w=90, text="単価(内税)" },
                        new testCell(){ w=90, text="金額" }
                }
            });
            decimal totalMoney = 0;
            decimal totalWeight = 0;
            for (int i = 0; i < 5; i++) {
                if (BWeights.Count > i) {
                    tRows.Add(new testRow() {
                        h = 30,
                        cells = new testCell[] {
                        new testCell(){w=130,text=BWeights[i].MaterialName},
                        new testCell(){w=90, text=BWeights[i].GrossWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].TareWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].d1.ToString() },
                        new testCell(){ w=90, text=BWeights[i].ImpurityWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].NetWeight.ToString() },
                        new testCell(){ w=90, text=BWeights[i].UnitPrice.ToString() },
                        new testCell(){ w=90, text=BWeights[i].UnitMoney.ToString() }
                }
                    });
                    totalMoney += BWeights[i].UnitMoney;
                    totalWeight+= BWeights[i].NetWeight;
                } else {
                    tRows.Add(new testRow() {
                        h = 30,
                        cells = new testCell[] {
                        new testCell(){w=130,text=""},
                        new testCell(){w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" },
                        new testCell(){ w=90, text="" }
                }
                    });

                }
            }
            drawTable(e, x, y, printFont, tRows.ToArray());
            y += 180;
            drawRow(e, x, y, 60, printFont, new testCell[] {
                new testCell(){w=400,text="" },
                new testCell(){w=180,text="" },
                new testCell(){w=180,text="" }
            });
            e.DrawString("【備考】", printFont, Brushes.Black, x + 10, y + 5);
            e.DrawString("重量計", printFont, Brushes.Black, x + 400 + 10, y + 5);
            e.DrawString("金額計", printFont, Brushes.Black, x + 400 + 180 + 10, y + 5);
            rightMiddle(e, x + 400 + 180 - 10, y + 5, 180, 20, printFont, $"￥{totalMoney.ToString("0.##")}");
            rightMiddle(e, x + 400 - 10, y + 35, 180, 20, printFont, $"{totalWeight.ToString("0.##")}");
            x = 500;
            e.DrawString(CfgUtil.GetCfg().Print.rightTitle, printFont, Brushes.Black, x, y1 + 5);

        }
        private static void page3(Graphics e,int y) {
            int x = 10;
            decimal totalMoney = 0;
            foreach (VWeight weight in BWeights) {
                totalMoney += weight.UnitMoney;
            }
            Font printFont = new Font("Arial", 18);
            centerMiddle(e, x, y, 800, 20, printFont, "領 収 書");
            y += 30;
            printFont = new Font("Arial", 12, FontStyle.Underline);
            e.DrawString("       山本     样", printFont, Brushes.Black, x, y);
            rightMiddle(e,500,y,280,20,printFont,$"No.{BWeights[0].WaybillNo}");
            y += 20;
            Brush brush = Brushes.SlateGray;
            e.FillRectangle(brush, new Rectangle(x,y,800,80));
            printFont = new Font("Arial", 18, FontStyle.Regular);
            centerMiddle(e, x, y, 700, 80, printFont, $"￥{totalMoney} -");
            printFont = new Font("Arial", 12, FontStyle.Regular);
            y += 80;
            y += 20;
            centerMiddle(e, x, y, 700, 20, printFont, "但 スクラップ商品代として  上記正に領収いたしました。");
            y += 20;
            x = 300;
            int y1 = y;
            drawTable(e, x, y, printFont, new testRow[]{
                new testRow(){
                    h=100,
                    cells=new testCell[] {
                        new testCell(){w=500,text=""}
                }
                },
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=500,text=""}
                }
                },
                new testRow(){
                    h=30,
                    cells=new testCell[] {
                        new testCell(){w=500,text=""}
                }
                }
            });
            rightMiddle(e,x,y,480,30,printFont,DateTime.Now.ToString("yyyy年MM月dd日"));
            y1 += 40;
            e.DrawString("会社名(屋号)", printFont,Brushes.Black,x+10,y1);
            y1 += 30;
            e.DrawString("氏名", printFont,Brushes.Black,x+10,y1);
            y1 += 35;
            e.DrawString("電話", printFont,Brushes.Black,x+10,y1);
            y1 += 30;
            e.DrawString("住所", printFont,Brushes.Black,x+10,y1);
        }
        private static void centerMiddle(Graphics e,int x,int y,int w,int h,Font font,string text) {
            SizeF textSize = e.MeasureString(text, font);
            x += ((w -textSize.Width) / 2).ToInt();
            y += ((h - textSize.Height) / 2).ToInt();
            e.DrawString(text, font, Brushes.Black, x, y);
        }
        private static void rightMiddle(Graphics e,int x,int y,int w,int h,Font font,string text) {
            SizeF textSize = e.MeasureString(text, font);
            x += (w -textSize.Width).ToInt();
            y += ((h - textSize.Height) / 2).ToInt();
            e.DrawString(text, font, Brushes.Black, x, y);
        }
        private static void drawCell(Graphics e, int x, int y, int w, int h, Font font, string text) {
            Pen pen = new Pen(Color.FromArgb(255, 5, 5, 5));
            pen.Width = 1;
            Point[] points = new Point[] {
new Point(x,y),
new Point(x+w, y),
new Point(x+w, y+h),
new Point(x, y+h),
new Point(x, y)
            };
            e.DrawLines(pen, points);
            centerMiddle(e, x, y, w, h, font, text);
        }
        private static void drawRow(Graphics e, int x, int y, int h, Font font, testCell[] tCells) {
            int x1 = x;
            foreach (testCell tCell in tCells) {
                drawCell(e, x1, y, tCell.w, h, font, tCell.text);
                x1 += tCell.w;
            }
        }
        private static void drawTable(Graphics e, int x, int y, Font font, testRow[] tCells) {
            int y1 = y;
            foreach (testRow tRow in tCells) {
            drawRow(e,x,y,tRow.h,font, tRow.cells);
                y += tRow.h;
            }
        }
    }
    public class testCell {
        public int w;
            public string text;
    }
    public class testRow {
        public int h;
        public testCell[] cells;
    }
    public class testColumn {
        public int w;
        public string Caption;
        public string Value;
    }
}
