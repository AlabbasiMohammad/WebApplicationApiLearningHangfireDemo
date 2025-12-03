using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WebApplicationApiDemo.Data;
using WebApplicationApiDemo.General;
using WebApplicationApiDemo.General.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// get connection string from appsettings.json
var hangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");

// Add services to the container.

//builder.Services.AddDbContext<ApiDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add EF Core and SQL Server connection
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionSqlServer")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMerchService, MerchService>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();


// hangfire client configuration
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSQLiteStorage(hangfireConnectionString));



// hangfire server configuration
builder.Services.AddHangfireServer();





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


app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire");


// RecurringJob.AddOrUpdate("Test-Job", () => Console.WriteLine("Hangfire is working!"), "* * * * *");



app.Run();
