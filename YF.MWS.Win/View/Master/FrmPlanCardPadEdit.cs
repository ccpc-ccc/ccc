using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraLayout;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using System.Threading;
using YF.MWS.Metadata.Cfg;
using YF.MWS.SQliteService.Remote;
using YF.MWS.Client.DataService.Interface.Remote;

namespace YF.MWS.Win.View.Master
{
    public partial class FrmPlanCardPadEdit : DevExpress.XtraEditors.XtraForm
    {
        private string currentCarId = string.Empty;
        private string currentMaterialId = string.Empty;
        private string currentCustomerId = string.Empty;
        private string currentDeliverId = string.Empty;
        private string currentReceiverId = string.Empty;
        private ICardService cardService = new CardService();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private ISeqNoService seqNoService = new SeqNoService();
        private List<BCardPreset> lstPreset = new List<BCardPreset>();
        private int icdev;
        private int port;
        private CardIdGenerateMode generateMode;
        private ReadCardType cardType;
        private bool isOpen = false;
        private UHFReader18Util remoteCardReader = null;
        private bool hasReadCard = true;
        /// <summary>
        /// 线程同步锁
        /// </summary>
        private static object lockObj = new object();
        private string cardId = string.Empty;
        private bool isVirtualCard = false;
        private bool isNew = true;
        private bool startAppCardRead = false;
        private SysCfg cfg;
        private WriteCardCfg writeCard;
        private SpeechUtil speech=null;
        public bool StartAppCardRead
        {
            get { return startAppCardRead; }
            set { startAppCardRead = value; }
        }

        public bool IsVirtualCard
        {
            get { return isVirtualCard; }
            set { isVirtualCard = value; }
        }

        public FrmPlanCardPadEdit()
        {
            InitializeComponent();
        }

        private void FrmPlanCardPadEdit_Load(object sender, EventArgs e)
        {
            speech = new SpeechUtil();
            btnFinishInput.Enabled = false;
            btnReconnect.Enabled = false;
            cfg = CfgUtil.GetCfg();
            if (cfg!=null && cfg.WriteCard != null)
            {
                writeCard = cfg.WriteCard;
            }
            if (writeCard != null) 
            {
                generateMode = writeCard.CardIdGenerate;
                cardType = writeCard.CardType;
                string portName = writeCard.PortName;
                if (!string.IsNullOrEmpty(portName))
                {
                    port = int.Parse(portName.Substring(3, portName.Length - 3)) - 1;
                    OpenPort();
                }
            }
        }

        private bool OpenPort()
        {
            btnReconnect.Enabled = false;
            string message = "成功打开串口.";
            if (cardType == ReadCardType.Remote)
            {
                remoteCardReader = new UHFReader18Util(port + 1);
                isOpen = remoteCardReader.OpenPort();
                if (isOpen)
                {
                    bool isSuccess = remoteCardReader.SetReaderWorkMode(0, 16);
                    if (isSuccess && writeCard != null && writeCard.ApplyParameter && writeCard.PowerDbm > 0)
                    {
                        //设置读卡器功率
                        isSuccess = remoteCardReader.SetReaderPowerDbm(writeCard.PowerDbm);
                        if (isSuccess)
                        {
                            isOpen = true;
                        }
                    }
                }
            }
            else
            {
                icdev = RF35Util.rf_init((short)port, 9600);
                if (icdev > 0)
                    isOpen = true;
                else
                    isOpen = false;
                if (isOpen)
                {
                    byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                    //装载初始密码
                    if (RF35Util.rf_load_key(icdev, 0, 0, key) != 0 || RF35Util.rf_load_key(icdev, 0, 1, key) != 0)
                    {
                        icdev = 0;
                        Logger.Write("1#RF35读卡器装载初始密码失败，请重试！");
                    }
                }
            }
            if (generateMode == CardIdGenerateMode.CardSN)
            {
                if (!timerReadCard.Enabled)
                    timerReadCard.Start();
            }
            else
            {
                if (timerReadCard.Enabled)
                    timerReadCard.Stop();
            }
            if (!isOpen)
                message = "打开串口失败,请重试.";
            lblStateNote.Text = message;
            btnReconnect.Enabled = !isOpen;
            return isOpen;
        }

