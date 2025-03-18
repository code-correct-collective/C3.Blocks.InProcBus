namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Represents a domain event.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the type of the event.
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// Gets the correlation ID of the event.
    /// </summary>
    string CorrelationId { get; }
}
