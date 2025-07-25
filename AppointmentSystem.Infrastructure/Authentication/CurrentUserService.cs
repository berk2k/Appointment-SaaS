using AppointmentSystem.Application.Interfaces.Authentication;
using AppointmentSystem.Common.Multitenancy;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AppointmentSystem.Infrastructure.Authentication
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantContext _tenantContext;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            ITenantContext tenantContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantContext = tenantContext;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public Guid UserId =>
            Guid.TryParse(User?.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : Guid.Empty;

        public Guid TenantId => _tenantContext.TenantId;

        public string Email => User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

        public string PhoneNumber => User?.FindFirstValue(ClaimTypes.MobilePhone) ?? string.Empty;

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;
    }
}
