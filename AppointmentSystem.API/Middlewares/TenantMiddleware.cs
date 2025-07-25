using AppointmentSystem.Application.Exceptions;
using AppointmentSystem.Common.Multitenancy;

namespace AppointmentSystem.API.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
        {
            var user = context.User;

            if (user?.Identity?.IsAuthenticated != true)
            {
                throw new CustomUnauthorizedException("User is not authenticated.");
            }

            var tenantIdClaim = user.FindFirst("tenantId");

            if (tenantIdClaim == null || !Guid.TryParse(tenantIdClaim.Value, out var tenantId))
            {
                throw new CustomUnauthorizedException("TenantId claim is missing or invalid.");
            }

            if (tenantContext is TenantContext concreteContext)
            {
                concreteContext.TenantId = tenantId;
                concreteContext.IsActive = true;
            }

            await _next(context);
        }
    }
}
