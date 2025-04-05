namespace Jaroszek.CoderHouse.ScrutorMediator.Abstractions;

/// <summary>
/// Handler for processing queries
/// </summary>
/// <typeparam name="TQuery">Query type</typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    /// <summary>
    /// Handles the specified query
    /// </summary>
    /// <param name="query">Query to handle</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result of the query</returns>
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}