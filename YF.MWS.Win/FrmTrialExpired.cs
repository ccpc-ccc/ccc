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
using YF.MWS.Db;
using YF.MWS.Win.View.User;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.Utility.Configuration;
using YF.MWS.Win.View.Home;
using YF.MWS.Metadata;

namespace YF.MWS.Win
{
    public partial class FrmTrialExpired : DevExpress.XtraEditors.XtraForm
    {
        private IClientService clientService = new ClientService();
        public FrmTrialExpired()
        {
            InitializeComponent();
        }

        private void FrmTrialExpired_Load(object sender, EventArgs e)
        { 
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                if (!string.IsNullOrEmpty(CurrentClient.Instance.StartLogoUrl))
                {
                    string fileName = Path.Combine(Application.StartupPath, CurrentClient.Instance.StartLogoUrl);
                    if (File.Exists(fileName))
                    {
                        peWaitting.Image = Image.FromFile(fileName);
                    }
                }
            }
            else
            {
                SCompany company = MasterCacher.GetCompany();
                if (company != null && company.StartLogo != null)
                {
                    peWaitting.EditValue = company.StartLogo;
                }
            }
        }

        private void btnExtendProbation_Click(object sender, EventArgs e)
        {
            //ExtendProbation();
            using (FrmTrialExpiredHandle frm = new FrmTrialExpiredHandle())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void ExtendProbation()
        {
            using (FrmAuth frmAuth = new FrmAuth())
            {
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    bool isSuccess = false;
                    isSuccess = clientService.UpdateProbation(CurrentClient.Instance.MachineCode, 7);
                    if (isSuccess)
                    {
                        MessageDxUtil.ShowTips("成功延长试用期.");
                    }
                    else
                    {
                        MessageDxUtil.ShowError("延长试用期时发生未知错误,请重试.");
                    }
                }
            }
        }

        private void btnConvertOfficial_Click(object sender, EventArgs e)
        {
            AppConfigUtil.SetConfigValue("version", VersionType.Official.ToString());
            MessageDxUtil.ShowTips("已经设为正式版,请关闭此窗口,重启程序.");
        }

        private void btnAddConsult_Click(object sender, EventArgs e)
        {
            FrmConsult frmConsult = new FrmConsult();
            if (frmConsult.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

    }
}