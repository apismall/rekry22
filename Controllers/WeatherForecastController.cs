using Microsoft.AspNetCore.Mvc;
using Entity;
using Data;
using Dto;

namespace rekry.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DataContext _dataContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<WeatherForecastDto> Get()
    {
        return _dataContext.Weather.Select(x => new WeatherForecastDto()
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            TemperatureF = x.TemperatureF,
            City = x.City,
            Summary = Summaries[summaryIndex(x.TemperatureC)]
        });
    }

    private int summaryIndex(int temperatureC)
    {
        // to adjust negative values so that minimum value is always >=0
        float adjustedTemperature = temperatureC + Math.Abs(_dataContext.temperatureMin);
        float temperatureRange = Math.Abs(_dataContext.temperatureMin) + Math.Abs(_dataContext.temperatureMax);
        float index = (float)Summaries.Length * (adjustedTemperature / temperatureRange);
        return (int)Math.Floor(index);
    }
}
