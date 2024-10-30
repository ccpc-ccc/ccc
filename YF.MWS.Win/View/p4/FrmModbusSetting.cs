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
using YF.MWS.Metadata;
using YF.Utility.Log;
using YF.MWS.Metadata.Cfg;
using YF.Utility;
using YF.MWS.SQliteService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.BaseMetadata;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Sockets;
using System.Net;

namespace YF.MWS.Win.View.Master {
    public partial class FrmModbusSetting : DevExpress.XtraEditors.XtraForm {
        private SysCfg cfg;
        private int modbusNo = 1;
        Socket socket;
        /// <summary>
        /// 控制器编号
        /// </summary>
        public int ModbusNo {
            get { return modbusNo; }
            set { modbusNo = value; }
        }

        /// <summary>
        /// 控制器
        /// </summary>
        private ModbusUtil modbus;

        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        private delegate void ShowData(string value);

        private ShowData OnShowData;

        public FrmModbusSetting() {
            InitializeComponent();
        }

        private void FrmDeviceSetting_Load(object sender, EventArgs e) {
            cfg = CfgUtil.GetCfg();
            if (cfg != null) {
                #region 控制箱设置
                chkStartModBus.Checked = cfg.Weight.StartModBus;
                txtModbusIP.Text = cfg.ModbusIP;
                txtModbusPort.Text = cfg.ModbusPort.ToString();
                #endregion
            }
        }

        private void FrmDeviceSetting_FormClosed(object sender, FormClosedEventArgs e) {
            Release();
        }

        private void Release() {
            if (modbus != null) {
                modbus.ClosePort();
            }
            if (socket != null && socket.Connected) socket.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e) {
            Save2();
            MessageBox.Show("成功保存控制器设置信息！");
        }
        private void Save2() {
            if (cfg == null) cfg = CfgUtil.GetCfg();
            cfg.Weight.StartModBus = chkStartModBus.Checked;
            cfg.Weight.ModBusCommMode = DeviceCommMode.Network;
            cfg.ModbusIP = txtModbusIP.Text;
            cfg.ModbusPort = txtModbusPort.Text.ToInt();
            CfgUtil.SaveCfg(cfg);
        }

        private void btnSend2_Click(object sender, EventArgs e) {
            byte[] byteFun, byteRet=new byte[24];
                if (socket == null || !socket.Connected) {
                    MessageBox.Show("请先连接网络设备");
                    return;
                }
                try {
                    byteFun = txtSend2.Text.HexGetBytes();
                    socket.Send(byteFun);
                int r = socket.Receive(byteRet);
                byte[] bn = new byte[r];
                if (r > 0) {
                    Array.Copy(byteRet, bn, r);
                }
                textBox1.Text += bn.ToHexStr(false,true) + "\r\n";
                MessageBox.Show("发送成功！");
                } catch (Exception ex) {
                    Logger.Write("发送数据到网络设备失败 "+ex.Message);
                    MessageBox.Show("发送失败");
                }

        }

        private void chkStartModBus_CheckedChanged(object sender, EventArgs e) {
        }

        private void simpleButton7_Click(object sender, EventArgs e) {
            if (simpleButton7.Text=="连接"){
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.ReceiveTimeout = 3000;
                socket.SendTimeout = 3000;
                simpleButton7.Text = "断开";
            try {
                socket.Connect(txtModbusIP.Text, txtModbusPort.Text.ToInt());
            } catch (Exception ex) {
                Logger.Write("socket连接失败 " + ex.Message);
                MessageBox.Show("连接失败");
            }
            } else {
               if(socket!=null&&socket.Connected) socket.Close();
                simpleButton7.Text = "连接";
            }

        }
    }
}