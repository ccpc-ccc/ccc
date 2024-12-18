﻿using DevExpress.CodeParser;
using DevExpress.Internal.WinApi;
using DevExpress.Utils.About;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YF.Utility;
using System.IO;
using System.IO.Compression;

namespace test {
    public partial class Form1 : Form {
        private SerialPort serialPort1;
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text == "") return;
            List<byte> bs = new List<byte>();
            string[] strs=textBox1.Text.Split(' ');
            foreach (string str in strs) {
                if (str == "") continue;
                byte b = Convert.ToByte(str, 16);
                bs.Add(b);
            }
            double weight= GetWithYHTF0(bs.ToArray());
            textBox2.Text = weight.ToString();
        }
        /// <summary>
        /// 处理KLD2008称重数据
        /// </summary>
        private double GetWithYHTF0(byte[] byteFrame) {
            if (byteFrame == null || byteFrame.Length == 0) {
                return 0;
            }
            //对接收到的数据进行校验
            byte byteVerif = (byte)(byteFrame[1] ^ byteFrame[2] ^ byteFrame[3] ^ byteFrame[4] ^ byteFrame[5] ^ byteFrame[6] ^ byteFrame[7] ^ byteFrame[8]);
            //校验高位
            byte verifHigh = (byte)((byteVerif & 0xf0) >> 4);
            //校验低位
            byte verifLow = (byte)(byteVerif & 0x0f);
            if (verifHigh > 9)
                verifHigh = (byte)(verifHigh + 0x37);
            else
                verifHigh = (byte)(verifHigh + 0x30);
            if (verifLow > 9)
                verifLow = (byte)(verifLow + 0x37);
            else
                verifLow = (byte)(verifLow + 0x30);
            if (byteFrame[9] == verifHigh && byteFrame[10] == verifLow) {
                List<byte> listDigit = new List<byte>() { (byte)0x30, (byte)0x31, (byte)0x32, (byte)0x33, (byte)0x34, (byte)0x35, (byte)0x36, (byte)0x37, (byte)0x38, (byte)0x39 };

                StringBuilder sbDigit = new StringBuilder();
                //获取称重数据
                for (int i = 2; i < 8; i++) {
                    if (!listDigit.Contains(byteFrame[i]))
                        byteFrame[i] = (byte)0x30;
                    sbDigit.Append(byteFrame[i] - 0x30);
                }
                //小数点位置
                int dotPos = byteFrame[8] - 0x30;
                int exponent = -dotPos;
                double weightValue = Convert.ToInt32(sbDigit.ToString()) * Math.Pow(10, exponent);
                //负数处理
                if (byteFrame[1] == 0x2D)
                    weightValue = -weightValue;
                return weightValue;
            }
            return 0;
        }

        private double GetWithD2002(byte[] byteFrame) {
            string weightData = Encoding.ASCII.GetString(byteFrame, 1, 7);
            //Logger.Write("KLD2002 data:" + weightData);
            char[] dataArr = weightData.ToCharArray();
            Array.Reverse(dataArr);
            weightData = string.Concat(dataArr);

           return Convert.ToDouble(weightData);
        }

        private void button2_Click(object sender, EventArgs e) {
          txtChinese.Text=  NumToChinese(txtNum.Text.ToDecimal());
        }
        private string NumToChinese(decimal num) {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾"; //数字位所对应的汉字
            string str4 = "";    //数字的字符串形式
            string str5 = "";  //人民币大写金额形式
            string str6 = "";
            int p = 0;  //小数点的位置
            int i;    //循环变量
            int j;    //num的值乘以100的字符串长度
            string ch1 = "";    //数字的汉语读法
            string ch2 = "";    //数字位的汉字读法
            int nzero = 0;  //用来计算连续的零值是几个
            int temp;            //从原num值中取出的值

            //num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数
            str4 = num.ToString();        //将num转换成字符串形式
            p = str4.IndexOf(".");
            if (p > 0) {
                str6 = str4.Substring(p + 1);
                str4 = str4.Substring(0, p);
            } else if (p == 0) {
                str6 = str4.Substring(1);
                str4 = "0";
            }
            if (str4.Length > 13) { return "溢出"; }
            j = str4.Length;
            str2 = str2.Substring(13 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分
            for (i = 0; i < j; i++) {
                char s = str4[i];
                temp = str4.Substring(i,1).ToInt();
                if (i != (j - 5) && i != (j - 9) && i != (j - 13)) {
                    //当所取位数不为万、亿、万亿上的数字时
                    if (s == '0') {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    } else {
                        if (nzero != 0) {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                        } else {
                            ch1 = str1.Substring(temp * 1, 1);
                        }
                        if (i < j - 1) ch2 = str2.Substring(i, 1);
                        else ch2 = "";
                        nzero = 0;
                    }
                } else {
                    //该位是万亿，亿，万位等关键位
                    if (s != '0' && nzero != 0) {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    } else if (s != '0' && nzero == 0) {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    } else if (s == '0' && nzero >= 3) {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    } else {
                        if (j >= 11) {
                            ch1 = "";
                            nzero = nzero + 1;
                        } else {
                            ch1 = "";
                            ch2 = str2.Substring(i, 1);
                            nzero = nzero + 1;
                        }
                    }
                }
                str5 = str5 + ch1 + ch2;
            }
            j = str6.Length;
            if (j > 0) str5 += "点";
            for (i = 0; i < j; i++) {
                temp = str6.Substring(i,1).ToInt();
                str5 += str1[temp].ToString();
            }
            if (num == 0) {
                str5 = "零";
            }
            return str5;
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.serialPort1 = new SerialPort();
            this.serialPort1.DataReceived += new SerialDataReceivedEventHandler(this.SerlPort_DataReceived);
            foreach (string item in SerialPort.GetPortNames()) {
                cmbCom1.Properties.Items.Add(item);
            }
            DxHelper.BindComboBoxEdit<YF.MWS.Metadata.StopBits>(cmbStopBits1,"One");
            DxHelper.BindComboBoxEdit<YF.MWS.Metadata.Parity>(cmbParity1,"None");
        }
        private void SerlPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            if (this.serialPort1 == null || !this.serialPort1.IsOpen) return;
                //等待接收数据
                Thread.Sleep(100);
            //接收数据
            try {
                int count = this.serialPort1.BytesToRead;
                byte[] byteRead = new byte[count];
                this.serialPort1.Read(byteRead, 0, count);
                StringBuilder sbData = new StringBuilder();
                foreach (byte item in byteRead) {
                    sbData.Append(string.Format("{0} ", item.ToString("X2")));
                }
                this.Invoke(new Action(
                    () => {
                        textBox3.Text += "Rx:" + sbData.ToString() + "\r\n";
                    }
                    ));
            } catch (Exception ex) {
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            if (simpleButton2.Text == "连接") {
                if (this.serialPort1 != null && this.serialPort1.IsOpen) {
                    this.serialPort1.Close();
                }
                this.serialPort1.PortName = cmbCom1.EditValue.ToString();
                this.serialPort1.BaudRate = cmbBaudRate1.Text.ToInt();
                this.serialPort1.DataBits = cmbDataBits1.Text.ToInt();
                this.serialPort1.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), cmbStopBits1.GetStrValue());
                this.serialPort1.Parity=(System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), cmbParity1.GetStrValue());
                try {
                this.serialPort1.Open();
                simpleButton2.Text = "断开";
                }catch (Exception ex) {
                    MessageBox.Show("打开串口失败！");
                }
            } else {
                this.serialPort1.Close();
                simpleButton2.Text = "连接";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.serialPort1 != null&&this.serialPort1.IsOpen) {
                this.serialPort1.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            if (!this.serialPort1.IsOpen) {
                MessageBox.Show("串口未打开");
                return;
            } else {
                byte[] bs = textBox4.Text.HexGetBytes();
                byte[] a= new byte[2] { bs[2] , bs[3] };
                int add = (bs[2] << 8)+bs[3];
                add += this.cmbAddress.SelectedIndex * 500;
                add.ToByte2(a,0);
                bs[2] = a[0];
                bs[3] = a[1];
                if(this.chkCRC.Checked) {
                    byte[] crc=DxHelper.GetCRC(bs);
                    bs=bs.Concat(crc).ToArray();
                }
                this.serialPort1.Write(bs,0,bs.Length);
                StringBuilder sbData = new StringBuilder();
                foreach (byte item in bs) {
                    sbData.Append(string.Format("{0} ", item.ToString("X2")));
                }
                textBox3.Text += "Tx:" + sbData.ToString() + "\r\n";
            }
        }
    }
}
