using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Event;
using YF.MWS.Win.Util;
using System.Drawing;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WTextEdit:TextEdit,IField
    { 
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
        public string ErrorTipText
        {
            get;
            set;
        }
        public virtual object CurrentValue
        {
            get 
            { 
                return EditValue;
            }
            set
            { 
                EditValue=value;
            }
        }

        public string FieldName
        {
            get;
            set;
        }

        public void SetValue()
        {
            if (CurrentValue != null)
            {
                EditValue = CurrentValue;
            }
        }

        public bool IsRequired
        {
            get;
            set;
        }
        public string t1 { get; set; }
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
            try
            {
                CurrentValue = t1;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() => {
                        if (t1 == null) Text = "";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void SetEnabled(bool enable)
        {
            //this.Enabled = enable;
            this.Properties.ReadOnly = !enable;
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

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public int DecimalDigits
        {
            get;
            set;
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
        #endregion



    }
}
