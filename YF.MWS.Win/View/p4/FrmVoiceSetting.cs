using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;
using YF.Utility.Configuration;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmVoiceSetting : DevExpress.XtraEditors.XtraForm
    {
        private string xmlPath = Path.Combine(Application.StartupPath, "VoiceCfg.xml");
        private VoiceCfg cfg;
        private SysCfg sysCfg;
        private SpeechUtil speechUtil = new SpeechUtil();
        public FrmVoiceSetting()
        {
            InitializeComponent();
        }

        private void FrmVoiceSetting_Load(object sender, EventArgs e) {
            string iconFont = AppSetting.GetValue("iconUrl");
            if (File.Exists(iconFont)) this.IconOptions.Image = Image.FromFile(iconFont);
            Bind();
        }

        private void Bind() 
        {
            sysCfg = CfgUtil.GetCfg();
            if (sysCfg != null && sysCfg.Weight!=null) 
            {
                chkStartVoicePrompt.Checked = sysCfg.Weight.StartVoicePrompt;
            }
            cfg = XmlUtil.Deserialize<VoiceCfg>(xmlPath);
            if (cfg != null) 
            {
                teOverWeight.Text = cfg.OverWeight;
                teCarRecognition.Text=cfg.CarRecognition;
                teCarStopFail.Text=cfg.CarStopFail;
                teFirstWeight.Text=cfg.FirstWeight;
                teReadCardFail.Text=cfg.ReadCardFail;
                teReadCardSuccess.Text=cfg.ReadCardSuccess;
                teSecondWeight.Text=cfg.SecondWeight;
                teStartReadCard.Text=cfg.StartReadCard;
                teStartWeight.Text=cfg.StartWeight;
                teTimeOut.Text=cfg.TimeOut;
                teWeightUnStable.Text=cfg.WeightUnStable;
                teInfraredCovered.Text = cfg.InfraredCovered;
                teUnloadWeight.Text = cfg.UnloadWeight;
                rgBroadcastWeightType.EditValue = cfg.BroadcastWeight.ToString();
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void Save() 
        {
            try
            {
                if (cfg == null)
                {
                    cfg = new VoiceCfg();
                }
                cfg.OverWeight = teOverWeight.Text;
                cfg.CarRecognition = teCarRecognition.Text;
                cfg.CarStopFail = teCarStopFail.Text;
                cfg.FirstWeight = teFirstWeight.Text;
                cfg.ReadCardFail = teReadCardFail.Text;
                cfg.ReadCardSuccess = teReadCardSuccess.Text;
                cfg.SecondWeight = teSecondWeight.Text;
                cfg.StartReadCard = teStartReadCard.Text;
                cfg.StartWeight = teStartWeight.Text;
                cfg.TimeOut = teTimeOut.Text;
                cfg.WeightUnStable = teWeightUnStable.Text;
                cfg.InfraredCovered = teInfraredCovered.Text;
                cfg.UnloadWeight = teUnloadWeight.Text;
                cfg.BroadcastWeight = rgBroadcastWeightType.EditValue.ToEnum<BroadcastWeightType>();
                XmlUtil.Serialize<VoiceCfg>(cfg, xmlPath);
                CfgUtil.ResetVoiceCfg();
                if (sysCfg == null)
                {
                    sysCfg = CfgUtil.GetCfg();
                    if (cfg == null)
                        sysCfg = new SysCfg();
                }
                sysCfg.Weight.StartVoicePrompt = chkStartVoicePrompt.Checked;
                CfgUtil.SaveCfg(sysCfg);
                MessageDxUtil.ShowTips("成功保存语音文字配置信息.");
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存语音文字配置信息过程中出现未知错误,请重试.");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            speechUtil.Speak(teTest.Text);
        }
    }
}