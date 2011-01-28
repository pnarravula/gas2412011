using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreComponents : StartupCommand
    {
        ComponentRegistrationProvider component_registration_provider;

        public ConfigureCoreComponents(ComponentRegistrationProvider component_registration_provider)
        {
            this.component_registration_provider = component_registration_provider;
        }

        public void run()
        {
            var container =
                new BasicDependencyContainer(new BasicDependencyRegistry(null));
            Container.facade_resolver = () => container;
            component_registration_provider.register<DependencyContainer>(container);
        }
    }
}