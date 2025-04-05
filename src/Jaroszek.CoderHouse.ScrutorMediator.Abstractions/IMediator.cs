namespace Jaroszek.CoderHouse.ScrutorMediator.Abstractions;

/// <summary>
/// Mediator pattern interface for sending commands and queries
/// </summary>
public interface IMediator
{
    /// <summary>
    /// Sends a command to its handler
    /// </summary>
    /// <param name="command">Command to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task SendAsync(ICommand command, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Sends a query to its handler
    /// </summary>
    /// <typeparam name="TResult">Type of the query result</typeparam>
    /// <param name="query">Query to send</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result of the query</returns>
    Task<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}