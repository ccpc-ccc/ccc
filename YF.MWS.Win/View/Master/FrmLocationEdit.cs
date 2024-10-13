using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Uc;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.MWS.CacheService;
using YF.MWS.Metadata.Dto;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmLocationEdit : BaseForm
    {
        private ILocationService masterService = new LocationService();
        private IWebClientService webClientService = new WebClientService();
        private SLocation location = null;

        public FrmLocationEdit()
        {
            InitializeComponent();
        }

        private void FrmLocationEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() 
        {
            DxHelper.BindComboBoxEdit(combLocationType, SysCode.LocationType, null);
            if (!string.IsNullOrEmpty(RecId))
            {
                location = masterService.GetLocation(RecId);
                if (location != null) 
                {
                    DxHelper.BindComboBoxEdit(combLocationType, SysCode.LocationType, location.LocationType);
                    teLocationCode.Text = location.LocationCode;
                    teLocationName.Text = location.LocationName;
                }
            }
        }

        private bool ValidateForm() 
        {
            bool isValidated = true;
            if (combLocationType.EditValue == null || combLocationType.EditValue.ToString().Length == 0) 
            {
                combLocationType.ErrorText = "请选择位置类别";
                isValidated = false;
                return isValidated;
            }
            if (teLocationCode.Text.Length == 0)
            {
                teLocationCode.ErrorText = "请输入位置编码";
                isValidated = false;
                return isValidated;
            }
            if (teLocationName.Text.Length == 0)
            {
                teLocationName.ErrorText = "请输入位置名称";
                isValidated = false;
                return isValidated;
            }
            return isValidated;
        }

        private void Save() 
        {
            if (!ValidateForm())
                return;
            if (location == null) 
            {
                location = new SLocation();
                location.Id = YF.MWS.Util.Utility.GetGuid();
            }
            location.LocationType = DxHelper.GetCode(combLocationType).ToEnum<LocationType>();
            location.LocationName = teLocationName.Text;
            location.LocationCode = teLocationCode.Text;
            bool isSaved = masterService.SaveLocation(location);
            if (isSaved)
            {
                MessageDxUtil.ShowTips("成功保存位置信息.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else 
            {
                MessageDxUtil.ShowWarning("保存位置信息时发生未知错误,请重试.");
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
