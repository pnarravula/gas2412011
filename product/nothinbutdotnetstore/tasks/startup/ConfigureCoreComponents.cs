using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreComponents : StartupCommand
    {
        IDictionary<Type, DependencyFactory> all_factories;

        public ConfigureCoreComponents(IDictionary<Type, DependencyFactory> all_factories)
        {
            this.all_factories = all_factories;
        }

        public void run()
        {
            var container = new BasicDependencyContainer(new BasicDependencyRegistry(all_factories));
            Container.facade_resolver = () => container;
            add_dependency_instance<DependencyContainer>(container);
        }

        void add_dependency_instance<Contract>(Contract instance)
        {
            all_factories.Add(typeof(Contract), new BasicDependencyFactory(() => instance));
        }

    }
}