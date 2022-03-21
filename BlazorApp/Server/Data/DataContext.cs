namespace BlazorApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasData(
                new WeatherForecast
                {
                    Id = 1,
                    Date = DateTime.Now,
                    TemperatureC = 3,
                    Summary = "example"
                }
                );
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }

}
