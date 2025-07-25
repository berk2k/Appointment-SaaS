using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Application.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, Guid activeTenantId);
    }
}
