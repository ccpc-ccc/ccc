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

        public static void AutoSaveCustomer(IMasterService masterService, ISeqNoService seqNoService, MainWeight mainWeight)
        {
            WCustomerEdit weCustomer = mainWeight.FindControl<WCustomerEdit>("CustomerId");
            WTextEdit customerAddress = mainWeight.FindControl<WTextEdit>("CustomerAddress");
            WTextEdit customerIdCard = mainWeight.FindControl<WTextEdit>("CustomerIdCard");
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

        public static void LoadCustomer(string customerId, CustomerType type, IMasterService masterService, MainWeight mainWeight)
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
                            WTextEdit customerCode = mainWeight.FindControl<WTextEdit>("CustomerCode");
                            if (customerCode != null)
                            {
                                customerCode.CurrentValue = customer.CustomerCode;
                            }
                            WTextEdit customerAddress = mainWeight.FindControl<WTextEdit>("CustomerAddress");
                            if (customerAddress != null)
                            {
                                customerAddress.CurrentValue = customer.Addr;
                            }
                            WTextEdit customerIdCard = mainWeight.FindControl<WTextEdit>("CustomerIdCard");
                            if (customerIdCard != null)
                            {
                                customerIdCard.CurrentValue = customer.IdCard;
                            }
                            WTextEdit customerAccount = mainWeight.FindControl<WTextEdit>("CustomerAccount");
                            if (customerAccount != null)
                            {
                                customerAccount.CurrentValue = customer.Account;
                            }
                            WTextEdit customerTel = mainWeight.FindControl<WTextEdit>("CustomerTel");
                            if (customerTel != null)
                            {
                                customerTel.CurrentValue = customer.Tel;
                            }
                            WTextEdit customerContacter = mainWeight.FindControl<WTextEdit>("CustomerContacter");
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
                            WTextEdit customerTel = mainWeight.FindControl<WTextEdit>("shouliangdianhua");
                            if (customerTel != null)
                            {
                                customerTel.CurrentValue = customer.Tel;
                            }
                            WTextEdit customerIdCard = mainWeight.FindControl<WTextEdit>("shenfen");
                            if (customerIdCard != null)
                            {
                                customerIdCard.CurrentValue = customer.IdCard;
                            }
                            WTextEdit customerBank = mainWeight.FindControl<WTextEdit>("kaihuhag");
                            if (customerBank != null)
                            {
                                customerBank.CurrentValue = customer.Bank;
                            }
                            WTextEdit customerAccount = mainWeight.FindControl<WTextEdit>("yinghangzhanghao");
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
