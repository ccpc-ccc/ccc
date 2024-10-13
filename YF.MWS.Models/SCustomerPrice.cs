using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    public class S_CustomerPrice : BaseEntity
    {
        public string? CustomerId { get; set; }
        public string? MaterialId { get; set; }
        public string? CustomerName { get; set; }
        public string? MaterialName { get; set; }
        public decimal? Price { get; set; }
    }
}
