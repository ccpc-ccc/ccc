using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Screen
{
    /// <summary>
    /// 重量稳定时LED显示设置
    /// </summary>
    public class ShowWeightStableCfg
    {
        /// <summary>
        /// 是否显示毛重
        /// </summary>
        public bool ShowGrossWeight { get; set; }
        /// <summary>
        /// 是否显示皮重
        /// </summary>
        public bool ShowTareWeight { get; set; }
        /// <summary>
        /// 是否显示净重
        /// </summary>
        public bool ShowSuttleWeight { get; set; }
        /// <summary>
        /// 是否显示车牌
        /// </summary>
        public bool ShowCarNo { get; set; }
        /// <summary>
        /// 是否显示客户
        /// </summary>
        public bool ShowCustomer { get; set; }
        /// <summary>
        /// 是否显示客户余额
        /// </summary>
        public bool ShowCustomerBalance { get; set; }
        /// <summary>
        /// 是否显示物资
        /// </summary>
        public bool ShowMaterial { get; set; }
        /// <summary>
        /// 是否显示发货单位
        /// </summary>
        public bool ShowDeliver { get; set; }
        /// <summary>
        /// 是否显示收货单位
        /// </summary>
        public bool ShowReceiver { get; set; }
        public bool ShowPayAmount { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int DecimalDigit { get; set; }

    }
}
