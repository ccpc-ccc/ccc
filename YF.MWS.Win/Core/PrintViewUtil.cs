using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.View.Report;

namespace YF.MWS.Win.Core
{
    public class PrintViewUtil
    {
        public static void PreviewDocument(IReportService reportService,DataSet dsReport, SReportTemplate template, string displayName, Hashtable parameters)
        {
            FrmXReport frmReport = new FrmXReport();
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    if (!string.IsNullOrEmpty(template.TemplateUrl))
                    {
                        frmReport.ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                    }
                }
                else
                {
                    SReportTemplate source = reportService.Get(template.Id);
                    if (source != null)
                    {
                        frmReport.ReportFilePath = Utility.GetReportTemplate(source);
                    }
                }
            }
            else
            {
                frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
            }
            frmReport.Parameters = parameters;
            frmReport.DataSource = dsReport;
            frmReport.DisplayName = displayName;
            frmReport.Text = displayName;
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.StartPosition = FormStartPosition.CenterScreen;
            frmReport.ShowDialog();
        }
    }
}
