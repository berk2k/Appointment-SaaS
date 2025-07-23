namespace AppointmentSystem.Domain.Entities
{
    public class UserBranch
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }

        public string Role { get; set; }
    }

}
