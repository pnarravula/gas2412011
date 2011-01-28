using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : StartupCommand
    {
        ComponentRegistrationProvider registration_provider;

        public ConfigureApplicationCommands(ComponentRegistrationProvider registration_provider)
        {
            this.registration_provider = registration_provider;
        }

        public void run()
        {
            registration_provider.register<ViewMainDepartments>();
        }
    }
}