using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public WeatherForecastController(ApplicationContext context)
        {
            _context = context;
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
