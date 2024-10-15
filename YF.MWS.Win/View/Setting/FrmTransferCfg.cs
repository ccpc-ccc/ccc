using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Db;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using com.google.zxing.qrcode;
using com.google.zxing.common;
using com.google.zxing;
using YF.MWS.Win.View.Home;
using YF.Utility.Configuration;
using YF.MWS.Win.Util.CarPlate;
using YF.MWS.Db.Server;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmTransferCfg : DevExpress.XtraEditors.XtraForm
    {
        private IWebCompanyService webCompanyService = new WebCompanyService();
        private SysCfg cfg;
        private FrmMain frmMain;

        public FrmMain FrmMain
        {
            get { return frmMain; }
            set { frmMain = value; }
        }

        public FrmTransferCfg()
        {
            InitializeComponent();
        }

        private void FrmTransferCfg_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null)
            {
                TransferCfg transfer = cfg.Transfer;
                txtServerUrl.Text = cfg.ServerUrl;
                txtToken.Text = cfg.ServerToken;
                checkEdit1.Checked = cfg.IsServer;
            }
        }

        private void Save()
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            cfg.ServerToken = txtToken.Text;
            cfg.ServerUrl = txtServerUrl.Text;
            cfg.IsServer = checkEdit1.Checked;
            CfgUtil.SaveCfg(cfg);
            CurrentClient.Instance.ServerToken = txtToken.Text;
            CurrentClient.Instance.ServerUrl = txtServerUrl.Text;
            CurrentClient.Instance.IsServer= checkEdit1.Checked;
            MessageDxUtil.ShowTips("成功保存云磅传输设置信息");
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e) {
            gpRuiJieYun.Enabled = checkEdit1.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            ReturnEntity model = WebWeightService.testServer(txtServerUrl.Text, txtToken.Text);
            if(model!=null) {
                MessageDxUtil.ShowTips("连接成功");
            } else if(model==null){
                MessageDxUtil.ShowTips("连接失败");
            }
            }
    }
}