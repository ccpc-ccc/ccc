using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmSumReportTemplate : DevExpress.XtraEditors.XtraForm
    {
        private static IReportService reportService = new ReportService();
        private IWeightService weightService = new WeightService();
        private IMasterService masterService = new MasterService();
        private IStatementService statementService = new StatementService();
        private XRDesignMdiController mdiController;
        private static SReportTemplate template = null;
        private string weightId = string.Empty;
        private string customerId = string.Empty;
        private string viewId = string.Empty;
        private XtraReport report = new XtraReport();
        public DataSet DataSource;
        public static string ReportFilePath;
        public Hashtable Parameters { get; set; }
        public string DisplayName { get; set; }
        private string currentTemplateId = string.Empty;

        public FrmSumReportTemplate()
        {
            InitializeComponent();
        }

        private void btnItemModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            using (FrmTemplateDetail frmEdit = new FrmTemplateDetail())
            {
                frmEdit.TemplateId = template.Id;
                /*if (tlReport.FocusedNode != null)
                {
                    frmEdit.TemplateId = tlReport.FocusedNode["TemplateId"].ToString();
                    frmEdit.ParentId = tlReport.FocusedNode["ParentId"].ToObjectString();
                }*/
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void barItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmTemplateDetail formDetail = new FrmTemplateDetail()) 
            {
                if (formDetail.ShowDialog() == DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void FrmSumReportTemplate_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<QReportTemplate> lstReport = new List<QReportTemplate>();
            lstReport = reportService.GetTemplateList(TemplateType.Report);
            gcReportList.DataSource = lstReport; 
            BWeight weight = weightService.GetLastWeight();
            viewId = CurrentClient.Instance.ViewId;
            if (weight != null)
            {
                weightId = weight.Id;
                customerId = weight.CustomerId;
            }
        }

        private void barItemAddSub_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmTemplateDetail frmEdit = new FrmTemplateDetail())
            {
                /*if (tlReport.FocusedNode != null)
                {
                    frmEdit.ParentId = tlReport.FocusedNode["TemplateId"].ToObjectString();
                }*/
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private Hashtable GetParameter()
        {
            Hashtable hash = new Hashtable();
            hash.Add("开始时间", DateTime.Now);
            hash.Add("结束时间", DateTime.Now);
            hash.Add("报表日期", DateTime.Now);
            return hash;
        }

        private void SetDataSource(SummaryReportType type,string subReportType) 
        {
            switch (type) 
            {
                case SummaryReportType.Weight:
                    WeightSubReportType subType = subReportType.ToEnum<WeightSubReportType>();
                    DataSource = reportService.GetWeight(viewId, weightId);
                    DataTable dt = masterService.GetCustomerTable(customerId);
                    if (dt != null)
                    {
                        DataSource.Tables.Add(dt);
                        if (DataSource.Tables.Count > 1)
                        {
                            DataSource.Tables[1].TableName = "供货商";
                        }
                    }    
                    if (subType != WeightSubReportType.Weight) 
                    {
                        DataSource.Tables.Clear();
                        dt = statementService.GetWeightDesignDataSource(subType);
                        DataSource.Tables.Add(dt);
                    }
                    break;
                case SummaryReportType.Charge:
                    DataSource = statementService.GetSummaryDesignResource(type);
                    break;
                case SummaryReportType.Recharge:
                    DataSource = statementService.GetSummaryDesignResource(type);
                    break;
            }
        }

        private void barItemDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            template = (SReportTemplate)gvReportList.GetFocusedRow();
            DisplayName = template.TemplateName; 

            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
            }
            else
            {
                template = reportService.Get(template.Id);
                currentTemplateId = template.Id;
                ReportFilePath = Utility.GetReportTemplate(template);
            }
            SummaryReportType type = template.ReportType.ToEnum<SummaryReportType>();
            SetDataSource(type,template.SubReportType);
            
            BindReport();
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;

            // Handle the DesignPanelLoaded event of the MDI controller,
            // to override the SaveCommandHandler for every loaded report.
            mdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

            // Open an empty report in the form.
            mdiController.OpenReport(report);

            // Show the form.
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null)
            {
                mdiController.ActiveDesignPanel.CloseReport();
            }
        }

        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            mdiController.AddCommandHandler(new SaveCommandHandler(panel));
        }

        public class SaveCommandHandler : ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs ||
                    command == ReportCommand.Closing);
                return !useNextHandler;
            }

            void Save()
            {
                try
                {
                    // Prevent the "Report has been changed" dialog from being shown.
                    panel.ReportState = ReportState.Saved;

                    // For instance:
                    panel.Report.SaveLayout(ReportFilePath);

                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver && template != null)
                    {
                        template.TemplateContent = File.ReadAllBytes(ReportFilePath);
                        reportService.Save(template);
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }

            #region ICommandHandler 成员

            public bool CanHandleCommand(ReportCommand command)
            {
                if (command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs || command == ReportCommand.Closing)
                {
                    return true;
                }
                return false;
            }

            public void HandleCommand(ReportCommand command, object[] args, ref bool handled)
            {
                Save();
            }

            #endregion
        }

        private void gvReportList_DoubleClick(object sender, EventArgs e)
        {
            if (gvReportList.GetFocusedRow() != null)
            {
                SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
                if (template == null)
                {
                    return;
                }
                DisplayName = template.TemplateName;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                }
                else
                {
                    template = reportService.Get(template.Id);
                    currentTemplateId = template.Id;
                    ReportFilePath = Utility.GetReportTemplate(template);
                }
                SummaryReportType type = template.ReportType.ToEnum<SummaryReportType>();
                SetDataSource(type, template.SubReportType);
                BindReport();
            }
        }

        private void BindReport()
        {
            if (System.IO.File.Exists(ReportFilePath))
            {
                this.report.LoadLayout(ReportFilePath);
                this.report.DisplayName = Path.GetFileName(ReportFilePath);
            }
            if (DataSource != null && DataSource.Tables.Count > 0) 
            {
                this.report.DataMember = DataSource.Tables[0].TableName;
            }
            this.report.DataSource = this.DataSource;
            this.report.Parameters.Clear();
            Parameters = GetParameter();
            if (this.Parameters != null)
            {
                foreach (string k in this.Parameters.Keys)
                {
                    var par = new DevExpress.XtraReports.Parameters.Parameter();
                    par.Name = k;
                    par.Value = this.Parameters[k];
                    par.Visible = false;
                    par.Type = typeof(DateTime);
                    this.report.Parameters.Add(par);
                }
            }
            this.report.ShowPrintMarginsWarning = false;
            pcReport.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(true);
        }

        private void gvReportList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvReportList.GetFocusedRow() != null)
            {
                SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
                if (template == null)
                {
                    return;
                }
                DisplayName = template.TemplateName;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                }
                else
                {
                    template = reportService.Get(template.Id);
                    currentTemplateId = template.Id;
                    ReportFilePath = Utility.GetReportTemplate(template);
                }
                SummaryReportType type = template.ReportType.ToEnum<SummaryReportType>();
                SetDataSource(type, template.SubReportType);
                BindReport();
            }
        }

        private void barItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            if (template != null)
            {
                string message = string.Format(@"确实要删除所选磅单({0})吗?{1}此删除不可恢复,请慎重操作.", template.TemplateName, Environment.NewLine);
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
                {
                    reportService.Delete(template.Id);
                    BindData();
                }
            }
        }

        private void barItemViewData_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() != null)
            {
                SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
                if (template == null)
                {
                    return;
                }
                SummaryReportType type = template.ReportType.ToEnum<SummaryReportType>();
                FrmViewCustomDataSource frmView = new FrmViewCustomDataSource();
                frmView.ReportType = type;
                if (type != SummaryReportType.Custom)
                {
                    SetDataSource(type, template.SubReportType);
                    frmView.DataSource = DataSource;
                }
                else 
                {
                    frmView.Template = template;
                }
                frmView.ShowDialog();
            }
        }
         
    }
}