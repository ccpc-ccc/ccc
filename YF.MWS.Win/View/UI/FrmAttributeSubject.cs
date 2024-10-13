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
    public partial class FrmAttributeSubject : BaseForm
    {
        private IAttributeService attributeService = new AttributeService();
        private SAttributeSubject attrSubject;
        public FrmAttributeSubject()
        {
            InitializeComponent();
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

        private void FrmAttributeSubject_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (teSubjectName.Text.Length == 0) 
            {
                teSubjectName.ErrorText = "请输入分类名称";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (attrSubject == null)
                {
                    attrSubject = new SAttributeSubject();
                    attrSubject.Id = YF.MWS.Util.Utility.GetGuid();
                }
                FormHelper.ControlToEntity<SAttributeSubject>(this, ref attrSubject);
                attributeService.SaveSubject(attrSubject);
                MessageDxUtil.ShowTips("成功保存扩展控件分类信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存扩展控件分类信息时发生未知错误,请重试.");
            }

        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                attrSubject = attributeService.GetSubject(RecId);
                FormHelper.BindControl<SAttributeSubject>(this, attrSubject);
            }
        }
    }
}