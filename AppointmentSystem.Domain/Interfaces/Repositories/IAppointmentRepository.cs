namespace AppointmentSystem.Domain.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByTenantAsync(Guid tenantId);
        Task<IEnumerable<Appointment>> GetAppointmentsByBranchAsync(Guid branchId);
        Task<IEnumerable<Appointment>> GetAppointmentsByUserAsync(Guid userId);
    }
}
