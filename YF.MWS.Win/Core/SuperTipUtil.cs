using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Win.Core
{
    /// <summary>
    /// 控件提示工具类
    /// </summary>
    public class SuperTipUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static SuperToolTip GetSupperTip(SModule module) 
        {
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            item.Appearance.Image = global::YF.MWS.Win.Properties.Resources.info_16x16;
            item.Appearance.Options.UseImage = true;
            item.Image = global::YF.MWS.Win.Properties.Resources.info_16x16;
            item.Text = string.Format("<b><color=\"red\">{0}</color></b>",module.SuperTipContent);
            tip.Items.Add(item);
            tip.AllowHtmlText = DefaultBoolean.True;
            return tip;
        }
    }
}
