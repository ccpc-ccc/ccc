using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Query
{
    public class QCardViewDtl : SCardViewDtl
    {
        public string Caption { get; set; }
        public string ControlName { get; set; }
        public string FieldName { get; set; }
        public string FullName { get; set; }
        public int DecimalDigits { get; set; }
    }
}
