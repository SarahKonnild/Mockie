using Mockie.Api.MockFactories;
using Xunit;

namespace Mockie.Api.Test
{
    public class MockControllerFactoryTest
    {
        [Fact]
        public void Should_CreateMockWithControllersMethods_When_UsingFactoryToCreateMock() 
        {
            // ARRANGE
            var mockControllerFactory = new MockControllerFactory();

            // ACT
            var mockController = mockControllerFactory.Create<ValuesController>();

            // ASSERT
        }
    }
}
