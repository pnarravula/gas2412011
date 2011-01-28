using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : StartupCommand
    {
        ComponentRegistrationProvider component_registration_provider;

        public ConfigureServiceLayer(ComponentRegistrationProvider component_registration_provider)
        {
            this.component_registration_provider = component_registration_provider;
        }

        public void run()
        {
            component_registration_provider.register<Catalog, StubCatalog>();
        }
    }
}