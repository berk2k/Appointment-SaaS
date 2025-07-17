namespace AppointmentSystem.API.Middlewares.Interfaces
{
    public interface IExceptionHandlerMiddleware
    {
        bool CanHandle(Exception exception);
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
