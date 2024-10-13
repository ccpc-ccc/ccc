using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Query;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using System.Threading;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmWriteCard : DevExpress.XtraEditors.XtraForm
    {
        private ICarService carService = new CarService();
        private ICardService cardService = new CardService();

        /// <summary>
        /// 通讯设备标识符
        /// </summary>
        private int icdev;

        public FrmWriteCard()
        {
            InitializeComponent();
        }

        private void FrmWriteCard_Load(object sender, EventArgs e)
        {
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "CardNo", Caption = "IC卡号" });
            lstField.Add(new LookupField() { FieldName = "CarNo", Caption = "车牌" });
            lstField.Add(new LookupField() { FieldName = "CustomerName", Caption = "所属单位" });
            List<QPlanCard> lstCar = cardService.GetList();
            SearchLookupUtil.BindData(this.lookUpCar, lstCar, "CardId", "CardNo", lstField);
        }

        private void btnItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SysCfg sysCfg = CfgUtil.GetCfg();
            if (!sysCfg.StartReadCard)
            {
                MessageDxUtil.ShowTips("未启用读卡器，请在系统设置中启用读卡器后重试！");
                return;
            }

            ReadCardCfg cardCfg = sysCfg.LstReadCard.Find(item => item.IsStart == true);
            if (cardCfg == null)
            {
                MessageDxUtil.ShowTips("未设置读卡器信息，请在系统设置中设置读卡器后重试！");
                return;
            }

            if (MessageDxUtil.ShowYesNoAndTips("确定正确放置卡片后，按确定按钮！") == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(this.txtCardNo.Text))
                {
                    MessageDxUtil.ShowTips("请输入卡号！");
                    return;
                }

                if (string.IsNullOrEmpty(this.txtCardValue.Text))
                {
                    MessageDxUtil.ShowTips("请输入卡值！");
                    return;
                }

                if (cardCfg.Type == ReadCardType.Short)
                {
                    short port = Convert.ToInt16(Convert.ToInt32(cardCfg.SerialPort1.Substring(3, cardCfg.SerialPort1.Length - 3)) - 1);
                    icdev = RF35Util.rf_init(port, 9600);

                    if (icdev == 0)
                    {
                        port = Convert.ToInt16(Convert.ToInt32(cardCfg.SerialPort2.Substring(3, cardCfg.SerialPort2.Length - 3)) - 1);
                        icdev = RF35Util.rf_init(port, 9600);
                    }

                    if (icdev > 0)
                    {
                        byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                        byte[] snr = new byte[5];
                        int st;
                        //装载初始密码
                        if (RF35Util.rf_load_key(icdev, 0, 0, key) != 0 || RF35Util.rf_load_key(icdev, 0, 1, key) != 0)
                        {
                            MessageDxUtil.ShowError("装载初始密码失败！");
                            goto Exit;
                        }
                        //寻卡
                        st = RF35Util.rf_card(icdev, 0, snr);
                        //寻卡失败
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("寻卡失败！");
                            goto Exit;
                        }
                        //验证卡数据块一密码
                        if (RF35Util.rf_authentication(icdev, 0, 0) != 0)
                        {
                            MessageDxUtil.ShowError("验证密码失败！");
                            goto Exit;
                        }
                        //向卡写入数据
                        byte[] byteData;
                        byte[] dataBuffer;
                        //向第一个数据地址写入卡值
                        string data = this.txtCardValue.Text.Trim();
                        dataBuffer = Encoding.Default.GetBytes(data);
                        byteData = new byte[16];
                        Buffer.BlockCopy(dataBuffer, 0, byteData, 0, 16);
                        st = RF35Util.rf_write(icdev, 0 * 4 + 1, byteData);
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("写入卡数据失败！");
                            goto Exit;
                        }
                        if (dataBuffer.Length > 16)
                        {
                            byteData = new byte[dataBuffer.Length - 16];
                            Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                            st = RF35Util.rf_write(icdev, 0 * 4 + 2, byteData);
                            if (st != 0)
                            {
                                MessageDxUtil.ShowError("写入卡数据失败！");
                                goto Exit;
                            }
                        }
                        //验证卡数据块二密码
                        if (RF35Util.rf_authentication(icdev, 0, 1) != 0)
                        {
                            MessageDxUtil.ShowError("验证密码失败！");
                            goto Exit;
                        }
                        //向第二个数据地址写入卡号
                        data = this.txtCardNo.Text.Trim();
                        dataBuffer = Encoding.Default.GetBytes(data);
                        byteData = new byte[16];
                        Buffer.BlockCopy(dataBuffer, 0, byteData, 0, 16);
                        st = RF35Util.rf_write(icdev, 1 * 4 + 1, byteData);
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("写入卡数据失败！");
                            goto Exit;
                        }
                        if (dataBuffer.Length > 16)
                        {
                            byteData = new byte[dataBuffer.Length - 16];
                            Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                            st = RF35Util.rf_write(icdev, 1 * 4 + 2, byteData);
                            if (st != 0)
                            {
                                MessageDxUtil.ShowError("写入卡数据失败！");
                                goto Exit;
                            }
                        }
                        //RF35Util.rf_halt(icdev);
                        //蜂鸣器响
                        RF35Util.rf_beep(icdev, 50);
                        //断开串口连接
                        RF35Util.rf_exit(icdev);
                        MessageDxUtil.ShowTips("写入卡数据成功！");
                    }
                    else
                    {
                        MessageDxUtil.ShowError("串口连接失败，请重试！");
                    }
                }
                else
                {
                    int port = Convert.ToInt32(cardCfg.SerialPort1.Substring(3, cardCfg.SerialPort1.Length - 3));
                    UHFReader18Util reader = new UHFReader18Util(port);
                    //打开串口
                    bool isSuccess = reader.OpenPort();

                    if (isSuccess)
                    {
                        //设置读卡器工作模式
                        isSuccess = reader.SetReaderWorkMode(0, 16);
                        if (isSuccess)
                        {
                            //设置读卡器功率
                            isSuccess = reader.SetReaderPowerDbm(10);
                            if (isSuccess)
                            {
                                //查找标签
                                string sEPC = reader.InventoryReader();
                                if (!string.IsNullOrEmpty(sEPC))
                                {
                                    Thread.Sleep(1000);
                                    string data = string.Format("{0}{1}", this.txtCardValue.Text.Trim(), this.txtCardNo.Text.Trim().PadRight(32, '0'));
                                    isSuccess = reader.WriteData(sEPC, data, 16);
                                    if (isSuccess)
                                    {
                                        MessageDxUtil.ShowTips("写入数据成功！");
                                    }
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                            }
                        }

                        //关闭串口
                        reader.ClosePort();
                    }

                    if (!isSuccess)
                    {
                        port = Convert.ToInt32(cardCfg.SerialPort2.Substring(3, cardCfg.SerialPort2.Length - 3));
                        reader = new UHFReader18Util(port);
                        //打开串口
                        isSuccess = reader.OpenPort();

                        if (isSuccess)
                        {
                            //设置读卡器工作模式
                            isSuccess = reader.SetReaderWorkMode(0, 16);
                            if (isSuccess)
                            {
                                //设置读卡器功率
                                isSuccess = reader.SetReaderPowerDbm(10);
                                if (isSuccess)
                                {
                                    //查找标签
                                    string sEPC = reader.InventoryReader();
                                    if (!string.IsNullOrEmpty(sEPC))
                                    {
                                        Thread.Sleep(1000);
                                        string data = string.Format("{0}{1}", this.txtCardValue.Text.Trim(), this.txtCardNo.Text.Trim().PadRight(32, '0'));
                                        isSuccess = reader.WriteData(sEPC, data, 16);
                                        if (isSuccess)
                                        {
                                            MessageDxUtil.ShowTips("写入数据成功！");
                                        }
                                        else
                                        {
                                            MessageDxUtil.ShowError("写入数据失败！");
                                        }
                                    }
                                    else
                                    {
                                        MessageDxUtil.ShowError("检测标签时出错！");
                                    }
                                }
                                else
                                {
                                    MessageDxUtil.ShowError("设置读写器功率失败！");
                                }
                            }
                            else
                            {
                                MessageDxUtil.ShowError("设置读写器工作模式失败！");
                            }

                            //关闭串口
                            reader.ClosePort();
                        }
                        else
                        {
                            MessageDxUtil.ShowError("串口连接失败，请重试！");
                        }
                    }
                }
                return;
            }

        //中断卡连接
        Exit:
            //RF35Util.rf_halt(icdev);
            RF35Util.rf_exit(icdev);
        }

        private void btnItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void lookUpCar_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpCar.Properties.View.GetFocusedRow() != null)
            {
                QPlanCard car = this.lookUpCar.Properties.View.GetFocusedRow() as QPlanCard;
                if (car != null)
                {
                    this.txtCardNo.Text = car.CardNo;
                    this.txtCardValue.Text = car.Id;
                }
            }
        }
    }
}