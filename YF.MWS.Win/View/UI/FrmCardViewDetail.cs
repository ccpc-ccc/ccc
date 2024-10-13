using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmCardViewDetail : DevExpress.XtraEditors.XtraForm
    {
        private ICardService cardService = new CardService();
        private IWeightViewService viewService = new WeightViewService();
        private List<SWeightViewDtl> lstDtl = new List<SWeightViewDtl>();
        public string ViewId { get; set; }
        public FrmCardViewDetail()
        {
            InitializeComponent();
        }

        private void FrmCardViewDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            lstDtl = cardService.GetInitedWVDetailList(ViewId);
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "ControlName", Caption = "名称" });
            SearchLookupUtil.BindData(lookupControl, lstDtl, "Id", "ControlName", lstField);
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                Save();
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (lookupControl.EditValue == null || lookupControl.EditValue.ToObjectString().Length == 0) 
            {
                isValidated = false;
                lookupControl.ErrorText = "请选择控件";
            }
            return isValidated;
        }

        private void Save() 
        {
            try
            {
                SCardViewDtl detail = new SCardViewDtl();
                detail.Id = YF.MWS.Util.Utility.GetGuid();
                SWeightViewDtl wvDetail = viewService.GetViewDetail(lookupControl.EditValue.ToObjectString());
                if (wvDetail == null)
                {
                    return;
                }
                SCardViewDtl findDetail = cardService.GetCardDetail(wvDetail.ViewId, wvDetail.Id);
                if (findDetail != null)
                {
                    findDetail.ControlId = wvDetail.ControlId;
                    findDetail.ViewId = wvDetail.ViewId;
                    findDetail.DetailId = wvDetail.Id;
                    findDetail.OrderNo = teOrderNo.Text.ToInt();
                    cardService.SaveDetail(findDetail);
                }
                else
                {
                    detail.ControlId = wvDetail.ControlId;
                    detail.ViewId = wvDetail.ViewId;
                    detail.DetailId = wvDetail.Id;
                    detail.OrderNo = teOrderNo.Text.ToInt();
                    cardService.SaveDetail(detail);
                }
                MessageDxUtil.ShowTips("成功保存IC卡界面控件.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存IC卡界面控件时发生未知错误,请重试.");
            }
        }
    }
}