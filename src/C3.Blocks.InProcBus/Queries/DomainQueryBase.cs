namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Base class for domain queries.
/// </summary>
/// <param name="CorrelationId">The correlation ID.</param>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public abstract record class DomainQueryBase<TResponse>(string CorrelationId) : IDomainQuery<TResponse>
{
}
