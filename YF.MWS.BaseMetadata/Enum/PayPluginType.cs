using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 支付插件类型
    /// </summary>
    public enum PayPluginType
    {
        /// <summary>
        /// 未知支付
        /// </summary>
        /// 
        [Description("未知支付")]
        None = 0,
        /// <summary>
        /// 微信扫码支付
        /// </summary>
        /// 
        [Description("微信扫码支付")]
        WeiXinPayNative = 1,
        /// <summary>
        /// 微信付款码支付
        /// </summary>
        /// 
        [Description("微信付款码支付")]
        WeiXinPayMicro = 2,
        /// <summary>
        /// P云支付
        /// </summary>
        /// 
        [Description("P云支付")]
        PClound = 3,
        /// <summary>
        /// P云付款码支付
        /// </summary>
        /// 
        [Description("P云付款码支付")]
        PCloundMicro = 4,
        /// <summary>
        /// 泊链扫码支付
        /// </summary>
        /// 
        [Description("泊链扫码支付")]
        BoLink = 5,
        /// <summary>
        /// 泊链付款码支付
        /// </summary>
        /// 
        [Description("泊链付款码支付")]
        BoLinkMicro = 6
    }
}
