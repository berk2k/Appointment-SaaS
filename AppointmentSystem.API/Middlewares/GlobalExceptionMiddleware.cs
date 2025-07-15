using AppointmentSystem.Application.Exceptions;
using System.Text.Json;

namespace AppointmentSystem.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "An error occurred",
                details = exception.Message
            };

            context.Response.StatusCode = exception switch
            {
                CustomNotFoundException => 404,
                CustomValidationException => 400,
                CustomUnauthorizedException => 401,
                _ => 500
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }


    }
}
