using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 文件查询条件
    /// </summary>
    public class MergeRepWithCarQueryCondition
    {
        public virtual string CarId { get; set; }    
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}