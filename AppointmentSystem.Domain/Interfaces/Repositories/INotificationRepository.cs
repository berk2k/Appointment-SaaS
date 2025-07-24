using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task AddAsync(Notification entity);
        Task<IEnumerable<Notification>> GetByTenantIdAsync(Guid tenantId);
        Task<IEnumerable<Notification>> GetByAppointmentIdAsync(Guid appointmentId);
        Task<Notification?> GetByIdAsync(Guid notificationId);
        Task UpdateAsync(Notification entity);
    }
}
