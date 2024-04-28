using Microsoft.AspNetCore.Mvc;
using Mockie.Api.MockTypes;
using System.Reflection;

namespace Mockie.Api.MockFactories
{
    public class MockControllerFactory
    {
        public MockController<TController> Create<TController>() where TController : ControllerBase 
        {
            // Http Attribute, we look at the CustomAttributes. The get-method is e.g. HttpGetAttribute
            MethodInfo[] methods = typeof(TController).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            return new MockController<TController>();
        }
    }
}
