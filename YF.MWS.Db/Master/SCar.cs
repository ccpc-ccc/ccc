using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;
using YF.Utility;

namespace YF.MWS.Db
{
    /// <summary>
    /// 车辆信息表
    /// Author:仇军
    /// Date:2014-08-31
    /// </summary>
    public class SCar:BaseEntity
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public virtual string CarType { get; set; }

        [Field(IsSqliteIgnore =true)]
        public virtual string CarTypeName
        {
            get
            {
                return CarType.ToEnum<BaseMetadata.CarType>().ToDescription();
            }
        }
        /// <summary>
        /// 司机
        /// </summary>
        public virtual string DriverName { get; set; }
        /// <summary>
        /// 限载重量
        /// </summary>
        public virtual decimal LimitWeight { get; set; }
        /// <summary>
        /// 限制状态
        /// 0:不限制 1:限制
        /// </summary>
        public virtual int LimitState { get; set; }
        /// <summary>
        /// 车辆皮重
        /// </summary>
        public virtual decimal TareWeight { get; set; }
        /// <summary>
        /// 车辆毛重
        /// </summary>
        public virtual decimal GrossWeight { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public virtual string SupplierId { get; set; }
        /// <summary>
        /// 发货商ID
        /// </summary>
        public virtual string DeliveryId { get; set; }
        /// <summary>
        /// 收货商ID
        /// </summary>
        public virtual string ReceiverId { get; set; }
        /// <summary>
        /// 承运商ID
        /// </summary>
        public virtual string TransferId { get; set; }
        /// <summary>
        /// 生产商ID
        /// </summary>
        public virtual string ManufacturerId { get; set; }
        /// <summary>
        /// 物资ID
        /// </summary>
        public virtual string MaterialId { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public virtual string WarehId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Balance { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tell { get; set; }
        /// <summary>
        /// 人脸Id
        /// </summary>
        public virtual string WorkId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string LimitWeight2 { get; set; }
        public virtual decimal d1 { get; set; }
        public virtual decimal d2 { get; set; }
        public virtual decimal d3 { get; set; }
        public virtual string t1 { get; set; }
        public virtual string t2 { get; set; }
        public virtual string t3 { get; set; }
        public virtual string t4 { get; set; }
        public virtual string t5 { get; set; }
        public virtual string t6 { get; set; }
        public virtual string t7 { get; set; }
        public virtual string t8 { get; set; }
        public virtual string t9 { get; set; }

    }
}
