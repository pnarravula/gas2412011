using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultComponentRegistrationProvider : Dictionary<Type,DependencyFactory>,ComponentRegistrationProvider
    {
        DependencyFactories dependency_factories;

        public DefaultComponentRegistrationProvider(DependencyFactories dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public void register<Contract, Implementation>()
        {
            Add(typeof(Contract),dependency_factories.create_factory(typeof(Contract),
                typeof(Implementation)));
        }

        public void register<Implementation>()
        {
            Add(typeof(Implementation),
                dependency_factories.create_factory(typeof(Implementation)));
        }

        public void register<Contract>(Contract contract)
        {
            Add(typeof(Contract),
                dependency_factories.create_factory(contract));
        }
    }
}