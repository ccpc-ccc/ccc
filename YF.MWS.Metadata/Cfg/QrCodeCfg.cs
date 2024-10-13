using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 二维码设置
    /// </summary>
    public class QrCodeCfg
    {
        /// <summary>
        /// 分隔符
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// 是否显示计量单位
        /// </summary>
        public bool ShowMeasureUnit { get; set; }
        //供应商|货物|规格|车牌号|毛重|皮重|净重|发矿量(自定收费控件)|盈亏(本次收费控件)|毛重时间|皮重时间|
        public bool ShowGrossWeight { get; set; }
        public int ShowGrossWeightIndex { get; set; }
        public bool ShowTareWeight { get; set; }
        public int ShowTareWeightIndex { get; set; }
        public bool ShowSuttleWeight { get; set; }
        public bool ShowWeightNo { get; set; }
        public bool ShowWeightId { get; set; }
        public bool ShowMaterial { get; set; }
        public bool ShowMaterialModel { get; set; }
        /// <summary>
        /// 显示车牌号
        /// </summary>
        public bool ShowCarNo { get; set; }
        public bool ShowRegularCharge { get; set; }
        /// <summary>
        /// 显示自定义收费
        /// </summary>
        public bool ShowCustomCharge { get; set; }
        public bool ShowCustomer { get; set; }
        public bool ShowCustomerBalance { get; set; }
        public bool ShowReceiver { get; set; }
        public bool ShowDeliver { get; set; }
        public bool ShowSupplier { get; set; }
        public bool ShowTransfer { get; set; }
        public bool ShowGrossWeightTime { get; set; }
        public bool ShowTareWeightTime { get; set; }
        /// <summary>
        /// 显示开始时间
        /// </summary>
        public bool ShowCreateTime { get; set; }
        /// <summary>
        /// 显示完成时间
        /// </summary>
        public bool ShowFinishTime { get; set; }
        /// <summary>
        /// 显示随机Id
        /// </summary>
        public bool ShowRandomId { get; set; }
        /// <summary>
        /// 毛重前缀
        /// </summary>
        public string ShowGrossWeightPrefix { get; set; }
        /// <summary>
        /// 皮重前缀
        /// </summary>
        public string ShowTareWeightPrefix { get; set; }
        /// <summary>
        /// 净重前缀
        /// </summary>
        public string ShowSuttleWeightPrefix { get; set; }
        public int ShowSuttleWeightIndex { get; set; }
        public int ShowWeightNoIndex { get; set; }
        public int ShowWeightIdIndex { get; set; }
        public int ShowMaterialIndex { get; set; }
        public int ShowMaterialModelIndex { get; set; }
        /// <summary>
        /// 显示车牌号
        /// </summary>
        public int ShowCarNoIndex { get; set; }
        public int ShowRegularChargeIndex { get; set; }
        /// <summary>
        /// 显示自定义收费
        /// </summary>
        public int ShowCustomChargeIndex { get; set; }
        public int ShowCustomerIndex { get; set; }
        public int ShowCustomerBalanceIndex { get; set; }
        public int ShowReceiverIndex { get; set; }
        public int ShowDeliverIndex { get; set; }
        public int ShowSupplierIndex { get; set; }
        public int ShowTransferIndex { get; set; }
        public int ShowGrossWeightTimeIndex { get; set; }
        public int ShowTareWeightTimeIndex { get; set; }
        /// <summary>
        /// 显示开始时间
        /// </summary>
        public int ShowCreateTimeIndex { get; set; }
        /// <summary>
        /// 显示完成时间
        /// </summary>
        public int ShowFinishTimeIndex { get; set; }
        public int ShowRandomIdIndex { get; set; }
        /// <summary>
        /// 磅单详情网址
        /// </summary>
        public string WeightUrl { get; set; }
    }
}
