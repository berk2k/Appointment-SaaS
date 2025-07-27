using AppointmentSystem.Application.DTOs.Branch;

namespace AppointmentSystem.Application.DTOs.Tenant
{
    public class TenantResponse
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Plan { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<BranchResponse> Branches { get; set; } = new();
    }
}
