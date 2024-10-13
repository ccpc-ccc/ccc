using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.Utility.IO;

namespace YF.MWS.Win.Util
{
    public class ExportUtil
    {
        private static bool ExprtAHJHJF(DataSet ds, CarStatementQuery query, string filePath) 
        {
            bool isImport = false;
            List<SCar> cars = query.Cars;
            List<string> titles = new List<string>();
            List<string> sheetNames = new List<string>();
            titles.Add(string.Format("九华金峰生产统计表{0}月份总合计", query.StartTime.Month));
            sheetNames.Add("总数量");
            if (cars != null)
            {
                cars = cars.OrderBy(c => c.CarNo).ToList();
                foreach (SCar car in cars)
                {
                    titles.Add(string.Format("矿卡登记表{0}号车", car.CarNo));
                    sheetNames.Add(car.CarNo);
                }
            }
            isImport = NPOIHelper.DataSetToExcel(ds, filePath, titles, sheetNames);
            return isImport;
        }

        public static void ExportCarStatement(VersionCodeType versionCode, DataSet ds, CarStatementQuery query) 
        {
            using (SaveFileDialog sfdFileSave = new SaveFileDialog())
            {
                sfdFileSave.Filter = "Excel 文件|*.xls";
                if (sfdFileSave.ShowDialog() == DialogResult.OK)
                {
                    bool isImport = false;
                    using (Util.Utility.GetWaitForm("导出数据"))
                    {
                        string filePath = sfdFileSave.FileName;
                        switch (versionCode)
                        {
                            case VersionCodeType.AHJHJF:
                                isImport = ExprtAHJHJF(ds, query, filePath);
                                break;
                        }
                    }
                    MessageDxUtil.ShowTips(isImport ? "成功导出" : "导出失败");
                }
            }
        }
    }
}
