using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;
using YF.Utility.Log;

namespace YF.MWS.Win
{
    public class SpeechUtil
    {
        /// <summary>
        /// 语音标识
        /// </summary>
        private SpeechVoiceSpeakFlags speakFlag = SpeechVoiceSpeakFlags.SVSFlagsAsync;

        /// <summary>
        /// 语音朗读器
        /// </summary>
        private SpVoice speaker;

        public SpeechUtil()
        {
            try
            {
                speaker = new SpVoice();
                //判断操作系统类型
                OperatingSystem os = Environment.OSVersion;
                //主版本号
                int major = os.Version.Major;
                if (major >= 6)
                {
                    speaker.Voice = speaker.GetVoices(string.Empty, string.Empty).Item(0);
                }
                else
                {
                    speaker.Voice = speaker.GetVoices("Name = ScanSoft Mei-Ling_Full_22kHz", string.Empty).Item(0);
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 朗读语音
        /// </summary>
        /// <param name="voiceText">要朗读的文本</param>
        public void Speak(string voiceText)
        {
            try
            {
                //朗读
                if (speaker != null)
                {
                    speaker.Speak(voiceText, speakFlag);
                }
            }
            catch (Exception ex) 
            {
                Logger.WriteException(ex);
            }
        }
    }
}
