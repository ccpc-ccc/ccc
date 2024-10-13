using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.Utility.Log;

namespace YF.MWS.Metadata {
    public class MessageDxUtil {
        public static void Show(MessageType type, string title, string messageContent) {
            switch (type) {
                case MessageType.Error:
                    MessageBox.Show(messageContent, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Info:
                    MessageBox.Show(messageContent, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.Warn:
                    MessageBox.Show(messageContent, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        /// <summary>
        /// 显示一般的提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void ShowTips(string message, string title = "") {
            try {
                if (!string.IsNullOrEmpty(title))
                    DevExpress.XtraEditors.XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="message">警告信息</param>
        public static void ShowWarning(string message, string title = "") {
            try {
                DevExpress.XtraEditors.XtraMessageBox.Show(message, "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        public static void ShowError(string message, string title = "") {
            try {
                if (string.IsNullOrEmpty(title)) title = "错误信息";
                DevExpress.XtraEditors.XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                Logger.WriteException(ex);
            }
        }

        /// <summary>
        /// 显示询问用户信息，并显示提示标志
        /// </summary>
        /// <param name="message">信息</param>
        public static DialogResult ShowYesNoAndTips(string message) {
            return DevExpress.XtraEditors.XtraMessageBox.Show(message, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }

}

