using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.Utility.Gdi;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata.Enum;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmPay : DevExpress.XtraEditors.XtraForm
    {
        private IPayService payService = new PayService();
        private SpeechUtil speech = new SpeechUtil();
        private string weightId;

        public string WeightId
        {
            get { return weightId; }
            set { weightId = value; }
        }
        private string requestUrl;

        public string RequestUrl
        {
            get { return requestUrl; }
            set { requestUrl = value; }
        }
        public FrmPay()
        {
            InitializeComponent();
        }

        private void FrmPay_Load(object sender, EventArgs e)
        {
            LoadData();
            timerPay.Start();
        }

        private void LoadData() 
        {
            Bitmap image=QrCodeUtil.Create(requestUrl);
            peQrCode.Image = image;
        }

        private void timerPay_Tick(object sender, EventArgs e)
        {
            int payState = payService.GetPayState(weightId);
            if (payState == (int)PayState.PaySuccess) 
            {
                if (timerPay.Enabled) 
                {
                    timerPay.Stop();
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string message = "确实要取消支付,允许车辆离开吗?";
            if (MessageDxUtil.ShowYesNoAndTips(message) == DialogResult.Yes) 
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerPay!=null)
            {
                if(timerPay.Enabled)
                   timerPay.Stop();
                timerPay.Dispose();
            }
        }
        
    }
}