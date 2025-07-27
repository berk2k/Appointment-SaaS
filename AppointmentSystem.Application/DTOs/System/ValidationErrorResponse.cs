namespace AppointmentSystem.Application.DTOs.System
{
    public class ValidationErrorResponse
    {
        public string Field { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
