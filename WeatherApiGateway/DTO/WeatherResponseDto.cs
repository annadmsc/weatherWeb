namespace WeatherApiGateway.DTOs
{
    public class WeatherResponseDto
    {
        public string City { get; set; } = string.Empty;
        public double TemperatureC { get; set; }
        public string Condition { get; set; } = string.Empty;
        public int Humidity { get; set; }
    }
}
