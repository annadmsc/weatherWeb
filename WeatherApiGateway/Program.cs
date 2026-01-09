using WeatherApiGateway.Services;
using WeatherApiGateway.Middleware;

//load da env para usar no appsettings 
DotNetEnv.Env.Load();


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IWeatherService, WeatherService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors("AllowFrontend");


app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();
app.Run();
