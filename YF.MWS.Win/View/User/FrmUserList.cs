using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Db;
using DevExpress.XtraBars;
using YF.MWS.Win.Util;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.CacheService;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmUserList : DevExpress.XtraEditors.XtraForm
    {
        private IUserService userService = new UserService();
        private List<SUser> lstUser = new List<SUser>();
        private GridCheckMarksSelection chkUser;
        private List<SCode> lstGender = new List<SCode>();
        public FrmUserList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
                gvUser.IndicatorWidth = 40;
                BindData();
            }
        }

        private void btnItemRefreh_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindData();
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<object> lstObj = chkUser.GetSelectedRow();
            if (lstObj == null || lstObj.Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要删除的用户.");
            }
            else
            {
                List<string> lstUserId = new List<string>();
                SUser user = null;
                foreach (object obj in lstObj)
                {
                    user = (SUser)obj;
                    if (user.UserName.ToLower() == "admin")
                    {
                        MessageDxUtil.ShowWarning("系统管理员账户不能被删除,请选择其他要删除的用户.");
                        break;
                    }
                    else
                    {
                        lstUserId.Add(user.Id);
                        if (MessageDxUtil.ShowYesNoAndTips("确实要删除所选用户吗?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            userService.Delete(lstUserId);
                            BindData();
                        }
                    }
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvUser.GetFocusedRow() != null)
            {
                SUser user = (SUser)gvUser.GetFocusedRow();
                using (FrmUserEdit frmEdit = new FrmUserEdit())
                {
                    frmEdit.UserId = user.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmUserEdit frmEdit = new FrmUserEdit())
            {
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            //BindData();
        }

        private void BindData()
        {
            lstGender = MasterCacher.GetSubCodeList(SysCode.Gender.ToString());
            lstUser = userService.GetList(CurrentUser.Instance);
            gcUser.DataSource = lstUser;
            gvUser.Columns["Gender"].ColumnEdit = DxHelper.SetItemComboBox("repItemGender", lstGender);
            if (chkUser == null)
                chkUser = new GridCheckMarksSelection(gvUser);
            chkUser.ClearSelection();
        }
    }
}