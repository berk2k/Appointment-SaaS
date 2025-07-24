using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.User)
                .Include(a => a.Branch)
                .Include(a => a.Tenant)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task AddAsync(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
        }

        public void Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
        }

        public void Delete(Appointment entity)
        {
            _context.Appointments.Remove(entity);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByTenantAsync(Guid tenantId)
        {
            return await _context.Appointments
                .Where(a => a.TenantId == tenantId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByBranchAsync(Guid branchId)
        {
            return await _context.Appointments
                .Where(a => a.BranchId == branchId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByUserAsync(Guid userId)
        {
            return await _context.Appointments
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }
    }
}
