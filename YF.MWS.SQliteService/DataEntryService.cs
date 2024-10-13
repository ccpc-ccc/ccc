using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Util;
using YF.MWS.Util.Dynamic;
using YF.Utility.Data;
namespace YF.MWS.SQliteService
{
    public class DataEntryService : IDataEntryService
    {
        private SqliteDb sqliteDb = new SqliteDb();

        public DataEntry Get(string id)
        {
            var script = "Select * From B_WeightExt where Id = '" + id + "'";
            DataTable dt = sqliteDb.ExecuteDataTable(script);
            if (dt != null && dt.Rows.Count > 0)
                return TableHelper.RowToEntity<DataEntry>(dt.Rows[0]);
            else
                return null;
        }

        public List<DataEntry> GetList()
        {
            var script = "Select * From B_WeightExt";// where Id = '" + id + "'";            
            DataTable dt = sqliteDb.ExecuteDataTable(script);
            return TableHelper.TableToList<DataEntry>(dt);
        }

        public bool Add(DataEntry entry)
        {
            if (entry == null)
                return false;
            var proxy = new ObjectProxy(entry);
            var sb = new StringBuilder();
            sb.Append("INSERT INTO [B_WeightExt]");
            var fields = new List<string>();
            var values = new List<string>();
            foreach (var p in proxy.GetDynamicMemberNames(true))
            {
                values.Add(string.Format("'{0}'", proxy[p]));
                fields.Add(string.Format("[{0}]", p));
            }

            sb.Append("(")
                .AppendLine(string.Join(",", fields.ToArray()))
                .AppendLine(") values (")
                .AppendLine(string.Join(",", values.ToArray()))
                .Append(")");

            var script = sb.ToString();


            return sqliteDb.ExecuteNonQuery(script) > 0;
        }

        public bool Update(DataEntry entry)
        {
            if (entry == null)
                return false;
            var proxy = new ObjectProxy(entry);
            var sb = new StringBuilder();
            sb.AppendLine("Update INTO [B_WeightExt] Set ");
            var fields = new List<string>();
            foreach (var p in proxy.GetDynamicMemberNames(true))
            {
                if (p == "Id")
                    continue;
                fields.Add(string.Format("[{0}] = '{1}'", p, proxy[p]));

            }
            sb.AppendLine(string.Join(",\r\n", fields.ToArray()))
            .AppendFormat("WHERE [Id] = '{0}'", entry.Id);
            var script = sb.ToString();


            return sqliteDb.ExecuteNonQuery(script) > 0;
        }

        public bool Delete(DataEntry entry)
        {
            if (entry == null)
                return false;
            return Delete(entry.Id);
        }

        public bool Delete(string id)
        {
            var script = string.Format("Delete From [B_WeightExt] where id = '{0}'", id);
            return sqliteDb.ExecuteNonQuery(script) > 0;
        }
    }
}
