using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        IDictionary<Type, DependencyFactory> all_factories;

        public ConfigureFrontController(IDictionary<Type, DependencyFactory> all_factories)
        {
            this.all_factories = all_factories;
        }

        public void run()
        {
            add_factory<FrontController, DefaultFrontController>();
            add_factory<IEnumerable<RequestCommand>, StubSetOfCommands>();
            add_factory<RequestFactory, StubRequestFactory>();
            add_factory<CommandRegistry, DefaultCommandRegistry>();
            add_factory<TemplateRegistry, StubTemplateRegistry>();
            add_factory<Renderer, DefaultRenderer>();
        }


        void add_factory<Contract, Implementation>()
        {
            //TODO - Need to inject the constructor strategy
            all_factories.Add(typeof(Contract), new AutomaticDependencyFactory(Container.fetch.a<DependencyContainer>(),
                                                                               null, typeof(Implementation)));
        }
    }
}