using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetByTenantIdAsync(Guid tenantId);
        Task<Branch?> GetWithUsersAsync(Guid branchId);
    }
}
