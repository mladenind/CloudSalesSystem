using CloudSalesSystem.Common.Filters;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Common.Services;
using CloudSalesSystem.Common.Utils;
using CloudSalesSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers()
        ;
    builder.Services.AddTransient<IApiKeyValidator, ApiKeyValidator>();
    builder.Services.AddScoped<ApiKeyAuthFilter>();
    builder.Services.AddSingleton<ICloudComputingProviderService, CloudComputingProviderService>();
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var connectionString = builder.Configuration.GetConnectionString("AppDb");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddApiVersioning(opt =>
    {
        opt.DefaultApiVersion = new ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.ReportApiVersions = true;
        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    });

    builder.Services.AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });

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

    // Apply migrations on app start
    using var scope = app.Services.CreateScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();

    app.Run();
}
catch (Exception ex)
{
    Log.Warning(ex, "An error occurred starting the application");
}
finally
{
    Log.CloseAndFlush();
}
