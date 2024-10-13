using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using System.Linq;

namespace YF.MWS.Win.View.User
{
    public partial class FrmModuleEdit : DevExpress.XtraEditors.XtraForm
    {
        private IRoleService roleService = new RoleService();
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string moduleId;

        public string ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }
        private string parentId;

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        private string parentName;

        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }
        public FrmModuleEdit()
        {
            InitializeComponent();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private bool ValidateForm() {
            bool isValidated = true;
            if (teModuleName.Text.Length == 0) {
                teModuleName.ErrorText = "请输入模块名称";
                teModuleName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            if (teFullName.Text.Length == 0) {
                teFullName.ErrorText = "请输入权限编号";
                teFullName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            } else if (teFullName.Text.Contains(",")|| teFullName.Text.Contains(".")|| teFullName.Text.Contains( "'")|| teFullName.Text.Contains("\""))
            {
                teFullName.ErrorText = "权限编号中不允许输入 , . ' \" 等特殊字符";
                teFullName.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                isValidated = false;
            }
            return isValidated;
        }
        private void Save() {
            if (ValidateForm()) {
                SModule module = roleService.GetModuleByFullName(teFullName.Text);
                if (module != null && module.Id != ModuleId) {
                    MessageDxUtil.ShowError("模块编号重复！");
                    return;
                }
                if (!string.IsNullOrEmpty(ModuleId)) {
                    module = roleService.GetModule(ModuleId);
                } else {
                    module = null;
                }
                if (module == null) {
                    module = new SModule();
                    module.Id = YF.MWS.Util.Utility.GetGuid();
                }
                module.ParentId = ParentId;
                FormHelper.ControlToEntity<SModule>(this, ref module);
                module.SuperTipState = chkSuperTipState.Checked ? 1 : 0;
                module.SuperTipContent = memSuperTipContent.Text;
                module.Platform = "Client";
                roleService.SaveModule(module);
                MessageDxUtil.ShowTips("成功保存系统模块信息.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(ModuleId))
            {
                SModule module = roleService.GetModule(ModuleId);
                if (module != null)
                {
                    FormHelper.BindControl<SModule>(this, module);
                    if (!string.IsNullOrEmpty(module.ParentId))
                    {
                        SModule parent = roleService.GetModule(module.ParentId);
                        if (parent != null)
                        {
                            ParentId = parent.Id;
                            teParent.Text = parent.ModuleName;
                        }
                    }
                    chkSuperTipState.Checked = module.SuperTipState == 1 ? true : false;
                    memSuperTipContent.Text = module.SuperTipContent;
                }
            }
            else
            {
                teParent.Text = ParentName;
                teFullName.Text = fullName;
            }
        }

        private void FrmModuleEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSelectParent_Click(object sender, EventArgs e)
        {
            using (FrmModuleSelect frmSelect = new FrmModuleSelect()) 
            {
                if (frmSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    parentId = frmSelect.ParentId;
                    parentName = frmSelect.ParentName;
                    teParent.Text = parentName;
                }
            }
        }
    }
}