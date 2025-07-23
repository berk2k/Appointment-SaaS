namespace AppointmentSystem.Common.Multitenancy
{
    public class TenantContext : ITenantContext
    {
        public Guid TenantId { get; set; }
        public string Domain { get; set; }
        public string Plan { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }

        public TenantContext()
        {
            TenantId = Guid.Empty;
            Domain = string.Empty;
            Plan = string.Empty;
            Status = string.Empty;
            IsActive = true;
        }
    }
}

