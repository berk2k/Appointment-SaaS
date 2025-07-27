namespace AppointmentSystem.Application.DTOs.User
{
    public class AssignUserToTenantRequest
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
