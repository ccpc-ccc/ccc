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
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.CacheService;
using YF.MWS.Win.Uc;
using YF.MWS.Metadata.Cfg;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Metadata.Event;
using YF.Utility;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmPlanCardList : BaseForm
    {
        private ICardService cardService = new CardService();
        private List<QPlanCard> lstCard = new List<QPlanCard>();
        private DataTable dtCard = new DataTable();
        private GridCheckMarksSelection chkCard;
        private QPage page = null;
        private int pageSize = 25;
        public FrmPlanCardList()
        {
            InitializeComponent();
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmPlanCardEdit frmEdit = new FrmPlanCardEdit()) 
            {
                if (frmEdit.ShowDialog() == DialogResult.OK) 
                {
                    barItemSearch.PerformClick();
                }
            }
        }

        private void FrmCardList_Load(object sender, EventArgs e)
        {
            pageSize = 5000;
            InitControl();
            page.PageIndex = 0;
        }

        private void InitControl()
        {
            chkCard = new GridCheckMarksSelection(gvPlanCard);
            page = new QPage();
            page.PageSize = pageSize;
            ucPage.PageChanged += ucPage_PageChanged;
            ucPage.Page.PageSize = pageSize;
        }

        private void ucPage_PageChanged(object sender, PageChangedEventArgs e)
        {
            page.PageIndex = e.Page.PageIndex;
            Search();
            e.Page.TotalRows = page.TotalRows;
        }

        private PlanCardQuery GetCondition()
        {
            PlanCardQuery query = new PlanCardQuery();
            query.PageIndex = page.PageIndex;
            query.PageSize = page.PageSize;
            query.DeliveryId = weDeliver.CurrentValue.ToObjectString();
            query.ReceiverId = weReceiver.CurrentValue.ToObjectString();
            query.DeptId = weDept.CurrentValue.ToObjectString();
            return query;
        }

        public void Search() 
        {
            PageList<QPlanCard> result = cardService.GetList(GetCondition());
            if (result != null)
            {
                page.TotalRows = result.Total;
                ucPage.Page.TotalRows = page.TotalRows;
                gcPlanCard.DataSource = result.Models;
                gcPlanCard.RefreshDataSource();
            }
            chkCard.ClearSelection();
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvPlanCard.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要编辑的计划卡.");
            }
            else 
            {
                using (FrmPlanCardEdit frmEdit = new FrmPlanCardEdit())
                {
                    QPlanCard card = (QPlanCard)gvPlanCard.GetFocusedRow();
                    frmEdit.RecId = card.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        barItemSearch.PerformClick();
                    }
                }
            }
        }

        private void barItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCard.GetSelectedRow()==null || chkCard.GetSelectedRow().Count == 0) 
            {
                MessageDxUtil.ShowWarning("请选择要删除的计划卡.");
                return;
            }
            string message = "确实要删除所选计划卡吗?\n此操作不可撤销,请慎重操作.";
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
            {
                List<object> lstCard = chkCard.GetSelectedRow();
                List<string> lstCardId = new List<string>();
                foreach (object  obj in lstCard)
                {
                    QPlanCard card = (QPlanCard)obj;
                    lstCardId.Add(card.Id); 
                }
                cardService.DeleteBatch(lstCardId);
                barItemSearch.PerformClick();
            }
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataTable dt = cardService.GetExport();
            DxHelper.ExportXls(dt, "Excel 文件|*.xls");
        }

        private void barItemRefreshCache_ItemClick(object sender, ItemClickEventArgs e)
        {
            CardCacher.Refresh();
        }

        private void barItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmImportCard frmEdit = new FrmImportCard())
            {
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    barItemSearch.PerformClick();
                }
            }
        }

        private void barItemSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            page.PageIndex = 0;
            Search();
            ucPage.InitControl();
        }

        private void bartemAddVirtualCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmPlanCardEdit frmEdit = new FrmPlanCardEdit())
            {
                frmEdit.IsVirtualCard = true;
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    barItemSearch.PerformClick();
                }
            }
        }

        private void gvPlanCard_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}