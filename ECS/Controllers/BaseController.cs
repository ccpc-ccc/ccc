using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class BaseController<T> : ControllerBase {
        private readonly CustomHSJWT _customHSJWT;
        private readonly ILogger<T> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        protected readonly S_User currentUser=null;
        protected readonly S_Company currentCompany=null;
        protected readonly S_Client currentClient=null;
        public BaseController(ILogger<T> _logger, CustomHSJWT _customHSJWT, IOptionsMonitor<ConnectionStrings> connectionString, IHttpContextAccessor httpContextAccessor) {
            this._logger = _logger;
            this._customHSJWT = _customHSJWT;
            _connectionString = connectionString;
            IUserService _userService = new UserService(connectionString.CurrentValue);
            ICompanyService _companyService = new CompanyService(connectionString.CurrentValue);
            IClientService _clientService = new ClientService(connectionString.CurrentValue);
            string bearer = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(bearer) || !bearer.Contains("Bearer")) return;
            string[] jwt = bearer.Split(' ');
            TypeAndValue UserId = CustomHSJWT.GetUserId(jwt[1]);
            if(UserId == null) return;
            if (UserId.Type=="User") {
                currentUser=_userService.GetById(UserId.Value);
            } else if (UserId.Type == "Company") {
                currentCompany = _companyService.GetById(UserId.Value);
            } else if (UserId.Type == "Client") {
                currentClient = _clientService.GetById(UserId.Value);
            }
        }
    }
}
