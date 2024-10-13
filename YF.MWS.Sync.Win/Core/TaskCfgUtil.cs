using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.Utility.Serialization;

namespace YF.MWS.Sync.Win.Core
{
    public class TaskCfgUtil
    {
        private static TaskCfg task = null;

        public static TaskCfg GetTaskCfg()
        {
            if (task == null)
            {
                task = XmlUtil.Deserialize<TaskCfg>(Path.Combine(Application.StartupPath, "taskcfg.xml"));
            }
            return task;
        }

        public static void SaveTaskCfg(TaskCfg cfg)
        {
            XmlUtil.Serialize<TaskCfg>(cfg, Path.Combine(Application.StartupPath, "taskcfg.xml"));
            task = null;
        }
    }
}
