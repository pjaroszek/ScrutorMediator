namespace Jaroszek.CoderHouse.ScrutorMediator.Abstractions;

/// <summary>
/// Marker interface for queries (request with result)
/// </summary>
/// <typeparam name="TResult">Type of the query result</typeparam>
public interface IQuery<out TResult>
{
}