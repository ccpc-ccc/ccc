using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Db;
using YF.MWS.Metadata;
using YF.MWS.Metadata.Dto;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using YF.MWS.SQlSugService;
using YF.MWS.SQlSugService.Interface;
using YF.Utility;

namespace ESC.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : BaseController<FileController> {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _fileService;
        private readonly ICarService _carService;
        private readonly IWarehService _warehService;
        private readonly IMaterialService _materialService;
        private readonly ICustomerService _customerService;
        public FileController(ILogger<FileController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            _fileService = new FileService(connectionString.CurrentValue);
            _carService = new CarService(connectionString.CurrentValue);
            _warehService = new WarehService(connectionString.CurrentValue);
            _materialService = new MaterialService(connectionString.CurrentValue);
            _customerService = new CustomerService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Client")]
        [HttpPost]
        public IActionResult save([FromBody] List<QueryFile> files) {
            try {
                bool isOk = false;
            foreach(QueryFile file in files) {
                    file.Id = null;
                   _fileService.saveFile(file);
                isOk = _fileService.save(file);
            }
                return new JsonResult(new { result = true, message = "操作成功" });

            }catch(Exception ex) {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User,Company")]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryFile user) {
            try {
                VPage<B_File> page = _fileService.getPage(user);
                page.Items.ForEach(li => { li.FileContent = _fileService.getFile(li); });
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryFile user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                B_File model = _fileService.Get(user.Id);
                if (model != null) {
                    return new JsonResult(new { result = true, data = model, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "操作失败" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
    }
}
