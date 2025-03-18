using C3.Blocks.InProcBus.Configuration;
using C3.Blocks.InProcBus.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace C3.Blocks.InProcBus.Tests.Configuration;

public class DomainQueryBuilderTests
{
    [Fact]
    public void TestAddQueriesMethod()
    {
        // Arrange
        var servicesMock = Substitute.For<IServiceCollection>();
        var builder = new DomainQueryBuilder(new InProcBusConfiguration(servicesMock));

        // Act
        builder.AddQuery<DomainQueryBase<int>, int, DomainQueryProcessorBase<DomainQueryBase<int>, int>>();

        // Assert
        servicesMock.Received(1).Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.Lifetime == ServiceLifetime.Scoped &&
            sd.ImplementationType == typeof(DomainQueryProcessorBase<DomainQueryBase<int>, int>) &&
            sd.ServiceType == typeof(IRequestHandler<DomainQueryBase<int>, int>)
        ));
    }
}
