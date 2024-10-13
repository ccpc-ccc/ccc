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
    public interface IUserService: IBaseService <S_User> {
        /// <summary>
        /// 批量删除用户信息
        /// </summary>
        /// <param name="lstUserId">要删除的用户ID集合</param>
        /// <returns>False: 删除失败 True: 删除成功</returns>
        bool Delete(List<string> lstUserId);

        /// <summary>
        /// 验证用户登录信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>用户信息实体类</returns>
        S_User Login(QueryUser query);
        bool MasterSave(S_User user);
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息实体类</returns>
        S_User GetByName(QueryUser query);

        List<string> GetUserList();
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户信息实体类</returns>
        S_User GetById(string userId);

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns>用户信息集合</returns>
        List<S_User> GetList();
        /// <summary>
        /// 获取商家管理员账户
        /// </summary>
        S_User getCompanyAdmin(string companyId);

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
        /// <summary>
        /// 分页获取数据(用户管理列表)
        /// </summary>
        VPage<S_User> getPage(QueryUser queryUser);
        List<S_User> getListByCompany(string companyId);
        bool Delete(List<S_User> lstUser);
        /// <summary>
        /// 保存权限
        /// </summary>
        bool savePermiss(QueryUser query);
    }
}
