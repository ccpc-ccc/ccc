using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class BaseResult
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int TotalPage { get; set; }
        public int Count { get; set; }
        public object Rows { get; set; }
    }
}
