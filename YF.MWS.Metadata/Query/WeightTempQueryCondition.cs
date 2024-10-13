using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    /// <summary>
    /// 临时磅单查询条件
    /// </summary>
    public class WeightTempQueryCondition
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StarTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public virtual string CompanyId { get; set; }
    }
}
