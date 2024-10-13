using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 系统编码实体类
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class S_Code : BaseEntity
    {
        public string? ParentId { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemCaption { get; set; }
        public string? ItemValue { get; set; }
        public int? SystemFlag { get; set; }
        public int? OrderNo { get; set; }
    }
}
