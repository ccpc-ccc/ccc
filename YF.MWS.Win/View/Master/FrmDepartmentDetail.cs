using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Log;
using YF.Utility.Metadata;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmDepartmentDetail : DevExpress.XtraEditors.XtraForm
    {
        private IMasterService masterService = new MasterService();
        private ICompanyService companyService = new CompanyService();
        private string _deptId;
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DeptId
        {
            get { return _deptId; }
            set { _deptId = value; }
        }

        private string _parentId;
        /// <summary>
        /// 上级部门Id
        /// </summary>
        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        private SDept _department;
        /// <summary>
        /// 部门信息
        /// </summary>
        public SDept Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public FrmDepartmentDetail()
        {
            InitializeComponent();
        }

        private void FrmDepartmentDetail_Load(object sender, EventArgs e)
        {
            this.InitData();
            this.BindData();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //绑定公司
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "CompanyName", Caption = "公司名称" });
            List<SCompany> listCompany = companyService.GetCompanyList(CurrentUser.Instance.CompanyIds);
            SearchLookupUtil.BindData(lookUpCompany, listCompany, "CompanyId", "CompanyName", lstField);

            //绑定部门类型
            DxHelper.BindComboBoxEdit(this.cmbDeptType, SysCode.DeptType, null);
        }

        /// <summary>
        /// 绑定部门列表
        /// </summary>
        /// <param name="companyId">公司Id</param>
        private void BindDept(string companyId)
        {
            //绑定部门
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "DepartName", Caption = "部门名称" });
            List<SDept> listDept = masterService.GetDeptListByCompany(companyId);
            SearchLookupUtil.BindData(lookUpDept, listDept, "DeptId", "DepartName", lstField);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            if (!string.IsNullOrEmpty(this._deptId))
            {
                this.lookUpCompany.Enabled = false;
                this._department = masterService.GetDepart(this._deptId);
                FormHelper.BindControl<SDept>(this, this._department);
                this._parentId = this._department.ParentId;
                //绑定公司
                SCompany comp = companyService.GetCompany(this._department.CompanyId);
                if (comp != null)
                {
                    this.lookUpCompany.EditValue = comp;
                    this.BindDept(this._department.CompanyId);
                }
                //绑定上级部门
                if (!string.IsNullOrEmpty(this._parentId))
                {
                    SDept dept = masterService.GetDepart(this._parentId);
                    if (dept != null)
                    {
                        this.lookUpDept.EditValue = dept;
                    }
                }
                this.cmbDeptType.Properties.Items.Clear();
                //绑定部门类别
                DxHelper.BindComboBoxEdit(this.cmbDeptType, SysCode.DeptType, this._department.DeptType);
            }
            else if (!string.IsNullOrEmpty(this._parentId))
            {
                this.lookUpCompany.Enabled = false;
                this.lookUpDept.Enabled = false;
                SDept dept = masterService.GetDepart(this._parentId);
                if (dept != null)
                {
                    SCompany comp = companyService.GetCompany(dept.CompanyId);
                    if (comp != null)
                    {
                        this.lookUpCompany.EditValue = comp;
                        this.BindDept(dept.CompanyId);
                    }
                    this.lookUpDept.EditValue = dept;
                }
            }
        }

        private void lookUpCompany_EditValueChanged(object sender, EventArgs e)
        {
            SCompany comp = this.lookUpCompany.Properties.View.GetFocusedRow() as SCompany;
            if (comp != null)
            {
                this.BindDept(comp.Id);
            }
        }

        /// <summary>
        /// 验证输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool isValidated = true;

            if (this.lookUpCompany.EditValue == null || string.IsNullOrEmpty(this.lookUpCompany.EditValue.ToString()))
            {
                this.lookUpCompany.ErrorText = "请选择所属公司";
                isValidated = false;
            }
            if (string.IsNullOrEmpty(this.txtDept.Text))
            {
                this.txtDept.ErrorText = "请输入部门名称";
                isValidated = false;
            }
            if (this.cmbDeptType.EditValue == null || string.IsNullOrEmpty(this.cmbDeptType.EditValue.ToString()))
            {
                this.cmbDeptType.ErrorText = "请选择部门类别";
                isValidated = false;
            }

            return isValidated;
        }

        /// <summary>
        /// 保存部门信息
        /// </summary>
        private void Save()
        {
            try
            {
                if (this.ValidateForm())
                {
                    SDept dept;
                    if (!string.IsNullOrEmpty(this._deptId))
                    {
                        dept = this._department;
                    }
                    else
                    {
                        dept = new SDept();
                        dept.Id = this._deptId;
                        dept.ParentId = this._parentId;
                    }

                    FormHelper.ControlToEntity<SDept>(this, ref dept);
                    dept.CompanyId = this.lookUpCompany.EditValue.ToString();
                    if (this.lookUpDept.EditValue != null && !string.IsNullOrEmpty(this.lookUpDept.EditValue.ToString()))
                    {
                        dept.ParentId = (this.lookUpDept.Properties.View.GetFocusedRow() as SDept).Id;
                    }
                    dept.DeptType = DxHelper.GetCode(this.cmbDeptType);
                    masterService.SaveDepart(dept);
                    MessageDxUtil.ShowTips("成功保存部门信息。");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
    }
}