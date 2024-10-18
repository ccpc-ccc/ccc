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
using YF.Utility.Configuration;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Home
{
    public partial class FrmAbout : DevExpress.XtraEditors.XtraForm
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            lblRegisterDate.Visible = false;
            lblExpireDate.Visible = false;
            lblMachineCode.Text = string.Format(lblMachineCode.Text, CurrentClient.Instance.MachineCode);
            lblVersion.Text = string.Format(lblVersion.Text, Application.ProductVersion);
            lblAppName.Text=string.Format(lblAppName.Text,AppSetting.GetValue("appName"));
            lblRegisterDate.Text = string.Format(lblRegisterDate.Text, CurrentClient.Instance.RegisterDate.ToString("yyyy-MM-dd"));
            if (CurrentUser.Instance.IsAdministrator) 
            {
                //lblExpireDate.Visible = true;
            }
            lblRegisterCode.Text = string.Format(lblRegisterCode.Text, CurrentClient.Instance.RegisterCode);
            string fileName = CurrentClient.Instance.StartLogoUrl;
            if (File.Exists(fileName))
            {
                peWaitting.Image = Image.FromFile(fileName);
            }
        }

        private void FrmAbout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C) 
            {
                e.Handled = true;
                Clipboard.SetText(CurrentClient.Instance.MachineCode);
            }
        }

        private void btnCopyMachineCode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(CurrentClient.Instance.MachineCode);
                MessageDxUtil.ShowTips("成功复制机器码.");
            }
            catch (Exception ex) 
            {
                MessageDxUtil.ShowError("复制机器码时发生未知错误,请重试.");
                Logger.WriteException(ex);
            }
        }

        
    }
}