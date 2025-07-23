using AppointmentSystem.API.Middlewares;

namespace AppointmentSystem.API.Extensions
{
    public static class TenantMiddlewareExtension
    {
        public static IApplicationBuilder UseTenantHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenantMiddleware>();
        }
    }
}
