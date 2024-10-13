using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using System.Data;
using YF.Utility.Data;
using YF.MWS.BaseMetadata;
using YF.MWS.Util;
using YF.Data.NHProvider;

using YF.MWS.Metadata;
using System.Reflection;

namespace YF.MWS.SQliteService
{
    public class RoleService : BaseService,IRoleService
    {
        #region IRoleService 成员

        public List<SModule> GetModuleList()
        {
            string sql = string.Format("select * from S_Module where Platform='{0}'  order by OrderNo", PlatformType.Client);
            return getList<SModule>(sql);
        }
        public List<SModule> GetModuleList(string[] powers)
        {
            string ps=string.Join("','", powers);
            string sql = string.Format("select * from S_Module where Platform='{0}' and FullName in ('{1}') order by OrderNo", PlatformType.Client,ps);
            return getList<SModule>(sql);
        }

        public List<SModule> GetSubModuleList(string moduleId)
        {
            string sql = string.Format("select * from S_Module where ParentId='{0}'", moduleId);
            return getList<SModule>(sql);
        }

        public List<SRole> GetRoleList()
        {
            string sql = string.Format("select * from S_Role where Platform='{0}'", PlatformType.Client);
            return getList<SRole>(sql);
        }

        public DataTable GetRoleTable()
        {
            string sql = string.Format("select * from S_Role where Platform='{0}'",PlatformType.Client);
            return GetTable(sql);
        }

        public List<SModule> GetModuleList(string userId)
        {
            string sql; 
                sql = string.Format(@"select  a.* from S_Module a inner join S_RolePermission b on a.Id=b.ModuleId 
                           inner join  S_User c on b.RoleId=c.RoleId where c.Id='{0}' and a.Platform='{1}'", userId,PlatformType.Client);
            return getList<SModule>(sql);
        }

        public List<SUserRole> GetUserRoleList(string userId)
        {
            string sql = string.Format(@"select * from S_UserRole where UserId='{0}'", userId);
            return getList<SUserRole>(sql);
        }

        public List<SRolePermission> GetRolePermissionList(string roleId)
        {
            string sql = string.Format(@"select ModuleId,Id,RoleId from S_RolePermission where RoleId='{0}'", roleId);
            return getList<SRolePermission>(sql);
        }

        public bool DeleteModule(string moduleId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from S_RolePermission where ModuleId='{0}';", moduleId);
            sb.AppendFormat("delete from S_Module where Id='{0}';", moduleId);
            return ExecuteSql(sb.ToString());
        }

        public bool DeleteRole(string roleId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from S_UserRole where RoleId='{0}';", roleId);
            sb.AppendFormat("delete from S_RolePermission where RoleId='{0}';", roleId);
            sb.AppendFormat("delete from S_Role where Id='{0}';", roleId);
            return ExecuteSql(sb.ToString());
        }

        public SModule GetModule(string moduleId)
        {
            string sql = string.Format(@"select * from S_Module where Id='{0}'", moduleId);
            return getModel<SModule>(sql);
        }
        public SModule GetModuleByFullName(string fullName) {
            string sql = string.Format(@"select * from S_Module where FullName='{0}'", fullName);
            return getModel<SModule>(sql);
        }

        public SRole GetRole(string roleId)
        {
            string sql = string.Format(@"select * from S_Role where Id='{0}'", roleId);
            return getModel<SRole>(sql);
        }

        public void ImportModules(List<SModule> modules) 
        {
            if (modules != null && modules.Count > 0) 
            {
                string sql = "delete from S_Module";
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                {
                    sqliteDb.ExecuteNonQuery(sql);
                    foreach (var module in modules) 
                    {
                        sql = SqliteSqlUtil.GetSaveSql<SModule>(module, "S_Module");
                        sqliteDb.ExecuteNonQuery(sql);
                    }
                }
                else
                {
                    service.ExecuteNonQuery(sql);
                    foreach (var module in modules)
                        service.Save(module, module.Id);
                }
            }
        }
        public bool SaveModule(SModule module)
        {
            bool isSaved = false;
            string sql;
            if (string.IsNullOrEmpty(module.Id))
            {
                module.Id = Util.Utility.GetGuid();
            }
            sql = SqliteSqlUtil.GetSaveSql<SModule>(module, "S_Module");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                module.Platform = PlatformType.Client.ToString();
                isSaved = service.Save<SModule>(module, module.Id);
            }
            return isSaved;
        }

        public bool SaveRole(SRole role)
        {
            bool isSaved = false;
            string sql;
            if (string.IsNullOrEmpty(role.Id))
            {
                role.Id = Util.Utility.GetGuid();
            }
            sql = SqliteSqlUtil.GetSaveSql<SRole>(role, "S_Role");
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                if (string.IsNullOrEmpty(role.Id))
                {
                    role.Id = Util.Utility.GetGuid();
                }
                role.Platform = PlatformType.Client.ToString();
                isSaved = service.Save<SRole>(role, role.Id);
            }
            return isSaved;
        }

        public bool SaveUserRole(string userId, List<string> lstRoleId)
        {
            bool isSaved = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from S_UserRole where UserId='{0}';", userId);
            foreach (string roleId in lstRoleId)
            {
                sb.AppendFormat("insert into S_UserRole(Id,UserId,RoleId,CreaterId,CreateTime,UpdaterId,UpdateTime) values('{2}','{0}','{1}','{3}','{4}','{5}','{6}');",
                    userId, roleId, Util.Utility.GetGuid(), CurrentUser.Instance.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                    CurrentUser.Instance.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sb.ToString()) > 0;
            }
            else 
            {
                isSaved = service.ExecuteNonQuery(sb.ToString());
            }
            return isSaved;
        }

        public bool SaveRolePermission(string roleId, List<string> lstModuleId)
        {
            bool isSaved = false;
            List<string> sqls = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from S_RolePermission where RoleId='{0}'", roleId);
            sqls.Add(sb.ToString());
            foreach (string moduleId in lstModuleId)
            {
                sb.Clear();
                sb.AppendFormat("insert into S_RolePermission(Id,RoleId,ModuleId,CreaterId,CreateTime,UpdaterId,UpdateTime) values('{2}','{0}','{1}','{3}','{4}','{5}','{6}')",
                    roleId, moduleId, Util.Utility.GetGuid(), CurrentUser.Instance.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                    CurrentUser.Instance.Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sqls.Add(sb.ToString());
            }
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                isSaved = sqliteDb.ExecuteNonQuery(sqls) > 0;
            }
            else
            {
                isSaved = service.ExecuteNonQuery(sqls);
            }
            return isSaved;
        }

        #endregion
    }
}
