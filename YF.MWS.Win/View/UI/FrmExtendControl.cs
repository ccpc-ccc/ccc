using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmExtendControl : DevExpress.XtraEditors.XtraForm
    {
        private List<SAttributeSubject> lstSubject = new List<SAttributeSubject>();
        private List<SAttribute> lstAttribute = new List<SAttribute>();
        private GridCheckMarksSelection chkSubject;
        private GridCheckMarksSelection chkAttribute;
        private string currentSubjectId;
        private IAttributeService attributeService = new AttributeService();

        public FrmExtendControl()
        {
            InitializeComponent();
        }

        private void BindData() 
        {
            lstSubject = attributeService.GetSubjectList();
            gcSubjectList.DataSource = lstSubject;
            if (chkSubject == null)
                chkSubject = new GridCheckMarksSelection(gvSubjectList);
            chkSubject.ClearSelection();
        }

        private void BindAttribute(string subjectId) 
        {
            lstAttribute = attributeService.GetAttributeList(subjectId);
            gcAttribute.DataSource = lstAttribute;
            if (chkAttribute == null)
                chkAttribute = new GridCheckMarksSelection(gvAttribute);
            chkAttribute.ClearSelection();
        }

        private void barItemNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmAttributeSubject frmEdit = new FrmAttributeSubject()) 
            {
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void barItemAddControl_ItemClick(object sender, ItemClickEventArgs e)
        { 
            using (FrmExtendControlDetail frmEdit = new FrmExtendControlDetail()) 
            {
                frmEdit.SubjectId = currentSubjectId;
                if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    BindAttribute(currentSubjectId);
                }
            }
        }

        private void gvSubjectList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvSubjectList.GetFocusedRow() != null) 
            {
                SAttributeSubject subject = (SAttributeSubject)gvSubjectList.GetFocusedRow();
                if (subject != null) 
                {
                    currentSubjectId = subject.Id;
                    BindAttribute(currentSubjectId);
                }
            }
        }

        private void barItemEditControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvAttribute.GetFocusedRow() != null) 
            {
                SAttribute attr = (SAttribute)gvAttribute.GetFocusedRow();
                if (attr != null)
                {
                    using (FrmExtendControlDetail frmEdit = new FrmExtendControlDetail())
                    {
                        frmEdit.RecId = attr.Id;
                        frmEdit.SubjectId = currentSubjectId;
                        if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            BindAttribute(currentSubjectId);
                        }
                    }
                }
            }
        }

        private void btnItemModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentSubjectId))
            {
                using (FrmAttributeSubject frmEdit = new FrmAttributeSubject())
                {
                    frmEdit.RecId = currentSubjectId;
                    if (frmEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void FrmExtendControl_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void barItemDeleteControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkAttribute.GetSelectedRow() == null || chkAttribute.GetSelectedRow().Count == 0)
            {
                MessageDxUtil.ShowWarning("请选择要删除的扩展控件.");
            }
            else 
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要删除所选择的扩展控件吗?") == DialogResult.Yes) 
                {
                    List<object> lstObj = chkAttribute.GetSelectedRow();
                    SAttribute attr = null;
                    foreach (object obj in lstObj) 
                    {
                        attr = (SAttribute)obj;
                        attributeService.DeleteAttribute(attr.Id);
                    }
                    BindAttribute(currentSubjectId);
                }
            }
        }

        private void barItemDeleteSubject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvSubjectList.GetFocusedRow() != null) 
            {
                SAttributeSubject subject = (SAttributeSubject)gvSubjectList.GetFocusedRow();
                string message=string.Format("确实要删除所选择的扩展控件分类({0})吗?",subject.SubjectName);
                if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) 
                {
                    bool isDelete=attributeService.DeleteSubject(subject.Id);
                    if (!isDelete)
                    {
                        MessageDxUtil.ShowWarning("删除失败:该扩展控件分类下有对应的扩展控件没有被删除,请先删除!");
                    }
                    else
                    {
                        BindData();
                    }
                }
            }
        }
    }
}