using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWeightSummaryItem : DevExpress.XtraEditors.XtraForm
    {
        private IWeightViewService weightViewService = new WeightViewService(); 
        /// <summary>
        /// 统计字段
        /// </summary>
        public List<WeightSummaryItem> SummaryItems { get; set; }
        public WeightSummaryItem SummaryItem { get; set; }

        public FrmWeightSummaryItem()
        {
            InitializeComponent();
        }

        private void FrmWeightSummaryItem_Load(object sender, EventArgs e)
        {
            weControl.InitData();
            weDisplayFormatType.InitData();
            weSummaryItemType.InitData();
        }

        private void btnItemOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidateForm())
                AddItem();
        }

        private void btnItemCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private bool ValidateForm() 
        {
            bool isValidated = false;
            if (weSummaryItemType.Text.Length == 0) 
            {
                isValidated = false;
                weSummaryItemType.ErrorText = "请选择统计类型";
            }
            if (weDisplayFormatType.Text.Length == 0)
            {
                isValidated = false;
                weDisplayFormatType.ErrorText = "请选择显示类型";
            }
            if (weControl.Text.Length == 0)
            {
                isValidated = false;
                weControl.ErrorText = "请选择字段";
            }
            if (SummaryItems != null && SummaryItems.Count > 0)
            {
                if (SummaryItems.Exists(c => c.ControlId == weControl.CurrentValue.ToObjectString())) 
                {
                    isValidated = false;
                    weControl.ErrorText = "请选择其他字段,此字段已经存在";
                }
            }
            return isValidated;
        }

        private void AddItem() 
        {
            SummaryItem = new WeightSummaryItem();
            SummaryItem.ControlId = weControl.CurrentValue.ToObjectString();
            SummaryItem.ControlName = weControl.Text;
            SummaryItem.DisplayType = weDisplayFormatType.CurrentValue.ToObjectString().ToEnum<DisplayFormatStringType>();
            SControl control = weightViewService.GetControl(SummaryItem.ControlId);
            if (control != null)
                SummaryItem.FieldName = control.FieldName;
            SummaryItem.SummaryType = weSummaryItemType.CurrentValue.ToObjectString().ToEnum<WeightSummaryItemType>();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}