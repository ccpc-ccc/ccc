using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.Utility;
using System.IO.Ports;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmIdCardCfg : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;

        public FrmIdCardCfg()
        {
            InitializeComponent();
        }

        private void rgWriteCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommunicationType type = rgCommType.EditValue.ToEnum<CommunicationType>();
            if (type == CommunicationType.Com) 
            {
                tePortType.Enabled = true;
                tePortPara.Enabled = true;
                teExtendPara.Enabled = true;
                comboUsbDeviceInfo.Visible = false;

                string[] ComPort = SerialPort.GetPortNames();
                if (ComPort.Length != 0)
                {
                    tePortType.Text = ComPort[0].Substring(3,1);
                }
                else
                {
                    tePortType.Text = "1";
                }
                tePortPara.Text = "115200";
                teExtendPara.Text = "";
                lblPortTypeTip.Text = "(串口号)";
                lblPortParaTip.Text = "(波特率)";
                lblExtendParaTip.Text = "(扩展盒)";
            }
            if (type == CommunicationType.Usb) 
            {
                tePortType.Enabled = true;
                tePortPara.Enabled = true;
                teExtendPara.Enabled = true;
                comboUsbDeviceInfo.Visible = true;

                tePortType.Text = "USB";
                lblPortTypeTip.Text = "(USB)";
                lblPortParaTip.Text = "(VID_PID)";
                lblExtendParaTip.Text = "(传输方式)";
                comboUsbDeviceInfo.SelectedIndex = 0;
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
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

        private void FrmIdCardCfg_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.IdCard != null) 
            {
                rgCommType.EditValue = cfg.IdCard.CommunicationType.ToString();
                tePortType.Text = cfg.IdCard.PortType;
                tePortPara.Text = cfg.IdCard.PortPara;
                teExtendPara.Text = cfg.IdCard.ExtendPara;
                chkStart.Checked = cfg.IdCard.Start;
                chkStartSecondRead.Checked = cfg.IdCard.StartSecondRead;
                chkStartGenerateCustomer.Checked = cfg.IdCard.StartGenerateCustomer;
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void comboUsbDeviceInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tePortPara.Text = comboUsbDeviceInfo.Text.Substring(0, 8);
            if (tePortPara.Text == "261A000C")
            {
                teExtendPara.Text = "MC";
            }
            else
            {
                teExtendPara.Text = "";
            }
        }
    }
}