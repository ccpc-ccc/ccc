using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Cfg;
using System.IO;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmVoice : DevExpress.XtraEditors.XtraForm
    {
        private BWeight weight;
        private SpeechUtil speecher;

        public SpeechUtil Speecher
        {
            get { return speecher; }
            set { speecher = value; }
        }

        public BWeight Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public FrmVoice()
        {
            InitializeComponent();
        }

        private void FrmVoice_Load(object sender, EventArgs e) {
            speecher = new SpeechUtil();
            Bind();
        }

        private void Bind()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "VoiceCfg.xml");
            VoiceCfg cfg = XmlUtil.Deserialize<VoiceCfg>(xmlPath);
            if (cfg != null)
            {
                teOverWeight.Text = cfg.OverWeight;
                teCarRecognition.Text = cfg.CarRecognition;
                teCarStopFail.Text = cfg.CarStopFail;
                teFirstWeight.Text = cfg.FirstWeight;
                teReadCardFail.Text = cfg.ReadCardFail;
                teReadCardSuccess.Text = cfg.ReadCardSuccess;
                teSecondWeight.Text = cfg.SecondWeight;
                teStartReadCard.Text = cfg.StartReadCard;
                teStartWeight.Text = cfg.StartWeight;
                teTimeOut.Text = cfg.TimeOut;
                teWeightUnStable.Text = cfg.WeightUnStable;
                teInfraredCovered.Text = cfg.InfraredCovered;
                teUnloadWeight.Text = cfg.UnloadWeight;
            }
        }

        private void Speek(string text) 
        {
            if (speecher == null || string.IsNullOrEmpty(text))
                return;
            speecher.Speak(text);
        }

        private void btnStartReadCard_Click(object sender, EventArgs e)
        {
            Speek(teStartReadCard.Text);
        }

        private void btnReadCardSuccess_Click(object sender, EventArgs e)
        {
            Speek(teReadCardSuccess.Text);
        }

        private void btnReadCardFail_Click(object sender, EventArgs e)
        {
            Speek(teReadCardFail.Text);
        }

        private void btnCarRecognition_Click(object sender, EventArgs e)
        {
            Speek(teCarRecognition.Text);
        }

        private void btnStartWeight_Click(object sender, EventArgs e)
        {
            Speek(teStartWeight.Text);
        }

        private void btnTimeOut_Click(object sender, EventArgs e)
        {
            Speek(teTimeOut.Text);
        }

        private void btnCarStopFail_Click(object sender, EventArgs e)
        {
            Speek(teCarStopFail.Text);
        }

        private void btnWeightUnStable_Click(object sender, EventArgs e)
        {
            if (weight != null)
            {
                Speek(string.Format(teWeightUnStable.Text, weight.SuttleWeight));
            }
            else
            {
                Speek(teWeightUnStable.Text);
            }
        }

        private void btnInfraredCovered_Click(object sender, EventArgs e)
        {
            Speek(teInfraredCovered.Text);
        }

        private void btnOverWeight_Click(object sender, EventArgs e)
        {
            Speek(teOverWeight.Text);
        }

        private void btnFirstWeight_Click(object sender, EventArgs e)
        {
            if (weight != null)
            {
                Speek(string.Format(teFirstWeight.Text, weight.SuttleWeight));
            }
            else 
            {
                Speek(teFirstWeight.Text);
            }
        }

        private void btnSecondWeight_Click(object sender, EventArgs e)
        {
            if (weight != null)
            {
                Speek(string.Format(teSecondWeight.Text, weight.SuttleWeight));
            }
            else
            {
                Speek(teSecondWeight.Text);
            }
        }

        private void btnUnloadWeight_Click(object sender, EventArgs e)
        {
            Speek(teUnloadWeight.Text);
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}