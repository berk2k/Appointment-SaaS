namespace AppointmentSystem.Application.DTOs.Branch
{
    public class BranchResponse
    {
        public Guid BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
