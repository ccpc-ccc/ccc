using DevExpress.Office.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.SQliteService;
using YF.MWS.Win.View.Master;

namespace YF.MWS.Win.Uc
{
    public partial class WeightControl : UserControl
    {
        private IMaterialService materialService = new MaterialService();
        public int Index { get; private set; }
        private List<SMaterial> materials { get; set; }
        private List<Label> labels { get; set; }
        public WeightControl(int index)
        {
            InitializeComponent();
            this.Index = index;
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            this.lbName.Text = Program._cfg.Device[Index].Name;
            materials = materialService.GetMaterialByCompanyId(Index.ToString());
            labels = new List<Label>();
            int i = 2;
            if (materials != null && materials.Count > 0) {
            foreach(SMaterial material in materials) {
                Label lb = setLabel();
                    lb.Text = material.MaterialName;
                    tableLayoutPanel1.Controls.Add(lb, 0, i);
                lb = setLabel();
                    lb.Text = "0";
                tableLayoutPanel1.Controls.Add(lb, 1, i);
                labels.Add(lb);
                i++;
                if (i > 7) break;
            }
            }
        }
        private Label setLabel() {
            Label lb = new Label();
            lb.AutoSize = false;
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lb.Font = new System.Drawing.Font(lb.Font.FontFamily, 14);
            lb.Dock= DockStyle.Fill;
            return lb;
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            FrmDeviceSetting frm = new FrmDeviceSetting(this.Index);
            frm.ShowDialog();
        }
        private void saveWeight(decimal weight) {

        }
    }
}
