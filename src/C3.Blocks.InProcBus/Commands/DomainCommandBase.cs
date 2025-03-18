namespace C3.Blocks.InProcBus.Commands;

/// <summary>
/// Represents the base class for domain commands.
/// </summary>
/// <param name="CorrelationId">The correlation ID.</param>
public abstract record class DomainCommandBase(string CorrelationId) : IDomainCommand
{
}
