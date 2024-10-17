using com.google.zxing.common;
using DevExpress.Export.Xl;
using DevExpress.Office;
using DevExpress.Office.Utils;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.SQliteService;
using YF.MWS.Win.View.Master;
using YF.Utility;
using YF.Utility.IO;
using YF.Utility.Log;

namespace YF.MWS.Win.Uc
{
    public partial class WeightControl : UserControl
    {
        private IMaterialService materialService = new MaterialService();
        private IWeightService weightService=new WeightService();
        public int Index { get; private set; }
        private List<SMaterial> materials { get; set; }
        private List<Label> labels { get; set; }
        private Socket _socket;
        private int _connectTime = 0;
        private byte[] _startByte = new byte[] { 0x01, 0x01, 0x01, 0x03, 0x11, 0x89 };
        private DataTable _dataList = new DataTable();
        private bool isRelease = false;
        /// <summary>
        /// 仪表当前重量
        /// </summary>
        private decimal _weight;
        public WeightControl(int index)
        {
            InitializeComponent();
            this.Index = index;
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode) {
            this.lbName.Text = Program._cfg.Device[Index].Name;
            if(!string.IsNullOrEmpty(Program._cfg.Device[Index].ReturnZeroCommand)) _startByte = Program._cfg.Device[Index].ReturnZeroCommand.HexGetBytes();
            materials = materialService.GetMaterialByCompanyId(Index.ToString());
            labels = new List<Label>();
            int i = 2;
            if (materials != null && materials.Count > 0) {
            foreach(SMaterial material in materials) {
                Label lb = setLabel();
                    lb.Text = material.MaterialName;
                    tableLayoutPanel1.Controls.Add(lb, 0, i);
                lb = setLabel();
                    lb.Text = "0";
                tableLayoutPanel1.Controls.Add(lb, 1, i);
                    lb.Tag = material.Id;
                labels.Add(lb);
                i++;
                if (i > 7) break;
            }
            }
            _dataList.Columns.Add("MaterialName");
            _dataList.Columns.Add("Weight");
            _dataList.Columns.Add("CreateTime");
            gvWeight.Columns["CreateTime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            connect();
            }
        }
        private Label setLabel() {
            Label lb = new Label();
            lb.AutoSize = false;
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Font = new System.Drawing.Font(lb.Font.FontFamily, 14);
            lb.Dock= DockStyle.Fill;
            return lb;
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            if (this._socket != null && this._socket.Connected) this._socket.Close();
            FrmDeviceSetting frm = new FrmDeviceSetting(this.Index);
            frm.ShowDialog();
            this.lbName.Text = Program._cfg.Device[Index].Name;
            connect();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void saveWeight(decimal weight) {
            SMaterial sMaterial = null;
            foreach (SMaterial material in materials) {
                if (material.MinWeight < weight && material.MaxWeight >= weight) {
                    sMaterial = material;
                    break;
                }
            }
            BWeight model = new BWeight() {
                SuttleWeight = weight,
                CompanyId = Index.ToString()
            };
            if(sMaterial!=null)model.MaterialId = sMaterial.Id;
            weightService.save(model, Program._cfg.Device[Index].SettlementTime);
            this.Invoke(new Action(() => {
            DataRow row = _dataList.NewRow();
            if(sMaterial!=null) row["MaterialName"] = sMaterial.MaterialName;
            row["Weight"] = weight;
            row["CreateTime"] = DateTime.Now;
            this._dataList.Rows.Add(row);
                this.gcWeight.DataSource = _dataList;
                this.gcWeight.RefreshDataSource();
            if (sMaterial != null) {
            foreach(Label lb in labels) {
                if (lb.Tag.ToString() == sMaterial.Id) {
                        lb.Text = (lb.Text.ToDecimal()+weight).ToString();
                    break;
                }
            }
            }
            }));
        }
        private void connect() {
            DeviceCfg device = Program._cfg.Device[Index];
            if (!device.StartDevice) return;
            if (device.ConnectType == 0) {

            } else if (device.ConnectType == 1)  {
                new Thread(() => {
                    Connect();
                }).Start();
            }
        }
        private void Connect() {
            DeviceCfg device = Program._cfg.Device[Index];
            if (this.IsDisposed) return;
                try {
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._socket.Connect(device.ServerIP, device.ServerPort);
                byte[] bytes = new byte[48];
                while (true) {
                    Thread.Sleep(100);
                    if (this._socket == null || !this._socket.Connected) return;
                    int received = this._socket.Receive(bytes);
                    this._connectTime = 0;
                this.Invoke(new Action(() => {
                    this.lbConnected.Text = "已连接";
                    this.lbConnected.ForeColor = Color.Green;
                }));
                        byte[] data= new byte[received];
                        Array.Copy(bytes, data, received);
                   string str= data.ToHexStr(false,true);
                    //Logger.Write("data " +str);
                        AnalyWeight(data);
                    if (bytes.Contains(_startByte)) {
                        saveWeight(this._weight);
                    }
                }
            } catch (Exception ex) {
                Logger.WriteException(ex);
                if (!this.isRelease) {
                this.Invoke(new Action(() => {
                    this.lbConnected.Text = "连接失败";
                    this.lbConnected.ForeColor = Color.Red;
                }));
                Thread.Sleep(5000);
                Connect();
                }
            }
        }
        private decimal? AnalyWeight(byte[] bytes) {
            decimal? weight= ProtoclAnaly.GetWithTOLEDO(bytes);
            if (weight == null) return null;
            this._weight = weight.ToDecimal();
            this.Invoke((Action)delegate {
                this.lbWeight.Text=this._weight.ToString();
            });
            return this._weight;
        }
        private void timer1_Tick(object sender, EventArgs e) {
           if(_connectTime<10) _connectTime++;
            else if(_connectTime==10) {
                if (this._socket != null && this._socket.Connected) {
                    this._socket.Close();
                }
                _connectTime++;
            }
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            this.isRelease = true;
            if (this._socket != null && this._socket.Connected) {
                this._socket.Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            this._dataList.Rows.Clear();
            foreach (Label lb in labels) {
                if (!string.IsNullOrEmpty( lb.Tag.ToString())) {
                    lb.Text = "0.00";
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) {
            saveWeight(12);
        }

        private void simpleButton4_Click(object sender, EventArgs e) {
            foreach (DataColumn column in this._dataList.Columns) {
                column.Caption = "";
            }
            foreach (GridColumn col in gvWeight.Columns) {
                if (this._dataList.Columns.Contains(col.FieldName) && col.Visible) this._dataList.Columns[col.FieldName].Caption = col.Caption;
            }
            for (int i = this._dataList.Columns.Count - 1; i >= 0; i--) {
                if (string.IsNullOrEmpty(this._dataList.Columns[i].Caption)) this._dataList.Columns.RemoveAt(i);
            }
            FileDialog sfdFileSave = new SaveFileDialog();
                sfdFileSave.Filter = "Excel 文件|*.xls";
            if (sfdFileSave.ShowDialog() == DialogResult.OK) {
                string filePath = sfdFileSave.FileName;
                bool isSuccess = NPOIHelper.DataTableToExcel(this._dataList, filePath, null);
                if (isSuccess) {
                    MessageDxUtil.ShowTips("数据成功导出.");
                } else {
                    MessageDxUtil.ShowError("数据导出失败.");
                }
            }
        }
    }
}
