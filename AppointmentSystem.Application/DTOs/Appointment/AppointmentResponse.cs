using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class AppointmentResponse
    {
        public Guid AppointmentId { get; set; }
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public List<ServiceResponse> Services { get; set; } = new();
    }
}
