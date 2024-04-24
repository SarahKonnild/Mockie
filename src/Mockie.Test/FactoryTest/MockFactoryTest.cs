using Xunit;
using Mockie.Factories;
using Mockie.Types;
using Mockie.Test.TestTypes;

namespace Mockie.Test.FactoryTest;

public class MockFactoryTest
{
    [Fact]
    public void Should_CreateMockWithCorrectType_When_CreatingMock()
    {
        // ARRANGE
        var mockFactory = new MockFactory();
        
        // ACT
        var mock = mockFactory.CreateMock<TestClass>();

        // ASSERT
        Assert.IsType<Mock<TestClass>>(mock);
    }
}