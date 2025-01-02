using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moongazing.Ink.Infrastructure.Aws.Configurations;
using Moongazing.Ink.Infrastructure.Aws.Services;

namespace Moongazing.Ink.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AwsS3Settings>(configuration.GetSection("AWS").Bind);
        services.AddSingleton(sp => sp.GetService<IOptions<AwsS3Settings>>()!.Value);

        services.AddSingleton<IAmazonS3>(sp =>
        {
            var awsConfig = sp.GetService<AwsS3Settings>();
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(awsConfig!.Region),
                ServiceURL = awsConfig.ServiceURL,
                ForcePathStyle = true
            };
            return new AmazonS3Client(awsConfig.AccessKey, awsConfig.SecretKey, config);
        });

        services.AddSingleton(sp =>
        {
            var s3Client = sp.GetService<IAmazonS3>();
            return new TransferUtility(s3Client);
        });

        services.AddSingleton<IStorageService, StorageService>();

        return services;
    }
}
