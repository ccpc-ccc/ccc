using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.CacheService;

namespace YF.MWS.Win.Uc
{
    public partial class FrmCardSelector : DevExpress.XtraEditors.XtraForm
    {
        private ICardService cardService = new CardService();
        private List<QPlanCard> lstCard = new List<QPlanCard>();
        public string CardNo { get; set; }
        public FrmCardSelector()
        {
            InitializeComponent();
        }

        private void FrmCardSelector_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            lstCard = CardCacher.GetList();
            gcPlanCard.DataSource = lstCard;
            gcPlanCard.RefreshDataSource(); 
        }

        private void SetCard() 
        {
            if (gvPlanCard.GetFocusedRow() != null) 
            {
                QPlanCard card = (QPlanCard)gvPlanCard.GetFocusedRow();
                if (card != null) 
                {
                    teCardNo.Text = card.CardNo;
                    CardNo = card.CardNo;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPlanCard_RowClick(object sender, RowClickEventArgs e)
        {
            SetCard();
        }

        private void gvPlanCard_DoubleClick(object sender, EventArgs e)
        {
            SetCard();
            this.DialogResult = DialogResult.OK;
        }
    }
}