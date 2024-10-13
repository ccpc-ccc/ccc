using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebCustomerService
    {
        bool Delete(List<string> customerIds);
        bool DeletePhysics(string customerId);
        bool BatchDeletePhysics(BatchUpdate batchUpdate);
        List<DCustomer> GetList(string companyId);
        bool Save(SCustomer customer);
        bool UpdateState(CustomerUpdate update);
        bool UpdateSyncStateNew(BatchUpdate update);
    }
}
