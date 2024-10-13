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
using DevExpress.XtraNavBar.ViewInfo;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.Utility.Configuration;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmAd : BaseForm {
        private ICommonService _commonService = new CommonService();
        BCommon _common = new BCommon();
        public FrmAd()
        {
            InitializeComponent();
        }

        private void FrmAd_Load(object sender, EventArgs e) {
            string Notice = AppSetting.GetValue("Notice");
            string content = File.ReadAllText(Notice);
            richTextBox1.Rtf = content;
        }

        private void FrmAd_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnItemFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string Notice = AppSetting.GetValue("Notice");
            richTextBox1.SaveFile(Notice, RichTextBoxStreamType.RichText);
            MessageBox.Show("保存成功！");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.png";
            if(ofd.ShowDialog() == DialogResult.OK) {
                string path=ofd.FileName;
                using (Image myImage = Image.FromFile(path)) {
                    Clipboard.SetDataObject(myImage);
                richTextBox1.Paste();
                }
            }
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.Close();
        }
    }
}