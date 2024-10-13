using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using System.Runtime.InteropServices;
using YF.MWS.Metadata;
using YF.Utility.Configuration;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmWelcome : DevExpress.XtraEditors.XtraForm
    {
        public FrmWelcome()
        {
            InitializeComponent();
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
            BindData();  
        }

        private void BindData() {
            string fileName = AppSetting.GetValue("mainBackUrl");
            if (File.Exists(fileName)) {
                peLogo.Image = Image.FromFile(fileName);
            }
        }
    }
}