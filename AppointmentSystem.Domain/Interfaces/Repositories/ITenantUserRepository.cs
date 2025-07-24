using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface ITenantUserRepository
    {
        Task AddAsync(TenantUser entity);
        Task RemoveAsync(Guid tenantId, Guid userId);
        Task<IEnumerable<TenantUser>> GetByTenantIdAsync(Guid tenantId);
        Task<IEnumerable<TenantUser>> GetByUserIdAsync(Guid userId);
        Task<TenantUser?> GetAsync(Guid tenantId, Guid userId);
    }
}
