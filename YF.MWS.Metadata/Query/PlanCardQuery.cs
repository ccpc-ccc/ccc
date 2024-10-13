using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    public class PlanCardQuery : BaseQuery
    {
        public string DeptId { get; set; }
        public string MaterialId { get; set; }
        public string CustomerId { get; set; }
        public string ReceiverId { get; set; }
        public string DeliveryId { get; set; }
    }
}
