using System.Text.Json.Serialization;

namespace BlazorApp.Shared
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}