        private void ClosePort()
        {
            if (isOpen)
            {
                if (timerReadCard.Enabled)
                    timerReadCard.Stop();
                if (cardType == ReadCardType.Remote)
                {
                    if (isOpen)
                        remoteCardReader.ClosePort();
                }
                else
                {
                    if (icdev > 0)
                        RF35Util.rf_exit(icdev);
                }
                isOpen = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectCarNo_Click(object sender, EventArgs e)
        {
            using (FrmCarSelectorPad frmCarSelector = new FrmCarSelectorPad())
            {
                if (frmCarSelector.ShowDialog() == DialogResult.OK)
                {
                    teCarNo.Text = frmCarSelector.CarNo;
                    currentCarId = frmCarSelector.CarId;
                }
            }
        }

        private void btnSelectMaterial_Click(object sender, EventArgs e)
        {
            using (FrmMaterialSelectorPad frmMaterialSelector = new FrmMaterialSelectorPad())
            {
                if (frmMaterialSelector.ShowDialog() == DialogResult.OK)
                {
                    teMaterial.Text = frmMaterialSelector.MaterialName;
                    currentMaterialId = frmMaterialSelector.MaterialId;
                }
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (FrmCustomerSelectorPad frmCustomerSelector = new FrmCustomerSelectorPad())
            {
                if (frmCustomerSelector.ShowDialog() == DialogResult.OK)
                {
                    teCustomer.Text = frmCustomerSelector.CustomerName;
                    currentCustomerId = frmCustomerSelector.CustomerId;
                }
            }
        }

        private void btnSelectDeliver_Click(object sender, EventArgs e)
        {
            using (FrmCustomerSelectorPad frmCustomerSelector = new FrmCustomerSelectorPad())
            {
                frmCustomerSelector.Type = CustomerType.Delivery;
                if (frmCustomerSelector.ShowDialog() == DialogResult.OK)
                {
                    teDeliver.Text = frmCustomerSelector.CustomerName;
                    currentDeliverId = frmCustomerSelector.CustomerId;
                }
            }
        }

        private void btnSelectReceiver_Click(object sender, EventArgs e)
        {
            using (FrmCustomerSelectorPad frmCustomerSelector = new FrmCustomerSelectorPad())
            {
                frmCustomerSelector.Type = CustomerType.Receiver;
                if (frmCustomerSelector.ShowDialog() == DialogResult.OK)
                {
                    teReceiver.Text = frmCustomerSelector.CustomerName;
                    currentReceiverId = frmCustomerSelector.CustomerId;
                }
            }
        }

        private void timerReadCard_Tick(object sender, EventArgs e)
        {
            ReadCard();
        }

        private void LoadData(string cardId)
        {
            QPlanCard card = cardService.Get(cardId);
            if (card != null)
            {
                isNew = false;
                FormHelper.BindControl<BPlanCard>(this, card);
                teCarNo.Text = card.CarNo;
                currentCarId = card.CarId;
                currentCustomerId = card.CustomerId;
                teCustomer.Text = card.CustomerName;
                currentDeliverId = card.DeliveryId;
                teDeliver.Text = card.DeliveryName;
                currentReceiverId= card.ReceiverId;
                teReceiver.Text = card.ReceiverName;
                currentMaterialId = card.MaterialId;
                teMaterial.Text = card.MaterialName;
            }
        }

        private void ReadCard()
        {
            lock (lockObj)
            {
                if (hasReadCard)
                {
                    return;
                }
                if (cardType == ReadCardType.Short)
                {
                    if (icdev > 0)
                    {
                        byte[] snr = new byte[5];
                        int st;
                        //寻卡
                        st = RF35Util.rf_card(icdev, 0, snr);
                        //寻卡失败
                        if (st != 0)
                        {
                            Logger.Info("寻卡失败，请重试！");
                            return;
                        }
                        cardId = RF35Util.GetCardId(snr);
                        if (!string.IsNullOrEmpty(cardId) && cardId.Length > 0)
                        {
                            LoadData(cardId);
                            hasReadCard = true;
                        }
                        RF35Util.rf_halt(icdev);
                        //蜂鸣器响
                        RF35Util.rf_beep(icdev, 50);
                    }
                }
                else
                {
                    if (isOpen)
                    {
                        cardId = remoteCardReader.GetTIDInventory();
                        if (!string.IsNullOrEmpty(cardId))
                        {
                            LoadData(cardId);
                            hasReadCard = true;
                        }
                    }
                }
            }
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            OpenPort();
        }

        private void FrmPlanCardPadEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
        }

        public void Clear()
        {
            cardId= string.Empty;
            teCarNo.Text = null;
            currentCustomerId = string.Empty;
            currentDeliverId = string.Empty;
            currentMaterialId = string.Empty;
            currentReceiverId = string.Empty;
            teCustomer.Text = null;
            teDeliver.Text = null;
            teMaterial.Text = null;
            teReceiver.Text = null;
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (generateMode == CardIdGenerateMode.CardSN)
            {
                if (string.IsNullOrEmpty(cardId) || cardId.Length==0)
                {
                    string message = "请先刷近距离卡.";
                    if (cardType == ReadCardType.Remote)
                        message = "请先刷远距离卡.";
                    lblStateNote.Text = message;
                    isValidated = false;
                }
            }
            if (teCarNo.Text.Length == 0) 
            {
                lblStateNote.Text = "请输入车牌号";
                isValidated = false;
            }
            return isValidated;
        }

        private string GetCarId(string carNo)
        {
            string carId = string.Empty;
            if (!string.IsNullOrEmpty(carNo) && carNo.Length > 0)
            {
                SCar car = carService.GetByCarNo(carNo);
                if (car == null)
                {
                    car = new SCar();
                    car.Id = YF.MWS.Util.Utility.GetGuid();
                    car.CarNo = this.Text.Trim();
                    car.CarType = "A1";
                    carService.Save(car);
                    carId = car.Id;
                }
                else
                {
                    carId = car.Id;
                }
            }
            return carId;
        }

        private void WriteCard(string cardId, string cardNo)
        {
            bool isSuccess = false;
            if (cardType == ReadCardType.Short)
            {
                if (icdev > 0)
                {
                    byte[] key = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                    byte[] snr = new byte[5];
                    int st;
                    //装载初始密码
                    if (RF35Util.rf_load_key(icdev, 0, 0, key) != 0 || RF35Util.rf_load_key(icdev, 0, 1, key) != 0)
                    {
                        //MessageDxUtil.ShowError("装载初始密码失败！");
                    }
                    //寻卡
                    st = RF35Util.rf_card(icdev, 0, snr);
                    //寻卡失败
                    if (st != 0)
                    {
                        //MessageDxUtil.ShowError("寻卡失败！");
                    }
                    //验证卡数据块一密码
                    if (RF35Util.rf_authentication(icdev, 0, 0) != 0)
                    {
                        //MessageDxUtil.ShowError("验证密码失败！");
                    }
                    //向卡写入数据
                    byte[] byteData;
                    byte[] dataBuffer;
                    //向第一个数据地址写入卡值
                    string data = cardId;
                    dataBuffer = Encoding.Default.GetBytes(data);
                    byteData = new byte[16];
                    Buffer.BlockCopy(dataBuffer, 0, byteData, 0, 16);
                    st = RF35Util.rf_write(icdev, 0 * 4 + 1, byteData);
                    if (st != 0)
                    {
                        //MessageDxUtil.ShowError("写入卡数据失败！");
                    }
                    if (dataBuffer.Length > 16)
                    {
                        byteData = new byte[dataBuffer.Length - 16];
                        Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                        st = RF35Util.rf_write(icdev, 0 * 4 + 2, byteData);
                        if (st != 0)
                        {
                            //MessageDxUtil.ShowError("写入卡数据失败！");
                        }
                    }
                    //验证卡数据块二密码
                    if (RF35Util.rf_authentication(icdev, 0, 1) != 0)
                    {
                        //MessageDxUtil.ShowError("验证密码失败！");
                    }
                    //向第二个数据地址写入卡号
                    data = cardNo;
                    dataBuffer = Encoding.Default.GetBytes(data);
                    byteData = new byte[16];
                    Buffer.BlockCopy(dataBuffer, 0, byteData, 0, 16);
                    st = RF35Util.rf_write(icdev, 1 * 4 + 1, byteData);
                    if (dataBuffer.Length > 16)
                    {
                        byteData = new byte[dataBuffer.Length - 16];
                        Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                        st = RF35Util.rf_write(icdev, 1 * 4 + 2, byteData);
                    }
                    //RF35Util.rf_halt(icdev);
                    //蜂鸣器响
                    RF35Util.rf_beep(icdev, 50);
                    //断开串口连接
                    RF35Util.rf_exit(icdev);
                }
            }
            else
            {
                if (isOpen)
                {
                    //设置读卡器工作模式
                    isSuccess = remoteCardReader.SetReaderWorkMode(0, 16);
                    if (!isSuccess)
                        return;
                    //设置读卡器功率
                    isSuccess = remoteCardReader.SetReaderPowerDbm(10);
                    if (!isSuccess)
                        return;
                    //查找标签
                    string sEPC = remoteCardReader.InventoryReader();
                    if (!string.IsNullOrEmpty(sEPC))
                    {
                        Thread.Sleep(1000);
                        string data = string.Format("{0}{1}", cardId, cardNo.PadRight(32, '0'));
                        isSuccess = remoteCardReader.WriteData(sEPC, data, 16);
                    }
                }
            }
        }

        private void SetButton(bool finishInput) 
        {
            if (finishInput)
            {
                btnFinishInput.Enabled = false;
                btnStartInput.Enabled = true;
            }
            else
            {
                btnFinishInput.Enabled = true;
                btnStartInput.Enabled = false;
            }
        }

        public bool Save()
        {
            bool isSaved = false;
            try
            {
                bool isValidated = ValidateForm();
                if (!isValidated)
                {
                    return isSaved;
                }
                BPlanCard card = null;
                bool isNewCard = false;
                if (!string.IsNullOrWhiteSpace(cardId) && cardId.Length > 0)
                {
                    card = cardService.GetByCardId(cardId);
                }
                if (card == null)
                {
                    isNewCard = true;
                    card = new BPlanCard();
                    card.CardNo = seqNoService.GetSeqNo(SeqCode.Card.ToString());
                    card.PlanNo = seqNoService.GetSeqNo(SeqCode.Plan.ToString());
                }
                FormHelper.ControlToEntity<BPlanCard>(this, ref card);
                if (isNewCard)
                {
                    if (isVirtualCard)
                    {
                        card.Id = YF.MWS.Util.Utility.GetGuid();
                    }
                    else
                    {
                        card.Id = cardId;
                    }
                }
                if (string.IsNullOrEmpty(card.CarId))
                    card.Id = YF.MWS.Util.Utility.GetGuid();
                if (teCarNo.Text.Length > 0)
                {
                    bool isExist = cardService.ExistCarNo(card.Id, teCarNo.Text);
                    if (isExist)
                    {
                        lblStateNote.Text= "此车牌号已经写过IC卡,不能重复写卡";
                        return isSaved;
                    }
                }
                card.MaterialId = currentMaterialId;
                card.CustomerId = currentCustomerId;
                card.CarNo = teCarNo.Text;
                card.CarId = currentCarId;
                if (string.IsNullOrEmpty(card.CarId))
                    card.CarId = GetCarId(card.CarNo);
                card.DeliveryId = currentDeliverId;
                card.ReceiverId = currentReceiverId;
                card.FinishState = FinishState.Unfinished.ToString();
                if (CurrentClient.Instance != null)
                {
                    card.MachineCode = CurrentClient.Instance.MachineCode;
                }
                if (string.IsNullOrWhiteSpace(card.Remark))
                {
                    if (isVirtualCard)
                    {
                        card.Remark = "自助写卡,此虚拟卡的编号由程序自动生成";
                    }
                    else
                    {
                        card.Remark = "自助写卡,卡编号由IC卡序列号生成";
                    }
                }
                isSaved = cardService.Save(card);
                cardService.SavePreset(card.Id, null);
                CardCacher.Refresh();
                hasReadCard = false;
                SetButton(true);
                Clear();
                lblStateNote.Text = "成功保存IC卡信息.";
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                lblStateNote.Text ="保存IC卡信息时发生未知错误,请重试.";
            }
            finally
            {
                hasReadCard = false;
            }
            return isSaved;
        }

        private void btnFinishInput_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnStartInput_Click(object sender, EventArgs e)
        {
            if (speech != null) 
            {
                string message = "请将卡片放到读卡器旁然后填写相关信息";
                speech.Speak(message);
            }
            Clear();
            Thread.Sleep(500);
            hasReadCard = false;
            btnFinishInput.Enabled = true;
            btnStartInput.Enabled = false;
        }
    }
}