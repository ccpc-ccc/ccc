using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using DevExpress.XtraBars;
using YF.Utility.Log;
using YF.Utility;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmControlEdit : BaseForm
    {
        private List<Type> lstType = new List<Type>();
        private IWeightViewService viewService = new WeightViewService();
        private SControl control;
        public FrmControlEdit()
        {
            InitializeComponent();
        }

        private void FrmControlEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() 
        { 
            if (!string.IsNullOrEmpty(RecId))
            {
                control = viewService.GetControl(RecId);
                FormHelper.BindControl<SControl>(this, control);
                DxHelper.BindComboBoxEdit(combWeightControl, SysCode.WeightControl, control.FullName);
                chkIsRequired.Checked = control.IsRequired == 1 ? true : false;
                checkEdit1.Checked = control.IsViewShow == 1 ? true : false;
                //teFieldName.Enabled = false;
            }
            else 
            {
                DxHelper.BindComboBoxEdit(combWeightControl, SysCode.WeightControl, null);
            }
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void Save() 
        {
            try
            {
                if (control == null)
                {
                    if (viewService.GetControlByName(teFieldName.Text) != null) 
                    {
                        MessageDxUtil.ShowWarning(string.Format("属性名称为{0}的控件已经存在,请用其他的属性名称.", teFieldName.Text));
                        return;
                    }
                    control = new SControl();
                    control.Id = YF.MWS.Util.Utility.GetGuid();
                }
                FormHelper.ControlToEntity<SControl>(this, ref control);
                control.FullName = DxHelper.GetCode(combWeightControl);
                control.IsRequired = chkIsRequired.Checked ? 1:0;
                viewService.SaveConrol(control);
                MessageDxUtil.ShowTips("成功保存控件信息.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存控件信息时发生未知错误,请重试.");
            }
        }
    }
}