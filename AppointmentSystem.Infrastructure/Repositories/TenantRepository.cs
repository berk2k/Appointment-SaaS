using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant?> GetByIdAsync(Guid id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task AddAsync(Tenant entity)
        {
            await _context.Tenants.AddAsync(entity);
        }

        public void Update(Tenant entity)
        {
            _context.Tenants.Update(entity);
        }

        public void Delete(Tenant entity)
        {
            _context.Tenants.Remove(entity);
        }

        public async Task<Tenant?> GetByDomainAsync(string domain)
        {
            return await _context.Tenants
                .FirstOrDefaultAsync(t => t.Domain == domain);
        }

        public async Task<Tenant?> GetWithBranchesAsync(Guid tenantId)
        {
            return await _context.Tenants
                .Include(t => t.Branches)
                .FirstOrDefaultAsync(t => t.TenantId == tenantId);
        }
    }
}
