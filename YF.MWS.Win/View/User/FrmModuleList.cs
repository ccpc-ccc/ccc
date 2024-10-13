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
using YF.Utility;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmModuleList : DevExpress.XtraEditors.XtraForm
    {
        private IRoleService roleService = new RoleService();

        public FrmModuleList()
        {
            using (Utility.GetWaitForm())
            {
                InitializeComponent();
                BindData();
            }
        }

        private void FrmModuleList_Load(object sender, EventArgs e)
        {
            //BindData();
            if (CurrentUser.Instance.UserName == AuthUser.Instance.UserName) 
            {
                barItemAuthSetting.Visibility = BarItemVisibility.Always;
            }
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmModuleEdit frmEdit = new FrmModuleEdit())
            {
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void BindData()
        {
            var lstModule = roleService.GetModuleList();
            treeModule.DataSource = lstModule;
            treeModule.ExpandAll();
        }

        private void btnItemAddSub_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmModuleEdit frmEdit = new FrmModuleEdit())
            {
                if (treeModule.FocusedNode != null)
                {
                    frmEdit.ParentId = treeModule.FocusedNode["Id"].ToString();
                    frmEdit.ParentName = treeModule.FocusedNode["ModuleName"].ToObjectString();
                    frmEdit.FullName = treeModule.FocusedNode["FullName"].ToObjectString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void treeModule_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            DxHelper.SetChildNode(e.Node, e.Node.CheckState);
            DxHelper.SetParentNode(e.Node, e.Node.CheckState);
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmModuleEdit frmEdit = new FrmModuleEdit())
            {
                if (treeModule.FocusedNode != null)
                { 
                    frmEdit.ModuleId = treeModule.FocusedNode["Id"].ToString();
                }
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Delete();
        }

        private void btnItemRefreh_ItemClick(object sender, ItemClickEventArgs e)
        {
            BindData();
        }

        private void barItemAuthSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentClient.Instance.CurrentVersion == VersionType.Probation) 
            {
                MessageDxUtil.ShowWarning("试用版无需设置版本功能.");
                return;
            }
            using (FrmAuth frmAuth = new FrmAuth()) 
            {
                if (frmAuth.ShowDialog() == DialogResult.OK) 
                {
                    using (FrmVersionSetting frmSetting = new FrmVersionSetting())
                    {
                        frmSetting.ShowDialog();
                    }
                }
            }
        }

        private void Delete() 
        {
            if (treeModule.FocusedNode != null)
            {
                string message;
                message = string.Format("确实要删除模块({0})吗?此操作不可撤销.", treeModule.FocusedNode["ModuleName"].ToString());
                if (MessageDxUtil.ShowYesNoAndTips(message) == System.Windows.Forms.DialogResult.Yes)
                {
                    string moduleId = treeModule.FocusedNode["Id"].ToString();
                    List<SModule> lstModule = roleService.GetSubModuleList(moduleId);
                    if (lstModule != null && lstModule.Count > 0)
                    {
                        message = string.Format("模块({0})存在对应的子模块,请先将子模块删除.", treeModule.FocusedNode["ModuleName"].ToString());
                        MessageDxUtil.ShowWarning(message);
                    }
                    else
                    {
                        message = string.Format("模块({0})成功被删除.", treeModule.FocusedNode["ModuleName"].ToString());
                        roleService.DeleteModule(moduleId);
                        MessageDxUtil.ShowTips(message);
                        BindData();
                    }
                }
            }
            else 
            {
                MessageDxUtil.ShowWarning("请选择要删除的模块.");
            }
        }

        private void barItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var modules = roleService.GetModuleList();
            if (modules == null || modules.Count == 0) 
            {
                MessageDxUtil.ShowWarning("暂无模块可以导出");
                return;
            }
            using (SaveFileDialog sfdFileSave = new SaveFileDialog())
            {
                sfdFileSave.Filter = "Xml 文件|*.xml";
                sfdFileSave.FileName = "功能模块.xml";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfdFileSave.FileName;
                    XmlUtil.Serialize<List<SModule>>(modules, filePath);
                    MessageDxUtil.ShowTips("成功导出模块");
                }
            }
        }

        private void barItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Xml 文件|*.xml";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    List<SModule> modules = XmlUtil.Deserialize<List<SModule>>(filePath);
                    if (modules == null || modules.Count == 0)
                    {
                        MessageDxUtil.ShowWarning("文件选择错误,请重新选择");
                        return;
                    }
                    roleService.ImportModules(modules);
                    MessageDxUtil.ShowTips("成功导入模块");
                    BindData();
                }
            }
        }
    }
}