using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Metadata.Dto;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Order
{
    public partial class FrmPlanList : DevExpress.XtraEditors.XtraForm
    {
        private IPlanService planService = new PlanService();
        private GridCheckMarksSelection chkCar;
        private QPage page = null;
        private int pageSize = 25;

        public FrmPlanList()
        {
            InitializeComponent();
        }
        private void InitControl()
        {
            page = new QPage();
            ucPage.PageChanged += ucPage_PageChanged;
            page.PageSize = pageSize;
            ucPage.Page.PageSize = pageSize;
        }
        private PlanQuery GetCondition()
        {
            PlanQuery query = new PlanQuery();
            query.PageIndex = page.PageIndex;
            query.PageSize = page.PageSize;
            if (wCustomer.CurrentValue.ToObjectString().Length > 0)
            {
                query.CustomerId = wCustomer.CurrentValue.ToObjectString();
            }
            if (weMaterial.CurrentValue.ToObjectString().Length > 0)
            {
                query.MaterialId = weMaterial.CurrentValue.ToObjectString();
            }
            if (weWarehBizType.Text.Length > 0)
            {
                WarehBizType warehBiz = weWarehBizType.CurrentValue.ToEnum<WarehBizType>();
                query.WarehBiz = warehBiz;
            }
            return query;
        }
        public void Search()
        {
            PageList<PlanFull> result = planService.GetList(GetCondition());
            if (result != null)
            {
                page.TotalRows = result.Total;
                ucPage.Page.TotalRows = page.TotalRows;
                gcCarPlan.DataSource = result.Models;
                gcCarPlan.RefreshDataSource();
                chkCar.ClearSelection();
            }
        }
        private void ucPage_PageChanged(object sender, PageChangedEventArgs e)
        {
            page.PageIndex = e.Page.PageIndex;
            Search();
            e.Page.TotalRows = page.TotalRows;
        }
        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmCarPlanEdit frmEdit = new  FrmCarPlanEdit())
            {
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    Search();
                }
            }
        }
        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCar.GetSelectedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要编辑的计划信息.");
            }
            else
            {
                PlanFull car = (PlanFull)gvCarPlan.GetFocusedRow();
                if (car != null)
                {
                    using (FrmCarPlanEdit frmEdit = new FrmCarPlanEdit())
                    {
                        frmEdit.RecId = car.Id;
                        if (frmEdit.ShowDialog() == DialogResult.OK)
                        {
                            this.barItemSearch.PerformClick();
                        }
                    }
                }
                else { MessageDxUtil.ShowWarning("请选择要编辑的计划信息."); }
            }
        }
        private void barItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCar.GetSelectedRow()==null)
            {
                MessageDxUtil.ShowWarning("请选择要删除的计划数据.");
                return;
            }
            string message = "确实要删除所选派车计划吗?\n此操作不可撤销,请慎重操作.";
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes)
            {
                List<object> lstCard = chkCar.GetSelectedRow();
                List<string> lstCardId = new List<string>();
                foreach (object obj in lstCard)
                {
                    PlanFull plan=(PlanFull)obj;
                   planService.Delete(plan.Id);
                }
                barItemSearch.PerformClick();
            }
        }
        private void barItemSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
           page.PageIndex = 0;
           Search();
           ucPage.InitControl();
        }
        private void FrmCarPlanList_Load(object sender, EventArgs e)
        {
            chkCar = new GridCheckMarksSelection(gvCarPlan);
            InitControl();
            barItemSearch.PerformClick();
        }

        private void gvCarPlan_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}