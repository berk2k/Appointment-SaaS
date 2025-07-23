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
            if (context.Request.Headers.TryGetValue("X-Tenant-ID", out var tenantIdValues))
            {
                var tenantIdString = tenantIdValues.FirstOrDefault();

                if (Guid.TryParse(tenantIdString, out var tenantId))
                {
                    if (tenantContext is TenantContext concreteContext)
                    {
                        concreteContext.TenantId = tenantId;
                        concreteContext.IsActive = true;
                       
                        
                    }

                    
                    await _next(context);
                    return;
                }
            }

            
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("TenantId is missing or invalid.");
            return;
        }
    }


}
