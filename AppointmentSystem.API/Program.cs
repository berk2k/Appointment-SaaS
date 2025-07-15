using Microsoft.OpenApi.Models;
using AppointmentSystem.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// logging
builder.Host.UseCustomSerilog(builder.Configuration);


var configuration = builder.Configuration;


builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AppointmentSystem API",
        Version = "v1"
    });
});

var app = builder.Build();

// Middleware pipeline
app.UseGlobalExceptionHandling();
// logging
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Starting web host");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
