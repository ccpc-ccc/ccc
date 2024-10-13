using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWarehEdit : BaseForm
    {
        private IWarehService warehService = new WarehService();
        private IWebCompanyService webCompanyService = new WebCompanyService();
        private SWareh wareh = null;
        public FrmWarehEdit()
        {
            InitializeComponent();
        }

        private void FrmWarehEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (teWarehCode.Text.Length == 0)
            {
                isValidated = false;
                teWarehCode.ErrorText = "编码不能为空";
            }
            if (teWarehName.Text.Length == 0)
            {
                isValidated = false;
                teWarehName.ErrorText = "名称不能为空";
            }
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (wareh == null)
                {
                    wareh = new SWareh();
                    wareh.Id = YF.MWS.Util.Utility.GetGuid();
                }
                FormHelper.ControlToEntity<SWareh>(this, ref wareh);
                warehService.Save(wareh);
                webCompanyService.SaveWareh(wareh);
                MessageDxUtil.ShowTips("成功保存仓库信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存仓库信息时发生未知错误,请重试.");
            }
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                wareh = warehService.Get(RecId);
                FormHelper.BindControl<SWareh>(this, wareh);
            }
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidateForm()) 
            {
                Save();
            }
        }
    }
}