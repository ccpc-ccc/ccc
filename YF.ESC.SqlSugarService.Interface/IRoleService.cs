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
    public interface IRoleService : IBaseService <S_Role> {
        VPage<S_Role> getPage(QueryRole query);
        S_Role GetById(string id);
        bool savePermiss(QueryRole query);
    }
}
