namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Initializes a new instance of the <see cref="DomainCommandBus"/> class.
/// </summary>
/// <param name="mediator">The mediator to send commands.</param>
/// <param name="logger">The logger to log command execution.</param>
public class DomainCommandBus(IMediator mediator, ILogger<DomainCommandBase> logger) : IDomainCommandBus
{
    private IMediator Mediator { get; } = mediator;

    private ILogger Logger { get; } = logger;

    /// <inheritdoc/>
    public async Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : IDomainCommand
    {
        this.Logger.LogDebugExecutingCommand(command);
        await this.Mediator.Send(command, cancellationToken).ConfigureAwait(false);
    }
}
