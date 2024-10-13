using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 车牌识别条件
    /// </summary>
    public enum CarNoRecCondition 
    {
        /// <summary>
        /// 不限制
        /// </summary>
        All,
        /// <summary>
        /// 重量大于零时识别
        /// </summary>
        WeightGeZero,
        /// <summary>
        /// 重量归零时识别
        /// </summary>
        WeightReturnZero
    }
    /// <summary>
    /// 车牌输出方式
    /// </summary>
    public enum CarNoOutMode
    {
        /// <summary>
        /// 完整输出
        /// </summary>
        Whole,
        /// <summary>
        /// 左边部分
        /// </summary>
        LeftPartial,
        /// <summary>
        /// 右边部分
        /// </summary>
        RightPartial
    }
}
