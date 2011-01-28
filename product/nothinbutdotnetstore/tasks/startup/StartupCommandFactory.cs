using System;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandFactory
    {
        ComponentRegistrationProvider provider;

        public StartupCommandFactory(ComponentRegistrationProvider provider)
        {
            this.provider = provider;
        }


        public virtual StartupCommand create_from(Type command_type)
        {
            return (StartupCommand)command_type.GetConstructors()[0].Invoke(new object[]{provider});
        }
    }
}