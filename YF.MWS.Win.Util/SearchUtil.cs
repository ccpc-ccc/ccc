using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.Utility;
using YF.Utility.Data;

namespace YF.MWS.Win.Util
{
    public class SearchUtil
    {
        private static string GetColumnName(SWeightViewDtl viewDetail,SearchControlType inputType) 
        {
            string columnName = string.Empty;
            SearchFieldType fieleType=viewDetail.ControlType.ToEnum<SearchFieldType>();
            if (fieleType == SearchFieldType.Extend)
            {
                columnName = string.Format("{0}", viewDetail.FieldName);
            }
            else
            {
                string key = viewDetail.FieldName.ToLower();
                if(key == WeightSearchKey.PaymentSettleState.ToString().ToLower() || 
                    key == WeightSearchKey.FreightSettleState.ToString().ToLower() || 
                    key == WeightSearchKey.SettleState.ToString().ToLower())
                {
                        columnName = string.Format("c.{0}", viewDetail.FieldName);
                }
                if (string.IsNullOrEmpty(columnName))
                {
                    if (inputType == SearchControlType.Text && key == WeightSearchKey.CarId.ToString().ToLower())
                    {
                        columnName = "a.CarNo";
                    }
                    else
                    {
                        columnName = string.Format("a.{0}", viewDetail.FieldName);
                    }
                }
            }
            return columnName;
        } 

        private static SearchControlType GetType(SWeightViewDtl viewDetail) 
        {
            SearchControlType type = SearchControlType.Text;
            string key = viewDetail.FieldName.ToLower();
            if (string.IsNullOrEmpty(key))
                return type;
            if (key == WeightSearchKey.CarId.ToString().ToLower() ||
                key == WeightSearchKey.CustomerId.ToString().ToLower() ||
                key == WeightSearchKey.DeliveryId.ToString().ToLower() ||
                key == WeightSearchKey.ManufacturerId.ToString().ToLower() ||
                key == WeightSearchKey.MaterialId.ToString().ToLower() ||
                key == WeightSearchKey.MeasureType.ToString().ToLower() ||
                key == WeightSearchKey.OrderSource.ToString().ToLower() ||
                key == WeightSearchKey.FreightSettleState.ToString().ToLower() ||
                key == WeightSearchKey.PaymentSettleState.ToString().ToLower() ||
                key == WeightSearchKey.ReceiverId.ToString().ToLower() ||
                key == WeightSearchKey.TransferId.ToString().ToLower() ||
                key == WeightSearchKey.PayType.ToString().ToLower() ||
                key == WeightSearchKey.WarehBizType.ToString().ToLower() ||
                key == WeightSearchKey.WarehId.ToString().ToLower() ||
                key == WeightSearchKey.SettleState.ToString().ToLower() ||
                key == WeightSearchKey.SupplierId.ToString().ToLower() ||
                key == WeightSearchKey.UnloadType.ToString().ToLower() ||
                key == WeightSearchKey.WeighterName.ToString().ToLower())
            {
                type = SearchControlType.SearchLookup;
            }
            return type;
        }

        /// <summary>
        /// 是否允许精确查询
        /// </summary>
        /// <param name="viewDetail"></param>
        /// <returns></returns>
        private static bool IsAccurateQuery(SWeightViewDtl viewDetail)
        {
            bool isOnly = false;
            string key = viewDetail.FieldName.ToLower();
            if (string.IsNullOrEmpty(key))
                return isOnly;
            if (key==WeightSearchKey.CarId.ToString().ToLower() ||
                key == WeightSearchKey.CardNo.ToString().ToLower() ||
                key == WeightSearchKey.CustomerId.ToString().ToLower() ||
                key == WeightSearchKey.DeliveryId.ToString().ToLower() ||
                key == WeightSearchKey.DriverName.ToString().ToLower() ||
                key == WeightSearchKey.ManufacturerId.ToString().ToLower() ||
                key == WeightSearchKey.TransferId.ToString().ToLower() ||
                key == WeightSearchKey.MaterialId.ToString().ToLower() ||
                key == WeightSearchKey.MeasureType.ToString().ToLower() ||
                key == WeightSearchKey.WarehBizType.ToString().ToLower() ||
                key == WeightSearchKey.WarehId.ToString().ToLower() ||
                key == WeightSearchKey.OrderSource.ToString().ToLower() ||
                key == WeightSearchKey.PayType.ToString().ToLower() ||
                key == WeightSearchKey.FreightSettleState.ToString().ToLower() ||
                key == WeightSearchKey.PaymentSettleState.ToString().ToLower() ||
                key == WeightSearchKey.ReceiverId.ToString().ToLower() ||
                key == WeightSearchKey.SettleState.ToString().ToLower() ||
                key == WeightSearchKey.SupplierId.ToString().ToLower() ||
                key == WeightSearchKey.UnloadType.ToString().ToLower() ||
                key == WeightSearchKey.WeighterName.ToString().ToLower())
            {
                    isOnly = true;
            }
            return isOnly;
        }

