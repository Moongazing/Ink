using Microsoft.Extensions.Configuration;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog.Messages;
using Serilog;

namespace Moongazing.Ink.Kernel.CrossCuttingConcerns.Logging.Serilog.Logger;

public class FileLogger : LoggerServiceBase
{
    private readonly IConfiguration configuration;

    public FileLogger(IConfiguration configuration)
    {
        this.configuration = configuration;

        FileLogConfiguration logConfig =
            configuration.GetSection("SeriLogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = string.Format(format: "{0}{1}", arg0: Directory.GetCurrentDirectory() + "." + logConfig.FolderPath, arg1: ".txt");

        Logger = new LoggerConfiguration().WriteTo.File(
            logFilePath, rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: null,
            fileSizeLimitBytes: 5000000,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            ).CreateLogger();
    }
}
