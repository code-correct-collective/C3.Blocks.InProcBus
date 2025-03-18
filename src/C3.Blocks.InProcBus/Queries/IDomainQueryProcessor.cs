namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Handles domain queries of type <typeparamref name="TQuery"/> and returns a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IDomainQueryProcessor<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IDomainQuery<TResponse>
{
    /// <summary>
    /// Processes the query asynchronously.
    /// </summary>
    /// <param name="query">The query to process.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response.</returns>
    Task<TResponse> ProcessQueryAsync(TQuery query, CancellationToken cancellationToken);
}
