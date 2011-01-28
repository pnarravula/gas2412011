 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.infrastructure
{   
	public class StartupSpec
	{
		public abstract class concern : Observes<Start>
		{
        
		}

		[Subject(typeof(Start))]
		public class when_application_starts : concern
		{

			It should_create_the_four_startup_commands_and_run_them = () =>
				Start.by<ConfigureCoreComponents>()
				.then_by<ConfigureFrontController>()
				.then_by<ConfigureServiceLayer>()
				.finish_by<ConfigureApplicationCommands>();
			
			// ConfigureApplicationCommands
			// ConfigureApplicationCommands
			// ConfigureFrontController
			// ConfigureServiceLayer

		}
	}
}
