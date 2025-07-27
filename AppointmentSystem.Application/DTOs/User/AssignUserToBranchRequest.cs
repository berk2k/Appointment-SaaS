namespace AppointmentSystem.Application.DTOs.User
{
    public class AssignUserToBranchRequest
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
