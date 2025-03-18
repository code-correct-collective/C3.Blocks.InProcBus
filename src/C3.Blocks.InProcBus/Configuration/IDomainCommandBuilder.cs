namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Provides methods to build domain commands for the in-process bus.
/// </summary>
public interface IDomainCommandBuilder
{
    /// <summary>
    /// Gets the configuration settings for the in-process bus.
    /// </summary>
    /// <value>
    /// The configuration settings for the in-process bus.
    /// </value>
    InProcBusConfiguration Configuration { get; }

    /// <summary>
    /// Adds a command and its handler to the in-process bus.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TCommandProcessor">The type of the command handler.</typeparam>
    /// <returns>The domain command builder.</returns>
    IDomainCommandBuilder AddCommand<TCommand, TCommandProcessor>()
        where TCommand : DomainCommandBase
        where TCommandProcessor : DomainCommandProcessorBase<TCommand>;

}
