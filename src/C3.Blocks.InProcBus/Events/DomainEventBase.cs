namespace C3.Blocks.InProcBus.Events;

/// <summary>
/// Represents the base class for domain events.
/// </summary>
/// <param name="CorrelationId">The correlation ID for the event.</param>
public abstract record DomainEventBase(string CorrelationId) : IDomainEvent
{
    /// <summary>
    /// Gets the event type, which includes the full name of the type and the assembly name.
    /// </summary>
    public string EventType => $"{this.GetType().FullName}, {this.GetType().Assembly.GetName().Name}";
}
