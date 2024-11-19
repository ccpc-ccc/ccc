using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IReportService
    {
        bool Delete(string templateId);
        SReportTemplate Get(string templateId); 
        SReportTemplate GetDefaultTemplate(DocumentType type);
        DataSet GetFinance(string viewId, string weightId);
        DataSet GetWeight(string viewId,int total, string weightId="");
        DataSet GetWeightSearch(string viewId, WeightQueryCondition qc);
        DataSet GetWeightSearch(string viewId, string condition, string conditionTareTime, string conditionGrossTime, List<QueryCondition> lstExtendCondition, QPage page);
        List<QReportTemplate> GetTemplateList(TemplateType type);
        List<QReportTemplate> GetTemplateList(TemplateType type, string reportType);
        bool Save(SReportTemplate template);
        void SetDefault(string reportId,DocumentType type);
        bool UpdateDefaultView(string viewId);
    }
}
