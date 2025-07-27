using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class CalendarAppointmentResponse
    {
        public Guid AppointmentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
