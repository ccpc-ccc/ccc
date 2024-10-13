using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using YF.MWS.BaseMetadata;
using YF.MWS.Metadata;
using YF.MWS.Models;
using YF.MWS.Models.Query;
using YF.MWS.Models.Views;
using YF.MWS.SQlSugService;
using YF.MWS.SQlSugService.Interface;
using YF.Utility;

namespace ESC.Controllers {
    /// <summary>
    /// 商户操作
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : BaseController<CompanyController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<CompanyController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        public CompanyController(ILogger<CompanyController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            _companyService = new CompanyService(connectionString.CurrentValue);
            _userService = new UserService(connectionString.CurrentValue);
        }
        [HttpPost]

        public IActionResult Login([FromBody] QueryCompany query) {
            if (query.Id == null) { return new JsonResult(new { result = false, token = "", message = "参数不存在" }); }
            S_Company model = _companyService.Get(query.Id);
            if (model != null) {
                string token = _customHSJWT.GetCompanyToken(model);
                return new JsonResult(new { result = true, token, user = model });
            } else {
                return new JsonResult(new { result = false, token = "", message = "商家登录失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryCompany query) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
            List<S_User> users=_userService.getListByCompany(query.Id);
              bool isDel= _companyService.delete(query);
            _userService.Delete(users);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult save([FromBody] QueryCompany query) {
            if (query != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "CompanyCode","CompanyName" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Company module = _companyService.GetByCode(query.CompanyCode!);
                if (module != null && query.Id != module.Id)
                    return new JsonResult(new { result = false, message = "商户编号重复" });
                bool isAdd = query.Id == null || query.Id == "";
                _companyService.save(query);
                if (isAdd) {
                    S_User user = new S_User() {
                        CompanyId = query.Id,
                        UserName = query.CompanyCode,
                        IsAdmin = 1,
                        Active = 1,
                        Permission = "",
                        Permission2 = ""
                    };
                    _userService.MasterSave(user);
                }
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getAll([FromBody] QueryCompany query) {
            try {
                string? companyId = null;
                if (currentUser!=null) companyId = currentUser.CompanyId;
            List<S_Company> page= _companyService.GetAll(companyId);
            return new JsonResult(new { result = true,data=page, message = "操作成功" });
            }catch (Exception ex) {
                return new JsonResult(new { result = false,message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryCompany query) {
            try {
                if (currentUser != null) query.Id = currentUser.CompanyId;
                VPage<S_Company> page= _companyService.getPage(query);
            return new JsonResult(new { result = true,data=page, message = "操作成功" });
            }catch (Exception ex) {
                return new JsonResult(new { result = false,message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryCompany query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_Company model = _companyService.GetById(query.Id);
            if (model != null) {
                return new JsonResult(new { result = true, data = model, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
            }catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 重置管理员密码
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult reUserPwd([FromBody] QueryCompany query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_User user = _userService.getCompanyAdmin(query.Id);
            if (user != null) {
                    _userService.UpdatePassword(user.Id, "123456".ToMd5());
                return new JsonResult(new { result = true,message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "管理员不存在" });
            }
            }catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
    }
}
