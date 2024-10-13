using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.Utility.Log;

namespace YF.MWS.Win.Util.Video.DHNew
{
    public class DHVideoUtil
    {
        private static fDisConnectCallBack m_DisConnectCallBack;

        public  bool Init() 
        {
            bool isInited = false;
            try
            {
                m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
                NETClientNew.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                isInited = true;
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
                //Process.GetCurrentProcess().Kill();
            }
            return isInited;
        }

        private void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {

        }

        public static void Release()
        {
            NETClientNew.Cleanup();
        }
    
    }
}
