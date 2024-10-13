using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Event;
using YF.MWS.SQliteService;
using YF.Utility;
using YF.MWS.Win.Util;
using System.Drawing;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WCardEdit : ButtonEdit, IField
    {
        private object currentValue;
        private ICardService masterService = new CardService();

        public WCardEdit()
        {
            this.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown;
        }

        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            base.OnClickButton(buttonInfo);
            using (FrmCardSelector frm = new FrmCardSelector())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.currentValue = frm.CardNo;
                    this.Text = frm.CardNo;
                }
            }
        }


        #region IField 成员

        public string Caption
        {
            get;
            set;
        }

        public object CurrentValue
        {
            get
            {
                if (currentValue.ToObjectString().Length == 0) 
                {
                    currentValue = this.Text;
                }
                return currentValue;
            }
            set
            {
                currentValue = value;
                Text = currentValue.ToObjectString();
            }
        }

        public string FieldName
        {
            get;
            set;
        }

        public string ErrorTipText
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

        public int DecimalDigits
        {
            get;
            set;
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

        public void InitData()
        {
            this.Font = CfgUtil.GetFont();
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

        public void SetReadonly()
        {
            this.Properties.ReadOnly = true;
        } 

        public string ActionName
        {
            get;
            set;
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
        #endregion
    }
}
