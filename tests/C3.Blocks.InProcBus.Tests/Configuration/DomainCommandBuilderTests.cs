using C3.Blocks.InProcBus.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Tests.Configuration;

public class DomainCommandBuilderTests
{
    [Fact]
    public void TestAddCommandMethod()
    {
        // Arrange
        var servicesMock = Substitute.For<IServiceCollection>();
        var commandBuilder = new DomainCommandBuilder(new InProcBusConfiguration(servicesMock));

        // Act
        commandBuilder.AddCommand<DomainCommandBase, DomainCommandProcessorBase<DomainCommandBase>>();

        // Assert
        servicesMock.Received(1).Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.Lifetime == ServiceLifetime.Scoped &&
            sd.ImplementationType == typeof(DomainCommandProcessorBase<DomainCommandBase>) &&
            sd.ServiceType == typeof(IRequestHandler<DomainCommandBase>)
        ));
    }
}
