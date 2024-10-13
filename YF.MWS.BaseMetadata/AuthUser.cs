using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.Utility.Mode;

namespace YF.MWS.BaseMetadata
{
    public class AuthUser : Singleton<AuthUser>
    {
        public string UserName { 
            get
            {
                return "ruijie";
            }
        }

        public string AuthCode 
        {
            get 
            {
                return "rjauth1.0";
            }
        }

        public string VerifyCode 
        {
            get 
            {
                return "ruijie123456";
            }
        }

        public string AuthResetPasswordCode
        {
            get
            {
                return "ruijiesoft2017";
            }
        }

        public string DefaultPassword 
        {
            get 
            {
                return "123456";
            }
        }
    }
}
