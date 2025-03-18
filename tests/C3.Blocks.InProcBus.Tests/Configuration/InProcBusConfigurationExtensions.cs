using C3.Blocks.InProcBus.Configuration;
using C3.Blocks.InProcBus.Events;
using C3.Blocks.InProcBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace C3.Blocks.InProcBus.Tests.Configuration;

public class InProcBusConfigurationExtensions
{
    [Fact]
    public void AddCommandsMethodTest()
    {
        RunTestBuild<DomainCommandBuilder, IDomainCommandBus, DomainCommandBus>(services =>
        {
            var builder = services.AddInProcBus().AddCommands();
            var config = builder.And();
            return (builder, config);
        });
    }

    [Fact]
    public void AddEventsMethodTest()
    {
        RunTestBuild<DomainEventBuilder, IDomainEventBus, DomainEventBus>(services =>
        {
            var builder = services.AddInProcBus().AddEvents();
            var config = builder.And();

            return (builder, config);
        });
    }

    [Fact]
    public void AddQueriesMethodTest()
    {
        RunTestBuild<DomainQueryBuilder, IDomainQueryBus, DomainQueryBus>(services =>
        {
            var builder = services.AddInProcBus().AddQueries();
            var config = builder.And();

            return (builder, config);
        });
    }


    static void RunTestBuild<TBuilder, TBusInterface, TBus>(Func<IServiceCollection, (object, InProcBusConfiguration)> runner)
    {
        // Arrange
        var servicesMock = Substitute.For<IServiceCollection>();

        // Act
        var (builder, config) = runner(servicesMock);

        // Assert
        Assert.IsAssignableFrom<TBuilder>(builder);
        Assert.IsAssignableFrom<InProcBusConfiguration>(config);

        servicesMock.Received(1).Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.Lifetime == ServiceLifetime.Scoped &&
            sd.ServiceType == typeof(IMediator) &&
            sd.ImplementationType == typeof(Mediator)
        ));

        servicesMock.Received(1).Add(Arg.Is<ServiceDescriptor>(sd =>
            sd.Lifetime == ServiceLifetime.Scoped &&
            sd.ServiceType == typeof(TBusInterface) &&
            sd.ImplementationType == typeof(TBus)
        ));
    }
}
