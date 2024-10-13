using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.Query
{
    public class QSeqNo : SSeqNo
    {
        public virtual string SeqCodeCaption { get; set; }
    }
}
