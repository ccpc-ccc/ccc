using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 界面主题
    /// </summary>
    public class SAttributeSubject : BaseEntity
    {
        public virtual string SubjectName { get; set; }
        public virtual int SyncState { get; set; }
    }
}
