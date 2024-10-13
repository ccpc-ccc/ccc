using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
namespace YF.MWS.Models
{
    /// <summary>
    /// 磅单报表模板定义
    ///Author:仇军 
    /// Date:2014-11-02
    /// </summary>
    public class S_ReportTemplate:BaseEntity
    {
        public string? ParentId { get; set; }
        public string? TemplateType { get; set; }
        public string? ReportType { get; set; }
        public string? SubReportType { get; set; }
        public string? TemplateName { get; set; }
        public string? TemplateUrl { get; set; }
        public string? ViewId { get; set; }
        public byte[]? TemplateContent { get; set; }
        /// <summary>
        /// 报表对应的查询控件
        /// </summary>
        public string? SearchControl { get; set; }

        public int? IsDefault { get; set; }

        public int? OrderNo { get; set; }

        public string? DataSourceSql { get; set; }
    }
}
