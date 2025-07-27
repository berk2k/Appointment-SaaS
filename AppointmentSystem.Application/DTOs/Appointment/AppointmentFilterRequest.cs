using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.DTOs.Appointment
{
    public class AppointmentFilterRequest
    {
        public Guid? BranchId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
