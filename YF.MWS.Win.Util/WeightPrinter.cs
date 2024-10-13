using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.MWS.SQliteService;
using YF.MWS.Util;
using YF.Utility.Configuration;
using YF.Utility;

namespace YF.MWS.Win.Util
{
    public class WeightPrinter
    {
        private IWeightService weightService = new WeightService();
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
        private QWeight weight;
        public WeightPrinter()
        {
            font = new Font("黑体", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocumentImage_PrintPage);
            printDialog = new PrintDialog();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            //printDialog.PrinterSettings = new PrinterSettings();
            printDialog.Document = printDocument;
        }

        public void Print(string weightId, QWeight weight)
        {
            this.weightId = weightId;
            this.weight = weight;
            PrinterSettings ps = new PrinterSettings();
            PageSettings df = new System.Drawing.Printing.PageSettings();
            df.PaperSize = new PaperSize("customer", AppSetting.GetValue("pageWidth").ToInt(), AppSetting.GetValue("pageHeight").ToInt());
            printDialog.Document.DefaultPageSettings = df;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //保存打印设置
                    //ps = printDialog.PrinterSettings;
                    printDocument.Print();
                    weightService.UpdatePrint(weightId);
                }
                catch
                {   //停止打印
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                }
            }
        }

        public void ShowPreview(string weightId, QWeight weight)
        {

            printPreviewDialog.ShowDialog();
        }

        private void printDocumentImage_PrintPage(object sender, PrintPageEventArgs e)
        {
            currentLineIndex = 0;
            e.Graphics.DrawString(weight.CustomerName, font, fontBrush, leftMargin, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.CustomerName, font, fontBrush, leftMargin + width, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.CustomerName, font, fontBrush, leftMargin + 2 * width + secColumnSpit, topMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            e.Graphics.DrawString(weight.MaterialName, font, fontBrush, leftMargin, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.MaterialName, font, fontBrush, leftMargin + width, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.MaterialName, font, fontBrush, leftMargin + 2 * width + secColumnSpit, topMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            e.Graphics.DrawString(weight.Weighter, font, fontBrush, leftMargin, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.Weighter, font, fontBrush, leftMargin + width, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.Weighter, font, fontBrush, leftMargin + 2 * width + secColumnSpit, topMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            string axleMessage = string.Empty;
            //decimal maxWeight = UnitUtil.GetValue(weight.MeasureUnit, selfUnit, weight.MaxWeight);
            axleMessage = string.Format("轴数:{0};限重:{1}吨", weight.AxleCount, weight.MaxWeight);
            e.Graphics.DrawString(axleMessage, font, fontBrush, leftMargin, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(axleMessage, font, fontBrush, leftMargin + width, topMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(axleMessage, font, fontBrush, leftMargin + 2 * width + secColumnSpit, topMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            totalTopMargin = spitHeight + topMargin;
            e.Graphics.DrawString(weight.WeightNo, font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.WeightNo, font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.WeightNo, font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            if (weight.FinishTime != DateTime.MinValue)
            {
                e.Graphics.DrawString(weight.FinishTime.ToString("yyyy-MM-dd"), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.FinishTime.ToString("yyyy-MM-dd"), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.FinishTime.ToString("yyyy-MM-dd"), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            }
            currentLineIndex++;
            if (weight.GrossWeightTime != DateTime.MinValue)
            {
                e.Graphics.DrawString(weight.GrossWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.GrossWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.GrossWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            }
            currentLineIndex++;
            if (weight.TareWeightTime != DateTime.MinValue)
            {
                e.Graphics.DrawString(weight.TareWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.TareWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString(weight.TareWeightTime.ToString("yyyy-MM-dd HH:mm:ss"), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            }
            currentLineIndex++;
            e.Graphics.DrawString(weight.CarNo, font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.CarNo, font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.CarNo, font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            decimal overWeight = UnitUtil.GetValue("Ton", selfUnit, weight.OverWeight);
            if (weight.OverWeightState == 1)
            {
                e.Graphics.DrawString("超载:" + overWeight + " Kg", font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString("超载:" + overWeight + " Kg", font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString("超载:" + overWeight + " Kg", font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            }
            else
            {
                e.Graphics.DrawString("未超载", font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString("未超载", font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
                e.Graphics.DrawString("未超载", font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            }

            currentLineIndex++;
            //decimal realCharge = UnitUtil.GetValue(weight.MeasureUnit, selfUnit, weight.RealCharge);
            e.Graphics.DrawString(weight.RealCharge.ToString(), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.RealCharge.ToString(), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(weight.RealCharge.ToString(), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            decimal grossWeight = UnitUtil.GetValue(weight.MeasureUnit, selfUnit, weight.GrossWeight);
            e.Graphics.DrawString(grossWeight.ToString(), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(grossWeight.ToString(), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(grossWeight.ToString(), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            decimal tareWeight = UnitUtil.GetValue(weight.MeasureUnit, selfUnit, weight.TareWeight);
            e.Graphics.DrawString(tareWeight.ToString(), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(tareWeight.ToString(), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(tareWeight.ToString(), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            currentLineIndex++;
            decimal suttleWeight = UnitUtil.GetValue(weight.MeasureUnit, selfUnit, weight.SuttleWeight);
            e.Graphics.DrawString(suttleWeight.ToString(), font, fontBrush, leftMargin, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(suttleWeight.ToString(), font, fontBrush, leftMargin + width, totalTopMargin + currentLineIndex * lineHeight);
            e.Graphics.DrawString(suttleWeight.ToString(), font, fontBrush, leftMargin + 2 * width + secColumnSpit, totalTopMargin + currentLineIndex * lineHeight);
            e.HasMorePages = false;
        }
    }
}
