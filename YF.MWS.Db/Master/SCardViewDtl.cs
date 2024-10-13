using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// IC卡对应的控件
    /// </summary>
    public class SCardViewDtl:BaseEntity
    {
        public virtual string DetailId { get; set; }
        public virtual string ViewId { get; set; }
        public virtual int OrderNo { get; set; }
        public virtual string ControlId { get; set; }
    }
}
