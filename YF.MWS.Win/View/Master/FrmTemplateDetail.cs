using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using System.Linq;
using YF.MWS.BaseMetadata;
using YF.Utility;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmTemplateDetail : DevExpress.XtraEditors.XtraForm
    {
        private List<Type> lstType = new List<Type>();
        private IReportService reportService = new ReportService();
        public string TemplateId { get; set; }
        public string ParentId { get; set; }

        public FrmTemplateDetail()
        {
            InitializeComponent();
        }

        private void FrmTemplateDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        { 
            //Assembly ass = Assembly.Load("MWS");
            //lstType = ass.GetTypes().ToList().FindAll(c => !string.IsNullOrEmpty(c.Namespace) && c.Namespace.EndsWith("YF.MWS.Win.Uc.Report"));
            //List<LookupField> lstField = new List<LookupField>();
            //lstField.Add(new LookupField() { FieldName = "Name", Caption = "名称" });
            ////SearchLookupUtil.BindData(lookUpSearchControl, lstType, "FullName", "Name", lstField);
            DxHelper.BindComboBoxEdit(combReportType, SysCode.SummaryReportType, null);
            if (!string.IsNullOrEmpty(ParentId))
            {
                SReportTemplate template = reportService.Get(ParentId);
            }
            if (!string.IsNullOrEmpty(TemplateId))
            {
                SReportTemplate template = reportService.Get(TemplateId);
                if (template != null)
                {
                    teTempateName.Text = template.TemplateName;
                    teOrderNo.Text = template.OrderNo.ToString();
                    memoDataSourceSql.Text = template.DataSourceSql;
                    DxHelper.BindComboBoxEdit(combReportType, SysCode.SummaryReportType, template.ReportType);
                    if (!string.IsNullOrEmpty(template.SubReportType)) 
                    {
                        DxHelper.BindComboBoxEdit(combSubReportType, template.ReportType + "SubReportType", template.SubReportType);
                    }
                }
            }
        }

        private bool ValidateSqlText(string sqlText) 
        {
            bool isValidated = true;
            if (!string.IsNullOrEmpty(sqlText)) 
            {
                if (sqlText.ToLower().Contains("delete") || sqlText.ToLower().Contains("truncate") 
                    || sqlText.ToLower().Contains("update") || sqlText.ToLower().Contains("insert")) 
                {
                    isValidated = false;
                }
            }
            return isValidated;
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (string.IsNullOrEmpty(TemplateId) && !string.IsNullOrEmpty(ParentId)) 
            {
                if (string.IsNullOrEmpty(beTemplateUrl.Text)) 
                {
                    beTemplateUrl.ErrorText = "请选择报表模板文件";
                    isValidated = false; 
                }
            }
            if (string.IsNullOrEmpty(teTempateName.Text)) 
            {
                teTempateName.ErrorText = "请输入报表模板名称";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                SReportTemplate template;
                if (!string.IsNullOrEmpty(TemplateId))
                {
                    template = reportService.Get(TemplateId);
                }
                else
                {
                    template = new SReportTemplate();
                    template.Id = YF.MWS.Util.Utility.GetGuid();
                    template.TemplateType = TemplateType.Report.ToString();
                }
                template.TemplateType = TemplateType.Report.ToString();
                if (!string.IsNullOrEmpty(beTemplateUrl.Text))
                {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        string fileName = string.Format(@"Report\Summary\{0}{1}", YF.MWS.Util.Utility.GetGuid(), Path.GetExtension(beTemplateUrl.Text));
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
                    else
                    {
                        template.TemplateContent = File.ReadAllBytes(beTemplateUrl.Text);
                    }
                }
                template.ReportType = DxHelper.GetCode(combReportType);
                template.SubReportType = DxHelper.GetCode(combSubReportType);
                template.ParentId = ParentId;
                template.TemplateName = teTempateName.Text;
                template.OrderNo = teOrderNo.Text.ToInt();
                template.DataSourceSql = memoDataSourceSql.Text;
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

        private void beTemplateUrl_Click(object sender, EventArgs e)
        {
            if (ofdReportTemplate.ShowDialog() == DialogResult.OK) 
            {
                beTemplateUrl.Text = ofdReportTemplate.FileName;
            }
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

        private void combReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combReportType.EditValue == null) return;
            SummaryReportType reportType = DxHelper.GetCode(combReportType).ToEnum<SummaryReportType>();
            if (reportType == SummaryReportType.Custom)
            {
                memoDataSourceSql.Enabled = true;
            }
            else 
            {
                memoDataSourceSql.Enabled = false;
            }
            DxHelper.BindComboBoxEdit(combSubReportType, reportType.ToString() + "SubReportType", null);
        }

    }
}