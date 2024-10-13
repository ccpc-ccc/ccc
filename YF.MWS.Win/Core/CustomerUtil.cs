using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Uc.Weight;
using YF.Utility.Language;

namespace YF.MWS.Win.Core
{
    public class CustomerUtil
    {
        private static IMasterService masterService = new MasterService();

        public static void AutoSaveCustomer(IMasterService masterService, ISeqNoService seqNoService, MainWeight mainWeight, List<SAttribute> lstAttr)
        {
            WCustomerEdit weCustomer = mainWeight.FindControl<WCustomerEdit>("CustomerId");
            WTextEdit customerAddress = mainWeight.FindExtendControl<WTextEdit>("CustomerAddress", lstAttr);
            WTextEdit customerIdCard = mainWeight.FindExtendControl<WTextEdit>("CustomerIdCard", lstAttr);
            if (weCustomer != null && customerAddress != null && customerIdCard != null)
            {
                if (customerIdCard.Text.Trim().Length > 0 && weCustomer.Text.Trim().Length > 0)
                {
                    SCustomer customer = masterService.GetCustomerByIdCard(CustomerType.Customer, customerIdCard.Text.Trim());
                    if (customer == null)
                    {
                        customer = new SCustomer();
                        customer.CustomerType = CustomerType.Customer.ToString();
                        customer.CustomerName = weCustomer.Text.Trim();
                        customer.IdCard = customerIdCard.Text.Trim();
                        customer.Id = YF.MWS.Util.Utility.GetGuid();
                        customer.PYCustomerName = PinYinUtil.GetInitial(customer.CustomerName);
                        customer.CustomerCode = seqNoService.GetSeqNo(SeqCode.Customer.ToString());
                        customer.Addr = customerAddress.Text.Trim();
                        bool isSaved=masterService.SaveCustomer(customer);
                        if (!isSaved)
                            customer = null;
                    }
                    if (customer != null)
                    {
                        weCustomer.CurrentValue = customer.Id;
                    }
                }
            }
        }

        public static void LoadCustomer(string customerId, CustomerType type, IMasterService masterService, MainWeight mainWeight, List<SAttribute> lstAttr)
        {
            SCustomer customer = masterService.GetCustomer(customerId);
            if (customer != null && !string.IsNullOrEmpty(customer.Id))
            {
                switch (type)
                {
                    case CustomerType.Customer:
                        #region customer
                        {
                            WNumbericEdit customerBalance = mainWeight.FindControl<WNumbericEdit>("CustomerBalance");
                            if (customerBalance != null)
                            {
                                customerBalance.CurrentValue = customer.BalanceAmount.ToString();
                            }
                            WTextEdit customerCode = mainWeight.FindExtendControl<WTextEdit>("CustomerCode", lstAttr);
                            if (customerCode != null)
                            {
                                customerCode.CurrentValue = customer.CustomerCode;
                            }
                            WTextEdit customerAddress = mainWeight.FindExtendControl<WTextEdit>("CustomerAddress", lstAttr);
                            if (customerAddress != null)
                            {
                                customerAddress.CurrentValue = customer.Addr;
                            }
                            WTextEdit customerIdCard = mainWeight.FindExtendControl<WTextEdit>("CustomerIdCard", lstAttr);
                            if (customerIdCard != null)
                            {
                                customerIdCard.CurrentValue = customer.IdCard;
                            }
                            WTextEdit customerAccount = mainWeight.FindExtendControl<WTextEdit>("CustomerAccount", lstAttr);
                            if (customerAccount != null)
                            {
                                customerAccount.CurrentValue = customer.Account;
                            }
                            WTextEdit customerTel = mainWeight.FindExtendControl<WTextEdit>("CustomerTel", lstAttr);
                            if (customerTel != null)
                            {
                                customerTel.CurrentValue = customer.Tel;
                            }
                            WTextEdit customerContacter = mainWeight.FindExtendControl<WTextEdit>("CustomerContacter", lstAttr);
                            if (customerContacter != null)
                            {
                                customerContacter.CurrentValue = customer.Contracter;
                            }
                            WNumbericEdit wCustomerBalance = mainWeight.FindControl<WNumbericEdit>("CustomerBalance");
                            if (wCustomerBalance != null && customer.BalanceAmount < customer.MinBalanceAmount && customer.MinBalanceAmount > 0)
                            {
                                wCustomerBalance.ForeColor = Color.Red;
                            }
                        }
                        #endregion
                        break;
                    case CustomerType.Delivery:
                        #region deliver
                        {
                            WTextEdit customerTel = mainWeight.FindExtendControl<WTextEdit>("shouliangdianhua", lstAttr);
                            if (customerTel != null)
                            {
                                customerTel.CurrentValue = customer.Tel;
                            }
                            WTextEdit customerIdCard = mainWeight.FindExtendControl<WTextEdit>("shenfen", lstAttr);
                            if (customerIdCard != null)
                            {
                                customerIdCard.CurrentValue = customer.IdCard;
                            }
                            WTextEdit customerBank = mainWeight.FindExtendControl<WTextEdit>("kaihuhag", lstAttr);
                            if (customerBank != null)
                            {
                                customerBank.CurrentValue = customer.Bank;
                            }
                            WTextEdit customerAccount = mainWeight.FindExtendControl<WTextEdit>("yinghangzhanghao", lstAttr);
                            if (customerAccount != null)
                            {
                                customerAccount.CurrentValue = customer.Account;
                            }
                        }
                        #endregion
                        break;
                }
            }
        }
    }
}
