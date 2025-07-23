using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Domain.Enums;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } 

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public AppointmentStatus Status { get; set; }
}
