
using Microsoft.Extensions.Logging;

namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Handles domain commands of type <typeparamref name="TCommand"/>.
/// </summary>
/// <typeparam name="TCommand">The type of the domain command.</typeparam>
/// <param name="logger">The logger instance.</param>
public abstract class DomainCommandProcessorBase<TCommand>(ILogger logger) : IDomainCommandProcessor<TCommand>
    where TCommand : DomainCommandBase
{
    /// <summary>
    /// Gets the logger instance.
    /// </summary>
    protected ILogger Logger { get; private set; } = logger;

    /// <inheritdoc/>
#pragma warning disable CA1033 // Interface methods should be callable by child types
    async Task IRequestHandler<TCommand>.Handle(TCommand request, CancellationToken cancellationToken)
#pragma warning restore CA1033 // Interface methods should be callable by child types
    {
        this.Logger.LogDebugProcessingCommand(request);
        await this.ProcessAsync(request, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Handles the specified domain command.
    /// </summary>
    /// <param name="command">The domain command to handle.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public abstract Task ProcessAsync(TCommand command, CancellationToken cancellationToken);
}
