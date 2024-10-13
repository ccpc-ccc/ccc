using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Models
{
    /// <summary>
    /// 公司下的部门信息
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class S_Dept : BaseEntity
    {
        public string? ParentId { get; set; }
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? DeptName { get; set; }
        public string? DeptType { get; set; }
        public string? DeptCode { get; set; }
        public string? DeptTypeName { get; set; }
    }
}
