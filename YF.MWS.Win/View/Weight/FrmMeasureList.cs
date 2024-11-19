using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
using YF.Utility.Data;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmMeasureList : DevExpress.XtraEditors.XtraForm
    {
        private IWeightService weightService = new WeightService();
        private IWeightViewService viewService = new WeightViewService();
        private IWeightExtService weightExtService = new WeightExtService();
        private IReportService reportService = new ReportService();
        private GridCheckMarksSelection chkWeight;
        private XtraReport report = new XtraReport();
        private XRDesignMdiController mdiController;
        private DataTable dtWeight = new DataTable();
        private string viewId;
        public static string ReportFilePath;
        public FrmMeasureList()
        {
            InitializeComponent();
            ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptMeasure.repx";
        }

        private void FrmMeasureList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                teEndDate.Time = DateTime.Now;
                teStartDate.Time = DateTime.Now;
                LoadData();
            }
        }

        private void LoadData()
        {
            SWeightView view = viewService.GetDefaultView(ViewType.Measure);
            if (view != null) 
            {
                viewId = view.Id;
            }
            dtWeight = weightExtService.GetAddList(teStartDate.Time, teEndDate.Time,OrderSource.Measure,viewId);
            gcWeight.DataSource = dtWeight;
            gcWeight.RefreshDataSource();
            gvWeight.OptionsView.ColumnAutoWidth = false;
            gvWeight.BestFitColumns();
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();
        }

        private void barItemDelete_ItemClick(object sender,  ItemClickEventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要删除的磅单");
            }
            else
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实需要删除该磅单吗?此删除不可撤销,请谨慎操作.") == DialogResult.Yes)
                {
                    string weightId = gvWeight.GetFocusedRowCellValue("WeightId").ToString();
                    DataRow row = gvWeight.GetFocusedDataRow();
                    BWeight weight =TableHelper.RowToEntity<BWeight>(row);
                    bool isDeleted = weightService.DeleteWeight(weight);
                    if (isDeleted)
                    {
                        MessageDxUtil.ShowTips("该磅单已经成功删除.");
                        LoadData();
                    }
                }
            }
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmMeasure frmMeasure = new FrmMeasure())
            {
                if (frmMeasure.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfdFileSave.FileName;
                gvWeight.ExportToXls(filePath);
            }
        }

        private void barItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                DataSet dsReport = new DataSet(); 
                dsReport = reportService.GetWeight(viewId,1, dr["WeightId"].ToObjectString());
                FrmXReport frmReport = new FrmXReport();
                frmReport.ReportFilePath = ReportFilePath;
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "磅单报表";
                frmReport.Text = "磅单报表";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
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
            if (gvWeight.GetFocusedDataRow() != null)
            {
                DataRow dr = gvWeight.GetFocusedDataRow(); 
                weightId = dr["WeightId"].ToObjectString();
            }

            if (System.IO.File.Exists(ReportFilePath))
            {
                this.report.LoadLayout(ReportFilePath);
                this.report.DisplayName = Path.GetFileName(ReportFilePath);
            }
            else
            {
                MessageDxUtil.ShowWarning("磅单模板文件不存在,请联系软件供应商.");
                return;
            }
            DataSet dsReport = new DataSet();
            dsReport = reportService.GetWeight(viewId, 1, weightId);
            this.report.DataSource = dsReport;
            this.report.ShowPrintMarginsWarning = false;
            report.CreateDocument(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void barItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvWeight.GetFocusedDataRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择计量方.");
            }
            else
            {
                DataRow dr = gvWeight.GetFocusedDataRow();
                using (FrmMeasure frmMeasure = new FrmMeasure())
                {
                    frmMeasure.RecId = dr["WeightId"].ToObjectString();
                    if (frmMeasure.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}