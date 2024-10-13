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
    public class ClientController : BaseController<ClientController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<ClientController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        private readonly IClientService _clientService;
        public ClientController(ILogger<ClientController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            _clientService = new ClientService(connectionString.CurrentValue);
        }
        [HttpPost]

        public IActionResult Login([FromBody] QueryClient query) {
            bool isVerify = UtilityQuery.Verify(new string[] { "CompanyCode", "MachineCode", "RegisterCode" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, token = "", message = UtilityQuery.errMsg });
            }
            S_Client client = _clientService.Login(query.MachineCode, query.RegisterCode);
            if (client != null&& client.Company!=null&&client.Company.CompanyCode==query.CompanyCode) {
                string token = _customHSJWT.GetClientToken(client);
                return new JsonResult(new { result = true, token, message = "获取成功", model = client });
            } else {
                return new JsonResult(new { result = false, token = "", message = "用户名或密码不正确" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryClient user) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            bool isDel = _clientService.Delete(user.Id);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult save([FromBody] QueryClient user) {
            if (user != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "MachineCode", "ClientName", "RegisterCode" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                if (user.Id == null) {
                    S_Client old = _clientService.GetByName(user.MachineCode);
                    if (old != null) {
                        return new JsonResult(new { result = false, message = "终端编号已存在" });
                    }
                }
                _clientService.save(user);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryClient user) {
            try {
                if (currentUser!=null&&currentUser.CompanyId!=null&&currentUser.CompanyId!="")
                {
                    user.CompanyId = currentUser.CompanyId;
                }
                VPage<S_Client> page = _clientService.getPage(user);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryClient user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Client model = _clientService.GetById(user.Id);
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
