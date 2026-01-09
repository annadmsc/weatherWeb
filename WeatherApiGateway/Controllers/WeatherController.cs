using Microsoft.AspNetCore.Mvc;
using WeatherApiGateway.Services;

namespace WeatherApiGateway.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City is required");

            var result = await _weatherService.GetWeather(city);
            return Ok(result);
        }
    }
}
