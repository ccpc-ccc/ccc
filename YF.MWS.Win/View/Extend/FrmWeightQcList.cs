using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.View.Report;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraReports.UserDesigner;
using YF.MWS.CacheService;

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmWeightQcList : DevExpress.XtraEditors.XtraForm
    {
        private IWeightService weightService = new WeightService();
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IWeightQcService weightQcService = new WeightQcService();
        private GridCheckMarksSelection chkWeight;
        private XRDesignMdiController mdiController;
        private DataTable dtWeightQc = new DataTable();
        private List<SCode> lstCode = new List<SCode>();
        public static string ReportFilePath;
        private XtraReport report = new XtraReport();
        public FrmWeightQcList()
        {
            InitializeComponent();
            ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptWeightQc.repx";
        } 

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Export()
        {
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdFileSave.FileName;
                gvWeightQc.ExportToXls(filePath);
            }
        }

        public void InitWeightDate()
        {
            teEndDate.Time = DateTime.Now;
            teStartDate.Time = DateTime.Now;
        }

        public void LoadData()
        {
            dtWeightQc = weightQueryService.GetQcList(teStartDate.Time, teEndDate.Time, combFinishState.SelectedIndex);
            gcWeightQc.DataSource = dtWeightQc;
            gcWeightQc.RefreshDataSource();
            gvWeightQc.OptionsView.ColumnAutoWidth = false;
            gvWeightQc.BestFitColumns();
            gvWeightQc.Columns[0].Visible = false;
            gvWeightQc.Columns[1].Visible = false;
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeightQc);
            chkWeight.ClearSelection();

        }

        private void FrmWeightQcList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                teEndDate.Time = DateTime.Now;
                teStartDate.Time = DateTime.Now;
                LoadData();
                lstCode = MasterCacher.GetSubCodeList(SysCode.MeasureType.ToString());
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void barItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmWeightQc frmQc = new FrmWeightQc())
            { 
                frmQc.ShowDialog();
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Edit();
        }

        private void barItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeightQc.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeightQc.GetFocusedDataRow();
                string qcId = dr["QcId"].ToObjectString();
                string weightId = dr["WeightId"].ToObjectString();
                if (string.IsNullOrEmpty(qcId)) 
                {
                    MessageDxUtil.ShowWarning("请先完善质量检测单再打印.");
                    return;
                }
                DataSet dsReport = new DataSet();
                dsReport = weightQcService.GetReport(weightId,qcId);
                FrmXReport frmReport = new FrmXReport();
                frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptWeightQc.repx";
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "质检报告";
                frmReport.Text = "质检报告";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
                weightService.UpdatePrint(dr["WeightId"].ToObjectString());
            } 
        }

        private void gvWeightQc_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit() 
        {
            if (gvWeightQc.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeightQc.GetFocusedDataRow();
                using (FrmWeightQc frmQc = new FrmWeightQc())
                {
                    frmQc.WeightId = dr["WeightId"].ToObjectString();
                    frmQc.RecId = dr["QcId"].ToObjectString();
                    if (frmQc.ShowDialog() == DialogResult.OK) 
                    {
                        LoadData();
                    }
                }
            } 
        }

        private void gvWeightQc_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MeasureType") 
            {
                SCode code = lstCode.Find(c => c.ItemCode == e.Value.ToObjectString());
                if (code != null) 
                {
                    e.DisplayText = code.ItemCaption;
                }
            }
        }

        private void barItemDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
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

        private void BindReport()
        {
            string qcId = string.Empty;
            string weightId = string.Empty;
            if (gvWeightQc.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeightQc.GetFocusedDataRow();
                qcId = dr["QcId"].ToObjectString();
                weightId = dr["WeightId"].ToObjectString();
            }

            if (System.IO.File.Exists(ReportFilePath))
            {
                this.report.LoadLayout(ReportFilePath);
                this.report.DisplayName = Path.GetFileName(ReportFilePath);
            }
            else 
            {
                MessageDxUtil.ShowWarning("质检报告模板文件不存在,请联系软件供应商.");
                return;
            }
            DataSet dsReport = new DataSet();
            dsReport = weightQcService.GetReport(weightId,qcId);
            this.report.DataSource = dsReport;
            this.report.ShowPrintMarginsWarning = false;
            report.CreateDocument(true);
        }
    }
}