using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SqlSugar;
using YF.MWS.Models;
using YF.MWS.BaseMetadata;
using Microsoft.AspNetCore.Identity;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using System.Reflection;
using YF.MWS.SQlSugService.Interface;
using YF.MWS.Metadata;
using System.Security.Cryptography;

namespace YF.MWS.SQlSugService {
    public class CarService : BaseService<S_Car>, ICarService {
        public CarService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<S_Car> getPage(QueryCar query) {
            ISugarQueryable<S_Car> list =db.Queryable<S_Car>().Where(li => li.CompanyId == query.CompanyId);
            return base.ToPage(query.PageIndex, query.PageSize, list);
        }
        public S_Car GetById(string id) {
            return db.Queryable<S_Car>().Where(li=>li.Id==id).First();
        }
        public S_Car GetByNo(S_Car query) {
            return db.Queryable<S_Car>().Where(li => li.CarNo == query.CarNo&&li.CompanyId==query.CompanyId).First();
        }
        public bool save(S_Car model) {
            if (model.Id == null || model.Id == "") {
                model.Id = Guid.NewGuid().ToString("N");
                return db.Insertable(model).ExecuteCommand() > 0;
            }
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns().ExecuteCommand() > 0;
        }
        public bool delete(S_Car model) {
            return db.Deleteable(model).ExecuteCommand()>0;
        }
        public S_Car clientToModel(S_Car model) {
            S_Car car = GetByNo(model);
            if (car == null) {
                model.Id = Guid.NewGuid().ToString("N");
                save(model);
            }
            return model;
        }
    }
}
