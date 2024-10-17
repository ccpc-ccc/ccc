using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YF.MWS.Db;

namespace YF.MWS.Metadata
{
    public static class MyConvert 
    {
        public static bool Contains(this byte[] source, byte[] pattern) {
            int findLen = pattern.Length;
            int sourceLen = source.Length;

            if (findLen > sourceLen)
                return false;

            for (int i = 0; i < sourceLen - findLen + 1; i++) {
                bool found = true;
                for (int j = 0; j < findLen; j++) {
                    if (source[i + j] != pattern[j]) {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return true;
            }
            return false;
        }
    }
}
