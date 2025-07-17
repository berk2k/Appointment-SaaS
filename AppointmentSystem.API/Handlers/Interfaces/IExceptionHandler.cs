namespace AppointmentSystem.API.Handlers.Interfaces
{
    public interface IExceptionHandler
    {
        bool CanHandle(Exception exception);
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
