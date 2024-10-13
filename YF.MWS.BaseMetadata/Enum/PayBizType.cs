using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 支付业务类别
    /// </summary>
    public enum PayBizType
    {
        /// <summary>
        /// 过磅收费
        /// </summary>
        /// 
        [Description("过磅收费")]
        Weight,
        /// <summary>
        /// 充值
        /// </summary>
        /// 
        [Description("充值")]
        Recharge,
        /// <summary>
        /// 扣款
        /// </summary>
        /// 
        [Description("扣款")]
        Deducte,
        /// <summary>
        /// 退款
        /// </summary>
        /// 
        [Description("退款")]
        Refund,
    }
}
