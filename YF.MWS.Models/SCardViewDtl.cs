using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// IC卡对应的控件
    /// </summary>
    public class S_CardViewDtl:BaseEntity
    {
        public string? DetailId { get; set; }
        public string? ViewId { get; set; }
        public int? OrderNo { get; set; }
        public string? ControlId { get; set; }
    }
}
