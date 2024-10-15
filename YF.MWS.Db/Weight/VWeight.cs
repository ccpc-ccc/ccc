using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 磅单主表
    /// Author:闫孝感
    /// Date:2024-09-10
    /// </summary>
    public class VWeight:BWeight
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehName { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryName { get; set; }
        public string ReceiverName { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public string TransferName { get; set; }
    }
}
