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
                txtMachineCode.Text = transfer.MachineCode;
                txtRegisterCode.Text = transfer.RegisterCode;
                txtCompanyCode.Text = transfer.CompanyCode;// AppSetting.GetValue("MobileServer");
                checkEdit1.Checked = transfer.isOpen;
                chkAutoSend.Checked = transfer.AutoSend;
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
            ReturnEntity client = WebWeightService.Login(txtCompanyCode.Text,txtMachineCode.Text, txtRegisterCode.Text);
            if(client != null) {
                WebWeightService.Token = client.Token;
            } else {
                WebWeightService.Token = "";
            }
            TransferCfg transfer = cfg.Transfer;
            transfer.MachineCode = txtMachineCode.Text;
            transfer.RegisterCode = txtRegisterCode.Text;
            transfer.CompanyCode = txtCompanyCode.Text;
            transfer.AutoSend = chkAutoSend.Checked;
            //transfer.ServerUrl = txtCompanyCode.Text;
            transfer.isOpen = checkEdit1.Checked;
            CfgUtil.SaveCfg(cfg);
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

        private void simpleButton1_Click(object sender, EventArgs e) {
            string url =string.Format("{0}?access={1}&password={2}", txtCompanyCode.Text, txtMachineCode.Text,txtRegisterCode.Text);
            FrmQrCode qrCode = new FrmQrCode(url);
            qrCode.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            ReturnEntity entity = WebWeightService.Login(txtCompanyCode.Text, txtMachineCode.Text,txtRegisterCode.Text);
            if(entity != null&&entity.Result) {
                MessageDxUtil.ShowTips("连接成功");
            } else {
                MessageDxUtil.ShowTips("连接失败");
            }
            }
    }
}