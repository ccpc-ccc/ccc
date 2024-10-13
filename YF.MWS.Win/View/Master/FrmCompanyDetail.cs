using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Log;
using YF.Utility.Metadata;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.MWS.Util.Dynamic;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmCompanyDetail : DevExpress.XtraEditors.XtraForm
    {
        private ICompanyService companyService = new CompanyService();
        private string companyId;
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

        private string parentId;
        /// <summary>
        /// 上级公司Id
        /// </summary>
        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private SCompany company;
        /// <summary>
        /// 公司信息
        /// </summary>
        public SCompany Company
        {
            get { return company; }
            set { company = value; }
        }

        /// <summary>
        /// 上传的公司Logo图片地址
        /// </summary>
        private string _imgFile;

        public FrmCompanyDetail()
        {
            InitializeComponent();
        }

        private void FrmCompanyDetail_Load(object sender, EventArgs e)
        {
            this.InitData();
            this.BindData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("临时计费","0"));
            list.Add(new ListItem("按次计费", "1"));
            list.Add(new ListItem("按时计费", "2"));
            cmbChargeType.BindComboBoxEdit(list, null);
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "CompanyName", Caption = "公司名称" });
            List<SCompany> listCompany = companyService.GetCompanyList(CurrentUser.Instance.CompanyIds);
            if (!string.IsNullOrEmpty(this.companyId))
            {
                listCompany.RemoveAll(item => item.Id == this.companyId);
            }
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
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            if (!string.IsNullOrEmpty(this.companyId))
            {
                this.company = companyService.GetCompany(this.companyId);
                FormHelper.BindControl<SCompany>(this, this.company);
                cmbChargeType.SelectedIndex = company.ChargeType;
            }
        }

        /// <summary>
        /// 保存公司信息
        /// </summary>
        private void Save()
        {
            try
            {
                if (this.ValidateForm())
                {
                    SCompany corp;
                    if (Company!=null)
                    {
                        corp = Company;
                    }
                    else
                    {
                        corp = new SCompany();
                        corp.Id = YF.MWS.Util.Utility.GetGuid();
                        corp.ParentId = CurrentUser.Instance.CompanyId;
                    }
                    if (dateOverTime.EditValue == null) dateOverTime.EditValue = DateTime.Now;
                    FormHelper.ControlToEntity<SCompany>(this, ref corp);
                    corp.ChargeType = cmbChargeType.SelectedIndex;
                    companyService.SaveCompany(corp);
                    MessageDxUtil.ShowTips("成功保存公司信息.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存公司信息时发生未知错误,请重试.");
            }
        }

        /// <summary>
        /// 验证输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool isValidated = true;

            if (string.IsNullOrEmpty(this.txtCompany.Text))
            {
                this.txtCompany.ErrorText = "请输入公司名称";
                isValidated = false;
            } 
            if (cmbChargeType.SelectedIndex==2&& dateOverTime.EditValue==null)
            {
                this.dateOverTime.ErrorText = "结束日期不能为空";
                isValidated = false;
            }

            return isValidated;
        }
    }
}