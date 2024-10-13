using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Query;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmSeqNoCfgList : DevExpress.XtraEditors.XtraForm
    {
        private ISeqNoService seqNoService = new SeqNoService();
        private List<QSeqNo> lstSeqNo = new List<QSeqNo>();
        private GridCheckMarksSelection chkCar;

        public FrmSeqNoCfgList()
        {
            InitializeComponent();
        }

        private void FrmSeqNoCfgList_Load(object sender, EventArgs e)
        {
            using (Utility.GetWaitForm(this))
            {
                BindData();
            }
        }

        private void BindData()
        {
            List<SCode> lstCode=new List<SCode>();
            lstCode = MasterCacher.GetSubCodeList(SysCode.SeqCode.ToString());
            lstSeqNo = seqNoService.GetList(lstCode);
            gcCar.DataSource = lstSeqNo;
            if (chkCar == null)
                chkCar = new GridCheckMarksSelection(gvCar);
            chkCar.ClearSelection();
        }

        private void btnItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FrmSeqNoCfgEdit frmEdit = new FrmSeqNoCfgEdit())
            {
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    BindData();
                }
            }
        }

        private void btnItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvCar.GetFocusedRow() != null)
            {
                QSeqNo seq = (QSeqNo)gvCar.GetFocusedRow();
                using (FrmSeqNoCfgEdit frmEdit = new FrmSeqNoCfgEdit())
                {
                    frmEdit.RecId = seq.Id;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindData();
                    }
                }
            }
        }

        private void btnItemPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvCar.GetFocusedRow() != null)
            {
                QSeqNo seq = (QSeqNo)gvCar.GetFocusedRow();
                string message = string.Format("当前{0}的序列号:\n{1}", MasterCacher.GetCodeCapiton(SysCode.SeqCode.ToString(), seq.SeqCode), seqNoService.Preview(seq.SeqCode));
                MessageDxUtil.ShowTips(message);
            }
        }
    }
}