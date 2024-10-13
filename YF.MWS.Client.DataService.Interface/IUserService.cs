using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 用户信息管理接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 批量删除用户信息
        /// </summary>
        /// <param name="lstUserId">要删除的用户ID集合</param>
        /// <returns>False: 删除失败 True: 删除成功</returns>
        bool Delete(List<string> lstUserId);
        bool Delete(string lstUserId);
        /// <summary>
        /// 验证用户登录信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>用户信息实体类</returns>
        SUser Login(string userName, string userPwd);

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息实体类</returns>
        SUser Get(string userName);

        List<string> GetUserList();
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户信息实体类</returns>
        SUser GetById(string userId);

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns>用户信息集合</returns>
        List<SUser> GetList(string[] companyIds);
        List<SUser> GetList(CurrentUser user);

        bool ResetPassword(string userName, string newPasswrod);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user">用户信息实体类</param>
        /// <returns>False: 保存失败 True: 保存成功</returns>
        bool Save(SUser user);

        /// <summary>
        /// 判断用户名是否存在系统中
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>True : 用户名存在 False : 用户名不存在</returns>
        bool UserExist(string userName);

        /// <summary>
        /// 更新用户的密码
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newPasswrod">新密码</param>
        /// <returns>False: 更新失败 True: 更新成功</returns>
        bool UpdatePassword(string userId, string newPasswrod);
    }
}
