using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayState
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        /// 
        [Description("未知状态")]
        None=-1,
        /// <summary>
        /// 待支付
        /// </summary>
        /// 
        [Description("待支付")]
        WaitingPay = 0,
        /// <summary>
        /// 支付成功
        /// </summary>
        /// 
        [Description("支付成功")]
        PaySuccess = 1,
        /// <summary>
        /// 支付失败
        /// </summary>
        /// 
        [Description("支付失败")]
        PayFailed = 2,
        /// <summary>
        /// 支付中
        /// </summary>
        /// 
        [Description("支付中")]
        Paying = 3
    }
}
