using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmExtendViewDetail : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private IAttributeService attributeService = new AttributeService();
        private List<SAttribute> lstAttribute = new List<SAttribute>();
        private SWeightViewDtl detail = null;
        private ControlType ctrlType = ControlType.Extend;
        public string ViewId;
        private string subjectId;

        public string SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        } 

        public FrmExtendViewDetail()
        {
            InitializeComponent();
        }

        private void lookupControl_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RecId))
            {
                if (lookupControl.EditValue != null)
                {
                    SAttribute attr = attributeService.GetAttribute(lookupControl.EditValue.ToString());
                    if (attr != null)
                    {
                        teFullName.Text = attr.FullName;
                        teControlName.Text = attr.AttributeName;
                        teFieldName.Text = attr.FieldName;
                        teCaption.Text = attr.AttributeName + ":";
                    }
                }
            }
        }

        private bool CanStartStay(string fieldName)
        {
            bool canStay = true;
            if (!string.IsNullOrEmpty(fieldName))
            {
                if (fieldName.ToLower() == "GrossWeight".ToLower() || fieldName.ToLower() == "TareWeight".ToLower()
                    || fieldName.ToLower() == "SuttleWeight".ToLower() || fieldName.ToLower() == "CarId".ToLower() || fieldName.ToLower() == "CardNo".ToLower())
                {
                    canStay = false;
                }
            }
            return canStay;
        }

        private void Save()
        {
            try
            {
                if (detail == null)
                {
                    detail = new SWeightViewDtl();
                    detail.Id = YF.MWS.Util.Utility.GetGuid();
                }
                FormHelper.ControlToEntity<SWeightViewDtl>(this, ref detail);
                detail.ViewId = ViewId;
                detail.ControlId = lookupControl.EditValue.ToObjectString();
                detail.IsRequired = chkIsRequired.Checked ? 1 : 0;
                detail.Readonly = chkReadonly.Checked ? 1 : 0;
                detail.ControlType = ctrlType.ToString();
                detail.ActionName = teActionName.Text;
                detail.StayState = chkStartStay.Checked ? 1 : 0;
                detail.AutoSaveState = chkStartAutoSave.Checked ? 1 : 0;
                bool canStay = CanStartStay(detail.FieldName);
                if (!canStay)
                    detail.StayState = 0;
                viewService.SaveViewDetail(detail);
                MessageDxUtil.ShowTips("成功保存界面扩展控件信息.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存界面扩展控件信息时发生未知错误,请重试.");
            }
        }

        private void BindData()
        {
            lstAttribute = attributeService.GetAttributeList(subjectId);
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "AttributeName", Caption = "名称" });
            SearchLookupUtil.BindData(lookupControl, lstAttribute, "Id", "AttributeName", lstField);
            if (!string.IsNullOrEmpty(RecId))
            {
                detail = viewService.GetViewDetail(RecId);
                FormHelper.BindControl<SWeightViewDtl>(this, detail);
                lookupControl.Properties.ReadOnly = true;
                lookupControl.EditValue = detail.ControlId;
                chkIsRequired.Checked = detail.IsRequired == 1 ? true : false;
                chkReadonly.Checked = detail.Readonly == 1 ? true : false;
                chkStartAutoSave.Checked = detail.AutoSaveState == 1;
                chkStartStay.Checked = detail.StayState ==1;
            }
        }

        private void FrmExtendViewDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (lookupControl.EditValue == null || lookupControl.EditValue.ToObjectString().Length == 0) 
            {
                lookupControl.ErrorText = "请选择控件";
                lookupControl.Focus();
                isValidated = false;
            }
            if (teControlName.Text.Length == 0)
            {
                teControlName.ErrorText = "请输入控件名称";
                teControlName.Focus();
                isValidated = false;
            }
            if (chkIsRequired.Checked) 
            {
                if (teErrorText.Text.Length == 0)
                {
                    teErrorText.ErrorText = "请输入标签";
                    chkIsRequired.Focus();
                    isValidated = false;
                }
            }
            return isValidated;
        }
    }
}