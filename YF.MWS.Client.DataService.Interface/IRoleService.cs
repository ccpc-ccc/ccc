using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Client.DataService.Interface
{
    /// <summary>
    /// 权限系统接口定义
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 获取系统模块定义信息
        /// </summary>
        /// <returns>系统模块定义信息集合</returns>
        List<SModule> GetModuleList();
        List<SModule> GetModuleList(string[] powers);

        /// <summary>
        /// 获取子模块列表
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<SModule> GetSubModuleList(string moduleId);

        /// <summary>
        /// 获取系统权限信息
        /// </summary>
        /// <returns>系统权限信息集合</returns>
        List<SRole> GetRoleList();

        DataTable GetRoleTable();
        /// <summary>
        /// 根据用户编号获取用户可访问的模块信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>模块信息集合</returns>
        List<SModule> GetModuleList(string userId);

        /// <summary>
        /// 根据用户编号获取角色信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>角色信息集合</returns>
        List<SUserRole> GetUserRoleList(string userId);

        /// <summary>
        /// 根据角色编号获取授权信息
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>授权信息集合</returns>
        List<SRolePermission> GetRolePermissionList(string roleId);

        /// <summary>
        /// 删除系统定义的模块信息
        /// </summary>
        /// <param name="moduleId">模块ID</param>
        /// <returns>False: 删除失败 True: 删除成功</returns>
        bool DeleteModule(string moduleId);

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>False: 删除失败 True: 删除成功</returns>
        bool DeleteRole(string roleId);

        /// <summary>
        /// 根据模块编号获取模块定义信息
        /// </summary>
        /// <param name="moduleId">模块ID</param>
        /// <returns>模块信息实体类</returns>
        SModule GetModule(string moduleId);
        SModule GetModuleByFullName(string fullName);

        /// <summary>
        /// 根据角色编号获取角色信息
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>角色信息实体类</returns>
        SRole GetRole(string roleId);

        /// <summary>
        /// 保存模块信息
        /// </summary>
        /// <param name="module">模块信息实体类</param>
        /// <returns>False: 保存失败 True: 保存成功</returns>
        bool SaveModule(SModule module);
        void ImportModules(List<SModule> modules);
        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="role">角色信息实体类</param>
        /// <returns>False: 保存失败 True: 保存成功</returns>
        bool SaveRole(SRole role);

        /// <summary>
        /// 保存用户对应的角色信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="lstRoleId">权限ID集合</param>
        /// <returns>False: 保存失败 True: 保存成功</returns>
        bool SaveUserRole(string userId, List<string> lstRoleId);

        /// <summary>
        /// 保存角色对应的授权信息
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="lstModuleId">模块ID集合</param>
        /// <returns>False: 保存失败 True: 保存成功</returns>
        bool SaveRolePermission(string roleId, List<string> lstModuleId);
    }
}
