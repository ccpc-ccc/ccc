using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    public enum CustomerType
    {
        /// <summary>
        /// 客户单位
        /// </summary>
        /// 
        [Description("客户单位")]
        Customer,
        /// <summary>
        /// 发货单位
        /// </summary>
        /// 
        [Description("发货单位")]
        Delivery,
        /// <summary>
        /// 生产单位
        /// </summary>
        /// 
        [Description("生产单位")]
        Manufacturer,
        /// <summary>
        /// 收货单位
        /// </summary>
        /// 
        [Description("收货单位")]
        Receiver,
        /// <summary>
        /// 供货单位
        /// </summary>
        /// 
        [Description("供货单位")]
        Supplier,
        /// <summary>
        /// 承运单位
        /// </summary>
        /// 
        [Description("承运单位")]
        Transfer
    }
}
