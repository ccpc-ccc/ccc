using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.Utility.Configuration;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmAd2 : SplashScreen {
        public bool autoClose { get; set; } = false;
        public FrmAd2()
        {
            InitializeComponent();
        }

        private void FrmAd_Load(object sender, EventArgs e) {
            string Notice = AppSetting.GetValue("Notice");
            string content = File.ReadAllText(Notice);
            richTextBox1.Rtf = content;
            timer1.Enabled = autoClose;
        }

        private void FrmAd_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e) {
            this.Close();
        }
    }
}