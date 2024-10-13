using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Cfg;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util.Screen;
using YF.MWS.Metadata.Screen;
using YF.MWS.Metadata.Enum;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmScreenCfg : BaseForm
    {
        private string xmlPath =string.Empty;
        private string xmlPath2 = string.Empty;
        private LXCfg lxCfg = null;
        private LXCfg lxCfg2 = null;
        private LXLedUtil lxLedUtil = null;
        private LXLedUtil lxLedUtil2 = null;
        public FrmScreenCfg()
        {
            InitializeComponent();
        }

        private void FrmScreenCfg_Load(object sender, EventArgs e)
        {
            xmlPath = Path.Combine(Application.StartupPath, "LXCfg_1.xml");
            xmlPath2 = Path.Combine(Application.StartupPath, "LXCfg_2.xml");
            BindData();
            BindData2();
        }

        private void BindData() 
        {
            lxCfg = CfgUtil.GetLXCfg(1);
            lxLedUtil = new LXLedUtil(lxCfg);
            if (lxCfg.CardModel == 3)
            {
                cbbModel.SelectedIndex = 2;
            }
            else 
            {
                cbbModel.SelectedIndex = 0;
            }
            if (lxCfg.CommunicationModel == Metadata.CommunicationModelType.Network)
            {
                cbbComm.SelectedIndex = 0;
            }
            else 
            {
                cbbComm.SelectedIndex = 1;
            }
            txtip.Text = lxCfg.IPAddr;
            cbbCom.SelectedItem = lxCfg.PortName;
            cbbBaud.SelectedItem = lxCfg.BaudRate.ToString();
            txtwidth.Text = lxCfg.ScreenWidth.ToString();
            txtheight.Text = lxCfg.ScreenHeight.ToString();
            cbbpno.SelectedItem = lxCfg.ScreenNo.ToString();
            sePlaySpeed.Value = lxCfg.PlaySpeed;
            spDelay.Value = lxCfg.Delay;
            teAd.Text = lxCfg.AdContent;
            spAdFontSize.Value = lxCfg.AdFontSize;
            spWeightFontSize.Value = lxCfg.WeightFontSize;
            chkStart.Checked = lxCfg.Start;
            rgLedVersionType.EditValue = lxCfg.VersionType.ToString();
            chkShowInCarNoRecognition.Checked = lxCfg.LedShow.ShowInCarNoRecognition;
            chkShowInWeightStable.Checked = lxCfg.LedShow.ShowInWeightStable;
            chkShowAd.Checked = lxCfg.LedShow.ShowAd;
            teIdleMinutesShowAd.Text = lxCfg.LedShow.IdleMinutesShowAd.ToString();
            FormHelper.BindControl<ShowWeightStableCfg>(gpShowInWeightStable, lxCfg.LedShow.ShowWeightStable);
            SetScreenColor(false);
        }
        private void BindData2() {
            lxCfg2 = CfgUtil.GetLXCfg(2);
            lxLedUtil2 = new LXLedUtil(lxCfg2);
            if (lxCfg2.CardModel == 3) {
                cbbModel2.SelectedIndex = 2;
            } else {
                cbbModel2.SelectedIndex = 0;
            }
            if (lxCfg2.CommunicationModel == Metadata.CommunicationModelType.Network) {
                cbbComm2.SelectedIndex = 0;
            } else {
                cbbComm2.SelectedIndex = 1;
            }
            txtip2.Text = lxCfg2.IPAddr;
            cbbCom2.SelectedItem = lxCfg2.PortName;
            cbbBaud2.SelectedItem = lxCfg2.BaudRate.ToString();
            txtwidth2.Text = lxCfg2.ScreenWidth.ToString();
            txtheight2.Text = lxCfg2.ScreenHeight.ToString();
            cbbpno2.SelectedItem = lxCfg2.ScreenNo.ToString();
            sePlaySpeed2.Value = lxCfg2.PlaySpeed;
            spDelay2.Value = lxCfg2.Delay;
            teAd2.Text = lxCfg2.AdContent;
            spAdFontSize2.Value = lxCfg2.AdFontSize;
            spWeightFontSize2.Value = lxCfg2.WeightFontSize;
            chkStart2.Checked = lxCfg2.Start;
            rgLedVersionType2.EditValue = lxCfg2.VersionType.ToString();
            chkShowInCarNoRecognition2.Checked = lxCfg2.LedShow.ShowInCarNoRecognition;
            chkShowInWeightStable2.Checked = lxCfg2.LedShow.ShowInWeightStable;
            chkShowAd2.Checked = lxCfg2.LedShow.ShowAd;
            teIdleMinutesShowAd2.Text = lxCfg2.LedShow.IdleMinutesShowAd.ToString();
            FormHelper.BindControl<ShowWeightStableCfg>(gpShowInWeightStable2, lxCfg2.LedShow.ShowWeightStable);
            SetScreenColor2(false);
        }

        private void SetScreenColor(bool setCfg) 
        {
            if (setCfg)
            {
                lxCfg.CardModel = 3;
            }
            if (cbbModel.SelectedIndex == 2)
            {
                cbbcolor.Items.Clear();
                cbbcolor.Items.Add("全彩");
                if (setCfg)
                {
                    lxCfg.ScreenColor = 3;
                }
            }
            else
            {
                cbbcolor.Items.Clear();
                cbbcolor.Items.Add("单色");
                cbbcolor.Items.Add("双色");
                if (setCfg)
                {
                    if (cbbModel.SelectedIndex == 0)
                    {
                        lxCfg.CardModel = 2;
                    }
                    lxCfg.ScreenColor = 1;
                }
            }
            cbbcolor.SelectedIndex = 0;
        }
        private void SetScreenColor2(bool setCfg) {
            if (setCfg) {
                lxCfg2.CardModel = 3;
            }
            if (cbbModel2.SelectedIndex == 2) {
                cbbcolor2.Items.Clear();
                cbbcolor2.Items.Add("全彩");
                if (setCfg) {
                    lxCfg2.ScreenColor = 3;
                }
            } else {
                cbbcolor2.Items.Clear();
                cbbcolor2.Items.Add("单色");
                cbbcolor2.Items.Add("双色");
                if (setCfg) {
                    if (cbbModel2.SelectedIndex == 0) {
                        lxCfg2.CardModel = 2;
                    }
                    lxCfg2.ScreenColor = 1;
                }
            }
            cbbcolor2.SelectedIndex = 0;
        }

        private void Save(bool showMessage) 
        {
            try
            {
                lxCfg.IPAddr = txtip.Text;
                lxCfg.PortName = cbbCom.SelectedItem.ToObjectString();
                lxCfg.ScreenHeight = txtheight.Text.ToInt();
                lxCfg.ScreenNo = cbbpno.SelectedItem.ToInt();
                lxCfg.ScreenWidth = txtwidth.Text.ToInt();
                lxCfg.BaudRate = cbbBaud.SelectedItem.ToInt();
                lxCfg.ScreenNo = cbbpno.SelectedItem.ToInt();
                lxCfg.PortNo = cbbCom.SelectedIndex + 1;
                lxCfg.PlaySpeed = sePlaySpeed.Value.ToInt();
                lxCfg.AdContent = teAd.Text;
                lxCfg.Delay = spDelay.Value.ToInt();
                lxCfg.AdFontSize = spAdFontSize.Value.ToInt();
                lxCfg.WeightFontSize = spWeightFontSize.Value.ToInt();
                lxCfg.Start = chkStart.Checked;
                lxCfg.VersionType = rgLedVersionType.EditValue.ToEnum<LedVersionType>();
                if (cbbComm.SelectedIndex == 0)
                {
                    lxCfg.CommunicationModel = Metadata.CommunicationModelType.Network;
                }
                else 
                {
                    lxCfg.CommunicationModel = Metadata.CommunicationModelType.SerlPort;
                }
                lxCfg.LedShow.ShowInCarNoRecognition = chkShowInCarNoRecognition.Checked;
                lxCfg.LedShow.ShowInWeightStable = chkShowInWeightStable.Checked;
                lxCfg.LedShow.IdleMinutesShowAd = teIdleMinutesShowAd.Text.ToInt();
                lxCfg.LedShow.ShowAd = chkShowAd.Checked;
                ShowWeightStableCfg showStableCfg=lxCfg.LedShow.ShowWeightStable;
                FormHelper.ControlToEntity<ShowWeightStableCfg>(gpShowInWeightStable, ref showStableCfg);
                XmlUtil.Serialize<LXCfg>(lxCfg, xmlPath);
                if (showMessage)
                {
                    MessageDxUtil.ShowTips("成功保存1#大屏幕配置信息.");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                if (showMessage)
                {
                    MessageDxUtil.ShowError("保存1#大屏幕配置信息过程中出现未知错误,请重试.");
                }
            }
        }
        private void Save2(bool showMessage) {
            try {
                lxCfg2.IPAddr = txtip2.Text;
                lxCfg2.PortName = cbbCom2.SelectedItem.ToObjectString();
                lxCfg2.ScreenHeight = txtheight2.Text.ToInt();
                lxCfg2.ScreenNo = cbbpno2.SelectedItem.ToInt();
                lxCfg2.ScreenWidth = txtwidth2.Text.ToInt();
                lxCfg2.BaudRate = cbbBaud2.SelectedItem.ToInt();
                lxCfg2.ScreenNo = cbbpno2.SelectedItem.ToInt();
                lxCfg2.PortNo = cbbCom2.SelectedIndex + 1;
                lxCfg2.PlaySpeed = sePlaySpeed2.Value.ToInt();
                lxCfg2.AdContent = teAd2.Text;
                lxCfg2.Delay = spDelay2.Value.ToInt();
                lxCfg2.AdFontSize = spAdFontSize2.Value.ToInt();
                lxCfg2.WeightFontSize = spWeightFontSize2.Value.ToInt();
                lxCfg2.Start = chkStart2.Checked;
                lxCfg2.VersionType = rgLedVersionType2.EditValue.ToEnum<LedVersionType>();
                if (cbbComm2.SelectedIndex == 0) {
                    lxCfg2.CommunicationModel = Metadata.CommunicationModelType.Network;
                } else {
                    lxCfg2.CommunicationModel = Metadata.CommunicationModelType.SerlPort;
                }
                lxCfg2.LedShow.ShowInCarNoRecognition = chkShowInCarNoRecognition2.Checked;
                lxCfg2.LedShow.ShowInWeightStable = chkShowInWeightStable2.Checked;
                lxCfg2.LedShow.IdleMinutesShowAd = teIdleMinutesShowAd2.Text.ToInt();
                lxCfg2.LedShow.ShowAd = chkShowAd2.Checked;
                ShowWeightStableCfg showStableCfg = lxCfg2.LedShow.ShowWeightStable;
                FormHelper.ControlToEntity<ShowWeightStableCfg>(gpShowInWeightStable2, ref showStableCfg);
                XmlUtil.Serialize<LXCfg>(lxCfg2, xmlPath2);
                if (showMessage) {
                    MessageDxUtil.ShowTips("成功保存大2#屏幕配置信息.");
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                if (showMessage) {
                    MessageDxUtil.ShowError("保存2#大屏幕配置信息过程中出现未知错误,请重试.");
                }
            }
        }


        private void cbbcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbcolor.Items.Count == 2)
            {
                if (cbbcolor.SelectedIndex == 0)
                {
                    lxCfg.ScreenColor = 1;
                }
                else
                {
                    lxCfg.ScreenColor = 2;
                }
            }
            else
            {
                lxCfg.ScreenColor = 3;
            }
        }

        private void cbbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScreenColor(true);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Save(false);
                bool isSended = false;
                LedVersionType type = rgLedVersionType.EditValue.ToEnum<LedVersionType>();
                if (type == LedVersionType.T3)
                {
                    bool isSettinged = lxLedUtil.Setting();
                    lxLedUtil.SetScreenParameter();
                    isSended = lxLedUtil.SendText(teContent.Text, 10);
                }
                else
                {
                    isSended = LXNewLedUtil.SendInfo(lxCfg, teContent.Text, spWeightFontSize.Value.ToInt());
                }
                if (isSended)
                {
                    MessageDxUtil.ShowTips("成功向大屏幕发送文字信息.");
                }
                else
                {
                    MessageDxUtil.ShowError("向大屏幕发送文字信息过程中出现未知错误,请重试.");
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("向大屏幕发送文字信息过程中出现未知错误,请重试.");
            }
        }

        private void cbbComm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbComm.SelectedIndex == 0)
            {
                grpNet.Enabled = true;
                grpCom.Enabled = false;
            }
            else
            {
                grpNet.Enabled = false;
                grpCom.Enabled = true;
            }
        }

        private void cbbcolor2_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbbcolor2.Items.Count == 2) {
                if (cbbcolor2.SelectedIndex == 0) {
                    lxCfg2.ScreenColor = 1;
                } else {
                    lxCfg2.ScreenColor = 2;
                }
            } else {
                lxCfg2.ScreenColor = 3;
            }
        }

        private void cbbModel2_SelectedIndexChanged(object sender, EventArgs e) {
            SetScreenColor2(true);
        }

        private void btnSend2_Click(object sender, EventArgs e) {
            try {
                Save2(false);
                bool isSended = false;
                LedVersionType type = rgLedVersionType2.EditValue.ToEnum<LedVersionType>();
                if (type == LedVersionType.T3) {
                    bool isSettinged = lxLedUtil2.Setting();
                    lxLedUtil2.SetScreenParameter();
                    isSended = lxLedUtil2.SendText(teContent.Text, 10);
                } else {
                    isSended = LXNewLedUtil.SendInfo(lxCfg2, teContent2.Text, spWeightFontSize2.Value.ToInt());
                }
                if (isSended) {
                    MessageDxUtil.ShowTips("成功向2#大屏幕发送文字信息.");
                } else {
                    MessageDxUtil.ShowError("向2#大屏幕发送文字信息过程中出现未知错误,请重试.");
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("向2#大屏幕发送文字信息过程中出现未知错误,请重试.");
            }
        }

        private void cbbComm2_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbbComm2.SelectedIndex == 0) {
                grpNet2.Enabled = true;
                grpCom2.Enabled = false;
            } else {
                grpNet2.Enabled = false;
                grpCom2.Enabled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Save(true);
        }
        private void simpleButton2_Click(object sender, EventArgs e) {
            Save2(true);
        }
    }
}