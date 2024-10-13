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
using YF.MWS.BaseMetadata;
using Microsoft.Win32;
using YF.Utility.Log;
using YF.Utility.Configuration;

namespace YF.MWS.Win.View.Setting
{
    public partial class FrmWeighWay : DevExpress.XtraEditors.XtraForm
    {
        private SysCfg cfg;

        public FrmWeighWay()
        {
            InitializeComponent();
        }

        private void FrmWeighWay_Load(object sender, EventArgs e) {
            string use = AppSetting.GetValue("use");
            cfg = CfgUtil.GetCfg();
            rbNobody.Visible = false;
            gpNobody.Visible = false;
            AuthCfg authCfg = CfgUtil.GetAuth();
            if (authCfg.AutoWeight)
            {
                rbNobody.Visible = true;
                gpNobody.Visible = true;
            }
            if (cfg != null) 
            {
                WeightCfg weight = cfg.Weight;
                WeightStableCfg weightStable = cfg.WeightStable;
                chkPeopleInfrared.Checked = cfg.PeopleWeight.StartInfrared;
                txtMinWeight.Text = cfg.NobodyWeight.MinWeightValue.ToString();
                txtAutoSaveTime.Text = cfg.NobodyWeight.AutoSaveTime.ToString();
                txtOutWeight.Text = cfg.NobodyWeight.OutWeightValue.ToString();
                txtAutoOutTime.Text = cfg.NobodyWeight.AutoOutTime.ToString();
                chkStartSaveWithManualFirst.Checked = cfg.NobodyWeight.StartSaveWithManualFirst;
                chkStartSaveWithManualSecond.Checked = cfg.NobodyWeight.StartSaveWithManualSecond;
                rgWeightProcessTriggerType.EditValue = weight.WeightProcessTrigger.ToString();
                teWeightDeviation.Text = weightStable.WeightDeviation.ToString();
                teMinCredibleWeight.Text = weightStable.MinCredibleWeight.ToString();
                spSamplingCount.Value = weightStable.SamplingCount;
                teSampingInterval.Text = weightStable.SampingInterval.ToString();
                SetMeasureTypeChecked(cfg.MeasureFun);
                if (cfg.MeasureFun.ToEnum<WeightWay>() == WeightWay.Nobody)
                {
                    gpNobody.Enabled = true;
                }
                else
                {
                    gpNobody.Enabled = false;
                }
            #region 称重设置
                OverWeightCfg overWeight = cfg.OverWeight;
                FormHelper.BindControl(plMain, weight);
                chkStartOverWeight.Checked = overWeight.Start;
                teMaxWeight.Text = overWeight.MaxWeight.ToString();
                chkStartCustomerBalanceLimit.Checked = weight.StartCustomerBalanceLimit;
                chkGrossTareTransform.Checked = weight.GrossTareTransform;
                chkShowShortCut.Checked = weight.ShowShortCut;
                chkSaveFormData.Checked = weight.SaveFormData;
                chkLoadImageWithRemote.Checked = weight.StartLoadImageWithRemote;
                rgLoadUnfinishWeight.EditValue = weight.LoadUnfinishWeight.ToString();
                chkWeightProcessCfg.Checked = weight.StartWeightProcessCfg;
                rgWeightProcess.EditValue = weight.Process.ToString();
                chkGrossTareTransform.Checked = weight.GrossTareTransform;
                chkAutoRun.Checked = weight.AutoRun;
                chkAutoReset.Checked = weight.StartAutoReset;
                teIdleMinutes.Text = weight.IdleMinutes.ToString();
                rgMeasureProcessMode.EditValue = weight.ProcessMode.ToString();
                chkStartAutoInvalid.Checked = weight.StartAutoInvalid;
                teUnfinishedTimeOut.Text = weight.UnfinishedTimeOut.ToString();
                rgWeightNoGenerateMode.EditValue = weight.WeightNoGenerateMode.ToString();
                chkGenerateWeightNoByRand.Checked = weight.GenerateWeightNoByRand;
                chkShareWeight.Checked = weight.ShareWeight;
                btnSelectBackupDbDirectory.Text = weight.BackupDir;
                if (string.IsNullOrEmpty(btnSelectBackupDbDirectory.Text))
                    btnSelectBackupDbDirectory.Text = @"D:\MWS\DataBack";
            #endregion
            }
            if (use != "all") {
                this.xtraTabPage1.PageVisible = false;
            }
        }

