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
using YF.MWS.Util;
using YF.MWS.Win.Util;
using YF.Utility.Configuration;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Manage
{
    public partial class FrmDbRestore : DevExpress.XtraEditors.XtraForm
    {
        public FrmDbRestore()
        {
            InitializeComponent();
        }

        private void btnItemRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                if (MessageDxUtil.ShowYesNoAndTips("确实要还原数据库吗?\n此操作会覆盖当前的最新数据,请谨慎操作.") == DialogResult.Yes)
                {
                    Restore();
                }
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK) 
            {
                txtFileDb.Text = ofdFile.FileName;
            }
        }

        private void FrmDbRestore_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (txtFileDb.Text.Length == 0)
            {
                txtFileDb.ErrorText = "请选择数据库文件.";
                isValidated = false;
            }
            return isValidated;
        }

        private void Restore() 
        {
            try
            {
                SqliteDb sqlDb = new SqliteDb();
                sqlDb.ClearConnection();
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSetting.GetValue("dsnSqlite"));
                File.Copy(txtFileDb.Text, dbPath,true);
                MessageDxUtil.ShowTips("成功还原数据库.");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("还原数据库过程中发生未知错误,请重试.");
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}