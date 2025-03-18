using C3.Blocks.InProcBus.Queries;

namespace C3.Blocks.InProcBus.Tests.Queries;

public class DomainQueryBusTests
{
    [Fact]
    public async Task ExecuteAsyncMethod()
    {
        // Arrange
        var expectedResponse = 4;
        var expectedCorrelationsId = Guid.NewGuid().ToString();
        var domainQueryMock = Substitute.ForPartsOf<DomainQueryBase<int>>(expectedCorrelationsId);
        var mediatorMock = Substitute.For<IMediator>();
        mediatorMock.Send(domainQueryMock, default).Returns(expectedResponse);
        var loggerMock = Substitute.For<ILogger<DomainQueryBus>>();


        // Act
        var bus = new DomainQueryBus(mediatorMock, loggerMock);
        var response = await bus.ExecuteAsync(domainQueryMock, default);

        // Assert
        Assert.Equal(expectedResponse, response);
        Assert.Equal(expectedCorrelationsId, domainQueryMock.CorrelationId);
        await mediatorMock.Received(1).Send(domainQueryMock, default);
    }

}
