using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YF.MWS.Win.Util
{
    public class WindowsMessage
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref CopyData lParam);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //定义消息常数   
        public const int WM_COPYDATA = 0x004A;
        public struct CopyData
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        public static bool SendMsg(string msg)
        {
            var hwnd = FindWindow("MWS", null);
            if (hwnd == IntPtr.Zero)
            {
                return false;
            }
            CopyData data;
            data.dwData = IntPtr.Zero;
            data.lpData = msg;
            data.cbData = Encoding.Default.GetBytes(data.lpData).Length + 1;
            SendMessage(hwnd, WM_COPYDATA, 0, ref data);
            return true;
        }  
    }
}
