using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Notification entity)
        {
            await _context.Notifications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetByTenantIdAsync(Guid tenantId)
        {
            return await _context.Notifications
                .Where(n => n.TenantId == tenantId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.Notifications
                .Where(n => n.AppointmentId == appointmentId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(Guid notificationId)
        {
            return await _context.Notifications
                .Include(n => n.Tenant)
                .Include(n => n.Appointment)
                .FirstOrDefaultAsync(n => n.NotificationId == notificationId);
        }

        public async Task UpdateAsync(Notification entity)
        {
            _context.Notifications.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
