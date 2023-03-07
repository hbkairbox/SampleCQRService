using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SampleCQRService.Infrastructure.DBContext;
using SampleCQRService.Infrastructure.Repositories.Persistence;
using SampleCQRService.Infrastructure.Repositories.ReadOnly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("SystemDBConnStr")));

builder.Services.AddDbContext<IReadOnlyContext, ReadOnlyContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("SystemDBConnStr")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());


builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryReadOnlyRepository, CategoryReadOnlyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
