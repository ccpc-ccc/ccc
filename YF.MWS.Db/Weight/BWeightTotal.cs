using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单统计表
    /// Author:闫孝感
    /// Date:2024-09-10
    /// </summary>
    public class BWeightTotal : BaseEntity
    {
        public string CompanyId { get; set; }
        public decimal Weight { get; set; }
        public int Date { get; set; }
        public string MaterialId { get; set; }
    }
}
