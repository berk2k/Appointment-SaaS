using AppointmentSystem.API.Middlewares;

namespace AppointmentSystem.API.Extensions
{
    public static class TenantAccessMiddlewareExtension
    {
        public static IApplicationBuilder UseTenantAccessHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenantAccessMiddleware>();
        }
    }
}
