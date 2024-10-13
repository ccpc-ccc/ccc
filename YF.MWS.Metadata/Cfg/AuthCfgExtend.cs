using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Metadata.Cfg
{
    public class AuthCfgExtend
    {
        private string verifyCode;

        public string VerifyCode
        {
            get { return verifyCode; }
            set { verifyCode = value; }
        }
        private AuthCfg cfg;

        public AuthCfg Cfg
        {
            get { return cfg; }
            set { cfg = value; }
        }
    }
}
