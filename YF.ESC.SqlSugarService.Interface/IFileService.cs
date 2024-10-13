
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;

namespace YF.MWS.SQlSugService.Interface
{
    /// <summary>
    /// 用户信息管理接口
    /// </summary>
    public interface IFileService : IBaseService <B_File> {
        VPage<B_File> getPage(QueryFile query);
        /// <summary>
        /// 保存文件数据
        /// </summary>
        /// <param name="file"></param>
        void saveFile(QueryFile file);
        string getFile(B_File file);
    }
}
