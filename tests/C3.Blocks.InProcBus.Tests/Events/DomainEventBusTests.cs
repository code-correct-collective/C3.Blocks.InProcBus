using C3.Blocks.InProcBus.Events;

namespace C3.Blocks.InProcBus.Tests.Events;

public class DomainEventBusTests
{
    [Fact]
    public async Task PublishMethodTests()
    {
        // Arrange
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var mediatorMock = Substitute.For<IMediator>();
        var loggerMock = Substitute.For<ILogger<DomainEventBus>>();
        var eventsMock = new List<DomainEventBase>()
        {
            Substitute.ForPartsOf<DomainEventBase>(expectedCorrelationId)
        }.AsEnumerable();

        // Act
        var eventBus = new DomainEventBus(mediatorMock, loggerMock);
        await eventBus.PublishAsync(eventsMock, default);

        // Assert
        loggerMock.Received().LogDebugPublishingCountEvent(1);
        loggerMock.Received().LogDebugPublishingEvent(eventsMock.First());
        await mediatorMock.Received(1).Publish(eventsMock.First(), default);
    }

    [Fact]
    public async Task PublishMethodTestsNullArgument()
    {
        // Arrange
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var mediatorMock = Substitute.For<IMediator>();
        var loggerMock = Substitute.For<ILogger<DomainEventBus>>();

        // Act
        var eventBus = new DomainEventBus(mediatorMock, loggerMock);
        await Assert.ThrowsAsync<ArgumentNullException>(() => eventBus.PublishAsync<DomainEventBase>(null!, default));
    }
}
