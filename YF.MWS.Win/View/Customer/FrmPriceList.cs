using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Query;
using YF.MWS.Db;
using YF.MWS.Metadata.Transfer;
using YF.Utility;
using YF.MWS.Metadata.Event;
using YF.MWS.CacheService;

namespace YF.MWS.Win.View.Customer
{
    public partial class FrmPriceList : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private ICustomerService customerPriceService = new CustomerService();
        private List<LookupField> lstField = new List<LookupField>();
        private GridCheckMarksSelection chkPrice;
        private QPage page = null;
        private int pageSize = 25;

        public FrmPriceList()
        {
            InitializeComponent();
        }

        private void FrmPriceList_Load(object sender, EventArgs e)
        {
            InitControl();
            LoadData();
        }

        private void InitControl()
        {
            page = new QPage();
            ucPage.PageChanged += ucPage_PageChanged;
            page.PageSize = pageSize;
            ucPage.Page.PageSize = pageSize;
        }

        private void ucPage_PageChanged(object sender, PageChangedEventArgs e)
        {
            page.PageIndex = e.Page.PageIndex;
            Search();
            e.Page.TotalRows = page.TotalRows;
        }

        private void LoadData()
        {
            List<SMaterial> lstMaterial = MaterialCacher.GetMaterialList();
            lstField.Clear();
            lstField.Add(new LookupField() { FieldName = "MaterialCode", Caption = "物料编码" });
            lstField.Add(new LookupField() { FieldName = "MaterialName", Caption = "物料名称" });
            SearchLookupUtil.BindData(lookMaterial, lstMaterial, "MaterialId", "MaterialName", lstField);
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            page.PageIndex = 0;
            Search();
            ucPage.InitControl();
        }

        private PageQueryCondition GetCondition()
        {
            PageQueryCondition qc = new PageQueryCondition();
            List<QColumn> lstColumn = new List<QColumn>();
            QColumn column;
            qc.PageIndex = page.PageIndex;
            qc.PageSize = page.PageSize;

            qc.LstColumn = lstColumn;
            qc.ExtendCondition = GetExtendCondition();
            return qc;
        }

        public string GetExtendCondition()
        {
            StringBuilder sb = new StringBuilder();
            if (weCustomer.CurrentValue.ToObjectString().Length > 0)
            {
                sb.AppendFormat(" and a.CustomerId='{0}'", weCustomer.CurrentValue);
            }
            if (lookMaterial.EditValue.ToObjectString().Length > 0)
            {
                sb.AppendFormat(" and a.MaterialId='{0}'", lookMaterial.EditValue.ToObjectString());
            }
            return sb.ToString();
        }

        private void Search()
        {
            TPageResult result = customerPriceService.GetList(GetCondition());
            if (result != null)
            {
                page.TotalRows = result.Count;
                ucPage.Page.TotalRows = page.TotalRows;

                if (result.Rows != null && result.Rows.ToObjectString().Length > 0)
                {
                    List<SCustomerPrice> lstBill = (List<SCustomerPrice>)result.Rows;
                    gcPrice.DataSource = lstBill;
                    gcPrice.RefreshDataSource();
                    if (chkPrice == null)
                    {
                        chkPrice = new GridCheckMarksSelection(gvPrice);
                    }
                    chkPrice.ClearSelection();
                }
            }
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmPriceEdit frmEdit = new FrmPriceEdit())
            {
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    barItemSearch.PerformClick();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPrice.GetFocusedRow() != null)
            {
                SCustomerPrice price = (SCustomerPrice)gvPrice.GetFocusedRow();
                using (FrmPriceEdit frmEdit = new FrmPriceEdit())
                {
                    frmEdit.RecId = price.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        barItemSearch.PerformClick();
                    }
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPrice.GetFocusedRow() != null)
            {
                SCustomerPrice price = (SCustomerPrice)gvPrice.GetFocusedRow();
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除该物资单价信息吗?") == DialogResult.Yes) 
                {
                    customerPriceService.Delete(price.Id);
                    barItemSearch.PerformClick();
                }
            }
        }
    }
}