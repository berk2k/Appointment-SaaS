namespace AppointmentSystem.Application.DTOs.Notification
{
    public class NotificationResponse
    {
        public Guid NotificationId { get; set; }
        public Guid AppointmentId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
