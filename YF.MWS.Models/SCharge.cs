using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 收费配置
    /// </summary>
    public class SCharge : BaseEntity
    {
        public string? Operator { get; set; }
        public decimal? MinWeight { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? Charge { get; set; }
    }
}
