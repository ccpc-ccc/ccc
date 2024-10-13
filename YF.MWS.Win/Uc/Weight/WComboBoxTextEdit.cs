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
using YF.Utility.Language;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WComboBoxTextEdit: ComboBoxEdit, IField
    {
        private IMasterService masterService = new MasterService();
        
        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        public WComboBoxTextEdit() 
        {
            this.EditValueChanged += WComboBoxtTextEdit_EditValueChanged;
        }
        void WComboBoxtTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (WeightVauleChanged != null)
            {
                WeightVauleChangedEventArgs args = new WeightVauleChangedEventArgs(ControlName);
                args.FieldName = FieldName;
                args.ActionName = ActionName;
                WeightVauleChanged(sender, args);
            }
        }
        #region IField 成员
        public bool IsEffectiveItem
        {
            get
            {
                bool isEffective = false;
                if (SelectedItem != null && SelectedItem is string)
                {
                    isEffective = true;
                }
                return isEffective;
            }
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
        public string ErrorTipText
        {
            get;
            set;
        }
        public object CurrentValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (Properties.Items.Count == 0)
                    return;
                if (Properties.Items[0] is ListItem)
                    this.SelectedItem = Properties.Items.Cast<ListItem>().FirstOrDefault(c => c.Text == Convert.ToString(value));
                else
                    this.SelectedItem = Properties.Items.Cast<SCode>().FirstOrDefault(c => c.ItemCaption == Convert.ToString(value));
            }
        }


        public string FieldName
        {
            get;
            set;
        }

        public int DecimalDigits
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
                    BeginInvoke(new Action(() =>
                    {
                       if(t1==null) Text = "";
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

        public void SaveInputItem() 
        {
            if (!string.IsNullOrEmpty(Text))
            {
                SCode code = new SCode();
                code.ItemCaption = Text;
                code.ItemCode = PinYinUtil.GetInitial(Text);
                code.OrderNo = 1;
                bool isSaved = masterService.SaveCode(code, FieldName);
                if (isSaved)
                {
                    MasterCacher.Refresh();
                }
            }
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
        public string t1 { get; set; }
        #endregion
    }
}
