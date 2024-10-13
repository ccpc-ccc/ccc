using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.CarPlate
{
    public class PlateInfo
    {
        private uint deviceID;

        public uint DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }
        private string strIP;

        public string IP
        {
            get { return strIP; }
            set { strIP = value; }
        }
        private string strNum;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string Num
        {
            get { return strNum; }
            set { strNum = value; }
        }

        private string strColor;

        public string Color
        {
            get { return strColor; }
            set { strColor = value; }
        }
    }
}
