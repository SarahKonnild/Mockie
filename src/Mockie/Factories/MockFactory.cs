using System.Reflection;
using System.Reflection.Emit;
using Mockie.Types;

namespace Mockie.Factories
{
    internal class MockFactory
    {
        public Mock<T> CreateMock<T>() where T : class 
        {
            // Create a new dynamic assembly
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder =
                AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            
            // Define a new type dynamically
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicClass", TypeAttributes.Public);
            
            // Implement the interface in the dynamic class
            typeBuilder.AddInterfaceImplementation(typeof(T));
            
            // Get the methods from the source type and add them to the new type
            foreach (MethodInfo methodInfo in typeof(T).GetMethods())
            {
                // Define the method in the new type
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    methodInfo.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    methodInfo.ReturnType,
                    Array.ConvertAll(methodInfo.GetParameters(), p => p.ParameterType)
                );
                
                // Generate IL code to throw NotImplementedException for each method
                ILGenerator ilGenerator = methodBuilder.GetILGenerator();
                ilGenerator.Emit(OpCodes.Newobj, typeof(NotImplementedException).GetConstructor(Type.EmptyTypes));
                ilGenerator.Emit(OpCodes.Throw);
                
                // Complete the method definition
                typeBuilder.DefineMethodOverride(methodBuilder, methodInfo);
            }
            
            // return typeBuilder.CreateType();
            return new Mock<T>();
        }
    }
}
