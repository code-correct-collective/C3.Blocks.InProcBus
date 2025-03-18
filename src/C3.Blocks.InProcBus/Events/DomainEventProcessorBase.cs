namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Base class for processing domain events.
/// </summary>
/// <typeparam name="TEvent">The type of the domain event.</typeparam>
/// <param name="logger">The logger instance for the domain event processor.</param>
public abstract class DomainEventProcessorBase<TEvent>(ILogger<DomainEventProcessorBase<TEvent>> logger) : IDomainEventProcessor<TEvent>
    where TEvent : DomainEventBase
{
    /// <summary>
    /// Gets the logger instance for the domain event processor.
    /// </summary>
    protected ILogger<DomainEventProcessorBase<TEvent>> Logger { get; } = logger;

#pragma warning disable CA1033 // Interface methods should be callable by child types
    async Task INotificationHandler<TEvent>.Handle(TEvent notification, CancellationToken cancellationToken)
#pragma warning restore CA1033 // Interface methods should be callable by child types
    {
        this.Logger.LogDebugProcessingEvent(notification);
        await this.ProcessEventAsync(notification, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public abstract Task ProcessEventAsync(TEvent domainEvent, CancellationToken cancellationToken);
}
