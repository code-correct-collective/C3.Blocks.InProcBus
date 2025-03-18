using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Initializes a new instance of the <see cref="DomainCommandBuilder"/> class.
/// </summary>
/// <param name="Configuration">The configuration for the in-process bus.</param>
public sealed record class DomainCommandBuilder(InProcBusConfiguration Configuration) : IDomainCommandBuilder
{
    /// <summary>
    /// Adds a command and its processor to the in-process bus configuration.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TCommandProcessor">The type of the command processor.</typeparam>
    /// <returns>The domain command builder.</returns>
    public IDomainCommandBuilder AddCommand<TCommand, TCommandProcessor>()
        where TCommand : DomainCommandBase
        where TCommandProcessor : DomainCommandProcessorBase<TCommand>
    {
        this.Configuration.Services.AddScoped<IRequestHandler<TCommand>, TCommandProcessor>();
        return this;
    }
}
