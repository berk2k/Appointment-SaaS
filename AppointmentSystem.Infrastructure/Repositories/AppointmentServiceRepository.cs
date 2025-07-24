using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class AppointmentServiceRepository : IAppointmentServiceRepository
    {
        private readonly AppDbContext _context;

        public AppointmentServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AppointmentService entity)
        {
            await _context.AppointmentServices.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid appointmentId, Guid serviceId)
        {
            var entity = await _context.AppointmentServices
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId && a.ServiceId == serviceId);

            if (entity != null)
            {
                _context.AppointmentServices.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AppointmentService>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.AppointmentServices
                .Include(a => a.Service)
                .Where(a => a.AppointmentId == appointmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentService>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _context.AppointmentServices
                .Include(a => a.Appointment)
                .Where(a => a.ServiceId == serviceId)
                .ToListAsync();
        }

        public async Task<AppointmentService?> GetAsync(Guid appointmentId, Guid serviceId)
        {
            return await _context.AppointmentServices
                .Include(a => a.Appointment)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId && a.ServiceId == serviceId);
        }
    }
}
