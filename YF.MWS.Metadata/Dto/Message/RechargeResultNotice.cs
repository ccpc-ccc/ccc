using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Dto
{
    /// <summary>
    /// 充值结果通知
    /// </summary>
    public class RechargeResultNotice
    {
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal RechargeAmount { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime RechargeTime { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal BalanceAmount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 微信openId
        /// </summary>
        public string OpenId { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
    }
}
