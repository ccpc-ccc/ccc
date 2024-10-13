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
    public class MaterialController : BaseController<ClientController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<ClientController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        private readonly IMaterialService _materialService;
        public MaterialController(ILogger<ClientController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            _materialService = new MaterialService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPost]
        public IActionResult del([FromBody] QueryMaterial user) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            bool isDel = _materialService.Delete(user.Id);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        [HttpPost]
        public IActionResult save([FromBody] QueryMaterial user) {
            if (user != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "MaterialCode","MaterialName" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                if(currentUser != null) { user.CompanyId = currentUser.CompanyId; }
                if (user.Id == null) {
                    S_Material old = _materialService.GetByCode(user);
                    if (old != null) {
                        return new JsonResult(new { result = false, message = "物资编号重复" });
                    }
                }
                _materialService.save(user);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User,Company")]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryMaterial user) {
            try {
                if (currentUser!=null&&currentUser.CompanyId!=null&&currentUser.CompanyId!="")
                {
                    user.CompanyId = currentUser.CompanyId;
                } else if (currentCompany != null && currentCompany.Id != null && currentCompany.Id != "") {
                    user.CompanyId = currentCompany.Id;
                }
                VPage<S_Material> page = _materialService.getPage(user);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryMaterial user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Material model = _materialService.Get(user.Id);
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
