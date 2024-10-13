using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    public class BPayDetail
    {
        public virtual string Id { get; set; }
        public virtual string PayId { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string WeightId { get; set; }
    }
}
