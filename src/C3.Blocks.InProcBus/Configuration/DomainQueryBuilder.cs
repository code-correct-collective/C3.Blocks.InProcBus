using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Initializes a new instance of the <see cref="DomainQueryBuilder"/> class with the specified configuration.
/// </summary>
/// <param name="Configuration">The configuration for the in-process bus.</param>
public sealed record class DomainQueryBuilder(InProcBusConfiguration Configuration) : IDomainQueryBuilder
{
    /// <summary>
    /// Adds a query to the domain query builder.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TQueryProcessor">The type of the query processor.</typeparam>
    /// <returns>An instance of <see cref="IDomainQueryBuilder"/>.</returns>
    public IDomainQueryBuilder AddQuery<TQuery, TResponse, TQueryProcessor>()
        where TQuery : DomainQueryBase<TResponse>
        where TQueryProcessor : DomainQueryProcessorBase<TQuery, TResponse>
    {
        this.Configuration.Services.AddScoped<IRequestHandler<TQuery, TResponse>, TQueryProcessor>();
        return this;
    }
}
