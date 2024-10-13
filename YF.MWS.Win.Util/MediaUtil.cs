using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace YF.MWS.Win.Util
{
    public class MediaUtil
    {
        protected const int SND_SYNC = 0x0;
        protected const int SND_ASYNC = 0x1;
        protected const int SND_NODEFAULT = 0x2;
        protected const int SND_MEMORY = 0x4;
        protected const int SND_LOOP = 0x8;
        protected const int SND_NOSTOP = 0x10;
        protected const int SND_NOWAIT = 0x2000;
        protected const int SND_ALIAS = 0x10000;
        protected const int SND_ALIAS_ID = 0x110000;
        protected const int SND_FILENAME = 0x20000;
        protected const int SND_RESOURCE = 0x40004;
        protected const int SND_PURGE = 0x40;
        protected const int SND_APPLICATION = 0x80;

        [DllImport("winmm")]
        private static extern bool PlaySound(string szSound, IntPtr hMod, int flags);

        /// <summary>
        /// 同步播放
        /// </summary>
        /// <param name="wavFile">WAV文件路径</param>
        public static void PlaySync(string wavFile)
        {
            PlaySound(wavFile, IntPtr.Zero, SND_FILENAME | SND_SYNC);
        }

        /// <summary>
        /// 异步播放
        /// </summary>
        /// <param name="wavFile">WAV文件路径</param>
        public static void PlayAsync(string wavFile)
        {
            PlaySound(wavFile, IntPtr.Zero, SND_FILENAME | SND_ASYNC);
        }

        /// <summary>
        /// 播放文本
        /// </summary>
        /// <param name="readText">要播放的文本</param>
        public static void Play(string readText)
        {
            if (!string.IsNullOrEmpty(readText))
            {
                for (int i = 0; i < readText.Length; i++)
                {
                    switch (readText.Substring(i, 1))
                    {
                        case "零":
                            PlaySync("./Sound/0.WAV");
                            break;
                        case "壹":
                            PlaySync("./Sound/1.WAV");
                            break;
                        case "贰":
                            PlaySync("./Sound/2.WAV");
                            break;
                        case "叁":
                            PlaySync("./Sound/3.WAV");
                            break;
                        case "肆":
                            PlaySync("./Sound/4.WAV");
                            break;
                        case "伍":
                            PlaySync("./Sound/5.WAV");
                            break;
                        case "陆":
                            PlaySync("./Sound/6.WAV");
                            break;
                        case "柒":
                            PlaySync("./Sound/7.WAV");
                            break;
                        case "捌":
                            PlaySync("./Sound/8.WAV");
                            break;
                        case "玖":
                            PlaySync("./Sound/9.WAV");
                            break;
                        case "点":
                            PlaySync("./Sound/DIAN.WAV");
                            break;
                        case "拾":
                            PlaySync("./Sound/SHI.WAV");
                            break;
                        case "佰":
                            PlaySync("./Sound/BAI.WAV");
                            break;
                        case "仟":
                            PlaySync("./Sound/QIAN.WAV");
                            break;
                        case "萬":
                            PlaySync("./Sound/WAN.WAV");
                            break;
                        case "秒":
                            PlaySync("./Sound/MIAO.wav");
                            break;
                        case "分":
                            PlaySync("./Sound/FEN.WAV");
                            break;
                        case "时":
                            PlaySync("./Sound/SHI.WAV");
                            break;
                        case "日":
                            PlaySync("./Sound/RI.wav");
                            break;
                        case "月":
                            PlaySync("./Sound/YUE.wav");
                            break;
                        case "年":
                            PlaySync("./Sound/NIAN.wav");
                            break;
                        case "角":
                            PlaySync("./Sound/JIAO.WAV");
                            break;
                        case "元":
                            PlaySync("./Sound/YUAN.WAV");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 播放报警声
        /// </summary>
        public static void PlayAlarm()
        {
            PlayAsync("./Sound/ALARM.WAV");
        }
    }
}
