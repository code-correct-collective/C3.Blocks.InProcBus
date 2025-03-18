using C3.Blocks.InProcBus.Events;

namespace C3.Blocks.InProcBus.Tests.Events;

public class DomainEvenProcessingBaseTests
{
    [Fact]
    public async Task ProcessEventAsyncTest()
    {
        // Arrange
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var eventMock = Substitute.ForPartsOf<DomainEventBase>(expectedCorrelationId);
        var logger = Substitute.For<ILogger<DomainEventProcessorBase<DomainEventBase>>>();
        var processor = Substitute.ForPartsOf<DomainEventProcessorBase<DomainEventBase>>(logger);

        // Act
        await ((INotificationHandler<DomainEventBase>)processor).Handle(eventMock, default);

        // Assert
        Assert.Equal(expectedCorrelationId, eventMock.CorrelationId);
        logger.Received(1).LogDebugProcessingEvent(eventMock);
        await processor.Received().ProcessEventAsync(eventMock, default);
    }
}
