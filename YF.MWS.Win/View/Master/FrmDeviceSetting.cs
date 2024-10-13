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
        /// 控制器编号
        /// </summary>
        public int ModbusNo {
            get { return modbusNo; }
            set { modbusNo = value; }
        }

        /// <summary>
        /// Ini文件控制器小节名称
        /// </summary>
        private string section;

        /// <summary>
        /// 控制器
        /// </summary>
        private ModbusUtil modbus;

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
        /// <summary>
        /// Ini文件仪表小节名称
        /// </summary>
        string deviceSection3;

        public FrmDeviceSetting() {
            InitializeComponent();
        }

        private void FrmDeviceSetting_Load(object sender, EventArgs e) {
            cfg = CfgUtil.GetCfg();
            //测速仪表小节名称
            deviceSection3 = "Velocimeter";
            if (!File.Exists(IniUtility.FilePath)) {
                File.Create(IniUtility.FilePath);
            }
            weDeviceCommMode.InitDataNew();
            //控制器小节名称
            section = string.Format("Modbus{0}", this.modbusNo);
            InitSerialPort();
            SetDeviceInfo1();
            SetDeviceInfo2();
            this.SetComInfo1();
            this.SetComInfo1_2();
            this.SetComInfo2();
            if (cfg != null) {
                #region 控制箱设置
                chkStartModBus.Checked = cfg.Weight.StartModBus;
                weDeviceCommMode.CurrentValue = (int)cfg.Weight.ModBusCommMode;
                txtModbusIP.Text = cfg.NobodyWeight.ModbusIP;
                txtModbusPort.Text = cfg.NobodyWeight.ModbusPort.ToString();
                rgCloseGateMode.EditValue = cfg.NobodyWeight.CloseGate.ToString();
                teFunSixCloseTime.Text = cfg.NobodyWeight.FunSixCloseTime.ToString();
                rgOpenSingleGateMode.EditValue = cfg.NobodyWeight.OpenSingleGate.ToString();
                rgBoundGate.EditValue = cfg.NobodyWeight.BoundGate.ToString();
                chkStartTrafficLight.Checked = cfg.NobodyWeight.StartTrafficLight;
                chkBoundGate.Checked = cfg.NobodyWeight.StartBoundGate;
                chkInfrared.Checked = cfg.NobodyWeight.StartInfrared;
                chkStartFunSix.Checked = cfg.NobodyWeight.StartFunSix;
                rgInfraredBlockCondition.EditValue = (int)cfg.NobodyWeight.InfraredBlockCondition;
                #endregion
            }
            AddEvent();
        }

        /// <summary>
        /// 初始化Modbus
        /// </summary>
        private void InitModbus() {
            this.modbus = new ModbusUtil(this.modbusNo);
            string portName = cmbCom2.Text;
            if(portName == "") {
                MessageDxUtil.ShowTips("端口不能为空！");
                return;
            }
            if (this.modbus != null) {
                bool isOpen = this.modbus.OpenPort();
                if (!isOpen) {
                    MessageDxUtil.ShowTips(string.Format("初始化串口{0}失败，或被占用！", portName));
                }
            } else {
                MessageDxUtil.ShowTips(string.Format("初始化串口{0}失败，或被占用！", portName));
            }
        }

        private void AddEvent() {
            //this.cmbCom1.SelectedIndexChanged += new System.EventHandler(this.cmbCom_SelectedIndexChanged);
            this.cmbBaudRate2.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate2_SelectedIndexChanged);
            this.cmbStopBits2.SelectedIndexChanged += new System.EventHandler(this.cmbStopBits2_SelectedIndexChanged);
            this.cmbDataBits2.SelectedIndexChanged += new System.EventHandler(this.cmbDataBits2_SelectedIndexChanged);
            this.cmbDevice1.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            this.cmbParity2.SelectedIndexChanged += new System.EventHandler(this.cmbParity2_SelectedIndexChanged);
            this.cmbCom2.SelectedIndexChanged += new System.EventHandler(this.cmbCom2_SelectedIndexChanged);
            this.cmbBaudRate1.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged1);
            this.cmbStopBits1.SelectedIndexChanged += new System.EventHandler(this.cmbStopBits_SelectedIndexChanged1);
            this.cmbDataBits1.SelectedIndexChanged += new System.EventHandler(this.cmbDataBits_SelectedIndexChanged1);
            this.cmbParity1.SelectedIndexChanged += new System.EventHandler(this.cmbParity_SelectedIndexChanged1);
            this.cmbBaudRate1_2.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged2);
            this.cmbStopBits1_2.SelectedIndexChanged += new System.EventHandler(this.cmbStopBits_SelectedIndexChanged2);
            this.cmbDataBits1_2.SelectedIndexChanged += new System.EventHandler(this.cmbDataBits_SelectedIndexChanged2);
            this.cmbParity1_2.SelectedIndexChanged += new System.EventHandler(this.cmbParity_SelectedIndexChanged2);
        }

        private void ChangeDevice1() {
            if (this.serialPort1 == null) return;
            this.serialPort1.ClosePort();
            this.serialPort1.SerlPort.PortName = cmbCom1.EditValue.ToString();
            this.serialPort1.OpenPort();
        }
        private void ChangeDevice2() {
            if (this.serialPort2 == null) return;
            this.serialPort1.ClosePort();
            this.serialPort2.SerlPort.PortName = cmbCom1_2.EditValue.ToString();
            this.serialPort2.OpenPort();
        }

        /// <summary>
        /// 设置串口信息
        /// </summary>
        private void SetComInfo2() {
            string settingValue;

            //COM端口
            foreach (string item in SerialPort.GetPortNames()) {
                this.cmbCom2.Properties.Items.Add(item);
            }
            settingValue = IniUtility.GetIniKeyValue(section, "Port", "COM1");
            this.cmbCom2.EditValue = settingValue;
            //波特率
            settingValue = IniUtility.GetIniKeyValue(section, "BaundRate", "9600");
            DxHelper.BindComboBoxEdit(cmbBaudRate2, SysCode.BaundRate, settingValue);
            //数据位
            settingValue = IniUtility.GetIniKeyValue(section, "DataBit", "8");
            DxHelper.BindComboBoxEdit(cmbDataBits2, SysCode.DataBit, settingValue);
            //停止位
            settingValue = IniUtility.GetIniKeyValue(section, "StopBit", "One");
            DxHelper.BindComboBoxEdit(cmbStopBits2, SysCode.StopBit, settingValue);
            //奇偶校验位
            settingValue = IniUtility.GetIniKeyValue(section, "Parity", "None");
            DxHelper.BindComboBoxEdit(cmbParity2, SysCode.ParityVerifyBit, settingValue);
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
            DxHelper.BindComboBoxEdit(cmbBaudRate1, SysCode.BaundRate, cfg.Device1.BaundRate);
            DxHelper.BindComboBoxEdit(cmbDataBits1, SysCode.DataBit, cfg.Device1.DataBit);
            DxHelper.BindComboBoxEdit(cmbStopBits1, SysCode.StopBit, cfg.Device1.StopBit);
            DxHelper.BindComboBoxEdit(cmbParity1, SysCode.ParityVerifyBit, cfg.Device1.Parity);
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
            DxHelper.BindComboBoxEdit(cmbBaudRate1_2, SysCode.BaundRate, cfg.Device2.BaundRate);
            DxHelper.BindComboBoxEdit(cmbDataBits1_2, SysCode.DataBit, cfg.Device2.DataBit);
            DxHelper.BindComboBoxEdit(cmbStopBits1_2, SysCode.StopBit, cfg.Device2.StopBit);
            DxHelper.BindComboBoxEdit(cmbParity1_2, SysCode.ParityVerifyBit, cfg.Device2.Parity);
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
            this.modbus = new ModbusUtil(this.modbusNo);

            if (this.serialPort1 != null) {
                this.OnShowData = new ShowData(this.ShowDataInfo1);
                this.serialPort1.OnDataReceived = new SerialPortHelper.DataReceived(this.ShowReceivedData1);
            }
            if (this.serialPort2 != null) {
                this.OnShowData = new ShowData(this.ShowDataInfo2);
                this.serialPort2.OnDataReceived = new SerialPortHelper.DataReceived(this.ShowReceivedData2);
            }
        }

        /// <summary>
        /// 修改串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCom_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeDevice1();
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
                this.Invoke(this.OnShowData, dataStr);
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
                this.Invoke(this.OnShowData, dataStr);
            }
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="value">接收到的数据</param>
        private void ShowDataInfo3(string value) {
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
            cfg.Device1.BaundRate = DxHelper.GetCode(cmbBaudRate1);
            cfg.Device1.DataBit = DxHelper.GetCode(cmbDataBits1);
            cfg.Device1.StopBit = DxHelper.GetCode(cmbStopBits1);
            cfg.Device1.Parity = DxHelper.GetCode(cmbParity1);
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
            cfg.Device2.BaundRate = DxHelper.GetCode(cmbBaudRate1_2);
            cfg.Device2.DataBit = DxHelper.GetCode(cmbDataBits1_2);
            cfg.Device2.StopBit = DxHelper.GetCode(cmbStopBits1_2);
            cfg.Device2.Parity = DxHelper.GetCode(cmbParity1_2);
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
            this.serialPort1.ClosePort();
            this.serialPort1.SerlPort.PortName = cmbCom1.EditValue.ToString();
            this.serialPort1.OpenPort();
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
            if (modbus != null) {
                modbus.ClosePort();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            Save1();
            MessageDxUtil.ShowTips("成功保存1号仪表设置信息");
        }
        /// <summary>
        /// 修改串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCom2_SelectedIndexChanged(object sender, EventArgs e) {
            if (modbus != null) {
                modbus.ClosePort();
                modbus.SetPortName(cmbCom2.EditValue.ToString());
                modbus.OpenPort();
            }
            // Save();
            // InitModbus();
        }

        /// <summary>
        /// 修改波特率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate2_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.modbus != null) {
                this.modbus.SetBaudRate(DxHelper.GetCode(cmbBaudRate2));
            }
        }

        /// <summary>
        /// 修改数据位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits2_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.modbus != null) {
                this.modbus.SetDataBits(DxHelper.GetCode(cmbDataBits2));
            }
        }

        /// <summary>
        /// 修改停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits2_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.modbus != null) {
                this.modbus.SetStopBits(DxHelper.GetCode(cmbStopBits2));
            }
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

        private void simpleButton4_Click(object sender, EventArgs e) {
            Save2();
            MessageDxUtil.ShowTips("成功保存控制器设置信息！");
        }
        private void Save2() {
            //设置串口信息
            IniUtility.WriteIniKey(section, "Port", this.cmbCom2.EditValue.ToString());
            IniUtility.WriteIniKey(section, "BaundRate", DxHelper.GetCode(cmbBaudRate2));
            IniUtility.WriteIniKey(section, "DataBit", DxHelper.GetCode(cmbDataBits2));
            IniUtility.WriteIniKey(section, "StopBit", DxHelper.GetCode(cmbStopBits2));
            IniUtility.WriteIniKey(section, "Parity", DxHelper.GetCode(cmbParity2));
            if (cfg == null) cfg = CfgUtil.GetCfg();
            cfg.Weight.StartModBus = chkStartModBus.Checked;
            cfg.Weight.ModBusCommMode = weDeviceCommMode.CurrentValue.ToEnum<DeviceCommMode>();
            cfg.NobodyWeight.ModbusIP = txtModbusIP.Text;
            cfg.NobodyWeight.ModbusPort = txtModbusPort.Text.ToInt();
            cfg.NobodyWeight.BoundGate = rgBoundGate.EditValue.ToEnum<BoundGateType>();
            cfg.NobodyWeight.StartTrafficLight = chkStartTrafficLight.Checked;
            cfg.NobodyWeight.StartBoundGate = chkBoundGate.Checked;
            cfg.NobodyWeight.StartInfrared = chkInfrared.Checked;
            cfg.NobodyWeight.StartFunSix = chkStartFunSix.Checked;
            cfg.NobodyWeight.CloseGate = rgCloseGateMode.EditValue.ToEnum<CloseGateMode>();
            cfg.NobodyWeight.OpenSingleGate = rgOpenSingleGateMode.EditValue.ToEnum<OpenSingleGateMode>();
            cfg.NobodyWeight.FunSixCloseTime = teFunSixCloseTime.Text.ToInt();
            cfg.NobodyWeight.InfraredBlockCondition = rgInfraredBlockCondition.EditValue.ToEnum<InfraredBlockCondition>();
            CfgUtil.SaveCfg(cfg);
        }
        private void btnClean2_Click(object sender, EventArgs e) {
            this.memoReceive1.Text = string.Empty;
        }

        private void btnSend2_Click(object sender, EventArgs e) {
            byte[] byteFun, byteRet;
            short funCode = Convert.ToInt16(this.cmbFunCode.Text);
            short address = Convert.ToInt16(this.txtRegister.Text);
            short value = Convert.ToInt16(this.txtNumValue.Text);
            if (this.modbus != null) {
                this.modbus.ServerIP = txtModbusIP.Text;
                this.modbus.ServerPort = txtModbusPort.Text.ToInt();
                if (tabModbus.SelectedTabPageIndex == 0) {
                    if (!modbus.OpenPort()) {
                        MessageBox.Show("打开串口失败！");
                        return;
                    }
                }
                //发送测试命令
                bool isSuccess = this.modbus.SendControl(funCode, address, value, out byteFun, out byteRet, tabModbus.SelectedTabPageIndex);

                StringBuilder sbData = new StringBuilder();
                if (byteFun != null) {
                    foreach (byte item in byteFun) {
                        sbData.Append(string.Format("0x{0} ", item.ToString("X2")));
                    }
                    this.txtSend2.Text = sbData.ToString().TrimEnd(' ');
                    sbData.Clear();
                }

                if (isSuccess) {
                    sbData.Append("通讯成功！\r\n");
                } else {
                    sbData.Append("通讯失败！\r\n");
                }
                if (byteRet != null) {
                    foreach (byte item in byteRet) {
                        sbData.Append(string.Format("0x{0} ", item.ToString("X2")));
                    }
                    sbData.Append("\r\n");
                }
                this.memoReceive2.Text += sbData.ToString();
                this.memoReceive2.SelectionStart = this.memoReceive2.Text.Length;
                this.memoReceive2.ScrollToCaret();
            } else {
                this.memoReceive2.Text += "通讯错误，连接控制器失败！\r\n";
                this.memoReceive2.SelectionStart = this.memoReceive2.Text.Length;
                this.memoReceive2.ScrollToCaret();
            }

        }
        private void btnInvalid_Click(object sender, EventArgs e) {
            modbus.ChangeDevice(false);
        }

        private void btnRecover_Click(object sender, EventArgs e) {
            modbus.ChangeDevice(true);
        }

        private void chkStartModBus_CheckedChanged(object sender, EventArgs e) {
            chkStartFunSix.Checked = chkStartModBus.Checked;
        }

        /// <summary>
        /// 修改奇偶校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbParity2_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.modbus != null) {
                this.modbus.SetParity(DxHelper.GetCode(cmbParity2));
            }
        }

        private void cmbCom1_2_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeDevice2();
        }

        private void btnSend3_Click(object sender, EventArgs e) {

        }

        private void simpleButton8_Click(object sender, EventArgs e) {
            if (this.serialPort2 == null) return;
            this.serialPort2.ClosePort();
            this.serialPort2.SerlPort.PortName = cmbCom1.EditValue.ToString();
            this.serialPort2.OpenPort();
        }

        private void simpleButton6_Click(object sender, EventArgs e) {
            Save1_2();
            MessageDxUtil.ShowTips("成功保存2号仪表设置信息");
        }

        /// <summary>
        /// 修改奇偶校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbParity_SelectedIndexChanged1(object sender, EventArgs e) {
            if (this.serialPort1 != null) {
                this.serialPort1.SetParity(DxHelper.GetCode(cmbParity1));
            }
        }
        private void cmbParity_SelectedIndexChanged2(object sender, EventArgs e) {
            if (this.serialPort2 != null) {
                this.serialPort2.SetParity(DxHelper.GetCode(cmbParity1_2));
            }
        }
    }
}