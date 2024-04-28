namespace Mockie.Api.MockTypes
{
    public class MockWebApplication
    {
        private readonly WebApplicationBuilder _webApplicationBuilder;

        public MockWebApplication()
        {
            _webApplicationBuilder = WebApplication.CreateBuilder();
        }


    }
}
