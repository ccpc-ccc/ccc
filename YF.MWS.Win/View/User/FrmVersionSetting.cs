using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.User
{
    public partial class FrmVersionSetting : DevExpress.XtraEditors.XtraForm
    {
        private IClientService clientService = new ClientService();
        private AuthCfg cfg = new AuthCfg();
        public FrmVersionSetting()
        {
            InitializeComponent();
        }

        private void FrmVersionSetting_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save(); 
        }

        private void BindData() 
        {
            cfg = CfgUtil.GetAuth();
            chkAutoWeight.Checked = cfg.AutoWeight;
            chkCarNoRecognition.Checked = cfg.CarNoRecognition;
            chkReadCard.Checked = cfg.ReadCard;
            chkStartFinance.Checked = cfg.StartFinance;
            chkStartScreen.Checked = cfg.StartScreen;
            chkStartPad.Checked = cfg.StartPad;
            chkStartVideo.Checked = cfg.StartVideo;
            chkStartOnline.Checked = cfg.StartOnline;
        }

        private void Save() 
        {
            if (cfg == null) 
            {
                cfg = new AuthCfg();
            }
            cfg.AutoWeight = chkAutoWeight.Checked;
            cfg.CarNoRecognition = chkCarNoRecognition.Checked;
            cfg.ReadCard = chkReadCard.Checked;
            cfg.StartFinance = chkStartFinance.Checked;
            cfg.StartScreen = chkStartScreen.Checked;
            cfg.StartPad = chkStartPad.Checked;
            cfg.StartVideo = chkStartVideo.Checked;
            cfg.StartOnline = chkStartOnline.Checked;
            string authCode = CfgUtil.GetAuthCode(cfg);
            clientService.UpdateAuthCode(CurrentClient.Instance.MachineCode, authCode);
            MessageDxUtil.ShowTips("成功保存版本模块设置信息.");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}