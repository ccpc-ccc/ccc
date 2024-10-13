using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Util;
using YF.Utility.Data;

namespace YF.MWS.SQliteService
{
    public class WeightViewService : BaseService,IWeightViewService {
        #region IWeightViewService 成员
        public bool DeleteView(string viewId)
        {
            List<string> sqls=new List<string>();
            sqls.Add(string.Format("delete from S_WeightView where Id='{0}' ", viewId));
            sqls.Add(string.Format("delete from S_WeightViewDtl where ViewId='{0}' ", viewId));
            return base.ExecuteSql(sqls);
        }

        public bool DeleteViewDetail(string detailId) 
        {
            List<string> sqls = new List<string>();
            string sql;
            sql = string.Format("delete from S_WeightViewDtl where Id='{0}' ", detailId);
            sqls.Add(sql);
            sql = string.Format("delete from S_CardViewDtl where Id='{0}' ", detailId);
            sqls.Add(sql);
            return ExecuteSql(sqls);
        }
        public bool DeleteControl(string controlId) {
            string sql = string.Format("delete from S_Control where Id='{0}'", controlId);
            return ExecuteSql(sql);
        }

        public SControl GetControl(string controlId)
        {
            string sql = string.Format("select * from S_Control where Id='{0}'", controlId);
            return getModel<SControl>(sql);
        }

        public SControl GetControlByName(string fieldName)
        {
            string sql = string.Format("select * from S_Control where FieldName='{0}'", fieldName);
            return getModel<SControl>(sql);
        }

        public List<SControl> GetControlList()
        {
            string sql = "select * from S_Control";
            return getList<SControl>(sql);
        }
        public List<SControl> GetViewControlList() {
            string sql = "select * from S_Control where IsViewShow=1";
            return getList<SControl>(sql);
        }

        public SWeightView GetDefaultView(ViewType type) 
        {
            string sql = string.Format("select * from S_WeightView where IsDefault=1 and ViewType='{0}'",type);
            return getModel<SWeightView>(sql);
        }

        public SWeightView GetView(string viewId)
        {
            string sql = string.Format("select * from S_WeightView where Id='{0}'", viewId);
            return getModel<SWeightView>(sql);
        }

        public List<QWeightView> GetViewList()
        {
            List<QWeightView> lstDetail = new List<QWeightView>();
            string sql = string.Format("select * from S_WeightView where RowState!={0} order by ViewName asc",(int)RowState.Delete);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<QWeightView>(dt);
            return lstDetail;
        }

        public SWeightViewDtl GetViewDetail(string detailId)
        {
            string sql = string.Format("select * from S_WeightViewDtl where Id='{0}' order by OrderNo", detailId);
            return getModel<SWeightViewDtl>(sql);
        }

        public List<SWeightViewDtl> GetAllDetailList(string viewId)
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string sql = string.Format("select * from S_WeightViewDtl where ViewId='{0}' order by OrderNo",viewId);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            return lstDetail;
        }

