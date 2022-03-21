using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetWeatherForecasts()
        {
            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
            return Ok(weatherForecasts);
        }

        [HttpPost]
        public async Task<ActionResult<List<WeatherForecast>>> PostWeatherForecasts(WeatherForecast weatherForecast)
        {
            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();

            weatherForecasts.Add(weatherForecast);

            return Ok(weatherForecasts);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetSingleWeatherForecasts(int id)
        {
            var weatherForecasts = await _context.WeatherForecasts
                .FirstOrDefaultAsync(x => x.Id == id);
            if (weatherForecasts == null)
            {
                return NotFound("No WeatherForecast Id avaialbe");
            }
            return Ok(weatherForecasts);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeatherForecast>> PutSingleWeatherForecasts(WeatherForecast request_weatherForecast)
        {
            var weatherForecasts = await _context.WeatherForecasts
                .FirstOrDefaultAsync(x => x.Id == request_weatherForecast.id);
            if (weatherForecasts == null)
            {
                return NotFound("No WeatherForecast Id avaialbe");
            }
            return Ok(weatherForecasts);
        }





        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet]
        //    public IEnumerable<WeatherForecast> Get()
        //    {
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Id = index,
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
    }
}