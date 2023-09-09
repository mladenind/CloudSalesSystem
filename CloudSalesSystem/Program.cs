using CloudSalesSystem.Common.Filters;
using CloudSalesSystem.Common.Interfaces;
using CloudSalesSystem.Common.Utils;
using CloudSalesSystem.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
   
    builder.Services.AddControllers(options =>
    {

    });
    builder.Services.AddTransient<IApiKeyValidator, ApiKeyValidator>();
    builder.Services.AddScoped<ApiKeyAuthFilter>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var connectionString = builder.Configuration.GetConnectionString("AppDb");
    builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

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
    await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
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

