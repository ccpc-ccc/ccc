using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models {
    /// <summary>
    /// 界面主题
    /// </summary>
    public class S_AttributeSubject : BaseEntity
    {
        public string? SubjectName { get; set; }
        public int? SyncState { get; set; }
    }
}
