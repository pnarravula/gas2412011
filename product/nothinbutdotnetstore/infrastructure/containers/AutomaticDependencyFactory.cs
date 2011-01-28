using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface ConstructorSelection
    {
        ConstructorInfo get_applicable_constructor_on(Type type);
    }

    public class AutomaticDependencyFactory : DependencyFactory
    {
        DependencyContainer container;
        ConstructorSelection constructor_selection;
        Type type_to_create;

        public AutomaticDependencyFactory(DependencyContainer container, ConstructorSelection constructor_selection, Type type_to_create)
        {
            this.container = container;
            this.type_to_create = type_to_create;
            this.constructor_selection = constructor_selection;
        }

        public object create()
        {
            var constructor_info = constructor_selection.get_applicable_constructor_on(type_to_create);

            var arguments = constructor_info.GetParameters()
                .Select(x => container.a(x.ParameterType));

            return constructor_info.Invoke(arguments.ToArray());
        }
    }
}