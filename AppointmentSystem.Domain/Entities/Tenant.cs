namespace AppointmentSystem.Domain.Entities
{
    public class Tenant
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Plan { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; }

        public ICollection<Branch> Branches { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }

        public ICollection<CustomerTenant> CustomerTenants { get; set; }

        public ICollection<Appointment> Appointments { get; set;}
    }
}
