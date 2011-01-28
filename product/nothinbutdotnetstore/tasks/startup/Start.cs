using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartRunning
    {
        IList<StartupCommand> commands;
        StartupCommandFactory startup_command_factory;

        public StartRunning(StartupCommandFactory startup_command_factory)
        {
            this.commands = commands;
            this.startup_command_factory = startup_command_factory;
        }

        public void finish_by<CommandToRun>() where CommandToRun : StartupCommand
        {
            commands.Add(startup_command_factory.create_from(typeof(CommandToRun)));
            run();
        }

        void run()
        {
            foreach (var startup_command in commands)
            {
                startup_command.run();
            }
        }
    }
}