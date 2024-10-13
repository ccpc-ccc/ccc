using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.MWS.Metadata.Transfer;
using YF.Utility.Metadata;
using YF.Utility;

namespace YF.MWS.Util
{
    /// <summary>
    /// 查询条件工具类
    /// </summary>
    public class QueryUtil
    {
        public static string GetLogCondition(LogQuery query)
        {
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.AppendFormat(" where a.RowState != '{0}' ", (int)RowState.Delete);
            if (query.ActionType.HasValue)
            {
                sbCondition.AppendFormat("and a.ActionType='{0}'", query.ActionType.Value.ToString());
            }
            sbCondition.AppendFormat("and a.LogTime>='{0}' ", query.StartTime.ToString("yyyy-MM-dd 00:00:00"));
            sbCondition.AppendFormat("and a.LogTime<'{0}' ", query.EndTime.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
            if (!string.IsNullOrEmpty(query.UserId))
                sbCondition.AppendFormat("and a.UserId='{0}'", query.UserId);
            if (!string.IsNullOrEmpty(query.Key))
            {
                sbCondition.AppendFormat(" and (a.LogDesc like '%{0}%' or a.RecNo like '%{0}%')", query.Key);
            }
            return sbCondition.ToString();
        }

        public static string GetPlanCardCondition(PlanCardQuery query)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(query.CustomerId))
            {
                sb.AppendFormat(" and a.CustomerId='{0}'", query.CustomerId);
            }
            if (!string.IsNullOrEmpty(query.DeliveryId))
            {
                sb.AppendFormat(" and a.DeliveryId='{0}'", query.DeliveryId);
            }
            if (!string.IsNullOrEmpty(query.ReceiverId))
            {
                sb.AppendFormat(" and a.ReceiverId='{0}'", query.ReceiverId);
            }
            if (!string.IsNullOrEmpty(query.MaterialId))
            {
                sb.AppendFormat(" and a.MaterialId='{0}'", query.MaterialId);
            }
            return sb.ToString();
        }

