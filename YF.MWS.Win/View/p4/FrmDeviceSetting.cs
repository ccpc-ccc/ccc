using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.MWS.Metadata.Cfg;
using YF.Utility;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.BaseMetadata;
using System.Runtime.InteropServices.ComTypes;

namespace YF.MWS.Win.View.Master {
    public partial class FrmDeviceSetting : DevExpress.XtraEditors.XtraForm {
        private IWeightViewService weightViewService = new WeightViewService();
        private SysCfg cfg;
        private int modbusNo = 1;

        /// <summary>
        /// 串口
        /// </summary>
        private SerialPortHelper serialPort1;//1号仪表
        private SerialPortHelper serialPort2;//2号仪表

        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        private delegate void ShowData(string value);

        private ShowData OnShowData;
        public FrmDeviceSetting() {
            InitializeComponent();
        }

        private void FrmDeviceSetting_Load(object sender, EventArgs e) {
            cfg = CfgUtil.GetCfg();
            InitSerialPort();
            SetDeviceInfo1();
            SetDeviceInfo2();
            this.SetComInfo1();
            this.SetComInfo1_2();
        }

        #region 设置串口及仪表信息

        /// <summary>
        /// 设置串口信息
        /// </summary>
        private void SetComInfo1() {
            //COM端口
            cmbCom1.Properties.Items.Add(" ");
            foreach (string item in SerialPort.GetPortNames()) {
                cmbCom1.Properties.Items.Add(item);
            }
            this.cmbCom1.EditValue = cfg.Device1.Port;
            cmbBaudRate1.Text = cfg.Device1.BaundRate;
            cmbDataBits1.Text = cfg.Device1.DataBit;
            DxHelper.BindComboBoxEdit<Metadata.StopBits>(cmbStopBits1, cfg.Device1.StopBit);
            DxHelper.BindComboBoxEdit<Metadata.Parity>(cmbParity1, cfg.Device1.Parity);
            if (cfg.Device1.DataFormat == "DEC") {
                this.radioDigit1.SelectedIndex = 0;
            } else {
                this.radioDigit1.SelectedIndex = 1;
            }
        }
        private void SetComInfo1_2() {
            //COM端口
            cmbCom1_2.Properties.Items.Add(" ");
            foreach (string item in SerialPort.GetPortNames()) {
                cmbCom1_2.Properties.Items.Add(item);
            }
            this.cmbCom1_2.EditValue = cfg.Device1.Port;
            cmbBaudRate1_2.Text = cfg.Device2.BaundRate;
            cmbDataBits1_2.Text = cfg.Device2.DataBit;
            DxHelper.BindComboBoxEdit<Metadata.StopBits>(cmbStopBits1_2, cfg.Device2.StopBit);
            DxHelper.BindComboBoxEdit<Metadata.Parity>(cmbParity1_2, cfg.Device2.Parity);
            if (cfg.Device2.DataFormat == "DEC") {
                this.radioDigit1_2.SelectedIndex = 0;
            } else {
                this.radioDigit1_2.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 设置称重设备信息
        /// </summary>
        private void SetDeviceInfo1() {
            DxHelper.BindComboBoxEdit(cmbDevice1, SysCode.Device, cfg.Device1.Version);
            DxHelper.BindComboBoxEdit(cmbDUnit1, SysCode.MeasureUnit, cfg.Device1.DUnit);
            DxHelper.BindComboBoxEdit(cmbSUnit1, SysCode.MeasureUnit, cfg.Device1.SUnit);
            DxHelper.BindComboBoxEdit(cmbFormat1, SysCode.ShowFormat, cfg.Device1.ShowFormat);
            DxHelper.BindComboBoxEdit(cmbDivision1, SysCode.DivisionValue, cfg.Device1.Division);
            switch (cfg.Device1.ComFun) {
                case "0":
                    rgComFun1.SelectedIndex = 0;
                    break;
                case "2":
                    rgComFun1.SelectedIndex = 1;
                    break;
                case "3":
                    rgComFun1.SelectedIndex = 2;
                    break;
                default:
                    rgComFun1.SelectedIndex = 0;
                    break;
            }
            DxHelper.BindComboBoxEdit(cmbCode1, SysCode.CustomCode, cfg.Device1.CustomCode);
            this.txtDataStart1.Text = cfg.Device1.DataStart;
            this.txtIntercept1.Text = cfg.Device1.Intercept;
            this.txtDataLength1.Text = cfg.Device1.DataLength;
            this.chkStartDevice1.Checked = cfg.Device1.StartDevice;
            this.txtPoint1.Text = cfg.Device1.Point;
            this.chkReturnZero1.Checked = cfg.Device1.StartReturnZero;
            this.rgSendReturnZeroProcess1.EditValue = cfg.Device1.SendReturnZeroProcess.ToString();
            this.teReturnZeroCommand1.Text = cfg.Device1.ReturnZeroCommand;
            DxHelper.BindComboBoxEdit(cmbSequence1, SysCode.Sequence, cfg.Device1.Sequence);
        }
        private void SetDeviceInfo2() {
            DxHelper.BindComboBoxEdit(cmbDevice1_2, SysCode.Device, cfg.Device2.Version);
            DxHelper.BindComboBoxEdit(cmbDUnit1_2, SysCode.MeasureUnit, cfg.Device2.DUnit);
            DxHelper.BindComboBoxEdit(cmbSUnit1_2, SysCode.MeasureUnit, cfg.Device2.SUnit);
            DxHelper.BindComboBoxEdit(cmbFormat1_2, SysCode.ShowFormat, cfg.Device2.ShowFormat);
            DxHelper.BindComboBoxEdit(cmbDivision1_2, SysCode.DivisionValue, cfg.Device2.Division);
            switch (cfg.Device2.ComFun) {
                case "0":
                    rgComFun1_2.SelectedIndex = 0;
                    break;
                case "2":
                    rgComFun1_2.SelectedIndex = 1;
                    break;
                case "3":
                    rgComFun1_2.SelectedIndex = 2;
                    break;
                default:
                    rgComFun1_2.SelectedIndex = 0;
                    break;
            }
            DxHelper.BindComboBoxEdit(cmbCode1_2, SysCode.CustomCode, cfg.Device2.CustomCode);
            this.txtDataStart1_2.Text = cfg.Device2.DataStart;
            this.txtIntercept1_2.Text = cfg.Device2.Intercept;
            this.txtDataLength1_2.Text = cfg.Device2.DataLength;
            this.txtPoint1_2.Text = cfg.Device2.Point;
            this.chkStartDevice1_2.Checked = cfg.Device2.StartDevice;
            this.chkReturnZero1_2.Checked = cfg.Device2.StartReturnZero;
            this.rgSendReturnZeroProcess1_2.EditValue = cfg.Device2.SendReturnZeroProcess.ToString();
            this.teReturnZeroCommand1_2.Text = cfg.Device2.ReturnZeroCommand;
            DxHelper.BindComboBoxEdit(cmbSequence1_2, SysCode.Sequence, cfg.Device2.Sequence);
        }

        #endregion

        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="deviceNo">串口编号</param>
        private void InitSerialPort() {
            this.serialPort1 = new SerialPortHelper(1,cfg.Device1);
            this.serialPort2 = new SerialPortHelper(2,cfg.Device2);

            if (this.serialPort1 != null) {
                this.serialPort1.OnDataReceived = new SerialPortHelper.DataReceived(this.ShowReceivedData1);
            }
            if (this.serialPort2 != null) {
                this.serialPort2.OnDataReceived = new SerialPortHelper.DataReceived(this.ShowReceivedData2);
            }
        }

        /// <summary>
        /// 修改仪器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e) {
            this.groupCustom.Enabled = false;
            string deviceCode = DxHelper.GetCode(cmbDevice1);
            if (!string.IsNullOrEmpty(deviceCode) && deviceCode == "Custom") {
                this.groupCustom.Enabled = true;
            }
        }

        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        /// <param name="byteData">接收到的数据</param>
        private void ShowReceivedData1(byte[] byteData) {
            if (byteData != null && byteData.Length > 0) {
                string dataStr;

                if (this.radioDigit1.SelectedIndex == 0) {
                    dataStr = Encoding.ASCII.GetString(byteData);
                    Logger.Info("ShowReceivedData:" + dataStr);
                } else {
                    StringBuilder sbData = new StringBuilder();
                    foreach (byte item in byteData) {
                        sbData.Append(string.Format("0x{0} ", item.ToString("X2")));
                    }
                    dataStr = sbData.ToString();

                }
                this.Invoke(new Action<string>((str) => {
                    this.ShowDataInfo1(str);
                }), dataStr);
            }
        }
        private void ShowReceivedData2(byte[] byteData) {
            if (byteData != null && byteData.Length > 0) {
                string dataStr;

                if (this.radioDigit1_2.SelectedIndex == 0) {
                    dataStr = Encoding.ASCII.GetString(byteData);
                    Logger.Info("ShowReceivedData:" + dataStr);
                } else {
                    StringBuilder sbData = new StringBuilder();
                    foreach (byte item in byteData) {
                        sbData.Append(string.Format("0x{0} ", item.ToString("X2")));
                    }
                    dataStr = sbData.ToString();

                }
                this.Invoke(new Action<string>((str) => {
                    this.ShowDataInfo2(str);
                }), dataStr);
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="value">接收到的数据</param>
        private void ShowDataInfo1(string value) {
            this.memoReceive1.Text += value;
            this.memoReceive1.SelectionStart = this.memoReceive1.Text.Length;
            this.memoReceive1.ScrollToCaret();
        }
        private void ShowDataInfo2(string value) {
            this.memoReceive1_2.Text += value;
            this.memoReceive1_2.SelectionStart = this.memoReceive1_2.Text.Length;
            this.memoReceive1_2.ScrollToCaret();
        }

        private void Save1() {
            cfg = CfgUtil.GetCfg();
            cfg.Device1.Port = this.cmbCom1.EditValue.ToObjectString();
            cfg.Device1.BaundRate =cmbBaudRate1.Text;
            cfg.Device1.DataBit =cmbDataBits1.Text;
            cfg.Device1.StopBit = cmbStopBits1.GetStrValue().ToString();
            cfg.Device1.Parity = cmbParity1.GetStrValue().ToString();
            cfg.Device1.DataFormat = this.radioDigit1.SelectedIndex == 0 ? "DEC" : "HEX";
            cfg.Device1.Version = DxHelper.GetCode(cmbDevice1);
            cfg.Device1.DUnit = DxHelper.GetCode(cmbDUnit1);
            cfg.Device1.SUnit = DxHelper.GetCode(cmbSUnit1);
            cfg.Device1.ShowFormat = DxHelper.GetCode(cmbFormat1);
            cfg.Device1.Division = DxHelper.GetCode(cmbDivision1);
            cfg.Device1.ComFun = this.rgComFun1.Properties.Items[this.rgComFun1.SelectedIndex].Value.ToString();
            cfg.Device1.CustomCode = DxHelper.GetCode(cmbCode1);
            cfg.Device1.DataStart = this.txtDataStart1.Text;
            cfg.Device1.Intercept = string.IsNullOrEmpty(this.txtIntercept1.Text) ? "1" : this.txtIntercept1.Text.Trim();
            cfg.Device1.DataLength = string.IsNullOrEmpty(this.txtDataLength1.Text) ? "7" : this.txtDataLength1.Text.Trim();
            cfg.Device1.Point = string.IsNullOrEmpty(this.txtPoint1.Text) ? "0" : this.txtPoint1.Text.Trim();
            cfg.Device1.Sequence = DxHelper.GetCode(cmbSequence1);

            cfg.Device1.StartDevice = chkStartDevice1.Checked;
            cfg.Device1.StartReturnZero = chkReturnZero1.Checked;
            cfg.Device1.SendReturnZeroProcess = rgSendReturnZeroProcess1.EditValue.ToEnum<SendReturnZeroProcessType>();
            cfg.Device1.ReturnZeroCommand = teReturnZeroCommand1.Text;

            string fomart = cmbFormat1.Text;
            int decimalDigits = 0;
            DisplayFormatStringType displayType = DisplayFormatStringType.Int;
            if (!string.IsNullOrEmpty(fomart)) {
                if (fomart == "0.0") {
                    decimalDigits = 1;
                    displayType = DisplayFormatStringType.OneDecimal;
                }
                if (fomart == "0.00") {
                    decimalDigits = 2;
                    displayType = DisplayFormatStringType.TwoDecimal;
                }
                if (fomart == "0.000") {
                    decimalDigits = 3;
                    displayType = DisplayFormatStringType.ThreeDecimal;
                }
            }
            if (cfg.WeightSearch != null && cfg.WeightSearch.SummaryItems != null) {
                foreach (var item in cfg.WeightSearch.SummaryItems) {
                    if (item.FieldName == "GrossWeight" || item.FieldName == "TareWeight"
                        || item.FieldName == "SuttleWeight" || item.FieldName == "NetWeight") {
                        item.DisplayType = displayType;
                    }
                }
            }
            weightViewService.UpdateWeightColumnDecimalDigits(decimalDigits);
            CfgUtil.SaveCfg(cfg);
        }
        private void Save1_2() {
            cfg = CfgUtil.GetCfg();
            cfg.Device2.Port = this.cmbCom1_2.EditValue.ToObjectString();
            cfg.Device2.BaundRate =cmbBaudRate1_2.Text;
            cfg.Device2.DataBit =cmbDataBits1_2.Text;
            cfg.Device2.StopBit =cmbStopBits1_2.GetStrValue().ToString();
            cfg.Device2.Parity = cmbParity1_2.GetStrValue().ToString();
            cfg.Device2.DataFormat = this.radioDigit1_2.SelectedIndex == 0 ? "DEC" : "HEX";
            cfg.Device2.Version = DxHelper.GetCode(cmbDevice1_2);
            cfg.Device2.DUnit = DxHelper.GetCode(cmbDUnit1_2);
            cfg.Device2.SUnit = DxHelper.GetCode(cmbSUnit1_2);
            cfg.Device2.ShowFormat = DxHelper.GetCode(cmbFormat1_2);
            cfg.Device2.Division = DxHelper.GetCode(cmbDivision1_2);
            cfg.Device2.ComFun = this.rgComFun1_2.Properties.Items[this.rgComFun1_2.SelectedIndex].Value.ToString();
            cfg.Device2.CustomCode = DxHelper.GetCode(cmbCode1_2);
            cfg.Device2.DataStart = this.txtDataStart1_2.Text;
            cfg.Device2.Intercept = string.IsNullOrEmpty(this.txtIntercept1_2.Text) ? "1" : this.txtIntercept1.Text.Trim();
            cfg.Device2.DataLength = string.IsNullOrEmpty(this.txtDataLength1_2.Text) ? "7" : this.txtDataLength1.Text.Trim();
            cfg.Device2.Point = string.IsNullOrEmpty(this.txtPoint1_2.Text) ? "0" : this.txtPoint1.Text.Trim();
            cfg.Device2.Sequence = DxHelper.GetCode(cmbSequence1_2);

            cfg.Device2.StartDevice = chkStartDevice1_2.Checked;
            cfg.Device2.StartReturnZero = chkReturnZero1_2.Checked;
            cfg.Device2.SendReturnZeroProcess = rgSendReturnZeroProcess1_2.EditValue.ToEnum<SendReturnZeroProcessType>();
            cfg.Device2.ReturnZeroCommand = teReturnZeroCommand1_2.Text;

            string fomart = cmbFormat1_2.Text;
            int decimalDigits = 0;
            DisplayFormatStringType displayType = DisplayFormatStringType.Int;
            if (!string.IsNullOrEmpty(fomart)) {
                if (fomart == "0.0") {
                    decimalDigits = 1;
                    displayType = DisplayFormatStringType.OneDecimal;
                }
                if (fomart == "0.00") {
                    decimalDigits = 2;
                    displayType = DisplayFormatStringType.TwoDecimal;
                }
                if (fomart == "0.000") {
                    decimalDigits = 3;
                    displayType = DisplayFormatStringType.ThreeDecimal;
                }
            }
            if (cfg.WeightSearch != null && cfg.WeightSearch.SummaryItems != null) {
                foreach (var item in cfg.WeightSearch.SummaryItems) {
                    if (item.FieldName == "GrossWeight" || item.FieldName == "TareWeight"
                        || item.FieldName == "SuttleWeight" || item.FieldName == "NetWeight") {
                        item.DisplayType = displayType;
                    }
                }
            }
            //weightViewService.UpdateWeightColumnDecimalDigits(decimalDigits);
            CfgUtil.SaveCfg(cfg);
        }


        private void btnSend_Click(object sender, EventArgs e) {
            if (this.serialPort1 == null) return;
            if (simpleButton2.Text == "连接") {
                this.serialPort1.ClosePort();
                this.serialPort1.SerlPort.PortName = cmbCom1.EditValue.ToString();
                this.serialPort1.SerlPort.BaudRate = cmbBaudRate1.Text.ToInt();
                this.serialPort1.SerlPort.DataBits = cmbDataBits1.Text.ToInt();
                this.serialPort1.SerlPort.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits),cmbStopBits1.GetStrValue());
                this.serialPort1.SetParity((System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity),cmbParity1.GetStrValue()));
                this.serialPort1.OpenPort();
                simpleButton2.Text = "断开";
            } else {
                this.serialPort1.ClosePort();
                simpleButton2.Text = "连接";
            }
        }

