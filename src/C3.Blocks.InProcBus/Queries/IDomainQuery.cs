namespace C3.Blocks.InProcBus.Queries;

/// <summary>
/// Represents a domain query.
/// </summary>
#pragma warning disable CA1040 // Avoid empty interfaces
public interface IDomainQuery
#pragma warning restore CA1040 // Avoid empty interfaces
{
}

/// <summary>
/// Represents a domain query that returns a response of type TResponse.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IDomainQuery<out TResponse> : IRequest<TResponse>, IDomainQuery
{
    /// <summary>
    /// Gets the correlation ID for the query.
    /// </summary>
    string CorrelationId { get; }
}
