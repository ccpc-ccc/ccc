using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using YF.MWS.BaseMetadata;
using YF.MWS.CacheService;
using YF.MWS.Db;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.Util;

namespace YF.MWS.Win.Uc
{
    public class BaseForm : XtraForm
    {
        public string RecId { get; set; }
        /// <summary>
        /// 系统配置
        /// </summary>
        public SysCfg Cfg { get; set; }
        public AuthCfg Auth { get; set; }
        private List<SModule> lstModule = new List<SModule>();

        public List<SModule> LstModule
        {
            get { return lstModule; }
            set { lstModule = value; }
        }

        public FrmMain FrmMain { get; set; }

        public FrmMain GetMain()
        {
            FrmMain frmMain = null;
            if (MdiParent != null)
                frmMain = (FrmMain)MdiParent;
            return frmMain;
        }

        public BaseForm() 
        {

        } 

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode) {
                Cfg = CfgUtil.GetCfg();
                Auth=CfgUtil.GetAuth();
                var lst = UserCacher.GetModuleList(CurrentUser.Instance.Id);
                string fullName = this.GetType().FullName;
                if (lst != null && lst.Count > 0)
                {
                    lstModule = lst.FindAll(c => c.FullName == fullName);
                }
            }
            base.OnLoad(e);
        }
    }
}
