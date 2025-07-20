namespace AppointmentSystem.Common.Behaviors
{
    public interface IPipelineBehavior<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
    }

    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();
}
