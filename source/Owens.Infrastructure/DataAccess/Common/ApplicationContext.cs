using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Owens.Infrastructure.DataAccess.Common
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            WeatherForecasts = Set<WeatherForecast>();
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
