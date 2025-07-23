namespace AppointmentSystem.Domain.Entities
{
    public class Branch
    {
        public Guid BranchId { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public Tenant Tenant { get; set; }

        public ICollection<UserBranch> UserBranches { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }

}
