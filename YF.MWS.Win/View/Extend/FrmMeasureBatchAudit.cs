using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Win.View.Report;
using YF.MWS.BaseMetadata;
using System.IO;
using YF.MWS.Metadata;
using YF.Utility;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Log;
using YF.MWS.Win.Uc;
using DevExpress.XtraGrid.Columns;
using YF.Utility.Configuration; 

namespace YF.MWS.Win.View.Extend
{
    public partial class FrmMeasureBatchAudit : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtSource;
        private IWeightQueryService weightQueryService = new WeightQueryService();
        private IWeightViewService viewService = new WeightViewService();
        private IReportService reportService = new ReportService();
        private IWeightExtService weightExtService = new WeightExtService();
        private GridCheckMarksSelection chkWeight;
        private List<string> lstWeightId = new List<string>();
        private string viewId = string.Empty;
        public List<string> LstWeightId
        {
            get { return lstWeightId; }
            set { lstWeightId = value; }
        }
        public FrmMeasureBatchAudit()
        {
            InitializeComponent();
        }

        private void FrmMeasureBatchAudit_Load(object sender, EventArgs e)
        {
            BindData();
            SetSummaryField();
        }

        private void SetSummaryField()
        {
            GridColumn col = null;
            string fieldName = string.Empty;
            string[] fields = AppSetting.GetValue("MeasureSummaryField").Split(';');
            string[] fieldsFormat = AppSetting.GetValue("MeasureSummaryFieldFormat").Split(';');
            int length = fields.Length;
            string f;
            for (int i = 0; i < length; i++)
            {
                f = fields[i];
                col = DxHelper.FindColumn(gvWeight, f);
                if (col != null)
                {
                    fieldName = col.FieldName;
                    gvWeight.Columns[fieldName].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                         new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, string.Format("{0}",fieldsFormat[i]))});
                    //gvWeight.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, fieldName, col, "{0:f2}");
                }
            } 
        }

        private void BindData()
        {
            SWeightView view = viewService.GetDefaultView(ViewType.Measure);
            if (view != null)
            {
                viewId = view.Id;
            }
            dtSource = weightQueryService.GetFinanceList(lstWeightId, viewId);
            gcWeight.DataSource = dtSource;
            gcWeight.RefreshDataSource();
            gvWeight.OptionsView.ColumnAutoWidth = false;
            gvWeight.BestFitColumns();
            gvWeight.Columns[0].Visible = false;
            gvWeight.Columns[1].Visible = false;
            if (chkWeight == null)
                chkWeight = new GridCheckMarksSelection(gvWeight);
            chkWeight.ClearSelection();

        }

        private void barItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barItemSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Finance))
            {
                Settle(SettleType.Finance);
            }
        }

        private bool ConfirmSettle(SettleType type)
        {
            bool isConfirmed = false;
            string message = string.Empty;
            switch (type)
            {
                case SettleType.Finance:
                    message = "确实要结算财务吗?";
                    break;
                case SettleType.Freight:
                    message = "确实要结算运费吗?";
                    break;
                case SettleType.Payment:
                    message = "确实要结算货款吗?";
                    break;
            }
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
            {
                isConfirmed = true;
            }
            return isConfirmed;
        }

        private void Settle(SettleType type)
        {
            int state = 1;
            BWeightExt weightExt = null;
            string message = string.Empty;
            switch (type)
            {
                case SettleType.Finance:
                    message = "已经成功结算财务信息.";
                    break;
                case SettleType.Freight:
                    message = "已经成功结算运费信息.";
                    break;
                case SettleType.Payment:
                    message = "已经成功结算货款信息.";
                    break;
            }
            foreach (DataRow dr in dtSource.Rows)
            {
                string recId = dr["WeightId"].ToObjectString();
                weightExt = weightExtService.Get(recId);
                try
                {
                    if (weightExt == null)
                    {
                        weightExt = new BWeightExt();
                        weightExt.Id = recId;
                    }
                    switch (type)
                    {
                        case SettleType.Finance:
                            weightExt.SettleState = state;
                            break;
                        case SettleType.Freight:
                            weightExt.FreightSettleState = state;
                            break;
                        case SettleType.Payment:
                            weightExt.PaymentSettleState = state;
                            break;
                    }
                    weightExtService.Save(weightExt);
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
            MessageDxUtil.ShowTips(message);
            BindData();
        }

        private void barItemFreightSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Freight))
            {
                Settle(SettleType.Freight);
            }
        }

        private void barItemPaymentSettle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmSettle(SettleType.Payment))
            {
                Settle(SettleType.Payment);
            }
        }
    }
}