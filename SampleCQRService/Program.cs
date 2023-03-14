using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.DBContext;

namespace SampleCQRService;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .Build();

        try
        {
            var host = CreateHostBuilder(args)
                .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                .Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            host.Run();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseStartup<Startup>();
            });
}