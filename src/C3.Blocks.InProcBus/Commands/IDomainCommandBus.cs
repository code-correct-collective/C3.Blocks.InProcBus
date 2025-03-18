namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Represents a bus for domain commands.
/// </summary>
public interface IDomainCommandBus
{
    /// <summary>
    /// Executes the specified domain command asynchronously.
    /// </summary>
    /// <typeparam name="TCommand">The type of the domain command.</typeparam>
    /// <param name="command">The domain command to execute.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : IDomainCommand;
}
