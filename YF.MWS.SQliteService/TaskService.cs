using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;
using YF.Utility;

namespace YF.MWS.SQliteService
{
    public class TaskService : ITaskService
    {
        private SqliteDb sqliteDb = new SqliteDb();

        public bool AddTask(BTask task)
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(task.Id))
            {
                task.Id = Util.Utility.GetGuid();
            }
            TaskType type = task.TaskType.ToEnum<TaskType>();
            string sql = string.Empty;
            List<string> lstSql = new List<string>();
            if (type == TaskType.PrintWatermark)
            {
                sql = "delete from B_Task where TaskType='PrintWatermark' ";
                lstSql.Add(sql);
            }
            sql = SqliteSqlUtil.GetSaveSql<BTask>(task, "B_Task");
            lstSql.Add(sql);
            isSaved = sqliteDb.ExecuteNonQuery(lstSql) > 0;
            return isSaved;
        }

        public bool DeleteTask(string taskId)
        {
            string sql;
            sql = string.Format("delete from B_Task where Id='{0}' ",taskId);
            return sqliteDb.ExecuteNonQuery(sql) > 0;
        }

        public List<BTask> GetUnfinishedTask()
        {
            List<BTask> lstTask = new List<BTask>();
            string sql;
            sql = string.Format(@"delete from B_Task where CreateTime<='{0}'",DateTime.Now.AddSeconds(-20).ToString("yyyy-MM-dd HH:mm:ss"));
            sqliteDb.ExecuteNonQuery(sql);
            sql = string.Format(@"select * from B_Task where (TaskState='0' or TaskType='PrintWatermark')  order by CreateTime asc limit 0,10");
            DataTable dt = null;
            dt = sqliteDb.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                lstTask = TableHelper.TableToList<BTask>(dt);
            }
            return lstTask;
        }

        public List<BTask> GetAutoPrintList()
        {
            List<BTask> lstTask = new List<BTask>();
            string sql;
            sql = string.Format(@"select * from B_Task where (TaskType='{0}' or TaskType='{1}')  order by CreateTime desc limit 0,10", 
                                                  TaskType.AutoPrint.ToString(), TaskType.AutoPrintTemp.ToString());
            DataTable dt = null;
            dt = sqliteDb.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                lstTask = TableHelper.TableToList<BTask>(dt);
            }
            return lstTask;
        }
    }
}
