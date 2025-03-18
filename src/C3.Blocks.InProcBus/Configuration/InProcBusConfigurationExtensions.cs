using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Provides extension methods for configuring the InProcBus.
/// </summary>
public static class InProcBusConfigurationExtensions
{
    /// <summary>
    /// Adds the InProcBus configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the configuration to.</param>
    /// <returns>The InProcBus configuration.</returns>
    public static InProcBusConfiguration AddInProcBus(this IServiceCollection services)
    {
        var configuration = new InProcBusConfiguration(services);
        configuration.Services.AddScoped<IMediator, Mediator>();

        // configuration.Services.AddTransient<IServiceProvider>(sp => sp.GetService);

        return configuration;
    }

    /// <summary>
    /// Adds command handling to the InProcBus configuration.
    /// </summary>
    /// <param name="configuration">The InProcBus configuration to add command handling to.</param>
    /// <returns>A DomainCommandBuilder for configuring domain commands.</returns>
    public static IDomainCommandBuilder AddCommands([NotNull] this InProcBusConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        configuration.Services.AddScoped<IDomainCommandBus, DomainCommandBus>();

        return new DomainCommandBuilder(configuration);
    }

    /// <summary>
    /// Returns the InProcBus configuration from the DomainCommandBuilder.
    /// </summary>
    /// <param name="commandBuilder">The DomainCommandBuilder instance.</param>
    /// <returns>The InProcBus configuration.</returns>
    public static InProcBusConfiguration And([NotNull] this IDomainCommandBuilder commandBuilder)
    {
        ArgumentNullException.ThrowIfNull(commandBuilder, nameof(commandBuilder));
        return commandBuilder.Configuration;
    }

    /// <summary>
    /// Adds event handling to the InProcBus configuration.
    /// </summary>
    /// <param name="configuration">The InProcBus configuration to add event handling to.</param>
    /// <returns>A DomainEventBuilder for configuring domain events.</returns>
    public static IDomainEventBuilder AddEvents([NotNull] this InProcBusConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        configuration.Services.AddScoped<IDomainEventBus, DomainEventBus>();

        return new DomainEventBuilder(configuration);
    }

    /// <summary>
    /// Returns the InProcBus configuration from the DomainEventBuilder.
    /// </summary>
    /// <param name="eventBuilder">The DomainEventBuilder instance.</param>
    /// <returns>The InProcBus configuration.</returns>
    public static InProcBusConfiguration And([NotNull] this IDomainEventBuilder eventBuilder)
    {
        ArgumentNullException.ThrowIfNull(eventBuilder, nameof(eventBuilder));
        return eventBuilder.Configuration;
    }

    /// <summary>
    /// Adds query handling to the InProcBus configuration.
    /// </summary>
    /// <param name="configuration">The InProcBus configuration to add query handling to.</param>
    /// <returns>A DomainQueryBuilder for configuring domain queries.</returns>
    public static IDomainQueryBuilder AddQueries([NotNull] this InProcBusConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        configuration.Services.AddScoped<IDomainQueryBus, DomainQueryBus>();

        return new DomainQueryBuilder(configuration);
    }

    /// <summary>
    /// Returns the InProcBus configuration from the DomainQueryBuilder.
    /// </summary>
    /// <param name="queryBuilder">The DomainQueryBuilder instance.</param>
    /// <returns>The InProcBus configuration.</returns>
    public static InProcBusConfiguration And([NotNull] this IDomainQueryBuilder queryBuilder)
    {
        ArgumentNullException.ThrowIfNull(queryBuilder, nameof(queryBuilder));
        return queryBuilder.Configuration;
    }
}
