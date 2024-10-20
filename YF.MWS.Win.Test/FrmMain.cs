using DevExpress.Utils.About;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
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
        private string _writeL = "E10ADC39";
        private string _writeH = "49BA59AB";
        private string _readL = "BE56E057";
        private string _readH = "F20F883E";
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
            } ;
            if (raFileType.EditValue.ToString() == "all") {
            cfg.AutoWeight = true;
            cfg.CarNoRecognition = true;
            }else if (raFileType.EditValue.ToString() == "car") {
            cfg.CarNoRecognition = true;
            }
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

        private void simpleButton1_Click(object sender, EventArgs e) {
            SoftKeyPWD et99 = new SoftKeyPWD();
            string KeyPath="";
            if (et99.FindPort(0, ref KeyPath) != 0)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后，再进行操作。");
                return;
            }
            int ret = et99.ReSet(KeyPath);
            if (ret != 0) {
                MessageBox.Show("加密狗初始化失败");
                return;
            }
            ret = et99.SetWritePassword("00000000", "00000000", _writeH, _writeL, KeyPath);
            if (ret != 0) {
                MessageBox.Show("设置写密码错误。"); return;
            }
            ret = et99.SetReadPassword(_writeH, _writeL, _readH, _readL, KeyPath);
            if (ret != 0) {
                MessageBox.Show("设置读密码错误。"); return;
            }
            string auth = "11111111";
            if (raType.EditValue.ToString() == "manual") auth = "10000111";
            else if (raType.EditValue.ToString() == "car") auth = "10001111";
             string lastUsedDate = DateTime.Now.ToString("yyyyMMdd");
            lastUsedDate=Encrypt.EncryptDES(lastUsedDate, CurrentClient.Instance.EncryptKey);
            auth += lastUsedDate;
             lastUsedDate = dateDongle.Time.ToString("yyyyMMdd");
            lastUsedDate = Encrypt.EncryptDES(lastUsedDate, CurrentClient.Instance.EncryptKey);
            auth += lastUsedDate;
            ret = et99.YWriteString(auth, 0, _writeH, _writeL, KeyPath);
            if (ret != 0) { MessageBox.Show("写字符串失败"); return; }
            MessageBox.Show("加密狗生成成功！");
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

        private void simpleButton3_Click(object sender, EventArgs e) {
            SoftKeyPWD et99 = new SoftKeyPWD();
            string KeyPath = "";
            if (et99.FindPort(0, ref KeyPath) != 0) {
                MessageBox.Show("未找到加密锁,请插入加密锁后，再进行操作。");
                return;
            }
            string outstring = "";
            int ret = et99.YReadString(ref outstring, 0, 56, _readH, _readL, KeyPath);
            if (ret != 0) {
                MessageBox.Show("读字符串失败"); return;
            }
            if (outstring.Length != 56) {
                MessageBox.Show("字符串长度错误"); return;
            }
            string message="";
            string auth = outstring.Substring(0, 8);
            if (auth == "11111111") {
                message="当前版本为：无人值守";
            } else if(auth == "10001111"){
                message="当前版本为：车牌识别版";
            } else if(auth == "10000111"){
                message="当前版本为：普通版";
            }
            string date = outstring.Substring(32, 24);
            date=Encrypt.DecryptDES(date, CurrentClient.Instance.EncryptKey);
            if (date.Length >= 8) {
            message += $"\r\n到期日期：{date.Substring(0,4)}年{date.Substring(4,2)}月{date.Substring(6,2)}日";
            }
            MessageBox.Show(message);
        }
    }
}
