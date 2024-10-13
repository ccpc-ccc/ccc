using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmRoleList : DevExpress.XtraEditors.XtraForm
    {
        private IRoleService roleService = new RoleService();
        private List<SRole> lstRole = new List<SRole>();
        public FrmRoleList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
                gvRole.IndicatorWidth = 40;
                BindData();
            }
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmRoleEdit frmEdit = new FrmRoleEdit())
            {
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvRole.GetFocusedRow() != null)
            {
                SRole role = (SRole)gvRole.GetFocusedRow();
                using (FrmRoleEdit frmEdit = new FrmRoleEdit())
                {
                    frmEdit.RoleId = role.Id;
                    if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //BindData();
                    }
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvRole.GetFocusedRow() == null)
            {
                MessageDxUtil.ShowWarning("请选择要删除的角色.");
            }
            else 
            {
                SRole role = (SRole)gvRole.GetFocusedRow();
                if (role != null) 
                {
                    string message = string.Format("确实要删除角色({0})?\n此操作不可撤销,请慎重操作.",role.RoleName);
                    if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes) 
                    {
                        roleService.DeleteRole(role.Id);
                        BindData();
                    }
                }
            }
        }

        private void btnItemRefreh_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindData();
        }

        private void FrmRoleList_Load(object sender, EventArgs e)
        {
            //BindData();
        }

        private void BindData()
        {
            lstRole = roleService.GetRoleList();
            gcRole.DataSource = lstRole;
        }

        private void gvRole_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}