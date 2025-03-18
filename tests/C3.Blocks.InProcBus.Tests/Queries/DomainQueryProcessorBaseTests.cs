using C3.Blocks.InProcBus.Queries;

namespace C3.Blocks.InProcBus.Tests.Queries;

public class DomainQueryProcessorBaseTests
{
    [Fact]
    public async Task TestProcessQueryAsyncMethod()
    {
        // Arrange
        var expectedResponse = 6;
        var expectedCorrelationId = Guid.NewGuid().ToString();
        var queryMock = Substitute.ForPartsOf<DomainQueryBase<int>>(expectedCorrelationId);
        var logger = Substitute.For<ILogger<DomainQueryProcessorBase<DomainQueryBase<int>, int>>>();
        var processor = Substitute.ForPartsOf<DomainQueryProcessorBase<DomainQueryBase<int>, int>>(logger);
        processor.ProcessQueryAsync(queryMock, default).Returns(expectedResponse);

        // Act
        var response = await ((IRequestHandler<DomainQueryBase<int>, int>)processor).Handle(queryMock, default);

        // Assert
        Assert.Equal(expectedResponse, response);
        Assert.Equal(expectedCorrelationId, queryMock.CorrelationId);
        logger.Received(1).LogDebugProcessingQuery(queryMock);
        await processor.Received(1).ProcessQueryAsync(queryMock, default);
    }

}
