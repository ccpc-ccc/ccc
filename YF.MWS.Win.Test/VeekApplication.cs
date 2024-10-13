using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YF.MWS.Win.Test
{
    public class PayInfo
    {
        public int PayId { get; set; }
    }

    public static class VeekApplication
    {
        public delegate void Finish(PayInfo payInfo);
        public static event Finish FinishEvent;

        static VeekApplication() 
        {
            VeekApplication.FinishEvent += VeekApplication_FinishEvent;
        }

        static void VeekApplication_FinishEvent(PayInfo payInfo)
        {
            int id = payInfo.PayId;
        }

        public static void Test() 
        {
            PayInfo payInfo = new PayInfo() { PayId = 222112 };
            if (FinishEvent != null)
                FinishEvent(payInfo);
        }
    }

    public static class OrderPayApplication 
    {

        static OrderPayApplication() 
        {
            VeekApplication.FinishEvent += VeekApplication_FinishEvent;
        }

        static void VeekApplication_FinishEvent(PayInfo payInfo)
        {
            int id = payInfo.PayId;
        }

        public static void Test() 
        {

        }
    }


}
