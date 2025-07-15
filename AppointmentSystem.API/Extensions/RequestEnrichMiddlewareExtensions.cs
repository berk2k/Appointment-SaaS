using AppointmentSystem.API.Middlewares;

namespace AppointmentSystem.API.Extensions
{
    public static class RequestEnrichMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestEnrichLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestEnrichMiddleware>();
        }
    }
}
