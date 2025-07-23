namespace AppointmentSystem.Domain.Entities
{
    public class AppointmentService
    {
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }

}
