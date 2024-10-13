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
    /// <summary>
    /// 商户操作
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ControlController : BaseController<ControlController> {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<ControlController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        private readonly IControlService _controlService;
        public ControlController(ILogger<ControlController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            _controlService = new ControlService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult del([FromBody] QueryControl query) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
              bool isDel= _controlService.delete(query);
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
        public IActionResult save([FromBody] QueryControl query) {
            if (query != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "FileName", "ControlName" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Control module = _controlService.GetByFieldName(query.FieldName!);
                if (module != null && query.Id != module.Id)
                    return new JsonResult(new { result = false, message = "字段名重复" });
                _controlService.save(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryControl query) {
            try {
                VPage<S_Control> page= _controlService.getPage(query);
            return new JsonResult(new { result = true,data=page, message = "操作成功" });
            }catch (Exception ex) {
                return new JsonResult(new { result = false,message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryControl query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_Control model = _controlService.GetById(query.Id);
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
