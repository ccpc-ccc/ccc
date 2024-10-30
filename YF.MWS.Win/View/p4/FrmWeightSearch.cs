using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.Utility.Data;
using YF.Utility;
using YF.MWS.Db;
using DevExpress.XtraGrid.Views.Base;
using YF.MWS.BaseMetadata;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using YF.Utility.IO;
using YF.Utility.Log;
using DevExpress.XtraGrid.Views.Grid;
using YF.MWS.Win.View.Master;
using YF.MWS.Metadata.Cfg;
using System.Net.Sockets;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace YF.MWS.Win.View.Weight {
    public partial class FrmWeightSearch : Form {
        public DataTable Dt { get; set; }
        private IWarehService warehService = new WarehService();
        private WeightPrinter printer = new WeightPrinter();
        private List<Component> lstComponent = new List<Component>();
        private List<BarItem> lstItem = new List<BarItem>();
        private StringBuilder sbCondition = new StringBuilder();
        private SysCfg cfg;
        private string sql;
        private bool startReWeightPrint = false;
        private string weightPrinterName = string.Empty;
        private List<VWeight> list = new List<VWeight>();
        public FrmWeightSearch() {
            InitializeComponent();
            cfg = CfgUtil.GetCfg();
        }

        private void FrmWeightSearch_Load(object sender, EventArgs e) {
            using (Utility.GetWaitForm()) {
                LoadEmpty();
                if (cfg != null) {
                    this.checkEdit1.Checked = cfg.AutoOption;
                    this.textEdit1.Text = cfg.IntervalTime.ToString();
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void LoadEmpty() {
            List<VWareh> list= warehService.GetList();
            if (list != null) {
                gcWeight.DataSource = list;
                gcWeight.RefreshDataSource();
            }
        }

        private void barItemQuery_ItemClick(object sender, ItemClickEventArgs e) {
            FrmModbusSetting frm = new FrmModbusSetting();
            frm.ShowDialog();
        }
        private void gvWeight_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e) {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0) {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void FrmWeightYcSearch_FormClosing(object sender, FormClosingEventArgs e) {
            cfg.AutoOption = this.checkEdit1.Checked;
            cfg.IntervalTime = this.textEdit1.Text.ToInt();
            CfgUtil.SaveCfg(cfg);
        }

        private void barItemLog_ItemClick(object sender, ItemClickEventArgs e) {
            VWareh wareh = (VWareh)gvWeight.GetFocusedRow();
            if(wareh == null) {
                MessageBox.Show("请选择仓门");
                return;
            }
            FrmWarehEdit frm = new FrmWarehEdit();
            frm.RecId = wareh.WarehId;
           if(frm.ShowDialog() == DialogResult.OK) {
                LoadEmpty();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            list = warehService.GetBWeights();
            foreach(VWeight weight in list) {
                if (weight.FinishState == 1 && string.IsNullOrEmpty(weight.WeightId2)) continue;
                else if (weight.FinishState == 0 &&weight.IsOpen==0 &&!string.IsNullOrEmpty(weight.OpenAddress)) {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.ReceiveTimeout = 3000;
                    socket.SendTimeout = 3000;
                    new Thread(() => {
                        sendData(weight.OpenAddress, socket);
                    }).Start();
                    warehService.OptionWareh(weight.WeightId, "open");
                }
                else if (weight.FinishState == 1 &&weight.IsClose==0 &&!string.IsNullOrEmpty(weight.CloseAddress)) {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.ReceiveTimeout = 3000;
                    socket.SendTimeout = 3000;
                    new Thread(() => {
                        sendData(weight.CloseAddress, socket);
                    }).Start();
                    warehService.OptionWareh(weight.WeightId, "close");
                }
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e) {
            int time = textEdit1.Text.ToInt() * 1000;
            if (time <= 0) {
                timer1.Stop();
                return;
            }
            timer1.Interval = time;
            textEdit1.Enabled = !checkEdit1.Checked;
            timer1.Enabled= checkEdit1.Checked;
        }

        private void barItemGraphic_ItemClick(object sender, ItemClickEventArgs e) {
            WarehOption("open");
        }
        private void WarehOption(string type) {
            VWareh wareh = (VWareh)gvWeight.GetFocusedRow();
            if (wareh == null) {
                MessageBox.Show("请选择仓门");
                return;
            }
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = 3000;
            socket.SendTimeout = 3000;
            new Thread(() => {
               if(type.ToLower()=="open") sendData(wareh.OpenAddress, socket);
               else  sendData(wareh.CloseAddress, socket);
            }).Start();
                MessageBox.Show("操作成功！");
        }
        private void sendData(string address,Socket socket) {
            byte[] bs = new byte[] {0x00,0x26,0x00, 0x00,0x00,0x06,0x01,0x05,0x33,0x00,0xff,0x00};
            if (address == "Y0") bs[9] = 0x00;
            else if (address == "Y1") bs[9] = 0x01;
            else if (address == "Y2") bs[9] = 0x02;
            else if (address == "Y3") bs[9] = 0x03;
            else if (address == "Y4") bs[9] = 0x04;
            else if (address == "Y5") bs[9] = 0x05;
            else if (address == "Y6") bs[9] = 0x06;
            else if (address == "Y7") bs[9] = 0x07;
            else if (address == "Y8") bs[9] = 0x08;
            else if (address == "Y9") bs[9] = 0x09;
            else if (address == "Y10") bs[9] = 0x0A;
            else if (address == "Y11") bs[9] = 0x0B;
            else if (address == "Y12") bs[9] = 0x0C;
            else if (address == "Y13") bs[9] = 0x0D;
            else if (address == "Y14") bs[9] = 0x0E;
            else if (address == "Y15") bs[9] = 0x0F;
            socket.Send(bs);
            Thread.Sleep(20000);
            bs[10] = 0x00;
            socket.Send(bs);
            socket.Close();
        }

        private void barItemVedio_ItemClick(object sender, ItemClickEventArgs e) {
            WarehOption("close");
        }
    }
}