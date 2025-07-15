using Serilog.Context;
using System.Security.Claims;

namespace AppointmentSystem.API.Middlewares
{
    public class RequestEnrichMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestEnrichMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenantId = context.Request.Headers["X-Tenant-Id"].FirstOrDefault() ?? "UnknownTenant";
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";

            using (LogContext.PushProperty("TenantId", tenantId))
            using (LogContext.PushProperty("UserId", userId))
            {
                await _next(context);
            }
        }
    }
}
