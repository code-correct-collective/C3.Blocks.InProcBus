namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Represents a domain event bus that publishes domain events.
/// </summary>
/// <param name="mediator">The mediator instance.</param>
/// <param name="logger">The logger instance.</param>
public class DomainEventBus(IMediator mediator, ILogger<DomainEventBus> logger) : IDomainEventBus
{
    /// <summary>
    /// Gets the mediator instance.
    /// </summary>
    protected IMediator Mediator => mediator;

    /// <summary>
    /// Gets the logger instance.
    /// </summary>
    protected ILogger<DomainEventBus> Logger => logger;

    /// <inheritdoc/>
    public async Task PublishAsync<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken)
        where TEvent : IDomainEvent
    {
        await this.PublishAsync(cancellationToken, events.ToArray()).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException" />
    public async Task PublishAsync<TEvent>(CancellationToken cancellationToken, params TEvent[] events)
        where TEvent : IDomainEvent
    {
        ArgumentNullException.ThrowIfNull(events, nameof(events));
        if (events.Length == 0)
        {
            throw new ArgumentException("Must publish at least one event");
        }

        this.Logger.LogDebugPublishingCountEvent(events.Length);
        var tasks = new List<Task>();
        foreach (var @event in events)
        {
            this.Logger.LogDebugPublishingEvent(@event);
            tasks.Add(this.Mediator.Publish(@event, cancellationToken));
        }

        await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
    }
}
