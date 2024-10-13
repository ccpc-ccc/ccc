using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 仓库业务类别
    /// </summary>
    public enum WarehBizType
    {
        /// <summary>
        /// 销售出库(发货)
        /// </summary>
        /// 
        [Description("入库")]
        RuKu = 0,
        /// <summary>
        /// 采购入库(收货)
        /// </summary>
        /// 
        [Description("出库")]
        ChuKu = 1,
        /// <summary>
        /// 内部转运
        /// </summary>
        /// 
        [Description("内部转运")]
        Transfer = 2,
        /// <summary>
        /// 其他
        /// </summary>
        /// 
        [Description("其他")]
        Other = 3
    }
}
