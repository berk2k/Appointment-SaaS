using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class CustomerTenantRepository : ICustomerTenantRepository
    {
        private readonly AppDbContext _context;

        public CustomerTenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomerTenant entity)
        {
            await _context.CustomerTenants.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid customerId, Guid tenantId)
        {
            var relation = await _context.CustomerTenants
                .FirstOrDefaultAsync(ct => ct.CustomerId == customerId && ct.TenantId == tenantId);

            if (relation != null)
            {
                _context.CustomerTenants.Remove(relation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CustomerTenant>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.CustomerTenants
                .Include(ct => ct.Tenant)
                .Where(ct => ct.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerTenant>> GetByTenantIdAsync(Guid tenantId)
        {
            return await _context.CustomerTenants
                .Include(ct => ct.Customer)
                .Where(ct => ct.TenantId == tenantId)
                .ToListAsync();
        }

        public async Task<CustomerTenant?> GetAsync(Guid customerId, Guid tenantId)
        {
            return await _context.CustomerTenants
                .Include(ct => ct.Customer)
                .Include(ct => ct.Tenant)
                .FirstOrDefaultAsync(ct => ct.CustomerId == customerId && ct.TenantId == tenantId);
        }
    }
}
