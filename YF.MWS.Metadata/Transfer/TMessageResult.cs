using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Transfer
{
    public class TMessageResult
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int TotalPage { get; set; }
        public int Count { get; set; }
        public List<TMessage> Rows { get; set; }
    }
}
