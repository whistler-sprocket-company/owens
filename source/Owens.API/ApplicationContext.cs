using Microsoft.EntityFrameworkCore;

namespace Owens.API
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
