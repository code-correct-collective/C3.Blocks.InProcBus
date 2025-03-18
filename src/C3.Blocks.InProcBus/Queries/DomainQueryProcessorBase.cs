namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Base class for processing domain queries.
/// </summary>
/// <typeparam name="TQuery">The type of the query.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
/// <param name="logger">The logger instance for the domain query processor.</param>
public abstract class DomainQueryProcessorBase<TQuery, TResponse>(ILogger<DomainQueryProcessorBase<TQuery, TResponse>> logger) : IDomainQueryProcessor<TQuery, TResponse>
    where TQuery : DomainQueryBase<TResponse>
{
    /// <summary>
    /// Gets the logger instance for the domain query processor.
    /// </summary>
    protected ILogger<DomainQueryProcessorBase<TQuery, TResponse>> Logger { get; } = logger;

#pragma warning disable CA1033 // Interface methods should be callable by child types
    async Task<TResponse> IRequestHandler<TQuery, TResponse>.Handle(TQuery request, CancellationToken cancellationToken)
#pragma warning restore CA1033 // Interface methods should be callable by child types
    {
        this.Logger.LogDebugProcessingQuery(request);
        return await this.ProcessQueryAsync(request, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Processes the query asynchronously.
    /// </summary>
    /// <param name="query">The query to process.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response.</returns>
    public abstract Task<TResponse> ProcessQueryAsync(TQuery query, CancellationToken cancellationToken);
}
