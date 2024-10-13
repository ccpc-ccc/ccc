using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 物资算法库
    /// Author:闫孝感
    /// Date:2024-08-31
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
