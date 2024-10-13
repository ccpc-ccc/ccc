using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Cfg;

namespace YF.MWS.Metadata.Query
{
    public class TopWeightQuery
    {
        //private List<SWeightViewDtl> columns = null;
        /// <summary>
        /// 需要显示的列集合
        /// </summary>
        /*public List<SWeightViewDtl> Columns
        {
            get { return columns; }
            set { columns = value; }
        }*/

        private string condition;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        private int topN;

        public int TopN
        {
            get { return topN; }
            set { topN = value; }
        }
        //public bool StartBatchWeight { get; set; }
        private bool startWeightPay;
        /// <summary>
        /// 开启磅单收费功能
        /// </summary>
        public bool StartWeightPay
        {
            get { return startWeightPay; }
            set { startWeightPay = value; }
        }
    }
}
