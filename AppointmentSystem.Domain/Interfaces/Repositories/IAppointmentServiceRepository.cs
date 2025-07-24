using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface IAppointmentServiceRepository
    {
        Task AddAsync(AppointmentService entity);
        Task RemoveAsync(Guid appointmentId, Guid serviceId);
        Task<IEnumerable<AppointmentService>> GetByAppointmentIdAsync(Guid appointmentId);
        Task<IEnumerable<AppointmentService>> GetByServiceIdAsync(Guid serviceId);
        Task<AppointmentService?> GetAsync(Guid appointmentId, Guid serviceId);
    }
}
