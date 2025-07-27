namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class CreateAppointmentRequest
    {
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Guid> ServiceIds { get; set; } = new();
    }
}
