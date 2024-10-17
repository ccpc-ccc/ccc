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
using YF.MWS.Db;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace YF.MWS.Win.View.Master {
    public partial class FrmDeviceSetting : DevExpress.XtraEditors.XtraForm {
        private IWeightViewService weightViewService = new WeightViewService();
        private IMaterialService materialService=new MaterialService();
        private int Index { get; set; }
        private SysCfg cfg;
        /// <summary>
        /// 串口
        /// </summary>
        private SerialPortHelper serialPort;//1号仪表
        private Socket _socket;
        private List<SMaterial> materials = new List<SMaterial>();
        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        private delegate void ShowData(string value);

        private ShowData OnShowData;

        public FrmDeviceSetting(int index) {
            InitializeComponent();
            this.Index = index;
        }

        private void FrmDeviceSetting_Load(object sender, EventArgs e) {
            cfg = Program._cfg;
            SetDeviceInfo1();
            this.SetComInfo1();
            materials = materialService.GetMaterialByCompanyId(Index.ToString());
            gcWeight.DataSource = materials;
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
            this.cmbCom1.EditValue = Program._cfg.Device[Index].Port;
            DxHelper.BindComboBoxEdit(cmbBaudRate1, SysCode.BaundRate, cfg.Device[Index].BaundRate);
            DxHelper.BindComboBoxEdit(cmbDataBits1, SysCode.DataBit, cfg.Device[Index].DataBit);
            DxHelper.BindComboBoxEdit<StopBits>(cmbStopBits1, cfg.Device[Index].StopBit);
            DxHelper.BindComboBoxEdit(cmbParity1, SysCode.ParityVerifyBit, cfg.Device[Index].Parity);
            if (cfg.Device[Index].DataFormat == "DEC") {
                this.radioDigit1.SelectedIndex = 0;
            } else {
                this.radioDigit1.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 设置称重设备信息
        /// </summary>
        private void SetDeviceInfo1() {
            DxHelper.BindComboBoxEdit(cmbDevice1, SysCode.Device, cfg.Device[Index].Version);
            DxHelper.BindComboBoxEdit(cmbDUnit1, SysCode.MeasureUnit, cfg.Device[Index].DUnit);
            DxHelper.BindComboBoxEdit(cmbSUnit1, SysCode.MeasureUnit, cfg.Device[Index].SUnit);
            DxHelper.BindComboBoxEdit(cmbFormat1, SysCode.ShowFormat, cfg.Device[Index].ShowFormat);
            DxHelper.BindComboBoxEdit(cmbDivision1, SysCode.DivisionValue, cfg.Device[Index].Division);
            switch (cfg.Device[Index].ComFun) {
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
            DxHelper.BindComboBoxEdit(cmbCode1, SysCode.CustomCode, cfg.Device[Index].CustomCode);
            this.txtDataStart1.Text = cfg.Device[Index].DataStart;
            this.txtIntercept1.Text = cfg.Device[Index].Intercept;
            this.txtDataLength1.Text = cfg.Device[Index].DataLength;
            this.chkStartDevice1.Checked = cfg.Device[Index].StartDevice;
            this.txtPoint1.Text = cfg.Device[Index].Point;
            this.chkReturnZero1.Checked = cfg.Device[Index].StartReturnZero;
            this.rgSendReturnZeroProcess1.EditValue = cfg.Device[Index].SendReturnZeroProcess.ToString();
            this.teReturnZeroCommand1.Text = cfg.Device[Index].ReturnZeroCommand;
            txtName.Text = cfg.Device[Index].Name;
           teSettlementTime.EditValue = cfg.Device[Index].SettlementTime;
            txtServerIP.Text = cfg.Device[Index].ServerIP;
            txtServerProt.Text = cfg.Device[Index].ServerPort.ToString();
            tabConnectType.SelectedTabPageIndex = cfg.Device[Index].ConnectType;
            DxHelper.BindComboBoxEdit(cmbSequence1, SysCode.Sequence, cfg.Device[Index].Sequence);
        }

        #endregion


        private void Save1() {
            cfg = CfgUtil.GetCfg();
            cfg.Device[Index].Port = this.cmbCom1.EditValue.ToObjectString();
            cfg.Device[Index].BaundRate = DxHelper.GetCode(cmbBaudRate1);
            cfg.Device[Index].DataBit = DxHelper.GetCode(cmbDataBits1);
            cfg.Device[Index].StopBit = DxHelper.GetCode(cmbStopBits1);
            cfg.Device[Index].Parity = DxHelper.GetCode(cmbParity1);
            cfg.Device[Index].DataFormat = this.radioDigit1.SelectedIndex == 0 ? "DEC" : "HEX";
            cfg.Device[Index].Version = DxHelper.GetCode(cmbDevice1);
            cfg.Device[Index].DUnit = DxHelper.GetCode(cmbDUnit1);
            cfg.Device[Index].SUnit = DxHelper.GetCode(cmbSUnit1);
            cfg.Device[Index].ShowFormat = DxHelper.GetCode(cmbFormat1);
            cfg.Device[Index].Division = DxHelper.GetCode(cmbDivision1);
            cfg.Device[Index].ComFun = this.rgComFun1.Properties.Items[this.rgComFun1.SelectedIndex].Value.ToString();
            cfg.Device[Index].CustomCode = DxHelper.GetCode(cmbCode1);
            cfg.Device[Index].DataStart = this.txtDataStart1.Text;
            cfg.Device[Index].Intercept = string.IsNullOrEmpty(this.txtIntercept1.Text) ? "1" : this.txtIntercept1.Text.Trim();
            cfg.Device[Index].DataLength = string.IsNullOrEmpty(this.txtDataLength1.Text) ? "7" : this.txtDataLength1.Text.Trim();
            cfg.Device[Index].Point = string.IsNullOrEmpty(this.txtPoint1.Text) ? "0" : this.txtPoint1.Text.Trim();
            cfg.Device[Index].Sequence = DxHelper.GetCode(cmbSequence1);
            cfg.Device[Index].StartDevice = chkStartDevice1.Checked;
            cfg.Device[Index].StartReturnZero = chkReturnZero1.Checked;
            cfg.Device[Index].SendReturnZeroProcess = rgSendReturnZeroProcess1.EditValue.ToEnum<SendReturnZeroProcessType>();
            cfg.Device[Index].ReturnZeroCommand = teReturnZeroCommand1.Text;
            cfg.Device[Index].Name=txtName.Text;
            cfg.Device[Index].SettlementTime = teSettlementTime.EditValue.ToDateTime();
            cfg.Device[Index].Code = Index.ToString();
            cfg.Device[Index].ServerIP= txtServerIP.Text;
            cfg.Device[Index].ServerPort = txtServerProt.Text.ToInt();
            cfg.Device[Index].ConnectType = tabConnectType.SelectedTabPageIndex;
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
            Program._cfg = cfg;
        }


        private void btnSend_Click(object sender, EventArgs e) {
            if (this.serialPort == null) return;
            if (simpleButton2.Text == "连接") {
                this.serialPort.ClosePort();
                this.serialPort.SerlPort.PortName = cmbCom1.EditValue.ToString();
                this.serialPort.SerlPort.BaudRate = cmbBaudRate1.EditValue.ToInt();
                this.serialPort.SerlPort.DataBits = cmbDataBits1.EditValue.ToInt();
                this.serialPort.SerlPort.StopBits = (StopBits)cmbStopBits1.SelectedIndex.ToInt();
                this.serialPort.SetParity(cmbParity1.EditValue.ToString());
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
            if (this._socket != null && this._socket.Connected) {
                this._socket.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            Save1();
            MessageDxUtil.ShowTips($"成功保存{Index}#仪表设置信息");
        }
        private void bindData() {
           List<SMaterial> materials= materialService.GetMaterialByCompanyId(Index.ToString());
            gcWeight.DataSource = materials;
            gcWeight.RefreshDataSource();
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmMaterialDetail frm = new FrmMaterialDetail(this.Index);
            if (frm.ShowDialog() == DialogResult.OK) {
                bindData();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e) {
            SMaterial material = (SMaterial)gvWeight.GetFocusedRow();
            if (material == null) {
                MessageBox.Show("请选择需要修改的数据");
                return;
            }
            FrmMaterialDetail frm = new FrmMaterialDetail(this.Index);
            frm.MaterialId = material.Id;
            if (frm.ShowDialog() == DialogResult.OK) {
                bindData();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e) {
            SMaterial material = (SMaterial)gvWeight.GetFocusedRow();
            if (material == null) {
                MessageBox.Show("请选择需要修改的数据");
                return;
            }
            if (MessageBox.Show("确实需要删除此条数据吗，此操作不可恢复。", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                materialService.DeleteMaterial(material.Id);
                bindData();
            }
        }
        private void simpleButton6_Click(object sender, EventArgs e) {
            if (this.btnConnect.Text == "连接") {
            this._socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try {
                    new Thread(() => {
                        this.Invoke(new Action(() => {
                        this.btnConnect.Text = "连接中";
                        }));
                        try {
                this._socket.Connect(txtServerIP.Text, txtServerProt.Text.ToInt());
                        this.Invoke(new Action(() => {
                btnConnect.Text = "断开";
                        }));
                        byte[] bytes = new byte[48];
                        while (true) {
                                Thread.Sleep(100);
                        if (this._socket == null || !this._socket.Connected) return;
                        int received= this._socket.Receive(bytes);
                        string message = Encoding.ASCII.GetString(bytes, 0, received);
                                memoReceive1.Text += message;
                        }

                        }catch(Exception ex) {
                            Logger.WriteException(ex);
                            MessageBox.Show("连接失败");
                            this.Invoke(new Action(() => {
                                btnConnect.Text = "连接";
                            }));
                        }
                    }).Start();
            } catch (Exception ex) {
                Logger.Write("网络连接失败，" + ex.Message);
                MessageBox.Show("连接失败");
            }
            } else {
                if(this._socket!=null&&this._socket.Connected) this._socket.Close();
                btnConnect.Text = "连接";
            }
        }

        private void simpleButton6_Click_1(object sender, EventArgs e) {
            materials = materialService.GetMaterialByCompanyId(Index.ToString());
            gcWeight.DataSource = materials;
            gcWeight.RefreshDataSource();
        }
    }
}