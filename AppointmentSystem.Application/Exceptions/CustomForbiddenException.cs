namespace AppointmentSystem.Application.Exceptions
{
    internal class CustomForbiddenException : Exception
    {
        public CustomForbiddenException(string message) : base(message) { }
        public CustomForbiddenException() : base("Forbidden access") { }
    }
}
