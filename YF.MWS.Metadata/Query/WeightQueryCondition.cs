using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Query;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 磅单查询条件
    /// </summary>
    public class WeightQueryCondition
    {
        public WeightQueryCondition() 
        {
            WeightTime = WeightTimeType.FinishTime;
        }
        public WeightReportType ReportType { get; set; }
        public string WeightId { get; set; }
        public string ClientId { get; set; }
        public DateSummaryType DateSummary { get; set; }
        public WeightTimeType WeightTime { get; set; }

        public string CarNo { get; set; }
        public string CardNo { get; set; }

        public string CustomerName { get; set; }
        /// <summary>
        /// 计量类型
        /// </summary>
        public string MeasureType { get; set; }
        /// <summary>
        /// 超载
        /// </summary>
        public string OverWeightState { get; set; }

        /// <summary>
        /// 磅单号
        /// </summary>
        public string WeightNo { get; set; }

        /// <summary>
        /// 发货单位ID
        /// </summary>
        public string DeliveryId { get; set; }
        /// <summary>
        /// 收货单位ID
        /// </summary>
        public string ReceiverId { get; set; }
        /// <summary>
        /// 供货单位ID
        /// </summary>
        public string SupplierId { get; set; }
        /// <summary>
        /// 承运商Id
        /// </summary>
        public string TransferId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public string CompanyId { get; set; }

        public string MachineCode { get; set; }

        /// <summary>
        /// 物资ID
        /// </summary>
        public string MaterialId { get; set; }
        public string OrderSource { get; set; }

        public UserType UserType { get; set; }
        public RowState? RowState { get; set; }

        public FinishState? FinishState { get; set; }
        /// <summary>
        /// 结算状态
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 仓库类型 ChuKu出库  RuKu入库
        /// </summary>
        public string WarehBizType { get; set; }
        public string Remark { get; set; }
        public bool IsEmpty { get; set; }
        /// <summary>
        /// 开启磅单收费功能
        /// </summary>
        public bool StartWeightPay { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        /// <summary>
        /// 称重数据列设置信息
        /// </summary>
        public List<SWeightViewDtl> Columns { get; set; }
        /// <summary>
        /// 扩展控件输入的查询条件
        /// </summary>
        public List<QueryCondition> ExtendConditions { get; set; }
        public string Condtion { get; set; }
    }
}
