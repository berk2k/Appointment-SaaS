using AppointmentSystem.API.Handlers.Interfaces;
using AppointmentSystem.Application.Exceptions;
using System.Text.Json;

namespace AppointmentSystem.API.Handlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is CustomNotFoundException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Resource not found",
                Details = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
