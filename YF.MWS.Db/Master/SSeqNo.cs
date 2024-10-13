using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class SSeqNo : BaseEntity
    {
        public virtual string Prefix { get; set; }
        public virtual string DateFomart { get; set; }
        public virtual int FixedLen { get; set; }
        public virtual string CurrentDate { get; set; }
        public virtual int RuningNo { get; set; }
        public virtual string SeqCode { get; set; }
    }
}
