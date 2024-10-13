using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 收货单位车辆分组统计
    /// </summary>
    public class ReceiverCarGroupStatistics
    {
        /// <summary>
        /// 磅单数
        /// </summary>
        public int WeightCount { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal TareWeight { get; set; }
        public decimal SuttleWeight { get; set; }
        public string CarNo { get; set; }
        public string ReceiverName { get; set; }
    }
}
