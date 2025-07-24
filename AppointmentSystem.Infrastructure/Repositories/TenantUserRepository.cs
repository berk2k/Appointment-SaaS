using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class TenantUserRepository : ITenantUserRepository
    {
        private readonly AppDbContext _context;

        public TenantUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TenantUser entity)
        {
            await _context.TenantUsers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid tenantId, Guid userId)
        {
            var tenantUser = await _context.TenantUsers
                .FirstOrDefaultAsync(tu => tu.TenantId == tenantId && tu.UserId == userId);

            if (tenantUser != null)
            {
                _context.TenantUsers.Remove(tenantUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TenantUser>> GetByTenantIdAsync(Guid tenantId)
        {
            return await _context.TenantUsers
                .Include(tu => tu.User)
                .Where(tu => tu.TenantId == tenantId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TenantUser>> GetByUserIdAsync(Guid userId)
        {
            return await _context.TenantUsers
                .Include(tu => tu.Tenant)
                .Where(tu => tu.UserId == userId)
                .ToListAsync();
        }

        public async Task<TenantUser?> GetAsync(Guid tenantId, Guid userId)
        {
            return await _context.TenantUsers
                .Include(tu => tu.Tenant)
                .Include(tu => tu.User)
                .FirstOrDefaultAsync(tu => tu.TenantId == tenantId && tu.UserId == userId);
        }
    }
}
