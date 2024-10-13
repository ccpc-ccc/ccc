using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Transfer;

namespace YF.MWS.Client.DataService.Interface
{
    public interface IFileService
    {
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="file">文件实体类</param>
        /// <returns></returns>
        bool Add(BFile file);

        bool DeleteBatch(string weightId);
        /// <summary>
        /// 删除远程服务器上的文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="recId"></param>
        void DeleteRemote(string url, string recId);
        List<BFile> Get(string recId, FileBusinessType type);
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="recId">关联主表Id</param>
        /// <param name="tableName">表名</param>
        /// <param name="type">文件类型</param>
        /// <returns></returns>
        List<BFile> Get(string recId, string tableName, FileBusinessType type);

        int GetCount(string recId, string tableName, FileBusinessType type);

        TPageResult GetListFromRemote(string url, string recId);
        /// <summary>
        /// 获取上传列表的文件
        /// </summary>
        /// <param name="recId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<BFile> GetUploadList(string recId);

        List<BFile> GetUploadList();

        void UpdateSyncState(string fileId);
    }
}
