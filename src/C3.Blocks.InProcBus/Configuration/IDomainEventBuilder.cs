namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Interface for building domain events.
/// </summary>
public interface IDomainEventBuilder
{
    /// <summary>
    /// Gets the InProcBus configuration.
    /// </summary>
    InProcBusConfiguration Configuration { get; }

    /// <summary>
    /// Adds an event and its processor to the domain event builder.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TEventProcessor">The type of the event processor.</typeparam>
    /// <returns>The domain event builder.</returns>
    IDomainEventBuilder AddEvent<TEvent, TEventProcessor>()
        where TEvent : DomainEventBase
        where TEventProcessor : DomainEventProcessorBase<TEvent>;
}
