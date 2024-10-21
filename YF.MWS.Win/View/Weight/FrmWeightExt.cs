using DevExpress.XtraBars;
using DevExpress.XtraGauges.Win.Gauges.State;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Db;
using YF.MWS.Db.Server;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.MWS.Win.Util;
using YF.MWS.Win.View.Report;
using YF.Utility;
using YF.Utility.AI;
using YF.Utility.Data;
using YF.Utility.Language;
using YF.Utility.Log;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmWeight
    {
        private int maxLogLength = 5000;
        private bool firstInitedUnitPrice = true;
        /// <summary>
        /// 驻留的单价
        /// </summary>
        private decimal residentUnitPrice = 0;


        private void AutoInvalidWeight() 
        {
            DateTime startTime = DateTime.Now.AddHours(0 - unfinishedTimeOut);
            List<BWeight> weights = weightService.GetUnFinishedList(startTime);
            if (weights != null && weights.Count>0) 
            {
                string desc = string.Empty;
                string weightNo = string.Empty;
                string weightId = string.Empty;
                foreach (BWeight weight in weights)
                {
                    weightNo = weight.WeightNo;
                    weightId = weight.Id;
                    desc = string.Format("系统自动作废磅单号:{0}", weightNo);
                    logService.Add(LogActionType.Weight, weightId, weightNo, desc);
                    weightService.UpdateWeight(weight.Id, RowState.Delete);
                    webWeightService.UpdateState(weight.Id, RowState.Delete);
                }
            }
        }

        private void AutoPrint(BWeight weight) 
        {
            try
            {
                if (weight == null)
                    return;
                Task.Factory.StartNew(new Action(() =>
                {
                    bool canPrint = CanPrint(weight);
                    if (canPrint)
                    {
                        if (weight.FinishState == (int)FinishState.Finished)
                        {
                            ShowWeightStateTip(string.Format("正在自动打印磅单({0})", weight.WeightNo));
                            weightService.UpdatePrint(weight.Id);
                                PrintUtil.PrintWeightReport(currentViewId, weight.Id, DocumentType.Weight, reportService, null, weightPrinterName);
                            if (appendPrintTemp)
                            {
                                PrintUtil.PrintWeightReport(currentViewId, weight.Id, DocumentType.TemporaryWeight, reportService, null, weightTempPrinterName);
                            }
                        }
                    }
                }));
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        private void AutoPrint(string weightId, DocumentType type) 
        {
            PrintUtil.PrintWeightReport(currentViewId, weightId, type, reportService, null);
        }

        /// <summary>
        /// 是否可以进入自动重置处理流程
        /// </summary>
        /// <returns></returns>
        private bool CanEnterReset() 
        {
            bool isCanRest = false;
            decimal weight = GetCurrentWeight();
            if (weight < minCredibleWeight && startAutoReset) 
            {
                TimeSpan ts = DateTime.Now.Subtract(lastWeightStartTime);
                if (ts.TotalMinutes > (double)idleMinutes) 
                {
                    isCanRest = true;
                }
            }
            return isCanRest;
        }

        public bool CanPrint(BWeight weight) 
        {
            bool canPrint = true;
            if (startPrintCountLimit && weight != null && weight.PrintCount >= maxPrintCount)
            {
                canPrint = false;
                ShowWeightStateTip("此磅单超过打印限制次数不能再次打印");
            }
            return canPrint;
        }

        public FinishState GetFinishState() 
        {
            FinishState state = FinishState.Unfinished;
            decimal grossWeight = 0;
            decimal tareWeight = 0;
            if (weGrossWeight != null) 
            {
                grossWeight = weGrossWeight.Text.ToDecimal();
            }
            if (weTareWeight != null) 
            {
                tareWeight = weTareWeight.Text.ToDecimal();
            }
            if (currentWeightProcess == WeightProcess.Two)
            {
                if (tareWeight > 0 && grossWeight > 0)
                {
                    state = FinishState.Finished;
                }
            }
            if (currentWeightProcess == WeightProcess.One)
            {
                if (grossWeight > 0)
                {
                    state = FinishState.Finished;
                }
            }
            return state;
        }

        public WeightCapture GetWeightCapture(string weightId,decimal weight=0) 
        {
            WeightCapture wc = new WeightCapture();
            wc.WeightId = weightId;
            wc.State = GetFinishState();
            StringBuilder sb = new StringBuilder();
            if (wlookCar != null) 
            {
                if (wlookCar.Text.Length > 0) 
                {
                    sb.AppendFormat("车牌:{0} ", wlookCar.Text);
                }
            }
            if (weight <= 0)
            {
                weight = GetCurrentWeight();
            }
            if (weight <= 0) 
            {
                if (weTareWeight != null) 
                {
                    weight = weTareWeight.Text.ToDecimal();
                }
            }
            if (weight <= 0)
            {
                if (weGrossWeight != null)
                {
                    weight = weGrossWeight.Text.ToDecimal();
                }
            }
            if (weight > 0) 
            {
                sb.AppendFormat("重量:{0} {1} ", weight, lbLeftUnit.Text);
            }
            sb.AppendFormat("时间:{0}",DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            wc.WaterMarkText = sb.ToString();
            return wc;
        }

        private void InitCommandBar()
        {
            var lstTemplate = reportService.GetTemplateList(TemplateType.Document,DocumentType.Weight.ToString());
            var lstPrintBarItem = new List<BarButtonItem>();
            var lstViewBarItem = new List<BarButtonItem>();
            BarButtonItem printItem;
            BarButtonItem previewItem;
            int index = 8;
            foreach (var template in lstTemplate)
            {
                printItem = new BarButtonItem();
                printItem.Caption = template.TemplateName;
                printItem.Tag = template.Id;
                printItem.ImageIndex = index;
                printItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                printItem.ItemClick += Print_ItemClick;
                lstPrintBarItem.Add(printItem);

                previewItem = new BarButtonItem();
                previewItem.Caption = template.TemplateName;
                previewItem.Tag = template.Id;
                previewItem.ImageIndex = index;
                previewItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                previewItem.ItemClick += Preview_ItemClick;
                lstViewBarItem.Add(previewItem);
            }

            lstTemplate = reportService.GetTemplateList(TemplateType.Report, SummaryReportType.Weight.ToString());
            var lstBarItem = new List<BarButtonItem>();
            BarButtonItem item;
            foreach (var template in lstTemplate)
            {
                item = new BarButtonItem();
                item.Caption = template.TemplateName;
                item.Tag = template.Id;
                item.ItemClick += item_ItemClick;
                lstBarItem.Add(item);
            }
        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                PrintAmountReport(e.Item.Tag.ToObjectString());
            }
        }

        private WeightQueryCondition GetCondition(WeightSubReportType subType)
        {
            WeightQueryCondition qc = new WeightQueryCondition();
            qc.Columns = viewService.GetShow2DetailList(ViewType.Weight);

            DateTime now = DateTime.Now;
            DateTime startTime = now;
            DateTime endTime = now;
            qc.DateSummary = DateSummaryType.Day;
            if (subType == WeightSubReportType.WeightMonth) 
            {
                startTime = DateUtil.FirstDayOfMonth(now.Year, now.Month);
                endTime = DateUtil.LastDayOfMonth(now.Year, now.Month);
            }
            qc.StartTime = startTime;
            qc.EndTime = endTime;
            return qc;
        }

        private Hashtable GetParameter(WeightQueryCondition query)
        {
            Hashtable hash = new Hashtable();
            DateTime now=DateTime.Now;
            hash.Add("开始时间", query.StartTime.HasValue ? query.StartTime.Value : now);
            hash.Add("结束时间", query.EndTime.HasValue ? query.EndTime.Value : now);
            hash.Add("报表日期", DateTime.Now);
            return hash;
        }

        private void PrintAmountReport(string templateId)
        {
            SReportTemplate template = reportService.Get(templateId);
            WeightSubReportType subType = template.SubReportType.ToEnum<WeightSubReportType>();
            DataSet dsReport = new DataSet();
            WeightQueryCondition query=GetCondition(subType);
            dsReport = reportService.GetWeightSearch(CurrentClient.Instance.ViewId, query);
            if (template != null && !string.IsNullOrEmpty(template.SubReportType))
            {
                if (subType != WeightSubReportType.Weight && subType != WeightSubReportType.WeightDay && subType != WeightSubReportType.WeightMonth)
                {
                    dsReport.Tables.Clear();
                    DataTable dt = statementSerivice.GetWeightDataSource(subType, query);
                    if (dt != null)
                    {
                        dsReport.Tables.Add(dt);
                    }
                }
            }
            FrmXReport frmReport = new FrmXReport();
            string reportPath = Application.StartupPath + "\\Report\\Weight\\rptWeightSummary.repx";
            if (template != null)
            {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    reportPath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                }
                else
                {
                    reportPath = Utility.GetReportTemplate(template);
                }
            }
            frmReport.Parameters = GetParameter(query);
            frmReport.ReportFilePath = reportPath;
            if (dsReport != null && dsReport.Tables.Count > 0)
            {
                frmReport.DataMember = dsReport.Tables[0].TableName;
            }
            frmReport.DataSource = dsReport;
            frmReport.DisplayName = "磅单统计报表";
            frmReport.Text = "磅单统计报表";
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.StartPosition = FormStartPosition.CenterScreen;
            frmReport.ShowDialog();
        } 

        void Preview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null)
                return;
            if (string.IsNullOrEmpty(searchList.CurrentWeightId))
            {
                MessageDxUtil.ShowWarning("请选择要预览的磅单");
            }
            else
            {
                DataSet dsReport = new DataSet();
                SReportTemplate template = reportService.Get(e.Item.Tag.ToObjectString());
                dsReport = reportService.GetWeight(searchList.CurrentViewId, searchList.CurrentWeightId);
                FrmXWeight frmReport = new FrmXWeight();
                if (template != null)
                {
                    if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                    {
                        if (!string.IsNullOrEmpty(template.TemplateUrl))
                        {
                            frmReport.ReportFilePath = Path.Combine(Application.StartupPath, template.TemplateUrl);
                        }
                    }
                    else
                    {
                        SReportTemplate templateFind = reportService.Get(template.Id);
                        frmReport.ReportFilePath = Utility.GetReportTemplate(templateFind);
                    }
                }
                else
                {
                    frmReport.ReportFilePath = Application.StartupPath + "\\Report\\Weight\\rptDefault.repx";
                }
                frmReport.DataSource = dsReport;
                frmReport.DisplayName = "磅单报表";
                frmReport.Text = "磅单报表";
                frmReport.WindowState = FormWindowState.Maximized;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.ShowDialog();
            }
        }

        void Print_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                string weightId = searchList.CurrentWeightId;
                if (string.IsNullOrEmpty(weightId)) 
                {
                    MessageDxUtil.ShowWarning("请选择要打印的磅单");
                    return;
                }
                BWeight weight = weightService.Get(weightId);
                bool canPrint = CanPrint(weight);
                if (canPrint)
                {
                    string weightPrinterName = null;
                    if (Cfg != null && Cfg.Print != null)
                    {
                        weightPrinterName = Cfg.Print.WeightPrinterName;
                    }
                    weightService.UpdatePrint(weightId);
                    PrintUtil.PrintWeightReportWithTemplate(searchList.CurrentViewId, weightId, e.Item.Tag.ToObjectString(), reportService, weightPrinterName);
                }
            }
        }

        /// <summary>
        /// 是否处于自动简单称重模式
        /// </summary>
        /// <returns></returns>
        private bool IsSimpleAuto() 
        {
            bool isSimple = false;
            if (currentWeighWay == WeightWay.Nobody && weightProcessTrigger == WeightProcessTriggerType.WeightStable)
            {
                isSimple = true;
            }
            return isSimple;
        }

        private string GetCarNo(string carNo) 
        {
            carNo = carNo.Trim().Replace(" ","");
            string outCarNo = carNo;
            if (!string.IsNullOrEmpty(carNo))
            {
                switch (carNoOutMode) 
                {
                    case CarNoOutMode.Whole:
                        outCarNo= carNo;
                        break;
                    case CarNoOutMode.LeftPartial:
                        outCarNo= StringUtils.SubString(carNo, carNoOutLength);
                        break;
                    case CarNoOutMode.RightPartial:
                        outCarNo = StringUtils.SubStringFromRight(carNo, carNoOutLength);
                        break;
                }
            }
            if (startCarRecAdjust) 
            {
                List<string> carNos = null;
                List<SCar> cars = carService.GetList();
                if (cars != null && cars.Count > 0) 
                {
                    carNos = cars.Select(c => c.CarNo).ToList();
                    outCarNo = CarUtil.Find(carNos, outCarNo);
                }
            }
            return outCarNo;
        }

        private bool ValidateAutoSimpleForm() 
        {
            bool isValidated = false;
            decimal tareWeight = 0;
            decimal grossWeight = 0;
            if (weTareWeight != null)
            {
                tareWeight = weTareWeight.Text.ToDecimal();
            }
            if (weGrossWeight != null)
            {
                grossWeight = weGrossWeight.Text.ToDecimal();
            }
            if (tareWeight > 0 || grossWeight > 0) 
            {
                isValidated = true;
            }
            if (!returnZero && isValidated) 
            {
                isValidated = false;
            }
            return isValidated;
        }

        private bool ValidateForm()
        {
            bool isValidated = true;
            decimal tareWeight = 0;
            decimal grossWeight = 0;
            decimal suttleWeight = 0;
            if (weSuttleWeight != null)
                suttleWeight = weSuttleWeight.Text.ToDecimal();
            if (weTareWeight != null)
            {
                tareWeight = weTareWeight.Text.ToDecimal();
            }
            if (weGrossWeight != null)
            {
                grossWeight = weGrossWeight.Text.ToDecimal();
            }
            if (IsSimpleAuto())
            {
                return ValidateAutoSimpleForm();
            }
            /*if (currentWeightProcess == WeightProcess.One)
            {
                if (tareWeight <= 0)
                {
                    isValidated = false;
                    if (showValidateMessage)
                    {
                        MessageDxUtil.ShowWarning("皮重数据必须大于0.");
                    }
                    ShowWeightStateTip("皮重数据必须大于0");
                    return isValidated;
                }
                if (grossWeight <= 0)
                {
                    isValidated = false;
                    if (showValidateMessage)
                    {
                        MessageDxUtil.ShowWarning("毛重数据必须大于0.");
                    }
                    ShowWeightStateTip("毛重数据必须大于0");
                    return isValidated;
                }
                if (tareWeight > grossWeight)
                {
                    isValidated = false;
                    if (showValidateMessage)
                    {
                        MessageDxUtil.ShowWarning("毛重不能小于皮重,请重新称称重.");
                    }
                    ShowWeightStateTip("毛重不能小于皮重,请重新称称重");
                    return isValidated;
                }
            }*/
            if (currentWeightProcess == WeightProcess.Two)
            {
                if (tareWeight <= 0 && grossWeight <= 0)
                {
                    isValidated = false;
                    if (showValidateMessage)
                    {
                        MessageDxUtil.ShowWarning("请至少称量一种重量数据.");
                    }
                    ShowWeightStateTip("请至少称量一种重量数据");
                    return isValidated;
                }
                if (tareWeight > 0 && grossWeight > 0)
                {
                    if (tareWeight > grossWeight)
                    {
                        isValidated = false;
                        if (showValidateMessage)
                        {
                            MessageDxUtil.ShowWarning("毛重不能小于皮重,请重新称重.");
                        }
                        ShowWeightStateTip("毛重不能小于皮重,请重新称重");
                        return isValidated;
                    }
                }
            }
            bool isOverWeight = IsOverWeight();
            if (isOverWeight)
            {
                isValidated = false;
                if (showValidateMessage)
                {
                    MessageDxUtil.ShowWarning("毛重已经超载,请重新称重.");
                }
                ShowWeightStateTip("毛重已经超载,请重新称重");
                return isValidated;
            }
            if (!ValidateInfrared())
            {
                isValidated = false;
                return isValidated;
            }
            if (weUnitPrice != null && weUnitPrice.IsRequired) 
            {
                decimal unitPrice = weUnitPrice.Text.ToDecimal();
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.NewWeight)
                {
                    if (unitPrice <= 0 && currentWeight == null)
                    {
                        isValidated = false;
                        if (showValidateMessage)
                        {
                            MessageDxUtil.ShowWarning("请输入收费单价.");
                        }
                        ShowWeightStateTip("请输入收费单价");
                        return isValidated;
                    }
                }
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.FinishWeight)
                {
                    if (unitPrice <= 0 && currentWeight != null)
                    {
                        isValidated = false;
                        if (showValidateMessage)
                        {
                            MessageDxUtil.ShowWarning("请输入收费单价.");
                        }
                        ShowWeightStateTip("请输入收费单价");
                        return isValidated;
                    }
                }
            }
            if (startValidateCarWithCard)
            {
                if (wlookCar != null && currentCard != null && wlookCar.Text.Length > 0 
                    && !string.IsNullOrEmpty(currentCard.CarNo) && wlookCar.Text!=currentCard.CarNo) 
                {
                    isValidated = false;
                    ShowWeightStateTip("车卡不一致");
                    return isValidated;
                }
            }
            if (startCustomerBalanceLimit)
            {
                decimal amount = 0;
                string customerId = string.Empty;
                decimal balance = 0;
                decimal minBalance = 0;
                if (wlookupCustomer != null)
                {
                    customerId = wlookupCustomer.CurrentValue.ToObjectString();
                }
                if (weRegularCharge != null)
                {
                    amount = weRegularCharge.Text.ToDecimal();
                }
                SCustomer customer = masterService.GetCustomer(customerId);
                if (customer != null)
                {
                    minBalance = customer.MinBalanceAmount;
                    balance = customer.BalanceAmount; 
                }
                bool needValidate = false;
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.NewWeight && isNewWeight)
                {
                    needValidate = true;
                }
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.FinishWeight && grossWeight>0 && tareWeight>0)
                {
                    needValidate = true;
                }
                if (balance < amount+minBalance && needValidate)
                {
                    string message = "客户余额不足,确定要保存磅单吗?";
                    if (MessageDxUtil.ShowYesNoAndTips(message) != System.Windows.Forms.DialogResult.Yes) 
                    {
                        isValidated = false;
                        return isValidated;
                    }
                }
            }
            if (startPlan)
            {
                string customerId = string.Empty;
                string customerName = string.Empty;
                if (isNewWeight)
                {
                    if (currentPlan == null)
                    {
                        if (wlookupCustomer != null)
                        {
                            customerId = wlookupCustomer.CurrentValue.ToObjectString();
                            customerName = wlookupCustomer.Text;
                        }
                    }
                    currentPlan = planService.Get(customerId, PlanStateType.Going);
                    if (currentPlan == null)
                    {
                        isValidated = false;
                        ShowWeightStateTip(string.Format("({0})不存在计划单",customerName));
                    }
                    else
                    {
                        if (currentPlan.EndTime.HasValue && currentPlan.EndTime.Value < DateTime.Now)
                        {
                            isValidated = false;
                            ShowWeightStateTip(string.Format("({0})的计划单已过期",customerName));
                        }
                    }
                }
                else
                {
                    if(currentWeight!=null)
                        currentPlan = planService.Get(currentWeight.RefId);
                    if (currentPlan != null)
                    {
                        if (currentPlan.LimitType == PlanLimitType.Count)
                        {
                            if (currentPlan.SurplusCarCount <= 0)
                            {
                                isValidated = false;
                                ShowWeightStateTip(string.Format("({0})的计划单剩余次数不足", customerName));
                            }
                        }
                        if (currentPlan.LimitType == PlanLimitType.Weight)
                        {
                            suttleWeight = UnitUtil.GetValue(currentDeviceCfg.SUnit, "Ton", suttleWeight);
                            if (currentPlan.SurplusWeight- suttleWeight < 0)
                            {
                                isValidated = false;
                                ShowWeightStateTip(string.Format("({0})的计划单剩余吨位不足", customerName));
                            }
                        }
                    }
                }
            }
            return isValidated;
        }

        /// <summary>
        /// 重量是否稳定
        /// </summary>
        /// <returns></returns>
        private bool IsWeightStable()
        {
            bool isWeightStatble = false;
            int stableCount = 0;
            string selftUnit = "Kg";
            try
            {
                if (lstWeightValue == null || lstWeightValue.Count < samplingCount) 
                {
                    return isWeightStatble;
                }
                List<double> lstWeight = new List<double>();
                lstWeightValue.ForEach(c => lstWeight.Add(c));
                if (lstWeight != null && lstWeight.Count >= samplingCount)
                {
                    decimal dValue = 0;
                    int length = lstWeight.Count;
                    for (int i = 0; i < length; i++)
                    {
                        double firstWeight = lstWeight[0];
                        if (i != 0)
                        {
                            dValue = (decimal)(lstWeight[i] - firstWeight);
                        }
                        dValue = UnitUtil.GetValue(currentDeviceCfg.SUnit, selftUnit, (decimal)dValue);
                        if (Math.Abs(dValue) <= weightDeviation)
                        {
                            stableCount++;
                        }
                    }
                    if (stableCount == samplingCount)
                    {
                        currentStableWeight = GetCurrentWeight();
                        isWeightStatble = true;
                    }
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
            if(currentDeviceCfg==Cfg.Device1)
            ShowWeightStableState(isWeightStatble, stateWeightStable1);
            if (currentDeviceCfg == Cfg.Device2)
                ShowWeightStableState(isWeightStatble, stateWeightStable2);
            return isWeightStatble;
        }

        /// <summary>
        /// 检测红外对射是否被遮挡
        /// </summary>
        /// <returns></returns>
        private bool ValidateInfrared() 
        {
            bool isValidated = true;
            //decimal currentWeight = GetCurrentWeight();
            if (startInfrared && modbusLeft != null)
            {
                isValidated = !modbusLeft.ValidateInfrared();
                if (!isValidated)
                {
                    ShowWeightStateTip("车未完全上磅不能保存磅单");
                    if (currentWeighWay == WeightWay.People)
                    {
                        MessageDxUtil.ShowWarning("车未完全上磅不能保存磅单.");
                    }
                    checkCarCount++;
                        if (startVoice && speecher != null)
                        {
                            speecher.Speak(voiceCfg.CarStopFail);
                        }
                        isNoteCheckCar = true;
                }
            }
            return isValidated;
        }

        /// <summary>
        /// 自动保存重量
        /// </summary>
        private void AutoWeightSave() 
        {
            lock (autoSaveLockObj)
            {
                try
                {
                    ShowWeightStateTip("开始自动保存磅单");
                    int entranceNo = readerNo;
                    //无人职守模式
                    if (currentWeighWay == WeightWay.Nobody)
                    {
                        //转换重量数字为文字形式
                        DigitConvertUtil digitConverter = new DigitConvertUtil((double)currentStableWeight);
                        if (startVoice && voiceCfg.BroadcastWeight == BroadcastWeightType.SuttleWeight)
                        {
                            if (weSuttleWeight != null) 
                            {
                                digitConverter.Numeric = (double)weSuttleWeight.Text.ToDecimal();
                            }
                        }
                        string voice = string.Empty;
                        if (startVoice)
                        {
                            if (currentWeight == null)
                            {
                                voice = string.Format(voiceCfg.FirstWeight, digitConverter.ConvertToString());
                            }
                            else
                            {
                                voice = string.Format(voiceCfg.SecondWeight, digitConverter.ConvertToString());
                            }
                        }
                        //保存称重截图
                        AsyncCapturePhoto(GetWeightCapture(currentWeightId, currentStableWeight));
                        bool isSaved = Save();
                        if (startVoice && speecher != null && isSaved)
                        {
                            this.speecher.Speak(voice);
                        }
                        
                        if (isSaved)
                        {
                            //bool needWait = NeedWaitConfirmPay();
                           // if (!needWait) 
                                HandleGateAfterSave();
                            ShowWeightStateTip("等待地磅重量归零,下次过磅准备");
                            //启动车辆驶出地磅检测定时器
                            this.timerOut.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteException(ex);
                }
            }
        }

        private bool NeedWaitConfirmPay() 
        {
            bool needWait = false;
            if (startWeightPay) 
            {
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.NewWeight && isNewWeight)
                    needWait = true;
                if (currentChargeTriggerCondtion == ChargeTriggerCondtionType.FinishWeight && !isNewWeight)
                    needWait = true;
            }
            return needWait;
        }

        private void HandleGateAfterSave() 
        {
            string message = string.Empty;
            bool isNeedOpen = IsNeedOpenGateWhenSaved();
            if (isNeedOpen)
            {
                //从1#读卡器或车牌识别仪驶入
                if (readerNo == 1)
                {
                    if (startBoundGate)
                    {
                        //落下1#道闸
                        CloseServerGate(1);
                        //开启2#道闸
                        OpenServerGate(2);
                        message = "落下1#道闸,开启2#道闸";
                    }
                }
                else
                {
                    if (startBoundGate)
                    {
                        //落下2#道闸
                        CloseServerGate(2);
                        //开启1#道闸
                        OpenServerGate(1);
                        message = "落下2#道闸,开启1#道闸";
                    }
                }
            }
            Logger.Write("磅单保存后起砸情况:" + message);
        }

        private bool ReadeShortCardSN(int icdev, ref string cardId) 
        {
            bool isSuccess = false;
            cardId = string.Empty;
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
                    return isSuccess;
                }
                cardId = RF35Util.GetCardId(snr);
                if (!string.IsNullOrEmpty(cardId) && cardId.Length>0) 
                {
                    isSuccess = true;
                }
                Logger.Info("CardId:" + cardId);
                RF35Util.rf_halt(icdev);
                //蜂鸣器响
                RF35Util.rf_beep(icdev, 50);
            }
            return isSuccess;
        }

        private bool ReadRemoteCardSN(UHFReader18Util remoteReader, ref string cardId) 
        {
            bool isSuccess = false;
            if (remoteReader != null)
            {
                cardId = remoteReader.GetTIDInventory();
                if (!string.IsNullOrEmpty(cardId))
                {
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        public void ShowWeightStateTip(string tip) 
        {
            Logger.Write(tip);
            tip = string.Format("{0}_{1}", DateTime.Now.ToString("HH:mm:ss"), tip);
            try
            {
                if (memLog.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        memLog.Text += tip + "\r\n";
                        memLog.SelectionStart = memLog.Text.Length;
                        memLog.ScrollToCaret();
                    }));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

        public void LoadCar()
        {
            if (wlookCar != null)
                wlookCar.LoadCar();
        }

        public void LoadCustomer(CustomerType customerType)
        {
            if (customerType == CustomerType.Customer)
            {
                if (wlookupCustomer != null)
                    wlookupCustomer.LoadCustomer();
            }
            if (customerType == CustomerType.Delivery)
            {
                if (weDeliver != null)
                    weDeliver.LoadCustomer();
            }
            if (customerType == CustomerType.Receiver)
            {
                if (wlookupReceiver != null)
                    wlookupReceiver.LoadCustomer();
            }
            if (customerType == CustomerType.Supplier)
            {
                if (wlookupSupplier != null)
                    wlookupSupplier.LoadCustomer();
            }
            if (customerType == CustomerType.Transfer)
            {
                if (wlookupTransfer != null)
                    wlookupTransfer.LoadCustomer();
            }
        }

        public void LoadMaterial()
        {
            if (weMaterial != null)
                weMaterial.LoadMaterial();
        }

        private void RefreshWeightControl() 
        {
            if (!startInputItemAutoSave)
                return;
            if (weDriverName != null) 
            {
                weDriverName.InitData();
            }
        }

        private void SaveCarWithTareWeight(BWeight weight) 
        {
            if (weight.SuttleWeight > 0 && weight.TareWeight>0 && weight.FinishState == (int)FinishState.Finished && !string.IsNullOrEmpty(weight.CarNo))
            {
                SCar car = carService.GetByCarNo(weight.CarNo);
                if (car == null)
                {
                    car = new SCar();
                    car.Id = YF.MWS.Util.Utility.GetGuid();
                    car.CarNo = weight.CarNo;
                    car.CarType = "A1";
                    car.TareWeight = UnitUtil.GetValue(currentDeviceCfg.SUnit, "Ton", weight.TareWeight);
                    carService.Save(car);
                    CarCacher.Remove();
                }
                else 
                {
                    if (car.TareWeight == 0) 
                    {
                        car.TareWeight = UnitUtil.GetValue(currentDeviceCfg.SUnit, "Ton", weight.TareWeight);
                        carService.Save(car);
                    }
                }
            }
        }

        private void SaveWeightInputItem() 
        {
            mainWeight.SaveInputItem();
            if (wlookupCustomer != null && !wlookupCustomer.StartAutoSave)
                CustomerUtil.AutoSaveCustomer(masterService, seqNoService, mainWeight);
        }

        #region 设备状态显示灯

        private void ShowControlBoxState(bool isOpen) 
        {
            //this.BeginInvoke(new Action(() => 
            //{
            //    if (isOpen)
            //        stateControlBox.StateIndex = 2;
            //    else
            //        stateControlBox.StateIndex = 1;
            //}));
        }

        /// <summary>
        /// 改变仪表稳定灯显示状态
        /// </summary>
        /// <param name="isOpen"></param>
        private void ShowWeightStableState(bool isOpen, StateIndicatorComponent stateWeightStable)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (isOpen)
                    stateWeightStable.StateIndex = 2;
                else
                    stateWeightStable.StateIndex = 1;
            }));
        }

        private void ShowDeviceState(bool isOpen)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (isOpen)
                    stateLight1.StateIndex = 2;
                else
                    stateLight1.StateIndex = 1;
            }));
        }

        #endregion

        private bool CanCarOut() 
        {
            bool canOut = false;
            decimal weight = GetCurrentWeight();
            if (startOnlinePay)
            {
                canOut = (weight <= outWeightValue) && paySuccess;
            }
            else 
            {
                canOut = weight <= outWeightValue;
            }
            //Logger.Write(string.Format("CanCarOut-StartOnLinePay:{0}-PaySuccess:{1}-CanOut:{2}",startOnlinePay,paySuccess,canOut));
            return canOut;
        }

        private void PreparePay(BPay pay) 
        {
            paySuccess = false;
            PayJumpPageModel model = payService.PreparePay(pay);
            if (model != null)
            {
                string requestUrl = model.RequestUrl;
                FrmPay frmPay = new FrmPay();
                frmPay.RequestUrl = requestUrl;
                frmPay.WeightId = pay.RefId;
                if (frmPay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pay.PayBizType = PayBizType.Recharge.ToString();
                    pay.Id = YF.MWS.Util.Utility.GetGuid();
                    pay.PayNo = seqNoService.GetSeqNo(SeqCode.Recharge.ToString());
                    payService.AddPay(pay);
                    paySuccess = true;
                    HandleGateAfterSave();
                }
            }
            else 
            {
                ShowWeightStateTip("在线支付发生异常,请联系软件供应商.");
            }
        }

        /// <summary>
        /// 是否进入保存磅单流程
        /// </summary>
        /// <returns></returns>
        private bool StartWeightWeightTimer()
        {
            bool isStart = false;
            if (currentWeighWay == WeightWay.Nobody)
            {
                switch (weightProcessTrigger)
                {
                    case WeightProcessTriggerType.CarRecognition:
                        isStart = hasGetCarNo;
                        break;
                    case WeightProcessTriggerType.Card:
                        isStart = hasReadCard;
                        break;
                    case WeightProcessTriggerType.CarRecognitionCard:
                        isStart = hasReadCard && hasGetCarNo;
                        break;
                    case WeightProcessTriggerType.CarRecognitionOrCard:
                        isStart = hasReadCard || hasGetCarNo;
                        break;
                    case WeightProcessTriggerType.WeightStable:
                        isStart = true;
                        break;
                    case WeightProcessTriggerType.Pad:
                        isStart = finishPadInput;
                        break;
                    case WeightProcessTriggerType.IdCard:
                        isStart = hasGetIdCardNo;
                        break;
                }
            }
            else
            {
                isStart = true;
            }
            return isStart;
        }
    }
}
