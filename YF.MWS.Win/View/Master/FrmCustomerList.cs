using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.CacheService;
using YF.MWS.Win.Uc;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using DevExpress.XtraGrid.Views.Grid;
using YF.Utility;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCustomerList : BaseForm
    {
        private ICustomerService customerService = new CustomerService();
        private IMasterService masterService = new MasterService();
        private IPayService payService = new PayService();
        private ISyncService syncService = new SyncService();
        private IWebCustomerService webCustomerService = new WebCustomerService();
        private List<SCustomer> lstCustomer = new List<SCustomer>();
        private List<SCode> lstCustomerType = new List<SCode>();
        private List<BarItem> lstItem = new List<BarItem>();
        private GridCheckMarksSelection chkCustomer;
        private bool startUpload = false;
        public FrmCustomerList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
                BindData();
            }
        }

        private void btnItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCustomerDetail frmDetail = new FrmCustomerDetail()) 
            {
                frmDetail.FrmMain = GetMain();
                if (frmDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void BindData() 
        {
            lstCustomer = customerService.GetAllCustomerList(); 
            gcCustomer.DataSource = lstCustomer;
            lstCustomerType = MasterCacher.GetSubCodeList(SysCode.CustomerType.ToString());
            gvCustomer.Columns["CustomerType"].ColumnEdit = DxHelper.SetItemComboBox("repItemCustomerType", lstCustomerType);
            if (chkCustomer == null)
                chkCustomer = new GridCheckMarksSelection(gvCustomer);
            chkCustomer.ClearSelection();
        }

        private void InitRoleControl()
        {
            lstItem.Add(barItemImport);
            lstItem.Add(barItemExport);
            RoleUtil.SetBarItem(lstItem, LstModule);
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvCustomer.GetFocusedRow() != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                using (FrmCustomerDetail frmDetail = new FrmCustomerDetail())
                {
                    frmDetail.FrmMain = GetMain();
                    frmDetail.RecId = customer.Id;
                    if (frmDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            InitRoleControl();
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCustomer.GetSelectedRow() == null || chkCustomer.GetSelectedRow().Count == 0) 
            {
                MessageDxUtil.ShowWarning("请选择要删除的客户信息.");
            }
            else
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除该客户信息吗?此删除可通过恢复操作还原客户信息,请谨慎操作.") == DialogResult.Yes) 
                {
                    List<object> lstObj = chkCustomer.GetSelectedRow();
                    List<string> customerIds = new List<string>();
                    bool isDeleted = false;
                    foreach (object obj in lstObj)
                    {
                        SCustomer customer = (SCustomer)obj;
                        if (customer != null)
                        {
                            isDeleted = customerService.DeleteCustomer(customer.Id);
                            if (isDeleted)
                                customerIds.Add(customer.Id);
                        }
                    }
                    CustomerCacher.Remove();
                    if (startUpload)
                        webCustomerService.Delete(customerIds);
                    MessageDxUtil.ShowTips("成功删除所选的客户信息.");
                    BindData();
                }
            }
        }

        private void barItemRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindData();
        }

        private void barItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmCustomerImport frmImport = new FrmCustomerImport()) 
            {
                if (frmImport.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmCustomerExport frmExport = new FrmCustomerExport())
            {
                if (frmExport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
            }
        }

        private void barItemSync_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<object> lstObj = chkCustomer.GetSelectedRow();
            if (lstObj == null || lstObj.Count == 0) 
            {
                MessageDxUtil.ShowWarning("请选择要同步的客户信息.");
                return;
            }
            using (Utility.GetWaitForm("正在同步客户信息..."))
            {
                foreach (object obj in lstObj)
                {
                    SCustomer customer = (SCustomer)obj;
                    webCustomerService.Save(customer);
                }
                MessageDxUtil.ShowTips("成功同步客户信息.");
            }
        }

        private void gvCustomer_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void barItemRefreshPayRecord_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<object> lstObj = chkCustomer.GetSelectedRow();
            if (lstObj == null || lstObj.Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要批量更新客户账单流水的客户信息.");
                return;
            }
            string message = "确实要批量更新客户账单流水吗?\n此操作会影响客户所有的历史账户数据";
            if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (object obj in lstObj)
                {
                    SCustomer customer = (SCustomer)obj;
                    payService.RefreshCustomerBalance(customer.Id);
                }
                MessageDxUtil.ShowTips("已经完成批量更新客户账单流水");
                barItemRefresh.PerformClick();
            }
        }

        private void gvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            barItemRecovery.Enabled = false;
            barItemRealDelete.Enabled = false;
            if (gvCustomer.GetFocusedRow() != null) 
            {
                SCustomer customer = (SCustomer)gvCustomer.GetFocusedRow();
                if (customer.RowState == (int)RowState.Delete) 
                {
                    barItemRecovery.Enabled = true;
                    barItemRealDelete.Enabled = true;
                }
            }
        }

        private void barItemRealDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCustomer.GetSelectedRow() == null || chkCustomer.GetSelectedRow().Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要彻底删除的单位信息.");
            }
            else
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要恢复所选择的单位信息吗?\n此删除不可撤销,请谨慎操作.") == DialogResult.Yes)
                {
                    List<object> lstObj = chkCustomer.GetSelectedRow();
                    List<string> customerIds = new List<string>();
                    bool isDeleted = false;
                    BatchUpdate batchUpdate = new BatchUpdate();
                    foreach (object obj in lstObj)
                    {
                        SCustomer customer = (SCustomer)obj;
                        if (customer != null)
                        {
                            isDeleted = customerService.DeleteCustomerPhysics(customer.Id);
                            if (isDeleted)
                                batchUpdate.Ids.Add(customer.Id);
                        }
                    }
                    CustomerCacher.Remove();
                    if (startUpload)
                        webCustomerService.BatchDeletePhysics(batchUpdate);
                    MessageDxUtil.ShowTips("成功删除所选的单位信息.");
                    BindData();
                }
            }
        }

        private void barItemRecovery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkCustomer.GetSelectedRow() == null || chkCustomer.GetSelectedRow().Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要恢复的单位信息.");
            }
            else
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要恢复所选择的单位信息吗?") == DialogResult.Yes)
                {
                    List<object> lstObj = chkCustomer.GetSelectedRow();
                    List<string> customerIds = new List<string>();
                    bool isDeleted = false;
                    CustomerUpdate customerUpdate = new CustomerUpdate();
                    customerUpdate.State = RowState.Edit;
                    foreach (object obj in lstObj)
                    {
                        SCustomer customer = (SCustomer)obj;
                        if (customer != null)
                        {
                            isDeleted = customerService.UpdateState(customer.Id, RowState.Edit);
                            if (isDeleted)
                                customerUpdate.CustomerIds.Add(customer.Id);
                        }
                    }
                    CustomerCacher.Remove();
                    if(startUpload)
                        webCustomerService.UpdateState(customerUpdate);
                    MessageDxUtil.ShowTips("成功恢复所选的单位信息.");
                    BindData();
                }
            }
        }

        private void gvCustomer_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (gvCustomer.GetRow(e.RowHandle) != null)
            {
                SCustomer customer = (SCustomer)gvCustomer.GetRow(e.RowHandle);
                if (customer != null && customer.BalanceWarn)
                {
                    e.Appearance.BackColor = Color.FromKnownColor(KnownColor.OrangeRed);
                }
            }
        }

    }
}