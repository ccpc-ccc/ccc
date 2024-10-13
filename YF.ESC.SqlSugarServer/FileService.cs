using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SqlSugar;
using YF.MWS.Models;
using YF.MWS.BaseMetadata;
using Microsoft.AspNetCore.Identity;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using System.Reflection;
using YF.MWS.SQlSugService.Interface;
using YF.MWS.Metadata;
using System.Linq.Expressions;

namespace YF.MWS.SQlSugService
{
    public class FileService : BaseService<B_File>, IFileService {
        public FileService(ConnectionStrings connection):base(connection) { }
        public VPage<B_File> getPage(QueryFile query) {
            var models = db.Queryable<B_File>().Where(li=>li.RecId==query.RecId);
            return base.ToPage(query.PageIndex, query.PageSize, models);
        }
        public B_File GetById(string id) {
            return db.Queryable<B_File>().Where(li=>li.Id==id).First();
        }
        public bool save(B_File model) {
            Expression<Func<B_File, object>> ps = li => new {
                li.UpdaterId,
                li.UpdateTime
            };
            return base.save(model, ps);
        }
        public void saveFile(QueryFile file) {
            file.serverUrl = file.serverUrl.Replace("\\", "/");
            if (string.IsNullOrEmpty(file.serverUrl) ||string.IsNullOrEmpty(file.FileContent)) return;
            int index=file.serverUrl.LastIndexOf("/");
            if (index <=0) return;
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\wwwroot\\" + file.serverUrl.Substring(0, index);
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            string fileUrl = AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"\\wwwroot\\" + file.serverUrl;
            File.WriteAllText(fileUrl, file.FileContent);
        }
        public string getFile(B_File file) {
            if (string.IsNullOrEmpty(file.serverUrl)) return "";
            string fileUrl = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\wwwroot\\" + file.serverUrl;
            file.FileContent= File.ReadAllText(fileUrl, System.Text.Encoding.UTF8);
            return file.FileContent;
        }
    }
}
