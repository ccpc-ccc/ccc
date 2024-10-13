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

namespace YF.MWS.Win.Uc
{
    public partial class UcCardEdit : DevExpress.XtraEditors.XtraUserControl
    {
        private ICardService cardService = new CardService();
        private IMasterService masterService = new MasterService();
        private ICarService carService = new CarService();
        private ISeqNoService seqNoService = new SeqNoService();
        private IWebCardService webCardService = new WebCardService();
        private List<BCardPreset> lstPreset = new List<BCardPreset>();
        private int icdev;
        private int port;
        private CardIdGenerateMode generateMode;
        private ReadCardType cardType;
        private bool isOpen = false;
        private UHFReader18Util remoteCardReader = null;
        private bool hasReadCard = false;
        /// <summary>
        /// 线程同步锁
        /// </summary>
        private static object lockObj = new object();
        private string cardId = string.Empty;
        private bool isVirtualCard = false;
        private bool isNew = true;
        private bool startAppCardRead = false;
        /// <summary>
        /// 允许一车多张卡
        /// </summary>
        private bool allowOneCarMultipleCards = false;
        private SysCfg cfg;

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

        public UcCardEdit()
        {
            InitializeComponent();
        }

        private void UcCardEdit_Load(object sender, EventArgs e)
        {
            cfg = CfgUtil.GetCfg();
            if (cfg != null)
            {
                if (cfg.Weight != null)
                {
                    allowOneCarMultipleCards = cfg.Weight.AllowOneCarMultipleCards;
                }
            }
            BindData();
        }

        private void BindData()
        {
            List<LookupField> lstField = new List<LookupField>();
            lstField.Add(new LookupField() { FieldName = "MaterialName", Caption = "货物名称" });
            List<SMaterial> lstMaterial = MaterialCacher.GetMaterialList();
            SearchLookupUtil.BindData(lookupMaterialId, lstMaterial, "Id", "MaterialName", lstField);
            lookupMaterialId.Properties.NullText = string.Empty;
            weWareh.InitDataNew();
            weWarehBizType.InitDataNew();
        }

        public void SettingCard(int port, CardIdGenerateMode generateMode, ReadCardType cardType, bool startAppCardRead) 
        {
            this.port = port;
            this.generateMode = generateMode;
            this.cardType = cardType;
            this.startAppCardRead = startAppCardRead;
        }

