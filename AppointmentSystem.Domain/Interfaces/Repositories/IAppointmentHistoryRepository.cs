using AppointmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentSystem.Domain.Interfaces
{
    public interface IAppointmentHistoryRepository
    {
        Task AddAsync(AppointmentHistory entity);
        Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(Guid appointmentId);
        Task<IEnumerable<AppointmentHistory>> GetByUserIdAsync(Guid userId);
        Task<AppointmentHistory?> GetByIdAsync(Guid appointmentHistoryId);
    }
}
