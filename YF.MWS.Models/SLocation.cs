using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Models
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class S_Location : BaseEntity
    {
        public string? LocationType { get; set; }
        public string? ValidateInput { get; set; }
        public string? CompanyId { get; set; }
        public string? LocationCode { get; set; }
        public string? LocationName { get; set; }
    }
}
