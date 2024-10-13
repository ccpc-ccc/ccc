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
using YF.MWS.Metadata;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using YF.MWS.SQlSugService;
using YF.MWS.SQlSugService.Interface;

namespace ESC.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModuleController : BaseController<ModuleController> {
        private readonly ILogger<ModuleController> _logger;
        private readonly IModuleService _moduleService;
        private readonly IRoleService _roleService;
        public ModuleController(ILogger<ModuleController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) :base( _logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            _moduleService = new ModuleService(connectionString.CurrentValue);
            _roleService = new RoleService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryModule query) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
              bool isDel= _moduleService.delete(query);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult save([FromBody] QueryModule query) {
            if (query != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Permiss" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Module module=_moduleService.GetByPermiss(query.Permiss!);
                if(module != null&&query.Id!=module.Id)
                    return new JsonResult(new { result = false, message = "权限编号重复" });
                _moduleService.saveModel(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getAll([FromBody] QueryModule query) {
            try {
            List<VModule>? page=null;
                if (currentUser != null) {
                    if (currentUser.IsAdmin == 2) {
                        page = _moduleService.GetAll(null,null);
                    } else {
                        string[] strs = query.Permiss.Split(",");
                        page = _moduleService.GetAll(null, strs);
                    }
                }
            return new JsonResult(new { result = true,data=page, message = "操作成功" });
            }catch (Exception ex) {
                return new JsonResult(new { result = false,message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryModule query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_Module model = _moduleService.GetById(query.Id);
            if (model != null) {
                return new JsonResult(new { result = true, data = model, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
            }catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
    }
}
