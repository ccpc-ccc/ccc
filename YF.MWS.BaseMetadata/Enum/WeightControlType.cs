using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.BaseMetadata
{
    /// <summary>
    /// 称重控件类型
    /// </summary>
    public enum WeightControlType
    {
        /// <summary>
        /// 默认类型
        /// </summary>
        None,
        /// <summary>
        /// IC卡
        /// </summary>
        WCardEdit,
        /// <summary>
        /// 车牌
        /// </summary>
        WCarLookup,
        /// <summary>
        /// 下拉选项
        /// </summary>
        WComboBoxEdit,
        /// <summary>
        /// 下拉选项文本
        /// </summary>
        WComboBoxTextEdit,
        /// <summary>
        /// 下拉选项值
        /// </summary>
        WComboBoxValueEdit,
        /// <summary>
        /// 单位选择
        /// </summary>
        WCustomerEdit,
        /// <summary>
        /// 日期选择
        /// </summary>
        WDateEdit,
        /// <summary>
        /// 整数输入
        /// </summary>
        WIntegerEdit,
        /// <summary>
        /// 搜索输入
        /// </summary>
        WLookupSearchEdit,
        /// <summary>
        /// 物资选择
        /// </summary>
        WMaterialEdit,
        /// <summary>
        /// 数字输入
        /// </summary>
        WNumbericEdit,
        /// <summary>
        /// 文本输入
        /// </summary>
        WTextEdit
    }
}
