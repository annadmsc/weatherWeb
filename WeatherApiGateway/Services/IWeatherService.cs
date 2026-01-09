using WeatherApiGateway.DTOs;

namespace WeatherApiGateway.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponseDto> GetWeather(string city);
    }
}
