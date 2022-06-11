using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
         : IPipelineBehavior<TRequest, TResponse> where TRequest
         : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("Request: {Name} {@Request}",
                requestName, request);

            var response = await next();

            return response;
        }
    }
}
