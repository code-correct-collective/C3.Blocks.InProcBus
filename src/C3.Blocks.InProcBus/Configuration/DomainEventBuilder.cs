using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Represents a builder for domain events with the specified configuration.
/// </summary>
/// <param name="Configuration">The configuration for the in-process bus.</param>
public sealed record class DomainEventBuilder(InProcBusConfiguration Configuration) : IDomainEventBuilder
{
    /// <summary>
    /// Adds an event and its processor to the domain event builder.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TEventProcessor">The type of the event processor.</typeparam>
    /// <returns>The domain event builder.</returns>
    public IDomainEventBuilder AddEvent<TEvent, TEventProcessor>()
        where TEvent : DomainEventBase
        where TEventProcessor : DomainEventProcessorBase<TEvent>
    {
        this.Configuration.Services.AddScoped<INotificationHandler<TEvent>, TEventProcessor>();
        return this;
    }
}
