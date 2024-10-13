using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    /// <summary>
    /// 磅单套打配置类
    /// Author:仇军
    /// Date:2014-12-20
    /// </summary>
    public class FormatPrintCfg
    {
        public string Title { get; set; }
        public float UnitPix { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float LineHeight { get; set; }
        public float LeftMargin { get; set; }
        public float TopMargin { get; set; }
        public float RightMargin { get; set; }
        public float BottomMargin { get; set; }
    }
}
