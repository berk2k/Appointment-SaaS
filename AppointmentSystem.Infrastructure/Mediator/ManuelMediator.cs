using AppointmentSystem.Common.Behaviors;
using AppointmentSystem.Common.Interfaces.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Infrastructure.Mediator
{
    public class ManualMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public ManualMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var requestType = request.GetType();
            var responseType = typeof(TResponse);

            
            return await ExecuteWithBehaviors<TResponse>(request, requestType, responseType, cancellationToken);
        }

        private async Task<TResponse> ExecuteWithBehaviors<TResponse>(
            IRequest<TResponse> request,
            Type requestType,
            Type responseType,
            CancellationToken cancellationToken)
        {
            
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new InvalidOperationException($"Handler not found for request type {requestType.Name}");
            }

            
            var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType, responseType);
            var behaviors = _serviceProvider.GetServices(behaviorType);

            
            RequestHandlerDelegate<TResponse> handlerDelegate = async () =>
            {
                var method = handlerType.GetMethod("Handle");
                if (method == null)
                {
                    throw new InvalidOperationException($"Handle method not found on {handlerType.Name}");
                }

                var result = method.Invoke(handler, new object[] { request, cancellationToken });

                if (result is Task<TResponse> taskResult)
                {
                    return await taskResult;
                }

                throw new InvalidOperationException($"Handler method did not return Task<{responseType.Name}>");
            };

            
            foreach (var behavior in behaviors.Reverse())
            {
                var currentDelegate = handlerDelegate;
                var typedBehavior = behavior; 

                handlerDelegate = async () =>
                {
                    
                    var behaviorHandleMethod = behavior.GetType().GetMethod("Handle");
                    if (behaviorHandleMethod == null)
                    {
                        throw new InvalidOperationException($"Handle method not found on behavior {behavior.GetType().Name}");
                    }

                    var result = behaviorHandleMethod.Invoke(behavior, new object[] { request, currentDelegate, cancellationToken });

                    if (result is Task<TResponse> taskResult)
                    {
                        return await taskResult;
                    }

                    throw new InvalidOperationException("Behavior Handle method did not return expected type");
                };
            }

            return await handlerDelegate();
        }
    }
}
