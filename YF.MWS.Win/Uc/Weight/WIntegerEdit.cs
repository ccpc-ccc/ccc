using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using YF.MWS.Metadata.Event;
using YF.Utility;

namespace YF.MWS.Win.Uc.Weight
{
    public class WIntegerEdit : WTextEdit
    {
        public WIntegerEdit()
        {
            this.EditValueChanged += WIntegerEdit_EditValueChanged; 
        }

        void WIntegerEdit_EditValueChanged(object sender, EventArgs e)
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
                return EditValue.ToInt();
            }
            set
            {
                EditValue = value;
            }
        }
    }
}
