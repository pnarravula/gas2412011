using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        IDictionary<Type,DependencyFactory> all_factories;

        public ConfigureServiceLayer(IDictionary<Type, DependencyFactory> all_factories)
        {
            this.all_factories = all_factories;
        }

        public void run()
        {
            add_factory<Catalog, StubCatalog>();
        }
        void add_factory<Contract, Implementation>()
        {
            //TODO - Need to inject the constructor strategy
            all_factories.Add(typeof(Contract),new AutomaticDependencyFactory(Container.fetch.a<DependencyContainer>(),
                null,typeof(Implementation)));
        }
    }
}