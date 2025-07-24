using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Branch?> GetByIdAsync(Guid id)
        {
            return await _context.Branches.FindAsync(id);
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task AddAsync(Branch entity)
        {
            await _context.Branches.AddAsync(entity);
        }

        public void Update(Branch entity)
        {
            _context.Branches.Update(entity);
        }

        public void Delete(Branch entity)
        {
            _context.Branches.Remove(entity);
        }

        public async Task<IEnumerable<Branch>> GetByTenantIdAsync(Guid tenantId)
        {
            return await _context.Branches
                .Where(b => b.TenantId == tenantId)
                .ToListAsync();
        }

        public async Task<Branch?> GetWithUsersAsync(Guid branchId)
        {
            return await _context.Branches
                .Include(b => b.UserBranches)      // Branch-User pivot table
                    .ThenInclude(ub => ub.User)    
                .FirstOrDefaultAsync(b => b.BranchId == branchId);
        }

    }
}
