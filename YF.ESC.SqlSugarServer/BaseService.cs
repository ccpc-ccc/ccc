using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Models;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService {
    public class BaseService<T> where T:BaseEntity, new() {
        protected ConnectionConfig config;
        protected SqlSugarClient db;
        public BaseService(ConnectionStrings connection) {
            config = new ConnectionConfig() {
                ConnectionString = connection.ConnectionString,
                IsAutoCloseConnection = connection.IsAutoCloseConnection,
                DbType = (SqlSugar.DbType)connection.DbType
            };
            db= new SqlSugarClient(config);
            db.Aop.OnLogExecuting = (sql, pars) => {
                Console.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sql));//断点打这里看sql语句...
            };
        }
         ~BaseService() {
            if (db != null) {
                db.Dispose(); } 
        }

        public bool Add(T entry) {
            int count = 0;
            using(db=new SqlSugarClient(config)) {
                count=db.Insertable(entry).ExecuteCommand();
            }
            return count>0;
        }

        public bool Delete(T entry) {
            int count = 0;
            using (db = new SqlSugarClient(config)) {
                count = db.Deleteable(entry).Where(li=>li.Id==entry.Id).ExecuteCommand();
            }
            return count > 0;
        }

        public bool Delete(string id) {
            int count = 0;
            T entry = new T();
            entry.Id = id;
            using (db = new SqlSugarClient(config)) {
                count = db.Deleteable(entry).Where(li => li.Id == id).ExecuteCommand();
            }
            return count > 0;
        }

        public T Get(string id) {
            T t = null;
            using (db = new SqlSugarClient(config)) {
                t= db.Queryable<T>().Where(li => li.Id == id).First();
            }
            return t;
        }

        public List<T> GetList() {
            List<T> t = null;
            using (db = new SqlSugarClient(config)) {
                t = db.Queryable<T>().ToList();
            }
            return t;
        }
        public bool save(T model, Expression<Func<T, object>> ps) {
            if (model.Id == null || model.Id == "") {
                model.Id = Guid.NewGuid().ToString("N");
                return db.Insertable(model).ExecuteCommand() > 0;
            }
            if (ps == null) {
            return db.Updateable(model).Where(it => it.Id == model.Id).ExecuteCommand() > 0;
            }
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns(ps).ExecuteCommand() > 0;
        }

        public bool Update(T entry) {
            int count = 0;
            using (db = new SqlSugarClient(config)) {
                count = db.Updateable(entry).Where(li => li.Id == entry.Id).ExecuteCommand();
            }
            return count > 0;
        }
        public VPage<T> ToPage(int? pageIndex,int? pageSize, ISugarQueryable<T> data) {
            VPage<T> page = new VPage<T>();
            int total = 0;
            if (pageIndex != null && pageSize != null && pageSize > 0) {
                page.Items = data.ToPageList((int)pageIndex, (int)pageSize, ref total);
                page.Total = total;
            } else {
                page.Items = data.ToList();
                page.Total = page.Items.Count;
            }
            return page;
        }
    }
}
