using C3.Blocks.InProcBus.Events;

namespace C3.Blocks.InProcBus.Tests.Events;

public class BasicDomainEventTests
{
    [Fact]
    public void TestDomainProperties()
    {
        // Arrange
        var expectedType = "Castle.Proxies.DomainEventBaseProxy, DynamicProxyGenAssembly2";
        var expectedCorrelationId = Guid.NewGuid().ToString();
        // Act
        var eventMock = Substitute.ForPartsOf<DomainEventBase>(expectedCorrelationId);

        // Assert
        Assert.Equal(expectedCorrelationId, eventMock.CorrelationId);
        Assert.Equal(expectedType, eventMock.EventType);
    }

}
