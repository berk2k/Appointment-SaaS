namespace AppointmentSystem.Application.Exceptions
{
    public class CustomUnauthorizedException : Exception
    {
        public CustomUnauthorizedException(string message) : base(message) { }
        public CustomUnauthorizedException() : base("Unauthorized access") { }
    }
}
