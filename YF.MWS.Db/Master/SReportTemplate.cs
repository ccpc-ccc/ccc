using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单报表模板定义
    ///Author:仇军 
    /// Date:2014-11-02
    /// </summary>
    public class SReportTemplate:BaseEntity
    {
        public virtual string ParentId { get; set; }
        public virtual string TemplateType { get; set; }
        public virtual string ReportType { get; set; }
        public virtual string SubReportType { get; set; }
        public virtual string TemplateName { get; set; }
        public virtual string TemplateUrl { get; set; }
        public virtual string ViewId { get; set; }
        public virtual byte[] TemplateContent { get; set; }
        /// <summary>
        /// 报表对应的查询控件
        /// </summary>
        public virtual string SearchControl { get; set; }

        public virtual int IsDefault { get; set; }

        public virtual int OrderNo { get; set; }

        public virtual string DataSourceSql { get; set; }
    }
}
