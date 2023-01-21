using System.Diagnostics.CodeAnalysis;

namespace Repository.MariaDb;

[ExcludeFromCodeCoverage]
public record MariaDbSettings
{
    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; init; } = string.Empty;
}