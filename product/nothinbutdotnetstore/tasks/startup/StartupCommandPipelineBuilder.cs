using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public class StartupCommandPipelineBuilder
    {
        public IList<StartupCommand> commands;
        public StartupCommandFactory startup_command_factory;

        public StartupCommandPipelineBuilder(IList<StartupCommand> commands,StartupCommandFactory startup_command_factory)
        {
            this.commands = commands;
            this.startup_command_factory = startup_command_factory;
        }

        public void finish_by<CommandToRun>() where CommandToRun : StartupCommand
        {
            append_command(typeof(CommandToRun));
            run();
        }

        void run()
        {
            foreach (var startup_command in commands)
            {
                startup_command.run();
            }
        }

        public StartupCommandPipelineBuilder then_by<CommandToRun>() where CommandToRun : StartupCommand
        {
            append_command(typeof(CommandToRun));
            return new StartupCommandPipelineBuilder(commands, startup_command_factory);
        }

        void append_command(Type command_type)
        {
            commands.Add(startup_command_factory.create_from(command_type));
        }
    }
}