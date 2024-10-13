using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    public class S_Wareh : BaseEntity
    {
        public string? CompanyId { get; set; }
        public string? WarehCode { get; set; }
        public string? WarehName { get; set; }
        public string? Location { get; set; }
    }
}
