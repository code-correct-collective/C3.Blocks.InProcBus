namespace C3.Blocks.InProcBus.Tests.Commands;

public class DomainProcessorBaseTests
{
    [Fact]
    public async Task ProcessAsyncMethodTest()
    {
        // Arrange
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var command = Substitute.ForPartsOf<DomainCommandBase>(expectedCorrelationId);
        var logger = Substitute.For<ILogger<DomainCommandProcessorBase<DomainCommandBase>>>();
        var processor = Substitute.For<DomainCommandProcessorBase<DomainCommandBase>>(logger);

        // Act
        await ((IRequestHandler<DomainCommandBase>)processor).Handle(command, default);

        // Assert
        await processor.Received(1).ProcessAsync(command, default);
        logger.Received(1).LogDebugProcessingCommand(command);
        Assert.Equal(expectedCorrelationId, command.CorrelationId);
    }
}
