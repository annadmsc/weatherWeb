using System.Text.Json;
using WeatherApiGateway.DTOs;

namespace WeatherApiGateway.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherResponseDto> GetWeather(string city)
        {
            var baseUrl = _configuration["WeatherApi:BaseUrl"];
            var apiKey = _configuration["WeatherApi:ApiKey"];

            var url = $"{baseUrl}/current.json?key={apiKey}&q={city}&aqi=no";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;
           
            return new WeatherResponseDto
            {
                City = root.GetProperty("location").GetProperty("name").GetString() ?? city,
                TemperatureC = root.GetProperty("current").GetProperty("temp_c").GetDouble(),
                Condition = root.GetProperty("current").GetProperty("condition").GetProperty("text").GetString() ?? "",
                Humidity = root.GetProperty("current").GetProperty("humidity").GetInt32()

            };
        }
    }
}
