
using System;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tasks.startup
{

	public class Start
	{
		public static StartRunning by<T>() where T : StartupCommand
		{
			
			return new StartRunning(typeof(T));
		}

	}

	public class StartRunning
	{

		List<Type> commands_to_run = new List<Type>();

		public StartRunning(Type T)
		{
			commands_to_run.Add(T);
		}

		public StartRunning then_by<T>()
		{
			commands_to_run.Add(typeof(T));
			return this;
		}

		public void finish_by<T>()
		{
			commands_to_run.Add(typeof(T));
			Run();
		}

		private void Run()
		{
			foreach (Type type in commands_to_run)
			{


				ComponentRegistrationProvider registration_provider = new DefaultRegistrationProvider();

				if (type == typeof(ConfigureApplicationCommands))
				{
					ConfigureApplicationCommands cmd = new ConfigureApplicationCommands(registration_provider);
					cmd.run();
				}

				if (type == typeof(ConfigureApplicationCommands))
				{
					ConfigureApplicationCommands cmd = new ConfigureApplicationCommands(registration_provider);
					cmd.run();
				}

				if (type == typeof(ConfigureFrontController))
				{
					ConfigureFrontController cmd = new ConfigureFrontController(registration_provider);
					cmd.run();
				}

				if (type == typeof(ConfigureServiceLayer))
				{
					ConfigureServiceLayer cmd = new ConfigureServiceLayer(registration_provider);
					cmd.run();
				}

			
				// object[] args = new object[1];
				// args[0] = registration_provider;

				// Activator.CreateInstance(type, args);
				// ((StartupCommand) obj).run();



				
			}
		}

	}


}