namespace C3.Blocks.InProcBus.Tests.Commands;

public class DomainCommandBusTest
{
    [Fact]
    public async Task ExecuteAsyncMethodTest()
    {
        // Arrange
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var command = Substitute.ForPartsOf<DomainCommandBase>(expectedCorrelationId);
        var loggerMock = Substitute.For<ILogger<DomainCommandBase>>();
        var mediatorMock = Substitute.For<IMediator>();

        // Act
        var bus = new DomainCommandBus(mediatorMock, loggerMock);
        await bus.ExecuteAsync(command, default);

        // Assert
        Assert.Equal(expectedCorrelationId, command.CorrelationId);
        loggerMock.Received(1).LogDebugExecutingCommand(command);
        await mediatorMock.Received(1).Send(command, default);
    }
}
