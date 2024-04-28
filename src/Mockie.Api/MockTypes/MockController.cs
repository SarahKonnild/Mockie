using Microsoft.AspNetCore.Mvc;

namespace Mockie.Api.MockTypes
{
    public class MockController<TController> where TController : ControllerBase
    {
    }
}
