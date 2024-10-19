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
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
         
    }
}
