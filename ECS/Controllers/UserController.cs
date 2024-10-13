using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SQLitePCL;
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
    public class UserController : BaseController<UserController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        private readonly ConnectionStrings _connectionString;
        public UserController(ILogger<UserController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString.CurrentValue;
            _userService = new UserService(connectionString.CurrentValue);
            _moduleService = new ModuleService(connectionString.CurrentValue);
        }
        [HttpGet]

        public async Task<IActionResult> wxLogin(string code) {
            string url = string.Format(@"https://api.weixin.qq.com/sns/jscode2session?appid=wx1a5c9e8df8c83cad&secret=94ee1ceb336c26390ee626119072a08f&js_code={0}&grant_type=authorization_code ",code);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("微信登录返回信息，"+result);
            return new JsonResult(new { result = true, data = result });
        }
        [HttpGet]

        public async Task<IActionResult> Test() {
            return new JsonResult(new { result = true, messge="请求成功" });
        }
        [HttpPost]

        public IActionResult Login([FromBody] QueryUser query) {
            string errMsg = "";
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "UserName", "UserPwd","CompanyCode" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, token = "", message = UtilityQuery.errMsg });
                }
                query.UserPwd = query.UserPwd.ToMd5();
            S_User _user = _userService.Login(query);
                if (_user != null) {
                if (_user.Active == 0) { return new JsonResult(new { result = false, token = "", message = "未激活用户" }); }
                    if (_user.IsAdmin == 1) {
                        _user.Permission2=_moduleService.getAdminPermiss(new string[] { "9_2", "9_3", "9_3_1", "9_3_2", "9_3_3","9_1", "9_1_1", "9_1_2", "9_1_3" });
                    }else if(_user.IsAdmin == 2) {
                        _user.Permission2=_moduleService.getAdminPermiss(new string[] {});
                    }
                string token = _customHSJWT.GetToken(_user);
                    return new JsonResult(new { result = true, token, user = _user });
            } else {
                return new JsonResult(new { result = false, token = "", message = "用户名或密码不正确" });
            }
            }catch (Exception ex) {
                return new JsonResult(new { result = false, token = "", message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryUser user) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            bool isDel = _userService.Delete(user.Id);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        [HttpPost]
        public IActionResult save([FromBody] QueryUser user) {
            if (user != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "UserName", "FullName", "RoleId" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                } 
                if(currentUser != null) { user.CompanyId=currentUser.CompanyId; }
                if (user.Id == null) {
                    S_User old = _userService.GetByName(user);
                    if (old != null) {
                        return new JsonResult(new { result = false, message = "用户名已存在" });
                    }
                }
                _userService.MasterSave(user);
                return new JsonResult(new { result = true,user, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryUser user) {
            try {
                if (currentUser != null) { 
                    user.CompanyId = currentUser.CompanyId; 
                    user.Id = currentUser.Id;
                }
                VPage<S_User> page = _userService.getPage(user);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryUser user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_User model = _userService.GetById(user.Id);
                if (model != null) {
                    return new JsonResult(new { result = true, data = model, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "操作失败" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 用户修改密码
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult upPwd([FromBody] QueryPwd user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_User model = _userService.GetById(user.Id);
                if (model != null) {
                    if (user.UserPwd.ToMd5() != model.UserPwd) {
                        return new JsonResult(new { result = false, message = "密码输入不正确" });
                    }
                    bool isSave = _userService.UpdatePassword(model.Id, user.NewPwd.ToMd5());
                    if (!isSave) {
                        return new JsonResult(new { result = false, message = "操作失败！" });
                    }
                    return new JsonResult(new { result = true, data = model, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "用户不存在" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 重置用户密码
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult rePwd([FromBody] QueryPwd user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                    bool isSave = _userService.UpdatePassword(user.Id, "123456".ToMd5());
                    if (!isSave) {
                        return new JsonResult(new { result = false, message = "操作失败！" });
                    }
                    return new JsonResult(new { result = true, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 保存用户权限
        /// </summary>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult savePermission([FromBody] QueryUser query) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id", "Permisses", "Permisses2" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            if (query != null) {
                _userService.savePermiss(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
    }
}
