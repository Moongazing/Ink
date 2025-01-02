using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moongazing.Ink.Persistence.Contexts;
using Npgsql;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Ink.Persistence;



public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        var retryPolicy = Policy
                         .Handle<NpgsqlException>()
                         .WaitAndRetry(
                         [
                            TimeSpan.FromSeconds(10),
                        TimeSpan.FromSeconds(20),
                        TimeSpan.FromSeconds(30),
                         ]);

        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Ink")));


        return services;
    }
}