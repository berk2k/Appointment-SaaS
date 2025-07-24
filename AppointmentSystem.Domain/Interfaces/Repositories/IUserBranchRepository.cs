using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface IUserBranchRepository
    {
        Task AddAsync(UserBranch entity);
        Task RemoveAsync(Guid userId, Guid branchId);
        Task<IEnumerable<UserBranch>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserBranch>> GetByBranchIdAsync(Guid branchId);
        Task<UserBranch?> GetAsync(Guid userId, Guid branchId);
    }
}
