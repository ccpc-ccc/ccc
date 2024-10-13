using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 公司下的部门信息
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SDept : BaseEntity
    {
        public virtual string ParentId { get; set; }
        public virtual string CompanyId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string DeptName { get; set; }
        public virtual string DeptType { get; set; }
        public virtual string DeptCode { get; set; }
        public virtual string DeptTypeName { get; set; }
    }
}
