using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 试用账号
    /// </summary>
    public class BTrialAccount
    {
        public virtual string Id { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public virtual string VersionCode { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string CorpName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Addr { get; set; }
        public virtual DateTime RegisiterTime { get; set; }
    }
}
