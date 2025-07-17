using AppointmentSystem.API.Handlers.Interfaces;
using System.Text.Json;

namespace AppointmentSystem.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _next = next;
            _logger = logger;
            _exceptionHandlers = exceptionHandlers;
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

                var handler = _exceptionHandlers.FirstOrDefault(h => h.CanHandle(ex));
                if (handler != null)
                {
                    await handler.HandleAsync(context, ex);
                }
                else
                {
                    await HandleUnknownExceptionAsync(context, ex);
                }
            }
        }

        private static async Task HandleUnknownExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "An internal server error occurred.",
                details = exception.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

}
