namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Interface for a domain event bus.
/// </summary>
public interface IDomainEventBus
{
    /// <summary>
    /// Publishes a collection of domain events asynchronously.
    /// </summary>
    /// <typeparam name="TEvent">The type of the domain event.</typeparam>
    /// <param name="events">The collection of domain events to publish.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishAsync<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken)
        where TEvent : IDomainEvent;

    /// <summary>
    /// Publishes a collection of domain events asynchronously.
    /// </summary>
    /// <typeparam name="TEvent">The type of the domain event.</typeparam>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <param name="events">The collection of domain events to publish.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishAsync<TEvent>(
        CancellationToken cancellationToken = default,
        params TEvent[] events)
        where TEvent : IDomainEvent;
}
