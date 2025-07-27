namespace AppointmentSystem.Application.DTOs.Branch
{
    public class BranchRoleResponse
    {
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
