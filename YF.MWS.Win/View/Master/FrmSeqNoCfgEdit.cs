using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Db;
using YF.MWS.Win.Util;
using YF.MWS.Metadata.Query;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Metadata;
using YF.MWS.Win.Uc;
using YF.Utility;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmSeqNoCfgEdit : BaseForm
    {
        private ISeqNoService seqNoService = new SeqNoService();
        private SSeqNo seq;
        public FrmSeqNoCfgEdit()
        {
            InitializeComponent();
        }

        private void FrmSeqNoCfgEdit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (combDateFomart.Text.Length == 0)
            {
                combDateFomart.ErrorText = "请选择日期格式";
                isValidated = false;
            }
            if (teFixedLen.Text.ToInt() <= 0)
            {
                teFixedLen.ErrorText = "请输入总长度";
                isValidated = false;
            }
            return isValidated;
        }

        private void Save()
        {
            try
            {
                if (ValidateForm())
                {
                    if (seq == null)
                    {
                        seq = new SSeqNo();
                        seq.Id = YF.MWS.Util.Utility.GetGuid();
                    }
                    FormHelper.ControlToEntity<SSeqNo>(this, ref seq);
                    seq.DateFomart = DxHelper.GetCode(combDateFomart);
                    seqNoService.Save(seq);
                    MessageDxUtil.ShowTips("成功保存序列号配置信息.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存序列号配置时发生未知错误,请重试.");
            }
        }

        private void BindData()
        {
            if (string.IsNullOrEmpty(RecId))
            {
                DxHelper.BindComboBoxEdit(combDateFomart, SysCode.DateFomart, null);
            }
            else
            {
                seq = seqNoService.Get(RecId);
                if (seq != null)
                {
                    DxHelper.BindComboBoxEdit(combDateFomart, SysCode.DateFomart, seq.DateFomart);
                    FormHelper.BindControl<SSeqNo>(this, seq);
                    teSeqCodeCaption.Text = MasterCacher.GetCodeCapiton(SysCode.SeqCode.ToString(), seq.SeqCode);
                }
            }
        }

        private void btnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void btnItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}