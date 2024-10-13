using DevExpress.Utils.About;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using DevExpress.Utils.Zip;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Security;
using YF.Utility.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace YF.MWS.Win.Test
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (txtCode.Text=="") {
                MessageBox.Show("注册码不能为空！");
                return;
            }
            string path = string.Format(@"{0}.yrg", txtCode.Text);
            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            AuthCfg cfg =new AuthCfg() {
                StartFinance= true,
                StartOnline= true,
                StartPad= true,
                StartScreen= true,
                StartVideo=true
            };
            cfg.AutoWeight = raFileType.EditValue.ToString() == "all";
            cfg.CarNoRecognition = raFileType.EditValue.ToString() == "all";
            string line3=Encrypt.EncryptDES(cfg.JsonSerialize(), CurrentClient.Instance.EncryptKey);
            string startDate = endDate.Time.ToString("yyyyMMdd");
            string line1 = Encrypt.EncryptDES(startDate, CurrentClient.Instance.EncryptKey);
            string line2 = Encrypt.EncryptDES(100.ToString(), CurrentClient.Instance.EncryptKey);
            string csvStr = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}", SoftRegister.GenerateRegisterCode(txtCode.Text), line1, line2, line3);
            writer.Write(csvStr);
            writer.Close();
            MessageBox.Show("文件生成成功！");
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            endDate.Time = DateTime.Now.AddYears(1);
            dateDongle.Time = DateTime.Now.AddYears(3);
        }

        private void btnVerify_Click(object sender, EventArgs e) {
            int authCode = CodeUtil.GetAuthCode(teRandCode.Text.ToInt());
            teAuthCode.Text = authCode.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            SoftKeyPWD et99 = new SoftKeyPWD();
            string KeyPath="";
            if (et99.FindPort(0, ref KeyPath) != 0)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后，再进行操作。");
                return;
            }
           /* txtPID2.Text=et99.GenPID("12345678");
            et99.WriteData("11111111", 0);
            string lastUsedDate = DateTime.Now.ToString("yyyyMMdd");
            et99.WriteData(Encrypt.EncryptDES(lastUsedDate, CurrentClient.Instance.EncryptKey), 8);
            lastUsedDate = dateDongle.Time.ToString("yyyyMMdd");
            et99.WriteData(Encrypt.EncryptDES(lastUsedDate, CurrentClient.Instance.EncryptKey), 32);
            et99.WriteData(Encrypt.EncryptDES(0.ToString(), CurrentClient.Instance.EncryptKey), 56);
            et99.WriteData(Encrypt.EncryptDES(100.ToString(), CurrentClient.Instance.EncryptKey), 68);
            et99.WriteData(et99.GetSN(), 80);*/
            MessageBox.Show("加密狗生成失败！");
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            try {
                string[] fileNames = Directory.GetFiles(txtFilePath.Text);
                foreach (string fileName in fileNames) {
                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.Extension == ".dll" || fileInfo.Extension == ".exe") {
                        string name = txtPackPath.Text+"/"+ fileInfo.Name;
                        System.IO.File.Copy(fileName, fileInfo.Name, true);
                    }
                }
                FastZip fastZip = new FastZip();
                fastZip.CreateEmptyDirectories = true;
                fastZip.CreateZip(txtPackPath.Text+".zip", txtPackPath.Text,false,null);
            } catch (Exception ex) {
                Console.WriteLine("发生错误：" + ex.Message);
            }
        }
    }
}
