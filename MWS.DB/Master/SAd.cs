using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.ECS.Db
{
    /// <summary>
    /// 推送广告
    /// Author:yafyr
    /// Date:2015-02-28
    /// </summary>
    public class SAd:BaseEntity
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 静态Html的路径
        /// </summary>
        public virtual string AdUrl { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        public virtual string AdTitle{ get; set; }
        /// <summary>
        /// 广告内容
        /// </summary>
        public virtual string AdContent { get; set; }
        /// <summary>
        /// 一周内那几天播放，中间用";"分隔，例如：1;3;5
        // Sunday = 0
        //Monday = 1
        //Tuesday = 2
        //Wednesday = 3,
        //Thursday = 4,
        //Friday = 5,
        //Saturday = 6,
        /// </summary>
        public virtual string Weeks { get; set; }
        /// <summary>
        /// 程序启动几小时后开始播放广告
        /// </summary>
        public virtual int Hours { get; set; }
    }
}
