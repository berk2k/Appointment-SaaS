using AppointmentSystem.Common.Interfaces.Mediator;
using AppointmentSystem.Domain.Enums;

namespace AppointmentSystem.Application.Commands.Appointment
{
    public class CreateAppointmentCommand : IRequest<Guid> // will return response dto 
    {
        public Guid TenantId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public AppointmentStatus Status { get; set; }
    }
}
