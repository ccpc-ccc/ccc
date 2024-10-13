using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    /// <summary>
    /// 物资算法库
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SAlgLibary:BaseEntity
    {
        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 换算系数
        /// </summary>
        public virtual decimal Factor { get; set; }
        /// <summary>
        /// 正偏差
        /// </summary>
        public virtual decimal PDeviation { get; set; }
        /// <summary>
        /// 负偏差
        /// </summary>
        public virtual decimal NDeviation { get; set; }
        public virtual int State { get; set; }
    }
}
