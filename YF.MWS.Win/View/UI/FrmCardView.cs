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
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmCardView : DevExpress.XtraEditors.XtraForm
    {
        private ICardService cardService = new CardService();
        private List<QCardViewDtl> lstDetail = new List<QCardViewDtl>();
        public string ViewId { get; set; }
        public FrmCardView()
        {
            InitializeComponent();
        }

        private void btnItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvViewDetail.GetFocusedValue() == null) 
            {
                return;
            }
            QCardViewDtl detail = (QCardViewDtl)gvViewDetail.GetFocusedRow();
            if (detail != null) 
            {
                string message = string.Format("确实要删除{0}吗?\n执行该操作会将对应的IC卡的数据也会删除,请慎重.", detail.ControlName);
                if (MessageDxUtil.ShowYesNoAndTips(message) ==  DialogResult.Yes) 
                {
                    cardService.DeleteDetail(detail.Id);
                    BindData();
                }
            }
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmCardViewDetail frmDetail = new FrmCardViewDetail()) 
            {
                frmDetail.ViewId = ViewId;
                if (frmDetail.ShowDialog() == DialogResult.OK) 
                {
                    BindData();
                }
            }
        }

        private void FrmCardView_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        {
            lstDetail = cardService.GetDetailList(ViewId);
            gcViewDetail.DataSource = lstDetail;
        }
    }
}