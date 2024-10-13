using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Metadata.Query
{
    public class PlanQuery : BaseQuery
    {
        public string CustomerId { get; set; }
        public string DeliveryId { get; set; }
        public string ReceiverId { get; set; }
        public string MaterialId { get; set; }
        public WarehBizType? WarehBiz { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
