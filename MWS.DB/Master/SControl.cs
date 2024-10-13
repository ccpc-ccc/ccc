using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 用户控件定义信息
    /// Author:yafyr
    /// Date:2014-11-11
    /// </summary>
    public class SControl:BaseEntity
    {
        public virtual string ControlName { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string FullName { get; set; }
        /// <summary>
        /// 操作名称,权限控制需要用到
        /// </summary>
        public virtual string ActionName { get; set; }
        public virtual string Caption { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public virtual string Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public virtual int AutoCalcNo { get; set; }
        public virtual string ErrorText { get; set; }
        public virtual int IsRequired { get; set; }
    }
}
