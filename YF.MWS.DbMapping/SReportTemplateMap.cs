using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using YF.MWS.Db;

namespace YF.MWS.DbMapping
{
    public class SReportTemplateMap:ClassMap<SReportTemplate>
    {
        public SReportTemplateMap() 
        {
            Table("S_ReportTemplate");
            Id(m => m.Id);
            Map(m => m.CreaterId).Not.Update();
            Map(m => m.CreateTime).Not.Update();
            Map(m => m.ParentId);
            Map(m => m.TemplateContent).CustomType("BinaryBlob");
            Map(m => m.TemplateName);
            Map(m => m.OrderNo);
            Map(m => m.DataSourceSql);
            Map(m => m.ReportType);
            Map(m => m.SubReportType);
            Map(m => m.TemplateType);
            Map(m => m.RowState);
            Map(m => m.TemplateUrl);
            Map(m => m.UpdaterId);
            Map(m => m.UpdateTime);
            Map(m => m.ViewId);
        }
    }
}
