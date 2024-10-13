using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.CarPlate
{
    /// <summary>
    /// 车牌识别结果
    /// </summary>
    public class RecognitionResult
    {
        public string CarNo { get; set; }
        public DateTime RecognitionTime { get; set; }
    }
}
