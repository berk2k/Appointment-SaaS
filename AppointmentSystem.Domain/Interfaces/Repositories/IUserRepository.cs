using AppointmentSystem.Domain.Entities;

namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
        Task<User?> GetWithBranchesAsync(Guid userId);
    }
}
