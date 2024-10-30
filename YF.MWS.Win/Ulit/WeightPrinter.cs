using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.Utility.Configuration;
using YF.Utility;

namespace YF.MWS.Win
{
    public class WeightPrinter
    {
        private PrintDocument printDocument;
        private PrintDialog printDialog;
        private PrintPreviewDialog printPreviewDialog;
        private Font font = SystemFonts.DefaultFont;
        private Brush fontBrush = SystemBrushes.ControlText;

        /// <summary>
        /// 1CM=37.45px
        /// </summary>
        private const float unitPx = 37.25f;
        /// <summary>
        /// 左边距
        /// </summary>
        private float leftMargin = (float)(1.5 + 2.0) * unitPx;
        /// <summary>
        /// 顶部距离  2.2 - 6 * 0.86
        /// </summary> 
        private float topMargin = (float)(AppSetting.GetValue("weightTopMarign").ToDecimal()) * unitPx;
        /// <summary>
        /// 中间间隔距离
        /// </summary>
        private float spitHeight = (float)1.1 * unitPx;
        /// <summary>
        /// 列宽
        /// </summary>
        private float width = (float)(6.6 + 0.7) * unitPx;

        private float secColumnSpit = (float)0.5 * unitPx;

        private float totalTopMargin = 0;
        /// <summary>
        /// 行高
        /// </summary>
        private float lineHeight = (float)0.90 * unitPx;

        private int currentLineIndex = 0;

        private string weightId;
        private string selfUnit = "kg";
        public WeightPrinter()
        {
            font = new Font("黑体", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            printDocument = new PrintDocument();
            printDialog = new PrintDialog();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            //printDialog.PrinterSettings = new PrinterSettings();
            printDialog.Document = printDocument;
        }
    }
}
