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
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata;
using YF.MWS.BaseMetadata;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWarehEdit : Form
    {
        private IWarehService warehService = new WarehService();
        private VWareh wareh = null;
        public string RecId { get; set; }
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
                    wareh = new VWareh();
                    wareh.Id = YF.MWS.Util.Utility.GetGuid();
                }
                wareh.WarehCode = teWarehCode.Text;
                wareh.CloseAddress = txtClose.Text;
                wareh.OpenAddress = txtOpen.Text;
                warehService.Save2(wareh);
                MessageBox.Show("成功保存仓库信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageBox.Show("保存仓库信息时发生未知错误,请重试.","错误");
            }
        }

        private void BindData()
        {
            if (!string.IsNullOrEmpty(RecId))
            {
                wareh = warehService.Get(RecId);
                if (wareh != null) {
                    teWarehCode.Text = wareh.WarehCode;
                    teWarehName.Text = wareh.WarehName;
                    txtClose.Text = wareh.CloseAddress;
                    txtOpen.Text = wareh.OpenAddress;
                }
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