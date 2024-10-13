using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 客户信息：公司的客户
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class S_Customer : BaseEntity
    {
        public string? CustomerCode { get; set; }
        public string? CompanyId { get; set; }
        public string? MachineCode { get; set; }
        public string? CustomerType { get; set; }
        public string? CustomerName { get; set; }
        public string? PYCustomerName { get; set; }
        public string? LogoUrl { get; set; }
        public string? Contracter { get; set; }
        public string? IdCard { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal? RechargeAmount { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal? PayAmount { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal? BalanceAmount { get; set; }
        /// <summary>
        /// 最低余额
        /// </summary>
        public decimal? MinBalanceAmount { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string? Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string? Account { get; set; }
        public string? Addr { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Remark { get; set; }

        public int? SyncState { get; set; }
    }
}
