using ESC.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YF.MWS.BaseMetadata;

namespace ESC.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOptionsMonitor<ConnectionStrings> _connectionString;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptionsMonitor<ConnectionStrings> connectionString) {
            _logger = logger;
            _connectionString = connectionString;
        }
        /// <summary>
        ///测试接口
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        public bool CheckDbConfig() {
            bool isConnected = false;
            try {
            } catch (Exception e) {
                this._logger.LogError(e.Message);
                Console.WriteLine(e.Message);
            }
            if (!isConnected) {
                Console.WriteLine("数据库连接不成功\n请检查配置文件(MWS.exe.config)中的数据库连接信息配置是否正确或者联系软件供应商获取帮助.");
            }
            return isConnected;
        }
    }
}