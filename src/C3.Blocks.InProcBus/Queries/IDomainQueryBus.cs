namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Represents a bus for executing domain queries.
/// </summary>
public interface IDomainQueryBus
{
    /// <summary>
    /// Executes the specified domain query asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The domain query to execute.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response.</returns>
    Task<TResponse> ExecuteAsync<TResponse>(IDomainQuery<TResponse> query, CancellationToken cancellationToken);
}
