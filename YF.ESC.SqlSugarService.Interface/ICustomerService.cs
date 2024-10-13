using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService.Interface
{
    /// <summary>
    /// 用户信息管理接口
    /// </summary>
    public interface ICustomerService : IBaseService <S_Customer> {
        VPage<S_Customer> getPage(QueryCustomer query);
        S_Customer GetByCode(QueryCustomer query);
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        S_Customer clientToModel(QueryCustomer model);
    }
}
