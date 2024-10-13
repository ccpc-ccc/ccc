using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Event;
using YF.Utility;
using YF.MWS.Win.Util;
using System.Drawing;

namespace YF.MWS.Win.Uc.Weight
{
    public class WDateEdit : DateEdit,IField
    {
        public WDateEdit() 
        {
            this.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
        }
        #region IField 成员
        public string ActionName
        {
            get;
            set;
        }
        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
        }

        public string Caption
        {
            get;
            set;
        }

        public object CurrentValue
        {
            get
            {
                return this.DateTime;
            }
            set
            {
                this.DateTime = value.ToDateTime();
            }
        }
        public string ErrorTipText
        {
            get;
            set;
        }
        public string FieldName
        {
            get;
            set;
        }

        public bool IsRequired
        {
            get;
            set;
        }

        /// <summary>
        /// 启用驻留
        /// </summary>
        public bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        public bool StartAutoSave { get; set; }

        public void Clear()
        {
            this.EditValue = null;
        }

        public void SetEnabled(bool enable)
        {
            this.Enabled = enable;
        } 

        public string ControlName
        {
            get;
            set;
        }

        public string Expression
        {
            get;
            set;
        }

        public int AutoCalcNo
        {
            get;
            set;
        }

        public WeightVauleChangedEventHandler WeightVauleChanged
        {
            get;
            set;
        }

        public int DecimalDigits
        {
            get;
            set;
        }

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public void SetReadonly()
        {
            this.Properties.ReadOnly = true;
        }
        public Point ParentLocation
        {
            get;
            set;
        }
        public void SaveInputItem()
        {

        }
        public string t1 { get; set; }
        public void setValue(object value) { }
        #endregion
    }
}
