using AppointmentSystem.Domain.ValueObjects;

namespace AppointmentSystem.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TenantUser> TenantUsers { get; set; }

        public ICollection<UserBranch> UserBranches { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
