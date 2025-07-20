using AppointmentSystem.Common.Behaviors;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AppointmentSystem.Application.Behaviors
{

    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Handling {RequestName} with content: {@Request}", requestName, request);

            var stopwatch = Stopwatch.StartNew();
            try
            {
                var response = await next();
                stopwatch.Stop();
                _logger.LogInformation("Handled {RequestName} in {ElapsedMilliseconds} ms with response: {@Response}",
                    requestName, stopwatch.ElapsedMilliseconds, response);
                return response;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Error handling {RequestName} after {ElapsedMilliseconds} ms",
                    requestName, stopwatch.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
