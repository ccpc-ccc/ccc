using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 称重界面视图
    /// Author:yafyr
    /// Date:2014-11-11
    /// </summary>
    public class SWeightView:BaseEntity
    {
        [Field(IsSqliteIgnore=true)]
        public virtual string CompanyId { get; set; }  //服务端特有字段
        [Field(IsSqliteIgnore = true)]
        public virtual string MachineCode { get; set; }  //服务端特有字段

        public virtual string SubjectId { get; set; }
        public virtual string ViewName { get; set; } 
        /// <summary>
        /// 列数
        /// </summary>
        public virtual int ColumnsCount { get; set; }
        public virtual int IsDefault { get; set; }
        public virtual string ViewType { get; set; }
    }
}
