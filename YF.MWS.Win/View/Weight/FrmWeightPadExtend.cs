using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YF.MWS.BaseMetadata;
using YF.MWS.Client.DataService.Interface;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.SQliteService;
using YF.MWS.Win.Core;
using YF.MWS.Win.Uc;
using YF.MWS.Win.Util;
using YF.Utility.Log;
using YF.Utility;
using YF.MWS.Metadata.Transfer;
using YF.MWS.Util;
using System.Threading;
using YF.MWS.Metadata.Cfg;
using YF.MWS.Win.View.Master;

namespace YF.MWS.Win.View.Weight
{
    public partial class FrmWeightPad : BaseForm
    {
        private IWeightViewService viewService = new WeightViewService();
        private IWeightService weightService = new WeightService();
        private IMasterService masterService = new MasterService();
        private ISeqNoService seqNoService = new SeqNoService();
        private string currentWeightId = YF.MWS.Util.Utility.GetGuid();
        private string currentViewId = string.Empty;
        private string currentCustomerId = string.Empty;
        private string currentMaterialId = string.Empty;
        private string currentCarId = string.Empty; 
        private string DeviceOneShowFormat; 

        private void InitConfig() 
        {
            this.DeviceOneShowFormat = IniUtility.GetIniKeyValue("Device1", "ShowFormat", "0.00"); 
        }

        private void SetControl()
        {
            Point p = btnClose.Location;
            p.X = gpWeight.Width - btnClose.Width - 20;
            btnClose.Location = p;
            Point locFinishInput = btnFinishInput.Location;
            locFinishInput.X = btnClose.Location.X - btnFinishInput.Width - 20;
            btnFinishInput.Location = locFinishInput;
        } 

        public void ShowWeight(double weight) 
        {
            lblWeight.Text = weight.ToString(this.DeviceOneShowFormat);
        }

    }
}
