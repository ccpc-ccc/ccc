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

namespace ESC.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerController> {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) :base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            _customerService = new CustomerService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        [HttpPost]
        public IActionResult del([FromBody] QueryCustomer query) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
              bool isDel= _customerService.Delete(query.Id);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User")]
        [HttpPost]
        public IActionResult save([FromBody] QueryCustomer query) {
            if (query != null) {
            bool isVerify = UtilityQuery.Verify(new string[] { "CustomerName","CustomerCode" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                if (currentUser != null) { query.CompanyId = currentUser.CompanyId; }
                if (query.Id == null) {
                    S_Customer old = _customerService.GetByCode(query);
                    if (old != null) {
                        return new JsonResult(new { result = false, message = "客户编码已存在" });
                    }
                }
                _customerService.save(query);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User,Company")]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryCustomer query) {
            try {
                if (currentUser != null) { query.CompanyId = currentUser.CompanyId; } 
                else if (currentCompany != null && currentCompany.Id != null && currentCompany.Id != "") {
                    query.CompanyId = currentCompany.Id;
                }
                VPage<S_Customer> page= _customerService.getPage(query);
            return new JsonResult(new { result = true,data=page, message = "操作成功" });
            }catch (Exception ex) {
                return new JsonResult(new { result = false,message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryCustomer query) {
            try {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, query);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
                S_Customer model = _customerService.Get(query.Id);
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
