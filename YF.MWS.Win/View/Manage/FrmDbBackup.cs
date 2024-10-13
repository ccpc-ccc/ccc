using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.MWS.Win.Util;
using YF.Utility.Configuration;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Manage
{
    public partial class FrmDbBackup : DevExpress.XtraEditors.XtraForm
    {
        public FrmDbBackup()
        {
            InitializeComponent();
        }

        private void btnItemBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm())
            {
                Backup();
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (txtFileDb.Text.Length == 0) 
            {
                txtFileDb.ErrorText = "请设置要保存的备份文件路径.";
                isValidated = false;
            }
            return isValidated;
        }
        
        private void Backup() 
        {
            try
            {
                string dbFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSetting.GetValue("dsnSqlite"));
                string backDbFileName = txtFileDb.Text;
                File.Copy(dbFileName, backDbFileName, true);
                MessageDxUtil.ShowTips("成功备份数据库.");
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("备份数据库过程中发生未知错误,请重试.");
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        { 
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                txtFileDb.EditValue = sfdFile.FileName;
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}