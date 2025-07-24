using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task<Service?> GetByIdAsync(Guid id);
        Task<IEnumerable<Service>> GetByTenantIdAsync(Guid tenantId);
        Task AddAsync(Service entity);
        void Update(Service entity);
        void Delete(Service entity);
    }
}
