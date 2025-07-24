using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Service?> GetByIdAsync(Guid id)
        {
            return await _context.Services
                .Include(s => s.Tenant)
                .FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public async Task<IEnumerable<Service>> GetByTenantIdAsync(Guid tenantId)
        {
            return await _context.Services
                .Where(s => s.TenantId == tenantId)
                .ToListAsync();
        }

        public async Task AddAsync(Service entity)
        {
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Service entity)
        {
            _context.Services.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Service entity)
        {
            _context.Services.Remove(entity);
            _context.SaveChanges();
        }
    }
}
