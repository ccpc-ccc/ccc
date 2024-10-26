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
using System.IO;
using YF.Utility.Log;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmPrint : DevExpress.XtraEditors.XtraForm {
        private IWeightViewService weightViewService = new WeightViewService();
        private SysCfg cfg;
        private VoiceCfg voiceCfg;
        private string xmlPath = Path.Combine(Application.StartupPath, "VoiceCfg.xml");
        private SpeechUtil speechUtil = new SpeechUtil();

        public FrmPrint()
        {
            InitializeComponent();
        }

        private void FrmPrint_Load(object sender, EventArgs e) {
            List<String> lstPrinters = PrintUtil.GetLocalPrinters();
            if (lstPrinters != null && lstPrinters.Count > 0)
            {
                combWeightTempPrinterName.Properties.Items.AddRange(lstPrinters.ToArray());
                combWeightPrinterName.Properties.Items.AddRange(lstPrinters.ToArray());
            }
            cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.Weight != null) {
                chkStartVoicePrompt.Checked = cfg.Weight.StartVoicePrompt;
            }
            if (cfg != null) 
            {
                PrintCfg print = cfg.Print;
                FormHelper.BindControl<PrintCfg>(gpPrintConfig, print);
                rgPrintType.EditValue = print.Mode.ToString();
                chkPrintPhoto.Checked = print.PrintPhoto;
                combWeightPrinterName.Text = print.WeightPrinterName;
                combWeightTempPrinterName.Text = print.WeightTempPrinterName;
                chkAppendPrintTemp.Checked = print.AppendPrintTemp;
                chkStartReWeightTemplate.Checked = print.StartReWeightTemplate;
                chkStartPrintCountLimit.Checked = print.StartPrintCountLimit;
                teMaxPrintCount.Text = print.MaxPrintCount.ToString();
                txtRightTitle.Text = print.rightTitle;
            }
            Bind();
        }
        private void Bind() {
            voiceCfg = XmlUtil.Deserialize<VoiceCfg>(xmlPath);
            if (voiceCfg != null) {
                teOverWeight.Text = voiceCfg.OverWeight;
                teCarRecognition.Text = voiceCfg.CarRecognition;
                teCarStopFail.Text = voiceCfg.CarStopFail;
                teFirstWeight.Text = voiceCfg.FirstWeight;
                teReadCardFail.Text = voiceCfg.ReadCardFail;
                teReadCardSuccess.Text = voiceCfg.ReadCardSuccess;
                teSecondWeight.Text = voiceCfg.SecondWeight;
                teStartReadCard.Text = voiceCfg.StartReadCard;
                teStartWeight.Text = voiceCfg.StartWeight;
                teTimeOut.Text = voiceCfg.TimeOut;
                teWeightUnStable.Text = voiceCfg.WeightUnStable;
                teInfraredCovered.Text = voiceCfg.InfraredCovered;
                teUnloadWeight.Text = voiceCfg.UnloadWeight;
                rgBroadcastWeightType.EditValue = voiceCfg.BroadcastWeight.ToString();
            }
        }

        private void Save() 
        {
            if (chkStartPrintCountLimit.Checked && teMaxPrintCount.Text.ToInt() == 0) 
            {
                MessageDxUtil.ShowWarning("打印限制次数不能为0");
                return;
            }
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            PrintCfg print = cfg.Print;
            FormHelper.ControlToEntity<PrintCfg>(gpPrintConfig, ref print);
            print.Mode = rgPrintType.EditValue.ToEnum<PrintMode>();
            print.WeightPrinterName = combWeightPrinterName.Text;
            print.WeightTempPrinterName = combWeightTempPrinterName.Text;
            print.AppendPrintTemp = chkAppendPrintTemp.Checked;
            print.StartReWeightTemplate = chkStartReWeightTemplate.Checked;
            print.MaxPrintCount = teMaxPrintCount.Text.ToInt();
            print.StartPrintCountLimit = chkStartPrintCountLimit.Checked;
            print.PrintPhoto = chkPrintPhoto.Checked;
            print.rightTitle = txtRightTitle.Text;
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存打印设置信息");
        }

        private string GetSelectedField(CheckedListBoxControl chk) {
            StringBuilder sbField = new StringBuilder();
            for (int i = 0; i < chk.Items.Count; i++) {
                if (chk.Items[i].CheckState == CheckState.Checked) {
                    sbField.AppendFormat("{0};", chk.Items[i].Value);
                }
            }
            if (sbField.Length > 0) {
                sbField = sbField.Remove(sbField.Length - 1, 1);
            }
            return sbField.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e) {
            speechUtil.Speak(teTest.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e) {

        }
        private void Save2() {
            try {
                if (voiceCfg == null) {
                    voiceCfg = new VoiceCfg();
                }
                voiceCfg.OverWeight = teOverWeight.Text;
                voiceCfg.CarRecognition = teCarRecognition.Text;
                voiceCfg.CarStopFail = teCarStopFail.Text;
                voiceCfg.FirstWeight = teFirstWeight.Text;
                voiceCfg.ReadCardFail = teReadCardFail.Text;
                voiceCfg.ReadCardSuccess = teReadCardSuccess.Text;
                voiceCfg.SecondWeight = teSecondWeight.Text;
                voiceCfg.StartReadCard = teStartReadCard.Text;
                voiceCfg.StartWeight = teStartWeight.Text;
                voiceCfg.TimeOut = teTimeOut.Text;
                voiceCfg.WeightUnStable = teWeightUnStable.Text;
                voiceCfg.InfraredCovered = teInfraredCovered.Text;
                voiceCfg.UnloadWeight = teUnloadWeight.Text;
                voiceCfg.BroadcastWeight = rgBroadcastWeightType.EditValue.ToEnum<BroadcastWeightType>();
                XmlUtil.Serialize<VoiceCfg>(voiceCfg, xmlPath);
                CfgUtil.ResetVoiceCfg();
                if (cfg == null) cfg = CfgUtil.GetCfg();
                cfg.Weight.StartVoicePrompt = chkStartVoicePrompt.Checked;
                CfgUtil.SaveCfg(cfg);
                MessageDxUtil.ShowTips("成功保存语音文字配置信息.");
            } catch (Exception ex) {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存语音文字配置信息过程中出现未知错误,请重试.");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            Save();
        }
    }
}