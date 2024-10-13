using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class CompanyQueryCondition
    {

        public virtual string Name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime StarTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public virtual DateTime EndTime { get; set; }
    }
}
