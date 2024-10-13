using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    public class BPay : BaseEntity
    {
        public virtual string PayNo { get; set; }
        public virtual string PayBizType { get; set; }
        public virtual string CarNo { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public virtual decimal PayAmount { get; set; }
        public virtual decimal BalanceAmount { get; set; }
        public virtual string RefId { get; set; }
        public virtual DateTime PayTime { get; set; }
        public virtual string DrawerName { get; set; }
        public virtual string DrawerId { get; set; }
        public virtual int PayType { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public virtual int PayState { get; set; }
        public virtual string Remark { get; set; }
    }
}
