using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<Tenant?> GetByDomainAsync(string domain);
        Task<Tenant?> GetWithBranchesAsync(Guid tenantId);
    }
}
