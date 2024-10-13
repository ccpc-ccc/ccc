using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmQrCodeCfg : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;
        public FrmQrCodeCfg()
        {
            InitializeComponent();
        }

        private void FrmQrCodeCfg_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null && cfg.QrCode != null)
            {
                FormHelper.BindControl(gpShowQrCode, cfg.QrCode);
                if (string.IsNullOrEmpty(cfg.QrCode.WeightUrl))
                    teWeightUrl.Text = "http://open.rjhq.cn/h5/weight/detail.htm";
            }
        }

        private void Save()
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            QrCodeCfg qrCode = cfg.QrCode;
            FormHelper.ControlToEntity(gpShowQrCode, ref qrCode);
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存二维码显示设置信息");
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