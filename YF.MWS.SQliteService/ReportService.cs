using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Client.DataService.Interface;
using System.Data;
using YF.MWS.Util;
using YF.MWS.Db;
using YF.Utility.Data;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Query;
using YF.Utility;
using YF.Data.NHProvider;
using YF.MWS.BaseMetadata;
using System.Data.SqlClient;
using YF.MWS.Metadata.Cfg;
using YF.Utility.IO;
using System.IO;
using YF.Utility.Configuration;
using System.Windows.Forms;
using YF.MWS.Metadata.Transfer;
using YF.Utility.Serialization;
using YF.Utility.Metadata;
using YF.Data.NHProvider.Metadata;
using YF.MWS.Metadata.Dto;

namespace YF.MWS.SQliteService
{
    public class ReportService :BaseService, IReportService
    {
        private IMasterService masterService = new MasterService();
        private IFileService fileService = new FileService();
        private SysCfg GetCfg()
        {
            SysCfg cfg = null;
            if (cfg == null)
            {
                string xmlPath = Path.Combine(Application.StartupPath, "SysCfg.xml");
                cfg = null;
                cfg = XmlUtil.Deserialize<SysCfg>(xmlPath);
            }
            return cfg;
        }
        private void SetFileToWeight(DataTable dtWeight, string weightId) 
        {
            if (dtWeight == null || dtWeight.Rows == null || dtWeight.Rows.Count == 0)
                return;
            bool loadImageWithRemote = false;
            string serverUrl = string.Empty;
            int maxCount=8;
            SysCfg cfg = GetCfg();
            if (cfg!=null && cfg.Transfer != null)
            {
                serverUrl = cfg.Transfer.ServerUrl;
            }
            if (cfg != null && cfg.Weight != null)
            {
                loadImageWithRemote = cfg.Weight.StartLoadImageWithRemote;
            }
            List<BFile> lstFile = new List<BFile>();
            if (loadImageWithRemote)
            {
                TPageResult result = fileService.GetListFromRemote(serverUrl, weightId);
                if (result != null && result.Code == (int)ResultCode.Success && result.Rows != null)
                {
                    lstFile = result.Rows.ToString().JsonDeserialize<List<BFile>>();
                    if (lstFile != null && lstFile.Count > 0)
                    {
                        lstFile = lstFile.FindAll(c => c.BusinessType == FileBusinessType.Graphic.ToString());
                    }
                }
            }
            else
            {
                lstFile = fileService.Get(weightId, FileBusinessType.Graphic);
            }
            string columnName;
            for (int i = 0; i < maxCount; i++) 
            {
                columnName = "图片" + (i + 1).ToString();
                if (!dtWeight.Columns.Contains(columnName))
                {
                    dtWeight.Columns.Add(columnName);
                }
            }
            if (dtWeight!=null && dtWeight.Rows.Count>0) 
            {
                if (lstFile == null) 
                {
                    lstFile = new List<BFile>();
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                    lstFile.Add(new BFile() { FileUrl = "test.png" });
                }
                if (lstFile != null && lstFile.Count > 0)
                {
                    int length = lstFile.Count;
                    for (int i = 0; i < length; i++)
                    {
                        columnName = "图片" + (i + 1).ToString();
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            if (loadImageWithRemote)
                            {
                                string url = string.Format("{0}{1}", serverUrl, lstFile[i].FileUrl);
                                dtWeight.Rows[0][columnName] = url;
                            }
                            else
                            {
                                dtWeight.Rows[0][columnName] = Path.Combine(Application.StartupPath, lstFile[i].FileUrl);
                            }
                        }
                    }
                }
            }
        }
        private void SetDecimalToUpper(DataTable dtWeight, string columnName) {
            string newColumn = columnName + "_Upper";
            if (dtWeight == null || dtWeight.Rows == null || dtWeight.Rows.Count == 0 || !dtWeight.Columns.Contains(columnName)|| dtWeight.Columns.Contains(newColumn)) return;
            dtWeight.Columns.Add(newColumn);
            dtWeight.Columns[newColumn].Caption = dtWeight.Columns[columnName].Caption + "大写";
            dtWeight.Rows[0][newColumn] = YF.MWS.Util.Utility.NumToRMB(dtWeight.Rows[0][columnName].ToDecimal());
        }
        private void SetDecimalToChinese(DataTable dtWeight, string columnName) {
            string newColumn = columnName + "_Upper";
            if (dtWeight == null || dtWeight.Rows == null || dtWeight.Rows.Count == 0 || !dtWeight.Columns.Contains(columnName)|| dtWeight.Columns.Contains(newColumn)) return;
            dtWeight.Columns.Add(newColumn);
            dtWeight.Columns[newColumn].Caption = dtWeight.Columns[columnName].Caption + "大写";
            dtWeight.Rows[0][newColumn] = YF.MWS.Util.Utility.NumToChinese(dtWeight.Rows[0][columnName].ToDecimal());
        }
        private string GetFilterExpression(DataTable dtWeight,List<QueryCondition> lstExtendCondition) 
        {
            StringBuilder sbCondition = new StringBuilder();
            sbCondition.Append("1=1");
            foreach (QueryCondition qc in lstExtendCondition) 
            {
                if (dtWeight.Columns.Contains(qc.Caption))
                {
                    sbCondition.AppendFormat(" and [{0}] like '%{1}%' ", qc.Caption, qc.Input);
                }
            }
            return sbCondition.ToString();
        }
        private DataTable GetFilterTable(DataTable dtWeight, List<QueryCondition> lstExtendCondition) 
        {
            DataTable dtTarget = dtWeight.Clone();
            DataRow[] drs;
            drs = dtWeight.Select(GetFilterExpression(dtWeight,lstExtendCondition));
            if (drs != null && drs.Length > 0) 
            {
                foreach (DataRow dr in drs) 
                {
                    dtTarget.ImportRow(dr);
                }
            }
            return dtTarget;
        }
        private string GetOverWeightExp(DataRow dr,string selfUnit) 
        {
            int overWeightState = dr["OverWeightState"].ToInt();
            decimal overWeight = UnitUtil.GetValue("Ton", selfUnit, dr["OverWeight"].ToDecimal());
            string exp = "未超载";
            if (overWeightState == 1) 
            {
                exp = "超载:" + overWeight + " "+ selfUnit;
            }
            return exp;
        }
        private string GetMaxWeightExt(DataRow dr) 
        {
            string exp;
            exp=string.Format("轴数:{0};限重:{1}吨",dr["AxleCount"].ToInt(),dr["MaxWeight"].ToDecimal());
            return exp;
        }
        private void InitTable(DataTable dtWeight) 
        {
            string selfUnit = AppSetting.GetValue("selfUnit");
            if (string.IsNullOrEmpty(selfUnit)) 
            {
                selfUnit = "KG";
            }
            if (dtWeight != null && dtWeight.Rows.Count > 0) 
            {
                string columnOverWeightExp = "OverWeightExp";
                string columnMaxWeightExp = "MaxWeightExp";
                if (!dtWeight.Columns.Contains(columnOverWeightExp)) 
                {
                    dtWeight.Columns.Add(columnOverWeightExp);
                }
                if (!dtWeight.Columns.Contains(columnMaxWeightExp))
                {
                    dtWeight.Columns.Add(columnMaxWeightExp);
                }
                foreach (DataRow dr in dtWeight.Rows) 
                {
                    dr[columnOverWeightExp] = GetOverWeightExp(dr, selfUnit);
                    dr[columnMaxWeightExp] = GetMaxWeightExt(dr);
                }
            }
        }
        public ReportService() 
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                service = ServiceInitialization.DbService;
            }
        }
        #region IReportService 成员

        public bool Delete(string templateId) 
        {
            string sql;
            sql = string.Format("delete from S_ReportTemplate where Id='{0}'", templateId);
            //sql = string.Format("update S_ReportTemplate set RowState={1} where TemplateId='{0}'", templateId,(int)RowState.Delete);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            { 
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else
            {
                return service.ExecuteNonQuery(sql);
            } 
        }

        public SReportTemplate Get(string templateId)
        {
            SReportTemplate report = new SReportTemplate();
            string sql; 
            DataTable dt;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sql = string.Format(@"select Id, ParentId,OrderNo, ViewId,TemplateType, ReportType,SubReportType, TemplateName, TemplateUrl, SearchControl, IsDefault, 
                                   CreaterId, RowState, CreateTime, UpdaterId, UpdateTime,DataSourceSql from S_ReportTemplate where Id='{0}'", templateId);
                dt = sqliteDb.ExecuteDataTable(sql);
            }
            else 
            {
                sql = string.Format(@"select Id, ParentId, OrderNo,ViewId,TemplateType, ReportType, SubReportType,TemplateName, TemplateContent, SearchControl, IsDefault, 
                                   CreaterId, RowState, CreateTime, UpdaterId, UpdateTime,DataSourceSql from S_ReportTemplate  where Id='{0}'", templateId);
                dt = service.GetDataTable(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                report = TableHelper.RowToEntity<SReportTemplate>(dt.Rows[0]);
            }
            return report;
        }

        public SReportTemplate GetDefaultTemplate(DocumentType type)
        {
            SReportTemplate report = new SReportTemplate();
            string sql;
            sql = string.Format(@"select Id,TemplateType, ParentId, ViewId, ReportType, TemplateName, TemplateUrl, 
                                   SearchControl, IsDefault, CreaterId, RowState, CreateTime, UpdaterId, UpdateTime 
                                     from S_ReportTemplate where IsDefault=1 and TemplateType='Document' and ReportType='{0}' ", type.ToString());
            DataTable dt;
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
                report = TableHelper.RowToEntity<SReportTemplate>(dt.Rows[0]);
            }
            return report;
        }

        public SReportTemplate GetTemplate(string controlName)
        {
            SReportTemplate report = new SReportTemplate();
            string sql;
            sql = string.Format(@"select Id, ParentId, ViewId, ReportType, TemplateName, TemplateUrl, 
                                            SearchControl, IsDefault, CreaterId, RowState, CreateTime, UpdaterId, UpdateTime
                                            from S_ReportTemplate where SearchControl='{0}'", controlName);
            DataTable dt;
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
                report = TableHelper.RowToEntity<SReportTemplate>(dt.Rows[0]);
            }
            return report;
        }

        public List<QReportTemplate> GetTemplateList(TemplateType type)
        {
            List<QReportTemplate> lst = new List<QReportTemplate>();
            string sql;
            sql = string.Format(@"select Id, ParentId, OrderNo,ViewId,TemplateType, SubReportType,ReportType, TemplateName, TemplateUrl, SearchControl, 
                                       IsDefault, CreaterId, RowState, CreateTime, UpdaterId, UpdateTime,DataSourceSql from S_ReportTemplate 
                                        where TemplateType='{0}' order by OrderNo asc", type.ToString());
            DataTable dt;
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
                lst = TableHelper.TableToList<QReportTemplate>(dt);
            }
            return lst;
        }

        public List<QReportTemplate> GetTemplateList(TemplateType type, string reportType)
        {
            List<QReportTemplate> lst = new List<QReportTemplate>();
            string sql;
            sql = string.Format(@"select Id, ParentId, OrderNo,ViewId, TemplateType,ReportType, TemplateName, TemplateUrl, SearchControl, 
                                       IsDefault, CreaterId, RowState, CreateTime, UpdaterId, UpdateTime from S_ReportTemplate 
                                        where TemplateType='{0}' and ReportType='{1}' order by OrderNo asc", type.ToString(), reportType);
            DataTable dt;
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
                lst = TableHelper.TableToList<QReportTemplate>(dt);
            }
            return lst;
        }

        public QWeight GetQWeight(string weightId)
        {
            QWeight weight = new QWeight();
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(@"select a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,a.RealCharge,a.MaxWeight,a.OverWeight,
                                                 a.OverWeightState,a.FinishTime,a.PrintCount,a.AxleCount,
                                                a.MeasureUnit,a.Remark as Remarks,b.FullName as Weighter,a.CreateTime,a.WeightNo,a.CarNo,d.CustomerName,e.MaterialName,
                                                f.WeightTime as TareWeightTime,g.WeightTime as GrossWeightTime
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id 
                                                left join S_Car c on a.CarId=c.Id
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id 
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={1} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={2}  
                                                where a.Id='{0}'", weightId, (int)WeightType.Tare, (int)WeightType.Gross);
            DataTable dt = null;
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dt = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else 
            {
                dt = service.GetDataTable(sbSql.ToString()); 
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                weight = TableHelper.RowToEntity<QWeight>(dt.Rows[0]);
                //List<SCode> lstCode = masterService.GetSubList(SysCode.AxleWeight.ToString());
                //WeightUtil.Calculate(weight, lstCode);
            }
            return weight;
        }

        public DataSet GetFinance(string viewId, string weightId)
        {
            DataSet ds = new DataSet();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            string condition = string.Format("a.Id='{0}'", weightId);
            List<SCode> lstMeasureType = masterService.GetSubList(SysCode.MeasureType.ToString());
            List<SCode> lstOrderSource = masterService.GetSubList(SysCode.OrderSource.ToString());
            SCode code = null;
            sbSql.AppendFormat("select a.ControlName,a.ControlType,a.FullName,a.FieldName from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            dtViewDtl = GetTable(sbSql.ToString());
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("磅单号"); 
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            dtWeight.Columns.Add("司磅员");
            dtWeight.Columns.Add("皮重时间", typeof(DateTime));
            dtWeight.Columns.Add("毛重时间", typeof(DateTime));
            foreach (DataRow dr in dtViewDtl.Rows)
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["ControlName"].ToObjectString()))
                    {
                        dtWeight.Columns.Add(dr["ControlName"].ToObjectString());
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数"))
            {
                //dtWeight.Columns.Add("打印次数");
            }
            if (!dtWeight.Columns.Contains("结算单号"))
            {
                dtWeight.Columns.Add("结算单号");
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.Id,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,
                                               a.RealCharge,a.MeasureUnit,a.OrderSource as '磅单来源',
                                                a.Remark,a.WeighterName,a.FinishTime as '完成日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                f.WeightTime  as '皮重时间',g.WeightTime  as '毛重时间',h.CustomerName as 'ReceiverId',i.CustomerName as 'DeliveryId',j.SettleNo as '结算单号'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1} 
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                  left join B_WeightExt j on a.Id=j.Id 
                                                 where {2};",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition);
            dtMain = GetTable(sbSql.ToString());
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.Id   from B_Weight a left join S_User b on a.WeighterId=b.UserId  
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1} 
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                 where {2}",
                                    (int)WeightType.Tare, (int)WeightType.Gross, condition);
            sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});", sbSql);
            dtExtend = GetTable(sbAttrSql.ToString());
            DataRow[] drExtends;
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                    if (code != null)
                    {
                        drMain["MeasureType"] = code.ItemCaption;
                    }
                    code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                    if (code != null)
                    {
                        drMain["磅单来源"] = code.ItemCaption;
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (dtExtend != null && dtExtend.Rows.Count > 0)
                    {
                        drExtends = dtExtend.Select(string.Format("[WeightId]='{0}'", drMain["WeightId"]));
                        foreach (DataRow dr in drExtends)
                        {
                            columnName = string.Format("{0}", dr["AttributeName"]);
                            if (dtWeight.Columns.Contains(columnName))
                            {
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            }
            if (lstDetail != null && lstDetail.Count > 0)
            {
                lstDetail = lstDetail.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            YF.MWS.Util.Utility.InitRow(dtWeight);
            ds.Tables.Add(dtWeight);
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单";
            }
            return ds;
        }

        public DataSet GetWeight(string viewId, string weightId="")
        { 
            DataTable dtWeight = null;
            DataSet ds=new DataSet();
            string condition = "";
            if (weightId != "") {
                condition = string.Format("and a.Id='{0}'", weightId);
            }
            WeightQueryService weightQueryService = new WeightQueryService();
            dtWeight = weightQueryService.GetTopListTable(new TopWeightQuery() { TopN=1,Condition= condition });
            YF.MWS.Util.Utility.InitRow(dtWeight);
            SetFileToWeight(dtWeight, weightId);
            SetDecimalToUpper(dtWeight, "d1");
            SetDecimalToChinese(dtWeight, "SuttleWeight");
            ds.Tables.Add(dtWeight);
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单";
            }
            return ds;
        }

        public DataSet GetWeightSearch(string viewId,WeightQueryCondition qc)
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            string condition = QueryUtil.GetWeightCondition(qc);
            DataSet ds = new DataSet();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMaterialType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.MaterialType);
            List<SCode> lstMeasureType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.MeasureType);
            List<SCode> lstOrderSource = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.OrderSource);
            List<SCode> lstWarehBizType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.WarehBizType);
            List<SCode> lstPayType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.PayType);
            SCode code = null;
            sbSql.AppendFormat("select a.ControlName,a.ControlType,a.FullName,a.FieldName from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtViewDtl = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtViewDtl = service.GetDataTable(sbSql.ToString());
            }
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("ViewId");
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("磅单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("开始日期", typeof(DateTime));
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            dtWeight.Columns.Add("皮重时间", typeof(DateTime));
            dtWeight.Columns.Add("毛重时间", typeof(DateTime));
            dtWeight.Columns.Add("司磅员");
            dtWeight.Columns.Add("毛重司磅员");
            dtWeight.Columns.Add("皮重司磅员");
            //dtWeight.Columns.Add("客户余额", typeof(decimal));
            foreach (DataRow dr in dtViewDtl.Rows)
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                        }
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                        }
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数"))
            {
                dtWeight.Columns.Add("打印次数");
            }
            sbSql.Clear();
            string payColumn = "CAST(n.PayType as varchar) as PayType";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver)
            {
                payColumn = "convert(varchar,n.PayType) PayType";
            }
            sbSql.AppendFormat(@"select a.Id,a.ViewId,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,
                                               a.RegularCharge,a.CustomCharge,a.MeasureUnit, a.OrderSource as '磅单来源',a.DriverName,a.RealCharge,a.ImpurityWeight,
                                                a.Remark,a.WeighterName,a.CreateTime as '开始日期',a.FinishTime as '完成日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',
                                                d.CustomerName as 'CustomerId',d.BalanceAmount as '当前客户余额',a.CustomerBalance,a.WarehBizType,a.WeighterName as '司磅员',
                                                e.MaterialName as 'MaterialId',e.MaterialType,a.MeasureType,a.PrintCount as '打印次数',a.WaybillNo as '运单号',a.MaterialModel,
                                                f.WeightTime  as '皮重时间',f.WeighterName as '皮重司磅员',g.WeightTime  as '毛重时间',g.WeighterName as '毛重司磅员',
                                                 h.CustomerName as 'ReceiverId',i.CustomerName as 'DeliveryId',
                                                j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',m.WarehName as 'WarehId',l.CustomerName as TransferId,{3}
                                                from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id 
                                                left join S_Customer l on a.TransferId=l.Id 
                                                left join S_Wareh m on a.WarehId=m.Id 
                                                left join B_Pay n on a.WeightId=n.RefId  and n.PayBizType='{4}' 
                                                 where 1=1 {2}  order by a.FinishTime desc;",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition, payColumn,PayBizType.Weight.ToString());
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtMain = service.GetDataTable(sbSql.ToString());
            }
            List<WeightExtend> extends = null;
            List<WeightExtend> extendFind = null;
            WeightExtend find = null;
            sbSql.Clear();
            List<string> weightIds=new List<string>();
            List<QWeight> weights = TableHelper.TableToList<QWeight>(dtMain);
            if (weights != null)
                weightIds = weights.Select(c => c.Id).Distinct().ToList();
            string sql = string.Format(@"select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a 
                                                           inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0})", SqlConditionUtil.GetArrayIn(weightIds));
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                extends = sqliteDb.GetObjectList<WeightExtend>(sql);
            }
            else
            {
                extends = service.GetObjectList<WeightExtend>(sql);
            }
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    if (lstMaterialType != null && lstMaterialType.Count > 0)
                    {
                        code = lstMeasureType.Find(c => c.ItemCode == drMain["MaterialType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["MaterialType"] = code.ItemCaption;
                        }
                    }
                    if (lstMeasureType != null && lstMeasureType.Count > 0)
                    {
                        code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["MeasureType"] = code.ItemCaption;
                        }
                    }
                    if (lstPayType != null && lstPayType.Count > 0)
                    {
                        code = lstPayType.Find(c => c.ItemValue == drMain["PayType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["PayType"] = code.ItemCaption;
                        }
                    }
                    if (lstWarehBizType != null && lstWarehBizType.Count > 0)
                    {
                        code = lstWarehBizType.Find(c => c.ItemCode == drMain["WarehBizType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["WarehBizType"] = code.ItemCaption;
                        }
                    }
                    if (lstOrderSource != null)
                    {
                        code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                        if (code != null)
                        {
                            drMain["磅单来源"] = code.ItemCaption;
                        }
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (extends != null && extends.Count > 0)
                    {
                        extendFind = extends.FindAll(c => c.WeightId == drMain["WeightId"].ToObjectString());
                        if (extendFind != null && extendFind.Count > 0)
                        {
                            foreach (DataColumn dc in dtWeight.Columns)
                            {
                                find = extendFind.Find(c => c.FieldName.ToUpper() == dc.ColumnName.ToUpper());
                                if (find == null)
                                    continue;
                                if (!string.IsNullOrEmpty(find.AttributeValue))
                                {
                                    drWeight[dc] = find.AttributeValue;
                                }
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            }
            if (lstDetail != null && lstDetail.Count > 0)
            {
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            YF.MWS.Util.Utility.InitRow(dtWeight);
            ds.Tables.Add(dtWeight);
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单";
            }
            return ds;
        }

        public DataSet GetWeightSearch(string viewId, string condition, string conditionTareTime, string conditionGrossTime, List<QueryCondition> lstExtendCondition) 
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            DataSet ds = new DataSet();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.MeasureType);
            List<SCode> lstOrderSource = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.OrderSource);
            List<SCode> lstWarehBizType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.WarehBizType);
            List<SCode> lstPayType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.PayType);
            SCode code = null;
            sbSql.AppendFormat("select a.[ControlName],a.[ControlType],a.[FullName],a.[FieldName] from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtViewDtl = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else 
            {
                dtViewDtl = service.GetDataTable(sbSql.ToString());
            }
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("ViewId");
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("磅单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("开始日期", typeof(DateTime));
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            dtWeight.Columns.Add("皮重时间", typeof(DateTime));
            dtWeight.Columns.Add("毛重时间", typeof(DateTime));
            dtWeight.Columns.Add("毛重司磅员");
            dtWeight.Columns.Add("皮重司磅员");
            //dtWeight.Columns.Add("客户余额", typeof(decimal));
            foreach (DataRow dr in dtViewDtl.Rows) 
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["ControlName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString(),typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString());
                        }
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    { 
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                        }
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数")) 
            {
                dtWeight.Columns.Add("打印次数");
            }
            sbSql.Clear();
            string payColumn = "CAST(n.PayType as varchar) as PayType";
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlserver) 
            {
                payColumn = "convert(varchar,n.PayType) PayType";
            }
            sbSql.AppendFormat(@"select a.Id as WeightId,a.ViewId,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,
                                               a.RegularCharge,a.MeasureUnit, a.OrderSource as '磅单来源',a.DriverName,a.RealCharge,a.ImpurityWeight,
                                                a.Remark,a.WeighterName,a.CreateTime as '开始日期',a.FinishTime as '完成日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',
                                                d.CustomerName as 'CustomerId',d.BalanceAmount as '当前客户余额',a.CustomerBalance,a.WarehBizType,
                                                e.MaterialName as 'MaterialId',a.MeasureType,a.PrintCount as '打印次数',a.WaybillNo as '运单号',a.MaterialModel,
                                                f.WeightTime  as '皮重时间',f.WeighterName as '皮重司磅员',g.WeightTime  as '毛重时间',g.WeighterName as '毛重司磅员',h.CustomerName as 'ReceiverId',i.CustomerName as 'DeliveryId',
                                                j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',m.WarehName as 'WarehId',{5}
                                                from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id 
                                                left join S_Wareh m on a.WarehId=m.Id 
                                                left join B_Pay n on a.WeightId=n.RefId
                                                 where {2} {3} {4} order by a.FinishTime desc;",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition, conditionTareTime, conditionGrossTime, payColumn);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else 
            {
                dtMain = service.GetDataTable(sbSql.ToString());
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select  a.Id   from B_Weight a   where {0}", condition);
            sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});", sbSql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtExtend = sqliteDb.ExecuteDataTable(sbAttrSql.ToString());
            }
            else 
            {
                dtExtend = service.GetDataTable(sbAttrSql.ToString());
            }
            DataRow[] drExtends;
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    if (lstMeasureType != null && lstMeasureType.Count > 0)
                    {
                        code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["MeasureType"] = code.ItemCaption;
                        }
                    }
                    if (lstPayType != null && lstPayType.Count > 0)
                    {
                        code = lstPayType.Find(c => c.ItemValue == drMain["PayType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["PayType"] = code.ItemCaption;
                        }
                    }
                    if (lstWarehBizType != null && lstWarehBizType.Count > 0)
                    {
                        code = lstWarehBizType.Find(c => c.ItemCode == drMain["WarehBizType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["WarehBizType"] = code.ItemCaption;
                        }
                    }
                    if (lstOrderSource != null)
                    {
                        code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                        if (code != null)
                        {
                            drMain["磅单来源"] = code.ItemCaption;
                        }
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (dtExtend != null && dtExtend.Rows.Count > 0)
                    {
                        drExtends = dtExtend.Select(string.Format("[WeightId]='{0}'", drMain["WeightId"]));
                        foreach (DataRow dr in drExtends)
                        {
                            columnName = string.Format("{0}", dr["AttributeName"]);
                            if (dtWeight.Columns.Contains(columnName))
                            {
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            } 
            if (lstDetail != null && lstDetail.Count > 0)
            {
                lstDetail = lstDetail.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            YF.MWS.Util.Utility.InitRow(dtWeight);
            if (lstExtendCondition == null || lstExtendCondition.Count == 0)
            {
                ds.Tables.Add(dtWeight);
            }
            else 
            {
                DataTable dtTarget = GetFilterTable(dtWeight, lstExtendCondition);
                ds.Tables.Add(dtTarget);
            }
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单"; 
            }
            return ds;
        }

        public DataSet GetWeightSearch(string viewId, string condition, string conditionTareTime, string conditionGrossTime, List<QueryCondition> lstExtendCondition, QPage page)
        {
            List<SWeightViewDtl> lstDetail = new List<SWeightViewDtl>();
            DataSet ds = new DataSet();
            DataTable dtWeight = new DataTable();
            DataTable dtViewDtl = new DataTable();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbAttrSql = new StringBuilder();
            DataTable dtMain = null;
            DataTable dtExtend = null;
            List<SCode> lstMeasureType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.MeasureType);
            List<SCode> lstOrderSource = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.OrderSource);
            List<SCode> lstWarehBizType = MatadataUtil.GetSubCodeList(GlobalCacher.LstCode, SysCode.WarehBizType);
            SCode code = null;
            sbSql.AppendFormat("select a.[ControlName],a.[ControlType],a.[FullName],a.[FieldName] from S_WeightViewDtl a where ViewId='{0}' order by OrderNo", viewId);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                dtViewDtl = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                dtViewDtl = service.GetDataTable(sbSql.ToString());
            }
            lstDetail = TableHelper.TableToList<SWeightViewDtl>(dtViewDtl);
            dtWeight.Columns.Add("ViewId");
            dtWeight.Columns.Add("WeightId");
            dtWeight.Columns.Add("磅单号");
            dtWeight.Columns.Add("磅单来源");
            dtWeight.Columns.Add("开始日期", typeof(DateTime));
            dtWeight.Columns.Add("完成日期", typeof(DateTime));
            dtWeight.Columns.Add("皮重时间", typeof(DateTime));
            dtWeight.Columns.Add("毛重时间", typeof(DateTime));
            //dtWeight.Columns.Add("客户余额", typeof(decimal));
            foreach (DataRow dr in dtViewDtl.Rows)
            {
                if (dr["ControlType"].ToEnum<ControlType>() == ControlType.Extend)
                {
                    if (!dtWeight.Columns.Contains(dr["ControlName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["ControlName"].ToObjectString());
                        }
                    }
                }
                else
                {
                    //对于标准控件的列名用FieldName
                    if (!dtWeight.Columns.Contains(dr["FieldName"].ToObjectString()))
                    {
                        if (dr["FullName"].ToObjectString().Length > 0 && dr["FullName"].ToObjectString().EndsWith("WNumbericEdit"))
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString(), typeof(decimal));
                        }
                        else
                        {
                            dtWeight.Columns.Add(dr["FieldName"].ToObjectString());
                        }
                    }
                }
            }
            if (!dtWeight.Columns.Contains("打印次数"))
            {
                dtWeight.Columns.Add("打印次数");
            }
            sbSql.Clear();
            sbSql.AppendFormat(@"select count(1)
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                 left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id
                                                 where {2}{3} {4};",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition, conditionTareTime, conditionGrossTime);

            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                page.TotalRows = sqliteDb.ExecuteScalar(sbSql.ToString()).ToInt();
            }
            else
            {
                page.TotalRows = service.GetDataTable(sbSql.ToString()).Rows[0][0].ToInt();
            }
            sbSql.Clear();

            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sbSql.AppendFormat(@"select a.Id as WeightId,a.ViewId,a.GrossWeight,a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,a.WaybillNo,
                                               a.RegularCharge,a.MeasureUnit, a.OrderSource as '磅单来源',a.DriverName,a.RealCharge,a.ImpurityWeight,
                                                a.Remark,a.WeighterName,a.CreateTime as '开始日期',a.FinishTime as '完成日期',a.WeightNo as '磅单号',a.CarNo as 'CarId',
                                                d.CustomerName as 'CustomerId',d.BalanceAmount as '当前客户余额',a.CustomerBalance,a.WarehBizType,
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                f.WeightTime  as '皮重时间',g.WeightTime  as '毛重时间',h.CustomerName as 'ReceiverId',i.CustomerName as 'DeliveryId',
                                                j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',m.WarehName as 'WarehId'
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                 left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id
                                                left join S_Wareh m on a.WarehId=m.WarehId 
                                                 where {2}{3} {4} order by a.FinishTime desc limit {5},{6};",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition, conditionTareTime, conditionGrossTime, page.PageIndex * page.PageSize, page.PageSize);
                dtMain = sqliteDb.ExecuteDataTable(sbSql.ToString());
            }
            else
            {
                sbSql.AppendFormat(@"select * from (select a.Id as WeightId,a.ViewId,ROW_NUMBER() over(order by a.FinishTime asc) as 'RowNo',a.GrossWeight,
                                               a.SuttleWeight,a.TareWeight,a.NetWeight,a.UnitPrice,a.UnitCharge,a.WaybillNo,a.RealCharge,a.ImpurityWeight,
                                               a.RegularCharge,a.MeasureUnit, a.OrderSource as '磅单来源',a.DriverName,a.WarehBizType,
                                                a.Remark,a.WeighterName,a.CreateTime as '开始日期',a.FinishTime as '完成日期',
                                                a.WeightNo as '磅单号',a.CarNo as 'CarId',d.CustomerName as 'CustomerId',
                                                e.MaterialName as 'MaterialId',a.MaterialModel,a.MeasureType,a.PrintCount as '打印次数',
                                                f.WeightTime  as '皮重时间',g.WeightTime  as '毛重时间',h.CustomerName as 'ReceiverId',
                                                i.CustomerName as 'DeliveryId',j.CustomerName as 'SupplierId',k.CustomerName as 'ManufacturerId',
                                                m.WarehName as 'WarehId',d.BalanceAmount as '当前客户余额',a.CustomerBalance
                                                 from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                                 left join B_WeightExt c on a.WeightId=c.Id    
                                                left join S_Customer d on a.CustomerId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0}  
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1}  
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                left join S_Customer i on a.DeliveryId=i.Id 
                                                left join S_Customer j on a.SupplierId=j.Id
                                                left join S_Customer k on a.ManufacturerId=k.Id 
                                                left join S_Wareh m on a.WarehId=m.Id 
                                                 where {2}{3} {4})as Q where RowNo between {5} and {6};",
                                                (int)WeightType.Tare, (int)WeightType.Gross, condition, conditionTareTime, conditionGrossTime,
                                                page.PageIndex * page.PageSize + 1, (page.PageIndex + 1) * page.PageSize);
                dtMain = service.GetDataTable(sbSql.ToString());
            }
            sbSql.Clear();
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sbSql.AppendFormat(@"select  a.Id    from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                             left join B_WeightExt c on a.Id=c.Id    
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1} 
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                 where {2} order by a.FinishTime asc limit {3},{4}",
                                    (int)WeightType.Tare, (int)WeightType.Gross, condition, page.PageIndex * page.PageSize, page.PageSize);
                sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.d where a.WeightId in({0});", sbSql);
                dtExtend = sqliteDb.ExecuteDataTable(sbAttrSql.ToString());
            }
            else
            {
                sbSql.AppendFormat(@"select Id from (select  a.Id,ROW_NUMBER() over(order by a.FinishTime asc) as 'RowNo'   from B_Weight a left join S_User b on a.WeighterId=b.Id  
                                             left join B_WeightExt c on a.WeightId=c.Id    
                                                left join S_Customer d on a.ReceiverId=d.Id
                                                left join S_Material e on a.MaterialId=e.Id
                                                left join B_WeightDetail f on a.Id=f.WeightId and f.WeightType={0} 
                                                left join B_WeightDetail g on a.Id=g.WeightId and g.WeightType={1} 
                                                left join S_Customer h on a.ReceiverId=h.Id 
                                                 left join S_Customer i on a.DeliveryId=i.Id 
                                                 where {2}) as Q where RowNo between {3} and {4}",
                                    (int)WeightType.Tare, (int)WeightType.Gross, condition, page.PageIndex * page.PageSize + 1, (page.PageIndex + 1) * page.PageSize);
                sbAttrSql.AppendFormat("select a.WeightId,a.AttributeValue,b.AttributeName,b.FieldName from B_WeightAttribute a inner join S_Attribute b on a.AttributeId=b.Id where a.WeightId in({0});", sbSql);
                dtExtend = service.GetDataTable(sbAttrSql.ToString());
            }
            //MessageBox.Show(dtMain.Rows[0]["WaybillNo"].ToString());
            DataRow[] drExtends;
            DataRow drMain;
            DataRow drWeight;
            string columnName;
            if (dtMain != null)
            {
                for (int i = 0; i < dtMain.Rows.Count; i++)
                {
                    drMain = dtMain.Rows[i];
                    drWeight = dtWeight.NewRow();
                    if (lstMeasureType != null && lstMeasureType.Count > 0)
                    {
                        code = lstMeasureType.Find(c => c.ItemCode == drMain["MeasureType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["MeasureType"] = code.ItemCaption;
                        }
                    }
                    if (lstWarehBizType != null && lstWarehBizType.Count > 0)
                    {
                        code = lstWarehBizType.Find(c => c.ItemCode == drMain["WarehBizType"].ToObjectString());
                        if (code != null)
                        {
                            drMain["WarehBizType"] = code.ItemCaption;
                        }
                    }
                    if (lstOrderSource != null)
                    {
                        code = lstOrderSource.Find(c => c.ItemCode == drMain["磅单来源"].ToObjectString());
                        if (code != null)
                        {
                            drMain["磅单来源"] = code.ItemCaption;
                        }
                    }
                    for (int j = 0; j < dtMain.Columns.Count; j++)
                    {
                        columnName = dtMain.Columns[j].ColumnName;
                        if (dtWeight.Columns.Contains(columnName))
                        {
                            drWeight[columnName] = drMain[columnName];
                        }
                    }
                    if (dtExtend != null && dtExtend.Rows.Count > 0)
                    {
                        drExtends = dtExtend.Select(string.Format("[WeightId]='{0}'", drMain["WeightId"]));
                        foreach (DataRow dr in drExtends)
                        {
                            columnName = string.Format("{0}", dr["AttributeName"]);
                            if (dtWeight.Columns.Contains(columnName))
                            {
                                drWeight[columnName] = dr["AttributeValue"];
                            }
                        }
                    }
                    dtWeight.Rows.Add(drWeight);
                }
            }
            if (lstDetail != null && lstDetail.Count > 0)
            {
                lstDetail = lstDetail.FindAll(c => c.ControlType != null && c.ControlType == ControlType.Standard.ToString());
                foreach (DataColumn dc in dtWeight.Columns)
                {
                    SWeightViewDtl dtl = lstDetail.Find(c => c.FieldName == dc.ColumnName);
                    if (dtl != null && !string.IsNullOrEmpty(dtl.ControlName) && !dtWeight.Columns.Contains(dtl.ControlName))
                    {
                        dc.ColumnName = dtl.ControlName;
                    }
                }
            }
            YF.MWS.Util.Utility.InitRow(dtWeight);
            //MessageBox.Show(dtWeight.Rows[0]["运单号"].ToString());
            if (lstExtendCondition == null || lstExtendCondition.Count == 0)
            {
                ds.Tables.Add(dtWeight);
            }
            else
            {
                DataTable dtTarget = GetFilterTable(dtWeight, lstExtendCondition);
                ds.Tables.Add(dtTarget);
            }
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].TableName = "磅单";
            }
            return ds;
        }

        public bool Save(SReportTemplate template)
        {
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                string sql;
                sql = SqliteSqlUtil.GetSaveSql<SReportTemplate>(template, "S_ReportTemplate");
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            }
            else 
            {
                bool isSaved = false;
                isSaved = service.Save(template, template.Id);
                return isSaved;
            }
        }

        public void SetDefault(string templateId, DocumentType type)
        {
            List<string> lstSql = new List<string>();
            string sql;
            sql = string.Format("update S_ReportTemplate set IsDefault=0 where TemplateType='{1}' and ReportType='{0}'",
                                         type.ToString(),TemplateType.Document.ToString());
            lstSql.Add(sql);
            sql = string.Format("update S_ReportTemplate set IsDefault=1 where Id='{0}'", templateId);
            lstSql.Add(sql);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
            {
                sqliteDb.ExecuteNonQuery(lstSql);
            }
            else 
            {
                service.ExecuteNonQuery(lstSql);
            }
        }

        public bool UpdateDefaultView(string viewId)
        {
            string sql = string.Format(@"update S_ReportTemplate set ViewId='{0}' where IsDefault={1}", viewId, (int)DefaultStateType.IsDefault);
            if (CurrentClient.Instance.DataBase == DataBaseType.Sqlite)
                return sqliteDb.ExecuteNonQuery(sql) > 0;
            else
                return service.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
