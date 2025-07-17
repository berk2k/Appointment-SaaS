using AppointmentSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Commands.Appointment
{
    public class CreateAppointmentCommand : IRequest<Guid>
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
