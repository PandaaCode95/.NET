using Microsoft.AspNetCore.Mvc;

namespace UniversityBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            _logger.LogTrace($"{nameof(WeatherForecastController)} - {nameof(Get)} - TraceSourceFactoryExtensions Level Log");
            _logger.LogDebug($"{nameof(WeatherForecastController)} - {nameof(Get)} -Debug Level log");
            _logger.LogInformation($"{nameof(WeatherForecastController)} - {nameof(Get)} -Information Level log");
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(Get)} -Warning Level log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(Get)} -Error Level log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(Get)} -Critical Level log");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}