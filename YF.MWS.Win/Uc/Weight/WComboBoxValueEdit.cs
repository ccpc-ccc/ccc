using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Event;
using YF.MWS.Win.Util;
using System.Drawing;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Language;
using YF.MWS.CacheService;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WComboBoxValueEdit : ComboBoxEdit, IField
    {
        private IMasterService masterService = new MasterService();

        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        #region IField 成员
        public string ActionName
        {
            get;
            set;
        }
        public void InitData()
        {
            if (!string.IsNullOrEmpty(FieldName))
            {
                DxHelper.BindComboBoxEdit(this, FieldName, null);
            }
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
                return DxHelper.GetValue(this);
            }
            set
            {
                if (Properties.Items == null || Properties.Items.Count == 0)
                    return;
                if (value == null || value.ToObjectString().Length == 0)
                    return;
                if (value.GetType().IsEnum)
                {
                    object obj = Enum.Parse(value.GetType(), value.ToObjectString());
                    int i = (int)obj;
                    SelectedItem = Properties.Items.Cast<SCode>().FirstOrDefault(c => c.ItemValue == Convert.ToString(i));
                }
                else
                {
                    SelectedItem = Properties.Items.Cast<SCode>().FirstOrDefault(c => c.ItemValue == Convert.ToString(value));
                }
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

        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }

        public WeightVauleChangedEventHandler WeightVauleChanged
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
            if (!string.IsNullOrEmpty(Text))
            {
                SCode code = new SCode();
                code.ItemCaption = Text;
                code.ItemCode = PinYinUtil.GetInitial(Text);
                code.OrderNo = 1;
                code.ItemValue = CurrentValue.ToObjectString();
                bool isSaved = masterService.SaveCode(code, FieldName);
                if (isSaved)
                {
                    MasterCacher.Refresh();
                }
            }
        }
        public string t1 { get; set; }
        #endregion
    }
}
