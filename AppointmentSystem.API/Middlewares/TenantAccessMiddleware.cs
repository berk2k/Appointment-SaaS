﻿using AppointmentSystem.Application.Exceptions;

namespace AppointmentSystem.API.Middlewares
{
    public class TenantAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString();

            // Tenant ID URL /api/{tenantId}/...
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length > 1 && segments[0].ToLower() == "api")
            {
                var routeTenantId = segments[1];

                var userTenantId = context.User.FindFirst("tenantId")?.Value;

                
                if (context.User.Identity?.IsAuthenticated == true && !string.IsNullOrEmpty(userTenantId))
                {
                    if (!string.Equals(routeTenantId, userTenantId, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new CustomForbiddenException("Forbidden access");
                        
                    }
                }
            }

            await _next(context);
        }
    }
}
