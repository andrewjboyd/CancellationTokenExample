using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPlayAround.Database;

namespace WebApiPlayAround.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ExampleDbContext _exampleDbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ExampleDbContext exampleDbContext)
        {
            _logger = logger;
            _exampleDbContext = exampleDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var Id = Guid.NewGuid();
            _logger.LogInformation("Db Call start {ThreadId}. DateTime {DateTime}", Id, DateTime.Now);

            var result = await _exampleDbContext.WeatherForecasts.FromSqlRaw("EXECUTE dbo.GetWeatherDetails").ToListAsync();

            _logger.LogInformation("Db Call end {ThreadId}. DateTime {DateTime}", Id, DateTime.Now);
            return result;
        }
    }
}