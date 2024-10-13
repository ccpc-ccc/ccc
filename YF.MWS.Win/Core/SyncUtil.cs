using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YF.MWS.Db;
using YF.MWS.Metadata.Query;
using YF.Utility.IO;
using YF.Utility.Log;
using YF.MWS.Util;
using System.Windows.Forms;
using System.ServiceModel;
using YF.MWS.Client.DataService.Interface;
using System.Threading;
using YF.MWS.Metadata.Partner;
using YF.MWS.Win.Util;
using YF.MWS.BaseMetadata;
using YF.Utility;
using YF.MWS.Client.DataService.Interface.Remote;
using YF.MWS.SQliteService.Remote;

namespace YF.MWS.Win.Core
{
    public class SyncUtil
    {
        private static IWebWeightService webWeightService = new WebWeightService();

        public static void UploadPhoto(BFile file, IWebFileService webFileService, IFileService fileService,string apiUrl)
        {
            try
            {
                string sourceFile = Path.Combine(Application.StartupPath, file.FileUrl);
                if (File.Exists(sourceFile))
                {
                    byte[] bytes = File.ReadAllBytes(sourceFile);
                    file.FileContent = Convert.ToBase64String(bytes);
                    bool isUploaded = webFileService.UploadPhoto(file, apiUrl);
                    if(isUploaded)
                        fileService.UpdateSyncState(file.Id);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }

    }
}
