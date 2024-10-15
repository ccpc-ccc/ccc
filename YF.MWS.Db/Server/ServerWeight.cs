using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.Utility.Metadata;

namespace YF.MWS.Db.Server
{
    /// <summary>
    /// 向服务器发送数据的实体类
    /// </summary>
    public class ServerWeight {
        /// <summary>
        /// 进料单编号
        /// </summary>
        public string jld { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string clmc { get; set; }
        /// <summary>
        /// 材料编码
        /// </summary>
        public string ycllx { get; set; }
        /// <summary>
        /// 材料规格
        /// </summary>
        public string clgg { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string gysmc { get; set; }
        /// <summary>
        /// 批次编号
        /// </summary>
        public string pc { get; set; }
        /// <summary>
        /// 进场时间
        /// </summary>
        public DateTime jcsj { get; set; }
        /// <summary>
        /// 进场称重
        /// </summary>
        public decimal jccz { get; set; }
        /// <summary>
        /// 存放料仓
        /// </summary>
        public string lcmc { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string cph { get; set; }
        /// <summary>
        /// 司磅员
        /// </summary>
        public string cby { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string contractnumber { get; set; }
        /// <summary>
        /// 合同标识
        /// </summary>
        public string contractid { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }
        /// <summary>
        /// 出场时间
        /// </summary>
        public DateTime cssj { get; set; }
        /// <summary>
        /// 出场称重
        /// </summary>
        public decimal cccz { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal jz { get; set; }
    }
    public class ServerWeightOut {
        /// <summary>
        /// 进料单编号
        /// </summary>
        public string jld { get; set; }
        /// <summary>
        /// 出厂时间
        /// </summary>
        public DateTime cssj { get; set; }
        /// <summary>
        /// 出厂称重
        /// </summary>
        public decimal cccz { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public decimal jz { get; set; }
    }
    public class ServerFile {
        public string jld { get; set; }
        public byte[] files { get; set; }
    }
}
