using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YF.MWS.Win.Util;
using YF.MWS.Db;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.SQliteService;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Query;
using YF.MWS.CacheService;
using System.Threading;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmReadCard : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 通讯设备标识符
        /// </summary>
        private int icdev;

        private ICardService cardService = new CardService();

        public FrmReadCard()
        {
            InitializeComponent();
        }

        private void btnItemRead_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                            MessageDxUtil.ShowError("装载初始密码失败，请重试！");
                            goto Exit;
                        }
                        //寻卡
                        st = RF35Util.rf_card(icdev, 0, snr);
                        //寻卡失败
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("寻卡失败，请重试！");
                            goto Exit;
                        }
                        //验证卡数据块一密码
                        if (RF35Util.rf_authentication(icdev, 0, 0) != 0)
                        {
                            MessageDxUtil.ShowError("验证密码失败，请重试！");
                            goto Exit;
                        }
                        //读取卡数据
                        byte[] byteData = new byte[16];
                        byte[] dataBuffer = new byte[32];
                        //读取第一个数据地址的卡值
                        st = RF35Util.rf_read(icdev, 0 * 4 + 1, byteData);
                        if (st == 0)
                        {
                            Buffer.BlockCopy(byteData, 0, dataBuffer, 0, 16);
                            byteData = new byte[16];
                            st = RF35Util.rf_read(icdev, 0 * 4 + 2, byteData);
                            if (st == 0)
                            {
                                Buffer.BlockCopy(byteData, 0, dataBuffer, 16, 16);
                            }
                            this.txtCardId.Text = Encoding.Default.GetString(dataBuffer);
                        }
                        else
                        {
                            MessageDxUtil.ShowError("读取卡数据失败，请重试！");
                            goto Exit;
                        }
                        //验证卡数据块二密码
                        if (RF35Util.rf_authentication(icdev, 0, 1) != 0)
                        {
                            MessageDxUtil.ShowError("验证密码失败，请重试！");
                            goto Exit;
                        }
                        byteData = new byte[16];
                        dataBuffer = new byte[32];
                        //读取第二个数据地址的卡号
                        st = RF35Util.rf_read(icdev, 1 * 4 + 1, byteData);
                        if (st == 0)
                        {
                            Buffer.BlockCopy(byteData, 0, dataBuffer, 0, 16);
                            byteData = new byte[16];
                            st = RF35Util.rf_read(icdev, 1 * 4 + 2, byteData);
                            if (st == 0)
                            {
                                Buffer.BlockCopy(byteData, 0, dataBuffer, 16, 16);
                            }
                            this.txtCardNo.Text = Encoding.Default.GetString(dataBuffer);
                        }
                        else
                        {
                            MessageDxUtil.ShowError("读取卡数据失败，请重试！");
                            goto Exit;
                        }
                        //RF35Util.rf_halt(icdev);
                        //蜂鸣器响
                        RF35Util.rf_beep(icdev, 50);
                        //断开串口连接
                        RF35Util.rf_exit(icdev);
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
                                    string cardData = reader.ReadData(sEPC, 16);
                                    if (!string.IsNullOrEmpty(cardData))
                                    {
                                        this.txtCardId.Text = cardData.Substring(0, 32).ToLower();
                                        this.txtCardNo.Text = cardData.Substring(32, 17);
                                    }
                                    else
                                    {
                                        isSuccess = false;
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
                                        string cardData = reader.ReadData(sEPC, 16);
                                        if (!string.IsNullOrEmpty(cardData))
                                        {
                                            this.txtCardId.Text = cardData.Substring(0, 32).ToLower();
                                            this.txtCardNo.Text = cardData.Substring(32, 17);
                                        }
                                        else
                                        {
                                            MessageDxUtil.ShowError("读取卡数据失败！");
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

                ICarService carService = new CarService();
                QPlanCard card = CardCacher.Get(txtCardId.Text.Trim(), cardService);
                if (card != null)
                {
                    txtCarNo.Text = card.CarNo;
                    teCustomerName.Text = card.CustomerName;
                    MessageDxUtil.ShowTips("成功读取IC卡数据！");
                }
                else
                {
                    MessageDxUtil.ShowError("读取IC卡数据时发生未知错误，请重试！");
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
    }
}