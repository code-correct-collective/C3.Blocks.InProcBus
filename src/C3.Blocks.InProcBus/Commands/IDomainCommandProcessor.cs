namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Interface for handling domain commands.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
public interface IDomainCommandProcessor<in TCommand> : IRequestHandler<TCommand>
    where TCommand : IDomainCommand
{
    /// <summary>
    /// Processes the specified domain command asynchronously.
    /// </summary>
    /// <param name="command">The domain command to process.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ProcessAsync(TCommand command, CancellationToken cancellationToken);
}
