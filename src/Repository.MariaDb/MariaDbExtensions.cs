using System.Data;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Diagnostics.CodeAnalysis;

namespace Repository.MariaDb;

[ExcludeFromCodeCoverage]
public static class MariaDbExtensions
{
    /// <summary>
    /// Adds sql server to service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">The configuration</param>
    /// <returns>The service collection with sql server configured</returns>
    public static IServiceCollection AddMariaDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MariaDbSettings>(configuration.GetSection("MariaDb"));
        var settings = configuration.GetRequiredSection("MariaDb").Get<MariaDbSettings>()!;
        services.AddScoped<IDbConnection>(_ => new MySqlConnection(settings.ConnectionString));
        return services;
    }
}
