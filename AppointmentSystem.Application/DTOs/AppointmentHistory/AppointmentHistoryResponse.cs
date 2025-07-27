namespace AppointmentSystem.Application.DTOs.AppointmentHistory
{
    public class AppointmentHistoryResponse
    {
        public Guid AppointmentHistoryId { get; set; }
        public string ChangedByUserName { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
}
