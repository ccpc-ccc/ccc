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
        private SerialPortHelper serialPort;//1号仪表

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
            this.SetComInfo1();
        }

        private void ChangeDevice1() {
            if (this.serialPort == null) return;
            this.serialPort.ClosePort();
            this.serialPort.SerlPort.PortName = cmbCom1.EditValue.ToString();
            this.serialPort.OpenPort();
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
            this.cmbCom1.EditValue = cfg.Device.Port;
            DxHelper.BindComboBoxEdit(cmbBaudRate1, SysCode.BaundRate, cfg.Device.BaundRate);
            DxHelper.BindComboBoxEdit(cmbDataBits1, SysCode.DataBit, cfg.Device.DataBit);
            DxHelper.BindComboBoxEdit<StopBits>(cmbStopBits1, cfg.Device.StopBit);
            DxHelper.BindComboBoxEdit<Parity>(cmbParity1, cfg.Device.Parity);
            if (cfg.Device.DataFormat == "DEC") {
                this.radioDigit1.SelectedIndex = 0;
            } else {
                this.radioDigit1.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 设置称重设备信息
        /// </summary>
        private void SetDeviceInfo1() {
            DxHelper.BindComboBoxEdit(cmbDevice1, SysCode.Device, cfg.Device.Version);
            DxHelper.BindComboBoxEdit(cmbDUnit1, SysCode.MeasureUnit, cfg.Device.DUnit);
            DxHelper.BindComboBoxEdit(cmbSUnit1, SysCode.MeasureUnit, cfg.Device.SUnit);
            DxHelper.BindComboBoxEdit(cmbFormat1, SysCode.ShowFormat, cfg.Device.ShowFormat);
            DxHelper.BindComboBoxEdit(cmbDivision1, SysCode.DivisionValue, cfg.Device.Division);
            switch (cfg.Device.ComFun) {
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
            DxHelper.BindComboBoxEdit(cmbCode1, SysCode.CustomCode, cfg.Device.CustomCode);
            this.txtDataStart1.Text = cfg.Device.DataStart;
            this.txtIntercept1.Text = cfg.Device.Intercept;
            this.txtDataLength1.Text = cfg.Device.DataLength;
            this.chkStartDevice1.Checked = cfg.Device.StartDevice;
            this.txtPoint1.Text = cfg.Device.Point;
            this.chkReturnZero1.Checked = cfg.Device.StartReturnZero;
            this.rgSendReturnZeroProcess1.EditValue = cfg.Device.SendReturnZeroProcess.ToString();
            this.teReturnZeroCommand1.Text = cfg.Device.ReturnZeroCommand;
            DxHelper.BindComboBoxEdit(cmbSequence1, SysCode.Sequence, cfg.Device.Sequence);
        }

        #endregion

        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="deviceNo">串口编号</param>
        private void InitSerialPort() {
            this.serialPort = new SerialPortHelper(1,cfg.Device);

            if (this.serialPort != null) {
                this.serialPort.OnDataReceived = new SerialPortHelper.DataReceived(this.ShowReceivedData1);
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

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="value">接收到的数据</param>
        private void ShowDataInfo1(string value) {
            this.memoReceive1.Text += value;
            this.memoReceive1.SelectionStart = this.memoReceive1.Text.Length;
            this.memoReceive1.ScrollToCaret();
        }

        private void Save1() {
            cfg = CfgUtil.GetCfg();
            cfg.Device.Port = this.cmbCom1.EditValue.ToObjectString();
            cfg.Device.BaundRate = DxHelper.GetCode(cmbBaudRate1);
            cfg.Device.DataBit = DxHelper.GetCode(cmbDataBits1);
            cfg.Device.StopBit = DxHelper.GetCode(cmbStopBits1);
            cfg.Device.Parity = DxHelper.GetCode(cmbParity1);
            cfg.Device.DataFormat = this.radioDigit1.SelectedIndex == 0 ? "DEC" : "HEX";
            cfg.Device.Version = DxHelper.GetCode(cmbDevice1);
            cfg.Device.DUnit = DxHelper.GetCode(cmbDUnit1);
            cfg.Device.SUnit = DxHelper.GetCode(cmbSUnit1);
            cfg.Device.ShowFormat = DxHelper.GetCode(cmbFormat1);
            cfg.Device.Division = DxHelper.GetCode(cmbDivision1);
            cfg.Device.ComFun = this.rgComFun1.Properties.Items[this.rgComFun1.SelectedIndex].Value.ToString();
            cfg.Device.CustomCode = DxHelper.GetCode(cmbCode1);
            cfg.Device.DataStart = this.txtDataStart1.Text;
            cfg.Device.Intercept = string.IsNullOrEmpty(this.txtIntercept1.Text) ? "1" : this.txtIntercept1.Text.Trim();
            cfg.Device.DataLength = string.IsNullOrEmpty(this.txtDataLength1.Text) ? "7" : this.txtDataLength1.Text.Trim();
            cfg.Device.Point = string.IsNullOrEmpty(this.txtPoint1.Text) ? "0" : this.txtPoint1.Text.Trim();
            cfg.Device.Sequence = DxHelper.GetCode(cmbSequence1);
            cfg.Device.StartDevice = chkStartDevice1.Checked;
            cfg.Device.StartReturnZero = chkReturnZero1.Checked;
            cfg.Device.SendReturnZeroProcess = rgSendReturnZeroProcess1.EditValue.ToEnum<SendReturnZeroProcessType>();
            cfg.Device.ReturnZeroCommand = teReturnZeroCommand1.Text;

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
        private void btnSend_Click(object sender, EventArgs e) {
            if (this.serialPort == null) return;
            if (simpleButton2.Text == "连接") {
                this.serialPort.ClosePort();
                this.serialPort.SerlPort.PortName = cmbCom1.EditValue.ToString();
                this.serialPort.SerlPort.BaudRate = cmbBaudRate1.Text.ToInt();
                this.serialPort.SerlPort.DataBits = cmbDataBits1.Text.ToInt();
                this.serialPort.SerlPort.StopBits = (StopBits)cmbStopBits1.SelectedIndex.ToInt();
                this.serialPort.SetParity((Parity)cmbParity1.SelectedIndex.ToInt());
                this.serialPort.OpenPort();
                simpleButton2.Text = "断开";
            } else {
                this.serialPort.ClosePort();
                simpleButton2.Text = "连接";
            }
        }

        private void FrmDeviceSetting_FormClosed(object sender, FormClosedEventArgs e) {
            Release();
        }

        private void Release() {
            if (this.serialPort != null) {
                this.serialPort.ClosePort();
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
            if (this.serialPort != null) {
                this.serialPort.SetBaudRate(DxHelper.GetCode(cmbBaudRate1));
            }
        }

        /// <summary>
        /// 修改数据位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort != null) {
                this.serialPort.SetDataBits(DxHelper.GetCode(cmbDataBits1));
            }
        }

        /// <summary>
        /// 修改停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort != null) {
                this.serialPort.SetStopBits(DxHelper.GetCode(cmbStopBits1));
            }
        }
    }
}