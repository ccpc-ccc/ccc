using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Dto;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Client.DataService.Interface.Remote
{
    public interface IWebUserService
    {
        bool ExistUserName(string userName);
        TLoginResult Login(string userName, string password);
        SUser Get(string userId);
        TPageResult GetList(PageQueryCondition qc);
        List<SRole> GetRoleList();
        List<DRole> GetUserRoleList(string userId);
        bool SaveUser(SUser user);
    }
}
