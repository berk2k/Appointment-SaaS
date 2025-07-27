using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class UpdateAppointmentRequest
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public AppointmentStatus? Status { get; set; }
        public List<Guid>? ServiceIds { get; set; }
    }
}
