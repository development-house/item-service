using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.PostgreSql;

[ExcludeFromCodeCoverage]
public class PostgresSqlSettings
{
    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}

