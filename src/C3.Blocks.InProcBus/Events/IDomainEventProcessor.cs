namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Interface for processing domain events.
/// </summary>
/// <typeparam name="TEvent">The type of domain event.</typeparam>
public interface IDomainEventProcessor<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
    /// <summary>
    /// Processes the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event to process.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ProcessEventAsync(TEvent domainEvent, CancellationToken cancellationToken);
}
