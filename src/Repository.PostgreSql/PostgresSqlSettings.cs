using System.Diagnostics.CodeAnalysis;

namespace Repository.PostgreSql;

[ExcludeFromCodeCoverage]
public class PostgresSqlSettings
{
    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}

