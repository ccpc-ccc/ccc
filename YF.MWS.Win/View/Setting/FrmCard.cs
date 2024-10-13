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
using YF.MWS.Metadata;
using YF.Utility;
using System.IO.Ports;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmCard : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;

        public FrmCard()
        {
            InitializeComponent();
        }

        private void FrmCard_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            string item1 = "";
            cmbWritePortName.Properties.Items.Add(item1);
            cmbComShort1.Properties.Items.Add(item1);
            cmbComShort2.Properties.Items.Add(item1);
            cmbComRemote1.Properties.Items.Add(item1);
            cmbComRemote2.Properties.Items.Add(item1);
            foreach (string item in SerialPort.GetPortNames())
            {
                cmbWritePortName.Properties.Items.Add(item);
                cmbComShort1.Properties.Items.Add(item);
                cmbComShort2.Properties.Items.Add(item);
                cmbComRemote1.Properties.Items.Add(item);
                cmbComRemote2.Properties.Items.Add(item);
            }
            if (cfg != null) 
            {
                List<ReadCardCfg> lstReadCard = cfg.LstReadCard;
                ReadCardCfg shortCard = lstReadCard.Find(c => c.Type == ReadCardType.Short);
                ReadCardCfg remoteCard = lstReadCard.Find(c => c.Type == ReadCardType.Remote);
                if (shortCard != null)
                {
                    chkShort.Checked = shortCard.IsStart;
                    if (shortCard.SerialPort1 != null)
                    {
                        cmbComShort1.EditValue = shortCard.SerialPort1;
                    }
                    if (shortCard.SerialPort2 != null)
                    {
                        cmbComShort2.EditValue = shortCard.SerialPort2;
                    }
                }
                if (remoteCard != null)
                {
                    chkRemote.Checked = remoteCard.IsStart;
                    if (remoteCard.SerialPort1 != null)
                    {
                        cmbComRemote1.EditValue = remoteCard.SerialPort1;
                    }
                    if (remoteCard.SerialPort2 != null)
                    {
                        cmbComRemote2.EditValue = remoteCard.SerialPort2;
                    }
                    tePower.Text = remoteCard.PowerDbm.ToString();
                    chkApplyParameter.Checked = remoteCard.ApplyParameter;
                }
                cmbWritePortName.EditValue = cfg.WriteCard.PortName;
                rgWriteCardType.EditValue = cfg.WriteCard.CardType.ToString();
                chkWriteApplyParameter.Checked = cfg.WriteCard.ApplyParameter;
                teWritePower.Text = cfg.WriteCard.PowerDbm.ToString();
                chkReadCard.Checked = cfg.StartReadCard;
                teCycle.Text = cfg.ReadCardCycle.ToString();
                chkStartSameCardNoControl.Checked = cfg.Weight.StartSameCardNoControl;
                teReadCardTimeSpan.Text = cfg.Weight.ReadCardTimeSpan.ToString();
                chkAllowOneCarMultipleCards.Checked = cfg.Weight.AllowOneCarMultipleCards;
            }
            #region 身份证读卡器配置
            if (cfg != null && cfg.IdCard != null) {
                rgCommType.EditValue = cfg.IdCard.CommunicationType.ToString();
                tePortType.Text = cfg.IdCard.PortType;
                tePortPara.Text = cfg.IdCard.PortPara;
                teExtendPara.Text = cfg.IdCard.ExtendPara;
                chkStart.Checked = cfg.IdCard.Start;
                chkStartSecondRead.Checked = cfg.IdCard.StartSecondRead;
                chkStartGenerateCustomer.Checked = cfg.IdCard.StartGenerateCustomer;
            }
            #endregion
        }

        private void Save() 
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            List<ReadCardCfg> lstReadCard = cfg.LstReadCard;
            ReadCardCfg shortCard = lstReadCard.Find(c => c.Type == ReadCardType.Short);
            ReadCardCfg remoteCard = lstReadCard.Find(c => c.Type == ReadCardType.Remote);
            if (shortCard == null)
            {
                shortCard = new ReadCardCfg();
                shortCard.Type = ReadCardType.Short;
            }
            if (remoteCard == null)
            {
                remoteCard = new ReadCardCfg();
                remoteCard.Type = ReadCardType.Remote;
            }
            if (shortCard != null)
            {
                shortCard.IsStart = chkShort.Checked;
                shortCard.SerialPort1 = cmbComShort1.EditValue.ToObjectString();
                shortCard.SerialPort2 = cmbComShort2.EditValue.ToObjectString();
            }
            if (remoteCard != null)
            {
                remoteCard.IsStart = chkRemote.Checked;
                remoteCard.SerialPort1 = cmbComRemote1.EditValue.ToObjectString();
                remoteCard.SerialPort2 = cmbComRemote2.EditValue.ToObjectString();
                remoteCard.PowerDbm = tePower.Text.ToInt();
                remoteCard.ApplyParameter = chkApplyParameter.Checked;
            }
            cfg.WriteCard.CardType = rgWriteCardType.EditValue.ToEnum<ReadCardType>();
            cfg.WriteCard.PortName = cmbWritePortName.EditValue.ToObjectString();
            cfg.WriteCard.ApplyParameter = chkWriteApplyParameter.Checked;
            cfg.WriteCard.PowerDbm = teWritePower.Text.ToInt();
            cfg.StartReadCard = chkReadCard.Checked;
            cfg.ReadCardCycle = teCycle.Text.ToDecimal();
            cfg.LstReadCard.Clear();
            cfg.LstReadCard.Add(shortCard);
            cfg.LstReadCard.Add(remoteCard);
            cfg.Weight.StartSameCardNoControl = chkStartSameCardNoControl.Checked;
            cfg.Weight.ReadCardTimeSpan = teReadCardTimeSpan.Text.ToInt();
            cfg.Weight.AllowOneCarMultipleCards = chkAllowOneCarMultipleCards.Checked;
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存读写卡配置信息");
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Save();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            if (cfg == null) cfg = CfgUtil.GetCfg();
            cfg.IdCard.CommunicationType = rgCommType.EditValue.ToEnum<CommunicationType>();
            cfg.IdCard.PortType = tePortType.Text;
            cfg.IdCard.PortPara = tePortPara.Text;
            cfg.IdCard.ExtendPara = teExtendPara.Text;
            cfg.IdCard.Start = chkStart.Checked;
            cfg.IdCard.StartSecondRead = chkStartSecondRead.Checked;
            cfg.IdCard.StartGenerateCustomer = chkStartGenerateCustomer.Checked;
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存身份证识别器设置信息");
        }
        private void comboUsbDeviceInfo_SelectedIndexChanged(object sender, EventArgs e) {
            tePortPara.Text = comboUsbDeviceInfo.Text.Substring(0, 8);
            if (tePortPara.Text == "261A000C") {
                teExtendPara.Text = "MC";
            } else {
                teExtendPara.Text = "";
            }
        }
    }
}