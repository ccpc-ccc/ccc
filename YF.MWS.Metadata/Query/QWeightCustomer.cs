using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Query
{
    public class QWeightCustomer
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public virtual string CompanyId { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual decimal NetWeightTotal { get; set; }

        public virtual int WeightCount { get; set; }

        public virtual string CustomerName { get; set; }

        public string CustomerId { get; set; }
    }
}
