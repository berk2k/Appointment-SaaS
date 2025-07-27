using AppointmentSystem.Application.DTOs.Branch;

namespace AppointmentSystem.Application.DTOs.User
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<string> TenantRoles { get; set; } = new();
        public List<BranchRoleResponse> BranchRoles { get; set; } = new();
    }
}