        public List<SWeightViewDtl> GetDetailList(string viewId)
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string sql;
            sql = string.Format("select * from S_WeightViewDtl where ViewId='{0}' and RowState!={1} order by OrderNo", viewId,(int)RowState.Delete);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            return lstDetail;
        }
        public List<SWeightViewDtl> GetShow2DetailList(string viewId) {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string sql = string.Format("select * from S_WeightViewDtl where ViewId='{0}' and (Show2=1 or Show2 is null)", viewId);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            return lstDetail;
        }
        public List<SWeightViewDtl> GetUnShow2DetailList(string viewId) {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string sql = string.Format("select * from S_WeightViewDtl where ViewId='{0}' and Show2=0", viewId);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            return lstDetail;
        }
        public List<SWeightViewDtl> GetShow2DetailList(ViewType type) {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            SWeightView view =GetDefaultView(type);
            if (view == null) return null;
            string sql = string.Format("select * from S_WeightViewDtl where ViewId='{0}' and (Show2=1 or Show2 is null)", view.Id);
            DataTable dt = GetTable(sql);
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dt);
            return lstDetail;
        }
        public bool SetDefaultView(ViewType type,string viewId) 
        {
            List<string> lstSql = new List<string>();
            string sql;
            sql = string.Format("update S_WeightView set IsDefault=0 where ViewType='{0}'",type);
            lstSql.Add(sql);
            sql = string.Format("update S_WeightView set IsDefault=1 where Id='{0}' and ViewType='{1}'", viewId,type);
            lstSql.Add(sql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(lstSql) > 0;
            }
            else 
            {
                sql = string.Format(@"update S_WeightView set IsDefault=0 where ViewType='{1}';
                                                 update S_WeightView set IsDefault=1 where Id='{0}' and ViewType='{1}'", viewId,type);
                return service.ExecuteNonQuery(sql);
            }
            
        }

        public bool SaveConrol(SControl control)
        {
            return base.save<SControl>(control, "S_Control");
        }

        public bool SaveView(SWeightView view) {
            if (view.IsDefault==1) {
                string sql = string.Format("update S_WeightView set IsDefault=0 where ViewType='{0}'",view.ViewType);
                base.ExecuteSql(sql);
            }
            return base.save<SWeightView>(view, "S_WeightView");
        }

        public bool SaveViewDetail(SWeightViewDtl detail) {
            return base.save<SWeightViewDtl>(detail, "S_WeightViewDtl");
        }

        public bool UpdateState(string detailId, RowState state) 
        {
            string sql = string.Format(@"update S_WeightViewDtl set RowState={0} where Id='{1}'",(int)state,detailId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateExpression(string detailId, string expression)
        {
            string sql = string.Format(@"update S_WeightViewDtl set Expression='{0}' where Id='{1}'",expression,detailId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateState(string detailId, RowState state, int orderNo)
        {
            string sql = string.Format(@"update S_WeightViewDtl set RowState={0},OrderNo={1} where Id='{2}'", 
                                                     (int)state, orderNo,detailId);
            return ExecuteSql(sql);
        }
        public bool UpdateShow2(string detailId, int state)
        {
            string sql = string.Format(@"update S_WeightViewDtl set Show2={0} where Id='{1}'", state,detailId);
            return ExecuteSql(sql);
        }

        public bool UpdateColumns(string viewId, int columnsCount) 
        {
            string sql = string.Format(@"update S_WeightView set ColumnsCount={0} where sId='{1}'", columnsCount, viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }

        public bool UpdateWeightColumnDecimalDigits(int decimalDigits) 
        {
            List<string> weightColumns = new List<string>() {"GrossWeight","NetWeight","TareWeight","SuttleWeight" };
            string sql = string.Format(@"update S_WeightViewDtl set DecimalDigits={0} where FieldName in({1})",
                                                        decimalDigits, SqlConditionUtil.GetArrayIn(weightColumns));
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            }
        }
        public bool saveWeightView(SWeightView sWeight, List<SWeightViewDtl> dtls) {
            if (sWeight.Id != null && sWeight.Id != "") {
            base.ExecuteSql(string.Format("update S_WeightViewDtl set RowState=3 where ViewId='{0}'",sWeight.Id));
                List<SWeightViewDtl> olds = GetAllDetailList(sWeight.Id);
                List<string> sqls = new List<string>();
                int i = 0;
                foreach (SWeightViewDtl dtl in dtls) {
                    i++;
                        bool ok = false;
                    dtl.OrderNo = i;
                    dtl.ViewId=sWeight.Id;  
                    foreach (SWeightViewDtl old in olds) {
                        if (old.FieldName == dtl.FieldName) {
                            sqls.Add(string.Format("update S_WeightViewDtl  set OrderNo='{0}',ControlName='{1}',Caption='{2}',RowState=1 where FieldName='{3}' and ViewId='{4}'",
                                i,dtl.ControlName,dtl.Caption,dtl.FieldName,sWeight.Id));
                            ok = true;
                            break;
                        }
                    }
                    if (ok) continue;
                dtl.Id = Guid.NewGuid().ToString("N");
                    SaveViewDetail(dtl);
                }
                base.ExecuteSql(sqls);
            } else {
                sWeight.Id = Guid.NewGuid().ToString("N");
                int i = 0;
                foreach (SWeightViewDtl dtl in dtls) {
                    i++;
                    dtl.ViewId = sWeight.Id;
                    dtl.OrderNo = i;
                    dtl.Id = Guid.NewGuid().ToString("N");
                    SaveViewDetail(dtl);
                }
            }
            return  SaveView(sWeight);
        }
        #endregion
    }
}
