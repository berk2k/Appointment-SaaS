using Microsoft.OpenApi.Models;
using AppointmentSystem.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;

// Katmanlarý ekliyoruz
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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
