using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IStatementService
    {
        bool InitReportDate();
        DataSet GetCarStatement(List<SCar> cars, DateTime startTime, DateTime endTime);
        DataSet GetDocumentData(DocumentType type,string id);
        DataSet GetDocumentDesignResource(DocumentType type);
        DataSet GetSummaryData(SummaryReportType type, PageQueryCondition qc);
        DataSet GetCustomSummaryDesignResource(SReportTemplate template);
        DataSet GetSummaryDesignResource(SummaryReportType type);
        /// <summary>
        /// 获取磅单统计报表设计数据源
        /// </summary>
        /// <param name="subType"></param>
        /// <returns></returns>
        DataTable GetWeightDesignDataSource(WeightSubReportType subType);
        DataTable GetWeightDataSource(WeightSubReportType subType, WeightQueryCondition qc);
    }
}
