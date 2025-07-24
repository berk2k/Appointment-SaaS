using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class AppointmentHistoryRepository : IAppointmentHistoryRepository
    {
        private readonly AppDbContext _context;

        public AppointmentHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AppointmentHistory entity)
        {
            await _context.AppointmentHistories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.AppointmentHistories
                .Include(h => h.ChangedByUser)
                .Where(h => h.AppointmentId == appointmentId)
                .OrderByDescending(h => h.ChangedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentHistory>> GetByUserIdAsync(Guid userId)
        {
            return await _context.AppointmentHistories
                .Include(h => h.Appointment)
                .Where(h => h.ChangedByUserId == userId)
                .OrderByDescending(h => h.ChangedAt)
                .ToListAsync();
        }

        public async Task<AppointmentHistory?> GetByIdAsync(Guid appointmentHistoryId)
        {
            return await _context.AppointmentHistories
                .Include(h => h.ChangedByUser)
                .Include(h => h.Appointment)
                .FirstOrDefaultAsync(h => h.AppointmentHistoryId == appointmentHistoryId);
        }
    }
}
