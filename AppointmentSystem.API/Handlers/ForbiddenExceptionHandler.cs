using AppointmentSystem.API.Handlers.Interfaces;
using AppointmentSystem.Application.Exceptions;
using System.Text.Json;

namespace AppointmentSystem.API.Handlers
{
    public class ForbiddenExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is CustomForbiddenException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Forbidden",
                Details = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
       
    }
}
