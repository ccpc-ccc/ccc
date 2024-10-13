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

        private SMaterial material;

        public FrmMaterialDetail()
        {
            InitializeComponent();
        }

        private void FrmMaterialDetail_Load(object sender, EventArgs e)
        {
            this.InitData();
            this.BindData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //绑定物资类别
            DxHelper.BindComboBoxEdit(this.cmbMaterialType, SysCode.MaterialType, null);
            //绑定物资单位
            DxHelper.BindComboBoxEdit(this.cmbUnit, SysCode.MeasureUnit, null);
            //绑定启禁用状态
            //DxHelper.BindComboBoxEdit(this.cmbState, SysCode.State, null);
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
                FormHelper.BindControl<SMaterial>(this, this.material);
                chkState.Checked = material.State == 1 ? true : false;
                this.cmbMaterialType.Properties.Items.Clear();
                //绑定物资类别
                DxHelper.BindComboBoxEdit(this.cmbMaterialType, SysCode.MaterialType, this.material.MaterialType);
                this.cmbUnit.Properties.Items.Clear();
                //绑定物资单位
                DxHelper.BindComboBoxEdit(this.cmbUnit, SysCode.MeasureUnit, this.material.Unit);
                 
                //绑定启禁用状态
                //DxHelper.BindComboBoxEdit(this.cmbState, SysCode.State, this._material.State);
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
            if (isValidated)
            {
                SMaterial find = materialService.GetMaterialByName(teMaterialName.Text.Trim());
                if (find != null)
                {
                    if (material != null)
                    {
                        if (find.Id != material.Id)
                        {
                            MessageDxUtil.ShowWarning(string.Format("此物资({0})已经存在不能重复添加", teMaterialName.Text.Trim()));
                            isValidated = false;
                        }
                    }
                    else
                    {
                        MessageDxUtil.ShowWarning(string.Format("此物资({0})已经存在不能重复添加", teMaterialName.Text.Trim()));
                        isValidated = false;
                    }
                }
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
                    FormHelper.ControlToEntity<SMaterial>(this, ref material);
                    material.MaterialType = DxHelper.GetCode(this.cmbMaterialType);
                    material.Unit = DxHelper.GetCode(this.cmbUnit);
                    material.State = chkState.Checked? 1: 0;
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
            tePYMaterialName.Text = PinYinUtil.GetInitial(teMaterialName.Text);
        }
    }
}