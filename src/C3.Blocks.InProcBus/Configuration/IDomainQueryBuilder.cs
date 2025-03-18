namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Interface for building domain queries.
/// </summary>
public interface IDomainQueryBuilder
{
    /// <summary>
    /// Gets the InProcBus configuration.
    /// </summary>
    public InProcBusConfiguration Configuration { get; }

    /// <summary>
    /// Adds a query to the domain query builder.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TQueryProcessor">The type of the query processor.</typeparam>
    /// <returns>An instance of <see cref="IDomainQueryBuilder"/>.</returns>
    IDomainQueryBuilder AddQuery<TQuery, TResponse, TQueryProcessor>()
        where TQuery : DomainQueryBase<TResponse>
        where TQueryProcessor : DomainQueryProcessorBase<TQuery, TResponse>;
}
