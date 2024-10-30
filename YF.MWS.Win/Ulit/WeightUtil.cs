using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Partner;
using YF.MWS.Util;
using YF.Utility;
using YF.Utility.Configuration;

namespace YF.MWS.Win
{
    /// <summary>
    /// 称重工具类
    /// </summary>
    public class WeightUtil
    {

        /// <summary>
        /// 重量单位换算
        /// </summary>
        /// <param name="value"></param>
        /// <param name="deviceOneUnit"></param>
        /// <param name="softOneUnit"></param>
        /// <returns></returns>
        public static double GetMinWeight(double value,DeviceCfg device) {
            if (device.DUnit == "GJ" || device.DUnit == "KG" || device.DUnit == "kg") {
                if (device.SUnit == "Dun" || device.SUnit == "T" || device.SUnit == "t") {
                    value /= 1000;
                } else if (device.SUnit.ToUpper() == "JIN") {
                    value *= 2;
                }
            } else if (device.DUnit == "Dun" || device.DUnit == "T" || device.DUnit == "t") {
                if (device.SUnit == "GJ" || device.SUnit == "KG" || device.SUnit == "kg") {
                    value *= 1000;
                } else if (device.SUnit.ToUpper() == "JIN") {
                    value *= 2000;
                }
            } else if (device.DUnit.ToUpper() == "JIN") {
                if (device.SUnit == "GJ" || device.SUnit == "KG" || device.SUnit == "kg") {
                    value /= 2;
                } else if (device.SUnit == "Dun" || device.SUnit == "T" || device.SUnit == "t") {
                    value /= 2000;
                }
            }
            return value;
        }

    }
}