        public bool OpenPort() 
        {
            string message = "成功打开串口.";
            if (cardType == ReadCardType.Remote)
            {
                WriteCardCfg writeCfg = null;
                if (cfg != null)
                {
                    writeCfg = cfg.WriteCard;
                }
                remoteCardReader = new UHFReader18Util(port+1);
                isOpen = remoteCardReader.OpenPort();
                if (isOpen) 
                {
                    bool isSuccess = remoteCardReader.SetReaderWorkMode(0, 16);
                    if (isSuccess && writeCfg!=null && writeCfg.ApplyParameter && writeCfg.PowerDbm > 0)
                    {
                        //设置读卡器功率
                        isSuccess = remoteCardReader.SetReaderPowerDbm(writeCfg.PowerDbm);
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
            MessageDxUtil.ShowWarning(message);
            return isOpen;
        }

        public void ClosePort() 
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
                        MessageDxUtil.ShowError("装载初始密码失败！");
                    }
                    //寻卡
                    st = RF35Util.rf_card(icdev, 0, snr);
                    //寻卡失败
                    if (st != 0)
                    {
                       MessageDxUtil.ShowError("寻卡失败！");
                    }
                    //验证卡数据块一密码
                    if (RF35Util.rf_authentication(icdev, 0, 0) != 0)
                    {
                        MessageDxUtil.ShowError("验证密码失败！");
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
                        MessageDxUtil.ShowError("写入卡数据失败！");
                    }
                    if (dataBuffer.Length > 16)
                    {
                        byteData = new byte[dataBuffer.Length - 16];
                        Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                        st = RF35Util.rf_write(icdev, 0 * 4 + 2, byteData);
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("写入卡数据失败！");
                        }
                    }
                    //验证卡数据块二密码
                    if (RF35Util.rf_authentication(icdev, 0, 1) != 0)
                    {
                        MessageDxUtil.ShowError("验证密码失败！");
                    }
                    //向第二个数据地址写入卡号
                    data = cardNo;
                    dataBuffer = Encoding.Default.GetBytes(data);
                    byteData = new byte[16];
                    Buffer.BlockCopy(dataBuffer, 0, byteData, 0, 16);
                    st = RF35Util.rf_write(icdev, 1 * 4 + 1, byteData);
                    if (st != 0)
                    {
                        MessageDxUtil.ShowError("写入卡数据失败！");
                    }
                    if (dataBuffer.Length > 16)
                    {
                        byteData = new byte[dataBuffer.Length - 16];
                        Buffer.BlockCopy(dataBuffer, 16, byteData, 0, dataBuffer.Length - 16);
                        st = RF35Util.rf_write(icdev, 1 * 4 + 2, byteData);
                        if (st != 0)
                        {
                            MessageDxUtil.ShowError("写入卡数据失败！");
                        }
                    }
                    //RF35Util.rf_halt(icdev);
                    //蜂鸣器响
                    RF35Util.rf_beep(icdev, 50);
                    //断开串口连接
                    RF35Util.rf_exit(icdev);
                    MessageDxUtil.ShowTips("写入卡数据成功！");
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
                        if (isSuccess)
                        {
                            MessageDxUtil.ShowTips("写入数据成功！");
                        }
                    }
                }
            }
        }

        public void LoadCard(string cardId)
        {
            this.cardId = cardId;
            LoadData(cardId);
        }

        private void LoadData(string cardId) 
        {
            QPlanCard card = cardService.Get(cardId);
            if (card != null)
            {
                isNew = false;
                FormHelper.BindControl<BPlanCard>(this, card);
                lookupCar.EditValue = card.CarNo;
                lookupCar.CurrentValue = card.CarId;
                lookupCustomer.CurrentValue = card.CustomerId;
                lookupCustomer.EditValue = card.CustomerName;
                lookupDeliveryId.CurrentValue = card.DeliveryId;
                lookupDeliveryId.EditValue = card.DeliveryName;
                lookupReceiverId.CurrentValue = card.ReceiverId;
                lookupReceiverId.EditValue = card.ReceiverName;
                weWarehBizType.CurrentValue = card.WarehBizType;
                weWareh.CurrentValue = card.WarehId;
                List<BCardPreset> presets=cardService.GetPresetList(cardId);
                if (presets != null && presets.Count > 0)
                    cardView.BindControl(presets);
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
                        if (!string.IsNullOrEmpty(cardId) && cardId.Length>0)
                        {
                            teCardId.Text = cardId;
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
                        ////设置读卡器工作模式
                        //bool isSuccess = remoteCardReader.SetReaderWorkMode(0, 16);
                        //if (isSuccess)
                        //{
                        //    //设置读卡器功率
                        //    isSuccess = remoteCardReader.SetReaderPowerDbm(10);
                        //    if (isSuccess)
                        //    {
                                
                        //    }
                        //}
                        cardId = remoteCardReader.GetTIDInventory();
                        if (!string.IsNullOrEmpty(cardId))
                        {
                            teCardId.Text = cardId;
                            LoadData(cardId);
                            hasReadCard = true;
                        }
                    }
                }
            }
        }

        private void timerReadCard_Tick(object sender, EventArgs e)
        {
            ReadCard();
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            if (isVirtualCard && isNew) 
            {
                teCardId.Text = YF.MWS.Util.Utility.GetGuid();
            }
            if (generateMode == CardIdGenerateMode.CardSN)
            {
                if (teCardId.Text.Length == 0)
                {
                    string message = "请先刷近距离卡.";
                    if (cardType == ReadCardType.Remote)
                        message = "请先刷远距离卡.";
                    MessageDxUtil.ShowWarning(message);
                    isValidated = false;
                }
            }
            return isValidated;
        }

        public bool Save() 
        {
            bool isSaved = false;
            try
            {
                bool isValidated = ValidateForm();
                if (!isValidated)
                {
                    hasReadCard = false;
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
                    if (teCardNo.Text.Length == 0)
                    {
                        teCardNo.Text = seqNoService.GetSeqNo(SeqCode.Card.ToString());
                    }
                    card.PlanNo = seqNoService.GetSeqNo(SeqCode.Plan.ToString());
                    card.RowState = (int)RowState.Add;
                }
                else
                {
                    card.RowState = (int)RowState.Edit;
                }
                FormHelper.ControlToEntity(this, ref card);
                if (!isNewCard)
                {
                    card.CardNo = teCardNo.Text;
                }
                if (isNewCard)
                {
                    if (isVirtualCard)
                    {
                        card.Id = teCardId.Text;
                    }
                    else
                    {
                        card.Id = teCardId.Text;
                    }
                }
                if (lookupCar.Text.Length > 0 && !allowOneCarMultipleCards)
                {
                    bool isExist = cardService.ExistCarNo(card.Id, lookupCar.Text);
                    if (isExist)
                    {
                        lookupCar.ErrorText = "此车牌号已经写过IC卡,不能重复写卡";
                        hasReadCard = false;
                        return isSaved;
                    }
                }
                lookupCar.SetCarNo(teTareWeight.Text.ToDecimal(),teDriverName.Text);
                card.CustomerId = lookupCustomer.CurrentValue.ToObjectString();
                card.CarId = lookupCar.CurrentValue.ToObjectString();
                card.CarNo = lookupCar.Text;
                card.DeliveryId = lookupDeliveryId.CurrentValue.ToObjectString();
                card.ReceiverId = lookupReceiverId.CurrentValue.ToObjectString();
                card.FinishState = FinishState.Unfinished.ToString();
                card.WarehId = weWareh.CurrentValue.ToObjectString();
                card.WarehBizType = DxHelper.GetCode(weWarehBizType);
                if (CurrentClient.Instance != null)
                {
                    card.MachineCode = CurrentClient.Instance.MachineCode;
                }
                if (string.IsNullOrWhiteSpace(card.Remark))
                {
                    if (isVirtualCard)
                    {
                        card.Remark = "此虚拟卡的编号由程序自动生成";
                    }
                    else
                    {
                        card.Remark = "卡编号由IC卡序列号生成";
                    }
                }
                isSaved=cardService.Save(card);
                List<BCardPreset> lstPresetNew = cardView.ControlToList(card.Id);
                cardService.SavePreset(card.Id, lstPresetNew);
                CardCacher.Refresh();
                hasReadCard = false;
                Clear();
                MessageDxUtil.ShowTips("成功保存IC卡信息.");
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                MessageDxUtil.ShowError("保存IC卡信息时发生未知错误,请重试.");
            }
            finally 
            {
                hasReadCard = false;
            }
            return isSaved;
        }

        public void Clear() 
        {
            teCardId.Text = string.Empty;
            lookupCar.Clear();
            lookupMaterialId.EditValue = null;
            teDriverName.Text = string.Empty;
            teRemark.Text = string.Empty;
            lookupCustomer.Clear();
            lookupDeliveryId.Clear();
            lookupReceiverId.Clear();
            teCardNo.Text = string.Empty;
            cardId = string.Empty;
            cardView.Clear();
        }
    }
}
