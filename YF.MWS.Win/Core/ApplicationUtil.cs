using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.Utility.IO;

namespace YF.MWS.Win.Core
{
    public class ApplicationUtil
    {
        public static void InitApp() 
        {
            string tempDictory = Path.Combine(Application.StartupPath, "Sync", "Temp");
            FileHelper.DeleteDir(tempDictory);
            tempDictory = Path.Combine(Application.StartupPath, "Sync", "Source");
            FileHelper.DeleteDir(tempDictory);
        }
    }
}
