using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmVersion : DevExpress.XtraEditors.XtraForm
    {
        private IClientService clientService = new ClientService();
        private AuthCfg cfg = new AuthCfg();

        public FrmVersion()
        {
            InitializeComponent();
        }

        private void FrmVersion_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            cfg = CfgUtil.GetAuth();
            if (cfg != null)
            {
                chkAutoWeight.Checked = cfg.AutoWeight;
                chkCarNoRecognition.Checked = cfg.CarNoRecognition;
                chkReadCard.Checked = cfg.ReadCard;
                chkStartFinance.Checked = cfg.StartFinance;
                chkStartScreen.Checked = cfg.StartScreen;
                chkStartPad.Checked = cfg.StartPad;
                chkStartVideo.Checked = cfg.StartVideo;
                chkStartOnline.Checked = cfg.StartOnline;
            }
        }
    }
}