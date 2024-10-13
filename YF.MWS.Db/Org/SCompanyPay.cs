using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 公司信息：指的是使用该称重系统的公司
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    public class SCompanyPay : BaseEntity
    {
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 续费次数（时长）
        /// </summary>
        public virtual int Quantity { get; set; }
    }
}
