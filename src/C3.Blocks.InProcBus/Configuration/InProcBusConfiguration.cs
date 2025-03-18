using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Configuration;

/// <summary>
/// Configuration for InProcBus.
/// </summary>
/// <param name="Services">The service collection.</param>
public record class InProcBusConfiguration(IServiceCollection Services)
{
}
