using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Metadata;
using YF.Utility.Configuration;
using YF.Utility;
using YF.Utility.Log;
using DevExpress.XtraTreeList.Nodes;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmUserEdit : DevExpress.XtraEditors.XtraForm
    {
        private IUserService userService = new UserService();
        private IRoleService roleService = new RoleService();
        private ICompanyService companyService = new CompanyService();
        private List<SRole> lstRole = new List<SRole>();
        private List<SUserRole> lstUserRole = new List<SUserRole>();
        private List<SRolePermission> lstPermission = new List<SRolePermission>();
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public FrmUserEdit()
        {
            InitializeComponent();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            initPowers();
            BindData();
            if (CurrentUser.Instance.IsAdministrator) {
                plAdmin.Visible = true;
            } else {
                plAdmin.Visible = false;
            }
        }
        private void initPowers() {
            if (CurrentUser.Instance.IsAdministrator) {
                List<SModule> lstModule = roleService.GetModuleList();
                treeModule.DataSource = lstModule;
            } else {
                if (CurrentUser.Instance.Powers == null) return;
                List<SModule> lstModule = roleService.GetModuleList(CurrentUser.Instance.Powers);
                treeModule.DataSource = lstModule;
            }
                treeModule.ExpandAll();
        }
        private void BindData()
        {
            lstRole = roleService.GetRoleList();
            DataTable dtRole=roleService.GetRoleTable();
            DataTable dtCompany = companyService.GetCompanies(CurrentUser.Instance.CompanyIds);
            txtNewPwd.Properties.PasswordChar = '*';
            List<ListItem> list = dtCompany.ToListItems( "CompanyName");
            if(CurrentUser.Instance.CompanyIds==null) list.Add(new ListItem("总部", ""));
            SUser user = userService.GetById(UserId);
            if (user != null)
            {
                    txtUserName.Text = user.UserName;
                    txtUserName.Enabled = false;
                    txtMobilePhone.Text = user.MobilePhone;
                    comboGender.SelectedItem = user.Gender;
                    txtFullName.Text = user.FullName;
                    chkActive.Checked = user.Active == 1 ? true : false;
                    chkIsAdmin.Checked = user.IsAdmin == 1 ? true : false;
                    DxHelper.BindComboBoxEdit(comboGender, SysCode.Gender, user.Gender);
                tabPagePassword.PageEnabled = true;
                    if (!string.IsNullOrEmpty(user.RoleId))
                        BindRole(user.Powers.Split(','));
            }
            else
            {
                DxHelper.BindComboBoxEdit(comboGender, SysCode.Gender, null);
                tabPagePassword.PageEnabled = false;
                //tabPageRoleSetting.PageEnabled = false;
            }
        }

        private void BindRole(string roleId) 
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                lstPermission = roleService.GetRolePermissionList(roleId);
                foreach (TreeListNode node in treeModule.Nodes)
                {
                    SetNodeChecked(node);
                    if (node.HasChildren)
                    {
                        DxHelper.SetParentNode(node.Nodes[0], node.Nodes[0].CheckState);
                    }
                }
            }
        }
        private void BindRole(string[] powers) 
        {
                foreach (TreeListNode node in treeModule.Nodes)
                {
                    SetNodeChecked(node, powers);
                    if (node.HasChildren)
                    {
                        DxHelper.SetParentNode(node.Nodes[0], node.Nodes[0].CheckState);
                    }
                }
        }

        private void SetNodeChecked(TreeListNode node)
        {
            foreach (TreeListNode subNode in node.Nodes)
            {
                if (lstPermission != null && lstPermission.Count(c => c.ModuleId == subNode.GetValue("FullName").ToString()) > 0)
                {
                    subNode.CheckState = CheckState.Checked;
                }
                else
                {
                    subNode.CheckState = CheckState.Unchecked;
                }
                if (subNode.HasChildren)
                {
                    SetNodeChecked(subNode);
                }
            }
        }
        private void SetNodeChecked(TreeListNode node, string[] powers)
        {
            foreach (TreeListNode subNode in node.Nodes)
            {
                if (powers != null && powers.Count(c => c == subNode.GetValue("FullName").ToString()) > 0)
                {
                    subNode.CheckState = CheckState.Checked;
                }
                else
                {
                    subNode.CheckState = CheckState.Unchecked;
                }
                if (subNode.HasChildren)
                {
                    SetNodeChecked(subNode);
                }
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (txtUserName.Text.Length == 0)
            {
                txtUserName.ErrorText = "请输入用户名";
                txtUserName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            if (txtFullName.Text.Length == 0)
            {
                txtFullName.ErrorText = "请输入真实姓名";
                txtFullName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            return isValidated;
        }

        private bool CheckUserExisit()
        {
            bool isExists = false;
            if (string.IsNullOrEmpty(UserId))
            {
                isExists = userService.UserExist(txtUserName.Text);
            }
            return isExists;
        }

        private void Save()
        {
            if (ValidateForm())
            {
                if (CheckUserExisit())
                {
                    MessageDxUtil.ShowTips(string.Format("该用户({0})已经存在,请用其他用户名.", txtUserName.Text));
                }
                else
                {
                    try
                    {
                        SUser user = null;
                        if (!string.IsNullOrEmpty(UserId))
                        {
                            user = userService.GetById(UserId);
                        }
                        if (user == null) 
                        {
                            user = new SUser();
                            user.UserPwd = AppSetting.GetValue("defaultPwd").ToMd5();
                        }
                        user.Gender = DxHelper.GetCode(comboGender);
                        user.UserName = txtUserName.Text;
                        user.FullName = txtFullName.Text;
                        
                        user.MobilePhone = txtMobilePhone.Text;
                        user.Active = chkActive.Checked ? 1:0;
                        user.IsAdmin = chkIsAdmin.Checked ? 1:0;
                            List<TreeListNode> lstNode = DxHelper.GetTreeCheckedNodes(treeModule.Nodes);
                            List<string> lstModuleId = new List<string>();
                            foreach (TreeListNode node in lstNode)
                            {
                                lstModuleId.Add(node.GetValue("FullName").ToString());
                            }
                        user.Powers = string.Join(",", lstModuleId.ToArray());
                        bool isSaved=userService.Save(user);
                       
                        if (string.IsNullOrEmpty(UserId))
                        {
                            MessageDxUtil.ShowTips(string.Format("成功新建用户({0}),默认密码是:{1}.", user.UserName, AppSetting.GetValue("defaultPwd")));
                        }
                        else
                        {
                            MessageDxUtil.ShowTips("成功保存用户信息.");
                        }
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch(Exception ex)
                    {
                        Logger.WriteException(ex);
                        MessageDxUtil.ShowError("保存用户信息时发生错误.");
                    }
                }
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            UpdatePassword();
        }

        private void UpdatePassword() 
        {
            string password = txtNewPwd.Text.Trim();
            if (password.Length == 0)
            {
                MessageDxUtil.ShowWarning("请输入密码");
            }
            else 
            {
                userService.UpdatePassword(UserId, password.ToMd5());
                MessageDxUtil.ShowTips("密码已经成功修改.");
            }
        }

        private void treeModule_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            DxHelper.SetChildNode(e.Node, e.Node.CheckState);
            DxHelper.SetParentNode(e.Node, e.Node.CheckState);
        }
    }
}