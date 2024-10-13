using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
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

namespace YF.MWS.Win.View.Master
{
    public partial class FrmViewDetail : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private List<SControl> lstControl = new List<SControl>();
        private SWeightViewDtl detail = null;
        private ControlType ctrlType= ControlType.Standard; 
        public string ViewId;

        public FrmViewDetail()
        {
            InitializeComponent();
        }

        private void FrmViewDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Save();
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
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
                detail.StayState = chkStartStay.Checked ? BoolValueType.True : BoolValueType.False;
                detail.AutoSaveState=chkStartAutoSave.Checked ? BoolValueType.True : BoolValueType.False;
                detail.RowState = chkRowState.Checked ? 2 : 3;
                detail.Show2 = chkShow2.Checked ? 1 : 0;
                detail.t1 = txtDefault.Text;
                bool canStay = CanStartStay(detail.FieldName);
                if (!canStay)
                    detail.StayState = BoolValueType.False;
                viewService.SaveViewDetail(detail);
                MessageDxUtil.ShowTips("成功保存界面控件信息.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存界面控件信息时发生未知错误,请重试.");
            }
        }

        private void BindData() 
        {
            lstControl = viewService.GetControlList();
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "ControlName", Caption = "名称" });
            SearchLookupUtil.BindData(lookupControl, lstControl,"Id", "ControlName", lstField);
            if (!string.IsNullOrEmpty(RecId)) 
            {
                detail = viewService.GetViewDetail(RecId);
                FormHelper.BindControl<SWeightViewDtl>(this, detail);
                lookupControl.Properties.ReadOnly = true;
                lookupControl.EditValue = detail.ControlId;
                chkIsRequired.Checked = detail.IsRequired == 1 ? true : false;
                chkReadonly.Checked = detail.Readonly == 1 ? true : false;
                chkStartAutoSave.Checked = detail.AutoSaveState == BoolValueType.True ? true : false;
                chkStartStay.Checked = detail.StayState == BoolValueType.True ? true : false;
                chkRowState.Checked=detail.RowState != 3 ? true :false;
                chkShow2.Checked = detail.Show2 == 1 ? true : false;
                txtDefault.Text = detail.t1;
            }
        }

        private void lookupControl_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupControl.EditValue != null && string.IsNullOrEmpty(RecId)) 
            {
                SControl control = viewService.GetControl(lookupControl.EditValue.ToString());
                FormHelper.BindControl<SControl>(this, control);
            }
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teControlName.Text.Length == 0)
            {
                teControlName.ErrorText = "请输入控件名称";
                isValidated = false;
            }
            if (chkIsRequired.Checked)
            {
                if (teErrorText.Text.Length == 0)
                {
                    teErrorText.ErrorText = "请输入标签";
                    isValidated = false;
                }
            }
            return isValidated;
        }

        private void teExpression_EditValueChanged(object sender, EventArgs e)
        {
            if (teExpression.Text.Length > 0) 
            {
                chkReadonly.Checked = true;
            }
        }
    }
}