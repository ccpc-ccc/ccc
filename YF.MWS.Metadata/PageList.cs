using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    public class PageList<T>
    {
        public List<T> Models { get; set; }
        public int Total { get; set; }
    }
}