        public static string GetWeightCondition(WeightQueryCondition qc) 
        {
            StringBuilder sb = new StringBuilder();
            if (qc.IsEmpty) 
            {
                sb.AppendFormat(" and 1=0 ");
                return sb.ToString();
            }
            if (qc.RowState.HasValue) 
            {
                if (qc.RowState.Value == RowState.Delete)
                {
                    sb.AppendFormat(" and a.RowState = {0} ", (int)RowState.Delete);
                }
                else 
                {
                    sb.AppendFormat(" and a.RowState != {0} ", (int)RowState.Delete);
                }
            }
            if (qc.FinishState.HasValue) 
            {
                sb.AppendFormat("and a.FinishState={0} ", (int)qc.FinishState.Value);
            }
            if (qc.StartTime.HasValue)
                {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                sb.AppendFormat("and a.FinishTime>=datetime('{0}') ", qc.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            } else {
                sb.AppendFormat("and a.FinishTime>='{0}'", qc.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
                }
                if (qc.EndTime.HasValue) {
                if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite) {
                    sb.AppendFormat("and a.FinishTime<=datetime('{0}') ", qc.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                } else {
                    sb.AppendFormat("and a.FinishTime<='{0}'", qc.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                }
            if (!string.IsNullOrEmpty(qc.WarehBizType)) {
                sb.AppendFormat(" and a.WarehBizType='{0}' ", qc.WarehBizType);
            }
            if (!string.IsNullOrEmpty(qc.CustomerName)) 
            {
                sb.AppendFormat(" and a.CustomerId in (select CustomerId from S_Customer where CustomerName like '%{0}%')", qc.CustomerName);
            }
            if (!string.IsNullOrEmpty(qc.DeliveryId))
            {
                sb.AppendFormat(" and a.DeliveryId='{0}'", qc.DeliveryId);
            }
            if (!string.IsNullOrEmpty(qc.ReceiverId))
            {
                sb.AppendFormat(" and a.ReceiverId='{0}'", qc.ReceiverId);
            }
            if (!string.IsNullOrEmpty(qc.SupplierId))
            {
                sb.AppendFormat(" and a.SupplierId='{0}'", qc.SupplierId);
            }
            if (!string.IsNullOrEmpty(qc.TransferId))
            {
                sb.AppendFormat(" and a.TransferId='{0}'", qc.TransferId);
            }
            if (!string.IsNullOrEmpty(qc.CarNo))
            {
                sb.AppendFormat(" and a.CarNo like '%{0}%'", qc.CarNo);
            }
            if (!string.IsNullOrEmpty(qc.CardNo))
            {
                sb.AppendFormat(" and a.CardNo='{0}'", qc.CardNo);
            }
            if (!string.IsNullOrEmpty(qc.MaterialId))
            {
                sb.AppendFormat(" and a.MaterialId='{0}'", qc.MaterialId);
            }
            if (!string.IsNullOrEmpty(qc.OrderSource))
            {
                sb.AppendFormat(" and a.OrderSource='{0}'", qc.OrderSource);
            }
            if (!string.IsNullOrEmpty(qc.Remark))
            {
                sb.AppendFormat(" and a.Remark like '%{0}%'", qc.Remark);
            }
                if (null!= qc.PayType)
                    sb.AppendFormat(" and a.PayType='{0}'", qc.PayType);
            sb.AppendFormat(" {0}", qc.Condtion);
            if (qc.ExtendConditions != null && qc.ExtendConditions.Count > 0) 
            {
                foreach (QueryCondition extQc in qc.ExtendConditions) 
                {
                    sb.AppendFormat(@" and a.WeightId in(select WeightId from B_WeightAttribute a inner join S_WeightViewDtl b on a.AttributeId=b.ControlId 
                                                     where b.DetailId='{0}' and a.AttributeValue like '%{1}%')",extQc.Id.Split('-')[1],extQc.Input);
                }
            }
            return sb.ToString();
        }
        public static string GetSaveSql<T>(T t, string tableName) where T : new() {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            PropertyInfo[] properties = typeof(T).GetProperties();
            _ = properties.Length;
            PropertyInfo[] array = properties;
            foreach (PropertyInfo propertyInfo in array) {
                object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(FieldAttribute), inherit: false);
                if (customAttributes != null && customAttributes.Length != 0) {
                    FieldAttribute fieldAttribute = (FieldAttribute)customAttributes[0];
                    if (fieldAttribute != null && fieldAttribute.IsSqliteIgnore) {
                        continue;
                    }
                }

                if (propertyInfo.PropertyType.IsGenericType) {
                    if (!(propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))) {
                        continue;
                    }

                    object value = propertyInfo.GetValue(t, null);
                    if (Nullable.GetUnderlyingType(propertyInfo.PropertyType).Name == "DateTime") {
                        stringBuilder2.AppendFormat("{0},", propertyInfo.Name);
                        if (propertyInfo.Name.ToUpper() == "UpdateTime".ToUpper()) {
                            stringBuilder3.AppendFormat("'{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        } else {
                            stringBuilder3.AppendFormat("'{0}',", value.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    } else {
                        stringBuilder2.AppendFormat("{0},", propertyInfo.Name);
                        stringBuilder3.AppendFormat("'{0}',", value.ToObjectString().Trim());
                    }
                } else if (propertyInfo.PropertyType.IsEnum) {
                    int num = (int)Enum.Parse(propertyInfo.PropertyType, propertyInfo.GetValue(t, null).ToString());
                    stringBuilder2.AppendFormat("{0},", propertyInfo.Name);
                    stringBuilder3.AppendFormat("'{0}',", num);
                } else if (propertyInfo.PropertyType.Name == "DateTime") {
                    object value = propertyInfo.GetValue(t, null);
                    if (value != null) {
                        stringBuilder2.AppendFormat("{0},", propertyInfo.Name);
                        if (propertyInfo.Name.ToUpper() == "UpdateTime".ToUpper()) {
                            stringBuilder3.AppendFormat("'{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        } else {
                            stringBuilder3.AppendFormat("'{0}',", value.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                    }
                } else {
                    object value = propertyInfo.GetValue(t, null);
                    stringBuilder2.AppendFormat("{0},", propertyInfo.Name);
                    stringBuilder3.AppendFormat("'{0}',", value.ToObjectString().Trim());
                }
            }

            if (stringBuilder2.Length > 0) {
                stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
                stringBuilder3.Remove(stringBuilder3.Length - 1, 1);
            }

            stringBuilder.AppendFormat("insert into {0} ({1}) values ({2})", tableName, stringBuilder2, stringBuilder3);
            return stringBuilder.ToString();
        }
    }
}
