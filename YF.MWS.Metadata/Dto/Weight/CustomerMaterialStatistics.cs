using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 客户物资统计
    /// </summary>
    public class CustomerMaterialStatistics
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal NetWeight { get; set; }
        public string MaterialName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal SuttleWeight { get; set; }
        public decimal TareWeight { get; set; }
        public int WeightCount { get; set; }
        /// <summary>
        /// 磅单收费
        /// </summary>
        public decimal RegularCharge { get; set; }
    }
}
