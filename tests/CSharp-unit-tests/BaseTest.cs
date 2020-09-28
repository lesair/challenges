using System.Collections.Generic;
using System.Reflection;

namespace CSharp
{
    public abstract class BaseTest
    {
        protected string ImplementationMethodsPrefix = string.Empty;
        protected string ImplementationMethodsSuffix = "Implementation";
        protected IReflect TypeToTest;

        protected IEnumerable<MethodInfo> ImplementationsToTest()
        {
            var infos = TypeToTest.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (var methodInfo in infos)
                if (methodInfo.Name.StartsWith(ImplementationMethodsPrefix) &&
                    methodInfo.Name.EndsWith(ImplementationMethodsSuffix))
                    yield return methodInfo;
        }
    }
}