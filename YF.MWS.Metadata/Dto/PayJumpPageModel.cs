using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Dto
{
    /// <summary>
    /// 支付页返回模板
    /// </summary>
    public class PayJumpPageModel
    {
        /// <summary>
        /// 支付插件ID
        /// </summary>
        public string PaymentId { get; set; }
        public string OrderIds { get; set; }
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 支付流水号
        /// </summary>
        public long PayRecordNo { get; set; }
        public UrlType UrlType { get; set; }
        public string RequestUrl { get; set; }

        /// <summary>
        /// 是否出错
        /// </summary>
        public bool IsError { get; set; }

        public string ErroMsg { set; get; }
    }
}
