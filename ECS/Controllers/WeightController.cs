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
    public class WeightController : BaseController<WeightController> {
        private readonly ILogger<WeightController> _logger;
        private readonly IWeightService _weightService;
        private readonly ICarService _carService;
        private readonly IWarehService _warehService;
        private readonly IMaterialService _materialService;
        private readonly ICustomerService _customerService;
        public WeightController(ILogger<WeightController> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) : base(_logger, _customHSJWT, connectionString, httpContextAccessor) {
            this._logger = _logger;
            _weightService = new WeightService(connectionString.CurrentValue);
            _carService = new CarService(connectionString.CurrentValue);
            _warehService = new WarehService(connectionString.CurrentValue);
            _materialService = new MaterialService(connectionString.CurrentValue);
            _customerService = new CustomerService(connectionString.CurrentValue);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPost]
        public IActionResult del([FromBody] QueryWeight user) {
            bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
            if (!isVerify) {
                return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
            }
            bool isDel = _weightService.Delete(user.Id);
            if (isDel) {
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User,Company")]
        [HttpPost]
        public IActionResult add([FromBody] QueryWeight weight) {
            if (weight != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "carNo", "MaterialId" }, weight);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                if(currentUser != null) { weight.CompanyId = currentUser.CompanyId; }
                else if (currentCompany != null) { weight.CompanyId = currentCompany.Id; }
                S_Car old = new QueryCar() { CarNo = weight.CarNo, CompanyId = weight.CompanyId };
                S_Car car=_carService.GetByNo(old);
                if (car == null) _carService.save(old);
                weight.FinishState = 0;
                _weightService.save(weight);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        [HttpPost]
        public IActionResult upState([FromBody] QueryWeight weight) {
            if (weight != null) {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id", "FinishState" }, weight);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                _weightService.upState(weight);
                return new JsonResult(new { result = true, message = "操作成功" });
            } else {
                return new JsonResult(new { result = false, message = "操作失败" });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="User,Company")]
        [HttpPost]
        public IActionResult getPage([FromBody] QueryWeight user) {
            try {
                if (currentUser!=null&&currentUser.CompanyId!=null&&currentUser.CompanyId!="")
                {
                    user.CompanyId = currentUser.CompanyId;
                } else if (currentCompany != null && currentCompany.Id != null && currentCompany.Id != "") {
                    user.CompanyId = currentCompany.Id;
                }
                VPage<B_Weight> page = _weightService.getPage(user);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Company")]
        [HttpPost]
        public IActionResult getWxPage([FromBody] QueryWeight user) {
            try {
                VPage<B_Weight> page = _weightService.getWxPage(user);
                return new JsonResult(new { result = true, data = page, message = "操作成功" });
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult getModel([FromBody] QueryWeight user) {
            try {
                bool isVerify = UtilityQuery.Verify(new string[] { "Id" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                B_Weight model = _weightService.Get(user.Id);
                if (model != null) {
                    return new JsonResult(new { result = true, data = model, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "操作失败" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Client")]
        [HttpPost]
        public IActionResult getModelState1([FromBody] QueryWeight user) {
           try {
                bool isVerify = UtilityQuery.Verify(new string[] { "CarNo" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                B_Weight model = _weightService.GetByState1(user);
                if (model != null) {
                    return new JsonResult(new { result = true, model = model, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "操作失败" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
        /// <summary>
        /// 上传称重完成的数据 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Client")]
        [HttpPost]
        public IActionResult doneWeight([FromBody] QueryWeight user) {
           try {
                bool isVerify = UtilityQuery.Verify(new string[] { "CarNo" }, user);
                if (!isVerify) {
                    return new JsonResult(new { result = false, message = UtilityQuery.errMsg });
                }
                S_Car old = new S_Car() { CompanyId = user.CompanyId, CarNo = user.CardNo };
                S_Car car=_carService.clientToModel(old);
                if (car != null) { user.CarId = car.Id; } else user.CarId = null;

                S_Wareh warehOld = new S_Wareh() { CompanyId = user.CompanyId, WarehName = user.WarehName };
                S_Wareh wareh= _warehService.clientToModel(warehOld);
                if (wareh != null) { user.WarehId = wareh.Id; } else user.WarehId = null;

                QueryMaterial materialOld = new QueryMaterial() { CompanyId = user.CompanyId, MaterialName = user.MaterailName };
                S_Material material = _materialService.clientToModel(materialOld);
                if (material != null) { user.MaterialId = material.Id; } else user.WarehId = null;

                QueryCustomer customerOld = new QueryCustomer() { CompanyId = user.CompanyId,CustomerType=CustomerType.Customer.ToString(), CustomerName = user.CustomerName };
                S_Customer customer = _customerService.clientToModel(customerOld);
                if (wareh != null) { user.CustomerId = customer.Id; } else user.CustomerId = null;
                user.FinishState = 2;
                bool isOk=_weightService.doneWeight(user);
                if (isOk) {
                    return new JsonResult(new { result = true, message = "操作成功" });
                } else {
                    return new JsonResult(new { result = false, message = "操作失败" });
                }
            } catch (Exception ex) {
                return new JsonResult(new { result = false, message = ex.Message });
            }
        }
    }
}
