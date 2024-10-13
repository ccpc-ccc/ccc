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
using YF.MWS.Metadata.Dto;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using YF.MWS.SQlSugService;
using YF.MWS.SQlSugService.Interface;

namespace ESC.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : BaseController<RoleController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<RoleController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        private readonly IRoleService _roleService;
        public RoleController(ILogger<RoleController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) :base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            _roleService = new RoleService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryRole query) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
              bool isDel= _roleService.Delete(query);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult save([FromBody] QueryRole query) {
            if (query != null) {
                if (currentUser != null) { query.CompanyId = currentUser.CompanyId; }
                _roleService.save(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult savePermission([FromBody] QueryRole query) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id", "Permisses", "Permisses2" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            if (query != null) {
                _roleService.savePermiss(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryRole query) {
            try {
                VPage<S_Role> page = _roleService.getPage(query);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryRole query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_Role model = _roleService.Get(query.Id);
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
