using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db.Server
{
    /// <summary>
    /// 服务器远程实体类
    /// </summary>
    public class FWeight {
        /// <summary>
        /// 产品类型 0－砂石，1－卵石  2 - 土
        /// </summary>
        public int category { get;set; }
        /// <summary>
        /// 开单员姓名，需要和系统一致
        /// </summary>
        public string billerName { get; set; }
        /// <summary>
        ///  开单地点
        /// </summary>
        public string billAddress { get; set; }
        /// <summary>
        ///  车牌号码
        /// </summary>
        public string plateNumber { get; set; }
        /// <summary>
        ///  实际载运吨
        /// </summary>
        public decimal actualLoad { get; set; }
        /// <summary>
        ///  采区名称，需要和系统一致
        /// </summary>
        public string miningAreaName { get; set; }
        /// <summary>
        ///  装运砂起始时间，格式 yyyy-MM-ddHH:mm:ss
        /// </summary>
        public DateTime transportStartTime { get; set; }
        /// <summary>
        /// 装运砂结束时间，格式 yyyy-MM-ddHH:mm:ss
        /// </summary>
        public DateTime transportEndTime { get; set; }
        /// <summary>
        ///  收货单位
        /// </summary>
        public string intendedArrivalHarbour { get; set; }
        /// <summary>
        ///  图片Base64数组，至少三张，最多九张
        /// </summary>
        public string[] documents { get; set; }
    }
}
