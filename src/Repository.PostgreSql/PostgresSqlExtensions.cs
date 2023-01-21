using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Npgsql;

namespace Repository.PostgreSql;

[ExcludeFromCodeCoverage]
public static class PostgresSqlExtensions
{
    /// <summary>
    /// Adds sql server to service collection
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configuration">The configuration</param>
    /// <returns>The service collection with sql server configured</returns>
    public static IServiceCollection AddPgSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresSqlSettings>(configuration.GetSection("PgSql"));
        var settings = configuration.GetRequiredSection("PgSql")
            .Get<PostgresSqlSettings>()!;
        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(settings.ConnectionString));
        return services;
    }
}
