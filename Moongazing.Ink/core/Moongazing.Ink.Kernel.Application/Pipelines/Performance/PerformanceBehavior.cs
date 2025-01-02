using MediatR;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog;
using System.Diagnostics;
using System.Text.Json;

namespace Moongazing.Ink.Kernel.Application.Pipelines.Performance;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IIntervalRequest
{
    private readonly Stopwatch stopwatch;
    private readonly LoggerServiceBase loggerServiceBase;

    public PerformanceBehavior(Stopwatch stopwatch, LoggerServiceBase loggerServiceBase)
    {
        this.stopwatch = stopwatch;
        this.loggerServiceBase = loggerServiceBase;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = request.GetType().Name;

        TResponse response;

        try
        {
            stopwatch.Start();
            response = await next();
        }
        finally
        {
            stopwatch.Stop();

            if (stopwatch.Elapsed.TotalSeconds > request.Interval)
            {
                string message = $"Performance -> {requestName} took {stopwatch.Elapsed.TotalSeconds} seconds";

                LogDetail logDetail = new()
                {
                    MethodName = next.Method.Name,
                    Parameters = new List<LogParameter>
                    {
                        new LogParameter
                        {
                            Type = request.GetType().Name,
                            Value = request
                        }
                    },
                    User = "PerformanceCheck"
                };

                loggerServiceBase.Info($"{message} | Details: {JsonSerializer.Serialize(logDetail)}");
            }

            stopwatch.Reset();
        }

        return response;
    }
}
