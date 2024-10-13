using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.Utility.IO;
using YF.Utility.Log;
using YF.MWS.Util;
using System.Windows.Forms;
using System.ServiceModel;
using YF.MWS.Client.DataService.Interface;
using System.Threading;
using YF.MWS.Metadata.Partner;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.Utility;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.SQliteService.Remote;

namespace YF.MWS.Win.Core
{
    public class SimulateWeight {

        private int startSimulate = 0;//当前重量
        private int endSimulate = 0;  //最大重量
        private int stabilizeSimulate = 0;//重量稳定的时间
        private int stabilizeSimulate2 = 0;
        private int flowSimulate = 0;
        /// <summary>
        /// 虚拟称重
        /// </summary>
        public int run() {
            Random ran = new Random();
            if (flowSimulate == 0) {
                if (endSimulate <= 0) endSimulate = ran.Next(100, 99999);
                if (startSimulate < endSimulate) {
                    if (startSimulate < 100)
                        startSimulate += ran.Next(0, 100);
                    else
                        startSimulate += ran.Next(0, startSimulate);
                } else if (startSimulate >= endSimulate) {
                    if (stabilizeSimulate <= 0) stabilizeSimulate = ran.Next(6, 19);
                    if (stabilizeSimulate > stabilizeSimulate2) {
                        stabilizeSimulate2 += 1;
                    } else {
                        flowSimulate = 1;
                        stabilizeSimulate = 0;
                        stabilizeSimulate2 = 0;
                    }
                }
            } else {
                if (startSimulate > 0) {
                    if (startSimulate <= 100)
                        startSimulate -= ran.Next(0, 100);
                    else
                        startSimulate -= ran.Next(0, startSimulate);
                    if (startSimulate < 0) startSimulate = 0;
                } else if (startSimulate <= 0) {
                    if (stabilizeSimulate <= 0) stabilizeSimulate = ran.Next(6, 19);
                    if (stabilizeSimulate > stabilizeSimulate2) {
                        stabilizeSimulate2 += 1;
                    } else {
                        flowSimulate = 0;
                        endSimulate = 0;
                        stabilizeSimulate = 0;
                        stabilizeSimulate2 = 0;
                    }
                }
            }
            return startSimulate;
        }
    }
}
