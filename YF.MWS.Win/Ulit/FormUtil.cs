using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Metadata.Screen;
using YF.MWS.SQliteService;
using YF.Utility;
using YF.Utility.Security;
using YF.MWS.Util;
using YF.Utility.IO;

namespace YF.MWS.Win
{
    /// <summary>
    /// 系统配置工具类
    /// Author:闫孝感
    /// Date:2023-12-20
    /// </summary>
    public class FormUtil {
        public static void LoadFormCfg(Form frm,FormCfg cfg) {
            if (cfg.isMax < 0) return;
            frm.WindowState= cfg.isMax==1? FormWindowState.Maximized : FormWindowState.Normal;
            frm.Location =new Point(cfg.x,cfg.y);
            frm.Width = cfg.width;
            frm.Height = cfg.height;
        }
        public static FormCfg CloseFormCfg(Form frm) {
            FormCfg cfg = new FormCfg();
            cfg.isMax = frm.WindowState == FormWindowState.Maximized ? 1 : 0;
            cfg.x = frm.Location.X;
            cfg.y = frm.Location.Y;
            cfg.height = frm.Height;
            cfg.width = frm.Width;
            return cfg;
        }
    }
}
