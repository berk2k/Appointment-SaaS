using AppointmentSystem.API.Handlers.Interfaces;
using AppointmentSystem.Application.Exceptions;
using System.Text.Json;

namespace AppointmentSystem.API.Handlers
{
    public class UnauthorizedExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is CustomUnauthorizedException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Unauthorized",
                Details = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
