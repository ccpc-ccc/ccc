using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YF.MWS.Metadata.Event;

namespace YF.MWS.Win.Uc
{
    public interface IField
    {
        string ActionName { get; set; }
        string Caption { get; set; }
        /// <summary>
        /// 控件中文名称
        /// </summary>
        string ControlName { get; set; }
        string Expression { get; set; }
        int AutoCalcNo { get; set; }
        object CurrentValue { get; set; }
        string FieldName { get; set; }
        /// <summary>
        /// 是否必填项
        /// </summary>
        bool IsRequired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        bool StartAutoSave { get; set; }
        /// <summary>
        /// 错误提示文本
        /// </summary>
        string ErrorTipText { get; set; }
        string EditText { get; set; }
        int DecimalDigits { get; set; }
        WeightVauleChangedEventHandler WeightVauleChanged { get; set; }
        string Text { get; set; }
        void InitData();
        void Clear();
        void SaveInputItem();
        void SetEnabled(bool enable);
        void SetReadonly();
        Point ParentLocation { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        string t1 { get; set; }
    }
}
