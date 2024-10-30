using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YF.Data.NHProvider;

using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public class WarehService :BaseService, IWarehService
    {
        

        public WarehService()
        { }

        public bool Delete(string warehId)
        {
            string sql = $"delete from S_Wareh  where Id = '{warehId}'";
            return base.ExecuteSql(sql);
        }

        public VWareh Get(string warehId)
        {
            string sql;
            sql = string.Format(@"select a.*,b.OpenAddress,b.CloseAddress,b.WarehId WarehId2 from S_Wareh a left join S_Wareh2 b on b.WarehId=a.WarehId where a.WarehId='{0}' ", warehId);
            return base.getModel<VWareh>(sql);
        }

        public SWareh GetByName(string warehName)
        {
            SWareh wareh = null;
            string sql;
            sql = string.Format(@"select * from S_Wareh where WarehName='{0}' ", warehName);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else
            {
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                wareh = TableHelper.RowToEntity<SWareh>(dt.Rows[0]);
            }
            return wareh;
        }

        public List<VWareh> GetList()
        {
            string sql = string.Format(@"select a.*,b.OpenAddress,b.CloseAddress,b.WarehId WarehId2 from S_Wareh a left join S_Wareh2 b on b.WarehId=a.WarehId where a.RowState!={0}", (int)RowState.Delete);
            return base.getList<VWareh>(sql);
        }
        public void Save2(VWareh model) {
            string sql = $"update S_Wareh2 set CloseAddress='{model.CloseAddress}',OpenAddress='{model.OpenAddress}' where WarehId='{model.WarehId}'";
            if (string.IsNullOrEmpty(model.WarehId2)) {
                string Id=Guid.NewGuid().ToString("N");
                sql = $"insert into S_Wareh2 (Id,WarehId,CloseAddress,OpenAddress) values ('{Id}','{model.WarehId}','{model.CloseAddress}','{model.OpenAddress}')";
            }
            base.ExecuteSql(sql);
        }
        public List<VWeight> GetBWeights() {
            string sql = "Select a.*,b.IsOpen,b.IsClose,b.OpenTime,b.CloseTime,b.WeightId WeightId2,c.OpenAddress,c.CloseAddress from B_Weight a left join B_Weight2 b left join S_Wareh c on c.WarehId=a.WarehId on a.WeightId=b.WeightId";
            sql += $" where a.CreateTime>='{DateTime.Now.AddDays(2)}' and a.RowState!=3 and c.WarehId is not null order by a.CreateTime";
            return base.getList<VWeight>(sql);
        }
        public void OptionWareh(string weightId,string type) {
            string sql = $"select * from B_Weight2 where WeightId='{weightId}'";
            B_Weight2 b_Weight2 = base.getModel<B_Weight2>(sql);
            if (b_Weight2 == null) {
                string id=Guid.NewGuid().ToString("N");
                if(type.ToLower()=="open") sql = $"insert into B_Weight2 (Id,WeightId,IsOpen,IsClose,OpenTime,CloseTime,CreateTime) values ('{id}','{weightId}',1,0,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                else sql = $"insert into B_Weight2 (Id,WeightId,IsClose,IsOpen,CloseTime,OpenTime,CreateTime) values ('{id}','{weightId}',1,0,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            } else {
                if (type.ToLower() == "open") sql = $"update B_Weight2 set IsOpen=1,OpenTime='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where WeightId='{weightId}'";
                else sql = $"update B_Weight2 set IsClose=1,CloseTime='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where WeightId='{weightId}'";
            }
            base.ExecuteSql(sql);
        }
    }
}
