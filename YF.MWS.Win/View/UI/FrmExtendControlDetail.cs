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

namespace YF.MWS.Win.View.UI
{
    public partial class FrmExtendControlDetail : BaseForm
    {
        private IAttributeService attributeService = new AttributeService();
        private SAttribute attr = null;
        private string subjectId;

        public string SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        public FrmExtendControlDetail()
        {
            InitializeComponent();
        }

        private void FrmExtendControlDetail_Load(object sender, EventArgs e)
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

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (teControlName.Text.Length == 0) 
            {
                teControlName.ErrorText = "请输入属性名称";
                isValidated = false;
            }
            if (combWeightExtendControl.EditValue == null) 
            {
                combWeightExtendControl.ErrorText = "请选择控件类型";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                if (attr == null)
                {
                    attr = new SAttribute();
                    attr.Id = YF.MWS.Util.Utility.GetGuid();
                }
                attr.SubjectId = subjectId;
                attr.AttributeName = teControlName.Text;
                attr.FieldName = teFieldName.Text;
                attr.FullName = DxHelper.GetCode(combWeightExtendControl);
                attributeService.SaveAttribute(attr);
                MessageDxUtil.ShowTips("成功保存扩展控件信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            { 
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存扩展控件信息时发生未知错误,请重试.");
            }
        }

        private void BindData() 
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                attr = attributeService.GetAttribute(RecId);
                if (attr != null)
                {
                    teControlName.Text = attr.AttributeName;
                    teFieldName.Text = attr.FieldName;
                    DxHelper.BindComboBoxEdit(combWeightExtendControl, SysCode.WeightControl, attr.FullName);
                }
                else 
                {
                    DxHelper.BindComboBoxEdit(combWeightExtendControl, SysCode.WeightControl, null);
                }
            }
            else 
            {
                DxHelper.BindComboBoxEdit(combWeightExtendControl, SysCode.WeightControl, null);
            }
        }
    }
}