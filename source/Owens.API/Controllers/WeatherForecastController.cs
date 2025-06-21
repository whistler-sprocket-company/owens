using Microsoft.AspNetCore.Mvc;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("conn-string")]
        public IActionResult ConnString()
        {
            return Ok(_configuration.GetConnectionString("Database"));
        }

        [HttpPost]
        public ActionResult Index()
        {
            try
            {
                _context.WeatherForecasts.Add(new WeatherForecast());

                var result = _context.SaveChanges();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType<IEnumerable<string>>(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var result = new List<string>
            {
                "Boeing",
                "Airbus",
                "Embraer",
            };

            return Ok(result);
        }
    }
}
