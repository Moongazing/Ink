using Microsoft.Extensions.Configuration;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Serilog;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog.Logger.GrayLog;

public class GraylogLogger : LoggerServiceBase
{
    public GraylogLogger(IConfiguration configuration)
    {
        const string configurationSection = "SeriLogConfigurations:GraylogConfiguration";
        GraylogConfiguration logConfiguration =
            configuration.GetSection(configurationSection).Get<GraylogConfiguration>()
            ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");

        Logger = new LoggerConfiguration()
            .WriteTo.Graylog(
                new GraylogSinkOptions
                {
                    HostnameOrAddress = logConfiguration.HostnameOrAddress,
                    Port = logConfiguration.Port,
                    TransportType = TransportType.Udp
                }
            )
            .CreateLogger();
    }
}