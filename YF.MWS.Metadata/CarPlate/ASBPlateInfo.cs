using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata.CarPlate
{
    public class ASBPlateInfo
    {
        private string strIP;

        public string IP
        {
            get { return strIP; }
            set { strIP = value; }
        }
        private string strNum;

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

        private int nVehicleColor;

        public int VehicleColor
        {
            get { return nVehicleColor; }
            set { nVehicleColor = value; }
        }

        private int nAlarmType;

        public int AlarmType
        {
            get { return nAlarmType; }
            set { nAlarmType = value; }
        }

        private int nCapTime;

        public int CapTime
        {
            get { return nCapTime; }
            set { nCapTime = value; }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private BFile file;

        public BFile File
        {
            get { return file; }
            set { file = value; }
        }

    }
}
