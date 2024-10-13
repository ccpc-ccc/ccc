using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata
{
    public class CodeTree : SCode
    {
        public virtual List<SCode> children { get; set; }

        public virtual bool status { get; set; }
    }
}
