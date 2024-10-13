using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.ECS.Db.Server
{
    /// <summary>
    /// 服务器远程实体类
    /// </summary>
    public class FWeight {
        public string id{get;set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carNo { get; set; }
        /// <summary>
         ///  榜单号
         /// </summary>
        public string weightNo { get; set; }
        /// <summary>
         ///  物料名称
          /// </summary>
        public string materialName { get; set; }
        /// <summary>
         ///  发货单位
          /// </summary>
        public string startDeliver { get; set; }
        /// <summary>
         ///  收货仓库
         /// </summary>
        public string endDeliver { get; set; }
        /// <summary>
         ///  订单状态 0、未使用 1、使用中  2、已完成
         /// </summary>
        public int state { get; set; }
        /// <summary>
         ///  数据状态 0、正常   -1、删除
         /// </summary>
        public int rowState { get; set; }
        /// <summary>
         ///  客户Id
         /// </summary>
        public string clientId { get; set; }
        /// <summary>
         ///  皮重
         /// </summary>
        public decimal tareWeight { get; set; }
        /// <summary>
         ///  毛重
         /// </summary>
        public decimal grossWeight { get; set; }
        /// <summary>
         ///  过皮时间
         /// </summary>
        public long tareTime { get; set; }
        /// <summary>
         ///  过毛时间
         /// </summary>
        public long grossTime { get; set; }
        /// <summary>
         ///  净重
         /// </summary>
        public decimal netWeight { get; set; }
        public long createTime { get; set; }
        public int createBy { get; set; }

        public long delTime { get; set; }
        public int version { get; set; }

    }
}
