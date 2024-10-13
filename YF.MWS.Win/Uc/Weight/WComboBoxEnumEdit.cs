using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Event;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc.Weight
{
    public class WComboBoxEnumEdit : ComboBoxEdit, IField
    {
        public object CurrentValue
        {
            get
            {
                return DxHelper.GetEnumValue(this);
            }
            set
            {
                if (Properties.Items == null || Properties.Items.Count == 0)
                    return;
                SelectedItem = Properties.Items.Cast<ListItem>().FirstOrDefault(c => c.Value == value.ToObjectString());
            }
        }

        public string ActionName { get; set; }
        public string Caption { get; set; }
        public string ControlName { get; set; }
        public string Expression { get; set; }
        public int AutoCalcNo { get; set; }
        public string FieldName { get; set; }
        public string ErrorTipText
        {
            get;
            set;
        }
        public bool IsRequired { get; set; }
        /// <summary>
        /// 启用驻留
        /// </summary>
        public bool StartStay { get; set; }
        /// <summary>
        /// 启用自动保存
        /// </summary>
        public bool StartAutoSave { get; set; }
        public string EditText
        {
            get { return Text; }
            set { Text = value; }
        }
        public int DecimalDigits { get; set; }
        public WeightVauleChangedEventHandler WeightVauleChanged { get; set; }
        public Point ParentLocation { get; set; }
        WeightVauleChangedEventHandler IField.WeightVauleChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Point IField.ParentLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Clear()
        {
            try
            {
                CurrentValue = null;
                if (IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        Text = "";
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void InitDataNew()
        {
            if (!string.IsNullOrEmpty(FieldName))
            {
                if (FieldName == "DeviceCommMode")
                {
                    DxHelper.BindComboBoxEdit<DeviceCommMode>(this);
                }
                if (FieldName == "PayType")
                {
                    DxHelper.BindComboBoxEdit<PayType>(this);
                }
                if (FieldName == "PlanLimitType")
                {
                    DxHelper.BindComboBoxEdit<PlanLimitType>(this);
                }
                if (FieldName == "WarehBizType")
                {
                    DxHelper.BindComboBoxEdit<WarehBizType>(this);
                }
                if (FieldName == "UserType")
                {
                    DxHelper.BindComboBoxEdit<UserType>(this);
                }
            }
        }

        public void InitData()
        {
            Font = CfgUtil.GetFont();
            InitDataNew();
        }

        public void SaveInputItem()
        {

        }

        public void SetEnabled(bool enable)
        {

        }

        public void SetReadonly()
        {

        }
        public string t1 { get; set; }
        public void setValue(object value) { }
    }
}
