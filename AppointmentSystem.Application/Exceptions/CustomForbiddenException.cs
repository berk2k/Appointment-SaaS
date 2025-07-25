namespace AppointmentSystem.Application.Exceptions
{
    public class CustomForbiddenException : Exception
    {
        public CustomForbiddenException(string message) : base(message) { }
        public CustomForbiddenException() : base("Forbidden access") { }
    }
}
