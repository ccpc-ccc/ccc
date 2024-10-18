using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.CarPlate;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Event;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata;
using YF.MWS.SQliteService.Remote;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util.CarPlate;
using YF.MWS.Win.Util.Video;
using YF.MWS.Win.Util;
using YF.MWS.Win.View.Customer;
using YF.MWS.Win.View.Report;
using YF.MWS.Win.View.UI;
using YF.Utility.Language;
using YF.Utility.Log;
using YF.Utility;
using System.Collections;
using System.Diagnostics;
using YF.Utility.Data;
using YF.MWS.Win.View.Master;
using DevExpress.XtraSplashScreen;

namespace YF.MWS.Win.View.Weight {
    public partial class FrmWeight : BaseForm {
        private DateTime grossWeightTime = DateTime.Now;
        private DeviceCfg currentDeviceCfg;
        private SerialPortHelper serialPort;

        public FrmWeight() {
            //线程可以控制控件
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void FrmWeight_Load(object sender, EventArgs e) {
            try {
                this.FrmMain=GetMain();
                SplashScreenManager.CloseForm();
                if (FrmMain!=null)Program.frmViewVideoDevice = Program.frmViewVideoDevice;
                InitPort();
                currentDeviceCfg = this.Cfg.Device;
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }

        }
        /// <summary>
        /// 初始化称重仪器
        /// </summary>
        private void InitPort() {
            InitPort(1, Cfg.Device);
        }
        private void InitPort(int deviceNo, DeviceCfg deviceCfg) {
            try {
                if (deviceCfg.StartDevice) {
                    serialPort = new SerialPortHelper(deviceNo, deviceCfg);
                    serialPort.OnShowWeight = new SerialPortHelper.ShowWeight(this.ShowWeightInfo);
                    bool isOpen = false;
                    if (serialPort != null) {
                        isOpen = serialPort.OpenPort();
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }
        private Task ShowWeightInfo(int deviceNo, double value) {
                    this.BeginInvoke(new Action(() => {
                        txtWeight.Text = value.ToString();
                    }));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 关闭称重仪器串口连接
        /// </summary>
        public void ClosePort() {
            try {
                if (this.serialPort != null) {
                    this.serialPort.ClosePort();
                    this.serialPort = null;
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }


        private void FrmWeight_FormClosed(object sender, FormClosedEventArgs e) {
            ClosePort();
        }
        private void FrmWeight_KeyDown(object sender, KeyEventArgs e) {
        }

        private void FrmWeight_SizeChanged(object sender, EventArgs e) {
            //gpWeightDetail.Height = this.Height - gpWeightDetail.Location.Y;
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            if (this.serialPort != null && this.serialPort.SerlPort.IsOpen) this.serialPort.ClosePort();
            FrmDeviceSetting frmDeviceSetting = new FrmDeviceSetting();
            frmDeviceSetting.ShowDialog();
            Cfg = CfgUtil.GetCfg();
            InitPort();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e) {
            Calculate();
        }
        private void Calculate() {
            if (cmbSymbol.Text == "+") {
                txtResult.Text = Math.Round(txtWeight.Text.ToDecimal() + textEdit2.Text.ToDecimal(),2).ToString();
            } else if (cmbSymbol.Text == "-") {
                txtResult.Text = Math.Round(txtWeight.Text.ToDecimal() - textEdit2.Text.ToDecimal(), 2).ToString();
            }else if (cmbSymbol.Text == "*") {
                txtResult.Text = Math.Round(txtWeight.Text.ToDecimal() * textEdit2.Text.ToDecimal(), 2).ToString();
            } else if (cmbSymbol.Text == "/") {
                if (textEdit2.Text.ToDecimal() == 0) {
                    txtResult.Text = "0";
                    return;
                }
                txtResult.Text = Math.Round(txtWeight.Text.ToDecimal() / textEdit2.Text.ToDecimal(), 3).ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmRegister frm = new FrmRegister();
            frm.ShowDialog();
        }

        private void txtWeight_EditValueChanged(object sender, EventArgs e) {
            Calculate();
        }
    }
}
