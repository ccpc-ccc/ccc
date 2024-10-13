using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using YF.MWS.Win.Util;
using DevExpress.XtraTreeList;
using System.Linq;
using YF.Utility.Log;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmRoleEdit : DevExpress.XtraEditors.XtraForm
    {
        private IRoleService roleService = new RoleService();
        private List<SRolePermission> lstPermission = new List<SRolePermission>();
        private string roleId;

        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        public FrmRoleEdit()
        {
            InitializeComponent();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teRoleName.Text.Length == 0)
            {
                teRoleName.ErrorText = "输入角色名称";
                teRoleName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    SRole role = new SRole();
                    role.Id = RoleId;
                    role.Remarks = memRemarks.Text;
                    role.RoleName = teRoleName.Text;
                    role.Platform= "Client";
                    roleService.SaveRole(role);
                    List<string> lstModuleId = new List<string>();
                    List<TreeListNode> lstNode = DxHelper.GetTreeCheckedNodes(treeModule.Nodes);
                    foreach (TreeListNode node in lstNode)
                    {
                        lstModuleId.Add(node.GetValue("Id").ToString());
                    }
                    roleService.SaveRolePermission(role.Id, lstModuleId);
                    MessageDxUtil.ShowTips("成功保存权限信息.");
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    Logger.WriteException(ex);
                    MessageDxUtil.ShowError("保存权限信息时发生未知错误,请重试.");
                }
            }
        }
        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void treeModule_AfterCheckNode(object sender, NodeEventArgs e)
        {
            DxHelper.SetChildNode(e.Node, e.Node.CheckState);
            DxHelper.SetParentNode(e.Node, e.Node.CheckState);
        }

        private void BindData()
        {
            List<SModule> lstModule = roleService.GetModuleList();
            treeModule.DataSource = lstModule;
            treeModule.ExpandAll();
            if (!string.IsNullOrEmpty(RoleId))
            {
                SRole role = roleService.GetRole(RoleId);
                teRoleName.Text = role.RoleName;
                memRemarks.Text = role.Remarks;
                lstPermission = roleService.GetRolePermissionList(RoleId);
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

        private void SetNodeChecked(TreeListNode node)
        {
            foreach (TreeListNode subNode in node.Nodes)
            {
                if (lstPermission != null && lstPermission.Count(c => c.ModuleId == subNode.GetValue("Id").ToString()) > 0)
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

        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}