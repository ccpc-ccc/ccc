using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 模块定义信息
    /// Author:闫孝感
    /// Date:2024-08-31
    /// </summary>
    /// 
    [Serializable]
    public class SModule : BaseEntity
    {
        public virtual string ParentId { get; set; }
        public virtual string Platform { get; set; }
        public virtual string ModuleName { get; set; }
        public virtual string FullName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ModuleType { get; set; }
        public virtual string LinkUrl { get; set; }
        public virtual int OrderNo { get; set; }
        public virtual string Icon { get; set; }
        public virtual int SuperTipState { get; set; }
        public virtual string SuperTipContent { get; set; }
    }
}
