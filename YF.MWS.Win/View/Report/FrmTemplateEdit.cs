using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Report
{
    public partial class FrmTemplateEdit : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private IReportService reportService = new ReportService();
        private List<QWeightView> lstView = new List<QWeightView>();
        private SReportTemplate template = null;
        public FrmTemplateEdit()
        {
            InitializeComponent();
        }

        private void FrmTemplateEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            DxHelper.BindComboBoxEdit(combReportType, SysCode.DocumentType, null);
            lstView = viewService.GetViewList();
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "ViewName", Caption = "名称" });
            SearchLookupUtil.BindData(lookupView, lstView, "ViewId", "ViewName", lstField);
            if (!string.IsNullOrEmpty(RecId)) 
            {
                template = reportService.Get(RecId);
                if (template != null)
                {
                    FormHelper.BindControl<SReportTemplate>(this, template);
                    lookupView.EditValue = template.ViewId;
                    DxHelper.BindComboBoxEdit(combReportType, SysCode.DocumentType, template.ReportType);
                    teTempateName.Text = template.TemplateName;
                }
            }
        }

        private void Save() 
        {
            try
            {
                if (template == null) 
                {
                    template = new SReportTemplate();
                    template.Id = YF.MWS.Util.Utility.GetGuid();
                    template.TemplateType = TemplateType.Document.ToString();
                }

                if (!string.IsNullOrEmpty(beTemplateUrl.Text))
                {
                        string fileName = string.Format(@"Report\Weight\{0}{1}", YF.MWS.Util.Utility.GetGuid(), Path.GetExtension(beTemplateUrl.Text));
                        if (!string.IsNullOrEmpty(template.TemplateUrl))
                        {
                            fileName = template.TemplateUrl;
                        }
                        else
                        {
                            template.TemplateUrl = fileName;
                        }
                        string fileCopyedPath = Path.Combine(Application.StartupPath, fileName);
                        File.Copy(beTemplateUrl.Text, fileCopyedPath, true);
                }
                template.TemplateName = teTempateName.Text;
                template.ViewId = lookupView.EditValue.ToObjectString();
                template.ReportType = DxHelper.GetCode(combReportType);
                reportService.Save(template);
                MessageDxUtil.ShowTips("成功保存报表模板.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存报表模板过程中发生未知错误,请重试.");
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (lookupView.EditValue == null) 
            {
                isValidated = false;
                lookupView.ErrorText = "界面类型不能为空";
            }
            if (combReportType.SelectedItem == null) 
            {
                isValidated = false;
                combReportType.ErrorText = "单据类别不能为空";
            }
            if (teTempateName.Text.Length == 0) 
            {
                isValidated = false;
                teTempateName.ErrorText = "模板名称不能为空";
            }
            if (string.IsNullOrEmpty(RecId) && beTemplateUrl.Text.Length == 0) 
            {
                isValidated = false;
                beTemplateUrl.ErrorText = "模板文件不能为空";
            }
            return isValidated;
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                Save();
            }
        }

        private void beTemplateUrl_Click(object sender, EventArgs e)
        {
            if (ofdReportTemplate.ShowDialog() == DialogResult.OK) 
            {
                beTemplateUrl.Text = ofdReportTemplate.FileName;
            }
        }
    }
}