        private void FrmDeviceSetting_FormClosed(object sender, FormClosedEventArgs e) {
            Release();
        }

        private void Release() {
            if (this.serialPort1 != null) {
                this.serialPort1.ClosePort();
            }
            if (this.serialPort2 != null) {
                this.serialPort2.ClosePort();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            Save1();
            MessageDxUtil.ShowTips("成功保存1号仪表设置信息");
        }

        /// <summary>
        /// 修改波特率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort1 != null) {
                this.serialPort1.SetBaudRate(DxHelper.GetCode(cmbBaudRate1));
            }
        }

        /// <summary>
        /// 修改数据位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort1 != null) {
                this.serialPort1.SetDataBits(DxHelper.GetCode(cmbDataBits1));
            }
        }

        /// <summary>
        /// 修改停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort1 != null) {
                this.serialPort1.SetStopBits(DxHelper.GetCode(cmbStopBits1));
            }
        }
        /// <summary>
        /// 修改波特率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate_SelectedIndexChanged2(object sender, EventArgs e) {
            if (this.serialPort2 != null) {
                this.serialPort2.SetBaudRate(DxHelper.GetCode(cmbBaudRate1_2));
            }
        }

        /// <summary>
        /// 修改数据位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits_SelectedIndexChanged2(object sender, EventArgs e) {
            if (this.serialPort2 != null) {
                this.serialPort2.SetDataBits(DxHelper.GetCode(cmbDataBits1_2));
            }
        }

        /// <summary>
        /// 修改停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits_SelectedIndexChanged2(object sender, EventArgs e) {
            if (this.serialPort2 != null) {
                this.serialPort2.SetStopBits(DxHelper.GetCode(cmbStopBits1_2));
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e) {
            if (this.serialPort2 == null) return;
            if (simpleButton8.Text == "连接") {
                this.serialPort2.ClosePort();
                this.serialPort2.SerlPort.PortName = cmbCom1_2.EditValue.ToString();
                this.serialPort2.SerlPort.BaudRate = cmbBaudRate1_2.Text.ToInt();
                this.serialPort2.SerlPort.DataBits = cmbDataBits1_2.Text.ToInt();
                this.serialPort2.SerlPort.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), cmbStopBits1_2.GetStrValue());
                this.serialPort2.SetParity((System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity),cmbParity1_2.GetStrValue()));
                this.serialPort2.OpenPort();
                simpleButton8.Text = "断开";
            } else {
                this.serialPort2.ClosePort();
                simpleButton8.Text = "连接";
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e) {
            Save1_2();
            MessageDxUtil.ShowTips("成功保存2号仪表设置信息");
        }
    }
}