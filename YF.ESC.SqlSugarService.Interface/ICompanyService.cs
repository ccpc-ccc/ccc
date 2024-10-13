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
    /// 商家管理接口
    /// </summary>
    public interface ICompanyService : IBaseService <S_Company> {
        VPage<S_Company> getPage(QueryCompany query);
        List<S_Company> GetAll(string? parentId);
        bool delete(S_Company model);
        S_Company GetById(string id);
        S_Company GetByCode(string code);
    }
}
