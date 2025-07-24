using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Interfaces.Repositories;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Infrastructure.Repositories
{
    public class UserBranchRepository : IUserBranchRepository
    {
        private readonly AppDbContext _context;

        public UserBranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserBranch entity)
        {
            await _context.UserBranches.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid userId, Guid branchId)
        {
            var userBranch = await _context.UserBranches
                .FirstOrDefaultAsync(ub => ub.UserId == userId && ub.BranchId == branchId);

            if (userBranch != null)
            {
                _context.UserBranches.Remove(userBranch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserBranch>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserBranches
                .Include(ub => ub.Branch)
                .Where(ub => ub.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserBranch>> GetByBranchIdAsync(Guid branchId)
        {
            return await _context.UserBranches
                .Include(ub => ub.User)
                .Where(ub => ub.BranchId == branchId)
                .ToListAsync();
        }

        public async Task<UserBranch?> GetAsync(Guid userId, Guid branchId)
        {
            return await _context.UserBranches
                .Include(ub => ub.User)
                .Include(ub => ub.Branch)
                .FirstOrDefaultAsync(ub => ub.UserId == userId && ub.BranchId == branchId);
        }
    }
}
