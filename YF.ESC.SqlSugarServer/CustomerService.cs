using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SqlSugar;
using YF.MWS.Models;
using YF.MWS.SQlSugService.Interface;
using YF.MWS.BaseMetadata;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using System.Linq.Expressions;

namespace YF.MWS.SQlSugService {
    public class CustomerService : BaseService<S_Customer>, ICustomerService {
        public CustomerService(ConnectionStrings connection) : base(connection) {
        }
        public S_Customer GetByCode(QueryCustomer model) {
            return db.Queryable<S_Customer>().Where(li => li.CustomerCode == model.CustomerCode&&li.CustomerType==model.CustomerType&&li.CompanyId==model.CompanyId).First();
        }
        public S_Customer GetByName(QueryCustomer model) {
            return db.Queryable<S_Customer>().Where(li => li.CustomerName == model.CustomerName && li.CustomerType==model.CustomerType&&li.CompanyId==model.CompanyId).First();
        }
        public VPage<S_Customer> getPage(QueryCustomer query) {
            var list = db.Queryable<S_Customer>().Where(li => li.CustomerType == query.CustomerType && li.CompanyId == query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public bool save(S_Customer model) {
            Expression<Func<S_Customer, object>> ps = li => li.CustomerName;
            return base.save(model, ps);
        }
        /// <summary>
        /// 合并终端数据
        /// </summary>
        /// <param name="model"></param>
        public S_Customer clientToModel(QueryCustomer model) {
            S_Customer old = GetByName(model);
            if (old != null) return old;
            S_Customer s_Wareh = new S_Customer();
            while (s_Wareh != null) {
                model.CustomerCode = "C" + DateTime.Now.ToString("yyMMddHHmmssffff");
                s_Wareh = GetByCode(model);
            }
            model.Id = Guid.NewGuid().ToString("N");
            if (base.save(model, null)) return new S_Customer() { Id = model.Id, CustomerCode = model.CustomerCode,CustomerType=model.CustomerType, CustomerName = model.CustomerName };
            else return null;
        }
    }
}
