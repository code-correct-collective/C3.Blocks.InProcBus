namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Represents a domain command with a correlation ID.
/// </summary>
public interface IDomainCommand : IRequest
{
    /// <summary>
    /// Gets the correlation ID.
    /// </summary>
    string CorrelationId { get; }
}