        /// <summary>
        /// 是否仅仅允许精确查询
        /// </summary>
        /// <param name="viewDetail"></param>
        /// <returns></returns>
        private static bool IsOnlyAccurateQuery(SWeightViewDtl viewDetail)
        {
            bool isOnly = false;
            string fieldName = viewDetail.FieldName;
            if (!string.IsNullOrEmpty(fieldName)) 
            {
                if (fieldName.ToLower() == WeightSearchKey.PaymentSettleState.ToString().ToLower() ||
                    fieldName.ToLower() == WeightSearchKey.FreightSettleState.ToString().ToLower() ||
                    fieldName.ToLower() == WeightSearchKey.SettleState.ToString().ToLower()) 
                {
                    isOnly = true;
                }
            }
            return isOnly;
        }

        /// <summary>
        /// 是否允许模糊查询
        /// </summary>
        /// <param name="viewDetail"></param>
        /// <returns></returns>
        private static bool IsFuzzyQuery(SWeightViewDtl viewDetail) 
        {
            bool isFQ = false;
            string key = viewDetail.FieldName.ToLower();
            if(key == WeightSearchKey.CarId.ToString().ToLower() ||
                key == WeightSearchKey.CardNo.ToString().ToLower() ||
                key == WeightSearchKey.DriverName.ToString().ToLower() ||
                key == WeightSearchKey.WeighterName.ToString().ToLower())
            {
                    isFQ = true;
            }
            return isFQ;
        }

        private static QueryCondition ViewDetailToQC(SWeightViewDtl viewDetail) 
        {
            QueryCondition qc = new QueryCondition();
            qc.Caption = viewDetail.ControlName;
            qc.ControlType = GetType(viewDetail);
            qc.ColumnName = GetColumnName(viewDetail,qc.ControlType);
            qc.FieldType = viewDetail.ControlType.ToEnum<SearchFieldType>();
            qc.SearchKey = viewDetail.FieldName;
            qc.SettingCaption = qc.Caption;
            qc.Id = qc.ControlType +"-"+ viewDetail.DetailId;
            return qc;
        }

        private static QueryCondition ViewDetailToQC(SWeightViewDtl viewDetail,SearchControlType type)
        {
            QueryCondition qc = new QueryCondition();
            qc.Caption = viewDetail.ControlName;
            qc.ControlType = type;
            qc.ColumnName = GetColumnName(viewDetail, qc.ControlType);
            qc.FieldType = viewDetail.ControlType.ToEnum<SearchFieldType>();
            qc.SearchKey = viewDetail.FieldName;
            if (type == SearchControlType.SearchLookup)
            {
                qc.SettingCaption = qc.Caption + "_精确查询";
            }
            else 
            {
                qc.SettingCaption = qc.Caption + "_模糊查询";
            }
            qc.Id = qc.ControlType + "-" + viewDetail.DetailId;
            return qc;
        }

        private static QueryCondition RowToQC(DataRow dr) 
        {
            QueryCondition qc = new QueryCondition();
            qc.Id = dr["Id"].ToObjectString();
            qc.SearchKey = dr["SearchKey"].ToObjectString();
            qc.Caption = dr["Caption"].ToObjectString();
            qc.ColumnName = dr["ColumnName"].ToObjectString();
            qc.ControlType = dr["ControlType"].ToEnum<SearchControlType>();
            qc.FieldType = dr["FieldType"].ToEnum<SearchFieldType>();
            qc.SettingCaption = dr["SettingCaption"].ToObjectString();
            return qc;
        }

        public static List<QueryCondition> GetConfigList(List<SWeightViewDtl> lstViewDtl) 
        {
            List<QueryCondition> lstQC = new List<QueryCondition>();
            foreach (SWeightViewDtl dtl in lstViewDtl) 
            {
                if (IsOnlyAccurateQuery(dtl))
                {
                    lstQC.Add(ViewDetailToQC(dtl, SearchControlType.SearchLookup));
                }
                else 
                {
                    if(IsAccurateQuery(dtl) && IsFuzzyQuery(dtl))
                    {
                        lstQC.Add(ViewDetailToQC(dtl, SearchControlType.SearchLookup));
                        lstQC.Add(ViewDetailToQC(dtl, SearchControlType.Text));
                    }
                    else
                    {
                        lstQC.Add(ViewDetailToQC(dtl));
                    }
                }
            }
            string cfgPath = Path.Combine(Application.StartupPath, "Config", "SearchCondition.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(cfgPath);
            if (ds.Tables.Count > 0) 
            {
                foreach (DataRow dr in ds.Tables[0].Rows) 
                {
                    lstQC.Add(RowToQC(dr));
                }
            }
            return lstQC;
        }
    }
}
