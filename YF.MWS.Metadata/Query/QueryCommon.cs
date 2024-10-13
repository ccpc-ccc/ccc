using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    /// <summary>
    /// 常用的查询条件
    /// </summary>
    public class QueryCommon
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }

        public virtual string CustomerId { get; set; }
        /// <summary>
        /// 物资ID
        /// </summary>
        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public virtual string CompanyId { get; set; }

        /// <summary>
        /// 机器码
        /// </summary>
        public virtual string MachineCode { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StarTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

    }
}
