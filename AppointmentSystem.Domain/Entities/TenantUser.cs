namespace AppointmentSystem.Domain.Entities
{
    public class TenantUser
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Role { get; set; }
    }
}
