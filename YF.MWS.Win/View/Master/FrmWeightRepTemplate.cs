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
using YF.MWS.Win.View.Report;
using YF.Utility;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraBars.Localization;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWeightRepTemplate : DevExpress.XtraEditors.XtraForm
    {
        private static IReportService reportService = new ReportService();
        private IWeightService weightService = new WeightService();
        private IWeightQueryService weightQueryService=new WeightQueryService();
        private IStatementService statementService = new StatementService();
        private XRDesignMdiController mdiController;
        private static SReportTemplate template = null;
        private string weightId = string.Empty;
        private string viewId = string.Empty;
        private XtraReport report = new XtraReport();
        private string currentTemplateId = string.Empty;
        public object DataSource;
        public static string ReportFilePath;
        public Hashtable Parameters { get; set; }
        public string DisplayName { get; set; }
        public FrmWeightRepTemplate()
        {
            InitializeComponent();
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
                viewId = template.ViewId;
                DisplayName = template.TemplateName;
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                }
                else 
                {
                    SReportTemplate templateFind = reportService.Get(template.Id);
                    ReportFilePath = Utility.GetReportTemplate(templateFind);
                }
                DocumentType docType = template.ReportType.ToEnum<DocumentType>();
                SetDataSource(docType);
                BindReport();
            }
        }

        private void SetDataSource(DocumentType type) 
        {
            switch (type) 
            {
                case DocumentType.FinanceSettle:
                    DataSource = reportService.GetFinance(viewId, weightId);
                    break;
                case DocumentType.Weight:
                case DocumentType.Measure:
                case DocumentType.ReWeight:
                case DocumentType.TemporaryWeight:
                    DataSource = reportService.GetWeight(viewId, 1);//weightQueryService.GetTopList(new TopWeightQuery() { TopN =1})
                    break;
                case DocumentType.Charge:
                    DataSource = statementService.GetDocumentDesignResource(type);
                    break;
                case DocumentType.Recharge:
                    DataSource = statementService.GetDocumentDesignResource(type);
                    break;
            }
        }

        private void FrmWeightReportList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            this.Parameters=new Hashtable();
            List<QReportTemplate> lstReport = new List<QReportTemplate>();
            List<QReportTemplate> lstReportTemp = new List<QReportTemplate>();
            lstReport = reportService.GetTemplateList(TemplateType.Document);
             
            gcReportList.DataSource = lstReport; 
            BWeight weight=weightService.GetLastWeight();
            if (weight != null)
            {
                weightId = weight.Id;
                //viewId = weight.ViewId;
                viewId = CurrentClient.Instance.ViewId;
            }
            this.Parameters.Add("当前时间",DateTime.Now);
        }

        private void BindReport()
        {
            if (System.IO.File.Exists(ReportFilePath))
            {
                this.report.LoadLayout(ReportFilePath);
                this.report.DisplayName = Path.GetFileName(ReportFilePath);
            }
            this.report.DataSource = this.DataSource;
            this.report.Parameters.Clear();
            if (this.Parameters != null)
            {
                foreach (string k in this.Parameters.Keys)
                {
                    var par = new DevExpress.XtraReports.Parameters.Parameter();
                    par.Name = k;
                    par.Value = this.Parameters[k];
                    par.Visible = false;
                    this.report.Parameters.Add(par);
                }
            }
            this.report.ShowPrintMarginsWarning = false;
            this.report.ReportUnit = ReportUnit.TenthsOfAMillimeter;
            pcReport.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(true); 
        }

        private void btnItemModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            DisplayName = template.TemplateName;
            viewId = template.ViewId;
            ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
            DataSource = reportService.GetWeight(viewId,1, weightId);
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
                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;

                // For instance:
                panel.Report.SaveLayout(ReportFilePath);

                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver && template!=null) 
                {
                    template.TemplateContent = File.ReadAllBytes(ReportFilePath);
                    reportService.Save(template);
                }

            }
        
            #region ICommandHandler 成员

            public bool CanHandleCommand(ReportCommand command)
            {
 	            if(command == ReportCommand.SaveFile ||
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

        private void btnItemSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null) 
            {
                MessageDxUtil.ShowWarning("请选择要设置为默认正式磅单的模板.");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            reportService.SetDefault(template.Id, template.ReportType.ToEnum<DocumentType>());
            BindData();
        }

        private void barItemTempReportSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要设置为默认临时磅单的模板");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            
            reportService.SetDefault(template.Id, DocumentType.TemporaryWeight);
            BindData();
        }

        private void btnItemDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            template = template = (SReportTemplate)gvReportList.GetFocusedRow();
            viewId = template.ViewId;
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
            DocumentType docType = template.ReportType.ToEnum<DocumentType>();
            SetDataSource(docType);
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

        private void barItemModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvReportList.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要修改的磅单");
                return;
            }
            SReportTemplate template = (SReportTemplate)gvReportList.GetFocusedRow();
            if (template != null)
            {
                using (FrmTemplateEdit frmEdit = new FrmTemplateEdit())
                {
                    frmEdit.RecId = template.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK) 
                    {
                        BindData();
                    }
                }
            }
        }

        private void barItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmTemplateEdit frmEdit = new FrmTemplateEdit())
            { 
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
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
    }
}