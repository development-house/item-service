using System.ComponentModel;
using MySqlConnector;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;

namespace Repository.MariaDb;
/// <summary>
/// SQL retry policies
/// </summary>
public static class Retry
{
    private static readonly IEnumerable<TimeSpan> s_delay =
        Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5);

    /// <summary>
    /// Retries transient SQL errors
    /// </summary>
    public static readonly AsyncRetryPolicy DefaultPolicy = Policy
                                                            .Handle<MySqlException>(MariabDbTransientExceptionDetector.ShouldRetryOn)
                                                            .Or<TimeoutException>()
                                                            .OrInner<Win32Exception>(MariabDbTransientExceptionDetector.ShouldRetryOn)
                                                            .WaitAndRetryAsync(s_delay);
}