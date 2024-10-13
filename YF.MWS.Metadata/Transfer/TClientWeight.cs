using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TClientWeight
    {
        /// <summary>
        /// 磅单ID
        /// </summary>
        public string WeightId { get; set; }
        /// <summary>
        /// 视图ID
        /// </summary>
        public string ViewId { get; set; }
        /// <summary>
        /// 磅单号
        /// </summary>
        public string WeightNo { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 皮重
        /// </summary>
        public decimal TareWeight { get; set; }
        /// <summary>
        /// 毛重
        /// </summary>
        public decimal GrossWeight { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal SuttleWeight { get; set; }
        /// <summary>
        /// 实重
        /// </summary>
        public decimal NetWeight { get; set; }
        /// <summary>
        /// 磅单完成日期
        /// </summary>
        public DateTime FinishTime { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }
        public string CompanyName { get; set; }

        public DateTime StartTime { get; set; }
    }
}
