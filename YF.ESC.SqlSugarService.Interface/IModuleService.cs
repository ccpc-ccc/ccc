using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService.Interface
{
    /// <summary>
    /// 用户信息管理接口
    /// </summary>
    public interface IModuleService : IBaseService <S_Module> {
        VPage<S_Module> getPage(QueryModule query);
        List<VModule> GetAll(string? parentId, string[]? permission);
        bool delete(S_Module model);
        S_Module GetById(string id);
        S_Module GetByPermiss(string Permiss);
        /// <summary>
        /// 获取管理员权限
        /// </summary>
        string getAdminPermiss(string[] notIn);
        bool saveModel(S_Module module);
    }
}
