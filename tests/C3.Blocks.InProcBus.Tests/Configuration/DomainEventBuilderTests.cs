using C3.Blocks.InProcBus.Configuration;
using C3.Blocks.InProcBus.Events;
using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Tests.Configuration;

public class DomainEventBuilderTests
{
    [Fact]
    public void AddEventTests()
    {
        // Arrange
        var servicesMock = Substitute.For<IServiceCollection>();
        var eventBuilder = new DomainEventBuilder(new InProcBusConfiguration(servicesMock));

        // Act
        eventBuilder.AddEvent<DomainEventBase, DomainEventProcessorBase<DomainEventBase>>();

        // Assert
        servicesMock.Received(1).Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.Lifetime == ServiceLifetime.Scoped &&
            sd.ImplementationType == typeof(DomainEventProcessorBase<DomainEventBase>) &&
            sd.ServiceType == typeof(INotificationHandler<DomainEventBase>)
        ));
    }
}
