using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 文件查询条件
    /// </summary>
    public class FileQueryCondition
    {
        public virtual string TableName { get; set; }
        public virtual string FileExtension { get; set; }
        public virtual string FileUrl { get; set; }
        public virtual int? MinFileSize { get; set; }
        public virtual int? MaxFileSize { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}