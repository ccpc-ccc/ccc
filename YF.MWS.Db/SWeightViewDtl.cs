using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility;
using YF.Utility.Metadata;

namespace YF.MWS.Db
{
    /// <summary>
    /// 称重界面视图详细配置信息
    /// Author:yafyr
    /// Date:2014-11-11
    /// </summary>
    public class SWeightViewDtl : BaseEntity
    {
        public virtual string ViewId { get; set; }
        public virtual string AttributeId { get; set; }
        public virtual string ControlId { get; set; }
        public virtual string ControlType { get; set; }
        public virtual string ControlName { get; set; } 
        public virtual string ActionName { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string FullName { get; set; }

        /// <summary>
        /// 表达式
        /// </summary>
        public virtual string Expression { get; set; }
        /// <summary>
        /// 自动计算排序号
        /// </summary>
        public virtual int AutoCalcNo { get; set; }
        /// <summary>
        /// 小数位个数
        /// </summary>
        public virtual int DecimalDigits { get; set; }

        public virtual int OrderNo { get; set; }
        /// <summary>
        /// 驻留状态
        /// </summary>
        public virtual BoolValueType StayState { get; set; }
        /// <summary>
        /// 自动保存状态
        /// </summary>
        public virtual BoolValueType AutoSaveState { get; set; }
        public virtual string Caption { get; set; }
        public virtual string ErrorText { get; set; }
        public virtual int Readonly { get; set; }
        public virtual int IsRequired { get; set; }
        /// <summary>
        /// 同步状态
        /// </summary>
        public virtual int SyncState { get; set; }
        /// <summary>
        /// 过磅主界面是否显示
        /// </summary>
        public virtual int Show1 { get; set; } = 1;
        /// <summary>
        /// 主界面查询是否显示
        /// </summary>
        public virtual int Show2 { get; set; } = 1;
        /// <summary>
        /// 查询界面是否显示
        /// </summary>
        public virtual int Show3 { get; set; } = 1;
        /// <summary>
        /// 默认值
        /// </summary>
        public virtual string t1 { get; set; }
        public override string ToString()
        {
            return ControlName;
        }
        [Field(IsSqliteIgnore=true)]
        public virtual string RowStateName
        {
            get 
            {
                BaseMetadata.RowState state = RowState.ToEnum<BaseMetadata.RowState>();
                if (state == BaseMetadata.RowState.Delete)
                    return "隐藏";
                else
                    return "显示";
            }
        }
    }
}
