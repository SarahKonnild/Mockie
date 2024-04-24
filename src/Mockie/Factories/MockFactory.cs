using Mockie.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockie.Factories
{
    internal class MockFactory
    {
        public Mock<T> CreateMock<T>() where T : class 
        {
            return new Mock<T>();
        }
    }
}
