using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Db
{
    public class DataEntry:BWeight,IKeyCode
    {

        public decimal D0 { get; set; }
        public decimal D1 { get; set; }
        public decimal D2 { get; set; }
        public decimal D3 { get; set; }
        public decimal D4 { get; set; }
        public decimal D5 { get; set; }
        public decimal D6 { get; set; }
        public decimal D7 { get; set; }
        public decimal D8 { get; set; }
        public decimal D9 { get; set; }

        public string S0 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
        public string S6 { get; set; }
        public string S7 { get; set; }
        public string S8 { get; set; }
        public string S9 { get; set; }
        //public string S10 { get; set; }
        //public string S11 { get; set; }
        //public string S12 { get; set; }
        //public string S13 { get; set; }
        //public string S14 { get; set; }
        //public string S15 { get; set; }

        string IKeyCode.Key
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        string IKeyCode.Code
        {
            get { return string.Empty; }
        }
    }
}
