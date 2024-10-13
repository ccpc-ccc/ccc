using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Uc;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.UI
{
    public partial class FrmFormulaCfg : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        public FrmFormulaCfg()
        {
            InitializeComponent();
        }

        private void FrmFormulaCfg_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RecId)) 
            {
                SWeightViewDtl dtl = viewService.GetViewDetail(RecId);
                if (dtl != null)
                {
                    teControlName.Text = dtl.ControlName;
                    teExpression.Text = dtl.Expression;
                }
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isUpdated=viewService.UpdateExpression(RecId, teExpression.Text);
            if (isUpdated)
            {
                MessageDxUtil.ShowTips("设置成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else 
            {
                MessageDxUtil.ShowWarning("设置不成功");
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}