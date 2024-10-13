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
        ///���Խӿ�
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
                Console.WriteLine("���ݿ����Ӳ��ɹ�\n���������ļ�(MWS.exe.config)�е����ݿ�������Ϣ�����Ƿ���ȷ������ϵ�����Ӧ�̻�ȡ����.");
            }
            return isConnected;
        }
    }
}