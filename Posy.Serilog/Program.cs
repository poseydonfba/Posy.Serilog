using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Posy.Serilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, config) => {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    config.WriteTo.PostgreSQL(connectionString, "Logs", needAutoCreateTable: true)
                        .MinimumLevel.Information();

                    if (context.HostingEnvironment.IsProduction() == false)
                    {
                        config.WriteTo.Console().MinimumLevel.Information();
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
