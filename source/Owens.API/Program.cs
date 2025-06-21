


using System.Diagnostics;
using Owens.Infrastructure.DataAccess.Common;
using Scalar.AspNetCore;

namespace Owens.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            Debug.Print(builder.Configuration.GetConnectionString("Database"));
            builder.Services.AddSqlServer<ApplicationContext>(builder.Configuration.GetConnectionString("Database"));

            var app = builder.Build();

            app.MapOpenApi();
            app.MapScalarApiReference();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
