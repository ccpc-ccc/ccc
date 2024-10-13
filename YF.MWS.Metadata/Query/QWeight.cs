using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.Utility;

namespace YF.MWS.Metadata.Query
{
    /// <summary>
    /// 称重查询结果实体类
    /// </summary>
    public class QWeight:BWeight
    {
        #region Extends

        /// <summary>
        /// 物资名称
        /// </summary>
        public string MaterialName { get; set; } 
        /// <summary>
        /// 客户单位名称
        /// </summary>
        public  string CustomerName { get; set; }
        /// <summary>
        /// 收货单位名称
        /// </summary>
        public  string ReceiverName { get; set; }
        /// <summary>
        /// 发货单位名称
        /// </summary>
        public  string DeliverName { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehName { get; set; }
        /// <summary>
        /// 司磅员
        /// </summary>
        public  string Weighter { get; set; }

        public DateTime TareWeightTime { get; set; }

        public DateTime GrossWeightTime { get; set; }
        /// <summary>
        /// 终端Id
        /// </summary>
        public string ClientId { get; set; }
        public new DateTime? CreateTime { get; set; } 
        public new DateTime? UpdateTime { get; set; }
        public List<BFile> files { get; set; }
        #endregion
    }
}
