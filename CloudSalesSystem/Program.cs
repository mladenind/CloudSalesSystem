using CloudSalesSystem.Common.Filters;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Common.Services;
using CloudSalesSystem.Common.Utils;
using CloudSalesSystem.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

try
{
    // Logger configuration
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    Log.Information("App Startup");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();

    // Register API validator and filter, services, AutoMapper and MediatR
    builder.Services.AddTransient<IApiKeyValidator, ApiKeyValidator>();
    builder.Services.AddScoped<ApiKeyAuthFilter>();
    builder.Services.AddSingleton<ICloudComputingProviderService, CloudComputingProviderService>();
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Db setup
    var connectionString = builder.Configuration.GetConnectionString("AppDb");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    // API versioning
    builder.Services.AddApiVersioning(opt =>
    {
        opt.DefaultApiVersion = new ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.ReportApiVersions = true;
        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    });

    // Make the API aware of versioning
    builder.Services.AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        // Handle and log exceptions in Production mode 
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    return;
                }

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    Log.Error(contextFeature.Error.ToString());
                }
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = Text.Plain;
                await context.Response.WriteAsync("Oops, something went wrong. If you're a dev, check the logs for the exception details.");
            });
        });
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
    Log.Error(ex, "An error occurred starting the application");
}
finally
{
    Log.CloseAndFlush();
}
