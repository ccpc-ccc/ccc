using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.MWS.Db {
    /// <summary>
    /// 磅单主表
    /// Author:闫孝感
    /// Date:2024-09-10
    /// </summary>
    public class VWeight : BWeight {
        /// <summary>
        /// 客户名称
        /// </summary>
        public virtual string CustomerName { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string CompanyName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public virtual string DeptName { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public virtual string SupplierName { get; set; }
        /// <summary>
        /// 发货商名称
        /// </summary>
        public virtual string DeliveryName { get; set; }
        /// <summary>
        /// 收货商名称
        /// </summary>
        public virtual string ReceiverName { get; set; }
        /// <summary>
        /// 承运商名称
        /// </summary>
        public virtual string TransferName { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        public virtual string MaterialName { get; set; }
        /// <summary>
        /// 生产商名称
        /// </summary>
        public virtual string ManufacturerName { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public virtual string WarehName { get; set; }
    }
}
