using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.MariaDb;

[ExcludeFromCodeCoverage]
public record MariaDbSettings
{
    /// <summary>
    /// Connection string
    /// </summary>
    public string ConnectionString { get; init; } = string.Empty;
}