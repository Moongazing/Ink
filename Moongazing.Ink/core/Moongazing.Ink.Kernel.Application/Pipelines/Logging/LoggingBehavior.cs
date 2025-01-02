using MediatR;
using Microsoft.AspNetCore.Http;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog;
using System.Text.Json;

namespace Moongazing.Ink.Kernel.Application.Pipelines.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>, ILoggableRequest
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly LoggerServiceBase loggerServiceBase;

    public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerServiceBase)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.loggerServiceBase = loggerServiceBase;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters =
        [
            new LogParameter
            {
                Type = request.GetType().Name,
                Value = request
            }
        ];

        LogDetail logDetail = new()
        {
            MethodName = next.Method.Name,
            Parameters = logParameters,
            User = httpContextAccessor.HttpContext?.User.Identity?.Name ?? "?"
        };

        loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));
        return await next();
    }
}
