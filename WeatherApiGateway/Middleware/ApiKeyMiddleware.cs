namespace WeatherApiGateway.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER = "X-API-Key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Libera CORS
            if (context.Request.Method == HttpMethods.Options)
            {
                await _next(context);
                return;
            }

            // Libera Swagger
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key missing");
                return;
            }

            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration["ApiKey"];

            if (!string.Equals(apiKey, extractedApiKey.ToString()))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await _next(context);
        }
    }
}
