namespace AppointmentSystem.Application.Interfaces.Authentication
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        Guid TenantId { get; }
        string Email { get; }
        string PhoneNumber { get; }
        bool IsAuthenticated { get; }
    }
}
