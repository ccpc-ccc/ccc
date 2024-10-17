using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.Utility.Metadata;
using YF.Utility.Log;
using YF.Utility.Language;
using YF.MWS.CacheService;
using YF.MWS.Win.Uc;
using YF.Utility;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmMaterialDetail : BaseForm
    {
        private IMaterialService materialService = new MaterialService();

        private string _materialId;
        /// <summary>
        /// 物资编号
        /// </summary>
        public string MaterialId
        {
            get { return _materialId; }
            set { _materialId = value; }
        }
        private string CompanyId { get; set; }

        private SMaterial material;

        public FrmMaterialDetail(int index)
        {
            InitializeComponent();
            CompanyId = index.ToString();
        }

        private void FrmMaterialDetail_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            if (!string.IsNullOrEmpty(this._materialId))
            {
                material = materialService.GetMaterial(this._materialId);
                if (material != null) {
                teMaterialName.Text = material.MaterialName;
                    txtMaxWeight.Text = material.MaxWeight.ToString();
                    txtMinWeight.Text = material.MinWeight.ToString();
                }
            }
        }

        /// <summary>
        /// 验证输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool isValidated = true;

            if (teMaterialName.Text.Length==0)
            {
                teMaterialName.ErrorText = "请输入物资名称";
                isValidated = false;
            }
            if (txtMaxWeight.Text.ToDecimal() <= txtMinWeight.Text.ToDecimal()) {
                txtMaxWeight.ErrorText = "最低重量必须小于最高重量";
                isValidated = false;
            }
            return isValidated;
        }

        /// <summary>
        /// 保存物资信息
        /// </summary>
        private void Save()
        {
            try
            {
                if (ValidateForm())
                {
                    if (material==null)
                    {
                        material = new SMaterial();
                        material.Id = YF.MWS.Util.Utility.GetGuid();
                    }
                    material.MaterialName = teMaterialName.Text;
                    material.MinWeight = txtMinWeight.Text.ToDecimal();
                    material.MaxWeight = txtMaxWeight.Text.ToDecimal();
                    material.CompanyId = this.CompanyId;
                    bool isSaved= materialService.SaveMaterial(material);
                    if (isSaved) 
                    {
                        if (FrmMain != null)
                            FrmMain.LoadMaterial();
                        MaterialCacher.Refresh();
                    }
                    MessageDxUtil.ShowTips("成功保存物资信息.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存物资信息时发生未知错误,请重试.");
            }
        }

        private void teMaterialName_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}