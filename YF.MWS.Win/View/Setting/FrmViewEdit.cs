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
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View
{
    public partial class FrmViewEdit : BaseForm
    {
        private IAttributeService attributeService = new AttributeService();
        private IWeightViewService viewService = new WeightViewService();
        private SWeightView view = null;
        private List<SAttributeSubject> lstSubject = new List<SAttributeSubject>();
        public FrmViewEdit()
        {
            InitializeComponent();
        }

        private void FrmViewEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemSave_ItemClick(object sender,ItemClickEventArgs e)
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

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (lookupSubject.EditValue == null || lookupSubject.EditValue.ToObjectString().Length==0)
            {
                isValidated = false;
                lookupSubject.ErrorText = "行业分类不能为空";
            }
            if (teViewName.Text.Length == 0) 
            {
                isValidated = false;
                teViewName.ErrorText = "界面名称不能为空";
            }
            if (comboViewType.EditValue == null) 
            {
                isValidated = false;
                comboViewType.ErrorText = "界面类别不能为空";
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                if (view == null)
                {
                    view = new SWeightView();
                    view.Id = YF.MWS.Util.Utility.GetGuid();
                }
                FormHelper.ControlToEntity<SWeightView>(this, ref view);
                view.SubjectId = lookupSubject.EditValue.ToObjectString();
                view.ViewType = DxHelper.GetCode(comboViewType);
                viewService.SaveView(view);
                MessageDxUtil.ShowTips("成功保存界面信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存界面信息时发生未知错误,请重试.");
            }
        }

        private void BindData() 
        {
            lstSubject = attributeService.GetSubjectList();
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "SubjectName", Caption = "名称" });
            SearchLookupUtil.BindData(lookupSubject, lstSubject, "SubjectId", "SubjectName", lstField);
            DxHelper.BindComboBoxEdit(comboViewType, SysCode.ViewType, null);
            if (!string.IsNullOrEmpty(RecId)) 
            {
                view = viewService.GetView(RecId);
                FormHelper.BindControl<SWeightView>(this, view);
                lookupSubject.EditValue = view.SubjectId;
                lookupSubject.Enabled = false;
                DxHelper.BindComboBoxEdit(comboViewType, SysCode.ViewType, view.ViewType);
            }
        }
    }
}