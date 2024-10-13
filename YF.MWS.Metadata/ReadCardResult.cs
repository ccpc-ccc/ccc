using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata
{
    /// <summary>
    /// 读卡结果
    /// </summary>
    public class ReadCardResult
    {
        /// <summary>
        /// 卡Id
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 识别时间
        /// </summary>
        public DateTime RecognitionTime { get; set; }
    }
}
