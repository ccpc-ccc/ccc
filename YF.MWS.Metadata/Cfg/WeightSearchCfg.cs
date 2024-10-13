using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata.Query;
using YF.Utility;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 磅单查询配置
    /// </summary>
    public class WeightSearchCfg
    {
        /// <summary>
        /// 统计字段
        /// </summary>
        public List<WeightSummaryItem> SummaryItems { get; set; }
        /// <summary>
        /// 查询关键词设置信息
        /// </summary>
        public List<QueryCondition> LstQueryCondition { get; set; }

        public WeightSearchCfg()
        {
            SummaryItems = new List<WeightSummaryItem>();
            LstQueryCondition = new List<QueryCondition>();
        }
    }

    /// <summary>
    /// 称重数据列设置
    /// </summary>
    public class WeightColumn 
    {
        public string ControlId { get; set; }
        public string ControlName { get; set; }
        public string FieldName { get; set; }
        public string FullName { get; set; }
        public WeightControlType WeightControlType 
        {
            get 
            {
                WeightControlType type = WeightControlType.None;
                if (!string.IsNullOrEmpty(FullName))
                {
                    int lastIndex = FullName.LastIndexOf(".");
                    string controlType = FullName.Substring(lastIndex + 1);
                    type = controlType.ToEnum<WeightControlType>();
                }
                return type;
            }
        }
        public Type DataType 
        {
            get 
            {
                Type type = typeof(string);
                switch (WeightControlType) 
                {
                    case WeightControlType.WCardEdit:
                    case BaseMetadata.WeightControlType.WCarLookup:
                    case BaseMetadata.WeightControlType.WComboBoxEdit:
                    case BaseMetadata.WeightControlType.WComboBoxTextEdit:
                    case BaseMetadata.WeightControlType.WCustomerEdit:
                    case BaseMetadata.WeightControlType.WMaterialEdit:
                    case BaseMetadata.WeightControlType.WTextEdit:
                        type = typeof(string);
                        break;
                    case BaseMetadata.WeightControlType.WDateEdit:
                        type = typeof(DateTime);
                        break;
                    case BaseMetadata.WeightControlType.WIntegerEdit:
                    case BaseMetadata.WeightControlType.WComboBoxValueEdit:
                        type = typeof(int);
                        break;
                    case BaseMetadata.WeightControlType.WNumbericEdit:
                        type = typeof(decimal);
                        break;
                }
                return type;
            }
        }
    }

    /// <summary>
    /// 统计列设置
    /// </summary>
    public class WeightSummaryItem 
    {
        public string ControlId { get; set; }
        public FormatType FormatType { get; set; }
        public string FormatTypeName 
        {
            get 
            {
                return FormatType.ToDescription();
            }
        }
        public WeightSummaryItemType SummaryType { get; set; }
        public string ControlName { get; set; }
        public string FieldName { get; set; }
        public DisplayFormatStringType DisplayType { get; set; }
        public string DisplayTypeName 
        {
            get { return DisplayType.ToDescription(); }
        }
        public string SummaryTypeName 
        {
            get { return SummaryType.ToDescription(); }
        }
    }

}
