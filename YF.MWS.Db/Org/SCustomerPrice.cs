using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class SCustomerPrice : BaseEntity
    {
        public virtual string CustomerId { get; set; }
        public virtual string MaterialId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string MaterialName { get; set; }
        public virtual decimal Price { get; set; }
    }
}
