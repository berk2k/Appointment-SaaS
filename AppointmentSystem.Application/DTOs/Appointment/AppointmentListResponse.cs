using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class AppointmentListResponse
    {
        public Guid AppointmentId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string ServiceNames { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
