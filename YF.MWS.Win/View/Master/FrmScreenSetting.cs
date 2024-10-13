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

namespace YF.MWS.Win.View.Master
{
    public partial class FrmScreenSetting : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 大屏幕编号
        /// </summary>
        private int screenNo;

        public int ScreenNo
        {
            get { return screenNo; }
            set { screenNo = value; }
        }

        /// <summary>
        /// Ini文件串口小节名称
        /// </summary>
        private string section;

        /// <summary>
        /// 串口
        /// </summary>
        private ScreenUtil serialPort;

        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        private delegate void ShowData(string value);

        private ShowData OnShowData;

        public FrmScreenSetting()
        {
            InitializeComponent();
        }

        private void FrmScreenSetting_Load(object sender, EventArgs e)
        {
            if (!File.Exists(IniUtility.FilePath))
            {
                File.Create(IniUtility.FilePath);
            }

            //串口小节名称
            section = string.Format("Screen{0}", this.screenNo);

            this.SetComInfo();
            this.InitSerialPort(this.screenNo);
        }

        #region 设置串口信息

        /// <summary>
        /// 设置串口信息
        /// </summary>
        private void SetComInfo()
        {
            string settingValue;

            //COM端口
            foreach (string item in SerialPort.GetPortNames())
            {
                this.cmbCom.Properties.Items.Add(item);
            }
            settingValue = IniUtility.GetIniKeyValue(section, "Port", "COM1");
            this.cmbCom.EditValue = settingValue;
            //波特率
            settingValue = IniUtility.GetIniKeyValue(section, "BaundRate", "9600");
            DxHelper.BindComboBoxEdit(cmbBaudRate, SysCode.BaundRate, settingValue);
            //数据位
            settingValue = IniUtility.GetIniKeyValue(section, "DataBit", "8");
            DxHelper.BindComboBoxEdit(cmbDataBits, SysCode.DataBit, settingValue);
            //停止位
            settingValue = IniUtility.GetIniKeyValue(section, "StopBit", "One");
            DxHelper.BindComboBoxEdit(cmbStopBits, SysCode.StopBit, settingValue);
            //奇偶校验位
            settingValue = IniUtility.GetIniKeyValue(section, "Parity", "None");
            DxHelper.BindComboBoxEdit(cmbParity, SysCode.ParityVerifyBit, settingValue);
            //数据显示格式
            settingValue = IniUtility.GetIniKeyValue(section, "DataFormat", "DEC");
            if (settingValue == "DEC")
            {
                this.radioDigit.SelectedIndex = 0;
            }
            else
            {
                this.radioDigit.SelectedIndex = 1;
            }
            //屏幕切换快捷键
            txtShotCut.Text = IniUtility.GetIniKeyValue(section, "ShotCut", "F1");
        }

        #endregion

        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="screenNo">大屏幕编号</param>
        private void InitSerialPort(int screenNo)
        {
            this.serialPort = new ScreenUtil(screenNo);

            if (this.serialPort != null)
            {
                this.OnShowData = new ShowData(this.ShowDataInfo);
                this.serialPort.OnDataReceived = new ScreenUtil.DataReceived(this.ShowReceivedData);

                bool isOpen = this.serialPort.OpenPort();
                if (!isOpen)
                {
                    MessageDxUtil.ShowTips(string.Format("初始化串口{0}失败，或被占用！", this.serialPort.SerlPort.PortName));
                }
            }
            else
            {
                MessageDxUtil.ShowTips(string.Format("初始化串口{0}失败，或被占用！", this.serialPort.SerlPort.PortName));
            }
        }

        /// <summary>
        /// 修改串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
                this.serialPort.SetPortName(this.cmbCom.EditValue.ToString());
                this.serialPort.OpenPort();
            }
        }

        /// <summary>
        /// 修改波特率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
                this.serialPort.SetBaudRate(DxHelper.GetCode(cmbBaudRate));
                this.serialPort.OpenPort();
            }
        }

        /// <summary>
        /// 修改数据位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
                this.serialPort.SetDataBits(DxHelper.GetCode(cmbDataBits));
                this.serialPort.OpenPort();
            }
        }

        /// <summary>
        /// 修改停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
                this.serialPort.SetStopBits(DxHelper.GetCode(cmbStopBits));
                this.serialPort.OpenPort();
            }
        }

        /// <summary>
        /// 修改奇偶校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
                this.serialPort.SetParity(DxHelper.GetCode(cmbParity));
                this.serialPort.OpenPort();
            }
        }

        /// <summary>
        /// 显示串口接收到的数据
        /// </summary>
        /// <param name="byteData">接收到的数据</param>
        private void ShowReceivedData(byte[] byteData)
        {
            if (byteData != null && byteData.Length > 0)
            {
                string dataStr;

                if (this.radioDigit.SelectedIndex == 0)
                {
                    dataStr = Encoding.ASCII.GetString(byteData);
                }
                else
                {
                    StringBuilder sbData = new StringBuilder();
                    foreach (byte item in byteData)
                    {
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
        private void ShowDataInfo(string value)
        {
            this.memoReceive.Text += value;
            this.memoReceive.SelectionStart = this.memoReceive.Text.Length;
            this.memoReceive.ScrollToCaret();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //设置串口信息
            IniUtility.WriteIniKey(section, "Port", this.cmbCom.EditValue.ToString());
            IniUtility.WriteIniKey(section, "BaundRate", DxHelper.GetCode(cmbBaudRate));
            IniUtility.WriteIniKey(section, "DataBit", DxHelper.GetCode(cmbDataBits));
            IniUtility.WriteIniKey(section, "StopBit", DxHelper.GetCode(cmbStopBits));
            IniUtility.WriteIniKey(section, "Parity", DxHelper.GetCode(cmbParity));
            IniUtility.WriteIniKey(section, "DataFormat", this.radioDigit.SelectedIndex == 0 ? "DEC" : "HEX");
            IniUtility.WriteIniKey(section, "ShotCut", txtShotCut.Text);

            MessageDxUtil.ShowTips("成功保存大屏幕设置信息，重新启动程序后生效！");
        }

        private void barItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.memoReceive.Text = string.Empty;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void FrmScreenSetting_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.txtShotCut.Text = Keys.F1.ToString();
                    break;
                case Keys.F2:
                    this.txtShotCut.Text = Keys.F2.ToString();
                    break;
                case Keys.F3:
                    this.txtShotCut.Text = Keys.F3.ToString();
                    break;
                case Keys.F4:
                    this.txtShotCut.Text = Keys.F4.ToString();
                    break;
                case Keys.F5:
                    this.txtShotCut.Text = Keys.F5.ToString();
                    break;
                case Keys.F6:
                    this.txtShotCut.Text = Keys.F6.ToString();
                    break;
                case Keys.F7:
                    this.txtShotCut.Text = Keys.F7.ToString();
                    break;
                case Keys.F8:
                    this.txtShotCut.Text = Keys.F8.ToString();
                    break;
                case Keys.F9:
                    this.txtShotCut.Text = Keys.F9.ToString();
                    break;
                case Keys.F10:
                    this.txtShotCut.Text = Keys.F10.ToString();
                    break;
                case Keys.F11:
                    this.txtShotCut.Text = Keys.F11.ToString();
                    break;
                case Keys.F12:
                    this.txtShotCut.Text = Keys.F12.ToString();
                    break;
            }
        }

        private void FrmScreenSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.serialPort != null)
            {
                this.serialPort.ClosePort();
            }
        }
    }
}