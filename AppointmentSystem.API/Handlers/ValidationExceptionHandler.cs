using AppointmentSystem.API.Handlers.Interfaces;
using AppointmentSystem.Application.Exceptions;
using FluentValidation;
using System.Text.Json;

namespace AppointmentSystem.API.Handlers
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is CustomValidationException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var validationException = (ValidationException)exception;
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });

            var response = new
            {
                Message = "Validation Failed",
                Errors = errors
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
