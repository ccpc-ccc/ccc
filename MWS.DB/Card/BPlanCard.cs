using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Metadata;

namespace YF.ECS.Db
{
    /// <summary>
    /// IC计划卡信息
    /// Author:闫孝感
    /// Date:2023-10-14
    /// </summary>
    public class BPlanCard : BaseEntity
    {
        [Field(IsSqliteIgnore=true)]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 卡号(要保证唯一性)
        /// </summary>
        public virtual string CardNo { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }
        /// <summary>
        /// 车辆ID
        /// </summary>
        public virtual string CarId { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string DriverName { get; set; }

        /// <summary>
        /// 计划单号
        /// </summary>
        public virtual string PlanNo { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        public virtual string TaskNo { get; set; }

        /// <summary>
        /// 完成状态
        /// </summary>
        public virtual string FinishState { get; set; }

        /// <summary>
        /// 称重业务类别
        /// </summary>
        public virtual string MeasureType { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual string CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        /// 
        [Field(IsSqliteIgnore = true)]
        public virtual string CustomerName { get; set; }
        /// <summary>
        /// 发货商名称
        /// </summary>
        /// 
        [Field(IsSqliteIgnore = true)]
        public virtual string DeliveryName { get; set; }

        /// <summary>
        /// 发货商ID
        /// </summary>
        public virtual string DeliveryId { get; set; }

        /// <summary>
        /// 收货商ID
        /// </summary>
        public virtual string ReceiverId { get; set; }

        /// <summary>
        /// 收货商名称
        /// </summary>
        /// 
        [Field(IsSqliteIgnore=true)]
        public virtual string ReceiverName { get; set; }

        /// <summary>
        /// 注册码(每个客户端注册后会生成的)
        /// </summary>
        public virtual string MachineCode { get; set; }

        /// <summary>
        /// 物资ID
        /// </summary>
        public virtual string MaterialId { get; set; }

        /// <summary>
        /// 物资名称
        /// </summary>
        /// 
        [Field(IsSqliteIgnore = true)]
        public virtual string MaterialName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public virtual string MaterialModel { get; set; }

        /// <summary>
        /// 计划吨位
        /// </summary>
        public virtual decimal PlanWeight { get; set; }
        /// <summary>
        /// 计划吨位
        /// </summary>
        public virtual decimal TareWeight { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public virtual string WarehId { get; set; }
        /// <summary>
        /// 仓库业务类型
        /// </summary>
        public virtual string WarehBizType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
    }
}
