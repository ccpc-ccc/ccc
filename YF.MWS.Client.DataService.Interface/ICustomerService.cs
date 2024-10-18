using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Client.DataService.Interface
{
    public interface ICustomerService
    {
        SCustomer AddCustomer(CustomerType type, string customerName);
        bool Delete(string priceId);
        bool DeleteCustomer(string customerId);
        bool DeleteCustomerPhysics(string customerId);
        SCustomerPrice Get(string priceId);
        SCustomer GetCustomer(string Id);
        SCustomerPrice Get(string customerId, string materialId);
        SCustomer GetCustomerByName(CustomerType customerType, string customerName);
        List<SCustomer> GetAllCustomerList(string type);
        List<SCustomer> GetCustomerList();
        int GetRechargeCount(string customerId);
        int GetWeightCount(CustomerType type, string customerId);
        TPageResult GetList(PageQueryCondition qc);
        /// <summary>
        /// 刷新客户ID
        /// </summary>
        /// <param name="oldCustomerId"></param>
        /// <param name="newCustomerId"></param>
        void RefreshCustomerId(string oldCustomerId, string newCustomerId);
        bool Save(SCustomerPrice price);
        bool UpdateState(string customerId, RowState state);
        bool SaveCustomer(SCustomer customer);
    }
}
