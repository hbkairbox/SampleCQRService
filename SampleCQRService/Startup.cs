using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.DBContext;
using SampleCQRService.Infrastructure.Repositories.Persistence;
using SampleCQRService.Infrastructure.Repositories.ReadOnly;
using System.Reflection;

namespace SampleCQRService;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddMvc();

        services.AddControllers();

        services.AddDbContext<Context>(option => option.UseNpgsql(Configuration.GetConnectionString("SystemDBConnStr")));

        services.AddDbContext<IReadOnlyContext, ReadOnlyContext>(option => option.UseNpgsql(Configuration.GetConnectionString("SystemDBConnStr")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>());

        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryReadOnlyRepository, CategoryReadOnlyRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapControllers();
        });

     }
}
