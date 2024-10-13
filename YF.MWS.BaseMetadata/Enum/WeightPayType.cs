using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 磅单支付方式
    /// </summary>
    public enum WeightPayType
    {
        /// <summary>
        /// 现金
        /// </summary>
        /// 
        [Description("现金")]
        Cash = 0,
        /// <summary>
        /// 余额
        /// </summary>
        /// 
        [Description("余额")]
        Balance = 1,
        /// <summary>
        /// 赊销
        /// </summary>
        /// 
        [Description("赊销")]
        Credit = 2,
        /// <summary>
        /// 在线支付
        /// </summary>
        /// 
        [Description("在线支付")]
        OnLine = 3
    }
}
