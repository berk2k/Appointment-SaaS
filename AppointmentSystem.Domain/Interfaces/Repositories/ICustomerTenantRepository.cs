using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface ICustomerTenantRepository
    {
        Task AddAsync(CustomerTenant entity);
        Task RemoveAsync(Guid customerId, Guid tenantId);
        Task<IEnumerable<CustomerTenant>> GetByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<CustomerTenant>> GetByTenantIdAsync(Guid tenantId);
        Task<CustomerTenant?> GetAsync(Guid customerId, Guid tenantId);
    }
}
