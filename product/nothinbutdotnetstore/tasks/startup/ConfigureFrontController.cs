using System.Collections.Generic;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : StartupCommand
    {
        ComponentRegistrationProvider component_registration_provider;

        public ConfigureFrontController(ComponentRegistrationProvider component_registration_provider)
        {
            this.component_registration_provider = component_registration_provider;
        }

        public void run()
        {
            component_registration_provider.register<FrontController, DefaultFrontController>();
            component_registration_provider.register<IEnumerable<RequestCommand>, StubSetOfCommands>();
            component_registration_provider.register<RequestFactory, StubRequestFactory>();
            component_registration_provider.register<CommandRegistry, DefaultCommandRegistry>();
            component_registration_provider.register<TemplateRegistry, StubTemplateRegistry>();
            component_registration_provider.register<Renderer, DefaultRenderer>();
        }
    }
}