using System;
using System.Reflection;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public delegate ConstructorInfo GetConstructor();
    public class AutomaticDependencyFactory : DependencyFactory
    {
        DependencyContainer container;
        GetConstructor get_constructor;

        public AutomaticDependencyFactory(DependencyContainer container, GetConstructor get_constructor)
        {
            this.container = container;
            this.get_constructor = get_constructor;
        }

        public object create()
        {
            var constructor_info = get_constructor();
            var arguments = constructor_info.GetParameters()
                .Select(x => container.a(x.ParameterType));

            return constructor_info.Invoke(arguments.ToArray());

        }
    }
}