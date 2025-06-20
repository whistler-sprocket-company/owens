using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
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
