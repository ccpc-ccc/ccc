using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class FontCfg
    {
        public string FamilyName { get; set; }
        public float FontSize { get; set; }
        public FontStyle Style { get; set; }

        public FontCfg() 
        {
            FamilyName = "宋体";
            FontSize = 12;
            Style = FontStyle.Regular;
        }
    }
}
