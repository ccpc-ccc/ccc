using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 客户信息：公司的客户
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class SCustomer : BaseEntity
    {
        public virtual string CustomerCode { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string MachineCode { get; set; }
        public virtual string CustomerType { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string PYCustomerName { get; set; }
        public virtual string LogoUrl { get; set; }
        public virtual string Contracter { get; set; }
        public virtual string IdCard { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public virtual decimal RechargeAmount { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public virtual decimal PayAmount { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public virtual decimal BalanceAmount { get; set; }
        /// <summary>
        /// 最低余额
        /// </summary>
        public virtual decimal MinBalanceAmount { get; set; }
        [Field(IsSqliteIgnore=true)]
        public virtual bool BalanceWarn
        {
            get
            {
                bool warn = false;
                BaseMetadata.CustomerType customerType = CustomerType.ToEnum<BaseMetadata.CustomerType>();
                if (customerType == BaseMetadata.CustomerType.Customer && MinBalanceAmount > BalanceAmount && MinBalanceAmount > 0)
                    warn = true;
                return warn;
            }
        }
        /// <summary>
        /// 开户行
        /// </summary>
        public virtual string Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public virtual string Account { get; set; }
        public virtual string Addr { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual string Remark { get; set; }

        public virtual int SyncState { get; set; }
        [Field(IsSqliteIgnore=true)]
        public virtual string RowStateName 
        {
            get 
            {
                return RowState.ToEnum<BaseMetadata.RowState>().ToDescription();
            }
        }
    }
}