        private void rbPeople_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPeople.Checked)
            {
                SetMeasureTypeChecked(rbPeople.Tag.ToString());
                gpNobody.Enabled = false;
            }
        }

        private void rbNobody_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNobody.Checked)
            {
                SetMeasureTypeChecked(rbNobody.Tag.ToString());
                gpNobody.Enabled = true;
            }
        }

        private void SetMeasureTypeChecked(string currentCheckedType)
        {
            if (rbPeople.Tag.ToString() == currentCheckedType)
            {
                rbPeople.Checked = true;
                rbNobody.Checked = false;
            }
            if (rbNobody.Tag.ToString() == currentCheckedType)
            {
                rbPeople.Checked = false;
                rbNobody.Checked = true;
            }
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private string GetMeasureType()
        {
            string measureType = WeightWay.People.ToString();
            if (rbNobody.Checked)
            {
                measureType = WeightWay.Nobody.ToString();
            }
            return measureType;
        }

        private void Save() 
        {
            if (cfg == null)
            {
                cfg = CfgUtil.GetCfg();
                if (cfg == null)
                    cfg = new SysCfg();
            }
            cfg.MeasureFun = GetMeasureType();
            WeightWay way = cfg.MeasureFun.ToEnum<WeightWay>();
            if (way == WeightWay.Nobody)
            {
                if ((string.IsNullOrEmpty(txtMinWeight.Text.Trim()) || txtMinWeight.Text.Trim().ToDecimal() <= 0) || (string.IsNullOrEmpty(txtAutoSaveTime.Text.Trim()) || txtAutoSaveTime.Text.Trim().ToDecimal() <= 0))
                {
                    MessageDxUtil.ShowTips("无人职守模式必须设置起磅重量和自动保存时间！");
                    return;
                }
                else
                {
                    cfg.NobodyWeight.MinWeightValue = txtMinWeight.Text.Trim().ToDecimal();
                    cfg.NobodyWeight.AutoSaveTime = txtAutoSaveTime.Text.ToDecimal();
                }
                if ((string.IsNullOrEmpty(txtOutWeight.Text.Trim()) || txtOutWeight.Text.Trim().ToDecimal() <= 0) || (string.IsNullOrEmpty(txtAutoOutTime.Text.Trim()) || txtAutoOutTime.Text.Trim().ToDecimal() <= 0))
                {
                    MessageDxUtil.ShowTips("无人职守模式必须设置落杆重量和自动落杆时间！");
                    return;
                }
                else
                {
                    cfg.NobodyWeight.OutWeightValue = txtOutWeight.Text.Trim().ToDecimal();
                    cfg.NobodyWeight.AutoOutTime = txtAutoOutTime.Text.Trim().ToDecimal();
                }
                cfg.NobodyWeight.StartSaveWithManualFirst = chkStartSaveWithManualFirst.Checked;
                cfg.NobodyWeight.StartSaveWithManualSecond = chkStartSaveWithManualSecond.Checked;
            }
            cfg.Weight.WeightProcessTrigger = rgWeightProcessTriggerType.EditValue.ToEnum<WeightProcessTriggerType>();
            cfg.PeopleWeight.StartInfrared = chkPeopleInfrared.Checked;
            WeightStableCfg weightStable = cfg.WeightStable;
            weightStable.WeightDeviation = teWeightDeviation.Text.ToDecimal();
            weightStable.MinCredibleWeight = teMinCredibleWeight.Text.ToDecimal();
            weightStable.SamplingCount = spSamplingCount.Value.ToInt();
            weightStable.SampingInterval = teSampingInterval.Text.ToDecimal();
            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存过磅方式设置信息");
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Save2();
        }
        private void Save2() {
            if (cfg == null) {
                cfg = CfgUtil.GetCfg();
            }
            WeightCfg weight = cfg.Weight;
            OverWeightCfg overWeight = cfg.OverWeight;
            FormHelper.ControlToEntity<WeightCfg>(plMain, ref weight);
            overWeight.Start = chkStartOverWeight.Checked;
            overWeight.MaxWeight = teMaxWeight.Text.Trim().ToDecimal();
            weight.GrossTareTransform = chkGrossTareTransform.Checked;
            weight.ShowShortCut = chkShowShortCut.Checked;
            weight.SaveFormData = chkSaveFormData.Checked;
            weight.StartLoadImageWithRemote = chkLoadImageWithRemote.Checked;
            weight.StartWeightProcessCfg = chkWeightProcessCfg.Checked;
            weight.StartCustomerBalanceLimit = chkStartCustomerBalanceLimit.Checked;
            weight.Process = rgWeightProcess.EditValue.ToEnum<WeightProcess>();
            weight.LoadUnfinishWeight = rgLoadUnfinishWeight.EditValue.ToEnum<LoadUnfinishWeightType>();
            weight.AutoLogin = chkAutoLogin.Checked;
            weight.StartValidateCarWithCard = chkStartValidateCarWithCard.Checked;
            weight.AutoRun = chkAutoRun.Checked;
            weight.StartAutoReset = chkAutoReset.Checked;
            weight.IdleMinutes = teIdleMinutes.Text.ToDecimal();
            weight.ProcessMode = rgMeasureProcessMode.EditValue.ToEnum<MeasureProcessMode>();
            weight.StartAutoInvalid = chkStartAutoInvalid.Checked;
            weight.UnfinishedTimeOut = teUnfinishedTimeOut.Text.ToInt();
            weight.WeightNoGenerateMode = rgWeightNoGenerateMode.EditValue.ToEnum<FinishState>();
            weight.GenerateWeightNoByRand = chkGenerateWeightNoByRand.Checked;
            weight.BackupDir = btnSelectBackupDbDirectory.Text;
            weight.ShareWeight = chkShareWeight.Checked;

            AutoStart(weight.AutoRun);

            CfgUtil.SaveCfg(cfg);
            MessageDxUtil.ShowTips("成功保存称重设置信息");
        }
        private void AutoStart(bool isAutoStart) {
            RegistryKey reg = null;
            string name = "MWS";
            string file = Application.StartupPath + "\\" + "MWS.exe";
            try {
                RegistryKey localKey;
                bool is64BitSys = false;
                if (Environment.Is64BitOperatingSystem) {
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    is64BitSys = true;
                } else
                    localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                if (is64BitSys) {
                    reg = localKey.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (reg != null) {
                        if (isAutoStart) {
                            reg.SetValue(name, file);
                        } else {
                            reg.SetValue(name, "false");
                        }
                    }
                } else {
                    reg = localKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (reg != null) {
                        if (isAutoStart) {
                            reg.SetValue(name, file);
                        } else {
                            reg.SetValue(name, "false");
                        }
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            } finally {
                if (reg != null) {
                    reg.Close();
                }
            }
        }

        private void btnSelectBackupDbDirectory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
            folderOpen.RootFolder = Environment.SpecialFolder.Desktop;
            folderOpen.SelectedPath = btnSelectBackupDbDirectory.Text;
            if (folderOpen.ShowDialog() == DialogResult.OK) {
                btnSelectBackupDbDirectory.Text = folderOpen.SelectedPath;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            Save();
        }
    }
}