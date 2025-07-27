namespace AppointmentSystem.Application.DTOs.Tenant
{
    public class CreateTenantRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
    }
}
