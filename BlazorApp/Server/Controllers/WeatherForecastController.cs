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


        // WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetWeatherForecasts()
        {
            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
            return Ok(weatherForecasts);
        }

        [HttpPut] // PUT = Create
        public async Task<ActionResult<List<WeatherForecast>>> PutWeatherForecasts(WeatherForecast[] weatherForecast)
        {
            
            foreach (var singleweatherForecast in weatherForecast)
            {
                _context.WeatherForecasts.Add(singleweatherForecast);
            }
           
            await _context.SaveChangesAsync();

            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
            return Ok(weatherForecasts);
        }



        // SingleWeatherForecast
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetSingleWeatherForecasts(int id)
        {
            var singleweatherForecast = await _context.WeatherForecasts
                .FirstOrDefaultAsync(x => x.Id == id);

            if (singleweatherForecast == null)
            {
                return NotFound("No WeatherForecast Id avaialbe");
            }

            return Ok(singleweatherForecast);
        }


        [HttpPost("{id}")] // POST = Update
        public async Task<ActionResult<WeatherForecast>>PostSingleWeatherForecasts(WeatherForecast request)
        {
            var singleweatherForecast = await _context.WeatherForecasts
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (singleweatherForecast == null)
            {
                return BadRequest("No WeatherForecast Id avaialbe"); // change?
            }
            singleweatherForecast.Date = request.Date;
            singleweatherForecast.TemperatureC = request.TemperatureC;
            singleweatherForecast.Summary = request.Summary;

            await _context.SaveChangesAsync();

            return Ok(singleweatherForecast);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSingleWeatherForecasts(int id)
        {
            var singleweatherForecast = await _context.WeatherForecasts
                .FirstOrDefaultAsync(x => x.Id == id);
            if (singleweatherForecast == null)
            {
                return NotFound("No WeatherForecast Id avaialbe");
            }

            _context.WeatherForecasts.Remove(singleweatherForecast);
            await _context.SaveChangesAsync();


            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
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