namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Represents a bus for executing domain queries.
/// </summary>
/// <param name="mediator">The mediator instance used to handle queries.</param>
/// <param name="logger">The logger instance used for logging information.</param>
public class DomainQueryBus(IMediator mediator, ILogger<DomainQueryBus> logger) : IDomainQueryBus
{
    /// <summary>
    /// Gets the mediator instance.
    /// </summary>
    protected IMediator Mediator { get; } = mediator;

    /// <summary>
    /// Gets the logger instance.
    /// </summary>
    protected ILogger<DomainQueryBus> Logger { get; } = logger;

    /// <inheritdoc/>
    public async Task<TResponse> ExecuteAsync<TResponse>(IDomainQuery<TResponse> query, CancellationToken cancellationToken)
    {
        this.Logger.LogDebugExecutingQuery(query);

        return await this.Mediator.Send(query, cancellationToken).ConfigureAwait(false);
    }
}
