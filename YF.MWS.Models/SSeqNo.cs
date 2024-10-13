using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    public class SSeqNo : BaseEntity
    {
        public string? Prefix { get; set; }
        public string? DateFomart { get; set; }
        public int? FixedLen { get; set; }
        public string? CurrentDate { get; set; }
        public int? RuningNo { get; set; }
        public string? SeqCode { get; set; }
    }
}
