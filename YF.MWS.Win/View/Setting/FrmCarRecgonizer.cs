using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.Utility;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmCarRecgonizer : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;

        public FrmCarRecgonizer()
        {
            InitializeComponent();
        }

        private void FrmCarRecgonizer_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null) 
            {
                string carNoRecognition = cfg.CarNoRecognition.Recognition;
                FormHelper.BindControl<CarNoRecognitionCfg>(gpCarNoRecognition, cfg.CarNoRecognition);
                DxHelper.BindComboBoxEdit(cmbRecognize, SysCode.CarNoRecognition, carNoRecognition);
                chkCarNoRecognition.Checked = cfg.StartCarNoRecognition;
                chkStartSameCarNoControl.Checked = cfg.CarNoRecognition.StartSameCarNoControl;
                teRecognitionTimeSpan.Text = cfg.CarNoRecognition.RecognitionTimeSpan.ToString();
                rgCarNoRecCondition.EditValue = cfg.CarNoRecognition.RecCondition.ToString();
                teIP1.Text = cfg.CarNoRecognition.IP1;
                tePort1.Text = cfg.CarNoRecognition.Port1.ToString();
                teIP2.Text = cfg.CarNoRecognition.IP2;
                tePort2.Text = cfg.CarNoRecognition.Port2.ToString();
                chkOutputVideo.Checked = cfg.CarNoRecognition.OutputVideo;
                chkOutputScreen.Checked = cfg.CarNoRecognition.OutputScreen;
                CarNoCfg carNo = cfg.CarNo;
                teAreaCode.Text = carNo.AreaCode;
                rgOutMode.EditValue = cfg.CarNo.OutMode.ToString();
                teLength.Text = cfg.CarNo.Length.ToString();
                rgCarLimitScopeType.EditValue = cfg.Weight.LimitScope.ToString();
                chkAutoLoadTareWeight.Checked = carNo.AutoLoadTareWeight;
                chkAutoSaveTareWeight.Checked = carNo.AutoSaveTareWeight;
                chkStartCarRecAdjust.Checked = cfg.CarNoRecognition.StartCarRecAdjust;
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
            CarNoRecognitionCfg carNoRec = cfg.CarNoRecognition;
            CarNoCfg carNo = cfg.CarNo;
            FormHelper.ControlToEntity<CarNoRecognitionCfg>(gpCarNoRecognition, ref carNoRec);
            cfg.StartCarNoRecognition = chkCarNoRecognition.Checked;
            cfg.CarNoRecognition.RecCondition = rgCarNoRecCondition.EditValue.ToEnum<CarNoRecCondition>();
            cfg.Weight.LimitScope = rgCarLimitScopeType.EditValue.ToEnum<CarLimitScopeType>();
            cfg.CarNoRecognition.OutputVideo = chkOutputVideo.Checked;
            cfg.CarNoRecognition.OutputScreen = chkOutputScreen.Checked;
            carNoRec.Recognition = DxHelper.GetCode(cmbRecognize);
            carNoRec.IP1 = teIP1.Text.Trim();
            carNoRec.Port1 = tePort1.Text.Trim().ToInt();
            carNoRec.IP2 = teIP2.Text.Trim();
            carNoRec.Port2 = tePort2.Text.Trim().ToInt();
            carNoRec.StartSameCarNoControl = chkStartSameCarNoControl.Checked;
            carNoRec.RecognitionTimeSpan = teRecognitionTimeSpan.Text.ToInt();
            carNo.AreaCode = teAreaCode.Text;
            cfg.CarNo.OutMode = rgOutMode.EditValue.ToEnum<CarNoOutMode>();
            cfg.CarNo.Length = teLength.Text.ToInt();
            cfg.CarNo.AutoLoadTareWeight = chkAutoLoadTareWeight.Checked;
            cfg.CarNo.AutoSaveTareWeight = chkAutoSaveTareWeight.Checked;
            cfg.CarNoRecognition.StartCarRecAdjust = chkStartCarRecAdjust.Checked;
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存车牌识别设置信息");
            Close();
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