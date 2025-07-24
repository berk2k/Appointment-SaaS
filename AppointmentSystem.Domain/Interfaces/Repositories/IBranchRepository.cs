using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetByTenantIdAsync(Guid tenantId);
        Task<Branch?> GetWithUsersAsync(Guid branchId);
    }
}
