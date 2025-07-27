namespace AppointmentSystem.Application.DTOs.Customer
{
    public class CustomerListResponse
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TotalAppointments { get; set; }
        public DateTime? LastAppointment { get; set; }
    }
}
