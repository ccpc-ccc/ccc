
using SqlSugar;
using YF.MWS.Models;
using YF.MWS.BaseMetadata;
using Microsoft.AspNetCore.Identity;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using System.Reflection;
using YF.MWS.SQlSugService.Interface;
using YF.MWS.Metadata;
using System.IO.Pipes;

namespace YF.MWS.SQlSugService {
    public class ModuleService : BaseService<S_Module>, IModuleService {
        public ModuleService(ConnectionStrings connection) : base(connection) {
        }
        public VPage<S_Module> getPage(QueryModule query) {
            List<S_Module> models = new List<S_Module>();
            int total = 0;
            if (query.PageIndex != null && query.PageSize != null && query.PageSize > 0) {
                models = db.Queryable<S_Module>().ToPageList((int)query.PageIndex, (int)query.PageSize, ref total);
            } else {
                models = db.Queryable<S_Module>().ToList();
                total = models.Count;
            }
            return new VPage<S_Module>() { Items = models, Total = total };
        }
        public List<VModule> GetAll(string? parentId, string[]? perssion) {
            List<S_Module> modules0;
            if (perssion == null) {
                modules0 = db.Queryable<S_Module>().Where(li => (li.ParentId == parentId)).OrderBy("OrderNo").ToList();
            } else {
                modules0 = db.Queryable<S_Module>().Where(li => (li.ParentId == parentId && perssion.Contains(li.Permiss))).OrderBy("OrderNo").ToList();
            }
            List<VModule> vModules = new List<VModule>();
            foreach (S_Module module in modules0) {
                VModule vModule = module.convert<VModule>();
                if (vModule == null) continue;
                vModule.Children = GetAll(module.Id, perssion);
                vModules.Add(vModule);
            }
            return vModules;
        }
        public S_Module GetById(string id) {
            return db.Queryable<S_Module>().Where(li=>li.Id==id).Includes(t=>t.Parent).First();
        }
        public bool save(S_Module model) {
            if (model.Id == null || model.Id == "") {
                model.Id = Guid.NewGuid().ToString("N");
                return db.Insertable(model).IgnoreColumns(it=>it.Parent).ExecuteCommand() > 0;
            }
            return db.Updateable(model).Where(it => it.Id == model.Id).UpdateColumns(li => new {
                li.Icon,
                li.LinkUrl,
                li.Title,
                li.Permiss
            }).ExecuteCommand() > 0;
        }
        public bool delete(S_Module model) {
            List<S_Module> models=new List<S_Module>();
            models.Add(model);
            List<S_Module> s_Modules = getAll(model.Id, ref models);
            return db.Deleteable(s_Modules).ExecuteCommand()>0;
        }
        public List<S_Module> getAll(string parentId,ref List<S_Module> modules) {
            List<S_Module> s_Modules = db.Queryable<S_Module>().Where(it => it.ParentId == parentId).ToList();
            foreach (S_Module module in s_Modules) {
                modules.Add(module);
                return getAll(module.Id, ref modules);
            }
            return modules;
        }
        public S_Module GetByPermiss(string Permiss) {
            return db.Queryable<S_Module>().Where(li => li.Permiss == Permiss).Includes(t => t.Parent).First();
        }
        public string getAdminPermiss(string[] notIn) {
           var list = db.Queryable<S_Module>().Where(it => !notIn.Contains(it.Permiss)).Select(li => new { li.Permiss }).ToList();
            string admin = "";
            list.ForEach(it => admin+=","+it.Permiss);
            return admin.Substring(1);
        }
        public bool saveModel(S_Module module) {
            if (module.Id == null || module.Id == ""||module.OrderNo==null) {
             S_Module old= db.Queryable<S_Module>().Where(li=>li.ParentId==module.ParentId).OrderBy("OrderNo Desc").First();
            if (old!=null&&old.OrderNo != null) module.OrderNo = old.OrderNo + 1;
            else module.OrderNo = 1;
            }
            return base.save(module, null);
        }
    }
}
