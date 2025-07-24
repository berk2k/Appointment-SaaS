using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces.Repositories;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> GetByEmailAsync(string email);
        Task<Customer?> GetByPhoneNumberAsync(string email);
        Task<Customer?> GetWithAppointmentsAsync(Guid customerId);
    }
}
