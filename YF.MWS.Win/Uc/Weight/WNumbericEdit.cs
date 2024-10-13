using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using YF.MWS.Metadata.Event;
using YF.Utility;
using YF.Utility.Calculate;
namespace YF.MWS.Win.Uc.Weight
{
    public class WNumbericEdit:WTextEdit
    {
        public WNumbericEdit() 
        {
            //string mask = string.Format("F{0}", DecimalDigits);
            //this.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            //Properties.DisplayFormat.FormatString = mask;
            //Properties.DisplayFormat.FormatType = FormatType.Numeric;
            //Properties.Mask.EditMask = mask;
            //Properties.Mask.MaskType = MaskType.Numeric;
            //Properties.Mask.UseMaskAsDisplayFormat = true;
            this.EditValueChanged += WNumbericEdit_EditValueChanged; 
        }

        void WNumbericEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (WeightVauleChanged != null)
            {
                WeightVauleChangedEventArgs args = new WeightVauleChangedEventArgs(ControlName);
                WeightVauleChanged(sender, args);
            }
        }

        public override object CurrentValue
        {
            get
            {
                return MathUtil.ChinaRound((double)(EditValue.ToDecimal()), DecimalDigits);
                //return EditValue.ToDecimal();
            }
            set
            {
                EditValue = value;
            }
        }
    }
}
