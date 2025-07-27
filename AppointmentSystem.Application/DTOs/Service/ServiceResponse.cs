namespace AppointmentSystem.Application.DTOs.Service
{
    public class ServiceResponse
    {
        public Guid ServiceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
