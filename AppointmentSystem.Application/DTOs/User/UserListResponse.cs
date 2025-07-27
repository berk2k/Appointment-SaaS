namespace AppointmentSystem.Application.DTOs.User
{
    public class UserListResponse
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<string> BranchNames { get; set; } = new();
    }
}
